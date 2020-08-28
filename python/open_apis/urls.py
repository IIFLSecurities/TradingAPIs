from django.urls import path
from . import views

urlpatterns = [
    path('loginRequestMobileForVendor/', views.loginRequestMobileForVendor, name='loginRequestMobileForVendor'),
    path('LoginRequestV2/', views.LoginRequestV2, name='LoginRequestV2')
]