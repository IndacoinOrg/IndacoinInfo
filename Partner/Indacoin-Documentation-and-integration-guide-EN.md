### API
On this page, you can find methods that are used to enable your service with the cryptocurrency exchange features of Indacoin. For example, if you want to provide your customers with theoption to pay via credit/debit cards, with our API you will be able to do that.

## 1. Introduction
### 1.1. Target audience
The current document is designed for the partner’s technical team who is responsible for Indacoin payment system integration. For better understanding, it is recommended for the reader to have a general knowledge of programming languages, HTML forms and client-server technology (web). Our platform provides 2 integration options (simple and standard), which we will walk you through step by step in paragraphs 2 and 3, respectively. 

### 1.2. Partner platform requirements

For the successful integration the seller’s website should be able to:
1. Redirect the users to Indacoin payment system using GET;
2. Accept and process requests from Indacoin payment system for the specified URLs implemented by the POST or GET methods (depends on the settings).

### 1.3. Additional features available for the partner while applying Indacoin payment system 
1. Modification of the payment page design 
To change the design of the payment page the partner needs to upload the custom CSS file in his personal account. (https://indacoin.com/gw/partneradmin)
2. Partner notification about payment completion - Callback
After the payment confirmation, we will send you a callback to the address that has been designated in your personal account. (https://indacoin.com/gw/partneradmin)
3. Creation of successful and failed payment pages on a partner platform
The partner is capable to monitor the pages with successful and failed payments on his platform to where it will be redirected after the payment is processed. The links should be indicated in the personal account. (https://indacoin.com/gw/partneradmin)

### 1.4. Receiving the main information required for the integration
The access will be granted to your personal account. The login should be input in the field “Partner” and the password in the field “Secret”.

## 2. Simple integration (front-end)
### 2.1 Placing the payment form on the partner platform and testing
For the customers to be forwarded to the payment page the partner needs to place a payment form on his platform. It will transfer all the necessary data to Indacoin. 

**Important!** While testing the integration system it is requested to use the test bank card (4111 1111 1111 1111, any expiration date, more than the current date, any CVC/CVV) and testing **cur_to - INTT** (Indacoin Test Token). After checking the system functionality and efficiency you can start using real bank cards for the payment.

Parameters that need to be transmitted:

**partner** - partner name in Indacoin system (string).

**cur_from** - currency to be exchanged (USD, RUB, EUR, GBP, AUD, SEK, CAD, CHF, DKK, PLN, CZK, NOK) (string).

**cur_to** - short_name of the cryptocurrency purchased, for instanсe, BTC, ETH, WAVES etc (string).

**amount** - the amount of the currency to be exchanged (double). The minimal amount is 10 USD/EUR, the maximum - 6000 USD/EUR.

**address** - wallet address, where the cryptocurrency will be deposited after the payment is processed (string).

**user_id** - customer id in a seller system (string).

All the requests should be sent to **https://indacoin.com/gw/payment_form**.

Below you can see the example of the payment form. 

`<form action=https://indacoin.com/gw/payment_form method="GET">`

`<input type="hidden" name="partner" value="YourPartnerName" />`

`<input type="hidden" name="cur_from" value="USD" />`

`<input type="hidden" name="cur_to" value="BTC" />`

`<input type="hidden" name="amount" value="1000" />`

`<input type="hidden" name="adress" value="3P3QsMVK89JBNqZQv5zMAKG8FK3kJM4rjt" />`

`<input type="hidden" name="user_id" value="1" />`

`<input type="submit" value="Buy" />`

`</form>`




Example of the link:
https://indacoin.com/gw/payment_form?partner=bitcoinist&cur_from=USD&cur_to=BCD&amount=100&address=1CGETsHqcQC5xU9y3oh6FMpZE4UPKADy5m&user_id=test%40gmail.com

### 2.2 Transaction statuses 

**NotFound** — the transaction is not found, the payment did not make it to the transaction;

**Chargeback** — a reversed money transfer to the customer ordered by the bank;

**Declined** — the payment was declined most probably due to the bank card not supporting 3DS;

**Cancelled** — the payment was not made within a few hours after the transaction had been created;

**Failed** — common case, the payment failed due to the different reasons;
 
**Draft** — the payment has not been made yet; 

**Paid** — money was debited from the user’s bank account;

**Verification** — the user started the verification process;

**FundsSent** — the coins were sent out to the user’s wallet address, but it has not been received yet;

**Finished** — the coins were received successfully by the user.

## 3. API Integration

### 3.1 API_DOC
The description of the API can be found at:  https://indacoin.com/ru-RU/api_doc

### 3.2. The simplest API integration algorithm
Create a transaction and then generate links using transaction_id, partner name, and secret key.
Example:

`$transaction_id =; //get it from createTransaction method`

`$string=$partnername."_".$transaction_id;`

`$secret="secret";`

`$sig = base64_encode(base64_encode(hash_hmac('sha256', $string, $secret,true)));`





