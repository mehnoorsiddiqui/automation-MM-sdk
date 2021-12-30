// <copyright file="CampaignSummary.cs" company="APIMatic">
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
    /// CampaignSummary.
    /// </summary>
    public class CampaignSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignSummary"/> class.
        /// </summary>
        public CampaignSummary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignSummary"/> class.
        /// </summary>
        /// <param name="totalEvents">total_events.</param>
        /// <param name="uniqueEngagements">unique_engagements.</param>
        /// <param name="eventSummary">event_summary.</param>
        public CampaignSummary(
            double totalEvents,
            double uniqueEngagements,
            List<Models.EventSummary> eventSummary)
        {
            this.TotalEvents = totalEvents;
            this.UniqueEngagements = uniqueEngagements;
            this.EventSummary = eventSummary;
        }

        /// <summary>
        /// The total number of events record against this campaign.
        /// </summary>
        [JsonProperty("total_events")]
        public double TotalEvents { get; set; }

        /// <summary>
        /// The unique number of recipients for which there exists at least one recorded event.
        /// </summary>
        [JsonProperty("unique_engagements")]
        public double UniqueEngagements { get; set; }

        /// <summary>
        /// The event summary breakdown.
        /// </summary>
        [JsonProperty("event_summary")]
        public List<Models.EventSummary> EventSummary { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CampaignSummary : ({string.Join(", ", toStringOutput)})";
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

            return obj is CampaignSummary other &&
                this.TotalEvents.Equals(other.TotalEvents) &&
                this.UniqueEngagements.Equals(other.UniqueEngagements) &&
                ((this.EventSummary == null && other.EventSummary == null) || (this.EventSummary?.Equals(other.EventSummary) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TotalEvents = {this.TotalEvents}");
            toStringOutput.Add($"this.UniqueEngagements = {this.UniqueEngagements}");
            toStringOutput.Add($"this.EventSummary = {(this.EventSummary == null ? "null" : $"[{string.Join(", ", this.EventSummary)} ]")}");
        }
    }
}