// <copyright file="PeriodEnum.cs" company="APIMatic">
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
    /// PeriodEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PeriodEnum
    {
        /// <summary>
        /// TODAY.
        /// </summary>
        [EnumMember(Value = "TODAY")]
        TODAY,

        /// <summary>
        /// YESTERDAY.
        /// </summary>
        [EnumMember(Value = "YESTERDAY")]
        YESTERDAY,

        /// <summary>
        /// THISWEEK.
        /// </summary>
        [EnumMember(Value = "THIS_WEEK")]
        THISWEEK,

        /// <summary>
        /// LASTWEEK.
        /// </summary>
        [EnumMember(Value = "LAST_WEEK")]
        LASTWEEK,

        /// <summary>
        /// THISMONTH.
        /// </summary>
        [EnumMember(Value = "THIS_MONTH")]
        THISMONTH,

        /// <summary>
        /// LASTMONTH.
        /// </summary>
        [EnumMember(Value = "LAST_MONTH")]
        LASTMONTH,

        /// <summary>
        /// LAST7DAYS.
        /// </summary>
        [EnumMember(Value = "LAST_7_DAYS")]
        LAST7DAYS,

        /// <summary>
        /// LAST30DAYS.
        /// </summary>
        [EnumMember(Value = "LAST_30_DAYS")]
        LAST30DAYS,
    }
}