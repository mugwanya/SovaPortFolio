define([], function() {
    return function(params) {
        var name = params ? params.name : "";
        return {
            name
        };
    };
});