// <copyright file="ClassificationEnum.cs" company="APIMatic">
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
    /// ClassificationEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ClassificationEnum
    {
        /// <summary>
        /// BRONZE.
        /// </summary>
        [EnumMember(Value = "BRONZE")]
        BRONZE,

        /// <summary>
        /// SILVER.
        /// </summary>
        [EnumMember(Value = "SILVER")]
        SILVER,

        /// <summary>
        /// GOLD.
        /// </summary>
        [EnumMember(Value = "GOLD")]
        GOLD,
    }
}