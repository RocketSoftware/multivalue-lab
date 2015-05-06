#Consuming and Parsing JSON with UDO
UniVerse and UniData now have the ability to work with JSON or XML as an object, simplifying when you need to either create or consume those formats.  As of UniVerse 11.1 and UniData 7.3, U2 Dynamic Objects (UDO for short) help you easily work with these formats.

## Weather Service
To help us build our example, we'll use a free online weather service that gets us some data that we can parse. Wunderground has a weather API for developers at http://www.wunderground.com/weather/api/ , check out the details there, you can get a free account  and API code that allows you to test the service.

## What's JSON?
JSON stands for JavaScript Object Notation and is a language-independent way of expressing data that is easy for data exchange using HTTP and it is commonly understood by many software languages.  It is probably best to leave it to [Wikipedia](http://en.wikipedia.org/wiki/JSON) to explain it better if you are not familiar.  Once you get your API key above, you can test the weather service and see exactly what is returned. Below is just a brief snippet to give you a quick glance at what it will look like. It's important that you know the structure, because your code will need to know what to look for.

    {
    "response": {
    	"version":"0.1",
    },
    "forecast":{
    	"simpleforecast": 
			"forecastday": [
				{"date":{
					"epoch":"1421287200",
					"pretty":"7:00 PM MST on January 14, 2015",
    ....continued....

## The Code
Let's start by getting the JSON from the weather service:

    ** IMPORTANT ** You will have to get your own API key to call the service
    apiKey = "0123abcd01234abcd"
    city = "CO/Denver"
    url = "http://api.wunderground.com/api/":apiKey:"/forecast/q/":city:".json"
    method = "GET"
    request = ""
    
    st = createRequest(url, method, objRequest)
    st = submitRequest(objRequest, 3600, "", headers, data, httpstatus)

At this point, if everything went right, then we should have JSON data in the **data** parameter.

    IF UDORead(data, UDOFORMAT_JSON, RESTMSG) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER
    IF UDOGetProperty(RESTMSG, "forecast", forecast, UDOTYPE) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER
    IF UDOGetProperty(forecast, "simpleforecast", simple, UDOTYPE) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER
    IF UDOGetProperty(simple, "forecastday", arrDays, UDOTYPE) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER

The UDORead function reads a JSON string from the first parameter and returns a UDO object in the third parameter if valid.  Notice the parameters in the next 3 UDOGetProperty calls, we are traversing down the object tree, from **forecast** object to **simpleforecast** object to the **forecastday** array.

Once we have the forecastday array, we can simply loop through each item and grab the values we are interested in. Just make sure you free the memory used by the UDO by calling UDOFree() when you are done.

    LOOP
		GETSTAT = UDOArrayGetNextItem(arrDays, W.UDO, W.TYPE)
	WHILE GETSTAT = UDO_SUCCESS DO
		i = i + 1
		IF UDOGetProperty(W.UDO, "date", UDO.DATE, UDOTYPE) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER
		IF UDOGetProperty(UDO.DATE, "monthname", F.MONTH, UDOTYPE) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER
		IF UDOGetProperty(UDO.DATE, "day", F.DAY, UDOTYPE) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER
		IF UDOGetProperty(UDO.DATE, "year", F.YEAR, UDOTYPE) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER
		IF UDOGetProperty(W.UDO, "high", UDO.HIGH, UDOTYPE) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER
		IF UDOGetProperty(UDO.HIGH, "fahrenheit", HF, UDOTYPE) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER
		IF UDOGetProperty(W.UDO, "low", UDO.LOW, UDOTYPE) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER
		IF UDOGetProperty(UDO.LOW, "fahrenheit", LF, UDOTYPE) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER
		IF UDOGetProperty(W.UDO, "conditions", CONDITIONS, UDOTYPE) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER
		PRINT F.MONTH:" ":F.DAY:", ":F.YEAR
		PRINT "  High: ":HF:"    Low: ":LF
		PRINT "  Conditions: ":CONDITIONS
		PRINT
	REPEAT

	IF UDOFree(RESTMSG) NE UDO_SUCCESS THEN GOSUB ERR.HANDLER

## The Result

    Weather Forecast for CO/Denver
    ------------------------------
    January 6, 2015
      High: 55    Low: 15
      Conditions: Partly Cloudy
    
    January 7, 2015
      High: 34    Low: 27
      Conditions: Partly Cloudy
    
    January 8, 2015
      High: 46    Low: 17
      Conditions: Partly Cloudy
    
    January 9, 2015
      High: 32    Low: 18
      Conditions: Clear

## Read The UDO Documentation
I've only touched on specific functions with this demo regarding UDO. To be thorough, you should probably read the documentation, found in the [BASIC Extensions Manual](http://www.rocketsoftware.com/brand/rocket-u2/technical-documentation). Click on the PDF next to UniVerse or UniData to get a list of all the available manuals.

