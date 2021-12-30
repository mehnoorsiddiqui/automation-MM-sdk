
# Getnumberauthorisationblacklistresponse

## Structure

`Getnumberauthorisationblacklistresponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Uri` | `string` | Optional | URL of the current API call, used to show the current pagination token for calls subsequent to the first one in the case of paginated data. |
| `Numbers` | `List<string>` | Optional | List of numbers belonging to the blacklist. |
| `Pagination` | [`Models.Pagination`](/doc/models/pagination.md) | Optional | - |

## Example (as JSON)

```json
{
  "uri": null,
  "numbers": null,
  "pagination": null
}
```

