define(["knockout", "dataService"], function (ko, ds) {

    return function (params) {
        
        var historyrecords = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();
        var selectAllPressed = ko.observable(true);
        var selectedItems = ko.observableArray();
        var items = selectedItems();
        
        selecetAllHasBeenPressed = function () {
            if (selectAllPressed() === false) {
                UnSelectAll();
                selectAllPressed(true);
            } else {
                selectAll();
                selectAllPressed(false)
            }
        }

        var runhistory = function (url) {
            var callback = function (data) {
                console.log(data);
                historyrecords(data.items);
                next(data.next);
                prev(data.previous);
            };
            if (url === undefined)
                ds.getHistory(callback);
            else
                ds.getHistory(url, callback);
        }
        runhistory();

        var nextPage = function () {
            runhistory(next());
        }
        var prevPage = function () {
            runhistory(prev());
        }

        var deleteSelected = function () {
            console.log('inside delete Function');
            ds.deleteHistory(
                selectedItems().userid,
                selectedItems().timestamped
            );
            historyrecords.remove(selectedItems());
            selectedItems.remove(selectedItems());
        }

        return {
            historyrecords,
            nextPage,
            prevPage,
            items,
            selectedItems,
            deleteSelected,
            selecetAllHasBeenPressed,
            selectAllPressed,
            prev,
            next
        };
    };
});