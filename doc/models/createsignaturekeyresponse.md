
# Createsignaturekeyresponse

## Structure

`Createsignaturekeyresponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `KeyId` | `string` | Required | - |
| `PublicKey` | `string` | Required | - |
| `Cipher` | `string` | Required | - |
| `Digest` | `string` | Required | - |
| `Created` | `string` | Required | - |
| `Enabled` | `bool` | Required | - |

## Example (as JSON)

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

