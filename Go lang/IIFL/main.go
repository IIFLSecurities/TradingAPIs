package main

import (
	"GOLangAPIIIFL/class"
	"fmt"
	"log"
	"net/http"

	"github.com/gorilla/mux"
)

func handleRequests() {
	// creates a new instance of a mux router
	myRouter := mux.NewRouter().StrictSlash(true)

	// replace http.HandleFunc with myRouter.HandleFunc

	myRouter.HandleFunc("/LoginRequestMobileForVendor", class.LoginRequestMobileForVendor)
	myRouter.HandleFunc("/LoginRequest", class.LoginRequest)
	myRouter.HandleFunc("/Holding", class.Holding)
	myRouter.HandleFunc("/MarketFeed", class.MarketFeed)
	myRouter.HandleFunc("/OrderRequest", class.OrderRequest)
	myRouter.HandleFunc("/OrderStatus", class.OrderStatus)
	myRouter.HandleFunc("/TradeInformation", class.TradeInformation)
	myRouter.HandleFunc("/Margin", class.Margin)
	myRouter.HandleFunc("/OrderBookV2", class.OrderBookV2)
	myRouter.HandleFunc("/TradeBook", class.TradeBook)
	myRouter.HandleFunc("/NetPosition", class.NetPosition)
	myRouter.HandleFunc("/NetPositionNetWise", class.NetPositionNetWise)
	myRouter.HandleFunc("/PreOrdMarginCalculation", class.PreOrdMarginCalculation)
	myRouter.HandleFunc("/BackoffMutualFundTransaction", class.BackoffMutualFundTransaction)
	myRouter.HandleFunc("/BackoffClientProfile", class.BackoffClientProfile)
	myRouter.HandleFunc("/BackoffEquitytransaction", class.BackoffEquitytransaction)
	myRouter.HandleFunc("/BackoffFutureTransaction", class.BackoffFutureTransaction)
	myRouter.HandleFunc("/BackoffoptionTransaction", class.BackoffoptionTransaction)
	myRouter.HandleFunc("/BackoffLedger", class.BackoffLedger)
	myRouter.HandleFunc("/BackoffDPTransaction", class.BackoffDPTransaction)
	myRouter.HandleFunc("/BackoffDPHolding", class.BackoffDPHolding)

	// finally, instead of passing in nil, we want
	// to pass in our newly created router as the second
	// argument
	log.Fatal(http.ListenAndServe(":10000", myRouter))
}

func main() {
	fmt.Println("Rest API v1.0 - IIFL Routers")

	handleRequests()
}
