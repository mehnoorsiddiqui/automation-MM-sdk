// <copyright file="Pagination.cs" company="APIMatic">
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
    /// Pagination.
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination"/> class.
        /// </summary>
        public Pagination()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination"/> class.
        /// </summary>
        /// <param name="page">page.</param>
        /// <param name="nextUri">next_uri.</param>
        public Pagination(
            string page = null,
            string nextUri = null)
        {
            this.Page = page;
            this.NextUri = nextUri;
        }

        /// <summary>
        /// The pagination token of the next set of results.
        /// </summary>
        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public string Page { get; set; }

        /// <summary>
        /// The uri pointing to the next set of results.
        /// </summary>
        [JsonProperty("next_uri", NullValueHandling = NullValueHandling.Ignore)]
        public string NextUri { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Pagination : ({string.Join(", ", toStringOutput)})";
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

            return obj is Pagination other &&
                ((this.Page == null && other.Page == null) || (this.Page?.Equals(other.Page) == true)) &&
                ((this.NextUri == null && other.NextUri == null) || (this.NextUri?.Equals(other.NextUri) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Page = {(this.Page == null ? "null" : this.Page == string.Empty ? "" : this.Page)}");
            toStringOutput.Add($"this.NextUri = {(this.NextUri == null ? "null" : this.NextUri == string.Empty ? "" : this.NextUri)}");
        }
    }
}