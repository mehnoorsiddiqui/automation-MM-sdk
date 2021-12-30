// <copyright file="SignatureKeyManagementControllerTest.cs" company="APIMatic">
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
    /// SignatureKeyManagementControllerTest.
    /// </summary>
    [TestFixture]
    public class SignatureKeyManagementControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private SignatureKeyManagementController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.SignatureKeyManagementController;
        }

        /// <summary>
        /// This will create a key pair:
        ///The ```private key``` stored in MessageMedia is used to create the signature.
        ///The ```public key``` is returned and stored at your side to verify the signature in callbacks.
        ///
        ///You need to enable your signature key after creating.
        ///
        ///In the response body  ```enabled```  is false for the new signature key. You can use the ```enable signature key```  endpoint to set this field to true..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCreateSignatureKey()
        {
            // Parameters for the API call
            string accept = "application/json";
            Standard.Models.Createsignaturekeyrequest body = ApiHelper.JsonDeserialize<Standard.Models.Createsignaturekeyrequest>("{\"digest\":\"SHA224\",\"cipher\":\"RSA\"}");

            // Perform API call
            Standard.Models.Createsignaturekeyresponse result = null;
            try
            {
                result = await this.controller.CreateSignatureKeyAsync(accept, body);
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
                    "{\"key_id\":\"7ca628a8-08b0-4e42-aeb8-960b37049c31\",\"public_key\":\"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCTIxtRyT5CuOD74r7UCT+AKzWNxvaAP9myjAqR7+vBnJKEvoPnmbKTnm6uLlxutnMbjKrnCCWnQ9vtBVnnd+ElhwLDPADfMcJoOqwi7mTcxucckeEbBsfsgYRfdacxgSZL8hVD1hLViQr3xwjEIkJcx1w3x8npvwMuTY0uW8+PjwIDAQAB\",\"cipher\":\"RSA\",\"digest\":\"SHA224\",\"created\":\"2018-01-18T10:16:12.364Z\",\"enabled\":false}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Retrieve the currently enabled signature key..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetEnabledSignatureKey()
        {
            // Perform API call
            Standard.Models.Getenabledsignaturekeyresponse result = null;
            try
            {
                result = await this.controller.GetEnabledSignatureKeyAsync();
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
                    "{\"key_id\":\"7ca628a8-08b0-4e42-aeb8-960b37049c31\",\"cipher\":\"RSA\",\"digest\":\"SHA224\",\"created\":\"2018-01-18T10:16:12.364Z\",\"enabled\":true}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Enable a signature key using the key_id returned in the ```create signature key``` endpoint.
        ///
        ///There is only one signature key is enabled at the one moment in time. So if you enable the new signature key, the old one will be disabled..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestEnableSignatureKey()
        {
            // Parameters for the API call
            string accept = "application/json";
            Standard.Models.Enablesignaturekeyrequest body = ApiHelper.JsonDeserialize<Standard.Models.Enablesignaturekeyrequest>("{\"key_id\":\"7ca628a8-08b0-4e42-aeb8-960b37049c31\"}");

            // Perform API call
            Standard.Models.Enablesignaturekeyresponse result = null;
            try
            {
                result = await this.controller.EnableSignatureKeyAsync(accept, body);
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
                    "{\"key_id\":\"7ca628a8-08b0-4e42-aeb8-960b37049c31\",\"cipher\":\"RSA\",\"digest\":\"SHA224\",\"created\":\"2018-01-18T10:16:12.364Z\",\"enabled\":true}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Disable the current enabled signature key.
        ///
        ///A successful request will return no content when successful..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDisableTheCurrentEnabledSignatureKey()
        {
            // Perform API call
            try
            {
                await this.controller.DisableTheCurrentEnabledSignatureKeyAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, this.HttpCallBackHandler.Response.StatusCode, "Status should be 204");
        }
    }
}