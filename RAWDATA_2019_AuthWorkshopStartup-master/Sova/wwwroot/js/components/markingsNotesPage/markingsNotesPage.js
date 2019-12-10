define(["knockout", "dataService"], function (ko, ds) {
    return function (params) {

        var posts = ko.observableArray();
        var markings = ko.observableArray();
        var notes = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();

        var getMarkings = function () {
            ds.getMarkingsByUserId(function (data) {
                console.log(data);
                markings(data.items);
                next(data.next);
                prev(data.prev);
            });
        }
        getMarkings();        

        var nextPage = function () {
            searchedPosts(next());
        }
        var prevPage = function () {
            searchedPosts(prev());
        }

        //var getNotes = function (markingId) {
        //    ds.getNotesByMarkingId(markingId, function (data) {
        //        console.log(data);
        //        notes(data.items);
        //    });
        //}
        
        //var selectedMarking = function (data) {
        //    getNotes(data.id);
        //};

        var getPosts = function (postId) {
            ds.getPostsById(postId, function (data) {
                console.log(data);
                posts(data.items);
            });
        }
        getPosts(19);

        //for (var i = 0; i < markings().length; i++) {
        //    getPosts(markings()[i].postCommentsId);
        //}


        var selectedMarking = function (makingData) {
            ds.getNotesByMarkingId(makingData.id, function (notesData) {
                console.log(notesData);
                notes(notesData.items);
            })
        };

        return {
            markings,
            nextPage,
            prevPage,
            notes,
            prev,
            next,
            selectedMarking,
            posts
        };
    };
});