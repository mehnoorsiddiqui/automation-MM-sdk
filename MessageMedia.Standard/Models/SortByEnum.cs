// <copyright file="SortByEnum.cs" company="APIMatic">
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
    /// SortByEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortByEnum
    {
        /// <summary>
        /// ACCOUNT.
        /// </summary>
        [EnumMember(Value = "ACCOUNT")]
        ACCOUNT,

        /// <summary>
        /// ACTION.
        /// </summary>
        [EnumMember(Value = "ACTION")]
        ACTION,

        /// <summary>
        /// DESTINATIONADDRESS.
        /// </summary>
        [EnumMember(Value = "DESTINATION_ADDRESS")]
        DESTINATIONADDRESS,

        /// <summary>
        /// DESTINATIONADDRESSCOUNTRY.
        /// </summary>
        [EnumMember(Value = "DESTINATION_ADDRESS_COUNTRY")]
        DESTINATIONADDRESSCOUNTRY,

        /// <summary>
        /// FORMAT.
        /// </summary>
        [EnumMember(Value = "FORMAT")]
        FORMAT,

        /// <summary>
        /// SOURCEADDRESS.
        /// </summary>
        [EnumMember(Value = "SOURCE_ADDRESS")]
        SOURCEADDRESS,

        /// <summary>
        /// SOURCEADDRESSCOUNTRY.
        /// </summary>
        [EnumMember(Value = "SOURCE_ADDRESS_COUNTRY")]
        SOURCEADDRESSCOUNTRY,

        /// <summary>
        /// TIMESTAMP.
        /// </summary>
        [EnumMember(Value = "TIMESTAMP")]
        TIMESTAMP,
    }
}