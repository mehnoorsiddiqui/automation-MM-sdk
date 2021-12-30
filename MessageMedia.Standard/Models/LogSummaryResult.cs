// <copyright file="LogSummaryResult.cs" company="APIMatic">
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
    /// LogSummaryResult.
    /// </summary>
    public class LogSummaryResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogSummaryResult"/> class.
        /// </summary>
        public LogSummaryResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogSummaryResult"/> class.
        /// </summary>
        /// <param name="totalClicks">total_clicks.</param>
        /// <param name="uniqueClicks">unique_clicks.</param>
        /// <param name="totalViews">total_views.</param>
        /// <param name="uniqueViews">unique_views.</param>
        /// <param name="shortUrlsGenerated">short_urls_generated.</param>
        /// <param name="shortUrls">short_urls.</param>
        /// <param name="pagination">pagination.</param>
        public LogSummaryResult(
            double? totalClicks = null,
            double? uniqueClicks = null,
            double? totalViews = null,
            double? uniqueViews = null,
            double? shortUrlsGenerated = null,
            List<Models.ShortUrl> shortUrls = null,
            Models.Pagination1 pagination = null)
        {
            this.TotalClicks = totalClicks;
            this.UniqueClicks = uniqueClicks;
            this.TotalViews = totalViews;
            this.UniqueViews = uniqueViews;
            this.ShortUrlsGenerated = shortUrlsGenerated;
            this.ShortUrls = shortUrls;
            this.Pagination = pagination;
        }

        /// <summary>
        /// Gets or sets TotalClicks.
        /// </summary>
        [JsonProperty("total_clicks", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalClicks { get; set; }

        /// <summary>
        /// Gets or sets UniqueClicks.
        /// </summary>
        [JsonProperty("unique_clicks", NullValueHandling = NullValueHandling.Ignore)]
        public double? UniqueClicks { get; set; }

        /// <summary>
        /// Gets or sets TotalViews.
        /// </summary>
        [JsonProperty("total_views", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalViews { get; set; }

        /// <summary>
        /// Gets or sets UniqueViews.
        /// </summary>
        [JsonProperty("unique_views", NullValueHandling = NullValueHandling.Ignore)]
        public double? UniqueViews { get; set; }

        /// <summary>
        /// Gets or sets ShortUrlsGenerated.
        /// </summary>
        [JsonProperty("short_urls_generated", NullValueHandling = NullValueHandling.Ignore)]
        public double? ShortUrlsGenerated { get; set; }

        /// <summary>
        /// Gets or sets ShortUrls.
        /// </summary>
        [JsonProperty("short_urls", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.ShortUrl> ShortUrls { get; set; }

        /// <summary>
        /// Gets or sets Pagination.
        /// </summary>
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Pagination1 Pagination { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LogSummaryResult : ({string.Join(", ", toStringOutput)})";
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

            return obj is LogSummaryResult other &&
                ((this.TotalClicks == null && other.TotalClicks == null) || (this.TotalClicks?.Equals(other.TotalClicks) == true)) &&
                ((this.UniqueClicks == null && other.UniqueClicks == null) || (this.UniqueClicks?.Equals(other.UniqueClicks) == true)) &&
                ((this.TotalViews == null && other.TotalViews == null) || (this.TotalViews?.Equals(other.TotalViews) == true)) &&
                ((this.UniqueViews == null && other.UniqueViews == null) || (this.UniqueViews?.Equals(other.UniqueViews) == true)) &&
                ((this.ShortUrlsGenerated == null && other.ShortUrlsGenerated == null) || (this.ShortUrlsGenerated?.Equals(other.ShortUrlsGenerated) == true)) &&
                ((this.ShortUrls == null && other.ShortUrls == null) || (this.ShortUrls?.Equals(other.ShortUrls) == true)) &&
                ((this.Pagination == null && other.Pagination == null) || (this.Pagination?.Equals(other.Pagination) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TotalClicks = {(this.TotalClicks == null ? "null" : this.TotalClicks.ToString())}");
            toStringOutput.Add($"this.UniqueClicks = {(this.UniqueClicks == null ? "null" : this.UniqueClicks.ToString())}");
            toStringOutput.Add($"this.TotalViews = {(this.TotalViews == null ? "null" : this.TotalViews.ToString())}");
            toStringOutput.Add($"this.UniqueViews = {(this.UniqueViews == null ? "null" : this.UniqueViews.ToString())}");
            toStringOutput.Add($"this.ShortUrlsGenerated = {(this.ShortUrlsGenerated == null ? "null" : this.ShortUrlsGenerated.ToString())}");
            toStringOutput.Add($"this.ShortUrls = {(this.ShortUrls == null ? "null" : $"[{string.Join(", ", this.ShortUrls)} ]")}");
            toStringOutput.Add($"this.Pagination = {(this.Pagination == null ? "null" : this.Pagination.ToString())}");
        }
    }
}