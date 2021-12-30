// <copyright file="LogsDetailResult.cs" company="APIMatic">
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
    /// LogsDetailResult.
    /// </summary>
    public class LogsDetailResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogsDetailResult"/> class.
        /// </summary>
        public LogsDetailResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsDetailResult"/> class.
        /// </summary>
        /// <param name="messageId">message_id.</param>
        /// <param name="longUrl">long_url.</param>
        /// <param name="shortUrl">short_url.</param>
        /// <param name="destinationNumber">destination_number.</param>
        /// <param name="clickCount">click_count.</param>
        /// <param name="viewCount">view_count.</param>
        /// <param name="clicks">clicks.</param>
        /// <param name="views">views.</param>
        /// <param name="pagination">pagination.</param>
        public LogsDetailResult(
            string messageId = null,
            string longUrl = null,
            string shortUrl = null,
            string destinationNumber = null,
            double? clickCount = null,
            double? viewCount = null,
            List<Models.Click> clicks = null,
            List<Models.View> views = null,
            Models.Pagination1 pagination = null)
        {
            this.MessageId = messageId;
            this.LongUrl = longUrl;
            this.ShortUrl = shortUrl;
            this.DestinationNumber = destinationNumber;
            this.ClickCount = clickCount;
            this.ViewCount = viewCount;
            this.Clicks = clicks;
            this.Views = views;
            this.Pagination = pagination;
        }

        /// <summary>
        /// Gets or sets MessageId.
        /// </summary>
        [JsonProperty("message_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets LongUrl.
        /// </summary>
        [JsonProperty("long_url", NullValueHandling = NullValueHandling.Ignore)]
        public string LongUrl { get; set; }

        /// <summary>
        /// Gets or sets ShortUrl.
        /// </summary>
        [JsonProperty("short_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortUrl { get; set; }

        /// <summary>
        /// Gets or sets DestinationNumber.
        /// </summary>
        [JsonProperty("destination_number", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationNumber { get; set; }

        /// <summary>
        /// Gets or sets ClickCount.
        /// </summary>
        [JsonProperty("click_count", NullValueHandling = NullValueHandling.Ignore)]
        public double? ClickCount { get; set; }

        /// <summary>
        /// Gets or sets ViewCount.
        /// </summary>
        [JsonProperty("view_count", NullValueHandling = NullValueHandling.Ignore)]
        public double? ViewCount { get; set; }

        /// <summary>
        /// Gets or sets Clicks.
        /// </summary>
        [JsonProperty("clicks", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Click> Clicks { get; set; }

        /// <summary>
        /// Gets or sets Views.
        /// </summary>
        [JsonProperty("views", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.View> Views { get; set; }

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

            return $"LogsDetailResult : ({string.Join(", ", toStringOutput)})";
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

            return obj is LogsDetailResult other &&
                ((this.MessageId == null && other.MessageId == null) || (this.MessageId?.Equals(other.MessageId) == true)) &&
                ((this.LongUrl == null && other.LongUrl == null) || (this.LongUrl?.Equals(other.LongUrl) == true)) &&
                ((this.ShortUrl == null && other.ShortUrl == null) || (this.ShortUrl?.Equals(other.ShortUrl) == true)) &&
                ((this.DestinationNumber == null && other.DestinationNumber == null) || (this.DestinationNumber?.Equals(other.DestinationNumber) == true)) &&
                ((this.ClickCount == null && other.ClickCount == null) || (this.ClickCount?.Equals(other.ClickCount) == true)) &&
                ((this.ViewCount == null && other.ViewCount == null) || (this.ViewCount?.Equals(other.ViewCount) == true)) &&
                ((this.Clicks == null && other.Clicks == null) || (this.Clicks?.Equals(other.Clicks) == true)) &&
                ((this.Views == null && other.Views == null) || (this.Views?.Equals(other.Views) == true)) &&
                ((this.Pagination == null && other.Pagination == null) || (this.Pagination?.Equals(other.Pagination) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MessageId = {(this.MessageId == null ? "null" : this.MessageId == string.Empty ? "" : this.MessageId)}");
            toStringOutput.Add($"this.LongUrl = {(this.LongUrl == null ? "null" : this.LongUrl == string.Empty ? "" : this.LongUrl)}");
            toStringOutput.Add($"this.ShortUrl = {(this.ShortUrl == null ? "null" : this.ShortUrl == string.Empty ? "" : this.ShortUrl)}");
            toStringOutput.Add($"this.DestinationNumber = {(this.DestinationNumber == null ? "null" : this.DestinationNumber == string.Empty ? "" : this.DestinationNumber)}");
            toStringOutput.Add($"this.ClickCount = {(this.ClickCount == null ? "null" : this.ClickCount.ToString())}");
            toStringOutput.Add($"this.ViewCount = {(this.ViewCount == null ? "null" : this.ViewCount.ToString())}");
            toStringOutput.Add($"this.Clicks = {(this.Clicks == null ? "null" : $"[{string.Join(", ", this.Clicks)} ]")}");
            toStringOutput.Add($"this.Views = {(this.Views == null ? "null" : $"[{string.Join(", ", this.Views)} ]")}");
            toStringOutput.Add($"this.Pagination = {(this.Pagination == null ? "null" : this.Pagination.ToString())}");
        }
    }
}