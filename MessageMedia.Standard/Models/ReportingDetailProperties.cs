// <copyright file="ReportingDetailProperties.cs" company="APIMatic">
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
    /// ReportingDetailProperties.
    /// </summary>
    public class ReportingDetailProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingDetailProperties"/> class.
        /// </summary>
        public ReportingDetailProperties()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingDetailProperties"/> class.
        /// </summary>
        /// <param name="endDate">end_date.</param>
        /// <param name="startDate">start_date.</param>
        /// <param name="sorting">sorting.</param>
        /// <param name="filters">filters.</param>
        /// <param name="timezone">timezone.</param>
        public ReportingDetailProperties(
            string endDate,
            string startDate,
            Models.Sorting sorting = null,
            Models.Filters filters = null,
            string timezone = null)
        {
            this.EndDate = endDate;
            this.StartDate = startDate;
            this.Sorting = sorting;
            this.Filters = filters;
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
        /// Gets or sets Sorting.
        /// </summary>
        [JsonProperty("sorting", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Sorting Sorting { get; set; }

        /// <summary>
        /// Gets or sets Filters.
        /// </summary>
        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Filters Filters { get; set; }

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

            return $"ReportingDetailProperties : ({string.Join(", ", toStringOutput)})";
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

            return obj is ReportingDetailProperties other &&
                ((this.EndDate == null && other.EndDate == null) || (this.EndDate?.Equals(other.EndDate) == true)) &&
                ((this.StartDate == null && other.StartDate == null) || (this.StartDate?.Equals(other.StartDate) == true)) &&
                ((this.Sorting == null && other.Sorting == null) || (this.Sorting?.Equals(other.Sorting) == true)) &&
                ((this.Filters == null && other.Filters == null) || (this.Filters?.Equals(other.Filters) == true)) &&
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
            toStringOutput.Add($"this.Sorting = {(this.Sorting == null ? "null" : this.Sorting.ToString())}");
            toStringOutput.Add($"this.Filters = {(this.Filters == null ? "null" : this.Filters.ToString())}");
            toStringOutput.Add($"this.Timezone = {(this.Timezone == null ? "null" : this.Timezone == string.Empty ? "" : this.Timezone)}");
        }
    }
}