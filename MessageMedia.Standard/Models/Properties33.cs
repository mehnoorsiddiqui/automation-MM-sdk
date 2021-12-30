// <copyright file="Properties33.cs" company="APIMatic">
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
    /// Properties33.
    /// </summary>
    public class Properties33
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Properties33"/> class.
        /// </summary>
        public Properties33()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Properties33"/> class.
        /// </summary>
        /// <param name="endDate">end_date.</param>
        /// <param name="startDate">start_date.</param>
        /// <param name="filters">filters.</param>
        /// <param name="grouping">grouping.</param>
        /// <param name="summary">summary.</param>
        /// <param name="summaryField">summary_field.</param>
        /// <param name="timezone">timezone.</param>
        public Properties33(
            string endDate,
            string startDate,
            object filters = null,
            Models.GroupingEnum? grouping = null,
            Models.SummaryEnum? summary = null,
            Models.SummaryFieldEnum? summaryField = null,
            string timezone = null)
        {
            this.EndDate = endDate;
            this.StartDate = startDate;
            this.Filters = filters;
            this.Grouping = grouping;
            this.Summary = summary;
            this.SummaryField = summaryField;
            this.Timezone = timezone;
        }

        /// <summary>
        /// End date time for report window. By default, the timezone for this parameter will be taken from the account settings for the account associated with the credentials used to make the request, or the account included in the Account parameter. This can be overridden using the timezone parameter per request. The date must be in ISO8601 format.
        /// </summary>
        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        /// <summary>
        /// Start date time for report window. By default, the timezone for this parameter will be taken from the account settings for the account associated with the credentials used to make the request, or the account included in the Account parameter. This can be overridden using the timezone parameter per request. The date must be in ISO8601 format.
        /// </summary>
        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        /// <summary>
        /// Any filters provided as parameters for this report
        /// </summary>
        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public object Filters { get; set; }

        /// <summary>
        /// The value of the group by parameter provided for this report
        /// </summary>
        [JsonProperty("grouping", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.GroupingEnum? Grouping { get; set; }

        /// <summary>
        /// The value of the summary_by parameter provided for this report
        /// </summary>
        [JsonProperty("summary", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.SummaryEnum? Summary { get; set; }

        /// <summary>
        /// The value of the summary_field parameter provided for this report
        /// </summary>
        [JsonProperty("summary_field", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.SummaryFieldEnum? SummaryField { get; set; }

        /// <summary>
        /// Gets or sets Timezone.
        /// </summary>
        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Properties33 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Properties33 other &&
                ((this.EndDate == null && other.EndDate == null) || (this.EndDate?.Equals(other.EndDate) == true)) &&
                ((this.StartDate == null && other.StartDate == null) || (this.StartDate?.Equals(other.StartDate) == true)) &&
                ((this.Filters == null && other.Filters == null) || (this.Filters?.Equals(other.Filters) == true)) &&
                ((this.Grouping == null && other.Grouping == null) || (this.Grouping?.Equals(other.Grouping) == true)) &&
                ((this.Summary == null && other.Summary == null) || (this.Summary?.Equals(other.Summary) == true)) &&
                ((this.SummaryField == null && other.SummaryField == null) || (this.SummaryField?.Equals(other.SummaryField) == true)) &&
                ((this.Timezone == null && other.Timezone == null) || (this.Timezone?.Equals(other.Timezone) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EndDate = {(this.EndDate == null ? "null" : this.EndDate == string.Empty ? "" : this.EndDate)}");
            toStringOutput.Add($"this.StartDate = {(this.StartDate == null ? "null" : this.StartDate == string.Empty ? "" : this.StartDate)}");
            toStringOutput.Add($"Filters = {(this.Filters == null ? "null" : this.Filters.ToString())}");
            toStringOutput.Add($"this.Grouping = {(this.Grouping == null ? "null" : this.Grouping.ToString())}");
            toStringOutput.Add($"this.Summary = {(this.Summary == null ? "null" : this.Summary.ToString())}");
            toStringOutput.Add($"this.SummaryField = {(this.SummaryField == null ? "null" : this.SummaryField.ToString())}");
            toStringOutput.Add($"this.Timezone = {(this.Timezone == null ? "null" : this.Timezone == string.Empty ? "" : this.Timezone)}");
        }
    }
}