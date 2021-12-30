// <copyright file="DeliveryReportsController.cs" company="APIMatic">
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
    using MessageMedia.Standard.Http.Response;
    using MessageMedia.Standard.Utilities;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// DeliveryReportsController.
    /// </summary>
    public class DeliveryReportsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryReportsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal DeliveryReportsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Check for any delivery reports that have been received.
        /// Delivery reports are a notification of the change in status of a message as it is being processed.
        /// </summary>
        /// <returns>Returns the Models.Checkdeliveryreportsresponse response from the API call.</returns>
        public Models.Checkdeliveryreportsresponse CheckDeliveryReports()
        {
            Task<Models.Checkdeliveryreportsresponse> t = this.CheckDeliveryReportsAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Check for any delivery reports that have been received.
        /// Delivery reports are a notification of the change in status of a message as it is being processed.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Checkdeliveryreportsresponse response from the API call.</returns>
        public async Task<Models.Checkdeliveryreportsresponse> CheckDeliveryReportsAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/delivery_reports");

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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 403)
            {
                throw new M403responseException("Unauthorised", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ResourcenotfoundException("Resource not found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Checkdeliveryreportsresponse>(response.Body);
        }

        /// <summary>
        /// Mark a delivery report as confirmed so it is no longer return in check delivery reports requests.
        /// </summary>
        /// <param name="body">Required parameter: Delivery reports to confirm as received..</param>
        /// <returns>Returns the object response from the API call.</returns>
        public object ConfirmDeliveryReportsAsReceived(
                Models.Confirmeliveryreportsasreceivedrequest body)
        {
            Task<object> t = this.ConfirmDeliveryReportsAsReceivedAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Mark a delivery report as confirmed so it is no longer return in check delivery reports requests.
        /// </summary>
        /// <param name="body">Required parameter: Delivery reports to confirm as received..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the object response from the API call.</returns>
        public async Task<object> ConfirmDeliveryReportsAsReceivedAsync(
                Models.Confirmeliveryreportsasreceivedrequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/delivery_reports/confirmed");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new BadrequestException("Bad request", context);
            }

            if (response.StatusCode == 403)
            {
                throw new M403responseException("Unauthorised", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ResourcenotfoundException("Resource not found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return response.Body;
        }
    }
}