define(['services/navigating', 'knockout', 'jquery', 'services/logger', 'api/categoryApi', 'api/newsApi', 'api/loungeApi', 'api/eventsApi', 'kobindings/roundabout'],
    function (navigating, ko, $, logger, categoryApi, newsApi, loungeApi, eventsApi, roundabout) {

        var sections = ["", "Top10", "Featured", "New", "Trending"];

        var makeSections = function (categories) {
            var list = [];
            for (var j = 0; j < sections.length; j++) {
                list.push({ Name: sections[j], List: [] });
            }
            for (var i = 0; i < categories.length; i++) {
                var o = categories[i];
                if (list[o.SectionId]) {
                    list[o.SectionId].List.push(o);
                }
            }
            return list.splice(1, list.length - 1);
        };

        var groupItems = function (items, groupSize) {
            var list = [];
            if (items == null)
                return list;
            var count = items.length > groupSize ? groupSize : items.length;
            for (var i = 0; i < items.length / count; i++) {
                list.push({ List: [] });
                for (var j = 0; j < count; j++) {
                    var o = items[(i * count) + j];
                    list[i].List.push(o);
                }
            }
            roundabout.sectionCount(roundabout.sectionCount() + 1);
            return list;
        };

        var activate = function () {
            return categoryApi.get(vm.categories)
               .done(function () {
                   return newsApi.get(vm.news, new Date()).then(
                   function () {
                       var groupSize = vm.news().length > 5 ? 5 : vm.news().length;
                       var list = groupItems(vm.news(), groupSize);
                       vm.newsSections(list);
                   }).then(function () {
                       return eventsApi.get(vm.events, new Date()).then(
                       function () {
                           var groupSize = vm.events().length > 4 ? 4 : vm.events().length;
                           var list = groupItems(vm.events(), groupSize);
                           vm.eventsSections(list);
                       });
                   }).then(function () {
                       return loungeApi.get(vm.loungeItems, new Date()).then(
                       function () {
                           var groupSize = vm.loungeItems().length > 4 ? 4 : vm.loungeItems().length;
                           var list = groupItems(vm.loungeItems(), groupSize);
                           vm.loungeSections(list);
                       });
                   });
               })
                .done(function () {
                    vm.sections(makeSections(vm.categories()));
                    roundabout.addThis();
                });
        };

        var vm = {
            name: "Category",
            categories: ko.observableArray([]),
            news: ko.observableArray([]),
            events: ko.observableArray([]),
            loungeItems: ko.observableArray([]),
            activate: activate,
            sections: ko.observableArray([]),
            newsSections: ko.observableArray([]),
            eventsSections: ko.observableArray([]),
            loungeSections: ko.observableArray([]),
        }

        vm.onLoad = ko.computed(function () {
            var list = vm.sections();
            if (roundabout.isReady() && list && list.length == 4) {
                setTimeout(function () {
                    $('.home-listing').bxSlider({
                        minSlides: 4,
                        maxSlides: 4,
                        controls: false,
                        moveSlides: 4,
                        slideWidth: 195,
                        slideMargin: 10
                    });
                    roundabout.sectionCount(roundabout.sectionCount() + 1);
                }, 100);
            }
        }, vm);
        roundabout.bind(vm);

        return vm;
    });