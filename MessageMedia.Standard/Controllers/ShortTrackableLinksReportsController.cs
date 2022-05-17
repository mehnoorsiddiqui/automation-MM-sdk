// <copyright file="ShortTrackableLinksReportsController.cs" company="APIMatic">
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
    /// ShortTrackableLinksReportsController.
    /// </summary>
    public class ShortTrackableLinksReportsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShortTrackableLinksReportsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal ShortTrackableLinksReportsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Clicks summary report for metadata key value pair, long url and short url.
        /// </summary>
        /// <param name="key">Optional parameter: Example: .</param>
        /// <param name="mValue">Optional parameter: Example: .</param>
        /// <param name="url">Optional parameter: Example: .</param>
        /// <param name="recipient">Optional parameter: Example: .</param>
        /// <param name="page">Optional parameter: Example: .</param>
        /// <param name="pageSize">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.LogSummaryResult response from the API call.</returns>
        public Models.LogSummaryResult LogSummary(
                string key = null,
                string mValue = null,
                string url = null,
                string recipient = null,
                double? page = null,
                double? pageSize = null)
        {
            Task<Models.LogSummaryResult> t = this.LogSummaryAsync(key, mValue, url, recipient, page, pageSize);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Clicks summary report for metadata key value pair, long url and short url.
        /// </summary>
        /// <param name="key">Optional parameter: Example: .</param>
        /// <param name="mValue">Optional parameter: Example: .</param>
        /// <param name="url">Optional parameter: Example: .</param>
        /// <param name="recipient">Optional parameter: Example: .</param>
        /// <param name="page">Optional parameter: Example: .</param>
        /// <param name="pageSize">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.LogSummaryResult response from the API call.</returns>
        public async Task<Models.LogSummaryResult> LogSummaryAsync(
                string key = null,
                string mValue = null,
                string url = null,
                string recipient = null,
                double? page = null,
                double? pageSize = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/links/summary");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "key", key },
                { "value", mValue },
                { "url", url },
                { "recipient", recipient },
                { "page", page },
                { "pageSize", pageSize },
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
                throw new ApiException("Bad Request. Invalid data provided", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Data cannot be found", context);
            }

            if (response.StatusCode == 500)
            {
                throw new ApiException("System Error", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.LogSummaryResult>(response.Body);
        }

        /// <summary>
        /// Detailed clicks report for a hashcode.
        /// </summary>
        /// <param name="hash">Required parameter: Example: .</param>
        /// <param name="page">Optional parameter: Example: .</param>
        /// <param name="pageSize">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.LogsDetailResult response from the API call.</returns>
        public Models.LogsDetailResult LogDetail(
                string hash,
                double? page = null,
                double? pageSize = null)
        {
            Task<Models.LogsDetailResult> t = this.LogDetailAsync(hash, page, pageSize);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Detailed clicks report for a hashcode.
        /// </summary>
        /// <param name="hash">Required parameter: Example: .</param>
        /// <param name="page">Optional parameter: Example: .</param>
        /// <param name="pageSize">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.LogsDetailResult response from the API call.</returns>
        public async Task<Models.LogsDetailResult> LogDetailAsync(
                string hash,
                double? page = null,
                double? pageSize = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/links/detail");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "hash", hash },
                { "page", page },
                { "pageSize", pageSize },
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
                throw new ApiException("Bad Request. Invalid data provided", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Data cannot be found", context);
            }

            if (response.StatusCode == 500)
            {
                throw new ApiException("System Error", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.LogsDetailResult>(response.Body);
        }
    }
}