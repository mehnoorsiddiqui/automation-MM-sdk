// <copyright file="View.cs" company="APIMatic">
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
    /// View.
    /// </summary>
    public class View
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="View"/> class.
        /// </summary>
        public View()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="View"/> class.
        /// </summary>
        /// <param name="dt">dt.</param>
        /// <param name="userAgent">user_agent.</param>
        /// <param name="ip">ip.</param>
        public View(
            string dt = null,
            string userAgent = null,
            string ip = null)
        {
            this.Dt = dt;
            this.UserAgent = userAgent;
            this.Ip = ip;
        }

        /// <summary>
        /// Gets or sets Dt.
        /// </summary>
        [JsonProperty("dt", NullValueHandling = NullValueHandling.Ignore)]
        public string Dt { get; set; }

        /// <summary>
        /// Gets or sets UserAgent.
        /// </summary>
        [JsonProperty("user_agent", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets Ip.
        /// </summary>
        [JsonProperty("ip", NullValueHandling = NullValueHandling.Ignore)]
        public string Ip { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"View : ({string.Join(", ", toStringOutput)})";
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

            return obj is View other &&
                ((this.Dt == null && other.Dt == null) || (this.Dt?.Equals(other.Dt) == true)) &&
                ((this.UserAgent == null && other.UserAgent == null) || (this.UserAgent?.Equals(other.UserAgent) == true)) &&
                ((this.Ip == null && other.Ip == null) || (this.Ip?.Equals(other.Ip) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Dt = {(this.Dt == null ? "null" : this.Dt == string.Empty ? "" : this.Dt)}");
            toStringOutput.Add($"this.UserAgent = {(this.UserAgent == null ? "null" : this.UserAgent == string.Empty ? "" : this.UserAgent)}");
            toStringOutput.Add($"this.Ip = {(this.Ip == null ? "null" : this.Ip == string.Empty ? "" : this.Ip)}");
        }
    }
}