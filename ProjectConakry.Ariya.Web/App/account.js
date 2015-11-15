define(['services/navigating', 'knockout', 'jquery', 'api/recommendationApi', 'kobindings/roundabout'],
    function (navigating, ko, $, recommendationApi, roundabout) {
        var sections = ["", "Recommended Videos"];

        var makeSections = function (recommendations) {
            if (!recommendations) {
                recommendations = [];
            }
            var list = [{ List: []}];
            
            for (var j = 0; j < sections.length; j++) {
                list.push({ Name: sections[j], List: [] });
            }
            recommendations = $(recommendations).filter(function (index, item) {
                return item;
            });
            for (var i = 0; i < recommendations.length; i++) {
                var o = recommendations[i];
                list[0].List.push(o);
            }
            return list[0];
        };

        var activate = function () {
            return recommendationApi.get(vm.recommendations, window.PageNumber)
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