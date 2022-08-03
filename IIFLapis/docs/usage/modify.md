## Modifying an order

```py
test_order = Order(order_type="BUY", scrip_code=2885, quantity=1, exchange="N",
	exchange_segment="C", price=1164, is_intraday=False, atmarket=False, order_id=2,
	remote_order_id="1", exch_order_id="0", DisQty=0, stoploss_price=0,
	is_stoploss_order=False, ioc_order= False, is_vtd=False, ahplaced = "N",
	vtd=f"/Date({NEXT_DAY_TIMESTAMP})/", public_ip='192.168.1.1',
	order_validity=OrderValidity.DAY, traded_qty=0)
client.modify_order(order=test_order,client_id='client_code',order_requester_code='order_requester_code')
```
