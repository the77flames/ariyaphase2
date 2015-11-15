define(['knockout', 'services/navigating'], function (ko, navigating) {
    var userRoles = ko.observableArray();

    var selectDepartment = function (data) {
        ko.utils.arrayForEach(vm.departments(), function (item) {
            item.isActive(false);
        });
        if (data.__moduleId__) {
            vm.isHomeActive(true);
        } else {
            vm.isHomeActive(false);
            data.isActive(true);
        }
    };

    var vm = {
        isHomeActive: ko.observable(true),
        selectDepartment: selectDepartment,
        categories: ko.observableArray([]),
        departments: ko.observableArray([]),
        userRoles: userRoles,
        serviceUrl: '../api/'
    };

    return vm;
});