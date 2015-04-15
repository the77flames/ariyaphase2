define(['durandal/system', 'jquery', 'knockout', 'roundabout', 'bxslider'],
    function (system, $, ko) {
        var vm = {
            sliders: [],
            addThisInitialized: false
        };

        var addThis = function () {
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

        vm.loadSliders = function (element, target, options) {
            setTimeout(function () {
                $(element).find(target).each(function (i, item) {
                    var slider = $(item).bxSlider(options);
                    vm.sliders.push(slider);
                });
                addThis();
                addthis.toolbox('.addthis_toolbox');
            }, 500);
        };

        ko.bindingHandlers.bxSlider = {
            init: function (element, valueAccessor, allBindingsAccessor) {
                var options = ko.utils.unwrapObservable(valueAccessor)();
                var target = allBindingsAccessor().target;
                if (target) {
                    vm.loadSliders(element, target, options);
                }
            }
        };

        return vm;
    });