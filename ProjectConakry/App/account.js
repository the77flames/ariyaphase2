define(['services/navigating', 'knockout', 'jquery', 'api/categoryApi', 'kobindings/roundabout'],
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
            return list.splice(1, list.length - 1);
        };

        var activate = function () {
            if ($(".home-listing").length > 0) {
                addthis.toolbox('.addthis_toolbox');
                return null;
            }
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