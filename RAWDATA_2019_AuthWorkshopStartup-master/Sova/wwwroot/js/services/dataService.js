define( function() {

    var getWithFetchAsync = async function (url, callback) {
        var response = await fetch(url);
        var data = await response.json();
        callback(data);
    };

    var getMarkingsByUserId = async function (callback) {
        var response = await fetch('api/Framework/markings/usermarkings/1');
        var data = await response.json();
        callback(data);
    };

    var getNotesByMarkingId = async function (markingid, callback) {
        var response = await fetch('api/Framework/notes/markings/' + markingid);
        var data = await response.json();
        callback(data);
    };

    var getPostsById = async function (postid, callback) {
        var response = await fetch('api/qa/posts/' + postid);
        var data = await response.json();
        callback(data);
    };

    return {
        getWithFetchAsync,
        getNotesByMarkingId,
        getMarkingsByUserId,
        getPostsById
    }
});