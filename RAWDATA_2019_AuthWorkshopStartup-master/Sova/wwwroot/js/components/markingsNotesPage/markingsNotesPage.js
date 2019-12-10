define(["knockout", "dataService"], function (ko, ds) {
    return function (params) {

        var post = ko.observableArray();

        var markings = ko.observableArray();
        var notes = ko.observable();
        var next = ko.observable();
        var prev = ko.observable();
        var isSelected = ko.observable();
        var tst = '19';


        var getMarkings = function (url) {
            ds.getWithFetchAsync(url, function (data) {
                console.log(data);
                markings(data.items);
                next(data.next);
                prev(data.prev);
            });
        }
        getMarkings('api/Framework/markings/usermarkings/1');

        

        var nextPage = function () {
            searchedPosts(next());
        }
        var prevPage = function () {
            searchedPosts(prev());
        }

        //var getNotes = function (url) {
        //    ds.getWithFetchAsync(url, function (data) {
        //        console.log(data);
        //        notes(data.items);
        //    });
        //}
        //getNotes('api/Framework/notes');


        var getNotesTst = function (markingId) {
            ds.getWithFetchAsync('api/Framework/notes/' + markingId, function (data) {
                console.log(data);
                notes(data.items);
            });
        }

        var setIsSelected = function () {
            getNotesTst(isSelected(postCommentId));
            //getNotesTst(ko.dataFor(isSelected));
            isSelected(true);
        };

        var getPosts = function (url) {
            ds.getWithFetchAsync(url, function (data) {
                console.log(data);
                post(data);
            });
        }
        getPosts('api/qa/posts/' + tst);

        return {
            markings,
            nextPage,
            prevPage,
            //getNotes,
            notes,
            prev,
            next,
            isSelected,
            setIsSelected,
            post
            
        };
    };
});