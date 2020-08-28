import sys, os
import json
import urllib3
from django.views.decorators.csrf import csrf_exempt
from common_utils import common_util,ref_strings, custom_exceptions

http = urllib3.PoolManager()
env = common_util.get_env()


@csrf_exempt
def loginRequestMobileForVendor(requests):
    try:
        if requests.method == 'POST':
            post_data = json.loads(requests.body)
            UserKey = post_data.get('UserKey', '')
            AppName = post_data.get('AppName', '')
            UserId = post_data.get('UserId', '')
            Password = post_data.get('Password', '')
            Email_id = post_data.get('Email_id', '')
            ContactNumber = post_data.get('ContactNumber', '')
            EncryKey = post_data.get('EncryKey', '')
            OAS_key = post_data.get('Ocp-Apim-Subscription-Key', '')

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

            resp = http.request(
                method='POST',
                url=url,
                headers=header,
                body=json.dumps(payload)
            )
            if not resp.status == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.data)
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

            credentials = post_data.get('credentials', 'NA')
            body = post_data.get('body', 'NA')

            #server side check to see is body and credentials is passed
            common_util.check_if_present(credentials, body)

            UserKey = credentials.get('UserKey', '')
            AppName = credentials.get('AppName', '')
            UserId = credentials.get('UserId', '')
            Password = credentials.get('Password', '')
            EncryKey = credentials.get('EncryKey', '')
            OAS_key = credentials.get('Ocp-Apim-Subscription-Key', '')

            ClientCode = body.get('ClientCode', ''),
            Password_ = body.get('Password', ''),
            HDSerialNumber = body.get('HDSerialNumber', '')
            MACAddress = body.get('MACAddress', '')
            MachineID = body.get('MachineID', '')
            VersionNo = body.get('VersionNo', '')
            My2PIN = body.get('My2PIN', '')

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
                        "userId": common_util.auth.encrypt(UserId),
                        "password": common_util.auth.encrypt(Password)
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

            resp = http.request(
                method='POST',
                url=url,
                headers=header,
                body=json.dumps(payload)
            )
            if not resp.status == 200:
                raise common_util.custom_exceptions.UserException(ref_strings.Common.bad_response)

            resp = json.loads(resp.data)
            return common_util.send_sucess_message(resp)

    except custom_exceptions.UserException as e:
        return common_util.send_sucess_message({'msg': str(e)})
    except Exception as e:
        error = common_util.get_error_traceback(sys, e)
        print(error)
        return common_util.send_error_message()
