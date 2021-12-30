
# Lookupaphonenumberresponse

## Structure

`Lookupaphonenumberresponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CountryCode` | `string` | Required | - |
| `PhoneNumber` | `string` | Required | - |
| `Type` | `string` | Required | - |
| `Carrier` | [`Models.Carrier`](/doc/models/carrier.md) | Required | - |
| `Result` | `string` | Optional | - |
| `Imsi` | `long?` | Optional | A unique number identifying a GSM subscriber |
| `Location` | `int?` | Optional | The location of the mobile number |

## Example (as JSON)

```json
{
  "country_code": "AU",
  "phone_number": "61491570156",
  "type": "mobile",
  "carrier": {
    "name": "Telstra"
  }
}
```

