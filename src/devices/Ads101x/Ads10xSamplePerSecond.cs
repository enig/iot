// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Iot.Device.Ads101x
{
    public enum Ads10xSamplePerSecond
    {
        /// <summary>
        /// 1600 sample per second rate (default)
        /// </summary>
        SPSR1600 = 0x0080,

        /// <summary>
        /// 128 sample per second rate
        /// </summary>
        SPSR128 = 0x0000,

        /// <summary>
        /// 250 sample per second rate
        /// </summary>
        SPSR250 = 0x0020,

        /// <summary>
        /// 490 sample per second rate
        /// </summary>
        SPSR490 = 0x0040,

        /// <summary>
        /// 920 sample per second rate
        /// </summary>
        SPSR920 = 0x0060,

        /// <summary>
        /// 2400 sample per second rate
        /// </summary>
        SPSR2400 = 0x00A0,

        /// <summary>
        /// 3300 sample per second rate
        /// </summary>
        SPSR3300 = 0x00C0
    }
}