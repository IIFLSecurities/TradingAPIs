"""
Get your API keys from https://api.iiflsecurities.com/api-keys.html
"""
import configparser

config = configparser.ConfigParser()
config.read("keys.conf")
try:
    section = config["KEYS"]
except KeyError:
    raise Exception("Please configure your keys in keys.conf")

APP_SOURCE = config["KEYS"]["APP_SOURCE"]
APP_NAME = config["KEYS"]["APP_NAME"]
USER_ID = config["KEYS"]["USER_ID"]
PASSWORD = config["KEYS"]["PASSWORD"]
USER_KEY = config["KEYS"]["USER_KEY"]
ENCRYPTION_KEY = config["KEYS"]["ENCRYPTION_KEY"]
OCP_KEY = config["KEYS"]["OCP_KEY"]