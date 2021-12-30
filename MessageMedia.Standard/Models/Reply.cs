// <copyright file="Reply.cs" company="APIMatic">
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
    /// Reply.
    /// </summary>
    public class Reply
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reply"/> class.
        /// </summary>
        public Reply()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Reply"/> class.
        /// </summary>
        /// <param name="callbackUrl">callback_url.</param>
        /// <param name="content">content.</param>
        /// <param name="dateReceived">date_received.</param>
        /// <param name="destinationNumber">destination_number.</param>
        /// <param name="messageId">message_id.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="replyId">reply_id.</param>
        /// <param name="sourceNumber">source_number.</param>
        /// <param name="vendorAccountId">vendor_account_id.</param>
        public Reply(
            string callbackUrl = null,
            string content = null,
            DateTime? dateReceived = null,
            string destinationNumber = null,
            Guid? messageId = null,
            object metadata = null,
            Guid? replyId = null,
            string sourceNumber = null,
            Models.VendorAccountId vendorAccountId = null)
        {
            this.CallbackUrl = callbackUrl;
            this.Content = content;
            this.DateReceived = dateReceived;
            this.DestinationNumber = destinationNumber;
            this.MessageId = messageId;
            this.Metadata = metadata;
            this.ReplyId = replyId;
            this.SourceNumber = sourceNumber;
            this.VendorAccountId = vendorAccountId;
        }

        /// <summary>
        /// The URL specified as the callback URL in the original submit message request
        /// </summary>
        [JsonProperty("callback_url", NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Content of the reply
        /// </summary>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        /// <summary>
        /// Date time when the reply was received
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("date_received", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateReceived { get; set; }

        /// <summary>
        /// Address from which this reply was sent to
        /// </summary>
        [JsonProperty("destination_number", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationNumber { get; set; }

        /// <summary>
        /// Unique ID of the original message
        /// </summary>
        [JsonProperty("message_id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? MessageId { get; set; }

        /// <summary>
        /// Any metadata that was included in the original submit message request
        /// </summary>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }

        /// <summary>
        /// Unique ID of this reply
        /// </summary>
        [JsonProperty("reply_id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ReplyId { get; set; }

        /// <summary>
        /// Address from which this reply was received from
        /// </summary>
        [JsonProperty("source_number", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceNumber { get; set; }

        /// <summary>
        /// Gets or sets VendorAccountId.
        /// </summary>
        [JsonProperty("vendor_account_id", NullValueHandling = NullValueHandling.Ignore)]
        public Models.VendorAccountId VendorAccountId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Reply : ({string.Join(", ", toStringOutput)})";
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

            return obj is Reply other &&
                ((this.CallbackUrl == null && other.CallbackUrl == null) || (this.CallbackUrl?.Equals(other.CallbackUrl) == true)) &&
                ((this.Content == null && other.Content == null) || (this.Content?.Equals(other.Content) == true)) &&
                ((this.DateReceived == null && other.DateReceived == null) || (this.DateReceived?.Equals(other.DateReceived) == true)) &&
                ((this.DestinationNumber == null && other.DestinationNumber == null) || (this.DestinationNumber?.Equals(other.DestinationNumber) == true)) &&
                ((this.MessageId == null && other.MessageId == null) || (this.MessageId?.Equals(other.MessageId) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true)) &&
                ((this.ReplyId == null && other.ReplyId == null) || (this.ReplyId?.Equals(other.ReplyId) == true)) &&
                ((this.SourceNumber == null && other.SourceNumber == null) || (this.SourceNumber?.Equals(other.SourceNumber) == true)) &&
                ((this.VendorAccountId == null && other.VendorAccountId == null) || (this.VendorAccountId?.Equals(other.VendorAccountId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CallbackUrl = {(this.CallbackUrl == null ? "null" : this.CallbackUrl == string.Empty ? "" : this.CallbackUrl)}");
            toStringOutput.Add($"this.Content = {(this.Content == null ? "null" : this.Content == string.Empty ? "" : this.Content)}");
            toStringOutput.Add($"this.DateReceived = {(this.DateReceived == null ? "null" : this.DateReceived.ToString())}");
            toStringOutput.Add($"this.DestinationNumber = {(this.DestinationNumber == null ? "null" : this.DestinationNumber == string.Empty ? "" : this.DestinationNumber)}");
            toStringOutput.Add($"this.MessageId = {(this.MessageId == null ? "null" : this.MessageId.ToString())}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
            toStringOutput.Add($"this.ReplyId = {(this.ReplyId == null ? "null" : this.ReplyId.ToString())}");
            toStringOutput.Add($"this.SourceNumber = {(this.SourceNumber == null ? "null" : this.SourceNumber == string.Empty ? "" : this.SourceNumber)}");
            toStringOutput.Add($"this.VendorAccountId = {(this.VendorAccountId == null ? "null" : this.VendorAccountId.ToString())}");
        }
    }
}