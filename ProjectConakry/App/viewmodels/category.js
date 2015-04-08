define(['durandal/app', 'services/navigating', 'knockout', 'jquery', 'services/logger', 'api/categoryApi', 'api/newsApi', 'kobindings/roundabout'],
    function (app, navigating, ko, $, logger, categoryApi, newsApi) {

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

        var activate = function () {
            return categoryApi.get(vm.categories)
                .then(function() {
                    return newsApi.get(vm.news, new Date()).then(
                    function () {
                        var list = groupItems(vm.news(), 5);
                        vm.newsSections(list);
                    });
                })
                .done(function () {
                vm.sections(makeSections(vm.categories()));
                setTimeout(function () {
                    addThis();
                }, 300);
                navigating.busy(false);
            });
        }

        var vm = {
            categories: ko.observableArray([]),
            news: ko.observableArray([]),
            activate: activate,
            sections: ko.observableArray([]),
            newsSections: ko.observableArray([])
        }

        return vm;
    });