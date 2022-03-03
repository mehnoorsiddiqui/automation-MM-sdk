# Messaging Reports

The MessageMedia Reports API provides a number of endpoints for running reports of messages sent and received using Messages API.  Reports can be detailed, a list of all messages and details of each message, or summary reports, which can be aggregated on a number of dimensions.

Below is the detail of some parameters of Reports API.

-`end_date`: End date time for report window. By default, the timezone for this parameter will be taken from the account settings for the account associated with the credentials used to make the request, or the account included in the Account parameter. This can be overridden using the timezone parameter per request. The date must be in ISO8601 format.

-`start_date` : Start date time for report window. By default, the timezone for this parameter will be taken from the account settings for the account associated with the credentials used to make the request, or the account included in the Account parameter. This can be overridden using the timezone parameter per request. The date must be in ISO8601 format.

-`timezone` : The timezone to use for the context of the request. If provided this will be used as the timezone for the start date and end date parameters, and all datetime fields returns in the response. The timezone should be provided as a IANA (Internet Assigned Numbers Authority) time zone database zone name, i.e., 'Australia/Melbourne'.

-`accounts` : Filter results by a specific account. By default results will be returned for the account associated with the authentication credentials and all sub accounts.

```csharp
MessagingReportsController messagingReportsController = client.MessagingReportsController;
```

## Class Name

`MessagingReportsController`

## Methods

* [Get Async Report Data by Id](../../doc/controllers/messaging-reports.md#get-async-report-data-by-id)
* [Submit Received Messages Detail](../../doc/controllers/messaging-reports.md#submit-received-messages-detail)
* [Get Received Messages Summary](../../doc/controllers/messaging-reports.md#get-received-messages-summary)
* [Get Async Report by Id](../../doc/controllers/messaging-reports.md#get-async-report-by-id)
* [Get Sent Messages Detail](../../doc/controllers/messaging-reports.md#get-sent-messages-detail)
* [Submit Sent Messages Summary](../../doc/controllers/messaging-reports.md#submit-sent-messages-summary)
* [Get Sent Messages Summary](../../doc/controllers/messaging-reports.md#get-sent-messages-summary)
* [Get Metadata Keys](../../doc/controllers/messaging-reports.md#get-metadata-keys)
* [Get Async Reports](../../doc/controllers/messaging-reports.md#get-async-reports)
* [Get Received Messages Detail](../../doc/controllers/messaging-reports.md#get-received-messages-detail)
* [Submit Sent Messages Detail](../../doc/controllers/messaging-reports.md#submit-sent-messages-detail)
* [Submit Received Messages Summary](../../doc/controllers/messaging-reports.md#submit-received-messages-summary)


# Get Async Report Data by Id

Gets the data of an asynchronous report.

```csharp
GetAsyncReportDataByIdAsync(
    string reportId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `reportId` | `string` | Template, Required | Unique ID of the async report |

## Response Type

`Task<Stream>`

## Example Usage

```csharp
string reportId = "report_id2";

try
{
    Stream result = await messagingReportsController.GetAsyncReportDataByIdAsync(reportId);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Check the json response for more details on what went wrong. | `ApiException` |
| 404 | Report not found or not finished. | `ApiException` |


# Submit Received Messages Detail

Submits a request to generate an async detail report

```csharp
SubmitReceivedMessagesDetailAsync(
    Models.Asyncreceivedmessagesdetailrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.Asyncreceivedmessagesdetailrequest`](../../doc/models/asyncreceivedmessagesdetailrequest.md) | Body, Required | - |

## Response Type

[`Task<Models.AsyncReportResponse>`](../../doc/models/async-report-response.md)

## Example Usage

```csharp
var body = new Asyncreceivedmessagesdetailrequest();
body.Period = PeriodEnum.THISWEEK;
body.SortBy = SortByEnum.ACCOUNT;
body.SortDirection = SortDirectionEnum.ASCENDING;

try
{
    AsyncReportResponse result = await messagingReportsController.SubmitReceivedMessagesDetailAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "id": "b8ffd5b3-050a-46b9-9192-fbd7c20a22ec"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Check the json response for more details on what went wrong. | `ApiException` |


# Get Received Messages Summary

Returns a summarised report of messages received

```csharp
GetReceivedMessagesSummaryAsync(
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
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `endDate` | `string` | Query, Required | End date time for report window. |
| `startDate` | `string` | Query, Required | Start date time for report window. |
| `groupBy` | [`Models.GroupByEnum`](../../doc/models/group-by-enum.md) | Query, Required | List of fields to group results set by{array} |
| `accounts` | `List<string>` | Query, Optional | Filter results by a specific account. |
| `destinationAddressCountry` | `string` | Query, Optional | Filter results by destination address country. |
| `destinationAddress` | `string` | Query, Optional | Filter results by destination address. |
| `messageFormat` | [`Models.Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Filter results by message format. |
| `metadataKey` | `string` | Query, Optional | Filter results for messages that include a metadata key. |
| `metadataValue` | `string` | Query, Optional | Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided. |
| `summaryBy` | [`Models.SummaryByEnum?`](../../doc/models/summary-by-enum.md) | Query, Optional | Function to apply when summarising results |
| `summaryField` | [`Models.SummaryFieldEnum?`](../../doc/models/summary-field-enum.md) | Query, Optional | Field to summarise results by |
| `sourceAddressCountry` | `string` | Query, Optional | Filter results by source address country. |
| `sourceAddress` | `string` | Query, Optional | Filter results by source address. |
| `timezone` | `string` | Query, Optional | The timezone to use for the context of the request. |

## Response Type

[`Task<Models.SummaryReport>`](../../doc/models/summary-report.md)

## Example Usage

```csharp
string endDate = "11/28/2021 13:30:00";
string startDate = "11/11/2021 13:30:00";
GroupByEnum groupBy = GroupByEnum.DAY;
Format1Enum? messageFormat = Format1Enum.MMS;
SummaryByEnum? summaryBy = SummaryByEnum.COUNT;
SummaryFieldEnum? summaryField = SummaryFieldEnum.UNITS;

try
{
    SummaryReport result = await messagingReportsController.GetReceivedMessagesSummaryAsync(endDate, startDate, groupBy, null, null, null, messageFormat, null, null, summaryBy, summaryField, null, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "properties": {
    "end_date": "2017-02-10T13:30:00.000Z",
    "start_date": "2017-02-12T13:30:00.000Z",
    "timezone": "The timezone that this report is presented in, this may be passed in as a parameter to the report, or taken from account settings"
  },
  "data": [
    {}
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Check the json response for more details on what went wrong. | `ApiException` |
| 501 | The group_by combination is not currently implemented | `ApiException` |


# Get Async Report by Id

Gets a single asynchronous report.

```csharp
GetAsyncReportByIdAsync(
    string reportId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `reportId` | `string` | Template, Required | Unique ID of the async report |

## Response Type

[`Task<Models.AsyncReport>`](../../doc/models/async-report.md)

## Example Usage

```csharp
string reportId = "report_id2";

try
{
    AsyncReport result = await messagingReportsController.GetAsyncReportByIdAsync(reportId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "created_datetime": "2017-02-12T13:30:00.000Z",
  "last_modified_datetime": "2017-02-12T13:30:00.000Z"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Check the json response for more details on what went wrong. | `ApiException` |
| 404 | The requested report was not found. | `ApiException` |


# Get Sent Messages Detail

Returns a list of message sent

```csharp
GetSentMessagesDetailAsync(
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
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `endDate` | `string` | Query, Required | End date time for report window. |
| `startDate` | `string` | Query, Required | Start date time for report window. |
| `accounts` | `List<string>` | Query, Optional | Filter results by a specific account. |
| `deliveryReport` | `bool?` | Query, Optional | Filter results by delivery report. |
| `destinationAddressCountry` | `string` | Query, Optional | Filter results by destination address country. |
| `destinationAddress` | `string` | Query, Optional | Filter results by destination address. |
| `messageFormat` | [`Models.Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Filter results by message format. |
| `metadataKey` | `string` | Query, Optional | Filter results for messages that include a metadata key. |
| `metadataValue` | `string` | Query, Optional | Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided. |
| `statusCode` | `string` | Query, Optional | Filter results by message status code. |
| `status` | [`Models.Status1Enum?`](../../doc/models/status-1-enum.md) | Query, Optional | Filter results by message status. Can't be combined with statuses. |
| `statuses` | [`Models.StatusesEnum?`](../../doc/models/statuses-enum.md) | Query, Optional | Filter results by message status. Can't be combined with status.{array} |
| `page` | `double?` | Query, Optional | Page number for paging through paginated result sets. |
| `pageSize` | `double?` | Query, Optional | Number of results to return in a page for paginated result sets. |
| `sortBy` | [`Models.SortByEnum?`](../../doc/models/sort-by-enum.md) | Query, Optional | Field to sort results set by |
| `sortDirection` | [`Models.SortDirectionEnum?`](../../doc/models/sort-direction-enum.md) | Query, Optional | Order to sort results by. |
| `sourceAddressCountry` | `string` | Query, Optional | Filter results by source address country. |
| `sourceAddress` | `string` | Query, Optional | Filter results by source address. |
| `timezone` | `string` | Query, Optional | The timezone to use for the context of the request. |

## Response Type

[`Task<Models.SentMessages>`](../../doc/models/sent-messages.md)

## Example Usage

```csharp
string endDate = "11/28/2021 13:30:00";
string startDate = "11/12/2021 13:30:00";
Format1Enum? messageFormat = Format1Enum.MMS;
Status1Enum? status = Status1Enum.CANCELLED;
StatusesEnum? statuses = StatusesEnum.CANCELLED;
SortByEnum? sortBy = SortByEnum.ACCOUNT;
SortDirectionEnum? sortDirection = SortDirectionEnum.ASCENDING;

try
{
    SentMessages result = await messagingReportsController.GetSentMessagesDetailAsync(endDate, startDate, null, null, null, null, messageFormat, null, null, null, status, statuses, null, null, sortBy, sortDirection, null, null, null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Check the json response for more details on what went wrong. | `ApiException` |


# Submit Sent Messages Summary

Submits a summarised report of sent messages

```csharp
SubmitSentMessagesSummaryAsync(
    Models.Asyncsentmessagesrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.Asyncsentmessagesrequest`](../../doc/models/asyncsentmessagesrequest.md) | Body, Required | - |

## Response Type

[`Task<Models.AsyncReportResponse>`](../../doc/models/async-report-response.md)

## Example Usage

```csharp
var body = new Asyncsentmessagesrequest();
body.EndDate = "2021-11-28T13:30:00.000";
body.StartDate = "2021-11-12T13:30:00.000";
body.GroupBy = new List<GroupByEnum>();
body.GroupBy.Add(GroupByEnum.HOUR);

try
{
    AsyncReportResponse result = await messagingReportsController.SubmitSentMessagesSummaryAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "id": "b8ffd5b3-050a-46b9-9192-fbd7c20a22ec"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Check the json response for more details on what went wrong. | `ApiException` |
| 501 | The group_by combination is not currently implemented | `ApiException` |


# Get Sent Messages Summary

Returns a summarised report of messages sent

```csharp
GetSentMessagesSummaryAsync(
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
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `endDate` | `string` | Query, Required | End date time for report window. |
| `startDate` | `string` | Query, Required | Start date time for report window. |
| `groupBy` | [`Models.GroupByEnum`](../../doc/models/group-by-enum.md) | Query, Required | List of fields to group results set by{array} |
| `accounts` | `List<string>` | Query, Optional | Filter results by a specific account. By default results<br><br>will be returned for the account associated with the authentication<br><br>credentials and all sub accounts. |
| `deliveryReport` | `bool?` | Query, Optional | Filter results by delivery report. |
| `destinationAddressCountry` | `string` | Query, Optional | Filter results by destination address country. |
| `destinationAddress` | `string` | Query, Optional | Filter results by destination address. |
| `summaryBy` | [`Models.SummaryByEnum?`](../../doc/models/summary-by-enum.md) | Query, Optional | Function to apply when summarising results |
| `summaryField` | [`Models.SummaryFieldEnum?`](../../doc/models/summary-field-enum.md) | Query, Optional | Field to summarise results by |
| `messageFormat` | [`Models.Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Filter results by message format. |
| `metadataKey` | `string` | Query, Optional | Filter results for messages that include a metadata key. |
| `metadataValue` | `string` | Query, Optional | Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided. |
| `statusCode` | `string` | Query, Optional | Filter results by message status code. |
| `sourceAddressCountry` | `string` | Query, Optional | Filter results by source address country. |
| `sourceAddress` | `string` | Query, Optional | Filter results by source address. |
| `timezone` | `string` | Query, Optional | The timezone to use for the context of the request. |

## Response Type

[`Task<Models.SummaryReport>`](../../doc/models/summary-report.md)

## Example Usage

```csharp
string endDate = "11/28/2021 13:30:00";
string startDate = "11/12/2021 13:30:00";
GroupByEnum groupBy = GroupByEnum.DAY;
SummaryByEnum? summaryBy = SummaryByEnum.COUNT;
SummaryFieldEnum? summaryField = SummaryFieldEnum.UNITS;
Format1Enum? messageFormat = Format1Enum.MMS;

try
{
    SummaryReport result = await messagingReportsController.GetSentMessagesSummaryAsync(endDate, startDate, groupBy, null, null, null, null, summaryBy, summaryField, messageFormat, null, null, null, null, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "properties": {
    "end_date": "2017-02-10T13:30:00.000Z",
    "start_date": "2017-02-12T13:30:00.000Z",
    "timezone": "The timezone that this report is presented in, this may be passed in as a parameter to the report, or taken from account settings"
  },
  "data": [
    {}
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Check the json response for more details on what went wrong. | `ApiException` |
| 501 | The group_by combination is not currently implemented | `ApiException` |


# Get Metadata Keys

Returns a list of metadata keys

```csharp
GetMetadataKeysAsync(
    Models.MessageTypeEnum messageType,
    string startDate,
    string endDate,
    List<string> accounts = null,
    string timezone = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `messageType` | [`Models.MessageTypeEnum`](../../doc/models/message-type-enum.md) | Template, Required | Message type. Possible values are sent messages and received messages. |
| `startDate` | `string` | Query, Required | Start date time for report window. |
| `endDate` | `string` | Query, Required | End date time for report window. |
| `accounts` | `List<string>` | Query, Optional | Filter results by a specific account. |
| `timezone` | `string` | Query, Optional | The timezone to use for the context of the request. |

## Response Type

[`Task<Models.MetadataKeysResponse>`](../../doc/models/metadata-keys-response.md)

## Example Usage

```csharp
MessageTypeEnum messageType = MessageTypeEnum.SENTMESSAGES;
string startDate = "02/10/2017 13:30:00";
string endDate = "02/12/2017 13:30:00";

try
{
    MetadataKeysResponse result = await messagingReportsController.GetMetadataKeysAsync(messageType, startDate, endDate, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "data": [],
  "properties": {
    "end_date": "2017-02-10T13:30:00.000Z",
    "start_date": "2017-02-12T13:30:00.000Z",
    "accounts": []
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Check the json response for more details on what went wrong. | `ApiException` |


# Get Async Reports

Lists asynchronous reports.

```csharp
GetAsyncReportsAsync(
    double? page = null,
    double? pageSize = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | `double?` | Query, Optional | Page number for paging through paginated result sets. |
| `pageSize` | `double?` | Query, Optional | Number of results to return in a page for paginated result sets. |

## Response Type

[`Task<Models.GetAsyncReportsResponse>`](../../doc/models/get-async-reports-response.md)

## Example Usage

```csharp
try
{
    GetAsyncReportsResponse result = await messagingReportsController.GetAsyncReportsAsync(null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "data": [
    {
      "created_datetime": "2017-02-12T13:30:00.000Z",
      "last_modified_datetime": "2017-02-12T13:30:00.000Z"
    }
  ],
  "pagination": {}
}
```


# Get Received Messages Detail

Returns a list message received

```csharp
GetReceivedMessagesDetailAsync(
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
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `endDate` | `string` | Query, Required | End date time for report window. |
| `startDate` | `string` | Query, Required | Start date time for report window. |
| `accounts` | `List<string>` | Query, Optional | Filter results by a specific account. |
| `action` | [`Models.ActionEnum?`](../../doc/models/action-enum.md) | Query, Optional | Filter results by the action that was invoked for this message. |
| `destinationAddressCountry` | `string` | Query, Optional | Filter results by destination address country. |
| `destinationAddress` | `string` | Query, Optional | Filter results by destination address. |
| `messageFormat` | [`Models.Format1Enum?`](../../doc/models/format-1-enum.md) | Query, Optional | Filter results by message format. |
| `metadataKey` | `string` | Query, Optional | Filter results for messages that include a metadata key. |
| `metadataValue` | `string` | Query, Optional | Filter results for messages that include a metadata key containing this value. If this parameter is provided, the metadata_key parameter must also be provided. |
| `page` | `double?` | Query, Optional | Page number for paging through paginated result sets. |
| `pageSize` | `double?` | Query, Optional | Number of results to return in a page for paginated result sets. |
| `sortBy` | [`Models.SortByEnum?`](../../doc/models/sort-by-enum.md) | Query, Optional | Field to sort results set by |
| `sortDirection` | [`Models.SortDirectionEnum?`](../../doc/models/sort-direction-enum.md) | Query, Optional | Order to sort results by. |
| `sourceAddressCountry` | `string` | Query, Optional | Filter results by source address country. |
| `sourceAddress` | `string` | Query, Optional | Filter results by source address. |
| `timezone` | `string` | Query, Optional | The timezone to use for the context of the request. |

## Response Type

[`Task<Models.ReceivedMessages>`](../../doc/models/received-messages.md)

## Example Usage

```csharp
string endDate = "11/28/2021 13:30:00";
string startDate = "11/12/2021 13:30:00";
ActionEnum? action = ActionEnum.MyAccount001;
Format1Enum? messageFormat = Format1Enum.MMS;
SortByEnum? sortBy = SortByEnum.ACCOUNT;
SortDirectionEnum? sortDirection = SortDirectionEnum.ASCENDING;

try
{
    ReceivedMessages result = await messagingReportsController.GetReceivedMessagesDetailAsync(endDate, startDate, null, action, null, null, messageFormat, null, null, null, null, sortBy, sortDirection, null, null, null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Check the json response for more details on what went wrong. | `ApiException` |


# Submit Sent Messages Detail

Submits a request to generate an async detail report

```csharp
SubmitSentMessagesDetailAsync(
    Models.Asyncsentmessagesdetailrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.Asyncsentmessagesdetailrequest`](../../doc/models/asyncsentmessagesdetailrequest.md) | Body, Required | - |

## Response Type

[`Task<Models.AsyncReportResponse>`](../../doc/models/async-report-response.md)

## Example Usage

```csharp
var body = new Asyncsentmessagesdetailrequest();
body.EndDate = "2017-02-10T13:30:00.000";
body.StartDate = "2017-02-12T13:30:00.000";
body.SortBy = SortByEnum.ACCOUNT;
body.SortDirection = SortDirectionEnum.ASCENDING;

try
{
    AsyncReportResponse result = await messagingReportsController.SubmitSentMessagesDetailAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "id": "b8ffd5b3-050a-46b9-9192-fbd7c20a22ec"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Check the json response for more details on what went wrong. | `ApiException` |


# Submit Received Messages Summary

Submits a summarised report of received messages

```csharp
SubmitReceivedMessagesSummaryAsync(
    Models.Asyncreceivedmessagessummaryrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.Asyncreceivedmessagessummaryrequest`](../../doc/models/asyncreceivedmessagessummaryrequest.md) | Body, Required | - |

## Response Type

[`Task<Models.AsyncReportResponse>`](../../doc/models/async-report-response.md)

## Example Usage

```csharp
var body = new Asyncreceivedmessagessummaryrequest();
body.EndDate = "2021-11-28T13:30:00.000";
body.StartDate = "2021-11-12T13:30:00.000";
body.SummaryBy = SummaryByEnum.COUNT;
body.SummaryField = SummaryFieldEnum.MESSAGEID;
body.GroupBy = new List<GroupByEnum>();
body.GroupBy.Add(GroupByEnum.DAY);

try
{
    AsyncReportResponse result = await messagingReportsController.SubmitReceivedMessagesSummaryAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "id": "b8ffd5b3-050a-46b9-9192-fbd7c20a22ec"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request. Check the json response for more details on what went wrong. | `ApiException` |
| 501 | The group_by combination is not currently implemented | `ApiException` |

