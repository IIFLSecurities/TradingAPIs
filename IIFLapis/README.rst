.. _IIFL-python-sdk:

IIFL Securities Python SDK
=================

   Python SDK for IIFL Trading APIs


Features
^^^^^^^^

-  Supports fetching user info including holdings, positions, margin and
   order book.
-  Supports order placement, modification and cancellation
-  Supports fetching order status and trade information.

Usage
~~~~~

Authentication
^^^^^^^^^^^^^^

.. code:: py

   from IIFLapis import IIFLClient

   client = IIFLClient(client_code="client_code", passwd="password", dob="YYYYMMDD", email_id="email", contact_number="Contact Number")
   client.client_login() #For Customer Login
   client.partner_login() #For Partner Login

After successful authentication, the cookie is persisted for subsequent
requests.

Fetching user info
^^^^^^^^^^^^^^^^^^

.. code:: py

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


Fetching transactions info
^^^^^^^^^^^^^^^^^^^^^^^^^^

.. code:: py

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


Placing an order
^^^^^^^^^^^^^^^^

.. code:: py

   # This is an indicative order.

   from IIFLapis.order import Order, OrderType, Exchange, ExchangeSegment, OrderValidity, AHPlaced

    ITC_order = Order(order_type="BUY", scrip_code=500875, quantity=1, exchange="B",
    exchange_segment="C", price=1164, is_intraday=False, atmarket=False, order_id=2,
    remote_order_id="1", exch_order_id="0", DisQty=0, stoploss_price=0,
    is_stoploss_order=False, ioc_order= False, is_vtd=False, ahplaced = "N",
    vtd=f"/Date({NEXT_DAY_TIMESTAMP})/", public_ip='192.168.1.1',
    order_validity=OrderValidity.DAY, traded_qty=0)

   print(client.place_order(order = ITC_order, client_id = 'client_code', order_requester_code = 'order_requester_code'))

Fetching Order Status and Trade Information
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

.. code:: py

    req_list= [
        {
            "Exch": "N",
            "ExchType": "C",
            "ScripCode": 20374,
            "ExchOrderID": "1000000015310807"
        }]

    # Fetches the trade details
    print(client.fetch_trade_info(req_list=req_list,client_id='client_code'))
    
    req_list_= [
          {
              "Exch": "N",
              "ExchType": "C",
              "ScripCode": 20374,
              "RemoteOrderID": "90980441"
          }]

    # Fetches the order status
    print(client.fetch_order_status(req_list=req_list,client_id='client_code'))

TODO
^^^^

-  Handle responses more gracefully.
-  Write tests.
-  Add logging

Credits
^^^^^^^

This package was created with `Cookiecutter`_ and the
`audreyr/cookiecutter-pypackage`_ project template.

.. _Cookiecutter: https://github.com/audreyr/cookiecutter
.. _audreyr/cookiecutter-pypackage: https://github.com/audreyr/cookiecutter-pypackage

.. |IIFL logo| image:: images/iifl-logo.png