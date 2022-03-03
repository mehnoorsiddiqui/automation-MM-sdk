# Number Authorisation

The number authorisation API allows you to manage your blacklists. MessageMedia automatically adds numbers to your blacklist if people send one of the opt out keywords in response to one of your messages.
This is a legal requirement. If you decide to handle the legal compliance yourself, calls to this endpoint will not affect your messages.

```csharp
NumberAuthorisationController numberAuthorisationController = client.NumberAuthorisationController;
```

## Class Name

`NumberAuthorisationController`

## Methods

* [List All Blocked Numbers](../../doc/controllers/number-authorisation.md#list-all-blocked-numbers)
* [Add One or More Numbers to Your Backlist](../../doc/controllers/number-authorisation.md#add-one-or-more-numbers-to-your-backlist)
* [Remove a Number From the Blacklist](../../doc/controllers/number-authorisation.md#remove-a-number-from-the-blacklist)
* [Check If One or Several Numbers Are Currently Blacklisted](../../doc/controllers/number-authorisation.md#check-if-one-or-several-numbers-are-currently-blacklisted)


# List All Blocked Numbers

This endpoint returns a list of 100 numbers that are on the blacklist.  There is a pagination token to retrieve the next 100 numbers

```csharp
ListAllBlockedNumbersAsync()
```

## Response Type

[`Task<Models.Getnumberauthorisationblacklistresponse>`](../../doc/models/getnumberauthorisationblacklistresponse.md)

## Example Usage

```csharp
try
{
    Getnumberauthorisationblacklistresponse result = await numberAuthorisationController.ListAllBlockedNumbersAsync();
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "uri": "/v1/number_authorisation/mt/blacklist\"",
  "numbers": [
    "+61491570156",
    "+61491570157"
  ],
  "pagination": {
    "page": "0",
    "next_uri": "/v1/number_authorisation/mt/blacklist?token=0"
  }
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unauthorised | [`M403responseException`](../../doc/models/m403-response-exception.md) |


# Add One or More Numbers to Your Backlist

This endpoint allows you to add one or more numbers to your blacklist. You can add up to 10 numbers in one request.

```csharp
AddOneOrMoreNumbersToYourBacklistAsync(
    Models.Addoneormorenumberstoyourbacklistrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.Addoneormorenumberstoyourbacklistrequest`](../../doc/models/addoneormorenumberstoyourbacklistrequest.md) | Body, Required | Numbers need to be in international format and therefore start with a + |

## Response Type

[`Task<Models.Addoneormorenumberstoyourbacklistresponse>`](../../doc/models/addoneormorenumberstoyourbacklistresponse.md)

## Example Usage

```csharp
var body = new Addoneormorenumberstoyourbacklistrequest();
body.Numbers = new List<string>();
body.Numbers.Add("+61491570156");

try
{
    Addoneormorenumberstoyourbacklistresponse result = await numberAuthorisationController.AddOneOrMoreNumbersToYourBacklistAsync(body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "uri": "/v1/number_authorisation/mt/blacklist",
  "numbers": [
    "+61491570156"
  ]
}
```


# Remove a Number From the Blacklist

This endpoint allows you to remove a number from the blacklist.  Only one number can be deleted per request.

```csharp
RemoveANumberFromTheBlacklistAsync(
    string number)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `number` | `string` | Template, Required | a number in international format e.g. `+61491570156` |

## Response Type

`Task<Stream>`

## Example Usage

```csharp
string number = "number2";

try
{
    Stream result = await numberAuthorisationController.RemoveANumberFromTheBlacklistAsync(number);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 404 | - | `ApiException` |


# Check If One or Several Numbers Are Currently Blacklisted

This endpoints lists for each requested number if you are authorised (which means the number is not blacklisted) to send to this number.
If you send a message which is on the blacklist, MessageMedia issue a delivery receipt with the appropriate status code.

```csharp
CheckIfOneOrSeveralNumbersAreCurrentlyBlacklistedAsync(
    List<string> numbers)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `numbers` | `List<string>` | Template, Required | one or more numbers in international format seperate by a comma, e.g. `+61491570156,+61491570157`<br>**Constraints**: *Minimum Items*: `1`, *Maximum Items*: `1`, *Unique Items Required* |

## Response Type

[`Task<Models.Checkifoneorseveralnumbersarecurrentlyblacklistedresponse>`](../../doc/models/checkifoneorseveralnumbersarecurrentlyblacklistedresponse.md)

## Example Usage

```csharp
var numbers = new List<string>();
numbers.Add("numbers0");

try
{
    Checkifoneorseveralnumbersarecurrentlyblacklistedresponse result = await numberAuthorisationController.CheckIfOneOrSeveralNumbersAreCurrentlyBlacklistedAsync(numbers);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

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

