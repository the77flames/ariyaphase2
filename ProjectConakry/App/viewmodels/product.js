define(['durandal/app', 'services/navigating', 'knockout', 'jquery', 'services/logger', 'services/global', 'api/productApi', 'api/categoryApi', 'api/departmentApi', 'api/shoppingCartApi'],
    function (app, navigating, ko, $, logger, global, productApi, categoryApi, departmentApi, shoppingCartApi) {

        var findCategory = function (catId) {
            var category;
            for (var i = 0; i < vm.departments().length; i++) {
                category = $.grep(vm.departments()[i].Categories, function (item) {
                    return item.ID == catId;
                })[0];
                if (category) {
                    vm.categories(vm.departments()[i].Categories);
                    break;
                }
            }
        };

        var loadProduct = function (id, catId) {
            var category = findCategory(catId);
            return productApi.getById(id, catId).done(function (data) {
                if (data.length > 0) {
                    var product = data[0];
                    product.category = category;
                    vm.product(product);
                }
                else
                    vm.message("No record was found.");
                navigating.busy(false);
            });
        };

        var activate = function (id, catId) {
            id = id || 1;
            navigating.busy(true);
            if (vm.departments().length > 0) {
                return loadProduct(id, catId);
            }
            return departmentApi.get(vm.departments).done(function () {
                return loadProduct(id, catId);
            });
        }

        var addToCart = function (d, e) {
            var p = { ProductID: d.ID, Size: 'Extra Small', Color: 'Red', Quantity: 1 }
            shoppingCartApi.update(p).done(function (data) {
                if (data.CssClass == "success")
                    alert("OK");
                else
                    alert(data.Text);
            });
        }

        var addToWishList = function (d, e) {
            var p = { ProductID: d.ID, Size: 'Extra Small', Color: 'Red', ApplyTo: 2 }
            shoppingCartApi.update(p).done(function (data) {
                if (data.CssClass == "success")
                    alert("OK");
                else
                    alert(data.Text);
            });
        }

        var productImageUrl = function (url) {
            if (url)
                return url; // 'images/products/' + url;
            return '';
        };

        var vm = {
            message: ko.observable(),
            product: ko.observable(),
            products: global.products,
            categories: global.categories,
            departments: global.departments,
            category: ko.observable(),
            activate: activate,
            productImageUrl: productImageUrl,
            addToCart: addToCart,
            addToWishList: addToWishList
        }

        return vm;
    });