// <copyright file="DeliveryReportsControllerTest.cs" company="APIMatic">
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
    /// DeliveryReportsControllerTest.
    /// </summary>
    [TestFixture]
    public class DeliveryReportsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private DeliveryReportsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.DeliveryReportsController;
        }

        /// <summary>
        /// Check for any delivery reports that have been received.
        ///Delivery reports are a notification of the change in status of a message as it is being processed..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCheckDeliveryReports()
        {
            // Perform API call
            Standard.Models.Checkdeliveryreportsresponse result = null;
            try
            {
                result = await this.controller.CheckDeliveryReportsAsync();
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
                    "{\"delivery_reports\":[{\"callback_url\":\"https://my.callback.url.com\",\"delivery_report_id\":\"01e1fa0a-6e27-4945-9cdb-18644b4de043\",\"source_number\":\"+61491570157\",\"date_received\":\"2017-05-20T06:30:37.642Z\",\"status\":\"enroute\",\"delay\":0,\"submitted_date\":\"2017-05-20T06:30:37.639Z\",\"original_text\":\"My first message!\",\"message_id\":\"d781dcab-d9d8-4fb2-9e03-872f07ae94ba\",\"vendor_account_id\":{\"vendor_id\":\"MessageMedia\",\"account_id\":\"MyAccount\"},\"metadata\":{\"key1\":\"value1\",\"key2\":\"value2\"}},{\"callback_url\":\"https://my.callback.url.com\",\"delivery_report_id\":\"0edf9022-7ccc-43e6-acab-480e93e98c1b\",\"source_number\":\"+61491570158\",\"date_received\":\"2017-05-21T01:46:42.579Z\",\"status\":\"submitted\",\"delay\":0,\"submitted_date\":\"2017-05-21T01:46:42.574Z\",\"original_text\":\"My second message!\",\"message_id\":\"fbb3b3f5-b702-4d8b-ab44-65b2ee39a281\",\"vendor_account_id\":{\"vendor_id\":\"MessageMedia\",\"account_id\":\"MyAccount\"},\"metadata\":{\"key1\":\"value1\",\"key2\":\"value2\"}}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Mark a delivery report as confirmed so it is no longer return in check delivery reports requests..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestConfirmDeliveryReportsAsReceived()
        {
            // Parameters for the API call
            Standard.Models.Confirmeliveryreportsasreceivedrequest body = ApiHelper.JsonDeserialize<Standard.Models.Confirmeliveryreportsasreceivedrequest>("{\"delivery_report_ids\":[\"011dcead-6988-4ad6-a1c7-6b6c68ea628d\",\"3487b3fa-6586-4979-a233-2d1b095c7718\"]}");

            // Perform API call
            object result = null;
            try
            {
                result = await this.controller.ConfirmDeliveryReportsAsReceivedAsync(body);
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
    }
}