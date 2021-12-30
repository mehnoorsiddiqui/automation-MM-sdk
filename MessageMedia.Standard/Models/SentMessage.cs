// <copyright file="SentMessage.cs" company="APIMatic">
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
    /// SentMessage.
    /// </summary>
    public class SentMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SentMessage"/> class.
        /// </summary>
        public SentMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SentMessage"/> class.
        /// </summary>
        /// <param name="account">account.</param>
        /// <param name="content">content.</param>
        /// <param name="deliveredTimestamp">delivered_timestamp.</param>
        /// <param name="deliveryReport">delivery_report.</param>
        /// <param name="destinationAddress">destination_address.</param>
        /// <param name="destinationAddressCountry">destination_address_country.</param>
        /// <param name="format">format.</param>
        /// <param name="id">id.</param>
        /// <param name="inResponseTo">in_response_to.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="sourceAddress">source_address.</param>
        /// <param name="sourceAddressCountry">source_address_country.</param>
        /// <param name="units">units.</param>
        /// <param name="timestamp">timestamp.</param>
        public SentMessage(
            string account = null,
            string content = null,
            string deliveredTimestamp = null,
            bool? deliveryReport = null,
            string destinationAddress = null,
            string destinationAddressCountry = null,
            Models.Format1Enum? format = null,
            string id = null,
            string inResponseTo = null,
            object metadata = null,
            string sourceAddress = null,
            string sourceAddressCountry = null,
            double? units = null,
            string timestamp = null)
        {
            this.Account = account;
            this.Content = content;
            this.DeliveredTimestamp = deliveredTimestamp;
            this.DeliveryReport = deliveryReport;
            this.DestinationAddress = destinationAddress;
            this.DestinationAddressCountry = destinationAddressCountry;
            this.Format = format;
            this.Id = id;
            this.InResponseTo = inResponseTo;
            this.Metadata = metadata;
            this.SourceAddress = sourceAddress;
            this.SourceAddressCountry = sourceAddressCountry;
            this.Units = units;
            this.Timestamp = timestamp;
        }

        /// <summary>
        /// Account associated with this message
        /// </summary>
        [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]
        public string Account { get; set; }

        /// <summary>
        /// Content of the message
        /// </summary>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        /// <summary>
        /// If a delivery report was requested for this message, this is the time at which the message was delivered (or failed to be delivered) to the destination address.
        /// </summary>
        [JsonProperty("delivered_timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string DeliveredTimestamp { get; set; }

        /// <summary>
        /// Indicates if a delivery report was requested for this message
        /// </summary>
        [JsonProperty("delivery_report", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DeliveryReport { get; set; }

        /// <summary>
        /// Address this message was delivered to
        /// </summary>
        [JsonProperty("destination_address", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationAddress { get; set; }

        /// <summary>
        /// Country associated with the destination address
        /// </summary>
        [JsonProperty("destination_address_country", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationAddressCountry { get; set; }

        /// <summary>
        /// Format of message, SMS or TTS (Text To Speech)
        /// </summary>
        [JsonProperty("format", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.Format1Enum? Format { get; set; }

        /// <summary>
        /// Unique ID for this message
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// If this message was sent in response to a received message (an auto response message for example) this is the ID of the received message.
        /// </summary>
        [JsonProperty("in_response_to", NullValueHandling = NullValueHandling.Ignore)]
        public string InResponseTo { get; set; }

        /// <summary>
        /// Metadata associated with this message
        /// </summary>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }

        /// <summary>
        /// Address this message was sent from
        /// </summary>
        [JsonProperty("source_address", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceAddress { get; set; }

        /// <summary>
        /// Country associated with the source address
        /// </summary>
        [JsonProperty("source_address_country", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceAddressCountry { get; set; }

        /// <summary>
        /// The total number of calculated SMS units this message cost. 1 SMS unit is defined as 160 GSM characters, or 153 GSM characters for multi-part messages as some characters are used to concatenate the message on the receiving handset.
        /// Messages with one or more non-GSM characters will be submitted using UCS-2 encoding. UCS-2 encoding means the message has a maximum of 70 characters per SMS, or 67 characters for multi-part messages.
        /// </summary>
        [JsonProperty("units", NullValueHandling = NullValueHandling.Ignore)]
        public double? Units { get; set; }

        /// <summary>
        /// Date time at which this message was submitted to the API, refer to the delivered timestamp for the time at which the message was delivered (or failed to be delivered) to the destination address.
        /// </summary>
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string Timestamp { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SentMessage : ({string.Join(", ", toStringOutput)})";
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

            return obj is SentMessage other &&
                ((this.Account == null && other.Account == null) || (this.Account?.Equals(other.Account) == true)) &&
                ((this.Content == null && other.Content == null) || (this.Content?.Equals(other.Content) == true)) &&
                ((this.DeliveredTimestamp == null && other.DeliveredTimestamp == null) || (this.DeliveredTimestamp?.Equals(other.DeliveredTimestamp) == true)) &&
                ((this.DeliveryReport == null && other.DeliveryReport == null) || (this.DeliveryReport?.Equals(other.DeliveryReport) == true)) &&
                ((this.DestinationAddress == null && other.DestinationAddress == null) || (this.DestinationAddress?.Equals(other.DestinationAddress) == true)) &&
                ((this.DestinationAddressCountry == null && other.DestinationAddressCountry == null) || (this.DestinationAddressCountry?.Equals(other.DestinationAddressCountry) == true)) &&
                ((this.Format == null && other.Format == null) || (this.Format?.Equals(other.Format) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.InResponseTo == null && other.InResponseTo == null) || (this.InResponseTo?.Equals(other.InResponseTo) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true)) &&
                ((this.SourceAddress == null && other.SourceAddress == null) || (this.SourceAddress?.Equals(other.SourceAddress) == true)) &&
                ((this.SourceAddressCountry == null && other.SourceAddressCountry == null) || (this.SourceAddressCountry?.Equals(other.SourceAddressCountry) == true)) &&
                ((this.Units == null && other.Units == null) || (this.Units?.Equals(other.Units) == true)) &&
                ((this.Timestamp == null && other.Timestamp == null) || (this.Timestamp?.Equals(other.Timestamp) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Account = {(this.Account == null ? "null" : this.Account == string.Empty ? "" : this.Account)}");
            toStringOutput.Add($"this.Content = {(this.Content == null ? "null" : this.Content == string.Empty ? "" : this.Content)}");
            toStringOutput.Add($"this.DeliveredTimestamp = {(this.DeliveredTimestamp == null ? "null" : this.DeliveredTimestamp == string.Empty ? "" : this.DeliveredTimestamp)}");
            toStringOutput.Add($"this.DeliveryReport = {(this.DeliveryReport == null ? "null" : this.DeliveryReport.ToString())}");
            toStringOutput.Add($"this.DestinationAddress = {(this.DestinationAddress == null ? "null" : this.DestinationAddress == string.Empty ? "" : this.DestinationAddress)}");
            toStringOutput.Add($"this.DestinationAddressCountry = {(this.DestinationAddressCountry == null ? "null" : this.DestinationAddressCountry == string.Empty ? "" : this.DestinationAddressCountry)}");
            toStringOutput.Add($"this.Format = {(this.Format == null ? "null" : this.Format.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.InResponseTo = {(this.InResponseTo == null ? "null" : this.InResponseTo == string.Empty ? "" : this.InResponseTo)}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
            toStringOutput.Add($"this.SourceAddress = {(this.SourceAddress == null ? "null" : this.SourceAddress == string.Empty ? "" : this.SourceAddress)}");
            toStringOutput.Add($"this.SourceAddressCountry = {(this.SourceAddressCountry == null ? "null" : this.SourceAddressCountry == string.Empty ? "" : this.SourceAddressCountry)}");
            toStringOutput.Add($"this.Units = {(this.Units == null ? "null" : this.Units.ToString())}");
            toStringOutput.Add($"this.Timestamp = {(this.Timestamp == null ? "null" : this.Timestamp == string.Empty ? "" : this.Timestamp)}");
        }
    }
}