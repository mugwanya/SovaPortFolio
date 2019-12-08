define(["knockout", "dataService"], function (ko, ds) {
    

    var currentComponent = ko.observable("history");
    var changeContent = () => {
        if (currentComponent() === "page1") {
            currentComponent("page2");
          
        } else {
            currentComponent("pageTest");

        }
    };

    return {
        currentComponent,
        changeContent

    };
});