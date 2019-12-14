define(["knockout", "store"], function (ko, store) {

   

    //var currentComponent = ko.observable("history");
    //var changeContent = () => {
    //    if (currentComponent() === "page1") {
    //        currentComponent("page2");
    //        currentComponent("navbarpage");
    //    } else {
    //        currentComponent("history");
            
    //    }
    //};

    var menuElements = [
        {
            name: "Component 1",
            component: "markingsNotesPage"
        },
        {
            name: "Component 2",
            component: "loginPage"
        },
        {
            name: "Component 3",
            component: "history"
        }
    ];

    var currentMenu = ko.observable(menuElements[0]);
    var currentComponent = ko.observable(currentMenu().component);

    var changeContent = function (menu) {
        store.dispatch(store.actions.selectMenu(menu.name));
    };

    store.subscribe(() => {
        var menuName = store.getState().selectedMenu;
        var menu = menuElements.find(x => x.name === menuName);
        if (menu) {
            currentMenu(menu);
            currentComponent(menu.component);
        }
    });

    var isSelected = function (menu) {
        return menu === currentMenu() ? "active" : "";
    };

    return {
        //currentComponent,
        //changeContent
        currentComponent,
        menuElements,
        changeContent,
        isSelected
    };
});