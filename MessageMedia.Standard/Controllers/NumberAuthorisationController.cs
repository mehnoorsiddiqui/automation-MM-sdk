// <copyright file="NumberAuthorisationController.cs" company="APIMatic">
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
    /// NumberAuthorisationController.
    /// </summary>
    public class NumberAuthorisationController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberAuthorisationController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal NumberAuthorisationController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// This endpoint returns a list of 100 numbers that are on the blacklist.  There is a pagination token to retrieve the next 100 numbers.
        /// </summary>
        /// <returns>Returns the Models.Getnumberauthorisationblacklistresponse response from the API call.</returns>
        public Models.Getnumberauthorisationblacklistresponse ListAllBlockedNumbers()
        {
            Task<Models.Getnumberauthorisationblacklistresponse> t = this.ListAllBlockedNumbersAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint returns a list of 100 numbers that are on the blacklist.  There is a pagination token to retrieve the next 100 numbers.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Getnumberauthorisationblacklistresponse response from the API call.</returns>
        public async Task<Models.Getnumberauthorisationblacklistresponse> ListAllBlockedNumbersAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/number_authorisation/mt/blacklist");

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
                throw new M403responseException("Unauthorised", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Getnumberauthorisationblacklistresponse>(response.Body);
        }

        /// <summary>
        /// This endpoint allows you to add one or more numbers to your blacklist. You can add up to 10 numbers in one request.
        /// </summary>
        /// <param name="body">Required parameter: Numbers need to be in international format and therefore start with a +.</param>
        /// <returns>Returns the Models.Addoneormorenumberstoyourbacklistresponse response from the API call.</returns>
        public Models.Addoneormorenumberstoyourbacklistresponse AddOneOrMoreNumbersToYourBacklist(
                Models.Addoneormorenumberstoyourbacklistrequest body)
        {
            Task<Models.Addoneormorenumberstoyourbacklistresponse> t = this.AddOneOrMoreNumbersToYourBacklistAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint allows you to add one or more numbers to your blacklist. You can add up to 10 numbers in one request.
        /// </summary>
        /// <param name="body">Required parameter: Numbers need to be in international format and therefore start with a +.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Addoneormorenumberstoyourbacklistresponse response from the API call.</returns>
        public async Task<Models.Addoneormorenumberstoyourbacklistresponse> AddOneOrMoreNumbersToYourBacklistAsync(
                Models.Addoneormorenumberstoyourbacklistrequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/number_authorisation/mt/blacklist");

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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Addoneormorenumberstoyourbacklistresponse>(response.Body);
        }

        /// <summary>
        /// This endpoint allows you to remove a number from the blacklist.  Only one number can be deleted per request.
        /// </summary>
        /// <param name="number">Required parameter: a number in international format e.g. ```+61491570156```.</param>
        /// <returns>Returns the Stream response from the API call.</returns>
        public Stream RemoveANumberFromTheBlacklist(
                string number)
        {
            Task<Stream> t = this.RemoveANumberFromTheBlacklistAsync(number);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint allows you to remove a number from the blacklist.  Only one number can be deleted per request.
        /// </summary>
        /// <param name="number">Required parameter: a number in international format e.g. ```+61491570156```.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Stream response from the API call.</returns>
        public async Task<Stream> RemoveANumberFromTheBlacklistAsync(
                string number,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/number_authorisation/mt/blacklist/{number}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "number", number },
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
            HttpResponse response = await this.GetClientInstance().ExecuteAsBinaryAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return response.RawBody;
        }

        /// <summary>
        /// This endpoints lists for each requested number if you are authorised (which means the number is not blacklisted) to send to this number.
        /// If you send a message which is on the blacklist, MessageMedia issue a delivery receipt with the appropriate status code.
        /// </summary>
        /// <param name="numbers">Required parameter: one or more numbers in international format seperate by a comma, e.g. ```+61491570156,+61491570157```.</param>
        /// <returns>Returns the Models.Checkifoneorseveralnumbersarecurrentlyblacklistedresponse response from the API call.</returns>
        public Models.Checkifoneorseveralnumbersarecurrentlyblacklistedresponse CheckIfOneOrSeveralNumbersAreCurrentlyBlacklisted(
                List<string> numbers)
        {
            Task<Models.Checkifoneorseveralnumbersarecurrentlyblacklistedresponse> t = this.CheckIfOneOrSeveralNumbersAreCurrentlyBlacklistedAsync(numbers);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoints lists for each requested number if you are authorised (which means the number is not blacklisted) to send to this number.
        /// If you send a message which is on the blacklist, MessageMedia issue a delivery receipt with the appropriate status code.
        /// </summary>
        /// <param name="numbers">Required parameter: one or more numbers in international format seperate by a comma, e.g. ```+61491570156,+61491570157```.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Checkifoneorseveralnumbersarecurrentlyblacklistedresponse response from the API call.</returns>
        public async Task<Models.Checkifoneorseveralnumbersarecurrentlyblacklistedresponse> CheckIfOneOrSeveralNumbersAreCurrentlyBlacklistedAsync(
                List<string> numbers,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/number_authorisation/is_authorised/{numbers}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "numbers", numbers },
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

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Checkifoneorseveralnumbersarecurrentlyblacklistedresponse>(response.Body);
        }
    }
}