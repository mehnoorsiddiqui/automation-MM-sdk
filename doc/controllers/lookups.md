# Lookups

MessageMedia Lookups API provides a simple way to keep your database clean. It accesses mobile carrier information about any mobile number, in real-time, anywhere in the world.

* Identify invalid numbers and reduce the number of failed or undeliverable messages
* Separate mobiles and landlines, so you don’t pay for messages that will never be delivered
* Identify carriers to determine which are low cost

To learn more about the benefits of the Lookups API, [visit product page](https://www.messagemedia.com/au/feature/lookups/).

![Lookups](https://developers.messagemedia.com/wp-content/uploads/2017/11/lookups-api.png)

Required Parameters

`{phone_number}`
This should be set to the phone number to be looked up.

By default, a request will only return the country_code and phone_number properties in the response.

```json
{
  "country_code": "AU",
  "phone_number": "+61491570156",
}
```

Options for Parameters

The options query parameter can also be used to request additional information about the phone number.

* `carrier` Request details about the carrier.
* `type` Use as a value of the options parameter

_Note: The `carrier` and the `type` values can be used together using a comma separated list, i.e. carrier,type._

* `hlr` Request details about the location by including as a value of the options parameter.

_NOTE: The `hlr` value CANNOT be used in conjunction with the other values.

```csharp
LookupsController lookupsController = client.LookupsController;
```

## Class Name

`LookupsController`


# Lookup a Phone Number

Use the Lookups API to find information about a phone number.

```csharp
LookupAPhoneNumberAsync(
    string phoneNumber,
    string options = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `phoneNumber` | `string` | Template, Required | The phone number to be looked up |
| `options` | `string` | Query, Optional | The options query parameter can also be used to request additional information about the phone number. e.g `carrier` and `type` can be used together using `,` and `hlr`  for location but cannot be used  with othe values. |

## Response Type

[`Task<Models.Lookupaphonenumberresponse>`](/doc/models/lookupaphonenumberresponse.md)

## Example Usage

```csharp
string phoneNumber = "61491570156";
string options = "\"carrier,type\"";

try
{
    Lookupaphonenumberresponse result = await lookupsController.LookupAPhoneNumberAsync(phoneNumber, options);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

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

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad request | [`BadrequestException`](/doc/models/badrequest-exception.md) |
| 403 | Unauthorised | [`M403responseException`](/doc/models/m403-response-exception.md) |
| 404 | Resource not found | [`Lookupaphonenumber404responseException`](/doc/models/lookupaphonenumber-404-response-exception.md) |

