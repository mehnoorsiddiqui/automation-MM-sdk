// <copyright file="Pagination1.cs" company="APIMatic">
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
    /// Pagination1.
    /// </summary>
    public class Pagination1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination1"/> class.
        /// </summary>
        public Pagination1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination1"/> class.
        /// </summary>
        /// <param name="page">page.</param>
        /// <param name="pageSize">page_size.</param>
        /// <param name="totalCount">total_count.</param>
        /// <param name="pageCount">page_count.</param>
        /// <param name="nextUri">next_uri.</param>
        /// <param name="previousUri">previous_uri.</param>
        public Pagination1(
            double? page = null,
            double? pageSize = null,
            double? totalCount = null,
            double? pageCount = null,
            string nextUri = null,
            string previousUri = null)
        {
            this.Page = page;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.PageCount = pageCount;
            this.NextUri = nextUri;
            this.PreviousUri = previousUri;
        }

        /// <summary>
        /// The current page of results
        /// </summary>
        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public double? Page { get; set; }

        /// <summary>
        /// The amount of results returned per page
        /// </summary>
        [JsonProperty("page_size", NullValueHandling = NullValueHandling.Ignore)]
        public double? PageSize { get; set; }

        /// <summary>
        /// The total number of results in the results set
        /// </summary>
        [JsonProperty("total_count", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalCount { get; set; }

        /// <summary>
        /// The total number of pages in the results set
        /// </summary>
        [JsonProperty("page_count", NullValueHandling = NullValueHandling.Ignore)]
        public double? PageCount { get; set; }

        /// <summary>
        /// Link to the next page of results
        /// </summary>
        [JsonProperty("next_uri", NullValueHandling = NullValueHandling.Ignore)]
        public string NextUri { get; set; }

        /// <summary>
        /// Link to the previous page of results
        /// </summary>
        [JsonProperty("previous_uri", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviousUri { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Pagination1 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Pagination1 other &&
                ((this.Page == null && other.Page == null) || (this.Page?.Equals(other.Page) == true)) &&
                ((this.PageSize == null && other.PageSize == null) || (this.PageSize?.Equals(other.PageSize) == true)) &&
                ((this.TotalCount == null && other.TotalCount == null) || (this.TotalCount?.Equals(other.TotalCount) == true)) &&
                ((this.PageCount == null && other.PageCount == null) || (this.PageCount?.Equals(other.PageCount) == true)) &&
                ((this.NextUri == null && other.NextUri == null) || (this.NextUri?.Equals(other.NextUri) == true)) &&
                ((this.PreviousUri == null && other.PreviousUri == null) || (this.PreviousUri?.Equals(other.PreviousUri) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Page = {(this.Page == null ? "null" : this.Page.ToString())}");
            toStringOutput.Add($"this.PageSize = {(this.PageSize == null ? "null" : this.PageSize.ToString())}");
            toStringOutput.Add($"this.TotalCount = {(this.TotalCount == null ? "null" : this.TotalCount.ToString())}");
            toStringOutput.Add($"this.PageCount = {(this.PageCount == null ? "null" : this.PageCount.ToString())}");
            toStringOutput.Add($"this.NextUri = {(this.NextUri == null ? "null" : this.NextUri == string.Empty ? "" : this.NextUri)}");
            toStringOutput.Add($"this.PreviousUri = {(this.PreviousUri == null ? "null" : this.PreviousUri == string.Empty ? "" : this.PreviousUri)}");
        }
    }
}