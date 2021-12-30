// <copyright file="Addoneormorenumberstoyourbacklistrequest.cs" company="APIMatic">
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
    /// Addoneormorenumberstoyourbacklistrequest.
    /// </summary>
    public class Addoneormorenumberstoyourbacklistrequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Addoneormorenumberstoyourbacklistrequest"/> class.
        /// </summary>
        public Addoneormorenumberstoyourbacklistrequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Addoneormorenumberstoyourbacklistrequest"/> class.
        /// </summary>
        /// <param name="numbers">numbers.</param>
        public Addoneormorenumberstoyourbacklistrequest(
            List<string> numbers)
        {
            this.Numbers = numbers;
        }

        /// <summary>
        /// Array of numbers to be added to the blacklist. These should be specified in E.164 international format. For information on E.164, please refer to http://en.wikipedia.org/wiki/E.164.
        /// </summary>
        [JsonProperty("numbers")]
        public List<string> Numbers { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Addoneormorenumberstoyourbacklistrequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is Addoneormorenumberstoyourbacklistrequest other &&
                ((this.Numbers == null && other.Numbers == null) || (this.Numbers?.Equals(other.Numbers) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Numbers = {(this.Numbers == null ? "null" : $"[{string.Join(", ", this.Numbers)} ]")}");
        }
    }
}