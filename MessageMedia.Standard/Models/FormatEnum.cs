// <copyright file="FormatEnum.cs" company="APIMatic">
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
    /// FormatEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FormatEnum
    {
        /// <summary>
        /// SMS.
        /// </summary>
        [EnumMember(Value = "SMS")]
        SMS,

        /// <summary>
        /// TTS.
        /// </summary>
        [EnumMember(Value = "TTS")]
        TTS,

        /// <summary>
        /// MMS.
        /// </summary>
        [EnumMember(Value = "MMS")]
        MMS,
    }
}