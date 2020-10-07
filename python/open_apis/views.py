import sys, os
import json
import urllib3
from django.views.decorators.csrf import csrf_exempt
from common_utils import common_util,ref_strings, custom_exceptions
import requests as req
import http.cookiejar
cookielib = http.cookiejar



http = urllib3.PoolManager()
env = common_util.get_env()
cookie_ = 'kpkk5weaq3e5opiuetauakry'
AppSource = env.get('credentials', 'AppSource')

@csrf_exempt
def loginRequestMobileForVendor(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)
            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            Email_id = env.get('credentials', 'Email_id')
            ContactNumber = env.get('credentials', 'ContactNumber')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')

            #server side check to see if all required params are passed
            common_util.check_if_present(UserKey, AppName, UserId, Password, Email_id, ContactNumber, EncryKey, OAS_key)

            url = env.get('urls', 'loginRequestMobileForVendor')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQLoginForVendor",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": common_util.auth.encrypt(UserId),
                        "password": common_util.auth.encrypt(Password)
                    },
                "body": {
                    "Email_id": Email_id,
                    "ContactNumber": ContactNumber,
                    "LocalIP": "192.168.88.41",
                    "PublicIP": "192.168.88.42"
                 }
            }

            session = req.Session()
            resp = session.post(url=url,headers=header,data=json.dumps(payload))
            print (resp.cookies)
            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)
            resp = json.loads(resp.text)
            resp['cookies'] = session.cookies.get_dict()
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()

@csrf_exempt
def LoginRequestV2(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            ClientCode = post_data.get('ClientCode', '')
            Password_ = post_data.get('Password', '')
            HDSerialNumber = post_data.get('HDSerialNumber', '')
            MACAddress = post_data.get('MACAddress', '')
            MachineID = post_data.get('MachineID', '')
            VersionNo = post_data.get('VersionNo', '')
            My2PIN = post_data.get('My2PIN', '')

            #server side check to see is all required input is passed
            common_util.check_if_present(UserKey, AppName, UserId, Password, EncryKey, OAS_key, ClientCode, Password_, HDSerialNumber,
                                         MACAddress, MachineID, VersionNo, My2PIN)

            url = env.get('urls', 'LoginRequestV2')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQLoginForVendor",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": {
                    "ClientCode": common_util.auth.encrypt(ClientCode),
                    "Password": common_util.auth.encrypt(Password_),
                    "HDSerialNumber": HDSerialNumber,
                    "MACAddress": MACAddress,
                    "MachineID": MachineID,
                    "VersionNo": VersionNo,
                    "RequestNo": 1,
                    "My2PIN": common_util.auth.encrypt(My2PIN),
                    "ConnectionType": 1,
                    "LocalIP": "192.168.88.41",
                    "PublicIP": "192.168.88.42"
                 }
            }
            print (payload)
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)
            
            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()


@csrf_exempt
def OrderRequest(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            AppSource = env.get('credentials', 'AppSource')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "_ReqData" : {
                    "head": {
                            "requestCode": "IIFLMarRQOrdReq",
                            "key": UserKey,
                            "appVer": "1.0",
                            "appName": AppName,
                            "osName": "Android",
                            "userId": UserId,
                            "password": Password
                        },
                    "body": {
                            "ClientCode": post_data.get('ClientCode'),
                            "OrderRequesterCode": post_data.get('ClientCode'),
                            "OrderFor": post_data.get('OrderFor'),
                            "Exchange": post_data.get('Exchange'),
                            "ExchangeType": post_data.get('ExchangeType'),
                            "Price":post_data.get('Price'),
                            
                            "OrderID":3,   #random value
                            
                            "OrderType": post_data.get('OrderType'),
                            "Qty": post_data.get('Qty'),
                            "OrderDateTime": '/Date('+str(common_util.time_milli_second()) + ')/',
                            
                            "TradedQty":0,  #For placing fresh order, value should be 0. For modification/cancellation, send the actual traded qty.


                            "ScripCode": post_data.get('ScripCode'), #stock code

                            "AtMarket": post_data.get('AtMarket', 'false'), #false --> limit order true --> market order
                            "RemoteOrderID": "s000220360", ##unique id for each order

                            "ExchOrderID": "0",  #Send 0 for fresh order and for modify cancel send the exchange order id received from exchange.
                            "DisQty": post_data.get('DisQty'), #display qty 
                            
                            "StopLossPrice": post_data.get('StopLossPrice'),  #shoould be checked outside before implementing here
                            "IsStopLossOrder": post_data.get('IsStopLossOrder', 'false'),

                            "IOCOrder": post_data.get('IOCOrder', 'false'),
                            "IsIntraday": post_data.get('IsIntraday', 'false'),

                            "ValidTillDate":   '/Date('+str(common_util.time_milli_second(expiry_time=True)) + ')/',
                            "PublicIP": "192.168.84.215",
                            "iOrderValidity": post_data.get('iOrderValidity', 0),
                            "IsVTD": post_data.get('IsVTD', 'false'),
                            "AHPlaced": post_data.get('AHPlaced')
                    }
            },
                "AppSource": int(AppSource)
            }
            print (json.dumps(payload))
            url = env.get('urls', 'OrderRequest')
            
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }

            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()


@csrf_exempt
def HoldingV2(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQHoldingV2",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": {
                        "ClientCode": post_data.get('ClientCode')
                }
            }

            url = env.get('urls', 'HoldingV2')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)


    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()


@csrf_exempt
def MarginV3(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQMarginV3",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": {
                        "ClientCode": post_data.get('ClientCode')
                }
            }

            url = env.get('urls', 'MarginV3')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()


@csrf_exempt
def OrderBookV2(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQOrdBkV2",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": {
                        "ClientCode": post_data.get('ClientCode')
                }
            }

            url = env.get('urls', 'OrderBookV2')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            print (payload)
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()

@csrf_exempt
def TradeBookV1(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQTrdBkV1",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": {
                        "ClientCode": post_data.get('ClientCode')
                }
            }

            url = env.get('urls', 'TradeBookV1')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()


@csrf_exempt
def PreOrdMarginCalculation(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQPreOrdMarCal",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                    "body": {
                        "OrderRequestorCode" : post_data.get('OrderRequestorCode'),
                        "Exch": post_data.get('Exch'),
                        "ExchangeType": post_data.get('ExchangeType'),
                        "ClientCode" : post_data.get('ClientCode'),
                        "ScripCode" : post_data.get('ScripCode'),
                        "PlaceModifyCancel": post_data.get('PlaceModifyCancel'),
                        "TransactionType": post_data.get('TransactionType'),
                        "AtMarket": post_data.get('AtMarket'),
                        "LimitRate": post_data.get('LimitRate'),
                        "WithSL": post_data.get('WithSL'),
                        "SLTriggerRate": post_data.get('SLTriggerRate'),
                        "IsSLTriggered": post_data.get('IsSLTriggered'),
                        "Volume": post_data.get('Volume'),
                        "OldTradedQty": post_data.get('OldTradedQty'),
                        "ProductType": post_data.get('ProductType'),
                        "ExchOrderId" : "96131461", #same as that of order id
                        "ClientIP": "192.168.84.215",
                        "AppSource": int(AppSource)
                    }
            }
            print(payload)
            url = env.get('urls', 'PreOrdMarginCalculation')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
    
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()


@csrf_exempt
def TradeInformation(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQTrdInfo",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": post_data
            }

            url = env.get('urls', 'TradeInformation')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()



@csrf_exempt
def NetPositionV4(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQNetPositionV4",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": {
                        "ClientCode": post_data.get('ClientCode')
                }
            }

            url = env.get('urls', 'NetPositionV4')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')

            resp = http.request(
                method='POST',
                url=url,
                headers=header,
                body=json.dumps(payload)
            )
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()


@csrf_exempt
def NetPositionNetWiseV1(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQNPNWV1",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": {
                        "ClientCode": post_data.get('ClientCode')
                }
            }

            url = env.get('urls', 'NetPositionNetWiseV1')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()


@csrf_exempt
def OrderStatus(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQOrdStatus",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": post_data
            }

            url = env.get('urls', 'OrderStatus')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()



@csrf_exempt
def MarketFeed(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQMarketFeed",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": post_data
            }

            url = env.get('urls', 'MarketFeed')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()



@csrf_exempt
def BackoffClientProfile(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQBackoffClientProfile",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": {
                        "ClientCode": post_data.get('ClientCode')
                }
            }

            url = env.get('urls', 'BackoffClientProfile')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()



@csrf_exempt
def BackoffEquitytransaction(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQBackoffEquitytransaction",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": post_data
            }

            url = env.get('urls', 'BackoffEquitytransaction')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()



@csrf_exempt
def BackoffFutureTransaction(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQBackoffFutureTransaction",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": post_data
            }

            url = env.get('urls', 'BackoffFutureTransaction')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()



@csrf_exempt
def BackoffoptionTransaction(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQBackoffoptionTransaction",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": post_data
            }

            url = env.get('urls', 'BackoffoptionTransaction')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()



@csrf_exempt
def BackoffMutualFundTransaction(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQBackoffMutulFundTransaction",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": post_data
            }
            print (payload)
            url = env.get('urls', 'BackoffMutualFundTransaction')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()



@csrf_exempt
def BackoffLedger(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQBackoffLedger",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": post_data
            }

            url = env.get('urls', 'BackoffLedger')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()



@csrf_exempt
def BackoffDPTransaction(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQBackoffDPTransaction",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": post_data
            }

            url = env.get('urls', 'BackoffDPTransaction')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()



@csrf_exempt
def BackoffDPHolding(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)

            UserKey = env.get('credentials', 'UserKey')
            AppName = env.get('credentials', 'AppName')
            UserId = env.get('credentials', 'UserId')
            Password = env.get('credentials', 'Password')
            EncryKey = env.get('credentials', 'EncryKey')
            OAS_key = env.get('credentials', 'Ocp-Apim-Subscription-Key')
            
            payload = {
                "head": {
                        "requestCode": "IIFLMarRQBackoffDPHolding",
                        "key": UserKey,
                        "appVer": "1.0",
                        "appName": AppName,
                        "osName": "Android",
                        "userId": UserId,
                        "password": Password
                    },
                "body": {
                        "ClientCode": post_data.get('ClientCode')
                }
            }

            url = env.get('urls', 'BackoffDPHolding')
            header = {
                "Content-Type": "application/json",
                "Ocp-Apim-Subscription-Key": OAS_key
            }
            cookies = req.cookies.RequestsCookieJar()
            cookies.set('IIFLMarcookie', cookie_, domain = 'dataservice.iifl.in')
            resp = req.post(url = url, headers = header, data = json.dumps(payload), cookies = cookies)

            if not resp.status_code == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.text)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()


