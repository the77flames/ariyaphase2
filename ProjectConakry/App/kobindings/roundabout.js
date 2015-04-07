define(['durandal/system', 'jquery', 'knockout', 'roundabout', 'bxslider'],
    function (system, $, ko) {

        var addThis = function () {
            var jsAddThis = document.createElement('script'),
            head = document.getElementsByTagName('head')[0];

            jsAddThis.async = true;
            jsAddThis.type = 'text/javascript';
            jsAddThis.src = 'http://s7.addthis.com/js/300/addthis_widget.js';

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