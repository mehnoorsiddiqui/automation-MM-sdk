// <copyright file="AsyncReportResponse.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace MessageMedia.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MessageMedia.Standard;
    using MessageMedia.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// AsyncReportResponse.
    /// </summary>
    public class AsyncReportResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncReportResponse"/> class.
        /// </summary>
        public AsyncReportResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncReportResponse"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        public AsyncReportResponse(
            string id = null)
        {
            this.Id = id;
        }

        /// <summary>
        /// The identifier for this async report
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AsyncReportResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is AsyncReportResponse other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
        }
    }
}