
Install python3.6 and pip with following command


sudo add-apt-repository ppa:deadsnakes/ppa
sudo apt-get update
sudo apt install python3.6
wget https://bootstrap.pypa.io/get-pip.py
sudo python3.6 get-pip.py
sudo ln -s /usr/bin/python3.6 /usr/local/bin/python3


Ones installed install dependency with following command from root directory where requirement.txt is present:

pip install -r requirement.txt


to run :


python3.6 manage.py runserver  0.0.0.0:8080


application will start in 8080 port


the api calls with relavent to apis has been attached here with name : Insomnia_2020-10-07.json please import it in postman/insomnia



Apis methos:
/open_apis/views.py


Application procedure:


1. Vendor credentials has been added in offline file configuration.ini, please change the file accordingly
2. After vendor login you will get cookie as response, please add the cookie manually in /open_apis/views.py with key name cookie_ as per example


