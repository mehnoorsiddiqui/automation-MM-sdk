# Messages

The MessageMedia Messages API provides a number of endpoints for building powerful two-way messaging applications. The Messages API provides access to three main resources:

* Messages - Messages delivered from an application to a handset.
* Delivery Reports - Real time reports on the delivery status of a message. As a message is processed, it's status may change several times before it is finally delivered to a handset.
* Replies - Messages sent from a handset to an application. These messages are typically a reply to a previously sent message.
  ![Message Flow](https://i.imgur.com/jJeHwf5.png)

```csharp
MessagesController messagesController = client.MessagesController;
```

## Class Name

`MessagesController`

## Methods

* [Cancel Scheduled Message](/doc/controllers/messages.md#cancel-scheduled-message)
* [Get Message Status](/doc/controllers/messages.md#get-message-status)
* [Send Messages](/doc/controllers/messages.md#send-messages)


# Cancel Scheduled Message

Cancel a that has not yet been delivered.

A scheduled message can be cancelled by updating the status of a message
from `scheduled` to `cancelled`.

```csharp
CancelScheduledMessageAsync(
    string messageId,
    Models.Cancelscheduledmessagerequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `messageId` | `string` | Template, Required | 35 character UUID. |
| `body` | [`Models.Cancelscheduledmessagerequest`](/doc/models/cancelscheduledmessagerequest.md) | Body, Required | Parameters of a message to change. |

## Response Type

`Task`

## Example Usage

```csharp
string messageId = "messageId2";
var body = new Cancelscheduledmessagerequest();
body.Status = "cancelled";

try
{
    await messagesController.CancelScheduledMessageAsync(messageId, body);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad request | [`BadrequestException`](/doc/models/badrequest-exception.md) |
| 403 | Unauthorised | [`M403responseException`](/doc/models/m403-response-exception.md) |
| 404 | Resource not found | [`ResourcenotfoundException`](/doc/models/resourcenotfound-exception.md) |


# Get Message Status

Retrieve the current status of a message using the message ID returned in the send messages end point.

```csharp
GetMessageStatusAsync(
    string messageId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `messageId` | `string` | Template, Required | 36 character UUID. |

## Response Type

[`Task<Models.Getmessagestatusresponse>`](/doc/models/getmessagestatusresponse.md)

## Example Usage

```csharp
string messageId = "messageId2";

try
{
    Getmessagestatusresponse result = await messagesController.GetMessageStatusAsync(messageId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "format": "SMS",
  "content": "My first message!",
  "metadata": {
    "key1": "value1",
    "key2": "value2"
  },
  "message_id": "877c19ef-fa2e-4cec-827a-e1df9b5509f7",
  "callback_url": "https://my.callback.url.com",
  "delivery_report": true,
  "destination_number": "+61401760575",
  "scheduled": "2016-11-03T11:49:02.807Z",
  "source_number": "+61491570157",
  "source_number_type": "INTERNATIONAL",
  "message_expiry_timestamp": "2016-11-03T11:49:02.807Z",
  "status": "enroute"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unauthorised | [`M403responseException`](/doc/models/m403-response-exception.md) |
| 404 | Resource not found | [`ResourcenotfoundException`](/doc/models/resourcenotfound-exception.md) |


# Send Messages

Submit one or more (up to 100 per request) SMS, MMS or text to voice messages for delivery.

*Note: when sending multiple messages in a request,if any message in the request is invalid, no message will be sent.*

```csharp
SendMessagesAsync(
    Models.Sendmessagesrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.Sendmessagesrequest`](/doc/models/sendmessagesrequest.md) | Body, Required | - |

## Response Type

[`Task<Models.Sendmessagesresponse>`](/doc/models/sendmessagesresponse.md)

## Example Usage

```csharp
var body = new Sendmessagesrequest();
body.Messages = new List<Message>();

var bodyMessages0 = new Message();
bodyMessages0.Content = "My first message";
bodyMessages0.DestinationNumber = "+61491570156";
bodyMessages0.SourceNumber = "+61491570157";
body.Messages.Add(bodyMessages0);


try
{
    Sendmessagesresponse result = await messagesController.SendMessagesAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "messages": [
    {
      "callback_url": "https://my.url.com",
      "content": "Hello world!",
      "destination_number": "+61491570156",
      "delivery_report": false,
      "format": "SMS",
      "message_expiry_timestamp": "2016-11-03T11:49:02.000+00:00",
      "metadata": {},
      "scheduled": "2016-11-03T11:49:02.000+00:00",
      "source_number": "+61491570156",
      "source_number_type": "INTERNATIONAL",
      "message_id": "d7d9d9fd-478f-40e6-b651-49b7f19878a2",
      "status": "enroute",
      "media": [
        "https://images.pexels.com/photos/1018350/pexels-photo-1018350.jpeg?cs=srgb&dl=architecture-buildings-city-1018350.jpg"
      ],
      "subject": "string"
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Unexpected error in API call. See HTTP response body for details. | [`BadrequestException`](/doc/models/badrequest-exception.md) |
| 403 | Unauthorised | [`M403responseException`](/doc/models/m403-response-exception.md) |

