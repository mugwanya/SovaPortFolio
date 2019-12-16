define(["knockout", "dataService", "store"], function (ko, ds) {

    return function (params) {

        var users = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();

        var runUsers = function() {
            ds.qaGetUsers(function (data) {
                console.log(data);
                users(data.items);
                next(data.next);
                console.log(data.next);

                //prev(data.prev);
                console.log(data.prev);
            });
        }
        runUsers();

        var nextPage = function () {
            ds.getNextPage(next());
        }
        var prevPage = function () {
            runUsers(prev());
        }

        
        return {
            name,
            users,
            nextPage,
            prevPage
        };
    };
});