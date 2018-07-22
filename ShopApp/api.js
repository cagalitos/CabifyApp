var API = {};

API.BASE_URL = 'http://localhost:49629/api/';

API.ITEMS = API.BASE_URL + 'items';
API.CART = API.BASE_URL + 'cart';

API.set = function (key, value) {
    API[key] = value;
}

API.get = function (key) {
    return API[key];
}