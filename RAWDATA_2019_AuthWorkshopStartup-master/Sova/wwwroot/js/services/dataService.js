define(["jquery"], function($) {
    var getNamesWithJQyery = function(callback) {
        $.getJSON("api/names", callback);
    };

    var getNamesWithFetch = function(callback) {
        fetch("api/names")
            .then(function(response) {
                return response.json();
            })
            .then(function(data) {
                callback(data);
            });
    };

    var getNamesWithFetchAsync = async function(url, callback) {
        var response = await fetch(url);
        var data = await response.json();
        callback(data);
    };





    var getUsersWithJQuery = function (url, callback) {
        $.getJSON(url, callback);
    };

    return {
        getNamesWithJQyery,
        getNamesWithFetch,
        getNamesWithFetchAsync,
        getUsersWithJQuery
    }
});