## Placing an order

```py
from IIFLapis.order import Order, OrderType, Exchange, ExchangeSegment, OrderValidity, AHPlaced

test_order = Order(order_type="BUY", scrip_code=2885, quantity=1, exchange="N",
    exchange_segment="C", price=1164, is_intraday=False, atmarket=False, order_id=2,
    remote_order_id="1", exch_order_id="0", DisQty=0, stoploss_price=0,
    is_stoploss_order=False, ioc_order= False, is_vtd=False, ahplaced = "N",
    vtd=f"/Date({NEXT_DAY_TIMESTAMP})/", public_ip='192.168.1.1',
    order_validity=OrderValidity.DAY, traded_qty=0)
client.place_order(order=test_order,client_id='client_code',order_requester_code='order_requester_code')

```

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

[Source](https://github.com/IIFLSecurities/TradingAPIs/IIFLapis/IIFLapis/order.py)