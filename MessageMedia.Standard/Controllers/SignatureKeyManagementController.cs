// <copyright file="SignatureKeyManagementController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace MessageMedia.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using MessageMedia.Standard;
    using MessageMedia.Standard.Authentication;
    using MessageMedia.Standard.Exceptions;
    using MessageMedia.Standard.Http.Client;
    using MessageMedia.Standard.Http.Request;
    using MessageMedia.Standard.Http.Request.Configuration;
    using MessageMedia.Standard.Http.Response;
    using MessageMedia.Standard.Utilities;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// SignatureKeyManagementController.
    /// </summary>
    public class SignatureKeyManagementController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureKeyManagementController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal SignatureKeyManagementController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Retrieve the paginated list of signature keys.
        /// </summary>
        /// <param name="page">Required parameter: Example: .</param>
        /// <param name="pageSize">Required parameter: Example: .</param>
        /// <returns>Returns the List of Models.Getsignaturekeylistresponse response from the API call.</returns>
        public List<Models.Getsignaturekeylistresponse> GetSignatureKeyList(
                string page,
                string pageSize)
        {
            Task<List<Models.Getsignaturekeylistresponse>> t = this.GetSignatureKeyListAsync(page, pageSize);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve the paginated list of signature keys.
        /// </summary>
        /// <param name="page">Required parameter: Example: .</param>
        /// <param name="pageSize">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.Getsignaturekeylistresponse response from the API call.</returns>
        public async Task<List<Models.Getsignaturekeylistresponse>> GetSignatureKeyListAsync(
                string page,
                string pageSize,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/iam/signature_keys");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "page", page },
                { "page_size", pageSize },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new Enablesignaturekey400responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new Disablethecurrentenabledsignaturekey403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.Getsignaturekeylistresponse>>(response.Body);
        }

        /// <summary>
        /// This will create a key pair:.
        /// The ```private key``` stored in MessageMedia is used to create the signature.
        /// The ```public key``` is returned and stored at your side to verify the signature in callbacks.
        /// You need to enable your signature key after creating.
        /// In the response body  ```enabled```  is false for the new signature key. You can use the ```enable signature key```  endpoint to set this field to true.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.Createsignaturekeyresponse response from the API call.</returns>
        public Models.Createsignaturekeyresponse CreateSignatureKey(
                string accept,
                Models.Createsignaturekeyrequest body)
        {
            Task<Models.Createsignaturekeyresponse> t = this.CreateSignatureKeyAsync(accept, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This will create a key pair:.
        /// The ```private key``` stored in MessageMedia is used to create the signature.
        /// The ```public key``` is returned and stored at your side to verify the signature in callbacks.
        /// You need to enable your signature key after creating.
        /// In the response body  ```enabled```  is false for the new signature key. You can use the ```enable signature key```  endpoint to set this field to true.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Createsignaturekeyresponse response from the API call.</returns>
        public async Task<Models.Createsignaturekeyresponse> CreateSignatureKeyAsync(
                string accept,
                Models.Createsignaturekeyrequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/iam/signature_keys");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new Enablesignaturekey400responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new Disablethecurrentenabledsignaturekey403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Createsignaturekeyresponse>(response.Body);
        }

        /// <summary>
        /// Retrieve the current detail of a signature key using the key_id returned in the ```create signature key``` endpoint.
        /// </summary>
        /// <param name="keyId">Required parameter: Example: .</param>
        /// <returns>Returns the Models.Getsignaturekeydetailresponse response from the API call.</returns>
        public Models.Getsignaturekeydetailresponse GetSignatureKeyDetail(
                string keyId)
        {
            Task<Models.Getsignaturekeydetailresponse> t = this.GetSignatureKeyDetailAsync(keyId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve the current detail of a signature key using the key_id returned in the ```create signature key``` endpoint.
        /// </summary>
        /// <param name="keyId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Getsignaturekeydetailresponse response from the API call.</returns>
        public async Task<Models.Getsignaturekeydetailresponse> GetSignatureKeyDetailAsync(
                string keyId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/iam/signature_keys/{key_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "key_id", keyId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new Enablesignaturekey400responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new Disablethecurrentenabledsignaturekey403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new Disablethecurrentenabledsignaturekey403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Getsignaturekeydetailresponse>(response.Body);
        }

        /// <summary>
        /// Delete a signature key using the key_id returned in the ```create signature key``` endpoint.
        /// </summary>
        /// <param name="keyId">Required parameter: Example: .</param>
        public void DeleteSignatureKey(
                string keyId)
        {
            Task t = this.DeleteSignatureKeyAsync(keyId);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Delete a signature key using the key_id returned in the ```create signature key``` endpoint.
        /// </summary>
        /// <param name="keyId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeleteSignatureKeyAsync(
                string keyId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/iam/signature_keys/{key_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "key_id", keyId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 403)
            {
                throw new Disablethecurrentenabledsignaturekey403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new Disablethecurrentenabledsignaturekey403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Retrieve the currently enabled signature key.
        /// </summary>
        /// <returns>Returns the Models.Getenabledsignaturekeyresponse response from the API call.</returns>
        public Models.Getenabledsignaturekeyresponse GetEnabledSignatureKey()
        {
            Task<Models.Getenabledsignaturekeyresponse> t = this.GetEnabledSignatureKeyAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve the currently enabled signature key.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Getenabledsignaturekeyresponse response from the API call.</returns>
        public async Task<Models.Getenabledsignaturekeyresponse> GetEnabledSignatureKeyAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/iam/signature_keys/enabled");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 403)
            {
                throw new Disablethecurrentenabledsignaturekey403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new Disablethecurrentenabledsignaturekey403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Getenabledsignaturekeyresponse>(response.Body);
        }

        /// <summary>
        /// Enable a signature key using the key_id returned in the ```create signature key``` endpoint.
        /// There is only one signature key is enabled at the one moment in time. So if you enable the new signature key, the old one will be disabled.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.Enablesignaturekeyresponse response from the API call.</returns>
        public Models.Enablesignaturekeyresponse EnableSignatureKey(
                string accept,
                Models.Enablesignaturekeyrequest body)
        {
            Task<Models.Enablesignaturekeyresponse> t = this.EnableSignatureKeyAsync(accept, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Enable a signature key using the key_id returned in the ```create signature key``` endpoint.
        /// There is only one signature key is enabled at the one moment in time. So if you enable the new signature key, the old one will be disabled.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Enablesignaturekeyresponse response from the API call.</returns>
        public async Task<Models.Enablesignaturekeyresponse> EnableSignatureKeyAsync(
                string accept,
                Models.Enablesignaturekeyrequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/iam/signature_keys/enabled");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PatchBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new Enablesignaturekey400responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new Disablethecurrentenabledsignaturekey403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new Disablethecurrentenabledsignaturekey403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Enablesignaturekeyresponse>(response.Body);
        }

        /// <summary>
        /// Disable the current enabled signature key.
        /// A successful request will return no content when successful.
        /// </summary>
        public void DisableTheCurrentEnabledSignatureKey()
        {
            Task t = this.DisableTheCurrentEnabledSignatureKeyAsync();
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Disable the current enabled signature key.
        /// A successful request will return no content when successful.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DisableTheCurrentEnabledSignatureKeyAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/iam/signature_keys/enabled");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 403)
            {
                throw new Disablethecurrentenabledsignaturekey403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }
    }
}