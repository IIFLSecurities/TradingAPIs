# IIFL Securities Open apis: Python


### Project Requirement
  - Python >3.*
  - Django


### How to install python 3.6
  ```
sudo add-apt-repository ppa:deadsnakes/ppa
sudo apt-get update
sudo apt install python3.6
wget https://bootstrap.pypa.io/get-pip.py
sudo python3.6 get-pip.py
sudo ln -s /usr/bin/python3.6 /usr/local/bin/python3
```


When python is installed you need to install project dependency

```
pip install -r requirement.txt
```
> Above command should be executed in root directory where requirement.txt is present

##### Ones project dependency is installed, follow following step to run the program

```python3.6 manage.py runserver  0.0.0.0:8080```
 >application will start in http://localhost:8080 

Sample post data has been attached with file name : ```Insomnia_2020-10-07.json``` please import it in postman/insomnia

#### location of main Apis
> /open_apis/views.py

### Running Application procedure:
  - Vendor credentials has been added in offline file ```configuration.ini```, please change the file accordingly
  - After vendor login you will get cookie as response, please add the cookie manually in /open_apis/views.py with key name cookie_ as per provided example:
 ``` cookie_ = 'kpkk5weaq3e5opiuetauakry'```

