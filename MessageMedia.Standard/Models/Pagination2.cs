// <copyright file="Pagination2.cs" company="APIMatic">
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
    /// Pagination2.
    /// </summary>
    public class Pagination2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination2"/> class.
        /// </summary>
        public Pagination2()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination2"/> class.
        /// </summary>
        /// <param name="page">page.</param>
        /// <param name="pageSize">page_size.</param>
        /// <param name="totalCount">total_count.</param>
        public Pagination2(
            double page,
            double pageSize,
            double totalCount)
        {
            this.Page = page;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
        }

        /// <summary>
        /// The current page number
        /// </summary>
        [JsonProperty("page")]
        public double Page { get; set; }

        /// <summary>
        /// The requested page size
        /// </summary>
        [JsonProperty("page_size")]
        public double PageSize { get; set; }

        /// <summary>
        /// The total number of items that match the query
        /// </summary>
        [JsonProperty("total_count")]
        public double TotalCount { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Pagination2 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Pagination2 other &&
                this.Page.Equals(other.Page) &&
                this.PageSize.Equals(other.PageSize) &&
                this.TotalCount.Equals(other.TotalCount);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Page = {this.Page}");
            toStringOutput.Add($"this.PageSize = {this.PageSize}");
            toStringOutput.Add($"this.TotalCount = {this.TotalCount}");
        }
    }
}