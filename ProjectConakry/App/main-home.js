requirejs.config({
    paths: {
        'text': '../Scripts/text',
        'durandal': '../Scripts/durandal',
        'plugins': '../Scripts/durandal/plugins',
        'transitions': '../Scripts/durandal/transitions',
        'knockout': '../Scripts/knockout-3.1.0.debug',
        'bootstrap': '../Scripts/bootstrap',
        'jquery': '../Scripts/jquery-1.8.2',
        'toastr': '../Scripts/toastr',
        'moment': '../Scripts/moment',
        'roundabout': '../js/jquery.roundabout.min',
        'bxslider': '../js/jquery.bxslider.min'
    },
    shim: {
        'bootstrap': {
            deps: ['jquery'],
            exports: 'jQuery'
        },
        'roundabout': {
            deps: ['jquery']
        },
        'bxslider': {
            deps: ['jquery']
        }
    }
});

define(['jquery', 'knockout', 'viewmodels/category', 'bootstrap'], function ($, ko, category) {
    var Model = function () {
        var model = this;

        $.extend(model, category);
    };

    $(document).ready(function () {
        var vm = new Model();
        ko.applyBindings(vm);
        vm.activate();
    });
});