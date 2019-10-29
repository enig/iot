// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Iot.Device.Ads101x
{
    /// <summary>
    /// Operational status or single-shot conversion start
    /// This bit determines the operational status of the device. 
    /// OS can only be written when in power-down state and has no effect when a conversion is ongoing.
    /// When writing:
    /// 0 : No effect
    /// 1 : Start a single conversion (when in power-down state)
    /// When reading:
    /// 0 : Device is currently performing a conversion
    /// 1 : Device is not currently performing a conversion
    /// </summary>
    public enum Ads101xOperationStatus
    {
        /// <summary>
        /// When writing:
        /// 0 : No effect
        /// 1 : Start a single conversion (when in power-down state)
        /// When reading:
        /// 0 : Device is currently performing a conversion
        /// 1 : Device is not currently performing a conversion
        /// </summary>
        NoEffect = 0b0000000000000000,

        /// <summary>
        /// When writing:
        /// 0 : No effect
        /// 1 : Start a single conversion (when in power-down state)
        /// When reading:
        /// 0 : Device is currently performing a conversion
        /// 1 : Device is not currently performing a conversion
        /// </summary>
        SingleConversion = 0b1000000000000000
    }
}