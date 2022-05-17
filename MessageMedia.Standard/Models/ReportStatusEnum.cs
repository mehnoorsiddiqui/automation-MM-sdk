// <copyright file="ReportStatusEnum.cs" company="APIMatic">
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
    /// ReportStatusEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportStatusEnum
    {
        /// <summary>
        /// REQUESTED.
        /// </summary>
        [EnumMember(Value = "REQUESTED")]
        REQUESTED,

        /// <summary>
        /// RUNNING.
        /// </summary>
        [EnumMember(Value = "RUNNING")]
        RUNNING,

        /// <summary>
        /// CANCELLED.
        /// </summary>
        [EnumMember(Value = "CANCELLED")]
        CANCELLED,

        /// <summary>
        /// DONE.
        /// </summary>
        [EnumMember(Value = "DONE")]
        DONE
    }
}