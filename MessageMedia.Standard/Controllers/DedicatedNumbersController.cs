// <copyright file="DedicatedNumbersController.cs" company="APIMatic">
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
    /// DedicatedNumbersController.
    /// </summary>
    public class DedicatedNumbersController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DedicatedNumbersController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal DedicatedNumbersController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Get details about a specific dedicated number.
        /// </summary>
        /// <param name="id">Required parameter: unique identifier.</param>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <returns>Returns the object response from the API call.</returns>
        public object GetNumberById(
                string id,
                string accept)
        {
            Task<object> t = this.GetNumberByIdAsync(id, accept);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get details about a specific dedicated number.
        /// </summary>
        /// <param name="id">Required parameter: unique identifier.</param>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the object response from the API call.</returns>
        public async Task<object> GetNumberByIdAsync(
                string id,
                string accept,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/messaging/numbers/dedicated/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
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
                throw new M403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ResourcenotfoundException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return response.Body;
        }

        /// <summary>
        /// Use this endpoint to view details of the assignment including the label and metadata.
        /// </summary>
        /// <param name="numberId">Required parameter: unique identifier.</param>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <returns>Returns the Models.Assignment response from the API call.</returns>
        public Models.Assignment GetAssignment(
                string numberId,
                string accept)
        {
            Task<Models.Assignment> t = this.GetAssignmentAsync(numberId, accept);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Use this endpoint to view details of the assignment including the label and metadata.
        /// </summary>
        /// <param name="numberId">Required parameter: unique identifier.</param>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Assignment response from the API call.</returns>
        public async Task<Models.Assignment> GetAssignmentAsync(
                string numberId,
                string accept,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/messaging/numbers/dedicated/{numberId}/assignment");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "numberId", numberId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
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
                throw new M403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ResourcenotfoundException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Assignment>(response.Body);
        }

        /// <summary>
        /// Assign the specified number to the authenticated account. .
        /// Use the body of the request to specify a label or metadata .
        /// for this number assignment.
        /// If you receive a *conflict* error then the number that you have selected is unavailable for assignment. .
        /// This means that the number is either already assigned to another account, .
        /// or has an available_after date in the future. Should this occur, perform .
        /// another search and select a different number.
        /// </summary>
        /// <param name="numberId">Required parameter: unique identifier.</param>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.Assignment response from the API call.</returns>
        public Models.Assignment CreateAssignment(
                string numberId,
                string accept,
                Models.CreateAssignmentrequest body)
        {
            Task<Models.Assignment> t = this.CreateAssignmentAsync(numberId, accept, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Assign the specified number to the authenticated account. .
        /// Use the body of the request to specify a label or metadata .
        /// for this number assignment.
        /// If you receive a *conflict* error then the number that you have selected is unavailable for assignment. .
        /// This means that the number is either already assigned to another account, .
        /// or has an available_after date in the future. Should this occur, perform .
        /// another search and select a different number.
        /// </summary>
        /// <param name="numberId">Required parameter: unique identifier.</param>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Assignment response from the API call.</returns>
        public async Task<Models.Assignment> CreateAssignmentAsync(
                string numberId,
                string accept,
                Models.CreateAssignmentrequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/messaging/numbers/dedicated/{numberId}/assignment");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "numberId", numberId },
            });

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

            if (response.StatusCode == 403)
            {
                throw new M403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ResourcenotfoundException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Assignment>(response.Body);
        }

        /// <summary>
        /// Release the dedicated number from your account.
        /// </summary>
        /// <param name="numberId">Required parameter: unique identifier.</param>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <returns>Returns the Stream response from the API call.</returns>
        public Stream DeleteAssignment(
                string numberId,
                string accept)
        {
            Task<Stream> t = this.DeleteAssignmentAsync(numberId, accept);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Release the dedicated number from your account.
        /// </summary>
        /// <param name="numberId">Required parameter: unique identifier.</param>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Stream response from the API call.</returns>
        public async Task<Stream> DeleteAssignmentAsync(
                string numberId,
                string accept,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/messaging/numbers/dedicated/{numberId}/assignment");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "numberId", numberId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
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

            if (response.StatusCode == 403)
            {
                throw new M403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return response.RawBody;
        }

        /// <summary>
        /// Retain the dedicated number assignment, and edit or add additional metadata or title information. You can exclude any data from the body of this request that you do not want updated.
        /// </summary>
        /// <param name="numberId">Required parameter: unique identifier.</param>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.Assignment response from the API call.</returns>
        public Models.Assignment UpdateAssignment(
                string numberId,
                string accept,
                Models.UpdateAssignmentrequest body)
        {
            Task<Models.Assignment> t = this.UpdateAssignmentAsync(numberId, accept, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retain the dedicated number assignment, and edit or add additional metadata or title information. You can exclude any data from the body of this request that you do not want updated.
        /// </summary>
        /// <param name="numberId">Required parameter: unique identifier.</param>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Assignment response from the API call.</returns>
        public async Task<Models.Assignment> UpdateAssignmentAsync(
                string numberId,
                string accept,
                Models.UpdateAssignmentrequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/messaging/numbers/dedicated/{numberId}/assignment");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "numberId", numberId },
            });

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

            if (response.StatusCode == 403)
            {
                throw new M403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Assignment>(response.Body);
        }

        /// <summary>
        /// Get a list of available dedicated numbers, filtered by requirements.
        /// </summary>
        /// <param name="country">Optional parameter: ISO_3166 country code, 2 character code to filter available numbers by country.</param>
        /// <param name="matching">Optional parameter: filters results by a pattern of digits contained within the number.</param>
        /// <param name="pageSize">Optional parameter: number of results returned per page, default 50.</param>
        /// <param name="serviceTypes">Optional parameter: filter results to include numbers with certain capabilities.</param>
        /// <param name="token">Optional parameter: In paginated data the original request will return with a "next_token" attribute. This token must be entered into subsequent call in the "token" query parameter to obtain the next set of records..</param>
        /// <returns>Returns the Models.NumbersListResponse response from the API call.</returns>
        public Models.NumbersListResponse GetNumbers(
                string country = null,
                string matching = null,
                int? pageSize = null,
                Models.ServiceTypesEnum? serviceTypes = null,
                string token = null)
        {
            Task<Models.NumbersListResponse> t = this.GetNumbersAsync(country, matching, pageSize, serviceTypes, token);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get a list of available dedicated numbers, filtered by requirements.
        /// </summary>
        /// <param name="country">Optional parameter: ISO_3166 country code, 2 character code to filter available numbers by country.</param>
        /// <param name="matching">Optional parameter: filters results by a pattern of digits contained within the number.</param>
        /// <param name="pageSize">Optional parameter: number of results returned per page, default 50.</param>
        /// <param name="serviceTypes">Optional parameter: filter results to include numbers with certain capabilities.</param>
        /// <param name="token">Optional parameter: In paginated data the original request will return with a "next_token" attribute. This token must be entered into subsequent call in the "token" query parameter to obtain the next set of records..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.NumbersListResponse response from the API call.</returns>
        public async Task<Models.NumbersListResponse> GetNumbersAsync(
                string country = null,
                string matching = null,
                int? pageSize = null,
                Models.ServiceTypesEnum? serviceTypes = null,
                string token = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/messaging/numbers/dedicated/");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "country", country },
                { "matching", matching },
                { "page_size", pageSize },
                { "service_types", (serviceTypes.HasValue) ? ApiHelper.JsonSerialize(serviceTypes.Value).Trim('\"') : null },
                { "token", token },
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

            if (response.StatusCode == 403)
            {
                throw new M403responseException("Unexpected error in API call. See HTTP response body for details.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.NumbersListResponse>(response.Body);
        }

        /// <summary>
        /// Get assigned numbers.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="pageSize">Optional parameter: Number of results returned per page, default 50.</param>
        /// <param name="token">Optional parameter: In paginated data the original request will return with a "next_token" attribute. This token must be entered into subsequent call in the "token" query parameter to obtain the next set of records..</param>
        /// <param name="numberId">Optional parameter: Unique identifier of a specific number.</param>
        /// <param name="matching">Optional parameter: Filters results by a pattern of digits contained within the number.</param>
        /// <param name="country">Optional parameter: Filter results by ISO_3166 country code, 2 character code to filter available numbers by country.</param>
        /// <param name="type">Optional parameter: Filter results by Number type.</param>
        /// <param name="classification">Optional parameter: Filter results by Number Classification.</param>
        /// <param name="serviceTypes">Optional parameter: Filter results by capabilities.</param>
        /// <param name="label">Optional parameter: Filter results by a matching label.</param>
        /// <param name="sortBy">Optional parameter: Sort results by property.</param>
        /// <param name="sortDirection">Optional parameter: Sort direction.</param>
        /// <returns>Returns the Models.AssignedNumberListResponse response from the API call.</returns>
        public Models.AssignedNumberListResponse GetAssignedNumbers(
                string accept,
                int? pageSize = null,
                string token = null,
                string numberId = null,
                string matching = null,
                string country = null,
                Models.Type1Enum? type = null,
                Models.ClassificationEnum? classification = null,
                Models.ServiceTypesEnum? serviceTypes = null,
                string label = null,
                Models.SortByEnum? sortBy = null,
                Models.SortDirectionEnum? sortDirection = null)
        {
            Task<Models.AssignedNumberListResponse> t = this.GetAssignedNumbersAsync(accept, pageSize, token, numberId, matching, country, type, classification, serviceTypes, label, sortBy, sortDirection);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get assigned numbers.
        /// </summary>
        /// <param name="accept">Required parameter: Example: .</param>
        /// <param name="pageSize">Optional parameter: Number of results returned per page, default 50.</param>
        /// <param name="token">Optional parameter: In paginated data the original request will return with a "next_token" attribute. This token must be entered into subsequent call in the "token" query parameter to obtain the next set of records..</param>
        /// <param name="numberId">Optional parameter: Unique identifier of a specific number.</param>
        /// <param name="matching">Optional parameter: Filters results by a pattern of digits contained within the number.</param>
        /// <param name="country">Optional parameter: Filter results by ISO_3166 country code, 2 character code to filter available numbers by country.</param>
        /// <param name="type">Optional parameter: Filter results by Number type.</param>
        /// <param name="classification">Optional parameter: Filter results by Number Classification.</param>
        /// <param name="serviceTypes">Optional parameter: Filter results by capabilities.</param>
        /// <param name="label">Optional parameter: Filter results by a matching label.</param>
        /// <param name="sortBy">Optional parameter: Sort results by property.</param>
        /// <param name="sortDirection">Optional parameter: Sort direction.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AssignedNumberListResponse response from the API call.</returns>
        public async Task<Models.AssignedNumberListResponse> GetAssignedNumbersAsync(
                string accept,
                int? pageSize = null,
                string token = null,
                string numberId = null,
                string matching = null,
                string country = null,
                Models.Type1Enum? type = null,
                Models.ClassificationEnum? classification = null,
                Models.ServiceTypesEnum? serviceTypes = null,
                string label = null,
                Models.SortByEnum? sortBy = null,
                Models.SortDirectionEnum? sortDirection = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/messaging/numbers/dedicated/assignments");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "page_size", pageSize },
                { "token", token },
                { "number_id", numberId },
                { "matching", matching },
                { "country", country },
                { "type", (type.HasValue) ? ApiHelper.JsonSerialize(type.Value).Trim('\"') : null },
                { "classification", (classification.HasValue) ? ApiHelper.JsonSerialize(classification.Value).Trim('\"') : null },
                { "service_types", (serviceTypes.HasValue) ? ApiHelper.JsonSerialize(serviceTypes.Value).Trim('\"') : null },
                { "label", label },
                { "sort_by", (sortBy.HasValue) ? ApiHelper.JsonSerialize(sortBy.Value).Trim('\"') : null },
                { "sort_direction", (sortDirection.HasValue) ? ApiHelper.JsonSerialize(sortDirection.Value).Trim('\"') : null },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
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

            if (response.StatusCode == 403)
            {
                throw new M403responseException("Unauthorised", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.AssignedNumberListResponse>(response.Body);
        }
    }
}