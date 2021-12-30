// <copyright file="EventSummary.cs" company="APIMatic">
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
    /// EventSummary.
    /// </summary>
    public class EventSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventSummary"/> class.
        /// </summary>
        public EventSummary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventSummary"/> class.
        /// </summary>
        /// <param name="mEvent">event.</param>
        /// <param name="totalEvents">total_events.</param>
        /// <param name="uniqueRecipients">unique_recipients.</param>
        /// <param name="source">source.</param>
        public EventSummary(
            string mEvent,
            double totalEvents,
            double uniqueRecipients,
            string source = null)
        {
            this.MEvent = mEvent;
            this.Source = source;
            this.TotalEvents = totalEvents;
            this.UniqueRecipients = uniqueRecipients;
        }

        /// <summary>
        /// The event type to which this summary is for.  See [Event Types](#events-types) for a list of available events.
        /// </summary>
        [JsonProperty("event")]
        public string MEvent { get; set; }

        /// <summary>
        /// The event source to which this summary is for, if applicable.
        /// </summary>
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        /// <summary>
        /// The total number of recorded events of this type and source.
        /// </summary>
        [JsonProperty("total_events")]
        public double TotalEvents { get; set; }

        /// <summary>
        /// The unique number of recipients for which there exists at least one event of this type and source recorded.
        /// </summary>
        [JsonProperty("unique_recipients")]
        public double UniqueRecipients { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"EventSummary : ({string.Join(", ", toStringOutput)})";
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

            return obj is EventSummary other &&
                ((this.MEvent == null && other.MEvent == null) || (this.MEvent?.Equals(other.MEvent) == true)) &&
                ((this.Source == null && other.Source == null) || (this.Source?.Equals(other.Source) == true)) &&
                this.TotalEvents.Equals(other.TotalEvents) &&
                this.UniqueRecipients.Equals(other.UniqueRecipients);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MEvent = {(this.MEvent == null ? "null" : this.MEvent == string.Empty ? "" : this.MEvent)}");
            toStringOutput.Add($"this.Source = {(this.Source == null ? "null" : this.Source == string.Empty ? "" : this.Source)}");
            toStringOutput.Add($"this.TotalEvents = {this.TotalEvents}");
            toStringOutput.Add($"this.UniqueRecipients = {this.UniqueRecipients}");
        }
    }
}