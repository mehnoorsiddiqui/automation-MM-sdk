// <copyright file="FieldEnum.cs" company="APIMatic">
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
    /// FieldEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FieldEnum
    {
        /// <summary>
        /// ACCOUNT.
        /// </summary>
        [EnumMember(Value = "ACCOUNT")]
        ACCOUNT,

        /// <summary>
        /// DELIVEREDTIMESTAMP.
        /// </summary>
        [EnumMember(Value = "DELIVERED_TIMESTAMP")]
        DELIVEREDTIMESTAMP,

        /// <summary>
        /// MESSAGEEXPIRYTIMESTAMP.
        /// </summary>
        [EnumMember(Value = "MESSAGE_EXPIRY_TIMESTAMP")]
        MESSAGEEXPIRYTIMESTAMP,

        /// <summary>
        /// DELIVERYREPORT.
        /// </summary>
        [EnumMember(Value = "DELIVERY_REPORT")]
        DELIVERYREPORT,

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
        /// UNITS.
        /// </summary>
        [EnumMember(Value = "UNITS")]
        UNITS,

        /// <summary>
        /// TIMESTAMP.
        /// </summary>
        [EnumMember(Value = "TIMESTAMP")]
        TIMESTAMP
    }
}