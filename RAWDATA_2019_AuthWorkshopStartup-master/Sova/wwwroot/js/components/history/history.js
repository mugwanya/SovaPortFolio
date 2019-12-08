define(["knockout", "dataService"], function (ko, ds) {

    return function (params) {

        var historyrecords = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();

        var runhistory = function (url) {
            ds.getWithFetchAsync(url, function (data) {
                console.log(data);
                historyrecords(data.items);
                next(data.next);
                prev(data.prev);
            });

        }

        var nextPage = function () {
            runhistory(next());
        }
        var prevPage = function () {
            runhistory(prev());
        }

        runhistory('api/Framework/history/1')

        return {     
            historyrecords,
            nextPage,
            prevPage
        };
    };
});