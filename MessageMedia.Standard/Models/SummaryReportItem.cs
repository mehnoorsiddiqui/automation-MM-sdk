// <copyright file="SummaryReportItem.cs" company="APIMatic">
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
    /// SummaryReportItem.
    /// </summary>
    public class SummaryReportItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryReportItem"/> class.
        /// </summary>
        public SummaryReportItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryReportItem"/> class.
        /// </summary>
        /// <param name="mGroup">group.</param>
        /// <param name="mValue">value.</param>
        public SummaryReportItem(
            string mGroup = null,
            double? mValue = null)
        {
            this.MGroup = mGroup;
            this.MValue = mValue;
        }

        /// <summary>
        /// Gets or sets MGroup.
        /// </summary>
        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public string MGroup { get; set; }

        /// <summary>
        /// Gets or sets MValue.
        /// </summary>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public double? MValue { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SummaryReportItem : ({string.Join(", ", toStringOutput)})";
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

            return obj is SummaryReportItem other &&
                ((this.MGroup == null && other.MGroup == null) || (this.MGroup?.Equals(other.MGroup) == true)) &&
                ((this.MValue == null && other.MValue == null) || (this.MValue?.Equals(other.MValue) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MGroup = {(this.MGroup == null ? "null" : this.MGroup == string.Empty ? "" : this.MGroup)}");
            toStringOutput.Add($"this.MValue = {(this.MValue == null ? "null" : this.MValue.ToString())}");
        }
    }
}