// <copyright file="DedicatedNumbersControllerTest.cs" company="APIMatic">
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
    /// DedicatedNumbersControllerTest.
    /// </summary>
    [TestFixture]
    public class DedicatedNumbersControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private DedicatedNumbersController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.DedicatedNumbersController;
        }

        /// <summary>
        /// Get details about a specific dedicated number..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetNumberById()
        {
            // Parameters for the API call
            string id = "e2014bc7-5fed-4e27-bd8c-XXXXXXXXXXX";
            string accept = "application/json;charset=UTF-8";

            // Perform API call
            object result = null;
            try
            {
                result = await this.controller.GetNumberByIdAsync(id, accept);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json;charset=UTF-8");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\r\n  \"id\": \"be3cb602-7c00-4c87-ae4b-b8defc04f179\",\r\n  \"phone_number\": 614111111111,\r\n  \"country\": \"AU\",\r\n  \"type\": \"MOBILE\",\r\n  \"classification\": \"SILVER\",\r\n  \"available_after\": \"2019-06-21T04:04:31.707Z\",\r\n  \"capabilities\": [\r\n    \"SMS\",\r\n    \"MMS\"\r\n  ]\r\n}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Use this endpoint to view details of the assignment including the label and metadata..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAssignment()
        {
            // Parameters for the API call
            string numberId = "e2014bc7-5fed-4e27-bd8c-XXXXXXXXXXX";
            string accept = "application/json;charset=UTF-8";

            // Perform API call
            Standard.Models.Assignment result = null;
            try
            {
                result = await this.controller.GetAssignmentAsync(numberId, accept);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json;charset=UTF-8");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"metadata\":{\"key1\":\"value1\"},\"label\":\"LabelTest0\",\"id\":\"be3cb602-7c00-4c87-ae4b-b8defc04f179\",\"number_id\":\"b9ee3fe8-2c20-47b1-96e9-c5d12d7ed985\"}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Assign the specified number to the authenticated account. 
        ///Use the body of the request to specify a label or metadata 
        ///for this number assignment.
        ///
        ///If you receive a *conflict* error then the number that you have selected is unavailable for assignment. 
        ///This means that the number is either already assigned to another account, 
        ///or has an available_after date in the future. Should this occur, perform 
        ///another search and select a different number..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCreateAssignment()
        {
            // Parameters for the API call
            string numberId = "e2014bc7-5fed-4e27-bd8c-XXXXXXXXXXX";
            string accept = "application/json;charset=UTF-8";
            Standard.Models.CreateAssignmentrequest body = ApiHelper.JsonDeserialize<Standard.Models.CreateAssignmentrequest>("{\"label\":\"ExampleLabel\",\"metadata\":{\"Key1\":\"value1\",\"Key2\":\"value2\"}}");

            // Perform API call
            Standard.Models.Assignment result = null;
            try
            {
                result = await this.controller.CreateAssignmentAsync(numberId, accept, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(201, this.HttpCallBackHandler.Response.StatusCode, "Status should be 201");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json;charset=UTF-8");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"label\":\"cillum irure\",\"number_id\":\"et pariatur\"}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Release the dedicated number from your account..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeleteAssignment()
        {
            // Parameters for the API call
            string numberId = "e2014bc7-5fed-4e27-bd8c-XXXXXXXXXXX";
            string accept = "application/json;charset=UTF-8";

            // Perform API call
            Stream result = null;
            try
            {
                result = await this.controller.DeleteAssignmentAsync(numberId, accept);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, this.HttpCallBackHandler.Response.StatusCode, "Status should be 204");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json;charset=UTF-8");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Get a list of available dedicated numbers, filtered by requirements..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetNumbers()
        {
            // Parameters for the API call
            string country = "AU";
            string matching = "223344";
            int? pageSize = 3;
            Standard.Models.ServiceTypesEnum serviceTypes = ApiHelper.JsonDeserialize<Standard.Models.ServiceTypesEnum>("\"SMS\"");
            string token = "example";

            // Perform API call
            Standard.Models.NumbersListResponse result = null;
            try
            {
                result = await this.controller.GetNumbersAsync(country, matching, pageSize, serviceTypes, token);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json;charset=UTF-8");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"pagination\":{\"next_token\":\"0428d673-0f75-4063-9493-e89d75f13438\",\"page_size\":5},\"data\":[{\"id\":\"03cf54ad-a4a3-4cd1-afd5-e0ca2cf158a3\",\"phone_number\":\"61436489205\",\"country\":\"AU\",\"type\":\"MOBILE\",\"classification\":\"BRONZE\",\"available_after\":\"2019-08-06T23:56:15.633Z\",\"capabilities\":[\"SMS\"]}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Get assigned numbers.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAssignedNumbers()
        {
            // Parameters for the API call
            string accept = "application/json;charset=UTF-8";
            int? pageSize = 3;
            string token = null;
            string numberId = null;
            string matching = "223344";
            string country = "AU";
            Standard.Models.Type1Enum type = ApiHelper.JsonDeserialize<Standard.Models.Type1Enum>("\"MOBILE\"");
            Standard.Models.ClassificationEnum classification = ApiHelper.JsonDeserialize<Standard.Models.ClassificationEnum>("\"BRONZE\"");
            Standard.Models.ServiceTypesEnum serviceTypes = ApiHelper.JsonDeserialize<Standard.Models.ServiceTypesEnum>("\"SMS\"");
            string label = null;
            Standard.Models.SortByEnum sortBy = ApiHelper.JsonDeserialize<Standard.Models.SortByEnum>("\"ACCOUNT\"");
            Standard.Models.SortDirectionEnum sortDirection = ApiHelper.JsonDeserialize<Standard.Models.SortDirectionEnum>("\"ASCENDING\"");

            // Perform API call
            Standard.Models.AssignedNumberListResponse result = null;
            try
            {
                result = await this.controller.GetAssignedNumbersAsync(accept, pageSize, token, numberId, matching, country, type, classification, serviceTypes, label, sortBy, sortDirection);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json;charset=UTF-8");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }
    }
}