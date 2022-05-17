// <copyright file="OrderEnum.cs" company="APIMatic">
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
    /// OrderEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderEnum
    {
        /// <summary>
        /// ASCENDING.
        /// </summary>
        [EnumMember(Value = "ASCENDING")]
        ASCENDING,

        /// <summary>
        /// DESCENDING.
        /// </summary>
        [EnumMember(Value = "DESCENDING")]
        DESCENDING
    }
}