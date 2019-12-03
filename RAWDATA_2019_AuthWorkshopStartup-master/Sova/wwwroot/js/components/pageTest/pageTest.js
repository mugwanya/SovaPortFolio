define(["knockout", "dataService"], function (ko, ds) {

    return function (params) {
        console.log("123");
        var name = params ? params.name : "";

        var users = ko.observableArray();

        var runUsers = function(url) {
            console.log("inside");
            ds.getUsersWithJQuery(url, function (data) {
                console.log(data);
                users(data.items);
            });

        }
        runUsers('api/Framework/users');

        return {
            name,
            users
        };
    };
});