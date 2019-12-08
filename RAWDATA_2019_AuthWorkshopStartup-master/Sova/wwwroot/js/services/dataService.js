define( function() {

    var getWithFetchAsync = async function (url, callback) {
        var response = await fetch(url);
        var data = await response.json();
        callback(data);
    };

    return {
        getWithFetchAsync
        
    }
});