# Replies

```csharp
RepliesController repliesController = client.RepliesController;
```

## Class Name

`RepliesController`

## Methods

* [Confirm Replies as Received](/doc/controllers/replies.md#confirm-replies-as-received)
* [Check Replies](/doc/controllers/replies.md#check-replies)


# Confirm Replies as Received

Mark a reply message as confirmed so it is no longer returned in check replies requests.

```csharp
ConfirmRepliesAsReceivedAsync(
    Models.Confirmrepliesasreceivedrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.Confirmrepliesasreceivedrequest`](/doc/models/confirmrepliesasreceivedrequest.md) | Body, Required | - |

## Response Type

`Task<object>`

## Example Usage

```csharp
var body = new Confirmrepliesasreceivedrequest();
body.ReplyIds = new List<Guid>();
body.ReplyIds.Add(new Guid("011dcead-6988-4ad6-a1c7-6b6c68ea628d"));
body.ReplyIds.Add(new Guid("3487b3fa-6586-4979-a233-2d1b095c7718"));

try
{
    object result = await repliesController.ConfirmRepliesAsReceivedAsync(body);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad request | [`BadrequestException`](/doc/models/badrequest-exception.md) |
| 403 | Unauthorised | [`M403responseException`](/doc/models/m403-response-exception.md) |
| 404 | Resource not found | [`ResourcenotfoundException`](/doc/models/resourcenotfound-exception.md) |


# Check Replies

Check for any replies that have been received.

*Note: It is recommended to use the Webhooks feature to receive reply messages rather than polling
the check replies endpoint.*

```csharp
CheckRepliesAsync()
```

## Response Type

[`Task<Models.Checkrepliesresponse>`](/doc/models/checkrepliesresponse.md)

## Example Usage

```csharp
try
{
    Checkrepliesresponse result = await repliesController.CheckRepliesAsync();
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "replies": [
    {
      "metadata": {
        "key1": "value1",
        "key2": "value2"
      },
      "message_id": "877c19ef-fa2e-4cec-827a-e1df9b5509f7",
      "reply_id": "a175e797-2b54-468b-9850-41a3eab32f74",
      "date_received": "2016-12-07T08:43:00.850Z",
      "callback_url": "https://my.callback.url.com",
      "destination_number": "+61491570156",
      "source_number": "+61491570157",
      "vendor_account_id": {
        "vendor_id": "MessageMedia",
        "account_id": "MyAccount"
      },
      "content": "My first reply!"
    },
    {
      "metadata": {
        "key1": "value1",
        "key2": "value2"
      },
      "message_id": "8f2f5927-2e16-4f1c-bd43-47dbe2a77ae4",
      "reply_id": "3d8d53d8-01d3-45dd-8cfa-4dfc81600f7f",
      "date_received": "2016-12-07T08:43:00.850Z",
      "callback_url": "https://my.callback.url.com",
      "destination_number": "+61491570157",
      "source_number": "+61491570158",
      "vendor_account_id": {
        "vendor_id": "MessageMedia",
        "account_id": "MyAccount"
      },
      "content": "My second reply!"
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unauthorised | [`M403responseException`](/doc/models/m403-response-exception.md) |
| 404 | Resource not found | [`ResourcenotfoundException`](/doc/models/resourcenotfound-exception.md) |

