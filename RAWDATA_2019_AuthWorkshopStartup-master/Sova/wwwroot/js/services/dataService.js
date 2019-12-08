define( function() {

    var getUsersWithFetchAsync = async function (url, callback) {
        var response = await fetch(url);
        var data = await response.json();
        callback(data);
    };

    var getPosts = async function (url, callback) {
        var response = await fetch(url);
        var data = await response.json();
        callback(data);
    };

    var getHistory = async function (url, callback) {
        var response = await fetch(url);
        var data = await response.json();
        callback(data);
    };

    return {
        getUsersWithFetchAsync,
        getHistory,
        getPosts
   
    }
});