define(["knockout", "dataService"], function (ko, ds) {

    return function (params) {
        var users = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();

        var runUsers = function(url) {
            ds.getUsersWithJQuery(url, function (data) {
                console.log(data);
                users(data.items);
                next(data.next);
                prev(data.prev);
            });

        }

        runUsers('api/Framework/users')

        return {
            name,
            users,
            next,
            prev,
            runUsers
         
        };
    };
});