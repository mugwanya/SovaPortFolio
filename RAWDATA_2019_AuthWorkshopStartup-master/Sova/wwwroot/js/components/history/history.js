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

        var runhistory = function () {
            ds.getHistory(function (data) {
                console.log(data);
                //var newItems = data.items.map(x => {
                //   userId:  x.userid,
                //   timestamped: x.timestamped,
                //    x.searchquery,
                //        selected: false
                //});
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

        var addToSelectedItems = function () {
            console.log('test');

            selectedItems().push($data);
            console.log($data);
        }

        var deleteSelected = function () {
            console.log('before loop');
            for (var i = 0; i < selectedItems().length; i++) {
               
                console.log('inside loop');
                console.log(selectedItems());
                console.log(selectedItems()[i]);
                ds.deleteHistory(
                    selectedItems()[i].userid,
                    selectedItems()[i].timestamped
                );
                //ds.deleteHistory(items[i].userid, items[i].timestamped);
                historyrecords.remove(selectedItems()[i]);
                selectedItems.remove(selectedItems()[i]);
                console.log(selectedItems());
            }
            console.log('after loop');
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
            next,
            addToSelectedItems
        };
    };
});