// <copyright file="SendCampaignToRecipientsrequest.cs" company="APIMatic">
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
    /// SendCampaignToRecipientsrequest.
    /// </summary>
    public class SendCampaignToRecipientsrequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendCampaignToRecipientsrequest"/> class.
        /// </summary>
        public SendCampaignToRecipientsrequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendCampaignToRecipientsrequest"/> class.
        /// </summary>
        /// <param name="recipients">recipients.</param>
        public SendCampaignToRecipientsrequest(
            List<Models.Recipient> recipients)
        {
            this.Recipients = recipients;
        }

        /// <summary>
        /// Gets or sets Recipients.
        /// </summary>
        [JsonProperty("recipients")]
        public List<Models.Recipient> Recipients { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SendCampaignToRecipientsrequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is SendCampaignToRecipientsrequest other &&
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