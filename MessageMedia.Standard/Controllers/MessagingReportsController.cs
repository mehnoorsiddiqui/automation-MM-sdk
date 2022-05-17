// <copyright file="MessagingReportsController.cs" company="APIMatic">
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
    /// MessagingReportsController.
    /// </summary>
    public class MessagingReportsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingReportsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal MessagingReportsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Gets the data of an asynchronous report.
        /// </summary>
        /// <param name="reportId">Required parameter: Unique ID of the async report.</param>
        /// <returns>Returns the Stream response from the API call.</returns>
        public Stream GetAsyncReportDataById(
                string reportId)
        {
            Task<Stream> t = this.GetAsyncReportDataByIdAsync(reportId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Gets the data of an asynchronous report.
        /// </summary>
        /// <param name="reportId">Required parameter: Unique ID of the async report.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Stream response from the API call.</returns>
        public async Task<Stream> GetAsyncReportDataByIdAsync(
                string reportId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/async_reports/{report_id}/data");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "report_id", reportId },
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
            HttpResponse response = await this.GetClientInstance().ExecuteAsBinaryAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ApiException("Bad Request. Check the json response for more details on what went wrong.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Report not found or not finished.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return response.RawBody;
        }

        /// <summary>
        /// Submits a request to generate an async detail report.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.AsyncReportResponse response from the API call.</returns>
        public Models.AsyncReportResponse SubmitReceivedMessagesDetail(
                Models.Asyncreceivedmessagesdetailrequest body)
        {
            Task<Models.AsyncReportResponse> t = this.SubmitReceivedMessagesDetailAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Submits a request to generate an async detail report.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AsyncReportResponse response from the API call.</returns>
        public async Task<Models.AsyncReportResponse> SubmitReceivedMessagesDetailAsync(
                Models.Asyncreceivedmessagesdetailrequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/received_messages/detail/async");

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

            if (response.StatusCode == 400)
            {
                throw new ApiException("Bad Request. Check the json response for more details on what went wrong.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.AsyncReportResponse>(response.Body);
        }

        /// <summary>
        /// Returns a summarised report of messages received.
        /// </summary>
        /// <param name="endDate">Required parameter: End date time for report window..</param>
        /// <param name="startDate">Required parameter: Start date time for report window..</param>
        /// <param name="groupBy">Required parameter: List of fields to group results set by{array}.</param>
        /// <param name="accounts">Optional parameter: Filter results by a specific account..</param>
        /// <param name="destinationAddressCountry">Optional parameter: Filter results by destination address country..</param>
        /// <param name="destinationAddress">Optional parameter: Filter results by destination address..</param>
        /// <param name="messageFormat">Optional parameter: Filter results by message format..</param>
        /// <param name="metadataKey">Optional parameter: Filter results for messages that include a metadata key..</param>
        /// <param name="metadataValue">Optional parameter: Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided..</param>
        /// <param name="summaryBy">Optional parameter: Function to apply when summarising results.</param>
        /// <param name="summaryField">Optional parameter: Field to summarise results by.</param>
        /// <param name="sourceAddressCountry">Optional parameter: Filter results by source address country..</param>
        /// <param name="sourceAddress">Optional parameter: Filter results by source address..</param>
        /// <param name="timezone">Optional parameter: The timezone to use for the context of the request..</param>
        /// <returns>Returns the Models.SummaryReport response from the API call.</returns>
        public Models.SummaryReport GetReceivedMessagesSummary(
                string endDate,
                string startDate,
                Models.GroupByEnum groupBy,
                List<string> accounts = null,
                string destinationAddressCountry = null,
                string destinationAddress = null,
                Models.Format1Enum? messageFormat = null,
                string metadataKey = null,
                string metadataValue = null,
                Models.SummaryByEnum? summaryBy = null,
                Models.SummaryFieldEnum? summaryField = null,
                string sourceAddressCountry = null,
                string sourceAddress = null,
                string timezone = null)
        {
            Task<Models.SummaryReport> t = this.GetReceivedMessagesSummaryAsync(endDate, startDate, groupBy, accounts, destinationAddressCountry, destinationAddress, messageFormat, metadataKey, metadataValue, summaryBy, summaryField, sourceAddressCountry, sourceAddress, timezone);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a summarised report of messages received.
        /// </summary>
        /// <param name="endDate">Required parameter: End date time for report window..</param>
        /// <param name="startDate">Required parameter: Start date time for report window..</param>
        /// <param name="groupBy">Required parameter: List of fields to group results set by{array}.</param>
        /// <param name="accounts">Optional parameter: Filter results by a specific account..</param>
        /// <param name="destinationAddressCountry">Optional parameter: Filter results by destination address country..</param>
        /// <param name="destinationAddress">Optional parameter: Filter results by destination address..</param>
        /// <param name="messageFormat">Optional parameter: Filter results by message format..</param>
        /// <param name="metadataKey">Optional parameter: Filter results for messages that include a metadata key..</param>
        /// <param name="metadataValue">Optional parameter: Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided..</param>
        /// <param name="summaryBy">Optional parameter: Function to apply when summarising results.</param>
        /// <param name="summaryField">Optional parameter: Field to summarise results by.</param>
        /// <param name="sourceAddressCountry">Optional parameter: Filter results by source address country..</param>
        /// <param name="sourceAddress">Optional parameter: Filter results by source address..</param>
        /// <param name="timezone">Optional parameter: The timezone to use for the context of the request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SummaryReport response from the API call.</returns>
        public async Task<Models.SummaryReport> GetReceivedMessagesSummaryAsync(
                string endDate,
                string startDate,
                Models.GroupByEnum groupBy,
                List<string> accounts = null,
                string destinationAddressCountry = null,
                string destinationAddress = null,
                Models.Format1Enum? messageFormat = null,
                string metadataKey = null,
                string metadataValue = null,
                Models.SummaryByEnum? summaryBy = null,
                Models.SummaryFieldEnum? summaryField = null,
                string sourceAddressCountry = null,
                string sourceAddress = null,
                string timezone = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/received_messages/summary");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "end_date", endDate },
                { "start_date", startDate },
                { "group_by", ApiHelper.JsonSerialize(groupBy).Trim('\"') },
                { "accounts", accounts },
                { "destination_address_country", destinationAddressCountry },
                { "destination_address", destinationAddress },
                { "message_format", (messageFormat.HasValue) ? ApiHelper.JsonSerialize(messageFormat.Value).Trim('\"') : null },
                { "metadata_key", metadataKey },
                { "metadata_value", metadataValue },
                { "summary_by", (summaryBy.HasValue) ? ApiHelper.JsonSerialize(summaryBy.Value).Trim('\"') : null },
                { "summary_field", (summaryField.HasValue) ? ApiHelper.JsonSerialize(summaryField.Value).Trim('\"') : null },
                { "source_address_country", sourceAddressCountry },
                { "source_address", sourceAddress },
                { "timezone", timezone },
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
                throw new ApiException("Bad Request. Check the json response for more details on what went wrong.", context);
            }

            if (response.StatusCode == 501)
            {
                throw new ApiException("The group_by combination is not currently implemented", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.SummaryReport>(response.Body);
        }

        /// <summary>
        /// Gets a single asynchronous report.
        /// </summary>
        /// <param name="reportId">Required parameter: Unique ID of the async report.</param>
        /// <returns>Returns the Models.AsyncReport response from the API call.</returns>
        public Models.AsyncReport GetAsyncReportById(
                string reportId)
        {
            Task<Models.AsyncReport> t = this.GetAsyncReportByIdAsync(reportId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Gets a single asynchronous report.
        /// </summary>
        /// <param name="reportId">Required parameter: Unique ID of the async report.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AsyncReport response from the API call.</returns>
        public async Task<Models.AsyncReport> GetAsyncReportByIdAsync(
                string reportId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/async_reports/{report_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "report_id", reportId },
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
                throw new ApiException("Bad Request. Check the json response for more details on what went wrong.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("The requested report was not found.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.AsyncReport>(response.Body);
        }

        /// <summary>
        /// Returns a list of message sent.
        /// </summary>
        /// <param name="endDate">Required parameter: End date time for report window..</param>
        /// <param name="startDate">Required parameter: Start date time for report window..</param>
        /// <param name="accounts">Optional parameter: Filter results by a specific account..</param>
        /// <param name="deliveryReport">Optional parameter: Filter results by delivery report..</param>
        /// <param name="destinationAddressCountry">Optional parameter: Filter results by destination address country..</param>
        /// <param name="destinationAddress">Optional parameter: Filter results by destination address..</param>
        /// <param name="messageFormat">Optional parameter: Filter results by message format..</param>
        /// <param name="metadataKey">Optional parameter: Filter results for messages that include a metadata key..</param>
        /// <param name="metadataValue">Optional parameter: Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided..</param>
        /// <param name="statusCode">Optional parameter: Filter results by message status code..</param>
        /// <param name="status">Optional parameter: Filter results by message status. Can't be combined with statuses..</param>
        /// <param name="statuses">Optional parameter: Filter results by message status. Can't be combined with status.{array}.</param>
        /// <param name="page">Optional parameter: Page number for paging through paginated result sets..</param>
        /// <param name="pageSize">Optional parameter: Number of results to return in a page for paginated result sets..</param>
        /// <param name="sortBy">Optional parameter: Field to sort results set by.</param>
        /// <param name="sortDirection">Optional parameter: Order to sort results by..</param>
        /// <param name="sourceAddressCountry">Optional parameter: Filter results by source address country..</param>
        /// <param name="sourceAddress">Optional parameter: Filter results by source address..</param>
        /// <param name="timezone">Optional parameter: The timezone to use for the context of the request..</param>
        /// <returns>Returns the Models.SentMessages response from the API call.</returns>
        public Models.SentMessages GetSentMessagesDetail(
                string endDate,
                string startDate,
                List<string> accounts = null,
                bool? deliveryReport = null,
                string destinationAddressCountry = null,
                string destinationAddress = null,
                Models.Format1Enum? messageFormat = null,
                string metadataKey = null,
                string metadataValue = null,
                string statusCode = null,
                Models.Status1Enum? status = null,
                Models.StatusesEnum? statuses = null,
                double? page = null,
                double? pageSize = null,
                Models.SortByEnum? sortBy = null,
                Models.SortDirectionEnum? sortDirection = null,
                string sourceAddressCountry = null,
                string sourceAddress = null,
                string timezone = null)
        {
            Task<Models.SentMessages> t = this.GetSentMessagesDetailAsync(endDate, startDate, accounts, deliveryReport, destinationAddressCountry, destinationAddress, messageFormat, metadataKey, metadataValue, statusCode, status, statuses, page, pageSize, sortBy, sortDirection, sourceAddressCountry, sourceAddress, timezone);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of message sent.
        /// </summary>
        /// <param name="endDate">Required parameter: End date time for report window..</param>
        /// <param name="startDate">Required parameter: Start date time for report window..</param>
        /// <param name="accounts">Optional parameter: Filter results by a specific account..</param>
        /// <param name="deliveryReport">Optional parameter: Filter results by delivery report..</param>
        /// <param name="destinationAddressCountry">Optional parameter: Filter results by destination address country..</param>
        /// <param name="destinationAddress">Optional parameter: Filter results by destination address..</param>
        /// <param name="messageFormat">Optional parameter: Filter results by message format..</param>
        /// <param name="metadataKey">Optional parameter: Filter results for messages that include a metadata key..</param>
        /// <param name="metadataValue">Optional parameter: Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided..</param>
        /// <param name="statusCode">Optional parameter: Filter results by message status code..</param>
        /// <param name="status">Optional parameter: Filter results by message status. Can't be combined with statuses..</param>
        /// <param name="statuses">Optional parameter: Filter results by message status. Can't be combined with status.{array}.</param>
        /// <param name="page">Optional parameter: Page number for paging through paginated result sets..</param>
        /// <param name="pageSize">Optional parameter: Number of results to return in a page for paginated result sets..</param>
        /// <param name="sortBy">Optional parameter: Field to sort results set by.</param>
        /// <param name="sortDirection">Optional parameter: Order to sort results by..</param>
        /// <param name="sourceAddressCountry">Optional parameter: Filter results by source address country..</param>
        /// <param name="sourceAddress">Optional parameter: Filter results by source address..</param>
        /// <param name="timezone">Optional parameter: The timezone to use for the context of the request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SentMessages response from the API call.</returns>
        public async Task<Models.SentMessages> GetSentMessagesDetailAsync(
                string endDate,
                string startDate,
                List<string> accounts = null,
                bool? deliveryReport = null,
                string destinationAddressCountry = null,
                string destinationAddress = null,
                Models.Format1Enum? messageFormat = null,
                string metadataKey = null,
                string metadataValue = null,
                string statusCode = null,
                Models.Status1Enum? status = null,
                Models.StatusesEnum? statuses = null,
                double? page = null,
                double? pageSize = null,
                Models.SortByEnum? sortBy = null,
                Models.SortDirectionEnum? sortDirection = null,
                string sourceAddressCountry = null,
                string sourceAddress = null,
                string timezone = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/sent_messages/detail");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "end_date", endDate },
                { "start_date", startDate },
                { "accounts", accounts },
                { "delivery_report", deliveryReport },
                { "destination_address_country", destinationAddressCountry },
                { "destination_address", destinationAddress },
                { "message_format", (messageFormat.HasValue) ? ApiHelper.JsonSerialize(messageFormat.Value).Trim('\"') : null },
                { "metadata_key", metadataKey },
                { "metadata_value", metadataValue },
                { "status_code", statusCode },
                { "status", (status.HasValue) ? ApiHelper.JsonSerialize(status.Value).Trim('\"') : null },
                { "statuses", (statuses.HasValue) ? ApiHelper.JsonSerialize(statuses.Value).Trim('\"') : null },
                { "page", page },
                { "page_size", pageSize },
                { "sort_by", (sortBy.HasValue) ? ApiHelper.JsonSerialize(sortBy.Value).Trim('\"') : null },
                { "sort_direction", (sortDirection.HasValue) ? ApiHelper.JsonSerialize(sortDirection.Value).Trim('\"') : null },
                { "source_address_country", sourceAddressCountry },
                { "source_address", sourceAddress },
                { "timezone", timezone },
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
                throw new ApiException("Bad Request. Check the json response for more details on what went wrong.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.SentMessages>(response.Body);
        }

        /// <summary>
        /// Submits a summarised report of sent messages.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.AsyncReportResponse response from the API call.</returns>
        public Models.AsyncReportResponse SubmitSentMessagesSummary(
                Models.Asyncsentmessagesrequest body)
        {
            Task<Models.AsyncReportResponse> t = this.SubmitSentMessagesSummaryAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Submits a summarised report of sent messages.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AsyncReportResponse response from the API call.</returns>
        public async Task<Models.AsyncReportResponse> SubmitSentMessagesSummaryAsync(
                Models.Asyncsentmessagesrequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/sent_messages/summary/async");

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

            if (response.StatusCode == 400)
            {
                throw new ApiException("Bad Request. Check the json response for more details on what went wrong.", context);
            }

            if (response.StatusCode == 501)
            {
                throw new ApiException("The group_by combination is not currently implemented", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.AsyncReportResponse>(response.Body);
        }

        /// <summary>
        /// Returns a summarised report of messages sent.
        /// </summary>
        /// <param name="endDate">Required parameter: End date time for report window..</param>
        /// <param name="startDate">Required parameter: Start date time for report window..</param>
        /// <param name="groupBy">Required parameter: List of fields to group results set by{array}.</param>
        /// <param name="accounts">Optional parameter: Filter results by a specific account. By default results  will be returned for the account associated with the authentication  credentials and all sub accounts..</param>
        /// <param name="deliveryReport">Optional parameter: Filter results by delivery report..</param>
        /// <param name="destinationAddressCountry">Optional parameter: Filter results by destination address country..</param>
        /// <param name="destinationAddress">Optional parameter: Filter results by destination address..</param>
        /// <param name="summaryBy">Optional parameter: Function to apply when summarising results.</param>
        /// <param name="summaryField">Optional parameter: Field to summarise results by.</param>
        /// <param name="messageFormat">Optional parameter: Filter results by message format..</param>
        /// <param name="metadataKey">Optional parameter: Filter results for messages that include a metadata key..</param>
        /// <param name="metadataValue">Optional parameter: Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided..</param>
        /// <param name="statusCode">Optional parameter: Filter results by message status code..</param>
        /// <param name="sourceAddressCountry">Optional parameter: Filter results by source address country..</param>
        /// <param name="sourceAddress">Optional parameter: Filter results by source address..</param>
        /// <param name="timezone">Optional parameter: The timezone to use for the context of the request..</param>
        /// <returns>Returns the Models.SummaryReport response from the API call.</returns>
        public Models.SummaryReport GetSentMessagesSummary(
                string endDate,
                string startDate,
                Models.GroupByEnum groupBy,
                List<string> accounts = null,
                bool? deliveryReport = null,
                string destinationAddressCountry = null,
                string destinationAddress = null,
                Models.SummaryByEnum? summaryBy = null,
                Models.SummaryFieldEnum? summaryField = null,
                Models.Format1Enum? messageFormat = null,
                string metadataKey = null,
                string metadataValue = null,
                string statusCode = null,
                string sourceAddressCountry = null,
                string sourceAddress = null,
                string timezone = null)
        {
            Task<Models.SummaryReport> t = this.GetSentMessagesSummaryAsync(endDate, startDate, groupBy, accounts, deliveryReport, destinationAddressCountry, destinationAddress, summaryBy, summaryField, messageFormat, metadataKey, metadataValue, statusCode, sourceAddressCountry, sourceAddress, timezone);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a summarised report of messages sent.
        /// </summary>
        /// <param name="endDate">Required parameter: End date time for report window..</param>
        /// <param name="startDate">Required parameter: Start date time for report window..</param>
        /// <param name="groupBy">Required parameter: List of fields to group results set by{array}.</param>
        /// <param name="accounts">Optional parameter: Filter results by a specific account. By default results  will be returned for the account associated with the authentication  credentials and all sub accounts..</param>
        /// <param name="deliveryReport">Optional parameter: Filter results by delivery report..</param>
        /// <param name="destinationAddressCountry">Optional parameter: Filter results by destination address country..</param>
        /// <param name="destinationAddress">Optional parameter: Filter results by destination address..</param>
        /// <param name="summaryBy">Optional parameter: Function to apply when summarising results.</param>
        /// <param name="summaryField">Optional parameter: Field to summarise results by.</param>
        /// <param name="messageFormat">Optional parameter: Filter results by message format..</param>
        /// <param name="metadataKey">Optional parameter: Filter results for messages that include a metadata key..</param>
        /// <param name="metadataValue">Optional parameter: Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided..</param>
        /// <param name="statusCode">Optional parameter: Filter results by message status code..</param>
        /// <param name="sourceAddressCountry">Optional parameter: Filter results by source address country..</param>
        /// <param name="sourceAddress">Optional parameter: Filter results by source address..</param>
        /// <param name="timezone">Optional parameter: The timezone to use for the context of the request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SummaryReport response from the API call.</returns>
        public async Task<Models.SummaryReport> GetSentMessagesSummaryAsync(
                string endDate,
                string startDate,
                Models.GroupByEnum groupBy,
                List<string> accounts = null,
                bool? deliveryReport = null,
                string destinationAddressCountry = null,
                string destinationAddress = null,
                Models.SummaryByEnum? summaryBy = null,
                Models.SummaryFieldEnum? summaryField = null,
                Models.Format1Enum? messageFormat = null,
                string metadataKey = null,
                string metadataValue = null,
                string statusCode = null,
                string sourceAddressCountry = null,
                string sourceAddress = null,
                string timezone = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/sent_messages/summary");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "end_date", endDate },
                { "start_date", startDate },
                { "group_by", ApiHelper.JsonSerialize(groupBy).Trim('\"') },
                { "accounts", accounts },
                { "delivery_report", deliveryReport },
                { "destination_address_country", destinationAddressCountry },
                { "destination_address", destinationAddress },
                { "summary_by", (summaryBy.HasValue) ? ApiHelper.JsonSerialize(summaryBy.Value).Trim('\"') : null },
                { "summary_field", (summaryField.HasValue) ? ApiHelper.JsonSerialize(summaryField.Value).Trim('\"') : null },
                { "message_format", (messageFormat.HasValue) ? ApiHelper.JsonSerialize(messageFormat.Value).Trim('\"') : null },
                { "metadata_key", metadataKey },
                { "metadata_value", metadataValue },
                { "status_code", statusCode },
                { "source_address_country", sourceAddressCountry },
                { "source_address", sourceAddress },
                { "timezone", timezone },
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
                throw new ApiException("Bad Request. Check the json response for more details on what went wrong.", context);
            }

            if (response.StatusCode == 501)
            {
                throw new ApiException("The group_by combination is not currently implemented", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.SummaryReport>(response.Body);
        }

        /// <summary>
        /// Returns a list of metadata keys.
        /// </summary>
        /// <param name="messageType">Required parameter: Message type. Possible values are sent messages and received messages..</param>
        /// <param name="startDate">Required parameter: Start date time for report window..</param>
        /// <param name="endDate">Required parameter: End date time for report window..</param>
        /// <param name="accounts">Optional parameter: Filter results by a specific account..</param>
        /// <param name="timezone">Optional parameter: The timezone to use for the context of the request..</param>
        /// <returns>Returns the Models.MetadataKeysResponse response from the API call.</returns>
        public Models.MetadataKeysResponse GetMetadataKeys(
                Models.MessageTypeEnum messageType,
                string startDate,
                string endDate,
                List<string> accounts = null,
                string timezone = null)
        {
            Task<Models.MetadataKeysResponse> t = this.GetMetadataKeysAsync(messageType, startDate, endDate, accounts, timezone);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of metadata keys.
        /// </summary>
        /// <param name="messageType">Required parameter: Message type. Possible values are sent messages and received messages..</param>
        /// <param name="startDate">Required parameter: Start date time for report window..</param>
        /// <param name="endDate">Required parameter: End date time for report window..</param>
        /// <param name="accounts">Optional parameter: Filter results by a specific account..</param>
        /// <param name="timezone">Optional parameter: The timezone to use for the context of the request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.MetadataKeysResponse response from the API call.</returns>
        public async Task<Models.MetadataKeysResponse> GetMetadataKeysAsync(
                Models.MessageTypeEnum messageType,
                string startDate,
                string endDate,
                List<string> accounts = null,
                string timezone = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/{messageType}/metadata/keys");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "messageType", ApiHelper.JsonSerialize(messageType).Trim('\"') },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "start_date", startDate },
                { "end_date", endDate },
                { "accounts", accounts },
                { "timezone", timezone },
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
                throw new ApiException("Bad Request. Check the json response for more details on what went wrong.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.MetadataKeysResponse>(response.Body);
        }

        /// <summary>
        /// Lists asynchronous reports.
        /// </summary>
        /// <param name="page">Optional parameter: Page number for paging through paginated result sets..</param>
        /// <param name="pageSize">Optional parameter: Number of results to return in a page for paginated result sets..</param>
        /// <returns>Returns the Models.GetAsyncReportsResponse response from the API call.</returns>
        public Models.GetAsyncReportsResponse GetAsyncReports(
                double? page = null,
                double? pageSize = null)
        {
            Task<Models.GetAsyncReportsResponse> t = this.GetAsyncReportsAsync(page, pageSize);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists asynchronous reports.
        /// </summary>
        /// <param name="page">Optional parameter: Page number for paging through paginated result sets..</param>
        /// <param name="pageSize">Optional parameter: Number of results to return in a page for paginated result sets..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetAsyncReportsResponse response from the API call.</returns>
        public async Task<Models.GetAsyncReportsResponse> GetAsyncReportsAsync(
                double? page = null,
                double? pageSize = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/async_reports");

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

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.GetAsyncReportsResponse>(response.Body);
        }

        /// <summary>
        /// Returns a list message received.
        /// </summary>
        /// <param name="endDate">Required parameter: End date time for report window..</param>
        /// <param name="startDate">Required parameter: Start date time for report window..</param>
        /// <param name="accounts">Optional parameter: Filter results by a specific account..</param>
        /// <param name="action">Optional parameter: Filter results by the action that was invoked for this message..</param>
        /// <param name="destinationAddressCountry">Optional parameter: Filter results by destination address country..</param>
        /// <param name="destinationAddress">Optional parameter: Filter results by destination address..</param>
        /// <param name="messageFormat">Optional parameter: Filter results by message format..</param>
        /// <param name="metadataKey">Optional parameter: Filter results for messages that include a metadata key..</param>
        /// <param name="metadataValue">Optional parameter: Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided..</param>
        /// <param name="page">Optional parameter: Page number for paging through paginated result sets..</param>
        /// <param name="pageSize">Optional parameter: Number of results to return in a page for paginated result sets..</param>
        /// <param name="sortBy">Optional parameter: Field to sort results set by.</param>
        /// <param name="sortDirection">Optional parameter: Order to sort results by..</param>
        /// <param name="sourceAddressCountry">Optional parameter: Filter results by source address country..</param>
        /// <param name="sourceAddress">Optional parameter: Filter results by source address..</param>
        /// <param name="timezone">Optional parameter: The timezone to use for the context of the request..</param>
        /// <returns>Returns the Models.ReceivedMessages response from the API call.</returns>
        public Models.ReceivedMessages GetReceivedMessagesDetail(
                string endDate,
                string startDate,
                List<string> accounts = null,
                Models.ActionEnum? action = null,
                string destinationAddressCountry = null,
                string destinationAddress = null,
                Models.Format1Enum? messageFormat = null,
                string metadataKey = null,
                string metadataValue = null,
                double? page = null,
                double? pageSize = null,
                Models.SortByEnum? sortBy = null,
                Models.SortDirectionEnum? sortDirection = null,
                string sourceAddressCountry = null,
                string sourceAddress = null,
                string timezone = null)
        {
            Task<Models.ReceivedMessages> t = this.GetReceivedMessagesDetailAsync(endDate, startDate, accounts, action, destinationAddressCountry, destinationAddress, messageFormat, metadataKey, metadataValue, page, pageSize, sortBy, sortDirection, sourceAddressCountry, sourceAddress, timezone);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list message received.
        /// </summary>
        /// <param name="endDate">Required parameter: End date time for report window..</param>
        /// <param name="startDate">Required parameter: Start date time for report window..</param>
        /// <param name="accounts">Optional parameter: Filter results by a specific account..</param>
        /// <param name="action">Optional parameter: Filter results by the action that was invoked for this message..</param>
        /// <param name="destinationAddressCountry">Optional parameter: Filter results by destination address country..</param>
        /// <param name="destinationAddress">Optional parameter: Filter results by destination address..</param>
        /// <param name="messageFormat">Optional parameter: Filter results by message format..</param>
        /// <param name="metadataKey">Optional parameter: Filter results for messages that include a metadata key..</param>
        /// <param name="metadataValue">Optional parameter: Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided..</param>
        /// <param name="page">Optional parameter: Page number for paging through paginated result sets..</param>
        /// <param name="pageSize">Optional parameter: Number of results to return in a page for paginated result sets..</param>
        /// <param name="sortBy">Optional parameter: Field to sort results set by.</param>
        /// <param name="sortDirection">Optional parameter: Order to sort results by..</param>
        /// <param name="sourceAddressCountry">Optional parameter: Filter results by source address country..</param>
        /// <param name="sourceAddress">Optional parameter: Filter results by source address..</param>
        /// <param name="timezone">Optional parameter: The timezone to use for the context of the request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ReceivedMessages response from the API call.</returns>
        public async Task<Models.ReceivedMessages> GetReceivedMessagesDetailAsync(
                string endDate,
                string startDate,
                List<string> accounts = null,
                Models.ActionEnum? action = null,
                string destinationAddressCountry = null,
                string destinationAddress = null,
                Models.Format1Enum? messageFormat = null,
                string metadataKey = null,
                string metadataValue = null,
                double? page = null,
                double? pageSize = null,
                Models.SortByEnum? sortBy = null,
                Models.SortDirectionEnum? sortDirection = null,
                string sourceAddressCountry = null,
                string sourceAddress = null,
                string timezone = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/received_messages/detail");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "end_date", endDate },
                { "start_date", startDate },
                { "accounts", accounts },
                { "action", (action.HasValue) ? ApiHelper.JsonSerialize(action.Value).Trim('\"') : null },
                { "destination_address_country", destinationAddressCountry },
                { "destination_address", destinationAddress },
                { "message_format", (messageFormat.HasValue) ? ApiHelper.JsonSerialize(messageFormat.Value).Trim('\"') : null },
                { "metadata_key", metadataKey },
                { "metadata_value", metadataValue },
                { "page", page },
                { "page_size", pageSize },
                { "sort_by", (sortBy.HasValue) ? ApiHelper.JsonSerialize(sortBy.Value).Trim('\"') : null },
                { "sort_direction", (sortDirection.HasValue) ? ApiHelper.JsonSerialize(sortDirection.Value).Trim('\"') : null },
                { "source_address_country", sourceAddressCountry },
                { "source_address", sourceAddress },
                { "timezone", timezone },
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
                throw new ApiException("Bad Request. Check the json response for more details on what went wrong.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ReceivedMessages>(response.Body);
        }

        /// <summary>
        /// Submits a request to generate an async detail report.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.AsyncReportResponse response from the API call.</returns>
        public Models.AsyncReportResponse SubmitSentMessagesDetail(
                Models.Asyncsentmessagesdetailrequest body)
        {
            Task<Models.AsyncReportResponse> t = this.SubmitSentMessagesDetailAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Submits a request to generate an async detail report.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AsyncReportResponse response from the API call.</returns>
        public async Task<Models.AsyncReportResponse> SubmitSentMessagesDetailAsync(
                Models.Asyncsentmessagesdetailrequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/sent_messages/detail/async");

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

            if (response.StatusCode == 400)
            {
                throw new ApiException("Bad Request. Check the json response for more details on what went wrong.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.AsyncReportResponse>(response.Body);
        }

        /// <summary>
        /// Submits a summarised report of received messages.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.AsyncReportResponse response from the API call.</returns>
        public Models.AsyncReportResponse SubmitReceivedMessagesSummary(
                Models.Asyncreceivedmessagessummaryrequest body)
        {
            Task<Models.AsyncReportResponse> t = this.SubmitReceivedMessagesSummaryAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Submits a summarised report of received messages.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AsyncReportResponse response from the API call.</returns>
        public async Task<Models.AsyncReportResponse> SubmitReceivedMessagesSummaryAsync(
                Models.Asyncreceivedmessagessummaryrequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/reporting/received_messages/summary/async");

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

            if (response.StatusCode == 400)
            {
                throw new ApiException("Bad Request. Check the json response for more details on what went wrong.", context);
            }

            if (response.StatusCode == 501)
            {
                throw new ApiException("The group_by combination is not currently implemented", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.AsyncReportResponse>(response.Body);
        }
    }
}