// <copyright file="AsyncReport.cs" company="APIMatic">
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
    /// AsyncReport.
    /// </summary>
    public class AsyncReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncReport"/> class.
        /// </summary>
        public AsyncReport()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncReport"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="messageType">message_type.</param>
        /// <param name="type">type.</param>
        /// <param name="reportStatus">report_status.</param>
        /// <param name="createdDatetime">created_datetime.</param>
        /// <param name="lastModifiedDatetime">last_modified_datetime.</param>
        public AsyncReport(
            string id = null,
            Models.MessageTypeEnum? messageType = null,
            Models.TypeEnum? type = null,
            Models.ReportStatusEnum? reportStatus = null,
            string createdDatetime = null,
            string lastModifiedDatetime = null)
        {
            this.Id = id;
            this.MessageType = messageType;
            this.Type = type;
            this.ReportStatus = reportStatus;
            this.CreatedDatetime = createdDatetime;
            this.LastModifiedDatetime = lastModifiedDatetime;
        }

        /// <summary>
        /// Unique ID for this reply
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets MessageType.
        /// </summary>
        [JsonProperty("message_type", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.MessageTypeEnum? MessageType { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.TypeEnum? Type { get; set; }

        /// <summary>
        /// Gets or sets ReportStatus.
        /// </summary>
        [JsonProperty("report_status", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ReportStatusEnum? ReportStatus { get; set; }

        /// <summary>
        /// Date time at which this report was created.
        /// </summary>
        [JsonProperty("created_datetime", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedDatetime { get; set; }

        /// <summary>
        /// Date time at which this report was last modified.
        /// </summary>
        [JsonProperty("last_modified_datetime", NullValueHandling = NullValueHandling.Ignore)]
        public string LastModifiedDatetime { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AsyncReport : ({string.Join(", ", toStringOutput)})";
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

            return obj is AsyncReport other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.MessageType == null && other.MessageType == null) || (this.MessageType?.Equals(other.MessageType) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.ReportStatus == null && other.ReportStatus == null) || (this.ReportStatus?.Equals(other.ReportStatus) == true)) &&
                ((this.CreatedDatetime == null && other.CreatedDatetime == null) || (this.CreatedDatetime?.Equals(other.CreatedDatetime) == true)) &&
                ((this.LastModifiedDatetime == null && other.LastModifiedDatetime == null) || (this.LastModifiedDatetime?.Equals(other.LastModifiedDatetime) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.MessageType = {(this.MessageType == null ? "null" : this.MessageType.ToString())}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.ReportStatus = {(this.ReportStatus == null ? "null" : this.ReportStatus.ToString())}");
            toStringOutput.Add($"this.CreatedDatetime = {(this.CreatedDatetime == null ? "null" : this.CreatedDatetime == string.Empty ? "" : this.CreatedDatetime)}");
            toStringOutput.Add($"this.LastModifiedDatetime = {(this.LastModifiedDatetime == null ? "null" : this.LastModifiedDatetime == string.Empty ? "" : this.LastModifiedDatetime)}");
        }
    }
}