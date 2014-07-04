#you need ecdsa library
#visit https://pypi.python.org/pypi/ecdsa/0.11 for more information

import base64
import ecdsa.util
import hashlib
from ecdsa import SigningKey, VerifyingKey, SECP256k1
def CalculateSignature(message, private_key):
	message = bytes(message, 'utf-8')
	sk_string = base64.b64decode(private_key)
	sk = SigningKey.from_string(sk_string, curve=SECP256k1)
	signature = sk.sign_deterministic(message, hashfunc=hashlib.sha1, sigencode=ecdsa.util.sigencode_der)
	return base64.b64encode(signature)