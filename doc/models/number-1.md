
# Number 1

## Structure

`Number1`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AvailableAfter` | `DateTime?` | Optional | - |
| `Capabilities` | [`List<Models.CapabilityEnum>`](/doc/models/capability-enum.md) | Optional | - |
| `Classification` | [`Models.ClassificationEnum?`](/doc/models/classification-enum.md) | Optional | - |
| `Country` | `string` | Optional | - |
| `Id` | `string` | Optional | - |
| `PhoneNumber` | `string` | Optional | - |
| `Type` | [`Models.Type1Enum?`](/doc/models/type-1-enum.md) | Optional | - |

## Example (as JSON)

```json
{
  "id": "be3cb602-7c00-4c87-ae4b-b8defc04f179",
  "phone_number": "614111111111",
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

