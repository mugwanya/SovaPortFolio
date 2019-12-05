define(["knockout", "dataService"], function (ko, ds) {
    

    var currentComponent = ko.observable("markingsNotesPage");
    var changeContent = () => {
        if (currentComponent() === "page1") {
            currentComponent("page2");
            currentComponent("navbarpage");
        } else {
            currentComponent("pageTest");

        }
    };

    return {
        currentComponent,
        changeContent

    };
});