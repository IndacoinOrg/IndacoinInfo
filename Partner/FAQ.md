1. **CREATE TRANSACTION**

    a. Would be great to see what the response looks like.
    
		It will be just id of transaction if everything is ok and text of error if something is wrong*
    b. What is `user_id`? Seems it's different than the partner ID.
    
		It is unique user id in your system(email will be the best). Need for differentiating customers for us(limits, verifications etc)
        
    c. Does `target_address` need to be defined even if `cur_out` is BTC or ETH?
    
		It is wallet where we will withdrawal funds after payment
    d. Less of a technical question: If `cur_out` is fiat (USD, EUR), I assume Indacoin holds it for us until the next scheduled payment? And if crypto, the funds are sent relatively soon?
    
    	You are right, if cur_out is fiat- then funds will be accumulated on your acc at our platform (https://indacoin.com/login), and if cur_out is crypto - funds will be sended after verification
    
    e. What are the errors that this endpoint may produce? Let's say that `target_address` is invalid or missing, for example.
    
    	Before payment we are checking some kind of altcoins for right target_address, also we are checking amounts and that purchase of such altcoin is possible at this moment

2. **PRICE INFO**:
    a. Would be great to see what the response looks like.
    
		You can check live https://indacoin.com/api/GetCoinConvertAmount/USD/BTC/1000
    b. Is the returned amount a guarantee or an estimate at current market value?
    
		It returns estimated amount*
3. **TRANSACTION INFO**:
    a. Would be great to see what the response looks like.
    
		It will be just array of transactions infos

    b. Transaction info how it would be looks like.
    
		We have such on our api_doc page https://indacoin.com/en_gb/api_doc
 ```json        
  {
 			      "userId": "support@mail.com"
 			      ,"transactionId": 453668
 			      ,"requestId": -1
 			      ,"status": "Draft"
 			      ,"createdAt": "2018-05-11T11:40:03.75Z"
 			      ,"confirmedAt": "0001-01-01T00:00:00Z"
 			      ,"finishedAt": "0001-01-01T00:00:00Z"
 			      ,"blockchainHash": ""
 			      ,"link": "/notify.aspx?confirm_code=&request_id=-1"
 			      ,"curIn": "USD"
 			      ,"curOut": "BTC"
 			      ,"amountIn": 112.0
 			      ,"amountOut": 0.010335
 			      ,"realAmountOut": 0.0
 			      ,"targetAddress": "{
 			        "btcAddress":"mtULnCAMY3iUiZmxGUqARhKuoiZQbFT36H"
 			      }"
 			      ,"reason": ""
 			      ,"extra_info": {}
 			      ,"couponCode": ""
     }
```


5. **EXAMPLE OF HOW TO CREATE THE REQUEST ON PHP AND NODE.JS**:

    a. Does the nonce need to be sequential, or is it enough if the nonce is larger than the previous one?
    
		It is enough to nonce to be larger
    b. For clarification, is it correct that the signature only includes the nonce and partner name?
    
		yes
6. CALLBACK SECTION:
    a. How do we register our callback URL?
    
		After receiving keys- you can login to admin panel
    b. Dates: is it correct to assume that 0001-01-01T00:00:00Z means the event hasn't occured yet?
    
		yes
    c. Is `targetAddress` a string containing a JSON object?
    
		yes
    d. Does the callback get sent every time the status of a transaction changes?
    
		yes
    e. Do you retry if our server is temporarily unable to accept the callback (e.g. returns with HTTP 503)?
    
		Unfortunately not
