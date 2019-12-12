define(["knockout", "dataService"], function (ko, ds) {

    return function (params) {
        
        var historyrecords = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();

        var runhistory = function () {
            ds.getHistory(function (data) {
                console.log(data);
                historyrecords(data.items);
                next(data.next);
                prev(data.prev);
            });
        }
        runhistory();

        var nextPage = function () {
            runhistory(next());
        }
        var prevPage = function () {
            runhistory(prev());
        }

        var items = historyrecords;
        var selectedItems = ko.observableArray();

        var deleteSelected = function () {
            items.removeAll(selectedItems());
            selectedItems.removeAll();
        }

        return {
            
            historyrecords,
            nextPage,
            prevPage,
            items,
            selectedItems,
            deleteSelected
            
        };
    };
});