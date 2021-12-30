// <copyright file="Pagination3.cs" company="APIMatic">
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
    /// Pagination3.
    /// </summary>
    public class Pagination3
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination3"/> class.
        /// </summary>
        public Pagination3()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination3"/> class.
        /// </summary>
        /// <param name="nextToken">next_token.</param>
        /// <param name="nextUrl">next_url.</param>
        public Pagination3(
            string nextToken,
            string nextUrl)
        {
            this.NextToken = nextToken;
            this.NextUrl = nextUrl;
        }

        /// <summary>
        /// Gets or sets NextToken.
        /// </summary>
        [JsonProperty("next_token")]
        public string NextToken { get; set; }

        /// <summary>
        /// Gets or sets NextUrl.
        /// </summary>
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Pagination3 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Pagination3 other &&
                ((this.NextToken == null && other.NextToken == null) || (this.NextToken?.Equals(other.NextToken) == true)) &&
                ((this.NextUrl == null && other.NextUrl == null) || (this.NextUrl?.Equals(other.NextUrl) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.NextToken = {(this.NextToken == null ? "null" : this.NextToken == string.Empty ? "" : this.NextToken)}");
            toStringOutput.Add($"this.NextUrl = {(this.NextUrl == null ? "null" : this.NextUrl == string.Empty ? "" : this.NextUrl)}");
        }
    }
}