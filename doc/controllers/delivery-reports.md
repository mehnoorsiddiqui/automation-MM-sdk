# Delivery Reports

If a callback URL is specified in the submit message request, then changes to the message status,
replies received in response to the message or delivery reports received for the message will be pushed via a HTTP POST request. An alternative to delivery reports via callbacks is custom webhooks using the webhooks management API.

All notifications are JSON encoded and the request expects to receive a response in the HTTP 200 range. If a valid response isn't received the request will be retried in an exponentially backing off fashion.

Delivery Reports may carry an additional charge. For pricing, please contact MessageMedia Account Manager or Support Team (support@messagemedia.com).

_Note, multiple delivery report notifications will be recieved for a single message.

The properties included in the notification are as follows:

* **Callback URL**: The URL specified as the callback URL in the original submit message request.

* **Delivery Report ID**: A unique ID for the delivery report that this notification represents.

* **Source Number**: The destination address of the original message.

* **Date Received**: The date and time at which this notification was generated in UTC.

* **Status**: The status of the message as indicated by this delivery report. The status field can be one of the following values:
  
  * `enroute`: Message has been received by the gateway and is being processed (or waiting to be processed).
  
  * `submitted`: Message has been submitted to a provider/carrier for delivery.
  
  * `delivered`: Message delivery has been confirmed by the provider, including to the handset (where possible).
  
  * `expired`: The message has expired.
  
  * `rejected`: The message will not be delivered - permanent failure. Reasons may include usage limit exceeded, insufficient credit, number blocked, or content filtered
  
  * `failed`: The message has failed. Reasons may include no active routes to destination or undeliverable by downstream provider.

* **Delay**: _Deprecated, no longer in use_

* **Submitted Date**: Date time status of the message changed in UTC. For a delivered DR this may indicate the time at which the message was received on the handset.

* **Original Text**: Text of the original message.

* **Message ID**: ID of the original message.

* **Vendor Account ID**: The account used to submit the original message. The vendor will always be `MessageMedia`

* **Error Code**: A status code which provides additional information about the message status:
  
  * `101`: Message being processed by the gateway.
  
  * `102`: Message is being rerouted to a different provider after failing via the first provider.
  
  * `151`: Message held for screening.
  
  * `200`: Message submitted to downstream provider for delivery.
  
  * `210`: Message accepted by downstream provider.
  
  * `211`: Message is enroute for delivery by provider.
  
  * `212`: Message submitted. Delivery pending.
  
  * `213`: Message scheduled for delivery by downstream provider.
  
  * `220`: Message delivered.
  
  * `221`: Message delivered to the handset.
  
  * `320`: Message validity period has expired (prior to submission).
  
  * `401`: Message validity period has expired (before delivery).
  
  * `301`: Usage threshold reached. Message discarded.
  
  * `302`: Destination address blocked. Message discarded.
  
  * `303`: Source address blocked. Message discarded.
  
  * `304`: Message dropped. Contact support.
  
  * `305`: Message discarded due to duplicate detection.
  
  * `402`: Message rejected by downstream provider.
  
  * `403`: Message skipped by downstream provider.
  
  * `410`: Invalid source address.
  
  * `411`: Invalid destination address.
  
  * `412`: Destination address blocked.
  
  * `413`: SMS service unavailable on destination.
  
  * `414`: Destination unreachable.
  
  * `330`: Gateway failure.
  
  * `331`: Message discarded.
  
  * `332`: No available route to destination.
  
  * `333`: Source address unsupported for this destination.
  
  * `400`: Message failed; undeliverable.
  
  * `405`: Message cancelled or deleted by provider.

```csharp
DeliveryReportsController deliveryReportsController = client.DeliveryReportsController;
```

## Class Name

`DeliveryReportsController`

## Methods

* [Check Delivery Reports](/doc/controllers/delivery-reports.md#check-delivery-reports)
* [Confirm Delivery Reports as Received](/doc/controllers/delivery-reports.md#confirm-delivery-reports-as-received)


# Check Delivery Reports

Check for any delivery reports that have been received.
Delivery reports are a notification of the change in status of a message as it is being processed.

```csharp
CheckDeliveryReportsAsync()
```

## Response Type

[`Task<Models.Checkdeliveryreportsresponse>`](/doc/models/checkdeliveryreportsresponse.md)

## Example Usage

```csharp
try
{
    Checkdeliveryreportsresponse result = await deliveryReportsController.CheckDeliveryReportsAsync();
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "delivery_reports": [
    {
      "callback_url": "https://my.callback.url.com",
      "delivery_report_id": "01e1fa0a-6e27-4945-9cdb-18644b4de043",
      "source_number": "+61491570157",
      "date_received": "2017-05-20T06:30:37.642Z",
      "status": "enroute",
      "delay": 0,
      "submitted_date": "2017-05-20T06:30:37.639Z",
      "original_text": "My first message!",
      "message_id": "d781dcab-d9d8-4fb2-9e03-872f07ae94ba",
      "vendor_account_id": {
        "vendor_id": "MessageMedia",
        "account_id": "MyAccount"
      },
      "metadata": {
        "key1": "value1",
        "key2": "value2"
      }
    },
    {
      "callback_url": "https://my.callback.url.com",
      "delivery_report_id": "0edf9022-7ccc-43e6-acab-480e93e98c1b",
      "source_number": "+61491570158",
      "date_received": "2017-05-21T01:46:42.579Z",
      "status": "submitted",
      "delay": 0,
      "submitted_date": "2017-05-21T01:46:42.574Z",
      "original_text": "My second message!",
      "message_id": "fbb3b3f5-b702-4d8b-ab44-65b2ee39a281",
      "vendor_account_id": {
        "vendor_id": "MessageMedia",
        "account_id": "MyAccount"
      },
      "metadata": {
        "key1": "value1",
        "key2": "value2"
      }
    }
  ]
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unauthorised | [`M403responseException`](/doc/models/m403-response-exception.md) |
| 404 | Resource not found | [`ResourcenotfoundException`](/doc/models/resourcenotfound-exception.md) |


# Confirm Delivery Reports as Received

Mark a delivery report as confirmed so it is no longer return in check delivery reports requests.

```csharp
ConfirmDeliveryReportsAsReceivedAsync(
    Models.Confirmeliveryreportsasreceivedrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.Confirmeliveryreportsasreceivedrequest`](/doc/models/confirmeliveryreportsasreceivedrequest.md) | Body, Required | Delivery reports to confirm as received. |

## Response Type

`Task<object>`

## Example Usage

```csharp
var body = new Confirmeliveryreportsasreceivedrequest();
body.DeliveryReportIds = new List<Guid>();
body.DeliveryReportIds.Add(new Guid("011dcead-6988-4ad6-a1c7-6b6c68ea628d"));
body.DeliveryReportIds.Add(new Guid("3487b3fa-6586-4979-a233-2d1b095c7718"));

try
{
    object result = await deliveryReportsController.ConfirmDeliveryReportsAsReceivedAsync(body);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad request | [`BadrequestException`](/doc/models/badrequest-exception.md) |
| 403 | Unauthorised | [`M403responseException`](/doc/models/m403-response-exception.md) |
| 404 | Resource not found | [`ResourcenotfoundException`](/doc/models/resourcenotfound-exception.md) |

