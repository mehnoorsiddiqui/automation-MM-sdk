// <copyright file="SummaryReport.cs" company="APIMatic">
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
    /// SummaryReport.
    /// </summary>
    public class SummaryReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryReport"/> class.
        /// </summary>
        public SummaryReport()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryReport"/> class.
        /// </summary>
        /// <param name="properties">properties.</param>
        /// <param name="data">data.</param>
        public SummaryReport(
            Models.Properties33 properties = null,
            List<Models.SummaryReportItem> data = null)
        {
            this.Properties = properties;
            this.Data = data;
        }

        /// <summary>
        /// Gets or sets Properties.
        /// </summary>
        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Properties33 Properties { get; set; }

        /// <summary>
        /// Gets or sets Data.
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.SummaryReportItem> Data { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SummaryReport : ({string.Join(", ", toStringOutput)})";
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

            return obj is SummaryReport other &&
                ((this.Properties == null && other.Properties == null) || (this.Properties?.Equals(other.Properties) == true)) &&
                ((this.Data == null && other.Data == null) || (this.Data?.Equals(other.Data) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Properties = {(this.Properties == null ? "null" : this.Properties.ToString())}");
            toStringOutput.Add($"this.Data = {(this.Data == null ? "null" : $"[{string.Join(", ", this.Data)} ]")}");
        }
    }
}