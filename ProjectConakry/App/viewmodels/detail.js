define(['durandal/app', 'services/navigating', 'knockout', 'jquery', 'services/logger'],
    function (app, navigating, ko, $, logger) {

        var activate = function () {
            //return departmentApi.get(vm.departments).done(function () {
            //    productApi.get(vm.products).done(function () {
            //        navigating.busy(false);
            //    });
            //});
        }

        var vm = {
            //products: ko.observableArray([]),
            //departments: ko.observableArray([]),
            activate: activate
        }

        return vm;
    });