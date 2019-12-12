﻿define(["knockout"], function (ko) {

   

    var currentComponent = ko.observable("history");
    var changeContent = () => {
        if (currentComponent() === "page1") {
            currentComponent("page2");
            currentComponent("navbarpage");
        } else {
            currentComponent("history");
            
        }
    };

    return {
        currentComponent,
        changeContent

    };
});