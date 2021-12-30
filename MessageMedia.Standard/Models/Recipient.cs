// <copyright file="Recipient.cs" company="APIMatic">
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
    /// Recipient.
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Recipient"/> class.
        /// </summary>
        public Recipient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipient"/> class.
        /// </summary>
        /// <param name="number">number.</param>
        /// <param name="parameters">parameters.</param>
        /// <param name="scheduled">scheduled.</param>
        public Recipient(
            string number,
            object parameters = null,
            string scheduled = null)
        {
            this.Number = number;
            this.Parameters = parameters;
            this.Scheduled = scheduled;
        }

        /// <summary>
        /// The recipient phone number.  Must be E.164 with a leading '+'
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// The recipient scoped template parameters
        /// </summary>
        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public object Parameters { get; set; }

        /// <summary>
        /// A message can be scheduled for delivery in the future by setting the scheduled property. The scheduled property expects a date time specified in ISO 8601 format. The scheduled time must be provided in UTC and be no more than 31 days in the future.
        /// </summary>
        [JsonProperty("scheduled", NullValueHandling = NullValueHandling.Ignore)]
        public string Scheduled { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Recipient : ({string.Join(", ", toStringOutput)})";
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

            return obj is Recipient other &&
                ((this.Number == null && other.Number == null) || (this.Number?.Equals(other.Number) == true)) &&
                ((this.Parameters == null && other.Parameters == null) || (this.Parameters?.Equals(other.Parameters) == true)) &&
                ((this.Scheduled == null && other.Scheduled == null) || (this.Scheduled?.Equals(other.Scheduled) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Number = {(this.Number == null ? "null" : this.Number == string.Empty ? "" : this.Number)}");
            toStringOutput.Add($"Parameters = {(this.Parameters == null ? "null" : this.Parameters.ToString())}");
            toStringOutput.Add($"this.Scheduled = {(this.Scheduled == null ? "null" : this.Scheduled == string.Empty ? "" : this.Scheduled)}");
        }
    }
}