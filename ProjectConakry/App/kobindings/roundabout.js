define(['durandal/system', 'jquery', 'knockout', 'roundabout', 'bxslider'],
    function (system, $, ko) {
        var vm = {
            sliders : []
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

        //vm.loadSliders = function (target, options) {
        //    setTimeout(function () {
        //        $(target).bxSlider(options);
        //    }, 300);
        //};

        //ko.bindingHandlers.bxSlider = {
        //    init: function (element, valueAccessor, allBindingsAccessor) {
        //        var options = ko.utils.unwrapObservable(valueAccessor)();
        //        var target = allBindingsAccessor().target;
        //        if (target) {
        //            setTimeout(function () {
        //                vm.loadSliders(target, options);
        //                vm.sliders.push({ target: target, options: options });                        
        //            }, 100);                    
        //        }
        //    }
        //};

        return vm;
    });