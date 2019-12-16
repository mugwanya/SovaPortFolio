define(["knockout", "dataService"], function (ko, ds) {
    return function (params) {

        var search = ko.observable();
        var posts = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();
        var body = ko.observableArray();
        var currentPost = ko.observable();
        var markings = ko.observableArray();
        var excistInMarking = ko.observable(false);

        searchedPosts = function () {
            ds.bestMatchSearch(search(), function (data) {
                console.log(data);
                posts(data);
                next(data.next);
                prev(data.prev);
            });
        }

        var nextPage = function () {
            searchedPosts(next());
        };
        var prevPage = function() {
             searchedPosts(prev());
        };

        getMarkings = function () {
            ds.getMarkingsByUserId(function (data) {
                markings(data.items);
                next(data.next);
                prev(data.prev);
            });
        }

        var selectedPost = function (postData) {
            currentPost(postData);
            //getMarkings();

            //for (var i = 0; i < markings().length; i++) {
            //    if (currentPost(postData).id === markings()[i].postCommentsId) {
            //        excistInMarking(false);
            //    } else {
            //        excistInMarking(true);
            //    }
            //}
            //console.log("excistInMarking");
            //console.log(excistInMarking());
            ds.getPostsById(postData.id, function (data) {
                console.log(data);
                body(data);
            });
        }

        addMark = function () {
            console.log(currentPost());
            ds.addPostMarking(1, currentPost().id);
        }



        return {
            posts,
            nextPage,
            prevPage,
            prev,
            next,
            searchedPosts,
            search,
            body,
            selectedPost,
            addMark
            
        };
    };
});