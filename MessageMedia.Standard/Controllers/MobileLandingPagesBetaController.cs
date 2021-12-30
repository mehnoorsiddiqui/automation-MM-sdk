// <copyright file="MobileLandingPagesBetaController.cs" company="APIMatic">
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
    /// MobileLandingPagesBetaController.
    /// </summary>
    public class MobileLandingPagesBetaController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobileLandingPagesBetaController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal MobileLandingPagesBetaController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Mobile Landing Pages Campaigns belonging to the user.Create a new campaign.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.CreateNewCampaignresponse response from the API call.</returns>
        public Models.CreateNewCampaignresponse CreateNewCampaign(
                Models.BetaSmsplusCampaignsRequest body = null)
        {
            Task<Models.CreateNewCampaignresponse> t = this.CreateNewCampaignAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Mobile Landing Pages Campaigns belonging to the user.Create a new campaign.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateNewCampaignresponse response from the API call.</returns>
        public async Task<Models.CreateNewCampaignresponse> CreateNewCampaignAsync(
                Models.BetaSmsplusCampaignsRequest body = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/beta/smsplus/campaigns");

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
                throw new ApiException("", context);
            }

            if (response.StatusCode == 402)
            {
                throw new ApiException("", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.CreateNewCampaignresponse>(response.Body);
        }

        /// <summary>
        /// A single campaign, identified by a unique identifier.Returns the details of a single campaign.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <returns>Returns the Models.GetCampaignresponse response from the API call.</returns>
        public Models.GetCampaignresponse GetCampaign(
                string id)
        {
            Task<Models.GetCampaignresponse> t = this.GetCampaignAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// A single campaign, identified by a unique identifier.Returns the details of a single campaign.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetCampaignresponse response from the API call.</returns>
        public async Task<Models.GetCampaignresponse> GetCampaignAsync(
                string id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/beta/smsplus/campaigns/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
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

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.GetCampaignresponse>(response.Body);
        }

        /// <summary>
        /// The Landing Page datastore makes it easier to create Campiangs based on the saved data.Create a Landing Page.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.CreateaLandingPageresponse response from the API call.</returns>
        public Models.CreateaLandingPageresponse CreateaLandingPage(
                Models.BetaSmsplusLandingPagesRequest body = null)
        {
            Task<Models.CreateaLandingPageresponse> t = this.CreateaLandingPageAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// The Landing Page datastore makes it easier to create Campiangs based on the saved data.Create a Landing Page.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateaLandingPageresponse response from the API call.</returns>
        public async Task<Models.CreateaLandingPageresponse> CreateaLandingPageAsync(
                Models.BetaSmsplusLandingPagesRequest body = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/beta/smsplus/landing_pages");

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
                throw new ApiException("", context);
            }

            if (response.StatusCode == 402)
            {
                throw new ApiException("", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.CreateaLandingPageresponse>(response.Body);
        }

        /// <summary>
        /// The Landing Page datastore makes it easier to create Campiangs based on the saved data.Returns a paginated list of Landing Pages for your account. ```sort_by``` and ```sort_direction``` must both be specified or neither at all (the default sort options are ```DESCENDING``` ```MODIFIED_TIMESTAMP```).
        /// </summary>
        /// <param name="pageSize">Optional parameter: Page size between 5 and 100 (default 20).</param>
        /// <param name="pageToken">Optional parameter: Token to fetch the next page.</param>
        /// <param name="sortBy">Optional parameter: Can be `CREATED_TIMESTAMP` or `UPDATED_TIMESTAMP`.</param>
        /// <param name="sortDirection">Optional parameter: Can be `ASCENDING` or `DESCENDING`.</param>
        /// <returns>Returns the object response from the API call.</returns>
        public object GetLandingPages(
                string pageSize = null,
                string pageToken = null,
                string sortBy = null,
                string sortDirection = null)
        {
            Task<object> t = this.GetLandingPagesAsync(pageSize, pageToken, sortBy, sortDirection);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// The Landing Page datastore makes it easier to create Campiangs based on the saved data.Returns a paginated list of Landing Pages for your account. ```sort_by``` and ```sort_direction``` must both be specified or neither at all (the default sort options are ```DESCENDING``` ```MODIFIED_TIMESTAMP```).
        /// </summary>
        /// <param name="pageSize">Optional parameter: Page size between 5 and 100 (default 20).</param>
        /// <param name="pageToken">Optional parameter: Token to fetch the next page.</param>
        /// <param name="sortBy">Optional parameter: Can be `CREATED_TIMESTAMP` or `UPDATED_TIMESTAMP`.</param>
        /// <param name="sortDirection">Optional parameter: Can be `ASCENDING` or `DESCENDING`.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the object response from the API call.</returns>
        public async Task<object> GetLandingPagesAsync(
                string pageSize = null,
                string pageToken = null,
                string sortBy = null,
                string sortDirection = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/beta/smsplus/landing_pages");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "page_size", pageSize },
                { "page_token", pageToken },
                { "sort_by", sortBy },
                { "sort_direction", sortDirection },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

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

            if (response.StatusCode == 402)
            {
                throw new ApiException("", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return response.Body;
        }

        /// <summary>
        /// The Landing Page datastore makes it easier to create Campiangs based on the saved data.Delete a Landing Page.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        public void DeleteaLandingPage(
                string id)
        {
            Task t = this.DeleteaLandingPageAsync(id);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// The Landing Page datastore makes it easier to create Campiangs based on the saved data.Delete a Landing Page.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeleteaLandingPageAsync(
                string id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/beta/smsplus/landing_pages/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 402)
            {
                throw new ApiException("", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// The Landing Page datastore makes it easier to create Campiangs based on the saved data.Update a Landing Page.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.UpdateaLandingPageresponse response from the API call.</returns>
        public Models.UpdateaLandingPageresponse UpdateaLandingPage(
                string id,
                Models.BetaSmsplusLandingPagesRequest1 body = null)
        {
            Task<Models.UpdateaLandingPageresponse> t = this.UpdateaLandingPageAsync(id, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// The Landing Page datastore makes it easier to create Campiangs based on the saved data.Update a Landing Page.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateaLandingPageresponse response from the API call.</returns>
        public async Task<Models.UpdateaLandingPageresponse> UpdateaLandingPageAsync(
                string id,
                Models.BetaSmsplusLandingPagesRequest1 body = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/beta/smsplus/landing_pages/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

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
            HttpRequest httpRequest = this.GetClientInstance().PatchBody(queryBuilder.ToString(), headers, bodyText);

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
                throw new ApiException("", context);
            }

            if (response.StatusCode == 402)
            {
                throw new ApiException("", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.UpdateaLandingPageresponse>(response.Body);
        }

        /// <summary>
        /// The reporting endpoint provides access to the reporting analytics.
        /// ### Events Types.
        /// The campaign report consists of a series of events, that were generated by recipients when.
        /// interacting with the generated mobile landing page.  The set of events that are currently supported.
        /// are as follows:.
        /// | Event Type        | Event Source | Description                                    |.
        /// |:------------------|:-------------|:-----------------------------------------------|.
        /// | `PAGE_OPEN`       | n/a          | The page was opened in a browser.              |.
        /// | `BUTTON_CLICKED`  | Button label | One of the Call to Action buttons was clicked. |.
        /// | `FORM_SUBMITTED`  | n/a          | A form has been submitted with the captured data stored in the 'data' field. |Returns the breakdown of events and recipients of a particular campaign.
        /// </summary>
        /// <param name="campaignId">Required parameter: The campaign ID.</param>
        /// <returns>Returns the Models.CampaignSummary response from the API call.</returns>
        public Models.CampaignSummary GetCampaignSummary(
                string campaignId)
        {
            Task<Models.CampaignSummary> t = this.GetCampaignSummaryAsync(campaignId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// The reporting endpoint provides access to the reporting analytics.
        /// ### Events Types.
        /// The campaign report consists of a series of events, that were generated by recipients when.
        /// interacting with the generated mobile landing page.  The set of events that are currently supported.
        /// are as follows:.
        /// | Event Type        | Event Source | Description                                    |.
        /// |:------------------|:-------------|:-----------------------------------------------|.
        /// | `PAGE_OPEN`       | n/a          | The page was opened in a browser.              |.
        /// | `BUTTON_CLICKED`  | Button label | One of the Call to Action buttons was clicked. |.
        /// | `FORM_SUBMITTED`  | n/a          | A form has been submitted with the captured data stored in the 'data' field. |Returns the breakdown of events and recipients of a particular campaign.
        /// </summary>
        /// <param name="campaignId">Required parameter: The campaign ID.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CampaignSummary response from the API call.</returns>
        public async Task<Models.CampaignSummary> GetCampaignSummaryAsync(
                string campaignId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/beta/smsplus/reporting/{campaign_id}/summary");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "campaign_id", campaignId },
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

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.CampaignSummary>(response.Body);
        }

        /// <summary>
        /// The reporting endpoint provides access to the reporting analytics.
        /// ### Events Types.
        /// The campaign report consists of a series of events, that were generated by recipients when.
        /// interacting with the generated mobile landing page.  The set of events that are currently supported.
        /// are as follows:.
        /// | Event Type        | Event Source | Description                                    |.
        /// |:------------------|:-------------|:-----------------------------------------------|.
        /// | `PAGE_OPEN`       | n/a          | The page was opened in a browser.              |.
        /// | `BUTTON_CLICKED`  | Button label | One of the Call to Action buttons was clicked. |.
        /// | `FORM_SUBMITTED`  | n/a          | A form has been submitted with the captured data stored in the 'data' field. |Returns a list of events that have occurred for a particular campaign.
        /// At this stage, the events are returned in reverse chronological order.
        /// </summary>
        /// <param name="campaignId">Required parameter: The campaign ID.</param>
        /// <param name="page">Optional parameter: The page of results to retrieve.  If unspecified, defaults to 0..</param>
        /// <param name="pageSize">Optional parameter: The size of each page.  Must be between 5 and 100.  Defaults to 25..</param>
        /// <returns>Returns the Models.ListCampaignEventPage response from the API call.</returns>
        public Models.ListCampaignEventPage GetCampaignEvents(
                string campaignId,
                double? page = null,
                double? pageSize = null)
        {
            Task<Models.ListCampaignEventPage> t = this.GetCampaignEventsAsync(campaignId, page, pageSize);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// The reporting endpoint provides access to the reporting analytics.
        /// ### Events Types.
        /// The campaign report consists of a series of events, that were generated by recipients when.
        /// interacting with the generated mobile landing page.  The set of events that are currently supported.
        /// are as follows:.
        /// | Event Type        | Event Source | Description                                    |.
        /// |:------------------|:-------------|:-----------------------------------------------|.
        /// | `PAGE_OPEN`       | n/a          | The page was opened in a browser.              |.
        /// | `BUTTON_CLICKED`  | Button label | One of the Call to Action buttons was clicked. |.
        /// | `FORM_SUBMITTED`  | n/a          | A form has been submitted with the captured data stored in the 'data' field. |Returns a list of events that have occurred for a particular campaign.
        /// At this stage, the events are returned in reverse chronological order.
        /// </summary>
        /// <param name="campaignId">Required parameter: The campaign ID.</param>
        /// <param name="page">Optional parameter: The page of results to retrieve.  If unspecified, defaults to 0..</param>
        /// <param name="pageSize">Optional parameter: The size of each page.  Must be between 5 and 100.  Defaults to 25..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCampaignEventPage response from the API call.</returns>
        public async Task<Models.ListCampaignEventPage> GetCampaignEventsAsync(
                string campaignId,
                double? page = null,
                double? pageSize = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/beta/smsplus/reporting/{campaign_id}/events");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "campaign_id", campaignId },
            });

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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 402)
            {
                throw new ApiException("", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ListCampaignEventPage>(response.Body);
        }

        /// <summary>
        /// Returns a list of Template Field Definition.
        /// </summary>
        /// <param name="id">Required parameter: Template Id.</param>
        /// <returns>Returns the Models.GetTemplatesFieldsDefinationresponse response from the API call.</returns>
        public Models.GetTemplatesFieldsDefinationresponse GetTemplatesFieldsDefinition(
                string id)
        {
            Task<Models.GetTemplatesFieldsDefinationresponse> t = this.GetTemplatesFieldsDefinitionAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of Template Field Definition.
        /// </summary>
        /// <param name="id">Required parameter: Template Id.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetTemplatesFieldsDefinationresponse response from the API call.</returns>
        public async Task<Models.GetTemplatesFieldsDefinationresponse> GetTemplatesFieldsDefinitionAsync(
                string id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/beta/smsplus/templates/{id}/fields");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
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

            if (response.StatusCode == 402)
            {
                throw new ApiException("Account is not postpaid, or does not have Mobile Landing Pages Enabled.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.GetTemplatesFieldsDefinationresponse>(response.Body);
        }

        /// <summary>
        /// Returns a paginated list of Template.
        /// </summary>
        /// <param name="pageSize">Optional parameter: Page size between 5 and 100 (default 20).</param>
        /// <param name="pageToken">Optional parameter: Token to fetch the next page.</param>
        /// <returns>Returns the Models.GetTemplatesresponse response from the API call.</returns>
        public Models.GetTemplatesresponse GetTemplates(
                string pageSize = null,
                string pageToken = null)
        {
            Task<Models.GetTemplatesresponse> t = this.GetTemplatesAsync(pageSize, pageToken);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a paginated list of Template.
        /// </summary>
        /// <param name="pageSize">Optional parameter: Page size between 5 and 100 (default 20).</param>
        /// <param name="pageToken">Optional parameter: Token to fetch the next page.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetTemplatesresponse response from the API call.</returns>
        public async Task<Models.GetTemplatesresponse> GetTemplatesAsync(
                string pageSize = null,
                string pageToken = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/beta/smsplus/templates");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "page_size", pageSize },
                { "page_token", pageToken },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 402)
            {
                throw new ApiException("", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.GetTemplatesresponse>(response.Body);
        }

        /// <summary>
        /// Sends a campaign message to a group of recipients.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.SendCampaignToRecipientsresponse response from the API call.</returns>
        public Models.SendCampaignToRecipientsresponse SendCampaignToRecipients(
                string id,
                Models.BetaSmsplusCampaignsRecipientsRequest body = null)
        {
            Task<Models.SendCampaignToRecipientsresponse> t = this.SendCampaignToRecipientsAsync(id, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Sends a campaign message to a group of recipients.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SendCampaignToRecipientsresponse response from the API call.</returns>
        public async Task<Models.SendCampaignToRecipientsresponse> SendCampaignToRecipientsAsync(
                string id,
                Models.BetaSmsplusCampaignsRecipientsRequest body = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/beta/smsplus/campaigns/{id}/recipients");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

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

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.SendCampaignToRecipientsresponse>(response.Body);
        }

        /// <summary>
        /// The reporting endpoint provides access to the reporting analytics.
        /// ### Events Types.
        /// The campaign report consists of a series of events, that were generated by recipients when.
        /// interacting with the generated mobile landing page.  The set of events that are currently supported.
        /// are as follows:.
        /// | Event Type        | Event Source | Description                                    |.
        /// |:------------------|:-------------|:-----------------------------------------------|.
        /// | `PAGE_OPEN`       | n/a          | The page was opened in a browser.              |.
        /// | `BUTTON_CLICKED`  | Button label | One of the Call to Action buttons was clicked. |.
        /// | `FORM_SUBMITTED`  | n/a          | A form has been submitted with the captured data stored in the 'data' field. |Produces an unpaginated CSV file of events that have occurred for a particular campaign and emails them to the specified address(es).
        /// At this stage, the events are returned in reverse chronological order.
        /// </summary>
        /// <param name="campaignId">Required parameter: The campaign ID.</param>
        public void ExportCampaignEventsAsync(
                string campaignId)
        {
            Task t = this.ExportCampaignEventsAsyncAsync(campaignId);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// The reporting endpoint provides access to the reporting analytics.
        /// ### Events Types.
        /// The campaign report consists of a series of events, that were generated by recipients when.
        /// interacting with the generated mobile landing page.  The set of events that are currently supported.
        /// are as follows:.
        /// | Event Type        | Event Source | Description                                    |.
        /// |:------------------|:-------------|:-----------------------------------------------|.
        /// | `PAGE_OPEN`       | n/a          | The page was opened in a browser.              |.
        /// | `BUTTON_CLICKED`  | Button label | One of the Call to Action buttons was clicked. |.
        /// | `FORM_SUBMITTED`  | n/a          | A form has been submitted with the captured data stored in the 'data' field. |Produces an unpaginated CSV file of events that have occurred for a particular campaign and emails them to the specified address(es).
        /// At this stage, the events are returned in reverse chronological order.
        /// </summary>
        /// <param name="campaignId">Required parameter: The campaign ID.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ExportCampaignEventsAsyncAsync(
                string campaignId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/beta/smsplus/reporting/{campaign_id}/events/async");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "campaign_id", campaignId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
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

            if (response.StatusCode == 402)
            {
                throw new ApiException("", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }
    }
}