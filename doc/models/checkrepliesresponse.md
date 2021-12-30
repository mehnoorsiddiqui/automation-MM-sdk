
# Checkrepliesresponse

## Structure

`Checkrepliesresponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Replies` | [`List<Models.Reply>`](/doc/models/reply.md) | Optional | The oldest 100 unconfirmed replies<br>**Constraints**: *Minimum Items*: `0`, *Maximum Items*: `100` |

## Example (as JSON)

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

