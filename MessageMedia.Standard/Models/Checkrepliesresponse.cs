// <copyright file="Checkrepliesresponse.cs" company="APIMatic">
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
    /// Checkrepliesresponse.
    /// </summary>
    public class Checkrepliesresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Checkrepliesresponse"/> class.
        /// </summary>
        public Checkrepliesresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkrepliesresponse"/> class.
        /// </summary>
        /// <param name="replies">replies.</param>
        public Checkrepliesresponse(
            List<Models.Reply> replies = null)
        {
            this.Replies = replies;
        }

        /// <summary>
        /// The oldest 100 unconfirmed replies
        /// </summary>
        [JsonProperty("replies", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Reply> Replies { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Checkrepliesresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is Checkrepliesresponse other &&
                ((this.Replies == null && other.Replies == null) || (this.Replies?.Equals(other.Replies) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Replies = {(this.Replies == null ? "null" : $"[{string.Join(", ", this.Replies)} ]")}");
        }
    }
}