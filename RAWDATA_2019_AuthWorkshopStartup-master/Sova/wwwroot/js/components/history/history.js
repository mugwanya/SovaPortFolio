define(["knockout", "dataService"], function (ko, ds) {

    return function (params) {
        
        var historyrecords = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();

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

        
        var selectedItems = ko.observableArray();
        var items = selectedItems();
        console.log(items.length);

        var deleteSelected = function () {
            //items.removeAll(selectedItems());
            //selectedItems.removeAll();

            //ds.deleteHistory(items()[0].userid, items()[0].timestamped);

            console.log('before loop');
            for (var i = 0; i < items.length; i++) {
               
                console.log('inside loop');

                ds.deleteHistory(items[i].userid, items[i].timestamped);
                historyrecords.remove(items[i]);
            }
            console.log('after loop');

            //historyrecords(items);
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