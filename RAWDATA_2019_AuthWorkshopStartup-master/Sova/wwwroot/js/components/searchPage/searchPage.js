define(["knockout", "dataService"], function (ko, ds) {
    return function (params) {

        var search = ko.observable();

        var posts = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();

        var searchedPosts = function (url) {
            ds.getWithFetchAsync(url, function (data) {
                console.log(data);
                posts(data.items);
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

        searchedPosts('api/QA/posts');

        return {
            posts,
            nextPage,
            prevPage,
            prev
        };
    };
});