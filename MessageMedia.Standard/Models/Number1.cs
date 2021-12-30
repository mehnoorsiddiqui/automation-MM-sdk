// <copyright file="Number1.cs" company="APIMatic">
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
    /// Number1.
    /// </summary>
    public class Number1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Number1"/> class.
        /// </summary>
        public Number1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Number1"/> class.
        /// </summary>
        /// <param name="availableAfter">available_after.</param>
        /// <param name="capabilities">capabilities.</param>
        /// <param name="classification">classification.</param>
        /// <param name="country">country.</param>
        /// <param name="id">id.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="type">type.</param>
        public Number1(
            DateTime? availableAfter = null,
            List<Models.CapabilityEnum> capabilities = null,
            Models.ClassificationEnum? classification = null,
            string country = null,
            string id = null,
            string phoneNumber = null,
            Models.Type1Enum? type = null)
        {
            this.AvailableAfter = availableAfter;
            this.Capabilities = capabilities;
            this.Classification = classification;
            this.Country = country;
            this.Id = id;
            this.PhoneNumber = phoneNumber;
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets AvailableAfter.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("available_after", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? AvailableAfter { get; set; }

        /// <summary>
        /// Gets or sets Capabilities.
        /// </summary>
        [JsonProperty("capabilities", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.CapabilityEnum> Capabilities { get; set; }

        /// <summary>
        /// Gets or sets Classification.
        /// </summary>
        [JsonProperty("classification", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ClassificationEnum? Classification { get; set; }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumber.
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.Type1Enum? Type { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Number1 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Number1 other &&
                ((this.AvailableAfter == null && other.AvailableAfter == null) || (this.AvailableAfter?.Equals(other.AvailableAfter) == true)) &&
                ((this.Capabilities == null && other.Capabilities == null) || (this.Capabilities?.Equals(other.Capabilities) == true)) &&
                ((this.Classification == null && other.Classification == null) || (this.Classification?.Equals(other.Classification) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AvailableAfter = {(this.AvailableAfter == null ? "null" : this.AvailableAfter.ToString())}");
            toStringOutput.Add($"this.Capabilities = {(this.Capabilities == null ? "null" : $"[{string.Join(", ", this.Capabilities)} ]")}");
            toStringOutput.Add($"this.Classification = {(this.Classification == null ? "null" : this.Classification.ToString())}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country == string.Empty ? "" : this.Country)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
        }
    }
}