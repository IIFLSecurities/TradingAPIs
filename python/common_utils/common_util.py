import os
import configparser
from django.http import JsonResponse
from common_utils import auth, custom_exceptions, ref_strings
import time

dir_path = os.path.dirname(os.path.realpath(__file__))

conf_file_path = dir_path+'/configuration.ini'
config = configparser.RawConfigParser()
config.read(conf_file_path)


def get_cookie():
    cookie_path = dir_path+'/cookie.txt'
    f = open(cookie_path,'r')
    cookie_ = f.readline()
    f.close()
    return cookie_

def write_cookie(cookie):
    cookie_path = dir_path+'/cookie.txt'
    f = open(cookie_path,'w')
    f.write(cookie)
    f.close()

def get_jwt():
    jwt_path = dir_path+'/jwt.txt'
    f = open(jwt_path,'r')
    jwt_ = f.readline()
    f.close()
    return jwt_

def write_jwt(jwt):
    jwt_path = dir_path+'/jwt.txt'
    f = open(jwt_path,'w')
    f.write(jwt)
    f.close()

auth = auth.EncryptionClient()

def get_env():
    return config

def get_error_traceback(sys, e):
    exc_type, exc_obj, exc_tb = sys.exc_info()
    fname = os.path.split(exc_tb.tb_frame.f_code.co_filename)[1]
    return "%s || %s || %s || %s" %(exc_type, fname, exc_tb.tb_lineno,e)

def check_if_present(*args,**kwargs):
    """
    For Server Side Checks
    """
    # print (args)
    if not all(arg for arg in args):
        raise custom_exceptions.UserException(ref_strings.Common.missing_req_param)

    if not all(val for key, val in kwargs.items()):
        raise custom_exceptions.UserException(ref_strings.Common.missing_req_param)

def send_sucess_message(param={}):
    param['sucess'] = True
    return JsonResponse(param)


def send_error_message(param={}):
    param['sucess'] = False
    return JsonResponse(param)


def time_milli_second(expiry_time=False):
    if expiry_time:
        return int((time.time()+24*3600)*1000.0)  ##assuming expiry time is 24 hr from now
    return int(time.time()*1000.0)