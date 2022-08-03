from django.urls import path
from . import views

urlpatterns = [
    path('loginRequestMobileForVendor/', views.loginRequestMobileForVendor, name='loginRequestMobileForVendor'),
    path('LoginRequestV2/', views.LoginRequestV2, name='LoginRequestV2'),
    path('JWTOpenApiValidation/', views.JWTOpenApiValidation, name='JWTOpenApiValidation'),
    path('OrderRequest/', views.OrderRequest, name='OrderRequest'),
    path('PlaceSMOOrder/', views.PlaceSMOOrder, name='PlaceSMOOrder'),
    path('AdvanceModifySMOOrder/', views.AdvanceModifySMOOrder, name='AdvanceModifySMOOrder'),
    path('HoldingV2/', views.HoldingV2, name='HoldingV2'),
    path('MarginV3/', views.MarginV3, name='MarginV3'),
    path('OrderBookV2/', views.OrderBookV2, name='OrderBookV2'),
    path('TradeBookV1/', views.TradeBookV1, name='TradeBookV1'),

    path('PreOrdMarginCalculation/', views.PreOrdMarginCalculation, name='PreOrdMarginCalculation'),
    path('TradeInformation/', views.TradeInformation, name='TradeInformation'),
    path('NetPositionV4/', views.NetPositionV4, name='NetPositionV4'),
    path('NetPositionNetWiseV1/', views.NetPositionNetWiseV1, name='NetPositionNetWiseV1'),
    path('OrderStatus/', views.OrderStatus, name='OrderStatus'),
    path('MarketFeed/', views.MarketFeed, name='MarketFeed'),
    path('HistoricalCandles/', views.HistoricalCandles, name='HistoricalCandles'),
    path('BackoffClientProfile/', views.BackoffClientProfile, name='BackoffClientProfile'),
    path('BackoffEquitytransaction/', views.BackoffEquitytransaction, name='BackoffEquitytransaction'),
    path('BackoffFutureTransaction/', views.BackoffFutureTransaction, name='BackoffFutureTransaction'),
    path('BackoffoptionTransaction/', views.BackoffoptionTransaction, name='BackoffoptionTransaction'),
    path('BackoffMutualFundTransaction/', views.BackoffMutualFundTransaction, name='BackoffMutualFundTransaction'),
    path('BackoffLedger/', views.BackoffLedger, name='BackoffLedger'),

    path('BackoffDPTransaction/', views.BackoffDPTransaction, name='BackoffDPTransaction'),
    path('BackoffDPHolding/', views.BackoffDPHolding, name='BackoffDPHolding'),

]