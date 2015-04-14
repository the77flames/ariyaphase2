define(['durandal/app', 'services/navigating', 'knockout', 'jquery', 'services/logger', 'api/categoryApi', 'api/newsApi', 'api/loungeApi', 'api/eventsApi', 'kobindings/roundabout'],
    function (app, navigating, ko, $, logger, categoryApi, newsApi, loungeApi, eventsApi, roundabout) {

        var sections = ["", "Top 10", "Featured", "New", "Trending"];

        var addThis = function () {
            var jsAddThis = document.createElement('script'),
            head = document.getElementsByTagName('head')[0];

            jsAddThis.async = true;
            jsAddThis.type = 'text/javascript';
            jsAddThis.src = 'http://s7.addthis.com/js/300/addthis_widget.js#pubid=ra-522955913726e62c';

            head.appendChild(jsAddThis);
        };

        var makeSections = function (categories) {
            var list = [];
            for (var j = 0; j < sections.length; j++) {
                list.push({ Name: sections[j], List: [] });
            }
            for (var i = 0; i < categories.length; i++) {
                var o = categories[i];
                list[o.SectionId].List.push(o);
            }
            return list.splice(1, list.length - 1);
        };

        var groupItems = function (items, count) {
            var list = [];
            for (var i = 0; i < items.length / count; i++) {
                list.push({List:[]});
                for (var j = 0; j < count; j++) {
                    var o = items[(i * count) + j];
                    list[i].List.push(o);
                }                
            }
            return list;
        };

        var sliders = [];
        var slider;

        var loadSliders = function () {
            setTimeout(function () {
                $('.home-listing').each(function (i, item) {
                    slider = $(item).bxSlider({
                        minSlides: 4,
                        maxSlides: 4,
                        controls: false,
                        moveSlides: 4,
                        slideWidth: 192,
                        slideMargin: 10
                    });
                    sliders.push(slider);
                });

                $('.sidebar-slider').each(function (i, item) {
                    slider = $(item).bxSlider();
                    sliders.push(slider);
                });
            }, 300);
        };

        var attached = function () {
            addThis();
            loadSliders();
        };

        var deactivate = function () {
            //$(sliders).each(function (i, item) {
            //    item.destroySlider();
            //});
        };

        var activate = function () {
            if ($('.home-listing').length > 0)
                return null;
            return categoryApi.get(vm.categories)
                .then(function () {
                    return newsApi.get(vm.news, new Date()).then(
                    function () {
                        var list = groupItems(vm.news(), 5);
                        vm.newsSections(list);
                    }).then(function () {
                        return eventsApi.get(vm.events, new Date()).then(
                        function () {
                            var list = groupItems(vm.events(), 4);
                            vm.eventsSections(list);
                        });
                    }).then(function () {
                        return loungeApi.get(vm.loungeItems, new Date()).then(
                        function () {
                            var list = groupItems(vm.loungeItems(), 4);
                            vm.loungeSections(list);
                        });
                    });
                })
                .done(function () {
                    vm.sections(makeSections(vm.categories()));
                    if ($('.home-listing').length > 0) {
                        loadSliders();
                    }
                    navigating.busy(false);
                });
        };

        var vm = {
            categories: ko.observableArray([]),
            news: ko.observableArray([]),
            events: ko.observableArray([]),
            loungeItems: ko.observableArray([]),
            activate: activate,
            deactivate: deactivate,
            attached: attached,
            sections: ko.observableArray([]),
            newsSections: ko.observableArray([]),
            eventsSections: ko.observableArray([]),
            loungeSections: ko.observableArray([])
        }

        return vm;
    });