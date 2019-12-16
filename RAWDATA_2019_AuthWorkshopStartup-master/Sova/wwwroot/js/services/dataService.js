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
    //var deleteHistory = async function (userid, timestamp, callback) {
    //    //console.log('api/Framework/history/' + userid + '/' + timestamp);
    //    var response = await fetch('api/Framework/history/' + userid + '/' + timestamp, { method: 'DELETE' });
    //    var data = await response.json();
    //    callback(data);
    //};
    var getHistory = async function (url, callback) {
        if (callback === undefined) {
            callback = url;
            url = 'api/Framework/history/1';
        }
        var response = await fetch(url);
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
    var qaGetUsers = async function (callback) {
        var response = await fetch('api/QA/users');
        var data = await response.json();
        callback(data);
    };
    var getNextPage = async function (url, callback) {
        var response = await fetch(url);
        var data = await response.json();
        callback(data);
    }
    var addPostMarking = async function (userid, postId) {
        var data = {
            PostCommentsId: postId,
            UserId: userid
        }
        var response = await fetch('api/framework/markings/', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });    
        return await response.json();
    };
    var addNoteToMarking = async function ( markingid, note) {
        var data = {
            MarkingId: markingid,
            Note: note
        }
        var response = await fetch('api/Framework/notes/', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
        return await response.json();
    };
    var deleteHistory = async function (userid, timestamp) {
        var response = await fetch('api/Framework/history/' + userid + '/' + timestamp, {
            method: 'DELETE'
        });
        return await response.json();
    };

    return {
        addNoteToMarking,
        getNotesByMarkingId,
        getMarkingsByUserId,
        getPostsById,
        deleteHistory,
        getHistory,
        bestMatchSearch,
        qaGetUsers,
        getNextPage,
        addPostMarking
    }
});