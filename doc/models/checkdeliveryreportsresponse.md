
# Checkdeliveryreportsresponse

## Structure

`Checkdeliveryreportsresponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DeliveryReports` | [`List<Models.DeliveryReport>`](../../doc/models/delivery-report.md) | Optional | The oldest 100 unconfirmed delivery reports<br>**Constraints**: *Minimum Items*: `0`, *Maximum Items*: `100` |

## Example (as JSON)

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

