// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Iot.Device.Ads101x
{
    /// <summary>
    /// The ADS101x have four registers that are accessible through the I2C interface using the Address Pointer register. 
    /// The Conversion register contains the result of the last conversion. 
    /// The Config register is used to change the ADS101x operating modes and query the status of the device. 
    /// The other two registers, Lo_thresh and Hi_thresh, set the threshold values used for the comparator function, and are not available in the ADS1013.
    /// Page 23
    /// </summary>
    public enum Ads101xAddresPointerAddress
    {
        /// <summary>
        /// Conversion Register (P[1:0] = 0h) [reset = 0000h]
        /// The 16-bit Conversion register contains the result of the last conversion in binary two's complement format.
        /// Following power-up, the Conversion register is cleared to 0, and remains 0 until the first conversion is completed.
        /// Page 23, Figure 20, Table 5
        /// </summary>
        ConversionRegister = 0b00000000,

        /// <summary>
        /// Config Register (P[1:0] = 1h) [reset = 8583h]
        /// The 16-bit Config register is used to control the operating mode, input selection, data rate, full-scale range, and comparator modes.
        /// Page 24, Figure 21, Table 6
        /// </summary>
        ConfigRegister = 0b00000001,

        /// <summary>
        /// <see cref="AdsModel.Ads1013"/> not supported.
        /// Hi_thresh (P[1:0] = 3h) [reset = 7FFFh] Registers
        /// The upper and lower threshold values used by the comparator are stored in two 16-bit registers in two's complement format. 
        /// The comparator is implemented as a digital comparator; therefore, the values in these registers must be updated whenever the PGA settings are changed.
        /// The conversion-ready function of the ALERT/RDY pin is enabled by setting the Hi_thresh register MSB to 1 and the Lo_thresh register MSB to 0. 
        /// To use the comparator function of the ALERT/RDY pin, the Hi_thresh register value must always be greater than the Lo_thresh register value. 
        /// The threshold register formats are shown in Figure 22. When set to RDY mode, the ALERT/RDY pin outputs the OS bit when in single-shot mode, and provides a continuous-conversion ready pulse when in continuous-conversion mode.
        /// Page 26, Figure 22, Table 7
        /// </summary>
        HiThreshRegister = 0b00000010,

        /// <summary>
        /// <see cref="AdsModel.Ads1013"/> not supported.
        /// Lo_thresh (P[1:0] = 2h) [reset = 8000h] Registers
        /// The upper and lower threshold values used by the comparator are stored in two 16-bit registers in two's complement format. 
        /// The comparator is implemented as a digital comparator; therefore, the values in these registers must be updated whenever the PGA settings are changed.
        /// The conversion-ready function of the ALERT/RDY pin is enabled by setting the Hi_thresh register MSB to 1 and the Lo_thresh register MSB to 0. 
        /// To use the comparator function of the ALERT/RDY pin, the Hi_thresh register value must always be greater than the Lo_thresh register value. 
        /// The threshold register formats are shown in Figure 22. When set to RDY mode, the ALERT/RDY pin outputs the OS bit when in single-shot mode, and provides a continuous-conversion ready pulse when in continuous-conversion mode.
        /// Page 26, Figure 23, Table 7
        /// </summary>
        LoThreshRegister = 0b00000011,

    }
}