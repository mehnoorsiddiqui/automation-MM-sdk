// <copyright file="DeliveryOptionsBody.cs" company="APIMatic">
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
    /// DeliveryOptionsBody.
    /// </summary>
    public class DeliveryOptionsBody
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryOptionsBody"/> class.
        /// </summary>
        public DeliveryOptionsBody()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryOptionsBody"/> class.
        /// </summary>
        /// <param name="deliveryType">delivery_type.</param>
        /// <param name="deliveryAddresses">delivery_addresses.</param>
        /// <param name="deliveryFormat">delivery_format.</param>
        public DeliveryOptionsBody(
            string deliveryType = null,
            List<string> deliveryAddresses = null,
            string deliveryFormat = null)
        {
            this.DeliveryType = deliveryType;
            this.DeliveryAddresses = deliveryAddresses;
            this.DeliveryFormat = deliveryFormat;
        }

        /// <summary>
        /// How to deliver the report.
        /// </summary>
        [JsonProperty("delivery_type", NullValueHandling = NullValueHandling.Ignore)]
        public string DeliveryType { get; set; }

        /// <summary>
        /// A list of email addresses to use as the recipient of the email. Only works for EMAIL delivery type
        /// </summary>
        [JsonProperty("delivery_addresses", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> DeliveryAddresses { get; set; }

        /// <summary>
        /// Format of the report.
        /// </summary>
        [JsonProperty("delivery_format", NullValueHandling = NullValueHandling.Ignore)]
        public string DeliveryFormat { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeliveryOptionsBody : ({string.Join(", ", toStringOutput)})";
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

            return obj is DeliveryOptionsBody other &&
                ((this.DeliveryType == null && other.DeliveryType == null) || (this.DeliveryType?.Equals(other.DeliveryType) == true)) &&
                ((this.DeliveryAddresses == null && other.DeliveryAddresses == null) || (this.DeliveryAddresses?.Equals(other.DeliveryAddresses) == true)) &&
                ((this.DeliveryFormat == null && other.DeliveryFormat == null) || (this.DeliveryFormat?.Equals(other.DeliveryFormat) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DeliveryType = {(this.DeliveryType == null ? "null" : this.DeliveryType == string.Empty ? "" : this.DeliveryType)}");
            toStringOutput.Add($"this.DeliveryAddresses = {(this.DeliveryAddresses == null ? "null" : $"[{string.Join(", ", this.DeliveryAddresses)} ]")}");
            toStringOutput.Add($"this.DeliveryFormat = {(this.DeliveryFormat == null ? "null" : this.DeliveryFormat == string.Empty ? "" : this.DeliveryFormat)}");
        }
    }
}