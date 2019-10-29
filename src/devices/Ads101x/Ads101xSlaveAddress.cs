// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Iot.Device.Ads101x
{
    /// <summary>
    /// The ADS101x have one address pin, ADDR, that configures the I2C address of the device. 
    /// This pin can be connected to GND, VDD, SDA, or SCL, allowing for four different addresses to be selected with one pin, as shown in Table 2. 
    /// The state of address pin ADDR is sampled continuously. 
    /// Use the GND, VDD and SCL addresses first. 
    /// If SDA is used as the device address, hold the SDA line low for at least 100 ns after the SCL line goes low to make sure the device decodes the address correctly during I2C communication.
    /// Page 19, Table 2
    /// </summary>
    public enum Ads101xSlaveAddress
    {
        /// <summary>
        /// I2C General Call
        /// The ADS101x respond to the I2C general call address (0000000) if the eighth bit is 0. 
        /// The devices acknowledge the general call address and respond to commands in the second byte. 
        /// If the second byte is 00000110 (06h), the ADS101x reset the internal registers and enter a power-down state.
        /// </summary>
        General = 0b00000000,

        /// <summary>
        /// Address pin connected to GND
        /// </summary>
        GND = 0b1001000,

        /// <summary>
        /// Address pin connected to VDD
        /// </summary>
        VDD = 0b1001001,
        
        /// <summary>
        /// Address pin connected to SDA
        /// </summary>
        SDA = 0b1001010,

        /// <summary>
        /// Address pin connected to SCL
        /// </summary>
        SCL = 0b1001011,
    }
}