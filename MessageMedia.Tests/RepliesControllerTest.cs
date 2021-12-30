// <copyright file="RepliesControllerTest.cs" company="APIMatic">
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
    /// RepliesControllerTest.
    /// </summary>
    [TestFixture]
    public class RepliesControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private RepliesController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.RepliesController;
        }

        /// <summary>
        /// Mark a reply message as confirmed so it is no longer returned in check replies requests..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestConfirmRepliesAsReceived()
        {
            // Parameters for the API call
            Standard.Models.Confirmrepliesasreceivedrequest body = ApiHelper.JsonDeserialize<Standard.Models.Confirmrepliesasreceivedrequest>("{\"reply_ids\":[\"011dcead-6988-4ad6-a1c7-6b6c68ea628d\",\"3487b3fa-6586-4979-a233-2d1b095c7718\"]}");

            // Perform API call
            object result = null;
            try
            {
                result = await this.controller.ConfirmRepliesAsReceivedAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(202, this.HttpCallBackHandler.Response.StatusCode, "Status should be 202");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "text/plain");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Check for any replies that have been received.
        ///
        ///*Note: It is recommended to use the Webhooks feature to receive reply messages rather than polling
        ///the check replies endpoint.*.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCheckReplies()
        {
            // Perform API call
            Standard.Models.Checkrepliesresponse result = null;
            try
            {
                result = await this.controller.CheckRepliesAsync();
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
                    "{\"replies\":[{\"metadata\":{\"key1\":\"value1\",\"key2\":\"value2\"},\"message_id\":\"877c19ef-fa2e-4cec-827a-e1df9b5509f7\",\"reply_id\":\"a175e797-2b54-468b-9850-41a3eab32f74\",\"date_received\":\"2016-12-07T08:43:00.850Z\",\"callback_url\":\"https://my.callback.url.com\",\"destination_number\":\"+61491570156\",\"source_number\":\"+61491570157\",\"vendor_account_id\":{\"vendor_id\":\"MessageMedia\",\"account_id\":\"MyAccount\"},\"content\":\"My first reply!\"},{\"metadata\":{\"key1\":\"value1\",\"key2\":\"value2\"},\"message_id\":\"8f2f5927-2e16-4f1c-bd43-47dbe2a77ae4\",\"reply_id\":\"3d8d53d8-01d3-45dd-8cfa-4dfc81600f7f\",\"date_received\":\"2016-12-07T08:43:00.850Z\",\"callback_url\":\"https://my.callback.url.com\",\"destination_number\":\"+61491570157\",\"source_number\":\"+61491570158\",\"vendor_account_id\":{\"vendor_id\":\"MessageMedia\",\"account_id\":\"MyAccount\"},\"content\":\"My second reply!\"}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}