
# List Response Example Response

## Structure

`ListResponseExampleResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Uri` | `string` | Required | - |
| `Numbers` | `List<string>` | Required | - |
| `Pagination` | [`Models.Pagination3`](../../doc/models/pagination-3.md) | Required | - |

## Example (as JSON)

```json
{
  "uri": "/v1/number_authorisation/mt/blacklist",
  "numbers": [],
  "pagination": {
    "next_token": "0",
    "next_url": "/v1/number_authorisation/mt/blacklist?token=0"
  }
}
```

