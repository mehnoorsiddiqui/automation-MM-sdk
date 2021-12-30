// <copyright file="Fields2.cs" company="APIMatic">
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
    /// Fields2.
    /// </summary>
    public class Fields2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fields2"/> class.
        /// </summary>
        public Fields2()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Fields2"/> class.
        /// </summary>
        /// <param name="fontFamilyURL1">fontFamilyURL1.</param>
        /// <param name="secondaryButtonTextColor">secondaryButtonTextColor.</param>
        /// <param name="fontFamilyURL3">fontFamilyURL3.</param>
        /// <param name="pageTitle">pageTitle.</param>
        /// <param name="fontFamilyURL2">fontFamilyURL2.</param>
        /// <param name="pageTextColor">pageTextColor.</param>
        /// <param name="barcodeHeight">barcodeHeight.</param>
        /// <param name="imageHeaderUrl">imageHeaderUrl.</param>
        /// <param name="barcodeMargin">barcodeMargin.</param>
        /// <param name="logoLink">logoLink.</param>
        /// <param name="primaryButtonLink">primaryButtonLink.</param>
        /// <param name="primaryButtonBackgroundColor">primaryButtonBackgroundColor.</param>
        /// <param name="secondaryButtonLink">secondaryButtonLink.</param>
        /// <param name="barcodeWidth">barcodeWidth.</param>
        /// <param name="primaryButtonText">primaryButtonText.</param>
        /// <param name="headline">headline.</param>
        /// <param name="headlineColor">headlineColor.</param>
        /// <param name="pageText">pageText.</param>
        /// <param name="secondaryButtonBackgroundColor">secondaryButtonBackgroundColor.</param>
        /// <param name="imageLinkPreviewUrl">imageLinkPreviewUrl.</param>
        /// <param name="pageTextFontFamily">pageTextFontFamily.</param>
        /// <param name="secondaryButtonText">secondaryButtonText.</param>
        /// <param name="headlineFontFamily">headlineFontFamily.</param>
        /// <param name="barcodeLineColor">barcodeLineColor.</param>
        /// <param name="barcodeValue">barcodeValue.</param>
        /// <param name="primaryButtonTextColor">primaryButtonTextColor.</param>
        /// <param name="imageLogoUrl">imageLogoUrl.</param>
        /// <param name="barcodeDisplayValue">barcodeDisplayValue.</param>
        /// <param name="buttonFontFamily">buttonFontFamily.</param>
        public Fields2(
            Models.FontFamilyURL1 fontFamilyURL1,
            Models.SecondaryButtonTextColor secondaryButtonTextColor,
            Models.FontFamilyURL1 fontFamilyURL3,
            Models.PageTitle pageTitle,
            Models.FontFamilyURL1 fontFamilyURL2,
            Models.PageTextColor pageTextColor,
            Models.BarcodeHeight barcodeHeight,
            Models.ImageHeaderUrl imageHeaderUrl,
            Models.BarcodeMargin barcodeMargin,
            Models.LogoLink logoLink,
            Models.PrimaryButtonLink primaryButtonLink,
            Models.PrimaryButtonBackgroundColor primaryButtonBackgroundColor,
            Models.SecondaryButtonLink secondaryButtonLink,
            Models.BarcodeWidth barcodeWidth,
            Models.PrimaryButtonText primaryButtonText,
            Models.Headline headline,
            Models.HeadlineColor headlineColor,
            Models.PageText pageText,
            Models.SecondaryButtonBackgroundColor secondaryButtonBackgroundColor,
            Models.ImageLinkPreviewUrl imageLinkPreviewUrl,
            Models.PageTextFontFamily pageTextFontFamily,
            Models.SecondaryButtonText secondaryButtonText,
            Models.HeadlineFontFamily headlineFontFamily,
            Models.BarcodeLineColor barcodeLineColor,
            Models.BarcodeValue barcodeValue,
            Models.PrimaryButtonTextColor primaryButtonTextColor,
            Models.ImageLogoUrl imageLogoUrl,
            Models.BarcodeDisplayValue barcodeDisplayValue,
            Models.ButtonFontFamily buttonFontFamily)
        {
            this.FontFamilyURL1 = fontFamilyURL1;
            this.SecondaryButtonTextColor = secondaryButtonTextColor;
            this.FontFamilyURL3 = fontFamilyURL3;
            this.PageTitle = pageTitle;
            this.FontFamilyURL2 = fontFamilyURL2;
            this.PageTextColor = pageTextColor;
            this.BarcodeHeight = barcodeHeight;
            this.ImageHeaderUrl = imageHeaderUrl;
            this.BarcodeMargin = barcodeMargin;
            this.LogoLink = logoLink;
            this.PrimaryButtonLink = primaryButtonLink;
            this.PrimaryButtonBackgroundColor = primaryButtonBackgroundColor;
            this.SecondaryButtonLink = secondaryButtonLink;
            this.BarcodeWidth = barcodeWidth;
            this.PrimaryButtonText = primaryButtonText;
            this.Headline = headline;
            this.HeadlineColor = headlineColor;
            this.PageText = pageText;
            this.SecondaryButtonBackgroundColor = secondaryButtonBackgroundColor;
            this.ImageLinkPreviewUrl = imageLinkPreviewUrl;
            this.PageTextFontFamily = pageTextFontFamily;
            this.SecondaryButtonText = secondaryButtonText;
            this.HeadlineFontFamily = headlineFontFamily;
            this.BarcodeLineColor = barcodeLineColor;
            this.BarcodeValue = barcodeValue;
            this.PrimaryButtonTextColor = primaryButtonTextColor;
            this.ImageLogoUrl = imageLogoUrl;
            this.BarcodeDisplayValue = barcodeDisplayValue;
            this.ButtonFontFamily = buttonFontFamily;
        }

        /// <summary>
        /// Gets or sets FontFamilyURL1.
        /// </summary>
        [JsonProperty("fontFamilyURL1")]
        public Models.FontFamilyURL1 FontFamilyURL1 { get; set; }

        /// <summary>
        /// Gets or sets SecondaryButtonTextColor.
        /// </summary>
        [JsonProperty("secondaryButtonTextColor")]
        public Models.SecondaryButtonTextColor SecondaryButtonTextColor { get; set; }

        /// <summary>
        /// Gets or sets FontFamilyURL3.
        /// </summary>
        [JsonProperty("fontFamilyURL3")]
        public Models.FontFamilyURL1 FontFamilyURL3 { get; set; }

        /// <summary>
        /// Gets or sets PageTitle.
        /// </summary>
        [JsonProperty("pageTitle")]
        public Models.PageTitle PageTitle { get; set; }

        /// <summary>
        /// Gets or sets FontFamilyURL2.
        /// </summary>
        [JsonProperty("fontFamilyURL2")]
        public Models.FontFamilyURL1 FontFamilyURL2 { get; set; }

        /// <summary>
        /// Gets or sets PageTextColor.
        /// </summary>
        [JsonProperty("pageTextColor")]
        public Models.PageTextColor PageTextColor { get; set; }

        /// <summary>
        /// Gets or sets BarcodeHeight.
        /// </summary>
        [JsonProperty("barcodeHeight")]
        public Models.BarcodeHeight BarcodeHeight { get; set; }

        /// <summary>
        /// Gets or sets ImageHeaderUrl.
        /// </summary>
        [JsonProperty("imageHeaderUrl")]
        public Models.ImageHeaderUrl ImageHeaderUrl { get; set; }

        /// <summary>
        /// Gets or sets BarcodeMargin.
        /// </summary>
        [JsonProperty("barcodeMargin")]
        public Models.BarcodeMargin BarcodeMargin { get; set; }

        /// <summary>
        /// Gets or sets LogoLink.
        /// </summary>
        [JsonProperty("logoLink")]
        public Models.LogoLink LogoLink { get; set; }

        /// <summary>
        /// Gets or sets PrimaryButtonLink.
        /// </summary>
        [JsonProperty("primaryButtonLink")]
        public Models.PrimaryButtonLink PrimaryButtonLink { get; set; }

        /// <summary>
        /// Gets or sets PrimaryButtonBackgroundColor.
        /// </summary>
        [JsonProperty("primaryButtonBackgroundColor")]
        public Models.PrimaryButtonBackgroundColor PrimaryButtonBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets SecondaryButtonLink.
        /// </summary>
        [JsonProperty("secondaryButtonLink")]
        public Models.SecondaryButtonLink SecondaryButtonLink { get; set; }

        /// <summary>
        /// Gets or sets BarcodeWidth.
        /// </summary>
        [JsonProperty("barcodeWidth")]
        public Models.BarcodeWidth BarcodeWidth { get; set; }

        /// <summary>
        /// Gets or sets PrimaryButtonText.
        /// </summary>
        [JsonProperty("primaryButtonText")]
        public Models.PrimaryButtonText PrimaryButtonText { get; set; }

        /// <summary>
        /// Gets or sets Headline.
        /// </summary>
        [JsonProperty("headline")]
        public Models.Headline Headline { get; set; }

        /// <summary>
        /// Gets or sets HeadlineColor.
        /// </summary>
        [JsonProperty("headlineColor")]
        public Models.HeadlineColor HeadlineColor { get; set; }

        /// <summary>
        /// Gets or sets PageText.
        /// </summary>
        [JsonProperty("pageText")]
        public Models.PageText PageText { get; set; }

        /// <summary>
        /// Gets or sets SecondaryButtonBackgroundColor.
        /// </summary>
        [JsonProperty("secondaryButtonBackgroundColor")]
        public Models.SecondaryButtonBackgroundColor SecondaryButtonBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets ImageLinkPreviewUrl.
        /// </summary>
        [JsonProperty("imageLinkPreviewUrl")]
        public Models.ImageLinkPreviewUrl ImageLinkPreviewUrl { get; set; }

        /// <summary>
        /// Gets or sets PageTextFontFamily.
        /// </summary>
        [JsonProperty("pageTextFontFamily")]
        public Models.PageTextFontFamily PageTextFontFamily { get; set; }

        /// <summary>
        /// Gets or sets SecondaryButtonText.
        /// </summary>
        [JsonProperty("secondaryButtonText")]
        public Models.SecondaryButtonText SecondaryButtonText { get; set; }

        /// <summary>
        /// Gets or sets HeadlineFontFamily.
        /// </summary>
        [JsonProperty("headlineFontFamily")]
        public Models.HeadlineFontFamily HeadlineFontFamily { get; set; }

        /// <summary>
        /// Gets or sets BarcodeLineColor.
        /// </summary>
        [JsonProperty("barcodeLineColor")]
        public Models.BarcodeLineColor BarcodeLineColor { get; set; }

        /// <summary>
        /// Gets or sets BarcodeValue.
        /// </summary>
        [JsonProperty("barcodeValue")]
        public Models.BarcodeValue BarcodeValue { get; set; }

        /// <summary>
        /// Gets or sets PrimaryButtonTextColor.
        /// </summary>
        [JsonProperty("primaryButtonTextColor")]
        public Models.PrimaryButtonTextColor PrimaryButtonTextColor { get; set; }

        /// <summary>
        /// Gets or sets ImageLogoUrl.
        /// </summary>
        [JsonProperty("imageLogoUrl")]
        public Models.ImageLogoUrl ImageLogoUrl { get; set; }

        /// <summary>
        /// Gets or sets BarcodeDisplayValue.
        /// </summary>
        [JsonProperty("barcodeDisplayValue")]
        public Models.BarcodeDisplayValue BarcodeDisplayValue { get; set; }

        /// <summary>
        /// Gets or sets ButtonFontFamily.
        /// </summary>
        [JsonProperty("buttonFontFamily")]
        public Models.ButtonFontFamily ButtonFontFamily { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Fields2 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Fields2 other &&
                ((this.FontFamilyURL1 == null && other.FontFamilyURL1 == null) || (this.FontFamilyURL1?.Equals(other.FontFamilyURL1) == true)) &&
                ((this.SecondaryButtonTextColor == null && other.SecondaryButtonTextColor == null) || (this.SecondaryButtonTextColor?.Equals(other.SecondaryButtonTextColor) == true)) &&
                ((this.FontFamilyURL3 == null && other.FontFamilyURL3 == null) || (this.FontFamilyURL3?.Equals(other.FontFamilyURL3) == true)) &&
                ((this.PageTitle == null && other.PageTitle == null) || (this.PageTitle?.Equals(other.PageTitle) == true)) &&
                ((this.FontFamilyURL2 == null && other.FontFamilyURL2 == null) || (this.FontFamilyURL2?.Equals(other.FontFamilyURL2) == true)) &&
                ((this.PageTextColor == null && other.PageTextColor == null) || (this.PageTextColor?.Equals(other.PageTextColor) == true)) &&
                ((this.BarcodeHeight == null && other.BarcodeHeight == null) || (this.BarcodeHeight?.Equals(other.BarcodeHeight) == true)) &&
                ((this.ImageHeaderUrl == null && other.ImageHeaderUrl == null) || (this.ImageHeaderUrl?.Equals(other.ImageHeaderUrl) == true)) &&
                ((this.BarcodeMargin == null && other.BarcodeMargin == null) || (this.BarcodeMargin?.Equals(other.BarcodeMargin) == true)) &&
                ((this.LogoLink == null && other.LogoLink == null) || (this.LogoLink?.Equals(other.LogoLink) == true)) &&
                ((this.PrimaryButtonLink == null && other.PrimaryButtonLink == null) || (this.PrimaryButtonLink?.Equals(other.PrimaryButtonLink) == true)) &&
                ((this.PrimaryButtonBackgroundColor == null && other.PrimaryButtonBackgroundColor == null) || (this.PrimaryButtonBackgroundColor?.Equals(other.PrimaryButtonBackgroundColor) == true)) &&
                ((this.SecondaryButtonLink == null && other.SecondaryButtonLink == null) || (this.SecondaryButtonLink?.Equals(other.SecondaryButtonLink) == true)) &&
                ((this.BarcodeWidth == null && other.BarcodeWidth == null) || (this.BarcodeWidth?.Equals(other.BarcodeWidth) == true)) &&
                ((this.PrimaryButtonText == null && other.PrimaryButtonText == null) || (this.PrimaryButtonText?.Equals(other.PrimaryButtonText) == true)) &&
                ((this.Headline == null && other.Headline == null) || (this.Headline?.Equals(other.Headline) == true)) &&
                ((this.HeadlineColor == null && other.HeadlineColor == null) || (this.HeadlineColor?.Equals(other.HeadlineColor) == true)) &&
                ((this.PageText == null && other.PageText == null) || (this.PageText?.Equals(other.PageText) == true)) &&
                ((this.SecondaryButtonBackgroundColor == null && other.SecondaryButtonBackgroundColor == null) || (this.SecondaryButtonBackgroundColor?.Equals(other.SecondaryButtonBackgroundColor) == true)) &&
                ((this.ImageLinkPreviewUrl == null && other.ImageLinkPreviewUrl == null) || (this.ImageLinkPreviewUrl?.Equals(other.ImageLinkPreviewUrl) == true)) &&
                ((this.PageTextFontFamily == null && other.PageTextFontFamily == null) || (this.PageTextFontFamily?.Equals(other.PageTextFontFamily) == true)) &&
                ((this.SecondaryButtonText == null && other.SecondaryButtonText == null) || (this.SecondaryButtonText?.Equals(other.SecondaryButtonText) == true)) &&
                ((this.HeadlineFontFamily == null && other.HeadlineFontFamily == null) || (this.HeadlineFontFamily?.Equals(other.HeadlineFontFamily) == true)) &&
                ((this.BarcodeLineColor == null && other.BarcodeLineColor == null) || (this.BarcodeLineColor?.Equals(other.BarcodeLineColor) == true)) &&
                ((this.BarcodeValue == null && other.BarcodeValue == null) || (this.BarcodeValue?.Equals(other.BarcodeValue) == true)) &&
                ((this.PrimaryButtonTextColor == null && other.PrimaryButtonTextColor == null) || (this.PrimaryButtonTextColor?.Equals(other.PrimaryButtonTextColor) == true)) &&
                ((this.ImageLogoUrl == null && other.ImageLogoUrl == null) || (this.ImageLogoUrl?.Equals(other.ImageLogoUrl) == true)) &&
                ((this.BarcodeDisplayValue == null && other.BarcodeDisplayValue == null) || (this.BarcodeDisplayValue?.Equals(other.BarcodeDisplayValue) == true)) &&
                ((this.ButtonFontFamily == null && other.ButtonFontFamily == null) || (this.ButtonFontFamily?.Equals(other.ButtonFontFamily) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.FontFamilyURL1 = {(this.FontFamilyURL1 == null ? "null" : this.FontFamilyURL1.ToString())}");
            toStringOutput.Add($"this.SecondaryButtonTextColor = {(this.SecondaryButtonTextColor == null ? "null" : this.SecondaryButtonTextColor.ToString())}");
            toStringOutput.Add($"this.FontFamilyURL3 = {(this.FontFamilyURL3 == null ? "null" : this.FontFamilyURL3.ToString())}");
            toStringOutput.Add($"this.PageTitle = {(this.PageTitle == null ? "null" : this.PageTitle.ToString())}");
            toStringOutput.Add($"this.FontFamilyURL2 = {(this.FontFamilyURL2 == null ? "null" : this.FontFamilyURL2.ToString())}");
            toStringOutput.Add($"this.PageTextColor = {(this.PageTextColor == null ? "null" : this.PageTextColor.ToString())}");
            toStringOutput.Add($"this.BarcodeHeight = {(this.BarcodeHeight == null ? "null" : this.BarcodeHeight.ToString())}");
            toStringOutput.Add($"this.ImageHeaderUrl = {(this.ImageHeaderUrl == null ? "null" : this.ImageHeaderUrl.ToString())}");
            toStringOutput.Add($"this.BarcodeMargin = {(this.BarcodeMargin == null ? "null" : this.BarcodeMargin.ToString())}");
            toStringOutput.Add($"this.LogoLink = {(this.LogoLink == null ? "null" : this.LogoLink.ToString())}");
            toStringOutput.Add($"this.PrimaryButtonLink = {(this.PrimaryButtonLink == null ? "null" : this.PrimaryButtonLink.ToString())}");
            toStringOutput.Add($"this.PrimaryButtonBackgroundColor = {(this.PrimaryButtonBackgroundColor == null ? "null" : this.PrimaryButtonBackgroundColor.ToString())}");
            toStringOutput.Add($"this.SecondaryButtonLink = {(this.SecondaryButtonLink == null ? "null" : this.SecondaryButtonLink.ToString())}");
            toStringOutput.Add($"this.BarcodeWidth = {(this.BarcodeWidth == null ? "null" : this.BarcodeWidth.ToString())}");
            toStringOutput.Add($"this.PrimaryButtonText = {(this.PrimaryButtonText == null ? "null" : this.PrimaryButtonText.ToString())}");
            toStringOutput.Add($"this.Headline = {(this.Headline == null ? "null" : this.Headline.ToString())}");
            toStringOutput.Add($"this.HeadlineColor = {(this.HeadlineColor == null ? "null" : this.HeadlineColor.ToString())}");
            toStringOutput.Add($"this.PageText = {(this.PageText == null ? "null" : this.PageText.ToString())}");
            toStringOutput.Add($"this.SecondaryButtonBackgroundColor = {(this.SecondaryButtonBackgroundColor == null ? "null" : this.SecondaryButtonBackgroundColor.ToString())}");
            toStringOutput.Add($"this.ImageLinkPreviewUrl = {(this.ImageLinkPreviewUrl == null ? "null" : this.ImageLinkPreviewUrl.ToString())}");
            toStringOutput.Add($"this.PageTextFontFamily = {(this.PageTextFontFamily == null ? "null" : this.PageTextFontFamily.ToString())}");
            toStringOutput.Add($"this.SecondaryButtonText = {(this.SecondaryButtonText == null ? "null" : this.SecondaryButtonText.ToString())}");
            toStringOutput.Add($"this.HeadlineFontFamily = {(this.HeadlineFontFamily == null ? "null" : this.HeadlineFontFamily.ToString())}");
            toStringOutput.Add($"this.BarcodeLineColor = {(this.BarcodeLineColor == null ? "null" : this.BarcodeLineColor.ToString())}");
            toStringOutput.Add($"this.BarcodeValue = {(this.BarcodeValue == null ? "null" : this.BarcodeValue.ToString())}");
            toStringOutput.Add($"this.PrimaryButtonTextColor = {(this.PrimaryButtonTextColor == null ? "null" : this.PrimaryButtonTextColor.ToString())}");
            toStringOutput.Add($"this.ImageLogoUrl = {(this.ImageLogoUrl == null ? "null" : this.ImageLogoUrl.ToString())}");
            toStringOutput.Add($"this.BarcodeDisplayValue = {(this.BarcodeDisplayValue == null ? "null" : this.BarcodeDisplayValue.ToString())}");
            toStringOutput.Add($"this.ButtonFontFamily = {(this.ButtonFontFamily == null ? "null" : this.ButtonFontFamily.ToString())}");
        }
    }
}