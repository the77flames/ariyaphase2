define(['services/navigating', 'knockout', 'jquery', 'services/logger', 'api/categoryApi', 'kobindings/roundabout'],
    function (navigating, ko, $, logger, recommendationApi, roundabout) {
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

        var attached = function () {
            setTimeout(function () {
                // addthis.toolbox('.addthis_toolbox');
            }, 300);
        };

        var activate = function () {
            if ($("detail-page .home-listing").length > 0) {
                addthis.toolbox('.addthis_toolbox');
                return null;
            }
            return recommendationApi.get(vm.recommendations)                
                 .done(function () {
                     vm.sections(makeSections(vm.recommendations()));
                     //if ($('#detail-content .home-listing').length > 0) {
                     //    loadSliders();
                     //}
                     navigating.busy(false);
                 });
        }

        var vm = {
            recommendations: ko.observableArray([]),
            activate: activate,
            attached: attached,
            sections: ko.observableArray([])
        }

        return vm;
    });