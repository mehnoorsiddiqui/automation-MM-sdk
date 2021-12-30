// <copyright file="MobileLandingPagesBetaControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace MessageMedia.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using MessageMedia.Standard;
    using MessageMedia.Standard.Controllers;
    using MessageMedia.Standard.Exceptions;
    using MessageMedia.Standard.Http.Client;
    using MessageMedia.Standard.Http.Response;
    using MessageMedia.Standard.Utilities;
    using MessageMedia.Tests.Helpers;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;

    /// <summary>
    /// MobileLandingPagesBetaControllerTest.
    /// </summary>
    [TestFixture]
    public class MobileLandingPagesBetaControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private MobileLandingPagesBetaController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.MobileLandingPagesBetaController;
        }

        /// <summary>
        /// Mobile Landing Pages Campaigns belonging to the user.Create a new campaign..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCreateNewCampaign()
        {
            // Parameters for the API call
            Standard.Models.BetaSmsplusCampaignsRequest body = null;

            // Perform API call
            Standard.Models.CreateNewCampaignresponse result = null;
            try
            {
                result = await this.controller.CreateNewCampaignAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(201, this.HttpCallBackHandler.Response.StatusCode, "Status should be 201");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"id\":\"null\",\"template_id\":\"null\",\"parameters\":{\"title\":\"This is a title\",\"bodyText\":\"This is some body text\",\"callToAction\":\"http://www.example.com/\"},\"message\":{\"callback_url\":\"https://my.url.com\",\"content\":\"Hello world!\",\"destination_number\":\"+61491570156\",\"delivery_report\":false,\"format\":\"SMS\",\"message_expiry_timestamp\":\"2016-11-03T11:49:02.000+00:00\",\"metadata\":{},\"scheduled\":\"2016-11-03T11:49:02.000+00:00\",\"source_number\":\"+61491570156\",\"source_number_type\":\"INTERNATIONAL\",\"message_id\":\"d7d9d9fd-478f-40e6-b651-49b7f19878a2\",\"status\":\"enroute\",\"media\":[\"https://images.pexels.com/photos/1018350/pexels-photo-1018350.jpeg?cs=srgb&dl=architecture-buildings-city-1018350.jpg\"],\"subject\":\"string\"}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// The Landing Page datastore makes it easier to create Campiangs based on the saved data.Create a Landing Page..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCreateaLandingPage()
        {
            // Parameters for the API call
            Standard.Models.BetaSmsplusLandingPagesRequest body = null;

            // Perform API call
            Standard.Models.CreateaLandingPageresponse result = null;
            try
            {
                result = await this.controller.CreateaLandingPageAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(201, this.HttpCallBackHandler.Response.StatusCode, "Status should be 201");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"id\":\"a94041bb-704b-48fa-ba0b-6f1538fc502f\",\"name\":\" My Landing Page\",\"template_id\":\"ac895f01-3149-4bf8-a8fe-01d3b8a9ba97\",\"parameters\":{\"title\":\"This is a ${title}\",\"bodyText\":\"This is some ${bodyText}\",\"callToAction\":\"${ctaUrl}\"},\"fields\":{\"title\":{\"type\":\"TEXT\"},\"bodyText\":{\"type\":\"TEXT\"},\"ctaUrl\":{\"type\":\"URL\"}},\"created_timestamp\":\"2019-11-03T11:49:02.807Z\",\"modified_timestamp\":\"2019-11-03T11:49:02.807Z\"}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// The Landing Page datastore makes it easier to create Campiangs based on the saved data.Returns a paginated list of Landing Pages for your account. ```sort_by``` and ```sort_direction``` must both be specified or neither at all (the default sort options are ```DESCENDING``` ```MODIFIED_TIMESTAMP```)..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetLandingPages()
        {
            // Parameters for the API call
            string pageSize = null;
            string pageToken = null;
            string sortBy = null;
            string sortDirection = null;

            // Perform API call
            object result = null;
            try
            {
                result = await this.controller.GetLandingPagesAsync(pageSize, pageToken, sortBy, sortDirection);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Returns a paginated list of Template..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetTemplates()
        {
            // Parameters for the API call
            string pageSize = null;
            string pageToken = null;

            // Perform API call
            Standard.Models.GetTemplatesresponse result = null;
            try
            {
                result = await this.controller.GetTemplatesAsync(pageSize, pageToken);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }
    }
}