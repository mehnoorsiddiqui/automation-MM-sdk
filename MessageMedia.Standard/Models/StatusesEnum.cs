// <copyright file="StatusesEnum.cs" company="APIMatic">
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
    /// StatusesEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusesEnum
    {
        /// <summary>
        /// CANCELLED.
        /// </summary>
        [EnumMember(Value = "CANCELLED")]
        CANCELLED,

        /// <summary>
        /// DELIVERED.
        /// </summary>
        [EnumMember(Value = "DELIVERED")]
        DELIVERED,

        /// <summary>
        /// ENROUTE.
        /// </summary>
        [EnumMember(Value = "ENROUTE")]
        ENROUTE,

        /// <summary>
        /// EXPIRED.
        /// </summary>
        [EnumMember(Value = "EXPIRED")]
        EXPIRED,

        /// <summary>
        /// HELD.
        /// </summary>
        [EnumMember(Value = "HELD")]
        HELD,

        /// <summary>
        /// PROCESSED.
        /// </summary>
        [EnumMember(Value = "PROCESSED")]
        PROCESSED,

        /// <summary>
        /// PROCESSING.
        /// </summary>
        [EnumMember(Value = "PROCESSING")]
        PROCESSING,

        /// <summary>
        /// QUEUED.
        /// </summary>
        [EnumMember(Value = "QUEUED")]
        QUEUED,

        /// <summary>
        /// REJECTED.
        /// </summary>
        [EnumMember(Value = "REJECTED")]
        REJECTED,

        /// <summary>
        /// SCHEDULED.
        /// </summary>
        [EnumMember(Value = "SCHEDULED")]
        SCHEDULED,

        /// <summary>
        /// SUBMITTED.
        /// </summary>
        [EnumMember(Value = "SUBMITTED")]
        SUBMITTED
    }
}