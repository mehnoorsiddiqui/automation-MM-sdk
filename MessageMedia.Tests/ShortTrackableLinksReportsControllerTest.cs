// <copyright file="ShortTrackableLinksReportsControllerTest.cs" company="APIMatic">
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
    /// ShortTrackableLinksReportsControllerTest.
    /// </summary>
    [TestFixture]
    public class ShortTrackableLinksReportsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private ShortTrackableLinksReportsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.ShortTrackableLinksReportsController;
        }

        /// <summary>
        /// Clicks summary report for metadata key value pair, long url and short url..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestLogSummary()
        {
            // Parameters for the API call
            string key = null;
            string mValue = null;
            string url = null;
            string recipient = null;
            double? page = null;
            double? pageSize = null;

            // Perform API call
            Standard.Models.LogSummaryResult result = null;
            try
            {
                result = await this.controller.LogSummaryAsync(key, mValue, url, recipient, page, pageSize);
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

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"total_clicks\":3,\"unique_clicks\":1,\"total_views\":2,\"unique_views\":1,\"short_urls_generated\":1,\"short_urls\":[{\"click_count\":3,\"view_count\":2,\"message_id\":\"00000000-0000-0000-0000-000000000000\",\"long_url\":\"https://developers.messagemedia.com\",\"short_url\":\"https://nxt.to/abc1234\",\"destination_number\":\"61491570157\"}],\"pagination\":{\"page\":1,\"page_size\":100,\"page_count\":3}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}