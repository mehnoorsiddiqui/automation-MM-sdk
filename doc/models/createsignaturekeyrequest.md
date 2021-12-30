
# Createsignaturekeyrequest

## Structure

`Createsignaturekeyrequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Digest` | `string` | Required | To hash the message. The valid values for digest type are: `SHA224`, `SHA256`, `SHA512` |
| `Cipher` | `string` | Required | To encrypt the hashed message. The valid value for cipher type is: `RSA` |

## Example (as JSON)

```json
{
  "digest": "SHA224",
  "cipher": "RSA"
}
```

