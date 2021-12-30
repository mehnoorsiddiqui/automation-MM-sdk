
# Numbers List Response

## Structure

`NumbersListResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Data` | [`List<Models.Number1>`](/doc/models/number-1.md) | Optional | - |
| `Pagination` | [`Models.Pagination1`](/doc/models/pagination-1.md) | Optional | - |

## Example (as JSON)

```json
{
  "pagination": {
    "next_token": "0428d673-0f75-4063-9493-e89d75f13438",
    "page_size": 5
  },
  "data": [
    {
      "id": "03cf54ad-a4a3-4cd1-afd5-e0ca2cf158a3",
      "phone_number": "61436489205",
      "country": "AU",
      "type": "MOBILE",
      "classification": "BRONZE",
      "available_after": "2019-08-06T23:56:15.633Z",
      "capabilities": [
        "SMS"
      ]
    }
  ]
}
```

