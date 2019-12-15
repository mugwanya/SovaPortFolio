define( function() {

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

    var deleteHistory = async function (userid, timestamp, callback) {
        //console.log('api/Framework/history/' + userid + '/' + timestamp);
        var response = await fetch('api/Framework/history/' + userid + '/' + timestamp, { method: 'DELETE' });
        var data = await response.json();
        callback(data);
    };

    var getHistory = async function (callback) {
        var response = await fetch('api/Framework/history/1');
        var data = await response.json();
        callback(data);
    };
    var getMarkingsByUserId = async function (callback) {
        var response = await fetch('api/Framework/markings/usermarkings/1');
        var data = await response.json();
        callback(data);
    };
    var bestMatchSearch = async function (query, callback) {
        var response = await fetch('api/qa/search/Best/1/'+ query);
        var data = await response.json();
        callback(data);
    };

    return {
        getNotesByMarkingId,
        getMarkingsByUserId,
        getPostsById,
        deleteHistory,
        getHistory,
        bestMatchSearch
    }
});