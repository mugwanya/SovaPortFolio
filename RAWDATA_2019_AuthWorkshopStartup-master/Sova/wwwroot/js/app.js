define(["knockout", "dataService"], function (ko, ds) {
    

    var currentComponent = ko.observable("pageTest");
    var currentParams = ko.observable({});
    var changeContent = () => {
        if (currentComponent() === "page1") {
            currentParams({ name: 'Ellen' });
            currentComponent("page2");
        } else {
            currentParams({});
            currentComponent("pageTest");
        }
    };

    var users = ko.observableArray([]);
    var pageOfPosts = {};

    ds.getUsersWithJQuery('api/Framework/users', function (data) {
        console.log(data)
        users(data.items);
        pageOfPosts = data;
        console.log(data);
    });

    var prev = function () {
        ds.getUsersWithJQuery(pageOfPosts.prev, function (data) {
            users(data.items);
            pageOfPosts = data;
            console.log(data);
        });
    };

    var next = function () {
        ds.getUsersWithJQuery(pageOfPosts.next, function (data) {
            users(data.items);
            pageOfPosts = data;
            console.log(data);
        });
    };

    return {
        currentComponent,
        currentParams,
        changeContent,
        users,
        prev,
        next

    };
});