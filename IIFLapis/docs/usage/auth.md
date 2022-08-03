### Authentication

#### Configuring API keys

Get your API keys from <a href="https://api.iiflsecurities.com/api-keys.html" target="_blank">here</a>

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

#### Login

```py
from IIFLapis import IIFLClient

client = IIFLClient(client_code="client_code", passwd="password", dob="YYYYMMDD", email_id="email",contact_number="Contact Number")
client.client_login() #For Customer Login
client.partner_login() #For Partner Login
```

After successful authentication, you should get a `Logged in!!` message.