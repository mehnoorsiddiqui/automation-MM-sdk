// <copyright file="AssignedNumber.cs" company="APIMatic">
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
    /// AssignedNumber.
    /// </summary>
    public class AssignedNumber
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssignedNumber"/> class.
        /// </summary>
        public AssignedNumber()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignedNumber"/> class.
        /// </summary>
        /// <param name="assignment">assignment.</param>
        /// <param name="number">number.</param>
        public AssignedNumber(
            Models.Assignment assignment = null,
            object number = null)
        {
            this.Assignment = assignment;
            this.Number = number;
        }

        /// <summary>
        /// Gets or sets Assignment.
        /// </summary>
        [JsonProperty("assignment", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Assignment Assignment { get; set; }

        /// <summary>
        /// Gets or sets Number.
        /// </summary>
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public object Number { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AssignedNumber : ({string.Join(", ", toStringOutput)})";
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

            return obj is AssignedNumber other &&
                ((this.Assignment == null && other.Assignment == null) || (this.Assignment?.Equals(other.Assignment) == true)) &&
                ((this.Number == null && other.Number == null) || (this.Number?.Equals(other.Number) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Assignment = {(this.Assignment == null ? "null" : this.Assignment.ToString())}");
            toStringOutput.Add($"Number = {(this.Number == null ? "null" : this.Number.ToString())}");
        }
    }
}