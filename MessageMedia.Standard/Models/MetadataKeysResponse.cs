// <copyright file="MetadataKeysResponse.cs" company="APIMatic">
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
    /// MetadataKeysResponse.
    /// </summary>
    public class MetadataKeysResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataKeysResponse"/> class.
        /// </summary>
        public MetadataKeysResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataKeysResponse"/> class.
        /// </summary>
        /// <param name="data">data.</param>
        /// <param name="properties">properties.</param>
        public MetadataKeysResponse(
            List<string> data = null,
            Models.Properties properties = null)
        {
            this.Data = data;
            this.Properties = properties;
        }

        /// <summary>
        /// Gets or sets Data.
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Data { get; set; }

        /// <summary>
        /// Gets or sets Properties.
        /// </summary>
        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Properties Properties { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MetadataKeysResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is MetadataKeysResponse other &&
                ((this.Data == null && other.Data == null) || (this.Data?.Equals(other.Data) == true)) &&
                ((this.Properties == null && other.Properties == null) || (this.Properties?.Equals(other.Properties) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Data = {(this.Data == null ? "null" : $"[{string.Join(", ", this.Data)} ]")}");
            toStringOutput.Add($"this.Properties = {(this.Properties == null ? "null" : this.Properties.ToString())}");
        }
    }
}