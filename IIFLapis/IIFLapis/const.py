"""
Contains reusable payloads across requests
"""
from .conf import APP_NAME, USER_ID, PASSWORD, USER_KEY, OCP_KEY, APP_SOURCE
from .auth import EncryptionClient
import datetime

HEADERS = {
    'Content-Type': 'application/json',
    'Ocp-Apim-Subscription-Key': OCP_KEY
}

HISTORICAL_CANDLE_HEADERS = {
    'Content-Type': 'application/json',
    'Ocp-Apim-Subscription-Key': OCP_KEY,
    'x-clientcode': '',   
    'x-auth-token': '' 
}

JWT_PAYLOAD = {
    "ClientCode": "",
    "JwtCode": ""    
}

GENERIC_PAYLOAD = {
    "head": {
        "appName": APP_NAME,
        "appVer": "1.0",
        "key": USER_KEY,
        "osName": "Android",
        "requestCode": "",
        "userId": USER_ID,
        "password": PASSWORD
    },
    "body": {
        "ClientCode": ""
    }
}

ORDER_PAYLOAD = {
    "_ReqData": {
        "head": {
            "appName": APP_NAME,
            "appVer": "1.0",
            "key": USER_KEY,
            "osName": "Android",
            "requestCode": "IIFLMarRQOrdReq",
            "userId": USER_ID,
            "password": PASSWORD
        },
        "body": {
            "ClientCode": ""
        }
    },
    "AppSource": int(APP_SOURCE)
}

CUSTOMER_LOGIN_PAYLOAD = {"head": {
    "appName": APP_NAME,
    "appVer": "1.0",
    "key": USER_KEY,
    "osName": "Android",
    "requestCode": "IIFLMarRQLoginRequestV2",
    "userId": USER_ID,
    "password": PASSWORD
},
    "body":
    {
    "ClientCode": "",
    "Password": "",
    "LocalIP": "192.168.10.10",
    "PublicIP": "192.168.10.10",
    "HDSerailNumber": " ",
    "MACAddress": " ",
    "MachineID": " ",
    "VersionNo": "1.0.16.0",
    "RequestNo": "1",
    "My2PIN": "",
    "ConnectionType": "1"
}
}

encryption_client_payload = EncryptionClient()

PARTNER_LOGIN_PAYLOAD = {"head": {
    "appName": APP_NAME,
    "appVer": "1.0",
    "key": USER_KEY,
    "osName": "Android",
    "requestCode": "IIFLMarRQLoginForVendor",
    "userId": encryption_client_payload.encrypt(USER_ID),
    "password": encryption_client_payload.encrypt(PASSWORD)
},
    "body":
    {
    "Email_id": "",
    "ContactNumber": "",
    "LocalIP": "192.168.10.10",
    "PublicIP": "192.168.10.10",
}
}


TODAY_TIMESTAMP = int(datetime.datetime.today().timestamp())
NEXT_DAY_TIMESTAMP = int(
    (datetime.datetime.today()+datetime.timedelta(days=1)).timestamp())
