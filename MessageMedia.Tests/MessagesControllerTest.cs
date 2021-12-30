// <copyright file="MessagesControllerTest.cs" company="APIMatic">
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
    /// MessagesControllerTest.
    /// </summary>
    [TestFixture]
    public class MessagesControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private MessagesController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.MessagesController;
        }

        /// <summary>
        /// Submit one or more (up to 100 per request) SMS, MMS or text to voice messages for delivery.
        ///
        ///*Note: when sending multiple messages in a request,if any message in the request is invalid, no message will be sent.*.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSendMessages()
        {
            // Parameters for the API call
            Standard.Models.Sendmessagesrequest body = ApiHelper.JsonDeserialize<Standard.Models.Sendmessagesrequest>("{\"messages\":[{\"content\":\"My first message\",\"destination_number\":\"+61491570156\",\"source_number\":\"+61491570157\"}]}");

            // Perform API call
            Standard.Models.Sendmessagesresponse result = null;
            try
            {
                result = await this.controller.SendMessagesAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(202, this.HttpCallBackHandler.Response.StatusCode, "Status should be 202");

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
                    "{\"messages\":[{\"callback_url\":\"https://my.url.com\",\"content\":\"Hello world!\",\"destination_number\":\"+61491570156\",\"delivery_report\":false,\"format\":\"SMS\",\"message_expiry_timestamp\":\"2016-11-03T11:49:02.000+00:00\",\"metadata\":{},\"scheduled\":\"2016-11-03T11:49:02.000+00:00\",\"source_number\":\"+61491570156\",\"source_number_type\":\"INTERNATIONAL\",\"message_id\":\"d7d9d9fd-478f-40e6-b651-49b7f19878a2\",\"status\":\"enroute\",\"media\":[\"https://images.pexels.com/photos/1018350/pexels-photo-1018350.jpeg?cs=srgb&dl=architecture-buildings-city-1018350.jpg\"],\"subject\":\"string\"}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}