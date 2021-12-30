// <copyright file="ReceivedMessages.cs" company="APIMatic">
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
    /// ReceivedMessages.
    /// </summary>
    public class ReceivedMessages
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedMessages"/> class.
        /// </summary>
        public ReceivedMessages()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedMessages"/> class.
        /// </summary>
        /// <param name="data">data.</param>
        /// <param name="pagination">pagination.</param>
        /// <param name="properties">properties.</param>
        public ReceivedMessages(
            List<Models.ReceivedMessage> data = null,
            Models.Pagination1 pagination = null,
            Models.ReportingDetailProperties properties = null)
        {
            this.Data = data;
            this.Pagination = pagination;
            this.Properties = properties;
        }

        /// <summary>
        /// List of received messages
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.ReceivedMessage> Data { get; set; }

        /// <summary>
        /// Gets or sets Pagination.
        /// </summary>
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Pagination1 Pagination { get; set; }

        /// <summary>
        /// Gets or sets Properties.
        /// </summary>
        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ReportingDetailProperties Properties { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ReceivedMessages : ({string.Join(", ", toStringOutput)})";
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

            return obj is ReceivedMessages other &&
                ((this.Data == null && other.Data == null) || (this.Data?.Equals(other.Data) == true)) &&
                ((this.Pagination == null && other.Pagination == null) || (this.Pagination?.Equals(other.Pagination) == true)) &&
                ((this.Properties == null && other.Properties == null) || (this.Properties?.Equals(other.Properties) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Data = {(this.Data == null ? "null" : $"[{string.Join(", ", this.Data)} ]")}");
            toStringOutput.Add($"this.Pagination = {(this.Pagination == null ? "null" : this.Pagination.ToString())}");
            toStringOutput.Add($"this.Properties = {(this.Properties == null ? "null" : this.Properties.ToString())}");
        }
    }
}