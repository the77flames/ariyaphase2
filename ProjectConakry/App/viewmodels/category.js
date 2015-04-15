define(['services/navigating', 'knockout', 'jquery', 'services/logger', 'api/categoryApi', 'api/newsApi', 'api/loungeApi', 'api/eventsApi', 'kobindings/roundabout'],
    function (navigating, ko, $, logger, categoryApi, newsApi, loungeApi, eventsApi, roundabout) {

        var sections = ["", "Top 10", "Featured", "New", "Trending"];

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

        var activate = function () {
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
                    roundabout.addThis();
                    // addthis.toolbox('.addthis_toolbox');
                    // navigating.busy(false);
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
            loungeSections: ko.observableArray([])
        }

        return vm;
    });