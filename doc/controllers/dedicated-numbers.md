# Dedicated Numbers

The Numbers API allows your to purchase, provision and configure the dedicated numbers assigned to your MessageMedia account.

To learn more about the benefits of dedicated numbers, and their use cases, visit [feature page](../../https://messagemedia.com/au/feature/dedicated-virtual-numbers/).

This is a paid feature and must be enabled on your account. Please contact [support@messagemedia.com](../../support@messagemedia.com) or MessageMedia account manager.

## Concepts

This API allows you to purchase and assign to your account a number from a pool of dedicated numbers. Dedicated numbers are priced differently according to their classification.

The following is the system by which we classify dedicated numbers.

| Pattern Type | Gold|  Silver |
|---|---|---|
| Same Number  |  Six of same (e.g. 999999) | Five of same (e.g. 999991 or 199999)  |
| Sequence  |  Six in sequence (e.g. 234567, or 765432) | Five in sequence (e.g. 245678, 456782, or 287654)  |
|  Triplets |  Two identical (e.g. 123123) or two double (e.g. 444666) | Identical pairs within triplets (e.g. 004008, or 400800), one identical and one in sequence (e.g. 444789, or 345777), or mirror image (e.g. 468864)|
|Pair|Three identical (e.g. 454545)|Three non-identical (e.g. 447700) or three in sequence (e.g. 232425, or 090807)|

Any numbers that do not meet the criteria for Gold or Silver are classified as Bronze.

For pricing on dedicated numbers please refer to the Numbers page in  Hub web portal, or speak with your MessageMedia Account Manager.

```csharp
DedicatedNumbersController dedicatedNumbersController = client.DedicatedNumbersController;
```

## Class Name

`DedicatedNumbersController`

## Methods

* [Get Number by Id](../../doc/controllers/dedicated-numbers.md#get-number-by-id)
* [Get Assignment](../../doc/controllers/dedicated-numbers.md#get-assignment)
* [Create Assignment](../../doc/controllers/dedicated-numbers.md#create-assignment)
* [Delete Assignment](../../doc/controllers/dedicated-numbers.md#delete-assignment)
* [Update Assignment](../../doc/controllers/dedicated-numbers.md#update-assignment)
* [Get Numbers](../../doc/controllers/dedicated-numbers.md#get-numbers)
* [Get Assigned Numbers](../../doc/controllers/dedicated-numbers.md#get-assigned-numbers)


# Get Number by Id

Get details about a specific dedicated number.

```csharp
GetNumberByIdAsync(
    string id,
    string accept)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | unique identifier |
| `accept` | `string` | Header, Required | - |

## Response Type

`Task<object>`

## Example Usage

```csharp
string id = "e2014bc7-5fed-4e27-bd8c-XXXXXXXXXXX";
string accept = "application/json;charset=UTF-8";

try
{
    object result = await dedicatedNumbersController.GetNumberByIdAsync(id, accept);
}
catch (ApiException e){};
```

## Example Response

```
{
  "id": "be3cb602-7c00-4c87-ae4b-b8defc04f179",
  "phone_number": 614111111111,
  "country": "AU",
  "type": "MOBILE",
  "classification": "SILVER",
  "available_after": "2019-06-21T04:04:31.707Z",
  "capabilities": [
    "SMS",
    "MMS"
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`M403responseException`](../../doc/models/m403-response-exception.md) |
| 404 | Unexpected error in API call. See HTTP response body for details. | [`ResourcenotfoundException`](../../doc/models/resourcenotfound-exception.md) |


# Get Assignment

Use this endpoint to view details of the assignment including the label and metadata.

```csharp
GetAssignmentAsync(
    string numberId,
    string accept)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `numberId` | `string` | Template, Required | unique identifier |
| `accept` | `string` | Header, Required | - |

## Response Type

[`Task<Models.Assignment>`](../../doc/models/assignment.md)

## Example Usage

```csharp
string numberId = "e2014bc7-5fed-4e27-bd8c-XXXXXXXXXXX";
string accept = "application/json;charset=UTF-8";

try
{
    Assignment result = await dedicatedNumbersController.GetAssignmentAsync(numberId, accept);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "metadata": {
    "key1": "value1"
  },
  "label": "LabelTest0",
  "id": "be3cb602-7c00-4c87-ae4b-b8defc04f179",
  "number_id": "b9ee3fe8-2c20-47b1-96e9-c5d12d7ed985"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`M403responseException`](../../doc/models/m403-response-exception.md) |
| 404 | Unexpected error in API call. See HTTP response body for details. | [`ResourcenotfoundException`](../../doc/models/resourcenotfound-exception.md) |


# Create Assignment

Assign the specified number to the authenticated account.
Use the body of the request to specify a label or metadata
for this number assignment.

If you receive a *conflict* error then the number that you have selected is unavailable for assignment.
This means that the number is either already assigned to another account,
or has an available_after date in the future. Should this occur, perform
another search and select a different number.

```csharp
CreateAssignmentAsync(
    string numberId,
    string accept,
    Models.CreateAssignmentrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `numberId` | `string` | Template, Required | unique identifier |
| `accept` | `string` | Header, Required | - |
| `body` | [`Models.CreateAssignmentrequest`](../../doc/models/create-assignmentrequest.md) | Body, Required | - |

## Response Type

[`Task<Models.Assignment>`](../../doc/models/assignment.md)

## Example Usage

```csharp
string numberId = "e2014bc7-5fed-4e27-bd8c-XXXXXXXXXXX";
string accept = "application/json;charset=UTF-8";
var body = new CreateAssignmentrequest();
body.Label = "ExampleLabel";
body.Metadata = new Dictionary<string, string>();
body.Metadata.Add("Key1", "value1");
body.Metadata.Add("Key2", "value2");

try
{
    Assignment result = await dedicatedNumbersController.CreateAssignmentAsync(numberId, accept, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "label": "cillum irure",
  "number_id": "et pariatur"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`M403responseException`](../../doc/models/m403-response-exception.md) |
| 404 | Unexpected error in API call. See HTTP response body for details. | [`ResourcenotfoundException`](../../doc/models/resourcenotfound-exception.md) |


# Delete Assignment

Release the dedicated number from your account.

```csharp
DeleteAssignmentAsync(
    string numberId,
    string accept)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `numberId` | `string` | Template, Required | unique identifier |
| `accept` | `string` | Header, Required | - |

## Response Type

`Task<Stream>`

## Example Usage

```csharp
string numberId = "e2014bc7-5fed-4e27-bd8c-XXXXXXXXXXX";
string accept = "application/json;charset=UTF-8";

try
{
    Stream result = await dedicatedNumbersController.DeleteAssignmentAsync(numberId, accept);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`M403responseException`](../../doc/models/m403-response-exception.md) |


# Update Assignment

Retain the dedicated number assignment, and edit or add additional metadata or title information. You can exclude any data from the body of this request that you do not want updated.

```csharp
UpdateAssignmentAsync(
    string numberId,
    string accept,
    Models.UpdateAssignmentrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `numberId` | `string` | Template, Required | unique identifier |
| `accept` | `string` | Header, Required | - |
| `body` | [`Models.UpdateAssignmentrequest`](../../doc/models/update-assignmentrequest.md) | Body, Required | - |

## Response Type

[`Task<Models.Assignment>`](../../doc/models/assignment.md)

## Example Usage

```csharp
string numberId = "e2014bc7-5fed-4e27-bd8c-XXXXXXXXXXX";
string accept = "application/json;charset=UTF-8";
var body = new UpdateAssignmentrequest();
body.Label = "ExampleLabel";
body.Metadata = new Dictionary<string, string>();
body.Metadata.Add("Key1", "value1");
body.Metadata.Add("Key2", "value2");

try
{
    Assignment result = await dedicatedNumbersController.UpdateAssignmentAsync(numberId, accept, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "id": "b06387c0-f4d9-4333-8657-c819bede79c3",
  "number_id": "073fb6bd-f054-4644-aada-8fb204145d77"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`M403responseException`](../../doc/models/m403-response-exception.md) |


# Get Numbers

Get a list of available dedicated numbers, filtered by requirements.

```csharp
GetNumbersAsync(
    string country = null,
    string matching = null,
    int? pageSize = null,
    Models.ServiceTypesEnum? serviceTypes = null,
    string token = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `country` | `string` | Query, Optional | ISO_3166 country code, 2 character code to filter available numbers by country |
| `matching` | `string` | Query, Optional | filters results by a pattern of digits contained within the number |
| `pageSize` | `int?` | Query, Optional | number of results returned per page, default 50 |
| `serviceTypes` | [`Models.ServiceTypesEnum?`](../../doc/models/service-types-enum.md) | Query, Optional | filter results to include numbers with certain capabilities |
| `token` | `string` | Query, Optional | In paginated data the original request will return with a "next_token" attribute. This token must be entered into subsequent call in the "token" query parameter to obtain the next set of records. |

## Response Type

[`Task<Models.NumbersListResponse>`](../../doc/models/numbers-list-response.md)

## Example Usage

```csharp
string country = "AU";
string matching = "223344";
int? pageSize = 3;
ServiceTypesEnum? serviceTypes = ServiceTypesEnum.SMS;
string token = "example";

try
{
    NumbersListResponse result = await dedicatedNumbersController.GetNumbersAsync(country, matching, pageSize, serviceTypes, token);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "pagination": {
    "next_token": "0428d673-0f75-4063-9493-e89d75f13438",
    "page_size": 5
  },
  "data": [
    {
      "id": "03cf54ad-a4a3-4cd1-afd5-e0ca2cf158a3",
      "phone_number": "61436489205",
      "country": "AU",
      "type": "MOBILE",
      "classification": "BRONZE",
      "available_after": "2019-08-06T23:56:15.633Z",
      "capabilities": [
        "SMS"
      ]
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`M403responseException`](../../doc/models/m403-response-exception.md) |


# Get Assigned Numbers

Get assigned numbers

```csharp
GetAssignedNumbersAsync(
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
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `pageSize` | `int?` | Query, Optional | Number of results returned per page, default 50 |
| `token` | `string` | Query, Optional | In paginated data the original request will return with a "next_token" attribute. This token must be entered into subsequent call in the "token" query parameter to obtain the next set of records. |
| `numberId` | `string` | Query, Optional | Unique identifier of a specific number |
| `matching` | `string` | Query, Optional | Filters results by a pattern of digits contained within the number |
| `country` | `string` | Query, Optional | Filter results by ISO_3166 country code, 2 character code to filter available numbers by country |
| `type` | [`Models.Type1Enum?`](../../doc/models/type-1-enum.md) | Query, Optional | Filter results by Number type |
| `classification` | [`Models.ClassificationEnum?`](../../doc/models/classification-enum.md) | Query, Optional | Filter results by Number Classification |
| `serviceTypes` | [`Models.ServiceTypesEnum?`](../../doc/models/service-types-enum.md) | Query, Optional | Filter results by capabilities |
| `label` | `string` | Query, Optional | Filter results by a matching label |
| `sortBy` | [`Models.SortByEnum?`](../../doc/models/sort-by-enum.md) | Query, Optional | Sort results by property |
| `sortDirection` | [`Models.SortDirectionEnum?`](../../doc/models/sort-direction-enum.md) | Query, Optional | Sort direction |

## Response Type

[`Task<Models.AssignedNumberListResponse>`](../../doc/models/assigned-number-list-response.md)

## Example Usage

```csharp
string accept = "application/json;charset=UTF-8";
int? pageSize = 3;
string matching = "223344";
string country = "AU";
Type1Enum? type = Type1Enum.MOBILE;
ClassificationEnum? classification = ClassificationEnum.BRONZE;
ServiceTypesEnum? serviceTypes = ServiceTypesEnum.SMS;
SortByEnum? sortBy = SortByEnum.ACCOUNT;
SortDirectionEnum? sortDirection = SortDirectionEnum.ASCENDING;

try
{
    AssignedNumberListResponse result = await dedicatedNumbersController.GetAssignedNumbersAsync(accept, pageSize, null, null, matching, country, type, classification, serviceTypes, null, sortBy, sortDirection);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unauthorised | [`M403responseException`](../../doc/models/m403-response-exception.md) |

