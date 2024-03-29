﻿define([], function () {

    const selectPerson = "SELECT_PERSON";
    const selectMenu = "SELECT_MENU";

    var subscribers = [];

    var currentState = {};

    var getState = () => currentState;

    var subscribe = function (callback) {
        subscribers.push(callback);

        return function () {
            subscribers = subscribers.filter(x => x !== callback);
        };
    };

    var reducer = function (state, action) {
        switch (action.type) {
            case selectPerson:
                return Object.assign({}, state, { selectedPerson: action.selectedPerson });
            case selectMenu:
                return Object.assign({}, state, { selectedMenu: action.selectedMenu });
            default:
                return state;
        }
    };

    var dispatch = function (action) {
        currentState = reducer(currentState, action);

        subscribers.forEach(callback => callback());
    };

    var actions = {
        selectPerson: function (person) {
            return {
                type: selectPerson,
                selectedPerson: person
            };
        },
        selectMenu: function (menu) {
            return {
                type: selectMenu,
                selectedMenu: menu
            };
        }
    };

    return {
        getState,
        subscribe,
        dispatch,
        actions
    };


});