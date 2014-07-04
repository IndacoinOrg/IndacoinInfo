//example of signing in PHP for 'getbalance' method
//you need OpenSSL library
//visit http://www.openssl.org/ for more information
<?php
$data = '';
$method = "getbalance";

$result = send($method, $data);
$obj = json_decode($result);

function send($method, $data)
{
//ENTER YOUR PRIVATE KEY (PEM)
$pemStr = <<<EOD
-----BEGIN EC PRIVATE KEY-----


-----END EC PRIVATE KEY-----
EOD;

$apiKey = "*****************************";//your API Key

$sign = "";
$t = str_ireplace(".", "", microtime(true));

openssl_sign($method.$t.$apiKey,
	$sign,
	$pemStr,
	"ecdsa-with-SHA1"
);

$curlInit = curl_init("https://indacoin.com/api/".$method);
curl_setopt($curlInit, CURLOPT_HTTPHEADER, array(
	'API-Key: '.$apiKey,
	'API-Sign: '.base64_encode($sign),
	'API-Nonce: '.$t,
	'Content-type: application/json; charset=utf-8'
));
curl_setopt($curlInit, CURLOPT_POST, true);
curl_setopt($curlInit, CURLOPT_POSTFIELDS, $data);
curl_setopt($curlInit,CURLOPT_RETURNTRANSFER,true);
curl_setopt($curlInit, CURLOPT_SSL_VERIFYPEER, false);
curl_setopt($curlInit, CURLOPT_SSL_VERIFYHOST, false);
return(curl_exec($curlInit));
}