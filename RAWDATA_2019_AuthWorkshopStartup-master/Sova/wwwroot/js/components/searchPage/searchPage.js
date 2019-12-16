define(["knockout", "dataService"], function (ko, ds) {
    return function (params) {

        var search = ko.observable();
        var posts = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();
        var body = ko.observableArray();
        var currentPost = ko.observable();

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

        var selectedPost = function (postData) {
            currentPost(postData);
            ds.getPostsById(postData.id, function (data) {
                console.log(data);
                body(data);
            });
        }

        tst = function () {
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
            tst
            
        };
    };
});