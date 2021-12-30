// <copyright file="DeliveryReport.cs" company="APIMatic">
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
    /// DeliveryReport.
    /// </summary>
    public class DeliveryReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryReport"/> class.
        /// </summary>
        public DeliveryReport()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryReport"/> class.
        /// </summary>
        /// <param name="callbackUrl">callback_url.</param>
        /// <param name="dateReceived">date_received.</param>
        /// <param name="delay">delay.</param>
        /// <param name="deliveryReportId">delivery_report_id.</param>
        /// <param name="messageId">message_id.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="originalText">original_text.</param>
        /// <param name="sourceNumber">source_number.</param>
        /// <param name="status">status.</param>
        /// <param name="submittedDate">submitted_date.</param>
        /// <param name="vendorAccountId">vendor_account_id.</param>
        public DeliveryReport(
            string callbackUrl = null,
            DateTime? dateReceived = null,
            int? delay = null,
            Guid? deliveryReportId = null,
            Guid? messageId = null,
            object metadata = null,
            string originalText = null,
            string sourceNumber = null,
            Models.StatusEnum? status = null,
            DateTime? submittedDate = null,
            Models.VendorAccountId vendorAccountId = null)
        {
            this.CallbackUrl = callbackUrl;
            this.DateReceived = dateReceived;
            this.Delay = delay;
            this.DeliveryReportId = deliveryReportId;
            this.MessageId = messageId;
            this.Metadata = metadata;
            this.OriginalText = originalText;
            this.SourceNumber = sourceNumber;
            this.Status = status;
            this.SubmittedDate = submittedDate;
            this.VendorAccountId = vendorAccountId;
        }

        /// <summary>
        /// The URL specified as the callback URL in the original submit message request
        /// </summary>
        [JsonProperty("callback_url", NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// The date and time at which this delivery report was generated in UTC.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("date_received", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateReceived { get; set; }

        /// <summary>
        /// Deprecated, no longer in use
        /// </summary>
        [JsonProperty("delay", NullValueHandling = NullValueHandling.Ignore)]
        public int? Delay { get; set; }

        /// <summary>
        /// Unique ID for this delivery report
        /// </summary>
        [JsonProperty("delivery_report_id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? DeliveryReportId { get; set; }

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
        /// Text of the original message.
        /// </summary>
        [JsonProperty("original_text", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalText { get; set; }

        /// <summary>
        /// Address from which this delivery report was received
        /// </summary>
        [JsonProperty("source_number", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceNumber { get; set; }

        /// <summary>
        /// The status of the message
        /// </summary>
        [JsonProperty("status", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.StatusEnum? Status { get; set; }

        /// <summary>
        /// The date and time when the message status changed in UTC. For a delivered DR this may indicate the time at which the message was received on the handset.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("submitted_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? SubmittedDate { get; set; }

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

            return $"DeliveryReport : ({string.Join(", ", toStringOutput)})";
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

            return obj is DeliveryReport other &&
                ((this.CallbackUrl == null && other.CallbackUrl == null) || (this.CallbackUrl?.Equals(other.CallbackUrl) == true)) &&
                ((this.DateReceived == null && other.DateReceived == null) || (this.DateReceived?.Equals(other.DateReceived) == true)) &&
                ((this.Delay == null && other.Delay == null) || (this.Delay?.Equals(other.Delay) == true)) &&
                ((this.DeliveryReportId == null && other.DeliveryReportId == null) || (this.DeliveryReportId?.Equals(other.DeliveryReportId) == true)) &&
                ((this.MessageId == null && other.MessageId == null) || (this.MessageId?.Equals(other.MessageId) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true)) &&
                ((this.OriginalText == null && other.OriginalText == null) || (this.OriginalText?.Equals(other.OriginalText) == true)) &&
                ((this.SourceNumber == null && other.SourceNumber == null) || (this.SourceNumber?.Equals(other.SourceNumber) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.SubmittedDate == null && other.SubmittedDate == null) || (this.SubmittedDate?.Equals(other.SubmittedDate) == true)) &&
                ((this.VendorAccountId == null && other.VendorAccountId == null) || (this.VendorAccountId?.Equals(other.VendorAccountId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CallbackUrl = {(this.CallbackUrl == null ? "null" : this.CallbackUrl == string.Empty ? "" : this.CallbackUrl)}");
            toStringOutput.Add($"this.DateReceived = {(this.DateReceived == null ? "null" : this.DateReceived.ToString())}");
            toStringOutput.Add($"this.Delay = {(this.Delay == null ? "null" : this.Delay.ToString())}");
            toStringOutput.Add($"this.DeliveryReportId = {(this.DeliveryReportId == null ? "null" : this.DeliveryReportId.ToString())}");
            toStringOutput.Add($"this.MessageId = {(this.MessageId == null ? "null" : this.MessageId.ToString())}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
            toStringOutput.Add($"this.OriginalText = {(this.OriginalText == null ? "null" : this.OriginalText == string.Empty ? "" : this.OriginalText)}");
            toStringOutput.Add($"this.SourceNumber = {(this.SourceNumber == null ? "null" : this.SourceNumber == string.Empty ? "" : this.SourceNumber)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.SubmittedDate = {(this.SubmittedDate == null ? "null" : this.SubmittedDate.ToString())}");
            toStringOutput.Add($"this.VendorAccountId = {(this.VendorAccountId == null ? "null" : this.VendorAccountId.ToString())}");
        }
    }
}