define(['services/navigating', 'knockout', 'jquery', 'services/logger', 'api/recommendationApi', 'kobindings/roundabout'],
    function (app, navigating, ko, $, logger, recommendationApi, roundabout) {
        var sections = ["", "Related Videos"];

        var makeSections = function (recommendations) {
            if (!recommendations) {
                recommendations = [];
            }
            var list = [];
            for (var j = 0; j < sections.length; j++) {
                list.push({ Name: sections[j], List: [] });
            }
            for (var i = 0; i < recommendations.length; i++) {
                var o = recommendations[i];
                list[o.SectionId].List.push(o);
            }
            return list.splice(1, list.length - 1);
        };

        //var loadSliders = function () {
        //    setTimeout(function () {
        //        $('#detail-content .home-listing').each(function (i, item) {
        //            slider = $(item).bxSlider({
        //                minSlides: 4,
        //                maxSlides: 4,
        //                controls: false,
        //                moveSlides: 4,
        //                slideWidth: 192,
        //                slideMargin: 10
        //            });
        //            sliders.push(slider);
        //        });
        //        addthis.toolbox('.addthis_toolbox');
        //    }, 100);
        //};

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