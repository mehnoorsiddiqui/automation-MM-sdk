// <copyright file="Lookupaphonenumberresponse.cs" company="APIMatic">
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
    /// Lookupaphonenumberresponse.
    /// </summary>
    public class Lookupaphonenumberresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lookupaphonenumberresponse"/> class.
        /// </summary>
        public Lookupaphonenumberresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lookupaphonenumberresponse"/> class.
        /// </summary>
        /// <param name="countryCode">country_code.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="type">type.</param>
        /// <param name="carrier">carrier.</param>
        /// <param name="result">result.</param>
        /// <param name="imsi">imsi.</param>
        /// <param name="location">location.</param>
        public Lookupaphonenumberresponse(
            string countryCode,
            string phoneNumber,
            string type,
            Models.Carrier carrier,
            string result = null,
            long? imsi = null,
            int? location = null)
        {
            this.CountryCode = countryCode;
            this.PhoneNumber = phoneNumber;
            this.Type = type;
            this.Carrier = carrier;
            this.Result = result;
            this.Imsi = imsi;
            this.Location = location;
        }

        /// <summary>
        /// Gets or sets CountryCode.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumber.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Carrier.
        /// </summary>
        [JsonProperty("carrier")]
        public Models.Carrier Carrier { get; set; }

        /// <summary>
        /// Gets or sets Result.
        /// </summary>
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public string Result { get; set; }

        /// <summary>
        /// A unique number identifying a GSM subscriber
        /// </summary>
        [JsonProperty("imsi", NullValueHandling = NullValueHandling.Ignore)]
        public long? Imsi { get; set; }

        /// <summary>
        /// The location of the mobile number
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public int? Location { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Lookupaphonenumberresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is Lookupaphonenumberresponse other &&
                ((this.CountryCode == null && other.CountryCode == null) || (this.CountryCode?.Equals(other.CountryCode) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Carrier == null && other.Carrier == null) || (this.Carrier?.Equals(other.Carrier) == true)) &&
                ((this.Result == null && other.Result == null) || (this.Result?.Equals(other.Result) == true)) &&
                ((this.Imsi == null && other.Imsi == null) || (this.Imsi?.Equals(other.Imsi) == true)) &&
                ((this.Location == null && other.Location == null) || (this.Location?.Equals(other.Location) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CountryCode = {(this.CountryCode == null ? "null" : this.CountryCode == string.Empty ? "" : this.CountryCode)}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type == string.Empty ? "" : this.Type)}");
            toStringOutput.Add($"this.Carrier = {(this.Carrier == null ? "null" : this.Carrier.ToString())}");
            toStringOutput.Add($"this.Result = {(this.Result == null ? "null" : this.Result == string.Empty ? "" : this.Result)}");
            toStringOutput.Add($"this.Imsi = {(this.Imsi == null ? "null" : this.Imsi.ToString())}");
            toStringOutput.Add($"this.Location = {(this.Location == null ? "null" : this.Location.ToString())}");
        }
    }
}