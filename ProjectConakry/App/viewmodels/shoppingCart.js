define(['durandal/app', 'services/navigating', 'knockout', 'jquery', 'services/logger', 'api/productApi', 'api/departmentApi'],
    function (app, navigating, ko, $, logger, productApi, departmentApi) {

        var activate = function () {
            return departmentApi.get(vm.departments).done(function () {
                productApi.get(vm.products).done(function () {
                    navigating.busy(false);
                });
            });
        }

        var vm = {
            products: ko.observableArray([]),
            departments: ko.observableArray([]),
            activate: activate
        }

        return vm;
    });