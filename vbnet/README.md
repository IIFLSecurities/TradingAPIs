# IIFL Market Trading APIs VB.NET examples

This working examples demonstrates the usage of market OpenApi.
The complete API reference document is available [here](http://images.indiainfoline.com/mailers/landingpage/Trade-API-Custom/Trade-API-Landingpage17Aug/landing-page.html)

## API Keys
For getting the API keys, the user must have a trading account with IIFL Securities (Trading Terminal). Only if the user has an active trading account, he would be able to use our Open APIs. The user needs to follow the below mentioned steps to retrieve his API keys:

1. The user needs to login into his Trading Terminal account and he will be taken to the dashboard after successful login.
2. The user should then go the “My Account” tab and from the drop down menu, select “Profile”
3. Click on the “My Details” option from the Profile sub-menu, which will take you to the “Your Account Details” page.
4. The API keys will be listed in a tab window next to the equity tab.

## API Usage

```
<configuration>
  <appSettings>
    <add key="ServiceURL" value="https://dataservice.iifl.in/openapi/prod/"/>
    <!--<add key="ServiceURL" value="http://localhost:50848/Service1.svc/"/>-->
    <add key="LoginUserID" value="{{Enter your user login ID here}}"/>
    <add key="LoginPwd" value="{{Enter your user login password here}}"/>
    <add key="UserID" value="{{Enter your user ID here}}"/>
    <add key="Pwd" value="{{Enter your user password here}}"/>
    <add key="HeadKey" value="{{Enter head key here}}"/>    
    <add key="AppName" value="{{Enter your AppName here}}"/>
  </appSettings>
  ....
  ....
</configuration>
```



