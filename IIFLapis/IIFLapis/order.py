"""
Contains base classes for Orders etc.
"""
from .const import GENERIC_PAYLOAD, ORDER_PAYLOAD, HEADERS, NEXT_DAY_TIMESTAMP
import requests
from .conf import APP_SOURCE
from enum import Enum


class Exchange(Enum):

    NSE = "N"
    BSE = "B"
    MCX = "M"


class ExchangeSegment(Enum):

    CASH = "C"
    DERIVATIVE = "D"
    CURRENCY = "U"


class OrderFor(Enum):

    PLACE = "P"
    MODIFY = "M"
    CANCEL = "C"


class OrderType(Enum):

    BUY = "BUY"
    SELL = "SELL"


class OrderValidity(Enum):

    DAY = 0
    GTD = 1
    GTC = 2
    IOC = 3
    EOS = 4
    FOK = 6


class AHPlaced(Enum):

    AFTER_MARKET_CLOSED = "Y"
    NORMAL_ORDER = "N"


class Order:

    def __init__(self, order_type: str, scrip_code: int, quantity: int, exchange: str,
                 exchange_segment: str, price: float ,is_intraday: bool , atmarket: bool ,order_id: int = 0,
                  remote_order_id: str = "1", exch_order_id: str = "0", order_for: OrderFor = OrderFor.PLACE,
                 DisQty: int=0, stoploss_price: float = 0, is_stoploss_order: bool = False, ioc_order: bool = False,
                  is_vtd: bool = False, vtd: str = f"/Date({NEXT_DAY_TIMESTAMP})/",
                 ahplaced: AHPlaced = AHPlaced.NORMAL_ORDER, public_ip: str = '192.168.1.1',
                 order_validity: OrderValidity = OrderValidity.DAY, traded_qty: int = 0):

        self.order_for = order_for.value
        self.exchange = exchange
        self.exchange_segment = exchange_segment
        self.price = price
        self.order_id = order_id
        self.order_type = order_type
        self.quantity = quantity
        self.scrip_code = scrip_code
        self.atmarket = atmarket
        self.remote_order_id = remote_order_id
        self.exch_order_id = exch_order_id
        self.DisQty=DisQty
        self.stoploss_price = stoploss_price
        self.is_stoploss_order = is_stoploss_order
        self.ioc_order = ioc_order
        self.is_intraday = is_intraday
        self.is_vtd = is_vtd
        self.vtd = vtd
        self.ahplaced = ahplaced.value
        self.public_ip = public_ip
        self.order_validity = order_validity.value
        self.traded_qty = traded_qty