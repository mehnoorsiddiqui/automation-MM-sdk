// <copyright file="ShortUrl.cs" company="APIMatic">
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
    /// ShortUrl.
    /// </summary>
    public class ShortUrl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShortUrl"/> class.
        /// </summary>
        public ShortUrl()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortUrl"/> class.
        /// </summary>
        /// <param name="clickCount">click_count.</param>
        /// <param name="viewCount">view_count.</param>
        /// <param name="messageId">message_id.</param>
        /// <param name="longUrl">long_url.</param>
        /// <param name="shortUrlProp">short_url.</param>
        /// <param name="destinationNumber">destination_number.</param>
        public ShortUrl(
            double? clickCount = null,
            double? viewCount = null,
            string messageId = null,
            string longUrl = null,
            string shortUrlProp = null,
            string destinationNumber = null)
        {
            this.ClickCount = clickCount;
            this.ViewCount = viewCount;
            this.MessageId = messageId;
            this.LongUrl = longUrl;
            this.ShortUrlProp = shortUrlProp;
            this.DestinationNumber = destinationNumber;
        }

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
        /// Gets or sets ShortUrlProp.
        /// </summary>
        [JsonProperty("short_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortUrlProp { get; set; }

        /// <summary>
        /// Gets or sets DestinationNumber.
        /// </summary>
        [JsonProperty("destination_number", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationNumber { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ShortUrl : ({string.Join(", ", toStringOutput)})";
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

            return obj is ShortUrl other &&
                ((this.ClickCount == null && other.ClickCount == null) || (this.ClickCount?.Equals(other.ClickCount) == true)) &&
                ((this.ViewCount == null && other.ViewCount == null) || (this.ViewCount?.Equals(other.ViewCount) == true)) &&
                ((this.MessageId == null && other.MessageId == null) || (this.MessageId?.Equals(other.MessageId) == true)) &&
                ((this.LongUrl == null && other.LongUrl == null) || (this.LongUrl?.Equals(other.LongUrl) == true)) &&
                ((this.ShortUrlProp == null && other.ShortUrlProp == null) || (this.ShortUrlProp?.Equals(other.ShortUrlProp) == true)) &&
                ((this.DestinationNumber == null && other.DestinationNumber == null) || (this.DestinationNumber?.Equals(other.DestinationNumber) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ClickCount = {(this.ClickCount == null ? "null" : this.ClickCount.ToString())}");
            toStringOutput.Add($"this.ViewCount = {(this.ViewCount == null ? "null" : this.ViewCount.ToString())}");
            toStringOutput.Add($"this.MessageId = {(this.MessageId == null ? "null" : this.MessageId == string.Empty ? "" : this.MessageId)}");
            toStringOutput.Add($"this.LongUrl = {(this.LongUrl == null ? "null" : this.LongUrl == string.Empty ? "" : this.LongUrl)}");
            toStringOutput.Add($"this.ShortUrlProp = {(this.ShortUrlProp == null ? "null" : this.ShortUrlProp == string.Empty ? "" : this.ShortUrlProp)}");
            toStringOutput.Add($"this.DestinationNumber = {(this.DestinationNumber == null ? "null" : this.DestinationNumber == string.Empty ? "" : this.DestinationNumber)}");
        }
    }
}