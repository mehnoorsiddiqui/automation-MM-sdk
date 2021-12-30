// <copyright file="Type1Enum.cs" company="APIMatic">
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
    /// Type1Enum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Type1Enum
    {
        /// <summary>
        /// MOBILE.
        /// </summary>
        [EnumMember(Value = "MOBILE")]
        MOBILE,

        /// <summary>
        /// LANDLINE.
        /// </summary>
        [EnumMember(Value = "LANDLINE")]
        LANDLINE,

        /// <summary>
        /// TOLLFREE.
        /// </summary>
        [EnumMember(Value = "TOLL_FREE")]
        TOLLFREE,

        /// <summary>
        /// SHORTCODE.
        /// </summary>
        [EnumMember(Value = "SHORT_CODE")]
        SHORTCODE,
    }
}