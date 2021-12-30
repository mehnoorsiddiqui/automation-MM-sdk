// <copyright file="Getnumberauthorisationblacklistresponse.cs" company="APIMatic">
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
    /// Getnumberauthorisationblacklistresponse.
    /// </summary>
    public class Getnumberauthorisationblacklistresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Getnumberauthorisationblacklistresponse"/> class.
        /// </summary>
        public Getnumberauthorisationblacklistresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Getnumberauthorisationblacklistresponse"/> class.
        /// </summary>
        /// <param name="uri">uri.</param>
        /// <param name="numbers">numbers.</param>
        /// <param name="pagination">pagination.</param>
        public Getnumberauthorisationblacklistresponse(
            string uri = null,
            List<string> numbers = null,
            Models.Pagination pagination = null)
        {
            this.Uri = uri;
            this.Numbers = numbers;
            this.Pagination = pagination;
        }

        /// <summary>
        /// URL of the current API call, used to show the current pagination token for calls subsequent to the first one in the case of paginated data.
        /// </summary>
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        /// <summary>
        /// List of numbers belonging to the blacklist.
        /// </summary>
        [JsonProperty("numbers", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Numbers { get; set; }

        /// <summary>
        /// Gets or sets Pagination.
        /// </summary>
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Pagination Pagination { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Getnumberauthorisationblacklistresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is Getnumberauthorisationblacklistresponse other &&
                ((this.Uri == null && other.Uri == null) || (this.Uri?.Equals(other.Uri) == true)) &&
                ((this.Numbers == null && other.Numbers == null) || (this.Numbers?.Equals(other.Numbers) == true)) &&
                ((this.Pagination == null && other.Pagination == null) || (this.Pagination?.Equals(other.Pagination) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uri = {(this.Uri == null ? "null" : this.Uri == string.Empty ? "" : this.Uri)}");
            toStringOutput.Add($"this.Numbers = {(this.Numbers == null ? "null" : $"[{string.Join(", ", this.Numbers)} ]")}");
            toStringOutput.Add($"this.Pagination = {(this.Pagination == null ? "null" : this.Pagination.ToString())}");
        }
    }
}