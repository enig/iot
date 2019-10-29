// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Buffers.Binary;
using System.Threading;
using System.Device.I2c;
using System.Diagnostics;
using System.Collections.Generic;

namespace Iot.Device.Ads101x
{
    /// <summary>
    /// Analog-to-Digital Converter Ads101x
    /// </summary>
    public class Ads101x : IDisposable
    {
        /// <summary>
        /// I2C device driver
        /// </summary>
        public I2cDevice I2cDevice { get; }

        /// <summary>
        /// Ads model type
        /// </summary>
        public AdsModel AdsModel { get; }

        /// <summary>
        /// Initialize a new Ads101x device connected through I2C
        /// </summary>
        /// <param name="i2cDevice">The I2C device used for communication.</param>
        public Ads101x(I2cDevice i2cDevice, AdsModel model)
        {
            this.I2cDevice = i2cDevice ?? throw new ArgumentNullException(nameof(i2cDevice));
            this.AdsModel = model;
            //ResetAll();
        }

        /// <summary>
        /// Get pin raw value
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="gain"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        public int GetRawValue(Ads101xPin pin, Ads10xSamplePerSecond sample, Ads101xConfigGain gain = Ads101xConfigGain.NotSupported)
        {
            //Config Register
            //FEDCBA9876543210
            //OMMMPPPMDDDCPLQQ
            //O: OS         0bx000000000000000
            //M: MUX        0b0xxx000000000000
            //P: PGA        0b0000xxx000000000
            //M: MODE       0b0000000x00000000
            //D: DR         0b00000000xxx00000
            //C: COMP_MODE  0b00000000000x0000
            //P: COMP_POL   0b000000000000x000
            //L: COMP_LAT   0b0000000000000x00
            //Q: COMP_QUE   0b00000000000000xx

            // Set disable comparator and set "single shot" mode
            if (AdsModel == AdsModel.Ads1013 && gain != Ads101xConfigGain.NotSupported)
            {
                throw new ArgumentOutOfRangeException(nameof(gain), gain, "Ads1013 not supported gain configuration.");
            }
            var config = 0
                | (ushort)Ads101xDeviceOperationMode.SingleShotOrPowerDown
                | (ushort)Ads101xOperationStatus.SingleConversion;
            config |= (ushort)sample;
            config |= (ushort)pin;
            if (gain != Ads101xConfigGain.NotSupported)
            {
                config |= (ushort)Ads101xAddresPointerAddress.LoThreshRegister;
                config |= (ushort)gain;
            }
            var data = new byte[3];
            data[0] = (byte)Ads101xAddresPointerAddress.ConfigRegister;
            data[1] = (byte)((config >> 8) & 0xFF);
            data[2] = (byte)(config & 0xFF);
            System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(1)).Wait();
            Trace.TraceInformation($"Ads101x send : {BitConverter.ToString(data)}");
            I2cDevice.Write(data);
            System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(1)).Wait();
            var result = new byte[2];
            I2cDevice.WriteRead(new byte[] { (byte)Ads101xAddresPointerAddress.ConversionRegister, 0x00 }, result);
            Trace.TraceInformation($"Ads101x result : {BitConverter.ToString(result)}");
            var gainScale = new Dictionary<Ads101xConfigGain, ushort>() {
                { Ads101xConfigGain.Gain2div3FSR6V144, 6144},
                { Ads101xConfigGain.FSR4V096, 4096},
                { Ads101xConfigGain.Gain1FSR2V048, 2048 },
                { Ads101xConfigGain.FSR1V024, 1024 },
                { Ads101xConfigGain.Gain2FSR0V512, 512 },
                { Ads101xConfigGain.Gain4FSR0V256, 256 },
                { Ads101xConfigGain.Gain8FSR0V256, 256 }
            };
            var milliVolts = (((result[0] << 8) | result[1]) >> 4);// * gainScale[gain] / 2048;
            return milliVolts;
        }

        /// <summary>
        /// Cleanup
        /// </summary>
        public void Dispose()
        {
            //if (I2cDevice != null)
            //{
            //    I2cDevice?.Dispose();
            //    I2cDevice = null;
            //}
        }
    }
}