// <copyright file="MessageTypeEnum.cs" company="APIMatic">
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
    /// MessageTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageTypeEnum
    {
        /// <summary>
        /// SENTMESSAGES.
        /// </summary>
        [EnumMember(Value = "SENT_MESSAGES")]
        SENTMESSAGES,

        /// <summary>
        /// RECEIVEDMESSAGES.
        /// </summary>
        [EnumMember(Value = "RECEIVED_MESSAGES")]
        RECEIVEDMESSAGES
    }
}