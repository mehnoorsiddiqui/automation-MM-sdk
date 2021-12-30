// <copyright file="Message.cs" company="APIMatic">
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
    /// Message.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        public Message()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="content">content.</param>
        /// <param name="destinationNumber">destination_number.</param>
        /// <param name="sourceNumber">source_number.</param>
        /// <param name="callbackUrl">callback_url.</param>
        /// <param name="deliveryReport">delivery_report.</param>
        /// <param name="format">format.</param>
        /// <param name="messageExpiryTimestamp">message_expiry_timestamp.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="scheduled">scheduled.</param>
        /// <param name="sourceNumberType">source_number_type.</param>
        /// <param name="messageId">message_id.</param>
        /// <param name="status">status.</param>
        /// <param name="media">media.</param>
        /// <param name="subject">subject.</param>
        public Message(
            string content,
            string destinationNumber,
            string sourceNumber,
            string callbackUrl = null,
            bool? deliveryReport = null,
            Models.FormatEnum? format = null,
            DateTime? messageExpiryTimestamp = null,
            object metadata = null,
            DateTime? scheduled = null,
            Models.SourceNumberTypeEnum? sourceNumberType = null,
            Guid? messageId = null,
            Models.StatusEnum? status = null,
            List<string> media = null,
            string subject = null)
        {
            this.CallbackUrl = callbackUrl;
            this.Content = content;
            this.DestinationNumber = destinationNumber;
            this.DeliveryReport = deliveryReport;
            this.Format = format;
            this.MessageExpiryTimestamp = messageExpiryTimestamp;
            this.Metadata = metadata;
            this.Scheduled = scheduled;
            this.SourceNumber = sourceNumber;
            this.SourceNumberType = sourceNumberType;
            this.MessageId = messageId;
            this.Status = status;
            this.Media = media;
            this.Subject = subject;
        }

        /// <summary>
        /// URL replies and delivery reports to this message will be pushed to
        /// </summary>
        [JsonProperty("callback_url", NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Content of the message
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Destination number of the message
        /// </summary>
        [JsonProperty("destination_number")]
        public string DestinationNumber { get; set; }

        /// <summary>
        /// Request a delivery report for this message
        /// </summary>
        [JsonProperty("delivery_report", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DeliveryReport { get; set; }

        /// <summary>
        /// Format of message, SMS or TTS (Text To Speech).
        /// </summary>
        [JsonProperty("format", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.FormatEnum? Format { get; set; }

        /// <summary>
        /// Date time after which the message expires and will not be sent
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("message_expiry_timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? MessageExpiryTimestamp { get; set; }

        /// <summary>
        /// Metadata for the message specified as a set of key value pairs, each key can be up to 100 characters long and each value can be up to 256 characters long
        /// ```
        /// {
        ///    "myKey": "myValue",
        ///    "anotherKey": "anotherValue"
        /// }
        /// ```
        /// </summary>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }

        /// <summary>
        /// Scheduled delivery date time of the message
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("scheduled", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Scheduled { get; set; }

        /// <summary>
        /// Source number of the message
        /// </summary>
        [JsonProperty("source_number")]
        public string SourceNumber { get; set; }

        /// <summary>
        /// Type of source address specified, this can be INTERNATIONAL, ALPHANUMERIC or SHORTCODE
        /// </summary>
        [JsonProperty("source_number_type", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.SourceNumberTypeEnum? SourceNumberType { get; set; }

        /// <summary>
        /// Unique ID of this message
        /// </summary>
        [JsonProperty("message_id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? MessageId { get; set; }

        /// <summary>
        /// The status of the message
        /// </summary>
        [JsonProperty("status", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.StatusEnum? Status { get; set; }

        /// <summary>
        /// The media is used to specify a list of URLs of the media file(s) that you are trying to send. Supported file formats include png, jpeg and gif. format parameter must be set to MMS for this to work.
        /// </summary>
        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Media { get; set; }

        /// <summary>
        /// The subject field is used to denote subject of the MMS message and has a maximum size of 64 characters long
        /// </summary>
        [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Message : ({string.Join(", ", toStringOutput)})";
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

            return obj is Message other &&
                ((this.CallbackUrl == null && other.CallbackUrl == null) || (this.CallbackUrl?.Equals(other.CallbackUrl) == true)) &&
                ((this.Content == null && other.Content == null) || (this.Content?.Equals(other.Content) == true)) &&
                ((this.DestinationNumber == null && other.DestinationNumber == null) || (this.DestinationNumber?.Equals(other.DestinationNumber) == true)) &&
                ((this.DeliveryReport == null && other.DeliveryReport == null) || (this.DeliveryReport?.Equals(other.DeliveryReport) == true)) &&
                ((this.Format == null && other.Format == null) || (this.Format?.Equals(other.Format) == true)) &&
                ((this.MessageExpiryTimestamp == null && other.MessageExpiryTimestamp == null) || (this.MessageExpiryTimestamp?.Equals(other.MessageExpiryTimestamp) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true)) &&
                ((this.Scheduled == null && other.Scheduled == null) || (this.Scheduled?.Equals(other.Scheduled) == true)) &&
                ((this.SourceNumber == null && other.SourceNumber == null) || (this.SourceNumber?.Equals(other.SourceNumber) == true)) &&
                ((this.SourceNumberType == null && other.SourceNumberType == null) || (this.SourceNumberType?.Equals(other.SourceNumberType) == true)) &&
                ((this.MessageId == null && other.MessageId == null) || (this.MessageId?.Equals(other.MessageId) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Media == null && other.Media == null) || (this.Media?.Equals(other.Media) == true)) &&
                ((this.Subject == null && other.Subject == null) || (this.Subject?.Equals(other.Subject) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CallbackUrl = {(this.CallbackUrl == null ? "null" : this.CallbackUrl == string.Empty ? "" : this.CallbackUrl)}");
            toStringOutput.Add($"this.Content = {(this.Content == null ? "null" : this.Content == string.Empty ? "" : this.Content)}");
            toStringOutput.Add($"this.DestinationNumber = {(this.DestinationNumber == null ? "null" : this.DestinationNumber == string.Empty ? "" : this.DestinationNumber)}");
            toStringOutput.Add($"this.DeliveryReport = {(this.DeliveryReport == null ? "null" : this.DeliveryReport.ToString())}");
            toStringOutput.Add($"this.Format = {(this.Format == null ? "null" : this.Format.ToString())}");
            toStringOutput.Add($"this.MessageExpiryTimestamp = {(this.MessageExpiryTimestamp == null ? "null" : this.MessageExpiryTimestamp.ToString())}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
            toStringOutput.Add($"this.Scheduled = {(this.Scheduled == null ? "null" : this.Scheduled.ToString())}");
            toStringOutput.Add($"this.SourceNumber = {(this.SourceNumber == null ? "null" : this.SourceNumber == string.Empty ? "" : this.SourceNumber)}");
            toStringOutput.Add($"this.SourceNumberType = {(this.SourceNumberType == null ? "null" : this.SourceNumberType.ToString())}");
            toStringOutput.Add($"this.MessageId = {(this.MessageId == null ? "null" : this.MessageId.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.Media = {(this.Media == null ? "null" : $"[{string.Join(", ", this.Media)} ]")}");
            toStringOutput.Add($"this.Subject = {(this.Subject == null ? "null" : this.Subject == string.Empty ? "" : this.Subject)}");
        }
    }
}