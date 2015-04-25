define(['services/navigating', 'knockout', 'jquery', 'api/recommendationApi', 'kobindings/roundabout'],
    function (navigating, ko, $, recommendationApi, roundabout) {
        var sections = ["", "Related Videos"];

        var makeSections = function (recommendations) {
            if (!recommendations) {
                recommendations = [];
            }
            var list = [];
            for (var j = 0; j < sections.length; j++) {
                list.push({ Name: sections[j], List: [] });
            }
            recommendations = $(recommendations).filter(function (index, item) {
                return item.SectionId == 1;
            });
            for (var i = 0; i < recommendations.length; i++) {
                var o = recommendations[i];
                list[o.SectionId].List.push(o);
            }
            return list;
        };

        var activate = function () {
            return recommendationApi.get(vm.recommendations, window.CurrentUserId)
                 .done(function () {
                     vm.sections(makeSections(vm.recommendations()));
                     roundabout.addThis();
                 });
        }

        var vm = {
            recommendations: ko.observableArray([]),
            activate: activate,
            sections: ko.observableArray([])
        }

        roundabout.bind(vm);

        return vm;
    });