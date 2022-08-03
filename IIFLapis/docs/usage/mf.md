#### Market Feed

```py
# NOTE : Symbol has to be in the same format as specified in the example below.

req_list_=[{"Exch":"N","ExchType":"C","ScripCode":"22"},
            {"Exch":"N","ExchType":"C","ScripCode":"2885"}]
            
client.fetch_market_feed(req_list=req_list_, count=2,client_id="client_code")
```

#### Historical Candle Data

```py
#To fetch historical candle data, jwt token needs to be validated first.
client.jwt_validation("client_code")

#After successful jwt validation, historical data can be fetched.            
client.historical_candles(exch='n',exchType='c',scripcode='1660',interval='30m',fromdate='2021-04-01',todate='2021-04-30',client_id="client_code")
```
