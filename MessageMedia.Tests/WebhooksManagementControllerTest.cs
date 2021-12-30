// <copyright file="WebhooksManagementControllerTest.cs" company="APIMatic">
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
    /// WebhooksManagementControllerTest.
    /// </summary>
    [TestFixture]
    public class WebhooksManagementControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private WebhooksManagementController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.WebhooksManagementController;
        }

        /// <summary>
        /// Retrieve all the webhooks created for the connected account..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRetrieveWebhook()
        {
            // Parameters for the API call
            int? page = null;
            int? pageSize = null;

            // Perform API call
            object result = null;
            try
            {
                result = await this.controller.RetrieveWebhookAsync(page, pageSize);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

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
        /// Create a webhook for one or more of the specified events..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCreateWebhook()
        {
            // Parameters for the API call
            Standard.Models.CreateWebhookrequest body = ApiHelper.JsonDeserialize<Standard.Models.CreateWebhookrequest>("{\"url\":\"http://webhook.com\",\"method\":\"POST\",\"encoding\":\"JSON\",\"headers\":{\"Account\":\"DeveloperPortal7000\"},\"events\":[\"ENROUTE_DR\"],\"template\":\"{\\\"id\\\":\\\"$mtId\\\",\\\"status\\\":\\\"$statusCode\\\"}\"}");

            // Perform API call
            object result = null;
            try
            {
                result = await this.controller.CreateWebhookAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(201, this.HttpCallBackHandler.Response.StatusCode, "Status should be 201");

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
        /// Delete a webhook that was previously created for the connected account.
        ///A webhook can be cancelled by appending the UUID of the webhook to the endpoint and submitting a DELETE request to the /webhooks/messages endpoint..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeleteWebhook()
        {
            // Parameters for the API call
            Guid webhookId = Guid.Parse("a7f11bb0-f299-4861-a5ca-9b29d04bc5ad");

            // Perform API call
            try
            {
                await this.controller.DeleteWebhookAsync(webhookId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, this.HttpCallBackHandler.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Update a webhook. You can update individual attributes or all of them by submitting a PATCH request to the /webhooks/messages endpoint (the same endpoint used above to delete a webhook).
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestUpdateWebhook()
        {
            // Parameters for the API call
            Guid webhookId = Guid.Parse("a7f11bb0-f299-4861-a5ca-9b29d04bc5ad");
            Standard.Models.UpdateWebhookrequest body = ApiHelper.JsonDeserialize<Standard.Models.UpdateWebhookrequest>("{\"url\":\"https://myurl.com\",\"method\":\"POST\",\"encoding\":\"FORM_ENCODED\",\"events\":[\"ENROUTE_DR\"],\"template\":\"{\\\"id\\\":\\\"$mtId\\\", \\\"status\\\":\\\"$statusCode\\\"}\"}");

            // Perform API call
            object result = null;
            try
            {
                result = await this.controller.UpdateWebhookAsync(webhookId, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

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