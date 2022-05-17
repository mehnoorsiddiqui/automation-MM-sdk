// <copyright file="LookupsController.cs" company="APIMatic">
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
    /// LookupsController.
    /// </summary>
    public class LookupsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LookupsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal LookupsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Use the Lookups API to find information about a phone number.
        /// </summary>
        /// <param name="phoneNumber">Required parameter: The phone number to be looked up.</param>
        /// <param name="options">Optional parameter: The options query parameter can also be used to request additional information about the phone number. e.g `carrier` and `type` can be used together using `,` and `hlr`  for location but cannot be used  with othe values..</param>
        /// <returns>Returns the Models.Lookupaphonenumberresponse response from the API call.</returns>
        public Models.Lookupaphonenumberresponse LookupAPhoneNumber(
                string phoneNumber,
                string options = null)
        {
            Task<Models.Lookupaphonenumberresponse> t = this.LookupAPhoneNumberAsync(phoneNumber, options);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Use the Lookups API to find information about a phone number.
        /// </summary>
        /// <param name="phoneNumber">Required parameter: The phone number to be looked up.</param>
        /// <param name="options">Optional parameter: The options query parameter can also be used to request additional information about the phone number. e.g `carrier` and `type` can be used together using `,` and `hlr`  for location but cannot be used  with othe values..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Lookupaphonenumberresponse response from the API call.</returns>
        public async Task<Models.Lookupaphonenumberresponse> LookupAPhoneNumberAsync(
                string phoneNumber,
                string options = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/lookups/phone/{phone_number}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "phone_number", phoneNumber },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "options", options },
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
                throw new BadrequestException("Bad request", context);
            }

            if (response.StatusCode == 403)
            {
                throw new M403responseException("Unauthorised", context);
            }

            if (response.StatusCode == 404)
            {
                throw new Lookupaphonenumber404responseException("Resource not found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Lookupaphonenumberresponse>(response.Body);
        }
    }
}