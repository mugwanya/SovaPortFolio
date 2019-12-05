define(["knockout", "dataService"], function (ko, ds) {
    return function (params) {

        var markings = ko.observableArray();
        var notes = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();

        var getMarkings = function (url) {
            ds.getWithFetchAsync(url, function (data) {
                console.log(data);
                markings(data.items);
                next(data.next);
                prev(data.prev);
            });
        }

        var nextPage = function () {
            searchedPosts(next());
        }
        var prevPage = function () {
            searchedPosts(prev());
        }

        getMarkings('api/Framework/markings/usermarkings/1');

        return {
            markings,
            nextPage,
            prevPage
        };
    };
});