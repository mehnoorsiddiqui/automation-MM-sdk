// <copyright file="Confirmrepliesasreceivedrequest.cs" company="APIMatic">
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
    /// Confirmrepliesasreceivedrequest.
    /// </summary>
    public class Confirmrepliesasreceivedrequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Confirmrepliesasreceivedrequest"/> class.
        /// </summary>
        public Confirmrepliesasreceivedrequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Confirmrepliesasreceivedrequest"/> class.
        /// </summary>
        /// <param name="replyIds">reply_ids.</param>
        public Confirmrepliesasreceivedrequest(
            List<Guid> replyIds)
        {
            this.ReplyIds = replyIds;
        }

        /// <summary>
        /// The UUID of the *reply* to be confirmed (note: not the UUID of the message it is in response to)
        /// </summary>
        [JsonProperty("reply_ids")]
        public List<Guid> ReplyIds { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Confirmrepliesasreceivedrequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is Confirmrepliesasreceivedrequest other &&
                ((this.ReplyIds == null && other.ReplyIds == null) || (this.ReplyIds?.Equals(other.ReplyIds) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ReplyIds = {(this.ReplyIds == null ? "null" : $"[{string.Join(", ", this.ReplyIds)} ]")}");
        }
    }
}