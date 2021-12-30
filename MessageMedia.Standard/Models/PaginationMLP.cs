// <copyright file="PaginationMLP.cs" company="APIMatic">
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
    /// PaginationMLP.
    /// </summary>
    public class PaginationMLP
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationMLP"/> class.
        /// </summary>
        public PaginationMLP()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationMLP"/> class.
        /// </summary>
        /// <param name="nextPageToken">next_page_token.</param>
        /// <param name="pageSize">page_size.</param>
        public PaginationMLP(
            string nextPageToken,
            int pageSize)
        {
            this.NextPageToken = nextPageToken;
            this.PageSize = pageSize;
        }

        /// <summary>
        /// Gets or sets NextPageToken.
        /// </summary>
        [JsonProperty("next_page_token")]
        public string NextPageToken { get; set; }

        /// <summary>
        /// Gets or sets PageSize.
        /// </summary>
        [JsonProperty("page_size")]
        public int PageSize { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaginationMLP : ({string.Join(", ", toStringOutput)})";
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

            return obj is PaginationMLP other &&
                ((this.NextPageToken == null && other.NextPageToken == null) || (this.NextPageToken?.Equals(other.NextPageToken) == true)) &&
                this.PageSize.Equals(other.PageSize);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.NextPageToken = {(this.NextPageToken == null ? "null" : this.NextPageToken == string.Empty ? "" : this.NextPageToken)}");
            toStringOutput.Add($"this.PageSize = {this.PageSize}");
        }
    }
}