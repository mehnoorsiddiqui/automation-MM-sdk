// <copyright file="MessagingReportsControllerTest.cs" company="APIMatic">
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
    /// MessagingReportsControllerTest.
    /// </summary>
    [TestFixture]
    public class MessagingReportsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private MessagingReportsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.MessagingReportsController;
        }

        /// <summary>
        /// Submits a request to generate an async detail report.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSubmitReceivedMessagesDetail()
        {
            // Parameters for the API call
            Standard.Models.Asyncreceivedmessagesdetailrequest body = ApiHelper.JsonDeserialize<Standard.Models.Asyncreceivedmessagesdetailrequest>("{\"sort_by\":\"ACCOUNT\",\"sort_direction\":\"ASCENDING\",\"period\":\"THIS_WEEK\"}");

            // Perform API call
            Standard.Models.AsyncReportResponse result = null;
            try
            {
                result = await this.controller.SubmitReceivedMessagesDetailAsync(body);
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
                    "{\"id\":\"b8ffd5b3-050a-46b9-9192-fbd7c20a22ec\"}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Returns a summarised report of messages received.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetReceivedMessagesSummary()
        {
            // Parameters for the API call
            string endDate = "2021-11-28T13:30:00.000";
            string startDate = "2021-11-11T13:30:00.000";
            Standard.Models.GroupByEnum groupBy = ApiHelper.JsonDeserialize<Standard.Models.GroupByEnum>("\"DAY\"");
            List<string> accounts = null;
            string destinationAddressCountry = null;
            string destinationAddress = null;
            Standard.Models.Format1Enum messageFormat = ApiHelper.JsonDeserialize<Standard.Models.Format1Enum>("\"MMS\"");
            string metadataKey = null;
            string metadataValue = null;
            Standard.Models.SummaryByEnum summaryBy = ApiHelper.JsonDeserialize<Standard.Models.SummaryByEnum>("\"COUNT\"");
            Standard.Models.SummaryFieldEnum summaryField = ApiHelper.JsonDeserialize<Standard.Models.SummaryFieldEnum>("\"UNITS\"");
            string sourceAddressCountry = null;
            string sourceAddress = null;
            string timezone = null;

            // Perform API call
            Standard.Models.SummaryReport result = null;
            try
            {
                result = await this.controller.GetReceivedMessagesSummaryAsync(endDate, startDate, groupBy, accounts, destinationAddressCountry, destinationAddress, messageFormat, metadataKey, metadataValue, summaryBy, summaryField, sourceAddressCountry, sourceAddress, timezone);
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
                    "{\"properties\":{\"end_date\":\"2017-02-10T13:30:00.000Z\",\"start_date\":\"2017-02-12T13:30:00.000Z\",\"timezone\":\"The timezone that this report is presented in, this may be passed in as a parameter to the report, or taken from account settings\"},\"data\":[{}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Returns a list of message sent.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetSentMessagesDetail()
        {
            // Parameters for the API call
            string endDate = "2021-11-28T13:30:00.000";
            string startDate = "2021-11-12T13:30:00.000";
            List<string> accounts = null;
            bool? deliveryReport = null;
            string destinationAddressCountry = null;
            string destinationAddress = null;
            Standard.Models.Format1Enum messageFormat = ApiHelper.JsonDeserialize<Standard.Models.Format1Enum>("\"MMS\"");
            string metadataKey = null;
            string metadataValue = null;
            string statusCode = null;
            Standard.Models.Status1Enum status = ApiHelper.JsonDeserialize<Standard.Models.Status1Enum>("\"CANCELLED\"");
            Standard.Models.StatusesEnum statuses = ApiHelper.JsonDeserialize<Standard.Models.StatusesEnum>("\"CANCELLED\"");
            double? page = null;
            double? pageSize = null;
            Standard.Models.SortByEnum sortBy = ApiHelper.JsonDeserialize<Standard.Models.SortByEnum>("\"ACCOUNT\"");
            Standard.Models.SortDirectionEnum sortDirection = ApiHelper.JsonDeserialize<Standard.Models.SortDirectionEnum>("\"ASCENDING\"");
            string sourceAddressCountry = null;
            string sourceAddress = null;
            string timezone = null;

            // Perform API call
            Standard.Models.SentMessages result = null;
            try
            {
                result = await this.controller.GetSentMessagesDetailAsync(endDate, startDate, accounts, deliveryReport, destinationAddressCountry, destinationAddress, messageFormat, metadataKey, metadataValue, statusCode, status, statuses, page, pageSize, sortBy, sortDirection, sourceAddressCountry, sourceAddress, timezone);
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
        /// Submits a summarised report of sent messages.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSubmitSentMessagesSummary()
        {
            // Parameters for the API call
            Standard.Models.Asyncsentmessagesrequest body = ApiHelper.JsonDeserialize<Standard.Models.Asyncsentmessagesrequest>("{\"end_date\":\"2021-11-28T13:30:00.000\",\"start_date\":\"2021-11-12T13:30:00.000\",\"group_by\":[\"HOUR\"]}");

            // Perform API call
            Standard.Models.AsyncReportResponse result = null;
            try
            {
                result = await this.controller.SubmitSentMessagesSummaryAsync(body);
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
                    "{\"id\":\"b8ffd5b3-050a-46b9-9192-fbd7c20a22ec\"}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Returns a summarised report of messages sent.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetSentMessagesSummary()
        {
            // Parameters for the API call
            string endDate = "2021-11-28T13:30:00.000";
            string startDate = "2021-11-12T13:30:00.000";
            Standard.Models.GroupByEnum groupBy = ApiHelper.JsonDeserialize<Standard.Models.GroupByEnum>("\"DAY\"");
            List<string> accounts = null;
            bool? deliveryReport = null;
            string destinationAddressCountry = null;
            string destinationAddress = null;
            Standard.Models.SummaryByEnum summaryBy = ApiHelper.JsonDeserialize<Standard.Models.SummaryByEnum>("\"COUNT\"");
            Standard.Models.SummaryFieldEnum summaryField = ApiHelper.JsonDeserialize<Standard.Models.SummaryFieldEnum>("\"UNITS\"");
            Standard.Models.Format1Enum messageFormat = ApiHelper.JsonDeserialize<Standard.Models.Format1Enum>("\"MMS\"");
            string metadataKey = null;
            string metadataValue = null;
            string statusCode = null;
            string sourceAddressCountry = null;
            string sourceAddress = null;
            string timezone = null;

            // Perform API call
            Standard.Models.SummaryReport result = null;
            try
            {
                result = await this.controller.GetSentMessagesSummaryAsync(endDate, startDate, groupBy, accounts, deliveryReport, destinationAddressCountry, destinationAddress, summaryBy, summaryField, messageFormat, metadataKey, metadataValue, statusCode, sourceAddressCountry, sourceAddress, timezone);
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
                    "{\"properties\":{\"end_date\":\"2017-02-10T13:30:00.000Z\",\"start_date\":\"2017-02-12T13:30:00.000Z\",\"timezone\":\"The timezone that this report is presented in, this may be passed in as a parameter to the report, or taken from account settings\"},\"data\":[{}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Returns a list of metadata keys.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetMetadataKeys()
        {
            // Parameters for the API call
            Standard.Models.MessageTypeEnum messageType = ApiHelper.JsonDeserialize<Standard.Models.MessageTypeEnum>("\"SENT_MESSAGES\"");
            string startDate = "2017-02-10T13:30:00.000";
            string endDate = "2017-02-12T13:30:00.000";
            List<string> accounts = null;
            string timezone = null;

            // Perform API call
            Standard.Models.MetadataKeysResponse result = null;
            try
            {
                result = await this.controller.GetMetadataKeysAsync(messageType, startDate, endDate, accounts, timezone);
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
                    "{\"data\":[],\"properties\":{\"end_date\":\"2017-02-10T13:30:00.000Z\",\"start_date\":\"2017-02-12T13:30:00.000Z\",\"accounts\":[]}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Lists asynchronous reports..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAsyncReports()
        {
            // Parameters for the API call
            double? page = null;
            double? pageSize = null;

            // Perform API call
            Standard.Models.GetAsyncReportsResponse result = null;
            try
            {
                result = await this.controller.GetAsyncReportsAsync(page, pageSize);
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
                    "{\"data\":[{\"created_datetime\":\"2017-02-12T13:30:00.000Z\",\"last_modified_datetime\":\"2017-02-12T13:30:00.000Z\"}],\"pagination\":{}}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Returns a list message received.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetReceivedMessagesDetail()
        {
            // Parameters for the API call
            string endDate = "2021-11-28T13:30:00";
            string startDate = "2021-11-12T13:30:00";
            List<string> accounts = null;
            Standard.Models.ActionEnum action = ApiHelper.JsonDeserialize<Standard.Models.ActionEnum>("\"MyAccount001\"");
            string destinationAddressCountry = null;
            string destinationAddress = null;
            Standard.Models.Format1Enum messageFormat = ApiHelper.JsonDeserialize<Standard.Models.Format1Enum>("\"MMS\"");
            string metadataKey = null;
            string metadataValue = null;
            double? page = null;
            double? pageSize = null;
            Standard.Models.SortByEnum sortBy = ApiHelper.JsonDeserialize<Standard.Models.SortByEnum>("\"ACCOUNT\"");
            Standard.Models.SortDirectionEnum sortDirection = ApiHelper.JsonDeserialize<Standard.Models.SortDirectionEnum>("\"ASCENDING\"");
            string sourceAddressCountry = null;
            string sourceAddress = null;
            string timezone = null;

            // Perform API call
            Standard.Models.ReceivedMessages result = null;
            try
            {
                result = await this.controller.GetReceivedMessagesDetailAsync(endDate, startDate, accounts, action, destinationAddressCountry, destinationAddress, messageFormat, metadataKey, metadataValue, page, pageSize, sortBy, sortDirection, sourceAddressCountry, sourceAddress, timezone);
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
        /// Submits a request to generate an async detail report.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSubmitSentMessagesDetail()
        {
            // Parameters for the API call
            Standard.Models.Asyncsentmessagesdetailrequest body = ApiHelper.JsonDeserialize<Standard.Models.Asyncsentmessagesdetailrequest>("{\"end_date\":\"2017-02-10T13:30:00.000\",\"start_date\":\"2017-02-12T13:30:00.000\",\"sort_by\":\"ACCOUNT\",\"sort_direction\":\"ASCENDING\"}");

            // Perform API call
            Standard.Models.AsyncReportResponse result = null;
            try
            {
                result = await this.controller.SubmitSentMessagesDetailAsync(body);
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
                    "{\"id\":\"b8ffd5b3-050a-46b9-9192-fbd7c20a22ec\"}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Submits a summarised report of received messages.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSubmitReceivedMessagesSummary()
        {
            // Parameters for the API call
            Standard.Models.Asyncreceivedmessagessummaryrequest body = ApiHelper.JsonDeserialize<Standard.Models.Asyncreceivedmessagessummaryrequest>("{\"end_date\":\"2021-11-28T13:30:00.000\",\"start_date\":\"2021-11-12T13:30:00.000\",\"summary_by\":\"COUNT\",\"summary_field\":\"MESSAGE_ID\",\"group_by\":[\"DAY\"]}");

            // Perform API call
            Standard.Models.AsyncReportResponse result = null;
            try
            {
                result = await this.controller.SubmitReceivedMessagesSummaryAsync(body);
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
                    "{\"id\":\"b8ffd5b3-050a-46b9-9192-fbd7c20a22ec\"}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}