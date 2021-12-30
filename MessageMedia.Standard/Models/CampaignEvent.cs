// <copyright file="CampaignEvent.cs" company="APIMatic">
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
    /// CampaignEvent.
    /// </summary>
    public class CampaignEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignEvent"/> class.
        /// </summary>
        public CampaignEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignEvent"/> class.
        /// </summary>
        /// <param name="campaignId">campaign_id.</param>
        /// <param name="recipientId">recipient_id.</param>
        /// <param name="number">number.</param>
        /// <param name="mEvent">event.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="source">source.</param>
        public CampaignEvent(
            string campaignId,
            string recipientId,
            string number,
            string mEvent,
            string timestamp,
            string source = null)
        {
            this.CampaignId = campaignId;
            this.RecipientId = recipientId;
            this.Number = number;
            this.MEvent = mEvent;
            this.Source = source;
            this.Timestamp = timestamp;
        }

        /// <summary>
        /// The campaign ID
        /// </summary>
        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        /// <summary>
        /// The recipient ID to which this event corresponds to
        /// </summary>
        [JsonProperty("recipient_id")]
        public string RecipientId { get; set; }

        /// <summary>
        /// The recipient's phone number
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// The event type.  See [Event Types](#events-types) for a list of available events.
        /// </summary>
        [JsonProperty("event")]
        public string MEvent { get; set; }

        /// <summary>
        /// The source identifier.  This identifies the element that produced the event.  This may not be applicable for all events.
        /// </summary>
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        /// <summary>
        /// The timestamp of the event, in ISO 8601 format.
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CampaignEvent : ({string.Join(", ", toStringOutput)})";
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

            return obj is CampaignEvent other &&
                ((this.CampaignId == null && other.CampaignId == null) || (this.CampaignId?.Equals(other.CampaignId) == true)) &&
                ((this.RecipientId == null && other.RecipientId == null) || (this.RecipientId?.Equals(other.RecipientId) == true)) &&
                ((this.Number == null && other.Number == null) || (this.Number?.Equals(other.Number) == true)) &&
                ((this.MEvent == null && other.MEvent == null) || (this.MEvent?.Equals(other.MEvent) == true)) &&
                ((this.Source == null && other.Source == null) || (this.Source?.Equals(other.Source) == true)) &&
                ((this.Timestamp == null && other.Timestamp == null) || (this.Timestamp?.Equals(other.Timestamp) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CampaignId = {(this.CampaignId == null ? "null" : this.CampaignId == string.Empty ? "" : this.CampaignId)}");
            toStringOutput.Add($"this.RecipientId = {(this.RecipientId == null ? "null" : this.RecipientId == string.Empty ? "" : this.RecipientId)}");
            toStringOutput.Add($"this.Number = {(this.Number == null ? "null" : this.Number == string.Empty ? "" : this.Number)}");
            toStringOutput.Add($"this.MEvent = {(this.MEvent == null ? "null" : this.MEvent == string.Empty ? "" : this.MEvent)}");
            toStringOutput.Add($"this.Source = {(this.Source == null ? "null" : this.Source == string.Empty ? "" : this.Source)}");
            toStringOutput.Add($"this.Timestamp = {(this.Timestamp == null ? "null" : this.Timestamp == string.Empty ? "" : this.Timestamp)}");
        }
    }
}