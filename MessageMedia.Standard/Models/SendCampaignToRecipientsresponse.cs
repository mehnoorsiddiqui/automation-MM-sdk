// <copyright file="SendCampaignToRecipientsresponse.cs" company="APIMatic">
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
    /// SendCampaignToRecipientsresponse.
    /// </summary>
    public class SendCampaignToRecipientsresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendCampaignToRecipientsresponse"/> class.
        /// </summary>
        public SendCampaignToRecipientsresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendCampaignToRecipientsresponse"/> class.
        /// </summary>
        /// <param name="recipients">recipients.</param>
        public SendCampaignToRecipientsresponse(
            List<Models.Recipient1> recipients)
        {
            this.Recipients = recipients;
        }

        /// <summary>
        /// Gets or sets Recipients.
        /// </summary>
        [JsonProperty("recipients")]
        public List<Models.Recipient1> Recipients { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SendCampaignToRecipientsresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is SendCampaignToRecipientsresponse other &&
                ((this.Recipients == null && other.Recipients == null) || (this.Recipients?.Equals(other.Recipients) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Recipients = {(this.Recipients == null ? "null" : $"[{string.Join(", ", this.Recipients)} ]")}");
        }
    }
}