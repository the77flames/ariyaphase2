define(['jquery', 'knockout', 'roundabout', 'bxslider', 'mediaplayer'],
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
                if (target)
                    $(element).find(target).bxSlider(options);
                else {
                    $(element).bxSlider(options);
                }
            }, 500);
        };

        ko.bindingHandlers.bxSlider = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
                var options = ko.utils.unwrapObservable(valueAccessor)();
                var target = allBindingsAccessor().target;
                vm.loadSliders(element, target, options);               
            }
        };

        var initPlayer = function () {
            if ($('audio, video').length > 0) {
                $('audio,video').mediaelementplayer({
                    success: function (player, node) {
                        $('#' + node.id + '-mode').html('mode: ' + player.pluginType);
                    }
                });
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
                initPlayer();
            });
            return model;
        }
        
        return vm;
    });