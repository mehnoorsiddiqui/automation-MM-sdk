// <copyright file="Filters.cs" company="APIMatic">
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
    /// Filters.
    /// </summary>
    public class Filters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Filters"/> class.
        /// </summary>
        public Filters()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Filters"/> class.
        /// </summary>
        /// <param name="deliveryReport">delivery_report.</param>
        /// <param name="destinationAddressCountry">destination_address_country.</param>
        /// <param name="destinationAddress">destination_address.</param>
        /// <param name="messageFormat">message_format.</param>
        /// <param name="metadataKey">metadata_key.</param>
        /// <param name="metadataValue">metadata_value.</param>
        /// <param name="sourceAddressCountry">source_address_country.</param>
        /// <param name="sourceAddress">source_address.</param>
        /// <param name="statusCode">status_code.</param>
        /// <param name="status">status.</param>
        /// <param name="action">action.</param>
        /// <param name="accounts">accounts.</param>
        public Filters(
            string deliveryReport = null,
            string destinationAddressCountry = null,
            string destinationAddress = null,
            string messageFormat = null,
            string metadataKey = null,
            string metadataValue = null,
            string sourceAddressCountry = null,
            string sourceAddress = null,
            string statusCode = null,
            string status = null,
            string action = null,
            List<string> accounts = null)
        {
            this.DeliveryReport = deliveryReport;
            this.DestinationAddressCountry = destinationAddressCountry;
            this.DestinationAddress = destinationAddress;
            this.MessageFormat = messageFormat;
            this.MetadataKey = metadataKey;
            this.MetadataValue = metadataValue;
            this.SourceAddressCountry = sourceAddressCountry;
            this.SourceAddress = sourceAddress;
            this.StatusCode = statusCode;
            this.Status = status;
            this.Action = action;
            this.Accounts = accounts;
        }

        /// <summary>
        /// Gets or sets DeliveryReport.
        /// </summary>
        [JsonProperty("delivery_report", NullValueHandling = NullValueHandling.Ignore)]
        public string DeliveryReport { get; set; }

        /// <summary>
        /// Gets or sets DestinationAddressCountry.
        /// </summary>
        [JsonProperty("destination_address_country", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationAddressCountry { get; set; }

        /// <summary>
        /// Gets or sets DestinationAddress.
        /// </summary>
        [JsonProperty("destination_address", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationAddress { get; set; }

        /// <summary>
        /// Gets or sets MessageFormat.
        /// </summary>
        [JsonProperty("message_format", NullValueHandling = NullValueHandling.Ignore)]
        public string MessageFormat { get; set; }

        /// <summary>
        /// Gets or sets MetadataKey.
        /// </summary>
        [JsonProperty("metadata_key", NullValueHandling = NullValueHandling.Ignore)]
        public string MetadataKey { get; set; }

        /// <summary>
        /// Gets or sets MetadataValue.
        /// </summary>
        [JsonProperty("metadata_value", NullValueHandling = NullValueHandling.Ignore)]
        public string MetadataValue { get; set; }

        /// <summary>
        /// Gets or sets SourceAddressCountry.
        /// </summary>
        [JsonProperty("source_address_country", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceAddressCountry { get; set; }

        /// <summary>
        /// Gets or sets SourceAddress.
        /// </summary>
        [JsonProperty("source_address", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceAddress { get; set; }

        /// <summary>
        /// Gets or sets StatusCode.
        /// </summary>
        [JsonProperty("status_code", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusCode { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets Action.
        /// </summary>
        [JsonProperty("action", NullValueHandling = NullValueHandling.Ignore)]
        public string Action { get; set; }

        /// <summary>
        /// List of accounts that were used to generate this report
        /// </summary>
        [JsonProperty("accounts", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Accounts { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Filters : ({string.Join(", ", toStringOutput)})";
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

            return obj is Filters other &&
                ((this.DeliveryReport == null && other.DeliveryReport == null) || (this.DeliveryReport?.Equals(other.DeliveryReport) == true)) &&
                ((this.DestinationAddressCountry == null && other.DestinationAddressCountry == null) || (this.DestinationAddressCountry?.Equals(other.DestinationAddressCountry) == true)) &&
                ((this.DestinationAddress == null && other.DestinationAddress == null) || (this.DestinationAddress?.Equals(other.DestinationAddress) == true)) &&
                ((this.MessageFormat == null && other.MessageFormat == null) || (this.MessageFormat?.Equals(other.MessageFormat) == true)) &&
                ((this.MetadataKey == null && other.MetadataKey == null) || (this.MetadataKey?.Equals(other.MetadataKey) == true)) &&
                ((this.MetadataValue == null && other.MetadataValue == null) || (this.MetadataValue?.Equals(other.MetadataValue) == true)) &&
                ((this.SourceAddressCountry == null && other.SourceAddressCountry == null) || (this.SourceAddressCountry?.Equals(other.SourceAddressCountry) == true)) &&
                ((this.SourceAddress == null && other.SourceAddress == null) || (this.SourceAddress?.Equals(other.SourceAddress) == true)) &&
                ((this.StatusCode == null && other.StatusCode == null) || (this.StatusCode?.Equals(other.StatusCode) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Action == null && other.Action == null) || (this.Action?.Equals(other.Action) == true)) &&
                ((this.Accounts == null && other.Accounts == null) || (this.Accounts?.Equals(other.Accounts) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DeliveryReport = {(this.DeliveryReport == null ? "null" : this.DeliveryReport == string.Empty ? "" : this.DeliveryReport)}");
            toStringOutput.Add($"this.DestinationAddressCountry = {(this.DestinationAddressCountry == null ? "null" : this.DestinationAddressCountry == string.Empty ? "" : this.DestinationAddressCountry)}");
            toStringOutput.Add($"this.DestinationAddress = {(this.DestinationAddress == null ? "null" : this.DestinationAddress == string.Empty ? "" : this.DestinationAddress)}");
            toStringOutput.Add($"this.MessageFormat = {(this.MessageFormat == null ? "null" : this.MessageFormat == string.Empty ? "" : this.MessageFormat)}");
            toStringOutput.Add($"this.MetadataKey = {(this.MetadataKey == null ? "null" : this.MetadataKey == string.Empty ? "" : this.MetadataKey)}");
            toStringOutput.Add($"this.MetadataValue = {(this.MetadataValue == null ? "null" : this.MetadataValue == string.Empty ? "" : this.MetadataValue)}");
            toStringOutput.Add($"this.SourceAddressCountry = {(this.SourceAddressCountry == null ? "null" : this.SourceAddressCountry == string.Empty ? "" : this.SourceAddressCountry)}");
            toStringOutput.Add($"this.SourceAddress = {(this.SourceAddress == null ? "null" : this.SourceAddress == string.Empty ? "" : this.SourceAddress)}");
            toStringOutput.Add($"this.StatusCode = {(this.StatusCode == null ? "null" : this.StatusCode == string.Empty ? "" : this.StatusCode)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
            toStringOutput.Add($"this.Action = {(this.Action == null ? "null" : this.Action == string.Empty ? "" : this.Action)}");
            toStringOutput.Add($"this.Accounts = {(this.Accounts == null ? "null" : $"[{string.Join(", ", this.Accounts)} ]")}");
        }
    }
}