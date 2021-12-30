// <copyright file="ListCampaignEventPage.cs" company="APIMatic">
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
    /// ListCampaignEventPage.
    /// </summary>
    public class ListCampaignEventPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCampaignEventPage"/> class.
        /// </summary>
        public ListCampaignEventPage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListCampaignEventPage"/> class.
        /// </summary>
        /// <param name="events">events.</param>
        /// <param name="pagination">pagination.</param>
        public ListCampaignEventPage(
            List<Models.CampaignEvent> events,
            Models.Pagination1 pagination)
        {
            this.Events = events;
            this.Pagination = pagination;
        }

        /// <summary>
        /// The list of campaign events.
        /// </summary>
        [JsonProperty("events")]
        public List<Models.CampaignEvent> Events { get; set; }

        /// <summary>
        /// Gets or sets Pagination.
        /// </summary>
        [JsonProperty("pagination")]
        public Models.Pagination1 Pagination { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListCampaignEventPage : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListCampaignEventPage other &&
                ((this.Events == null && other.Events == null) || (this.Events?.Equals(other.Events) == true)) &&
                ((this.Pagination == null && other.Pagination == null) || (this.Pagination?.Equals(other.Pagination) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Events = {(this.Events == null ? "null" : $"[{string.Join(", ", this.Events)} ]")}");
            toStringOutput.Add($"this.Pagination = {(this.Pagination == null ? "null" : this.Pagination.ToString())}");
        }
    }
}