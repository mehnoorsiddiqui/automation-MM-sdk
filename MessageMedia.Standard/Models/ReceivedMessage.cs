// <copyright file="ReceivedMessage.cs" company="APIMatic">
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
    /// ReceivedMessage.
    /// </summary>
    public class ReceivedMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedMessage"/> class.
        /// </summary>
        public ReceivedMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceivedMessage"/> class.
        /// </summary>
        /// <param name="account">account.</param>
        /// <param name="action">action.</param>
        /// <param name="content">content.</param>
        /// <param name="destinationAddress">destination_address.</param>
        /// <param name="destinationAddressCountry">destination_address_country.</param>
        /// <param name="format">format.</param>
        /// <param name="id">id.</param>
        /// <param name="inResponseTo">in_response_to.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="sourceAddress">source_address.</param>
        /// <param name="sourceAddressCountry">source_address_country.</param>
        /// <param name="timestamp">timestamp.</param>
        public ReceivedMessage(
            string account = null,
            Models.ActionEnum? action = null,
            string content = null,
            string destinationAddress = null,
            string destinationAddressCountry = null,
            Models.Format1Enum? format = null,
            string id = null,
            string inResponseTo = null,
            object metadata = null,
            string sourceAddress = null,
            string sourceAddressCountry = null,
            string timestamp = null)
        {
            this.Account = account;
            this.Action = action;
            this.Content = content;
            this.DestinationAddress = destinationAddress;
            this.DestinationAddressCountry = destinationAddressCountry;
            this.Format = format;
            this.Id = id;
            this.InResponseTo = inResponseTo;
            this.Metadata = metadata;
            this.SourceAddress = sourceAddress;
            this.SourceAddressCountry = sourceAddressCountry;
            this.Timestamp = timestamp;
        }

        /// <summary>
        /// Account associated with this message
        /// </summary>
        [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]
        public string Account { get; set; }

        /// <summary>
        /// Action that was invoked for this message if any, OPT_OUT, OPT_IN, GLOBAL_OPT_OUT
        /// </summary>
        [JsonProperty("action", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ActionEnum? Action { get; set; }

        /// <summary>
        /// Content of the message
        /// </summary>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        /// <summary>
        /// Address this message was delivered to. If this message was received in response to a sent message, this is the source address of the sent message
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
        /// Unique ID for this reply
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// If this message was received in response to a sent message, this is the ID of the sent message
        /// </summary>
        [JsonProperty("in_response_to", NullValueHandling = NullValueHandling.Ignore)]
        public string InResponseTo { get; set; }

        /// <summary>
        /// If this message was received in response to a sent message, this is the metadata associated with the sent message
        /// </summary>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }

        /// <summary>
        /// Address this message was received from. If this message was received in response to a sent message, this is the destination address of the sent message.
        /// </summary>
        [JsonProperty("source_address", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceAddress { get; set; }

        /// <summary>
        /// Country associated with the source address
        /// </summary>
        [JsonProperty("source_address_country", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceAddressCountry { get; set; }

        /// <summary>
        /// Date time at which this message was received
        /// </summary>
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string Timestamp { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ReceivedMessage : ({string.Join(", ", toStringOutput)})";
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

            return obj is ReceivedMessage other &&
                ((this.Account == null && other.Account == null) || (this.Account?.Equals(other.Account) == true)) &&
                ((this.Action == null && other.Action == null) || (this.Action?.Equals(other.Action) == true)) &&
                ((this.Content == null && other.Content == null) || (this.Content?.Equals(other.Content) == true)) &&
                ((this.DestinationAddress == null && other.DestinationAddress == null) || (this.DestinationAddress?.Equals(other.DestinationAddress) == true)) &&
                ((this.DestinationAddressCountry == null && other.DestinationAddressCountry == null) || (this.DestinationAddressCountry?.Equals(other.DestinationAddressCountry) == true)) &&
                ((this.Format == null && other.Format == null) || (this.Format?.Equals(other.Format) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.InResponseTo == null && other.InResponseTo == null) || (this.InResponseTo?.Equals(other.InResponseTo) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true)) &&
                ((this.SourceAddress == null && other.SourceAddress == null) || (this.SourceAddress?.Equals(other.SourceAddress) == true)) &&
                ((this.SourceAddressCountry == null && other.SourceAddressCountry == null) || (this.SourceAddressCountry?.Equals(other.SourceAddressCountry) == true)) &&
                ((this.Timestamp == null && other.Timestamp == null) || (this.Timestamp?.Equals(other.Timestamp) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Account = {(this.Account == null ? "null" : this.Account == string.Empty ? "" : this.Account)}");
            toStringOutput.Add($"this.Action = {(this.Action == null ? "null" : this.Action.ToString())}");
            toStringOutput.Add($"this.Content = {(this.Content == null ? "null" : this.Content == string.Empty ? "" : this.Content)}");
            toStringOutput.Add($"this.DestinationAddress = {(this.DestinationAddress == null ? "null" : this.DestinationAddress == string.Empty ? "" : this.DestinationAddress)}");
            toStringOutput.Add($"this.DestinationAddressCountry = {(this.DestinationAddressCountry == null ? "null" : this.DestinationAddressCountry == string.Empty ? "" : this.DestinationAddressCountry)}");
            toStringOutput.Add($"this.Format = {(this.Format == null ? "null" : this.Format.ToString())}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.InResponseTo = {(this.InResponseTo == null ? "null" : this.InResponseTo == string.Empty ? "" : this.InResponseTo)}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
            toStringOutput.Add($"this.SourceAddress = {(this.SourceAddress == null ? "null" : this.SourceAddress == string.Empty ? "" : this.SourceAddress)}");
            toStringOutput.Add($"this.SourceAddressCountry = {(this.SourceAddressCountry == null ? "null" : this.SourceAddressCountry == string.Empty ? "" : this.SourceAddressCountry)}");
            toStringOutput.Add($"this.Timestamp = {(this.Timestamp == null ? "null" : this.Timestamp == string.Empty ? "" : this.Timestamp)}");
        }
    }
}