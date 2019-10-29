// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Iot.Device.Ads101x
{
    /// <summary>
    /// Programmable gain amplifier configuration
    /// These bits set the FSR of the programmable gain amplifier. These bits serve no function on the ADS1013.
    /// 000 : FSR = ±6.144 V(1)
    /// 001 : FSR = ±4.096 V(1)
    /// 010 : FSR = ±2.048 V (default)
    /// 011 : FSR = ±1.024 V
    /// 100 : FSR = ±0.512 V
    /// 101 : FSR = ±0.256 V
    /// 110 : FSR = ±0.256 V
    /// 111 : FSR = ±0.256 V
    /// Page 24, Table 6
    /// </summary>
    public enum Ads101xConfigGain
    {
        /// <summary>
        /// Not supported
        /// </summary>
        NotSupported = -1,
       
        /// <summary>
        /// Gain 1
        /// FSR = ±2.048 V (default)
        /// </summary>
        Gain1FSR2V048 = 0b0000001000000000, //0x0200,

        /// <summary>
        /// Gain 2
        /// FSR = ±6.144 V(1)
        /// </summary>
        Gain2div3FSR6V144 = 0b0000000000000000, //0x0000,

        /// <summary>
        /// Gain ?
        /// FSR = ±4.096 V(1)
        /// </summary>
        FSR4V096 = 0b0000000100000000, //0x0100,

        /// <summary>
        /// Gain ?
        /// FSR = ±1.024 V
        /// </summary>
        FSR1V024 = 0b0000001100000000, //0x0300,

        /// <summary>
        /// Gain 2
        /// FSR = ±0.512 V
        /// </summary>
        Gain2FSR0V512 = 0b0000010000000000, //0x0400,

        /// <summary>
        /// Gain 4
        /// FSR = ±0.256 V
        /// </summary>
        Gain4FSR0V256 = 0b0000011000000000, //0x0600,

        /// <summary>
        /// Gain 8
        /// FSR = ±0.256 V
        /// </summary>
        Gain8FSR0V256 = 0b0000100000000000, //0x0800,

        /// <summary>
        /// Gain 16
        /// FSR = ±0.256 V
        /// </summary>
        Gain16FSR0V256 = 0b0000101000000000, //0x0A00,
    }
}