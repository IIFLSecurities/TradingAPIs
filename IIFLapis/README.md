# IIFL Securities Python SDK

Python SDK for IIFL Trading APIs


#### Documentation

Read the docs hosted [here](https://api.iiflsecurities.com/)

#### Features

-   Order placement, modification and cancellation
-   Fetching user info including holdings, positions, margin and order book.
-   Fetching live market feed.
-   Fetching order status and trade information.

### Installation

`pip install IIFLapis`

### Usage

#### Configuring API keys

Get your API keys from https://api.iiflsecurities.com/api-keys.html

Configure these keys in a file named `keys.conf` in the same directory as your python script exists

A sample `keys.conf` is given below:

```conf
[KEYS]
APP_NAME=YOUR_APP_NAME_HERE
APP_SOURCE=YOUR_APP_SOURCE_HERE
USER_ID=YOUR_USER_ID_HERE
PASSWORD=YOUR_PASSWORD_HERE
USER_KEY=YOUR_USER_KEY_HERE
ENCRYPTION_KEY=YOUR_ENCRYPTION_KEY_HERE
OCP_KEY=YOUR_OCP_KEY_HERE
```


#### Authentication

```py
from IIFLapis import IIFLClient

client = IIFLClient(client_code="client_code", passwd="password", dob="YYYYMMDD", email_id="email",contact_number="Contact Number")
client.client_login() #For Customer Login
client.partner_login() #For Partner Login
```


After successful authentication, you should get a `Logged in!!` message
#### Market Feed

```py
#NOTE : Symbol has to be in the same format as specified in the example below.

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


#### Fetching user info

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

Scrip codes reference:

Note : Use these Links for getting scrip codes

CSV Scrip Dump: https://api.iiflsecurities.com/scrip-master.html

#### Enums

Following are the enums which can be imported and used for placing more complex orders.


```py
class Exchange(Enum):

    NSE = "N"
    BSE = "B"
    MCX = "M"
```

```py
class ExchangeSegment(Enum):

    CASH = "C"
    DERIVATIVE = "D"
    CURRENCY = "U"
```

```py
class OrderType(Enum):

    BUY = "BUY"
    SELL = "SELL"
```

```py
class OrderValidity(Enum):

    DAY = 0
    GTD = 1
    GTC = 2
    IOC = 3
    EOS = 4
    FOK = 6
```

```py
class AHPlaced(Enum):

    AFTER_MARKET_CLOSED = "Y"
    NORMAL_ORDER = "N"
```


#### Placing an order

```py
# Note: This is an indicative order.

from IIFLapis.order import Order, OrderType, Exchange, ExchangeSegment, OrderValidity, AHPlaced

test_order = Order(order_type="BUY", scrip_code=2885, quantity=1, exchange="N",
    exchange_segment="C", price=1164, is_intraday=False, atmarket=False, order_id=2,
    remote_order_id="1", exch_order_id="0", DisQty=0, stoploss_price=0,
    is_stoploss_order=False, ioc_order= False, is_vtd=False,ahplaced = AHPlaced.NORMAL_ORDER,
    public_ip='192.168.1.1', order_validity=OrderValidity.DAY, traded_qty=0)
client.place_order(order=test_order,client_id='client_code',order_requester_code='order_requester_code')

```

#### Modifying an order

```py
test_order = Order(order_type="BUY", scrip_code=2885, quantity=1, exchange="N",
    exchange_segment="C", price=1164, is_intraday=False, atmarket=False, order_id=2,
    remote_order_id="1", exch_order_id="12345678", DisQty=0, stoploss_price=0,
    is_stoploss_order=False, ioc_order= False, is_vtd=False, ahplaced = "N",
    vtd=f"/Date({NEXT_DAY_TIMESTAMP})/", public_ip='192.168.1.1',
    order_validity=OrderValidity.DAY, traded_qty=0)
client.modify_order(order=test_order,client_id='client_code',order_requester_code='order_requester_code')
```

#### Canceling an order

```py
test_order = Order(order_type='B', scrip_code=1660, quantity=1,exchange='N',exchange_segment='C',exch_order_id='12345678')
client.cancel_order(order=test_order,client_id='client_code',order_requester_code='order_requester_code')
```


#### Fetching Order Status and Trade Information

```py
from IIFLapis.order import  Exchange

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

#### TODO
 - Write tests.


#### Credits

This package was created with
[Cookiecutter](https://github.com/audreyr/cookiecutter) and the
[audreyr/cookiecutter-pypackage](https://github.com/audreyr/cookiecutter-pypackage)
project template.