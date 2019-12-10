define(["knockout", "dataService"], function (ko, ds) {
    return function (params) {


        var markings = ko.observableArray();
        var notes = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();
        var isSelected = ko.observable();


        var getMarkings = function () {
            ds.getMarkingsByUserId(function (data) {
                console.log(data);
                markings(data.items);
                next(data.next);
                prev(data.prev);
            });
        }
        getMarkings();        

        var nextPage = function () {
            searchedPosts(next());
        }
        var prevPage = function () {
            searchedPosts(prev());
        }

        var getNotes = function (markingId) {
            ds.getNotesByMarkingId(markingId, function (data) {
                console.log(data);
                notes(data.items);
            });
        }
        
        var setIsSelected = function (data) {
            getNotes(data.id);
        };
   
        return {
            markings,
            nextPage,
            prevPage,
            notes,
            prev,
            next,
            isSelected,
            setIsSelected            
        };
    };
});