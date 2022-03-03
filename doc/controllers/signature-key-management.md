# Signature Key Management

As MessageMedia's customer, you want to be able to ensure that callbacks are coming from MessageMedia and not from a 3rd party. Since
these are calls to your own system, you should be provided with an extra level of security
when calling your resources.

The MessageMedia Signature Key API provides a number of endpoints
for managing key used to sign each unique request to ensure security
and the requests can't (easily) be spoofed. This is similar to using
HMAC in your outbound messaging (rather than HTTP Basic).

The Signature Key API provides seven main endpoints:

- `Create signature key` Create a new signature key for signature verification in callbacks.
- `Get signature key detail` Retrieve the current detail of a signature key using the key_id returned in the `create signature key` endpoint.
- `Delete signature key` Delete a signature key using the key_id returned in the `create signature key` endpoint.
- `Get signature key list` Retrieve the paginated list of signature keys.
- `Enable signature key` Enable a signature key using the key_id returned in the `create signature key` endpoint.
- `Get enabled signature key` Retrieve the current enabled signature key.
- `Disable an enabled signature key` Disable the current enabled signature key.

```csharp
SignatureKeyManagementController signatureKeyManagementController = client.SignatureKeyManagementController;
```

## Class Name

`SignatureKeyManagementController`

## Methods

* [Get Signature Key List](../../doc/controllers/signature-key-management.md#get-signature-key-list)
* [Create Signature Key](../../doc/controllers/signature-key-management.md#create-signature-key)
* [Get Signature Key Detail](../../doc/controllers/signature-key-management.md#get-signature-key-detail)
* [Delete Signature Key](../../doc/controllers/signature-key-management.md#delete-signature-key)
* [Get Enabled Signature Key](../../doc/controllers/signature-key-management.md#get-enabled-signature-key)
* [Enable Signature Key](../../doc/controllers/signature-key-management.md#enable-signature-key)
* [Disable the Current Enabled Signature Key](../../doc/controllers/signature-key-management.md#disable-the-current-enabled-signature-key)


# Get Signature Key List

Retrieve the paginated list of signature keys.

```csharp
GetSignatureKeyListAsync(
    string page,
    string pageSize)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `page` | `string` | Query, Required | - |
| `pageSize` | `string` | Query, Required | - |

## Response Type

[`Task<List<Models.Getsignaturekeylistresponse>>`](../../doc/models/getsignaturekeylistresponse.md)

## Example Usage

```csharp
string page = "page8";
string pageSize = "page_size8";

try
{
    List<Getsignaturekeylistresponse> result = await signatureKeyManagementController.GetSignatureKeyListAsync(page, pageSize);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
[
  {
    "key_id": "7ca628a8-08b0-4e42-aeb8-960b37049c31",
    "cipher": "RSA",
    "digest": "SHA224",
    "created": "2018-01-18T10:16:12.364Z",
    "enabled": true
  },
  {
    "key_id": "6a0108cf-3659-435e-800e-004beb910fd1",
    "cipher": "RSA",
    "digest": "SHA224",
    "created": "2018-01-18T10:15:31.035Z",
    "enabled": false
  }
]
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Unexpected error in API call. See HTTP response body for details. | [`Enablesignaturekey400responseException`](../../doc/models/enablesignaturekey-400-response-exception.md) |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`Disablethecurrentenabledsignaturekey403responseException`](../../doc/models/disablethecurrentenabledsignaturekey-403-response-exception.md) |


# Create Signature Key

This will create a key pair:
The `private key` stored in MessageMedia is used to create the signature.
The `public key` is returned and stored at your side to verify the signature in callbacks.

You need to enable your signature key after creating.

In the response body  `enabled`  is false for the new signature key. You can use the `enable signature key`  endpoint to set this field to true.

```csharp
CreateSignatureKeyAsync(
    string accept,
    Models.Createsignaturekeyrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `body` | [`Models.Createsignaturekeyrequest`](../../doc/models/createsignaturekeyrequest.md) | Body, Required | - |

## Response Type

[`Task<Models.Createsignaturekeyresponse>`](../../doc/models/createsignaturekeyresponse.md)

## Example Usage

```csharp
string accept = "application/json";
var body = new Createsignaturekeyrequest();
body.Digest = "SHA224";
body.Cipher = "RSA";

try
{
    Createsignaturekeyresponse result = await signatureKeyManagementController.CreateSignatureKeyAsync(accept, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "key_id": "7ca628a8-08b0-4e42-aeb8-960b37049c31",
  "public_key": "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCTIxtRyT5CuOD74r7UCT+AKzWNxvaAP9myjAqR7+vBnJKEvoPnmbKTnm6uLlxutnMbjKrnCCWnQ9vtBVnnd+ElhwLDPADfMcJoOqwi7mTcxucckeEbBsfsgYRfdacxgSZL8hVD1hLViQr3xwjEIkJcx1w3x8npvwMuTY0uW8+PjwIDAQAB",
  "cipher": "RSA",
  "digest": "SHA224",
  "created": "2018-01-18T10:16:12.364Z",
  "enabled": false
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Unexpected error in API call. See HTTP response body for details. | [`Enablesignaturekey400responseException`](../../doc/models/enablesignaturekey-400-response-exception.md) |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`Disablethecurrentenabledsignaturekey403responseException`](../../doc/models/disablethecurrentenabledsignaturekey-403-response-exception.md) |


# Get Signature Key Detail

Retrieve the current detail of a signature key using the key_id returned in the `create signature key` endpoint.

```csharp
GetSignatureKeyDetailAsync(
    string keyId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `keyId` | `string` | Template, Required | - |

## Response Type

[`Task<Models.Getsignaturekeydetailresponse>`](../../doc/models/getsignaturekeydetailresponse.md)

## Example Usage

```csharp
string keyId = "key_id4";

try
{
    Getsignaturekeydetailresponse result = await signatureKeyManagementController.GetSignatureKeyDetailAsync(keyId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "key_id": "7ca628a8-08b0-4e42-aeb8-960b37049c31",
  "cipher": "RSA",
  "digest": "SHA224",
  "created": "2018-01-18T10:16:12.364Z",
  "enabled": false
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Unexpected error in API call. See HTTP response body for details. | [`Enablesignaturekey400responseException`](../../doc/models/enablesignaturekey-400-response-exception.md) |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`Disablethecurrentenabledsignaturekey403responseException`](../../doc/models/disablethecurrentenabledsignaturekey-403-response-exception.md) |
| 404 | Unexpected error in API call. See HTTP response body for details. | [`Disablethecurrentenabledsignaturekey403responseException`](../../doc/models/disablethecurrentenabledsignaturekey-403-response-exception.md) |


# Delete Signature Key

Delete a signature key using the key_id returned in the `create signature key` endpoint.

```csharp
DeleteSignatureKeyAsync(
    string keyId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `keyId` | `string` | Template, Required | - |

## Response Type

`Task`

## Example Usage

```csharp
string keyId = "key_id4";

try
{
    await signatureKeyManagementController.DeleteSignatureKeyAsync(keyId);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`Disablethecurrentenabledsignaturekey403responseException`](../../doc/models/disablethecurrentenabledsignaturekey-403-response-exception.md) |
| 404 | Unexpected error in API call. See HTTP response body for details. | [`Disablethecurrentenabledsignaturekey403responseException`](../../doc/models/disablethecurrentenabledsignaturekey-403-response-exception.md) |


# Get Enabled Signature Key

Retrieve the currently enabled signature key.

```csharp
GetEnabledSignatureKeyAsync()
```

## Response Type

[`Task<Models.Getenabledsignaturekeyresponse>`](../../doc/models/getenabledsignaturekeyresponse.md)

## Example Usage

```csharp
try
{
    Getenabledsignaturekeyresponse result = await signatureKeyManagementController.GetEnabledSignatureKeyAsync();
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "key_id": "7ca628a8-08b0-4e42-aeb8-960b37049c31",
  "cipher": "RSA",
  "digest": "SHA224",
  "created": "2018-01-18T10:16:12.364Z",
  "enabled": true
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`Disablethecurrentenabledsignaturekey403responseException`](../../doc/models/disablethecurrentenabledsignaturekey-403-response-exception.md) |
| 404 | Unexpected error in API call. See HTTP response body for details. | [`Disablethecurrentenabledsignaturekey403responseException`](../../doc/models/disablethecurrentenabledsignaturekey-403-response-exception.md) |


# Enable Signature Key

Enable a signature key using the key_id returned in the `create signature key` endpoint.

There is only one signature key is enabled at the one moment in time. So if you enable the new signature key, the old one will be disabled.

```csharp
EnableSignatureKeyAsync(
    string accept,
    Models.Enablesignaturekeyrequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accept` | `string` | Header, Required | - |
| `body` | [`Models.Enablesignaturekeyrequest`](../../doc/models/enablesignaturekeyrequest.md) | Body, Required | - |

## Response Type

[`Task<Models.Enablesignaturekeyresponse>`](../../doc/models/enablesignaturekeyresponse.md)

## Example Usage

```csharp
string accept = "application/json";
var body = new Enablesignaturekeyrequest();
body.KeyId = "7ca628a8-08b0-4e42-aeb8-960b37049c31";

try
{
    Enablesignaturekeyresponse result = await signatureKeyManagementController.EnableSignatureKeyAsync(accept, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "key_id": "7ca628a8-08b0-4e42-aeb8-960b37049c31",
  "cipher": "RSA",
  "digest": "SHA224",
  "created": "2018-01-18T10:16:12.364Z",
  "enabled": true
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Unexpected error in API call. See HTTP response body for details. | [`Enablesignaturekey400responseException`](../../doc/models/enablesignaturekey-400-response-exception.md) |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`Disablethecurrentenabledsignaturekey403responseException`](../../doc/models/disablethecurrentenabledsignaturekey-403-response-exception.md) |
| 404 | Unexpected error in API call. See HTTP response body for details. | [`Disablethecurrentenabledsignaturekey403responseException`](../../doc/models/disablethecurrentenabledsignaturekey-403-response-exception.md) |


# Disable the Current Enabled Signature Key

Disable the current enabled signature key.

A successful request will return no content when successful.

```csharp
DisableTheCurrentEnabledSignatureKeyAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await signatureKeyManagementController.DisableTheCurrentEnabledSignatureKeyAsync();
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 403 | Unexpected error in API call. See HTTP response body for details. | [`Disablethecurrentenabledsignaturekey403responseException`](../../doc/models/disablethecurrentenabledsignaturekey-403-response-exception.md) |

