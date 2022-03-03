// <copyright file="MessagesController.cs" company="APIMatic">
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
    /// MessagesController.
    /// </summary>
    public class MessagesController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessagesController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal MessagesController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Cancel a scheduled message that has not yet been .
        /// A scheduled message can be cancelled by updating the status of a message.
        /// from ```scheduled``` to ```cancelled```.
        /// </summary>
        /// <param name="messageId">Required parameter: 35 character UUID..</param>
        /// <param name="body">Required parameter: Parameters of a message to change..</param>
        public void CancelScheduledMessage(
                string messageId,
                Models.Cancelscheduledmessagerequest body)
        {
            Task t = this.CancelScheduledMessageAsync(messageId, body);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Cancel a scheduled message that has not yet been .
        /// A scheduled message can be cancelled by updating the status of a message.
        /// from ```scheduled``` to ```cancelled```.
        /// </summary>
        /// <param name="messageId">Required parameter: 35 character UUID..</param>
        /// <param name="body">Required parameter: Parameters of a message to change..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task CancelScheduledMessageAsync(
                string messageId,
                Models.Cancelscheduledmessagerequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/messages/{messageId}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "messageId", messageId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

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
        }

        /// <summary>
        /// Retrieve the current status of a message using the message ID returned in the send messages end point.
        /// </summary>
        /// <param name="messageId">Required parameter: 36 character UUID..</param>
        /// <returns>Returns the Models.Getmessagestatusresponse response from the API call.</returns>
        public Models.Getmessagestatusresponse GetMessageStatus(
                string messageId)
        {
            Task<Models.Getmessagestatusresponse> t = this.GetMessageStatusAsync(messageId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve the current status of a message using the message ID returned in the send messages end point.
        /// </summary>
        /// <param name="messageId">Required parameter: 36 character UUID..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Getmessagestatusresponse response from the API call.</returns>
        public async Task<Models.Getmessagestatusresponse> GetMessageStatusAsync(
                string messageId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/messages/{messageId}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "messageId", messageId },
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

            return ApiHelper.JsonDeserialize<Models.Getmessagestatusresponse>(response.Body);
        }

        /// <summary>
        /// Submit one or more (up to 100 per request) SMS, MMS or text to voice messages for delivery.
        /// *Note: when sending multiple messages in a request,if any message in the request is invalid, no message will be sent.*.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.Sendmessagesresponse response from the API call.</returns>
        public Models.Sendmessagesresponse SendMessages(
                Models.Sendmessagesrequest body)
        {
            Task<Models.Sendmessagesresponse> t = this.SendMessagesAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Submit one or more (up to 100 per request) SMS, MMS or text to voice messages for delivery.
        /// *Note: when sending multiple messages in a request,if any message in the request is invalid, no message will be sent.*.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Sendmessagesresponse response from the API call.</returns>
        public async Task<Models.Sendmessagesresponse> SendMessagesAsync(
                Models.Sendmessagesrequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/messages");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
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
                throw new BadrequestException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new M403responseException("Unauthorised", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Sendmessagesresponse>(response.Body);
        }
    }
}