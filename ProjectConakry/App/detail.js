define(['services/navigating', 'knockout', 'jquery', 'services/logger', 'api/categoryApi', 'kobindings/roundabout'],
    function (navigating, ko, $, logger, recommendationApi, roundabout) {
        var sections = ["Related Videos"];

        var makeSections = function (recommendations) {
            if (!recommendations) {
                recommendations = [];
            }
            var list = [];
            for (var j = 0; j < sections.length; j++) {
                list.push({ Name: sections[j], List: [] });
            }            
            for (var i = 0; (i < recommendations.length && i < 5); i++) {
                var o = recommendations[i];
                list[0].List.push(o);
            }
            return list;
        };

        var activate = function () {
            return recommendationApi.get(vm.recommendations)                
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