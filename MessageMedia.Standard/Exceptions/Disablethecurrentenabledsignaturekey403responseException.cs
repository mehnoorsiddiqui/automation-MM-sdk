// <copyright file="Disablethecurrentenabledsignaturekey403responseException.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace MessageMedia.Standard.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MessageMedia.Standard;
    using MessageMedia.Standard.Http.Client;
    using MessageMedia.Standard.Models;
    using MessageMedia.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Disablethecurrentenabledsignaturekey403responseException.
    /// </summary>
    public class Disablethecurrentenabledsignaturekey403responseException : ApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Disablethecurrentenabledsignaturekey403responseException"/> class.
        /// </summary>
        /// <param name="reason"> The reason for throwing exception.</param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects.</param>
        public Disablethecurrentenabledsignaturekey403responseException(string reason, HttpContext context)
            : base(reason, context)
        {
        }

        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        [JsonProperty("message")]
        public new string Message { get; set; }
    }
}