
require.config({
    baseUrl: "js",
    paths: {
        jquery: "../lib/jquery/dist/jquery",
        knockout: "../lib/knockout/build/output/knockout-latest.debug",
        text: "../lib/requirejs-text/text",
        dataService: "services/dataService"
     

    }
});

require(['knockout'], function(ko) {
    ko.components.register('mycomp',
        {
            viewModel: { require: "viewModel"},
            template: { require: "text!../mycomp.html"}
        });
    ko.components.register('page1',
        {
            viewModel: { require: "components/page1/page1" },
            template: { require: "text!components/page1/page1.html" }
        });
    ko.components.register('page2',
        {
            viewModel: { require: "components/page2/page2" },
            template: { require: "text!components/page2/page2.html" }
        });
    ko.components.register('pageTest',
        {
            viewModel: { require: "components/pageTest/pageTest" },
            template: { require: "text!components/pageTest/pageTest.html" }
        });

    ko.components.register('history',
        {
            viewModel: { require: "components/history/history" },
            template: { require: "text!components/history/history.html" }
        });
    ko.components.register('searchPage',
        {
            viewModel: { require: "components/searchPage/searchPage" },
            template: { require: "text!components/searchPage/searchPage.html" }
        });
    ko.components.register('markingsNotesPage',
        {
            viewModel: { require: "components/markingsNotesPage/markingsNotesPage" },
            template: { require: "text!components/markingsNotesPage/markingsNotesPage.html" }
        });
    ko.components.register('loginPage',
        {
            viewModel: { require: "components/loginPage/loginPage" },
            template: { require: "text!components/loginPage/loginPage.html" }
        });


});



require(["knockout", "app"], function(ko, app, ds) {
   
    ko.applyBindings(app);
});