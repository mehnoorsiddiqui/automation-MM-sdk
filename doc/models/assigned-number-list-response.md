
# Assigned Number List Response

## Structure

`AssignedNumberListResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Data` | [`List<Models.AssignedNumber>`](../../doc/models/assigned-number.md) | Optional | - |
| `Pagination` | [`Models.Pagination1`](../../doc/models/pagination-1.md) | Optional | - |

## Example (as JSON)

```json
{
  "pagination": {
    "next_token": "0428d673-0f75-4063-9493-e89d75f13438",
    "page_size": 5
  },
  "data": [
    {
      "assignment": {
        "metadata": {
          "key1": "value1"
        },
        "label": "LabelTest0",
        "id": "be3cb602-7c00-4c87-ae4b-b8defc04f179",
        "number_id": "b9ee3fe8-2c20-47b1-96e9-c5d12d7ed985"
      },
      "number": {
        "id": "03cf54ad-a4a3-4cd1-afd5-e0ca2cf158a3",
        "phone_number": "+61436489205",
        "country": "AU",
        "type": "MOBILE",
        "classification": "BRONZE",
        "available_after": "2019-08-06T23:56:15.633Z",
        "capabilities": [
          "SMS"
        ]
      }
    }
  ]
}
```

