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
        var response = await fetch('api/Framework/historydelete/'+ userid+ '/'+ timestamp);
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
    

    return {
        getWithFetchAsync,
        getNotesByMarkingId,
        getMarkingsByUserId,
        getPostsById,
        deleteHistory,
        getHistory
    }
});