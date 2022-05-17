// <copyright file="SummaryByEnum.cs" company="APIMatic">
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
    /// SummaryByEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SummaryByEnum
    {
        /// <summary>
        /// COUNT.
        /// </summary>
        [EnumMember(Value = "COUNT")]
        COUNT
    }
}