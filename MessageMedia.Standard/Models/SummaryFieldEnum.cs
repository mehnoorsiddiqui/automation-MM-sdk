// <copyright file="SummaryFieldEnum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace MessageMedia.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using MessageMedia.Standard;
    using MessageMedia.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// SummaryFieldEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SummaryFieldEnum
    {
        /// <summary>
        /// UNITS.
        /// </summary>
        [EnumMember(Value = "UNITS")]
        UNITS,

        /// <summary>
        /// MESSAGEID.
        /// </summary>
        [EnumMember(Value = "MESSAGE_ID")]
        MESSAGEID
    }
}