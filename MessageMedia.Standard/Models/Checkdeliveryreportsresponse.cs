// <copyright file="Checkdeliveryreportsresponse.cs" company="APIMatic">
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
    /// Checkdeliveryreportsresponse.
    /// </summary>
    public class Checkdeliveryreportsresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Checkdeliveryreportsresponse"/> class.
        /// </summary>
        public Checkdeliveryreportsresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkdeliveryreportsresponse"/> class.
        /// </summary>
        /// <param name="deliveryReports">delivery_reports.</param>
        public Checkdeliveryreportsresponse(
            List<Models.DeliveryReport> deliveryReports = null)
        {
            this.DeliveryReports = deliveryReports;
        }

        /// <summary>
        /// The oldest 100 unconfirmed delivery reports
        /// </summary>
        [JsonProperty("delivery_reports", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.DeliveryReport> DeliveryReports { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Checkdeliveryreportsresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is Checkdeliveryreportsresponse other &&
                ((this.DeliveryReports == null && other.DeliveryReports == null) || (this.DeliveryReports?.Equals(other.DeliveryReports) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DeliveryReports = {(this.DeliveryReports == null ? "null" : $"[{string.Join(", ", this.DeliveryReports)} ]")}");
        }
    }
}