define(['jquery', 'knockout', 'roundabout', 'bxslider'],
    function ($, ko) {
        var vm = {
            sliders: [],
            addThisInitialized: false
        };

        vm.addThis = function () {
            if (vm.addThisInitialized)
                return;
            vm.addThisInitialized = true;

            var jsAddThis = document.createElement('script'),
            head = document.getElementsByTagName('head')[0];

            jsAddThis.async = true;
            jsAddThis.type = 'text/javascript';
            jsAddThis.src = 'http://s7.addthis.com/js/300/addthis_widget.js#pubid=ra-522955913726e62c';

            head.appendChild(jsAddThis);
        };

        ko.bindingHandlers.roundabout = {
            init: function (element) {
                $(element).roundabout({
                    minScale: 0.1,
                    childSelector: "li",
                    autoplay: true,
                    autoplayDuration: 2400,
                    autoplayPauseOnHover: true
                });
            }
        };

        ko.bindingHandlers.image = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
                var img = ko.utils.unwrapObservable(valueAccessor());
                element.src = 'images/' + img;
            }
        };

        ko.bindingHandlers.details = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var data = bindingContext.$data;
                element.href = 'details?entityType=' + data.Genre + '&id=' + data.Id;
            }
        };

        vm.loadSliders = function (element, target, options) {
            setTimeout(function () {
                $(element).find(target).bxSlider(options);
            }, 50);
        };

        ko.bindingHandlers.bxSlider = {
            init: function (element, valueAccessor, allBindingsAccessor) {
                var options = ko.utils.unwrapObservable(valueAccessor)();
                var target = allBindingsAccessor().target;
                ko.computed(function () {
                    var count = vm.sectionCount();
                    if (count == 4) {
                        vm.loadSliders(element, target, options);
                    }
                }, vm);                
            }
        };

        vm.sectionCount = ko.observable(0);

        vm.bind = function (viewModel) {
            var Model = function () {
                return viewModel;
            };
            var model = new Model();
            $(document).ready(function () {
                ko.applyBindings(model);
                viewModel.activate();
            });
            return model;
        }
        
        return vm;
    });