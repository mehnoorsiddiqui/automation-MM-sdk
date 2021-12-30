// <copyright file="Sendmessagesresponse.cs" company="APIMatic">
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
    /// Sendmessagesresponse.
    /// </summary>
    public class Sendmessagesresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sendmessagesresponse"/> class.
        /// </summary>
        public Sendmessagesresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sendmessagesresponse"/> class.
        /// </summary>
        /// <param name="messages">messages.</param>
        public Sendmessagesresponse(
            List<Models.Message> messages = null)
        {
            this.Messages = messages;
        }

        /// <summary>
        /// Gets or sets Messages.
        /// </summary>
        [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Message> Messages { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Sendmessagesresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is Sendmessagesresponse other &&
                ((this.Messages == null && other.Messages == null) || (this.Messages?.Equals(other.Messages) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Messages = {(this.Messages == null ? "null" : $"[{string.Join(", ", this.Messages)} ]")}");
        }
    }
}