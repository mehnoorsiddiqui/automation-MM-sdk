// <copyright file="VendorAccountId.cs" company="APIMatic">
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
    /// VendorAccountId.
    /// </summary>
    public class VendorAccountId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VendorAccountId"/> class.
        /// </summary>
        public VendorAccountId()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VendorAccountId"/> class.
        /// </summary>
        /// <param name="vendorId">vendor_id.</param>
        /// <param name="accountId">account_id.</param>
        public VendorAccountId(
            string vendorId = null,
            string accountId = null)
        {
            this.VendorId = vendorId;
            this.AccountId = accountId;
        }

        /// <summary>
        /// Gets or sets VendorId.
        /// </summary>
        [JsonProperty("vendor_id", NullValueHandling = NullValueHandling.Ignore)]
        public string VendorId { get; set; }

        /// <summary>
        /// The account used to submit the original message.
        /// </summary>
        [JsonProperty("account_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"VendorAccountId : ({string.Join(", ", toStringOutput)})";
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

            return obj is VendorAccountId other &&
                ((this.VendorId == null && other.VendorId == null) || (this.VendorId?.Equals(other.VendorId) == true)) &&
                ((this.AccountId == null && other.AccountId == null) || (this.AccountId?.Equals(other.AccountId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.VendorId = {(this.VendorId == null ? "null" : this.VendorId == string.Empty ? "" : this.VendorId)}");
            toStringOutput.Add($"this.AccountId = {(this.AccountId == null ? "null" : this.AccountId == string.Empty ? "" : this.AccountId)}");
        }
    }
}