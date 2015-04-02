define(['durandal/app', 'services/navigating', 'knockout', 'jquery', 'services/logger', 'api/categoryApi', 'kobindings/roundabout'],
    function (app, navigating, ko, $, logger, categoryApi, departmentApi) {

        var activate = function () {
            return categoryApi.get(vm.categories).done(function () {
                navigating.busy(false);
            });
        }

        var vm = {
            categories: ko.observableArray([]),
            activate: activate
        }

        return vm;
    });