define(["knockout", "dataService"], function (ko, ds) {
    return function (params) {

        var markings = ko.observableArray();
        var notes = ko.observable();
        var next = ko.observable();
        var prev = ko.observable();
        var isSelected = ko.observable();


        var getMarkings = function (url) {
            ds.getWithFetchAsync(url, function (data) {
                console.log(data);
                markings(data.items);
                next(data.next);
                prev(data.prev);
            });
        }
        getMarkings('api/Framework/markings/usermarkings/1');

        var nextPage = function () {
            searchedPosts(next());
        }
        var prevPage = function () {
            searchedPosts(prev());
        }

        var getNotes = function (url) {
            ds.getWithFetchAsync(url, function (data) {
                console.log(data);
                notes(data.items);
            });
        }
        getNotes('api/Framework/notes');

        var setIsSelected = function () {
            isSelected(true);
        }

        return {
            markings,
            nextPage,
            prevPage,
            getNotes,
            notes,
            prev,
            isSelected,
            setIsSelected
        };
    };
});