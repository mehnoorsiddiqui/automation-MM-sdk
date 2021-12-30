// <copyright file="Confirmeliveryreportsasreceivedrequest.cs" company="APIMatic">
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
    /// Confirmeliveryreportsasreceivedrequest.
    /// </summary>
    public class Confirmeliveryreportsasreceivedrequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Confirmeliveryreportsasreceivedrequest"/> class.
        /// </summary>
        public Confirmeliveryreportsasreceivedrequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Confirmeliveryreportsasreceivedrequest"/> class.
        /// </summary>
        /// <param name="deliveryReportIds">delivery_report_ids.</param>
        public Confirmeliveryreportsasreceivedrequest(
            List<Guid> deliveryReportIds)
        {
            this.DeliveryReportIds = deliveryReportIds;
        }

        /// <summary>
        /// Array of unique IDs for the delivery report that this notification represents
        /// </summary>
        [JsonProperty("delivery_report_ids")]
        public List<Guid> DeliveryReportIds { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Confirmeliveryreportsasreceivedrequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is Confirmeliveryreportsasreceivedrequest other &&
                ((this.DeliveryReportIds == null && other.DeliveryReportIds == null) || (this.DeliveryReportIds?.Equals(other.DeliveryReportIds) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DeliveryReportIds = {(this.DeliveryReportIds == null ? "null" : $"[{string.Join(", ", this.DeliveryReportIds)} ]")}");
        }
    }
}