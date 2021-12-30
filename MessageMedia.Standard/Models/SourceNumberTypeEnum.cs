// <copyright file="SourceNumberTypeEnum.cs" company="APIMatic">
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
    /// SourceNumberTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SourceNumberTypeEnum
    {
        /// <summary>
        /// INTERNATIONAL.
        /// </summary>
        [EnumMember(Value = "INTERNATIONAL")]
        INTERNATIONAL,

        /// <summary>
        /// ALPHANUMERIC.
        /// </summary>
        [EnumMember(Value = "ALPHANUMERIC")]
        ALPHANUMERIC,

        /// <summary>
        /// SHORTCODE.
        /// </summary>
        [EnumMember(Value = "SHORTCODE")]
        SHORTCODE,
    }
}