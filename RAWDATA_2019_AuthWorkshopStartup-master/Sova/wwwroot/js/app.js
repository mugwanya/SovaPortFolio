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

    return {
        currentComponent,
        currentParams,
        changeContent

    };
});