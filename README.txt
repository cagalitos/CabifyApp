I have created a single page web application with a front end using angularJS 1.7 and a web API in the back end. There are two controllers, once in charge of the shop items and another one in charge of the cart itself.

The Web API has the promotions and items hardcoded on it, but ideally these records should be stored in a database. Since I did not know whether you would be able to run the projet with a localDB on it, I decided to hard code them (knowing this is far from ideal).

The application is easy to use and intuitive. You add items to the cart, which in turn returns a total and a total saved. Prommotions are explicitly shown in the items shop section for user information.