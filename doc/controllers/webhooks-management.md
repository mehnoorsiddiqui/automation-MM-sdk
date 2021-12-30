# Webhooks Management

Webhooks Management API allows you to manage your webhooks configuration. You can subscribe to one or several events, retrieve the webhooks, update them or even delete them if needed.

`Create a webhook` for one or more of the specified events.

#### Types of Events

You can select all of the events (listed below) or combine them in whatever way you like but atleast one event must be used. Otherwise, the webhook won't be created.

A webhook will be triggered when any one or more of the events occur:

+ **SMS**

+ `RECEIVED_SMS` Receive an SMS

+ `OPT_OUT_SMS` Opt-out occured

+ **MMS**

+ `RECEIVED_MMS` Receive an MMS

+ **DR (Delivery Reports)**

+ `ENROUTE_DR` Message is enroute

+ `EXPIRED_DR` Message has expired

+ `REJECTED_DR` Message is rejected

+ `FAILED_DR` Message has failed

+ `DELIVERED_DR` Message is delivered

+ `SUBMITTED_DR` Message is submitted

#### Template Parameters

You can choose what to include in the data that will be sent as the payload via the Webhook. It's upto you to choose what format you would like the payload to be returned. You can choose between JSON or XML.

Keep in my mind, if you've chosen JSON as the format, you must escape the JSON in the template value (see example above).

The table illustrates a list of all the parameters that can be included in the template and which event types it can be applied to.

| Data  | Parameter Name | Example | Event Type |
|:--|--|--|--:|
| **Service Type**  | $type| `SMS` | `DR` `MO` `MO MMS` |
| **Message ID**  | $mtId, $messageId| `877c19ef-fa2e-4cec-827a-e1df9b5509f7` | `DR` `MO` `MO MMS`|
| **Delivery Report ID** |$drId, $reportId| `01e1fa0a-6e27-4945-9cdb-18644b4de043` | `DR` |
| **Reply ID**| $moId, $replyId| `a175e797-2b54-468b-9850-41a3eab32f74` | `MO` `MO MMS` |
| **Account ID**  | $accountId| `DeveloperPortal7000` | `DR` `MO` `MO MMS` |
| **Message Timestamp**  | $submittedTimestamp| `2016-12-07T08:43:00.850Z` | `DR` `MO` `MO MMS` |
| **Provider Timestamp**  | $receivedTimestamp| `2016-12-07T08:44:00.850Z` | `DR` `MO` `MO MMS` |
| **Message Status** | $status| `enroute` | `DR` |
| **Status Code**  | $statusCode| `200` | `DR` |
| **External Metadata** | $metadata.get('key')| `name` | `DR` `MO` `MO MMS` |
| **Source Address**| $sourceAddress| `+61491570156` | `DR` `MO` `MO MMS` |
| **Destination Address**| $destinationAddress| `+61491593156` | `MO` `MO MMS` |
| **Message Content**| $mtContent, $messageContent| `Hi Derp` | `DR` `MO` `MO MMS` |
| **Reply Content**| $moContent, $replyContent| `Hello Derpina` | `MO` `MO MMS` |
| **Retry Count**| $retryCount| `1` | `DR` `MO` `MO MMS` |

```csharp
WebhooksManagementController webhooksManagementController = client.WebhooksManagementController;
```

## Class Name

`WebhooksManagementController`

## Methods

* [Retrieve Webhook](/doc/controllers/webhooks-management.md#retrieve-webhook)
* [Create Webhook](/doc/controllers/webhooks-management.md#create-webhook)
* [Delete Webhook](/doc/controllers/webhooks-management.md#delete-webhook)
* [Update Webhook](/doc/controllers/webhooks-management.md#update-webhook)


# Retrieve Webhook

Retrieve all the webhooks created for the connected account.

```csharp
RetrieveWebhookAsync(
    int? page = null,
    int? pageSize = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | `int?` | Query, Optional | - |
| `pageSize` | `int?` | Query, Optional | - |

## Response Type

`Task<object>`

## Example Usage

```csharp
try
{
    object result = await webhooksManagementController.RetrieveWebhookAsync(null, null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Unexpected error in API call. See HTTP response body for details. | [`UpdateWebhook400responseException`](/doc/models/update-webhook-400-response-exception.md) |


# Create Webhook

Create a webhook for one or more of the specified events.

```csharp
CreateWebhookAsync(
    Models.CreateWebhookrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateWebhookrequest`](/doc/models/create-webhookrequest.md) | Body, Required | - |

## Response Type

`Task<object>`

## Example Usage

```csharp
var body = new CreateWebhookrequest();
body.Url = "http://webhook.com";
body.Method = "POST";
body.Encoding = "JSON";
body.Headers = new Headers();
body.Headers.Account = "DeveloperPortal7000";
body.Events = new List<string>();
body.Events.Add("ENROUTE_DR");
body.Template = "{\"id\":\"$mtId\",\"status\":\"$statusCode\"}";

try
{
    object result = await webhooksManagementController.CreateWebhookAsync(body);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Unexpected error in API call. See HTTP response body for details. | [`UpdateWebhook400responseException`](/doc/models/update-webhook-400-response-exception.md) |
| 409 | Unexpected error in API call. See HTTP response body for details. | [`UpdateWebhook400responseException`](/doc/models/update-webhook-400-response-exception.md) |


# Delete Webhook

Delete a webhook that was previously created for the connected account.
A webhook can be cancelled by appending the UUID of the webhook to the endpoint and submitting a DELETE request to the /webhooks/messages endpoint.

```csharp
DeleteWebhookAsync(
    Guid webhookId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `webhookId` | `Guid` | Template, Required | - |

## Response Type

`Task`

## Example Usage

```csharp
Guid webhookId = new Guid("a7f11bb0-f299-4861-a5ca-9b29d04bc5ad");

try
{
    await webhooksManagementController.DeleteWebhookAsync(webhookId);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 404 | - | `ApiException` |


# Update Webhook

Update a webhook. You can update individual attributes or all of them by submitting a PATCH request to the /webhooks/messages endpoint (the same endpoint used above to delete a webhook)

```csharp
UpdateWebhookAsync(
    Guid webhookId,
    Models.UpdateWebhookrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `webhookId` | `Guid` | Template, Required | - |
| `body` | [`Models.UpdateWebhookrequest`](/doc/models/update-webhookrequest.md) | Body, Required | - |

## Response Type

`Task<object>`

## Example Usage

```csharp
Guid webhookId = new Guid("a7f11bb0-f299-4861-a5ca-9b29d04bc5ad");
var body = new UpdateWebhookrequest();
body.Url = "https://myurl.com";
body.Method = "POST";
body.Encoding = "FORM_ENCODED";
body.Events = new List<string>();
body.Events.Add("ENROUTE_DR");
body.Template = "{\"id\":\"$mtId\", \"status\":\"$statusCode\"}";

try
{
    object result = await webhooksManagementController.UpdateWebhookAsync(webhookId, body);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Unexpected error in API call. See HTTP response body for details. | [`UpdateWebhook400responseException`](/doc/models/update-webhook-400-response-exception.md) |
| 404 | - | `ApiException` |

