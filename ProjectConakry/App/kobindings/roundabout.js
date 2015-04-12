define(['durandal/system', 'jquery', 'knockout', 'roundabout', 'bxslider'],
    function (system, $, ko) {

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

        ko.bindingHandlers.bxSlider = {
            init: function (element, valueAccessor, allBindingsAccessor) {
                var options = ko.utils.unwrapObservable(valueAccessor)();
                var target = allBindingsAccessor().target;
                if (target) {
                    setTimeout(function () {
                        $(element).find(target).bxSlider(options);                        
                    }, 300);                    
                }
            }
        };
    });