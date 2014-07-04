## Authentication

You need to provide 3 headers to authenticate a private request:

API-Key -    You can get API-Key in account settings.

API-Sign -   Text Signature: method + nonce + API­key, created with ECDSA algorithm using a hash function with sha­1, issued a private key on curve sec256k1.

API-Nonce -  Nonce is an arbitrary number increasing with every request.

Make sure the Content-Type is application/json.

There is examples how to create sign in different languages
