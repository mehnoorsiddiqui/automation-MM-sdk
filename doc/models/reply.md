
# Reply

## Structure

`Reply`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CallbackUrl` | `string` | Optional | The URL specified as the callback URL in the original submit message request |
| `Content` | `string` | Optional | Content of the reply<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `5000` |
| `DateReceived` | `DateTime?` | Optional | Date time when the reply was received |
| `DestinationNumber` | `string` | Optional | Address from which this reply was sent to<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `15` |
| `MessageId` | `Guid?` | Optional | Unique ID of the original message |
| `Metadata` | `object` | Optional | Any metadata that was included in the original submit message request |
| `ReplyId` | `Guid?` | Optional | Unique ID of this reply |
| `SourceNumber` | `string` | Optional | Address from which this reply was received from<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `15` |
| `VendorAccountId` | [`Models.VendorAccountId`](../../doc/models/vendor-account-id.md) | Optional | - |

## Example (as JSON)

```json
{
  "callback_url": null,
  "content": null,
  "date_received": null,
  "destination_number": null,
  "message_id": null,
  "metadata": null,
  "reply_id": null,
  "source_number": null,
  "vendor_account_id": null
}
```

