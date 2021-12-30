// <copyright file="ActionEnum.cs" company="APIMatic">
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
    /// ActionEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActionEnum
    {
        /// <summary>
        /// MyAccount001.
        /// </summary>
        [EnumMember(Value = "MyAccount001")]
        MyAccount001,

        /// <summary>
        /// OPTOUT.
        /// </summary>
        [EnumMember(Value = "OPT_OUT")]
        OPTOUT,

        /// <summary>
        /// OPTIN.
        /// </summary>
        [EnumMember(Value = "OPT_IN")]
        OPTIN,

        /// <summary>
        /// GLOBALOPTOUT.
        /// </summary>
        [EnumMember(Value = "GLOBAL_OPT_OUT")]
        GLOBALOPTOUT,
    }
}