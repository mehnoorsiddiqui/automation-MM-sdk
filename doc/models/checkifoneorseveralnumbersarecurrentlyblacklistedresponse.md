
# Checkifoneorseveralnumbersarecurrentlyblacklistedresponse

## Structure

`Checkifoneorseveralnumbersarecurrentlyblacklistedresponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Uri` | `string` | Required | - |
| `Numbers` | `object` | Required | - |

## Example (as JSON)

```json
{
  "uri": "/v1/number_authorisation/is_authorised/+61491570156,+61491570157",
  "numbers": [
    {
      "number": 61491570156,
      "authorised": true
    },
    {
      "number": 61491570157,
      "authorised": false
    }
  ]
}
```

