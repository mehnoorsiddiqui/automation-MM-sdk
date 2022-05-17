// <copyright file="GroupByEnum.cs" company="APIMatic">
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
    /// GroupByEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GroupByEnum
    {
        /// <summary>
        /// DAY.
        /// </summary>
        [EnumMember(Value = "DAY")]
        DAY,

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
        /// HOUR.
        /// </summary>
        [EnumMember(Value = "HOUR")]
        HOUR,

        /// <summary>
        /// METADATAKEY.
        /// </summary>
        [EnumMember(Value = "METADATA_KEY")]
        METADATAKEY,

        /// <summary>
        /// METADATAVALUE.
        /// </summary>
        [EnumMember(Value = "METADATA_VALUE")]
        METADATAVALUE,

        /// <summary>
        /// MINUTE.
        /// </summary>
        [EnumMember(Value = "MINUTE")]
        MINUTE,

        /// <summary>
        /// MONTH.
        /// </summary>
        [EnumMember(Value = "MONTH")]
        MONTH,

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
        /// STATUS.
        /// </summary>
        [EnumMember(Value = "STATUS")]
        STATUS,

        /// <summary>
        /// STATUSCODE.
        /// </summary>
        [EnumMember(Value = "STATUS_CODE")]
        STATUSCODE,

        /// <summary>
        /// YEAR.
        /// </summary>
        [EnumMember(Value = "YEAR")]
        YEAR,

        /// <summary>
        /// ACCOUNT.
        /// </summary>
        [EnumMember(Value = "ACCOUNT")]
        ACCOUNT
    }
}