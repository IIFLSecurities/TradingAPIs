### Information

#### User information

```py
# Fetches client profile
client.profile(client_id = "client_code")

# Fetches holdings
client.holdings(client_id = "client_code")

# Fetches DP holdings
client.dp_holdings(client_id = "client_code")

# Fetches margin
client.margin(client_id = "client_code")

# Fetches net positions
client.net_positions(client_id = "client_code")

# Fetches net wise positions
client.net_position_netwise(client_id = "client_code")

# Fetches the order book of the client
client.order_book(client_id = "client_code")

# Fetches the trade book of the client
client.trade_book(client_id = "client_code")
```

#### Fetching transactions info

```py
# Fetches equity transactions
client.equity_transactions(client_id="client_code", from_date="20210201", to_date="20210301")

# Fetches future transactions
client.future_transactions(client_id="client_code", from_date="20210201", to_date="20210301")

# Fetches option transactions
client.option_transactions(client_id="client_code", from_date="20210201", to_date="20210301")

# Fetches mutual funds transactions
client.mf_transactions(client_id="client_code", from_date="20210201", to_date="20210301")

# Fetches DP transactions
client.dp_transactions(client_id="client_code", from_date="20210201", to_date="20210301")

# Fetches ledger
client.ledger(client_id="client_code", from_date="20210201", to_date="20210301")
```


#### Order Status and Trade Information

```py

req_list= [

        {
            "Exch": "N",
            "ExchType": "C",
            "ScripCode": 20374,
            "ExchOrderID": "1000000015310807"
        }]

# Fetches the trade details
client.fetch_trade_info(req_list=req_list,client_id='client_code')

req_list_= [

        {
            "Exch": "N",
            "ExchType": "C",
            "ScripCode": 20374,
            "RemoteOrderID": "90980441"
        }]
# Fetches the order status
client.fetch_order_status(req_list=req_list_,client_id='client_code')
```