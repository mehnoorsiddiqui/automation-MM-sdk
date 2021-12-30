// <copyright file="Asyncsentmessagesdetailrequest.cs" company="APIMatic">
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
    /// Asyncsentmessagesdetailrequest.
    /// </summary>
    public class Asyncsentmessagesdetailrequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Asyncsentmessagesdetailrequest"/> class.
        /// </summary>
        public Asyncsentmessagesdetailrequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Asyncsentmessagesdetailrequest"/> class.
        /// </summary>
        /// <param name="endDate">end_date.</param>
        /// <param name="startDate">start_date.</param>
        /// <param name="period">period.</param>
        /// <param name="sortBy">sort_by.</param>
        /// <param name="sortDirection">sort_direction.</param>
        /// <param name="timezone">timezone.</param>
        /// <param name="accounts">accounts.</param>
        /// <param name="destinationAddressCountry">destination_address_country.</param>
        /// <param name="destinationAddress">destination_address.</param>
        /// <param name="messageFormat">message_format.</param>
        /// <param name="metadataKey">metadata_key.</param>
        /// <param name="metadataValue">metadata_value.</param>
        /// <param name="sourceAddressCountry">source_address_country.</param>
        /// <param name="sourceAddress">source_address.</param>
        /// <param name="status">status.</param>
        /// <param name="statuses">statuses.</param>
        /// <param name="statusCode">status_code.</param>
        /// <param name="deliveryReport">delivery_report.</param>
        /// <param name="deliveryOptions">delivery_options.</param>
        public Asyncsentmessagesdetailrequest(
            string endDate = null,
            string startDate = null,
            Models.PeriodEnum? period = null,
            Models.SortByEnum? sortBy = null,
            Models.SortDirectionEnum? sortDirection = null,
            string timezone = null,
            List<string> accounts = null,
            string destinationAddressCountry = null,
            string destinationAddress = null,
            Models.Format1Enum? messageFormat = null,
            string metadataKey = null,
            string metadataValue = null,
            string sourceAddressCountry = null,
            string sourceAddress = null,
            Models.Status1Enum? status = null,
            List<Models.StatusesEnum> statuses = null,
            string statusCode = null,
            bool? deliveryReport = null,
            List<Models.DeliveryOptionsBody> deliveryOptions = null)
        {
            this.EndDate = endDate;
            this.StartDate = startDate;
            this.Period = period;
            this.SortBy = sortBy;
            this.SortDirection = sortDirection;
            this.Timezone = timezone;
            this.Accounts = accounts;
            this.DestinationAddressCountry = destinationAddressCountry;
            this.DestinationAddress = destinationAddress;
            this.MessageFormat = messageFormat;
            this.MetadataKey = metadataKey;
            this.MetadataValue = metadataValue;
            this.SourceAddressCountry = sourceAddressCountry;
            this.SourceAddress = sourceAddress;
            this.Status = status;
            this.Statuses = statuses;
            this.StatusCode = statusCode;
            this.DeliveryReport = deliveryReport;
            this.DeliveryOptions = deliveryOptions;
        }

        /// <summary>
        /// End date time for report window.
        /// </summary>
        [JsonProperty("end_date", NullValueHandling = NullValueHandling.Ignore)]
        public string EndDate { get; set; }

        /// <summary>
        /// Start date time for report window.
        /// </summary>
        [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
        public string StartDate { get; set; }

        /// <summary>
        /// Automatically set a date range based on the period value. Can't be combined with start_date and end_date.
        /// </summary>
        [JsonProperty("period", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.PeriodEnum? Period { get; set; }

        /// <summary>
        /// Field to sort results set by
        /// </summary>
        [JsonProperty("sort_by", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.SortByEnum? SortBy { get; set; }

        /// <summary>
        /// Order to sort results by.
        /// </summary>
        [JsonProperty("sort_direction", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.SortDirectionEnum? SortDirection { get; set; }

        /// <summary>
        /// The timezone to use for the context of the request.
        /// </summary>
        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; set; }

        /// <summary>
        /// Filter results by a specific account.
        /// </summary>
        [JsonProperty("accounts", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Accounts { get; set; }

        /// <summary>
        /// Filter results by destination address country.
        /// </summary>
        [JsonProperty("destination_address_country", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationAddressCountry { get; set; }

        /// <summary>
        /// Filter results by destination address.
        /// </summary>
        [JsonProperty("destination_address", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationAddress { get; set; }

        /// <summary>
        /// Format of message, SMS or TTS (Text To Speech)
        /// </summary>
        [JsonProperty("message_format", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.Format1Enum? MessageFormat { get; set; }

        /// <summary>
        /// Filter results for messages that include a metadata key.
        /// </summary>
        [JsonProperty("metadata_key", NullValueHandling = NullValueHandling.Ignore)]
        public string MetadataKey { get; set; }

        /// <summary>
        /// Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided.
        /// </summary>
        [JsonProperty("metadata_value", NullValueHandling = NullValueHandling.Ignore)]
        public string MetadataValue { get; set; }

        /// <summary>
        /// Filter results by source address country.
        /// </summary>
        [JsonProperty("source_address_country", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceAddressCountry { get; set; }

        /// <summary>
        /// Filter results by source address.
        /// </summary>
        [JsonProperty("source_address", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceAddress { get; set; }

        /// <summary>
        /// Filter results by message status. Can't be combined with statuses.
        /// </summary>
        [JsonProperty("status", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.Status1Enum? Status { get; set; }

        /// <summary>
        /// Filter results by message statuses. Can't be combined with status.
        /// </summary>
        [JsonProperty("statuses", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.StatusesEnum> Statuses { get; set; }

        /// <summary>
        /// Filter results by message status code.
        /// </summary>
        [JsonProperty("status_code", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusCode { get; set; }

        /// <summary>
        /// Filter results by delivery report.
        /// </summary>
        [JsonProperty("delivery_report", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DeliveryReport { get; set; }

        /// <summary>
        /// Delivery options for this asynchronous report.
        /// </summary>
        [JsonProperty("delivery_options", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.DeliveryOptionsBody> DeliveryOptions { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Asyncsentmessagesdetailrequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is Asyncsentmessagesdetailrequest other &&
                ((this.EndDate == null && other.EndDate == null) || (this.EndDate?.Equals(other.EndDate) == true)) &&
                ((this.StartDate == null && other.StartDate == null) || (this.StartDate?.Equals(other.StartDate) == true)) &&
                ((this.Period == null && other.Period == null) || (this.Period?.Equals(other.Period) == true)) &&
                ((this.SortBy == null && other.SortBy == null) || (this.SortBy?.Equals(other.SortBy) == true)) &&
                ((this.SortDirection == null && other.SortDirection == null) || (this.SortDirection?.Equals(other.SortDirection) == true)) &&
                ((this.Timezone == null && other.Timezone == null) || (this.Timezone?.Equals(other.Timezone) == true)) &&
                ((this.Accounts == null && other.Accounts == null) || (this.Accounts?.Equals(other.Accounts) == true)) &&
                ((this.DestinationAddressCountry == null && other.DestinationAddressCountry == null) || (this.DestinationAddressCountry?.Equals(other.DestinationAddressCountry) == true)) &&
                ((this.DestinationAddress == null && other.DestinationAddress == null) || (this.DestinationAddress?.Equals(other.DestinationAddress) == true)) &&
                ((this.MessageFormat == null && other.MessageFormat == null) || (this.MessageFormat?.Equals(other.MessageFormat) == true)) &&
                ((this.MetadataKey == null && other.MetadataKey == null) || (this.MetadataKey?.Equals(other.MetadataKey) == true)) &&
                ((this.MetadataValue == null && other.MetadataValue == null) || (this.MetadataValue?.Equals(other.MetadataValue) == true)) &&
                ((this.SourceAddressCountry == null && other.SourceAddressCountry == null) || (this.SourceAddressCountry?.Equals(other.SourceAddressCountry) == true)) &&
                ((this.SourceAddress == null && other.SourceAddress == null) || (this.SourceAddress?.Equals(other.SourceAddress) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Statuses == null && other.Statuses == null) || (this.Statuses?.Equals(other.Statuses) == true)) &&
                ((this.StatusCode == null && other.StatusCode == null) || (this.StatusCode?.Equals(other.StatusCode) == true)) &&
                ((this.DeliveryReport == null && other.DeliveryReport == null) || (this.DeliveryReport?.Equals(other.DeliveryReport) == true)) &&
                ((this.DeliveryOptions == null && other.DeliveryOptions == null) || (this.DeliveryOptions?.Equals(other.DeliveryOptions) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EndDate = {(this.EndDate == null ? "null" : this.EndDate == string.Empty ? "" : this.EndDate)}");
            toStringOutput.Add($"this.StartDate = {(this.StartDate == null ? "null" : this.StartDate == string.Empty ? "" : this.StartDate)}");
            toStringOutput.Add($"this.Period = {(this.Period == null ? "null" : this.Period.ToString())}");
            toStringOutput.Add($"this.SortBy = {(this.SortBy == null ? "null" : this.SortBy.ToString())}");
            toStringOutput.Add($"this.SortDirection = {(this.SortDirection == null ? "null" : this.SortDirection.ToString())}");
            toStringOutput.Add($"this.Timezone = {(this.Timezone == null ? "null" : this.Timezone == string.Empty ? "" : this.Timezone)}");
            toStringOutput.Add($"this.Accounts = {(this.Accounts == null ? "null" : $"[{string.Join(", ", this.Accounts)} ]")}");
            toStringOutput.Add($"this.DestinationAddressCountry = {(this.DestinationAddressCountry == null ? "null" : this.DestinationAddressCountry == string.Empty ? "" : this.DestinationAddressCountry)}");
            toStringOutput.Add($"this.DestinationAddress = {(this.DestinationAddress == null ? "null" : this.DestinationAddress == string.Empty ? "" : this.DestinationAddress)}");
            toStringOutput.Add($"this.MessageFormat = {(this.MessageFormat == null ? "null" : this.MessageFormat.ToString())}");
            toStringOutput.Add($"this.MetadataKey = {(this.MetadataKey == null ? "null" : this.MetadataKey == string.Empty ? "" : this.MetadataKey)}");
            toStringOutput.Add($"this.MetadataValue = {(this.MetadataValue == null ? "null" : this.MetadataValue == string.Empty ? "" : this.MetadataValue)}");
            toStringOutput.Add($"this.SourceAddressCountry = {(this.SourceAddressCountry == null ? "null" : this.SourceAddressCountry == string.Empty ? "" : this.SourceAddressCountry)}");
            toStringOutput.Add($"this.SourceAddress = {(this.SourceAddress == null ? "null" : this.SourceAddress == string.Empty ? "" : this.SourceAddress)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.Statuses = {(this.Statuses == null ? "null" : $"[{string.Join(", ", this.Statuses)} ]")}");
            toStringOutput.Add($"this.StatusCode = {(this.StatusCode == null ? "null" : this.StatusCode == string.Empty ? "" : this.StatusCode)}");
            toStringOutput.Add($"this.DeliveryReport = {(this.DeliveryReport == null ? "null" : this.DeliveryReport.ToString())}");
            toStringOutput.Add($"this.DeliveryOptions = {(this.DeliveryOptions == null ? "null" : $"[{string.Join(", ", this.DeliveryOptions)} ]")}");
        }
    }
}