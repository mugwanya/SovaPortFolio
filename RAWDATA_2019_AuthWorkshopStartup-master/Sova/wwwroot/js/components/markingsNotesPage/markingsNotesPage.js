define(["knockout", "dataService"], function (ko, ds) {
    return function (params) {

        var posts = ko.observableArray();
        var markings = ko.observableArray();
        var notes = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();
        var tmpList = [];

        var getMarkings = function () {
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
                                    title: data.title
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

        //var getNotes = function (markingId) {
        //    ds.getNotesByMarkingId(markingId, function (data) {
        //        console.log(data);
        //        notes(data.items);
        //    });
        //}
        
        //var selectedMarking = function (data) {
        //    getNotes(data.id);
        //};

        var getPosts = function (postId) {
            ds.getPostsById(postId, function (data) {
                posts(data);
                console.log('console.log(posts());');
                console.log(posts());


                tst.push(data);
                
            });
        }

        //for (var i = 0; i < markings().length; i++) {
        //    console.log('inside forloop');
        //    getPosts(markings()[i].postCommentsId);
        //}
        
        var selectedMarking = function (makingData) {
            ds.getNotesByMarkingId(makingData.id, function (notesData) {
                console.log(notesData);
                notes(notesData.items);
            })
        };

        return {
            markings,
            nextPage,
            prevPage,
            notes,
            prev,
            next,
            selectedMarking,
            posts
        };
    };
});