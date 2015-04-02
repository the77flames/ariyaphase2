define(['durandal/app', 'services/navigating', 'knockout', 'jquery', 'services/logger', 'services/global', 'api/productApi', 'api/departmentApi'],
    function (app, navigating, ko, $, logger, global, productApi, departmentApi) {
        var columnCount = 4;

        var make2Dimension = function (products) {
            var len = products.length;
            var list = [];
            var cols = [];
            for (var i = 0; i < len; i++) {
                if (i % columnCount == 0) {
                    cols = [];
                    list.push({ cols: cols });
                }
                cols.push(products[i]);
            }
            return list;
        };

        var loadProducts = function (id, cat) {
            var category = null;
            for (var i = 0; i < vm.departments().length; i++) {
                category = $.grep(vm.departments()[i].Categories, function (item) {
                    return item.ID == cat;
                })[0];
                if (category) {
                    vm.department(vm.departments()[i]);
                    vm.category(category);
                    break;
                }                
            }
            if (!category) {
                vm.department('');
                vm.category({ Name: 'On Catalog Promotion' });
                vm.selectDepartment(vm);
            } else {
                vm.selectDepartment(vm.department());
            }
            return productApi.get(vm.products, 0, cat).done(function () {
                var list = make2Dimension(vm.products());                
                vm.rows(list);                
                navigating.busy(false);
            });
        };

        var activate = function (cat) {
            cat = cat || 0;
            navigating.busy(true);
            if (vm.departments().length > 0) {
                return loadProducts(0, cat);
            }
            return departmentApi.get(vm.departments).done(function () {
                return loadProducts(0, cat);
            });
        }

        var productImageUrl = function (url) {
            if (url)
                return url;
            return '';
        };
 
        var vm = {
            rows: ko.observableArray(),
            productImageUrl: productImageUrl,
            products: global.products,
            categories: global.categories,
            departments: global.departments,
            selectDepartment: global.selectDepartment,
            category: ko.observable(),
            department: ko.observable(),
            activate: activate,
        }

        return vm;
    });