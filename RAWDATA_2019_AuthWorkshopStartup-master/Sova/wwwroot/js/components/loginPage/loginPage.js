define(["knockout"], function (ko) {
    return function (params) {

        var userName = ko.observable('');
        var userPassword = ko.observable('');
        var logged = ko.observable(false);



        var logging = function (data) {
            logged(true);
        }

        return {
            userName,
            userPassword,
            logged,
            logging

        };
    };
});