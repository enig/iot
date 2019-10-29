// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Iot.Device.Ads101x
{
    /// <summary>
    /// Device operating mode
    /// This bit controls the operating mode.
    /// 0 : Continuous-conversion mode
    /// 1 : Single-shot mode or power-down state (default)
    /// </summary>
    public enum Ads101xDeviceOperationMode
    {
        /// <summary>
        /// Single-shot mode or power-down state (default)
        /// </summary>
        SingleShotOrPowerDown = 0b0000000100000000,

        /// <summary>
        /// Continuous-conversion mode
        /// </summary>
        ContinuousConversion = 0b0000000000000000

    }
}