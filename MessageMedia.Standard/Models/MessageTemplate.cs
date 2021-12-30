// <copyright file="MessageTemplate.cs" company="APIMatic">
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
    /// MessageTemplate.
    /// </summary>
    public class MessageTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTemplate"/> class.
        /// </summary>
        public MessageTemplate()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTemplate"/> class.
        /// </summary>
        /// <param name="content">content.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="richLink">rich_link.</param>
        /// <param name="deliveryReport">delivery_report.</param>
        public MessageTemplate(
            string content,
            object metadata = null,
            Models.RichLink richLink = null,
            bool? deliveryReport = null)
        {
            this.Content = content;
            this.Metadata = metadata;
            this.RichLink = richLink;
            this.DeliveryReport = deliveryReport;
        }

        /// <summary>
        /// The message content.  This supports template placeholders.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Message metadata.  This will be supplied to URL shortener and UG.  Max 10 keys per campaign.
        /// </summary>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }

        /// <summary>
        /// Gets or sets RichLink.
        /// </summary>
        [JsonProperty("rich_link", NullValueHandling = NullValueHandling.Ignore)]
        public Models.RichLink RichLink { get; set; }

        /// <summary>
        /// Request a delivery report for the sent message
        /// </summary>
        [JsonProperty("delivery_report", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DeliveryReport { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MessageTemplate : ({string.Join(", ", toStringOutput)})";
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

            return obj is MessageTemplate other &&
                ((this.Content == null && other.Content == null) || (this.Content?.Equals(other.Content) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true)) &&
                ((this.RichLink == null && other.RichLink == null) || (this.RichLink?.Equals(other.RichLink) == true)) &&
                ((this.DeliveryReport == null && other.DeliveryReport == null) || (this.DeliveryReport?.Equals(other.DeliveryReport) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Content = {(this.Content == null ? "null" : this.Content == string.Empty ? "" : this.Content)}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
            toStringOutput.Add($"this.RichLink = {(this.RichLink == null ? "null" : this.RichLink.ToString())}");
            toStringOutput.Add($"this.DeliveryReport = {(this.DeliveryReport == null ? "null" : this.DeliveryReport.ToString())}");
        }
    }
}