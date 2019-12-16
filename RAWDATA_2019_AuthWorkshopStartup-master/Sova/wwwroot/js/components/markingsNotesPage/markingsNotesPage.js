define(["knockout", "dataService"], function (ko, ds) {
    return function (params) {

        var posts = ko.observableArray();
        var markings = ko.observableArray();
        var notes = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();
        var tmpList = [];
        var isChecked = ko.observableArray();
        var noteValue = ko.observable();
        var currentMarking = ko.observable();
        var noteEligible = ko.observable(false);

        getMarkings = function () {
            ds.getMarkingsByUserId(function (data) {
                markings(data.items);       
                next(data.next);
                prev(data.prev);
               
                for (var i = 0; i < markings().length; i++) {
                    ds.getPostsById(markings()[i].postCommentsId, function (data) {
                        posts(data);
                        for (var j = 0; j < markings().length; j++) {
                            if (data.id == markings()[j].postCommentsId) {
                                var newItems = {
                                    id: markings()[j].id,
                                    title: data.title,
                                    selected: false
                                }
                                tmpList.push(newItems);
                            }
                        }
                        posts(tmpList);
                    });
                }
                console.log(tmpList);
            });
        }
        getMarkings();        

        var nextPage = function () {
            searchedPosts(next());
        }
        var prevPage = function () {
            searchedPosts(prev());
        }

        
        var selectedMarking = function (makingData) {
            currentMarking(makingData);
            noteEligible(true);
            ds.getNotesByMarkingId(makingData.id, function (notesData) {
                console.log(notesData);
                notes(notesData.items);
            });
        };

        addNote = function () {
            console.log(noteValue());
            console.log(currentMarking().id);
            ds.addNoteToMarking(currentMarking().id, noteValue());
        }

        return {
            noteEligible,
            markings,
            nextPage,
            prevPage,
            notes,
            prev,
            next,
            selectedMarking,
            posts,
            isChecked,
            noteValue
        };
    };
});