## Authentication

[Read in russian](https://github.com/IndacoinOrg/SigningAlgorithms/wiki/Авторизация-при-работе-с-API)

You need to provide 3 headers to authenticate a private request:

**API-Key** -    You can get API-Key in account settings.

**API-Sign** -   Text Signature: method + nonce + API­key, created with ECDSA algorithm using a hash function with sha­1, issued a private key on curve sec256k1.

**API-Nonce**-  nonce is an arbitrary number increasing with every request.

Make sure the Content-Type is application/json.

There are examples how to create sign in different languages

* [C++](https://github.com/IndacoinOrg/SigningAlgorithms/blob/master/CPPSigning.cpp)

* [C#](https://github.com/IndacoinOrg/SigningAlgorithms/blob/master/CSharpSigning.cs)

* [PHP example](https://github.com/IndacoinOrg/SigningAlgorithms/blob/master/PHPSigningExampleGetBalance.php)

* [Python](https://github.com/IndacoinOrg/SigningAlgorithms/blob/master/PythonSigning.py)

For more information about API visit [Indacoin.com](https://indacoin.com/api)

##Programms that support our API

* [QtBitcoinTrader](https://github.com/IndacoinOrg/QtBitcoinTrader/wiki)
