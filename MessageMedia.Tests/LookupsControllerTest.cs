// <copyright file="LookupsControllerTest.cs" company="APIMatic">
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
    /// LookupsControllerTest.
    /// </summary>
    [TestFixture]
    public class LookupsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private LookupsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.LookupsController;
        }

        /// <summary>
        /// Use the Lookups API to find information about a phone number..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestLookupAPhoneNumber()
        {
            // Parameters for the API call
            string phoneNumber = "61491570156";
            string options = "\"carrier,type\"";

            // Perform API call
            Standard.Models.Lookupaphonenumberresponse result = null;
            try
            {
                result = await this.controller.LookupAPhoneNumberAsync(phoneNumber, options);
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
                    "{\"country_code\":\"AU\",\"phone_number\":\"61491570156\",\"type\":\"mobile\",\"carrier\":{\"name\":\"Telstra\"}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}