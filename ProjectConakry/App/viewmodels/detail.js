define(['durandal/app', 'services/navigating', 'knockout', 'jquery', 'services/logger', 'api/recommendationApi', 'kobindings/roundabout'],
    function (app, navigating, ko, $, logger, recommendationApi) {
        var sections = ["", "Related Videos"];

        var addThis = function () {
            var jsAddThis = document.createElement('script'),
            head = document.getElementsByTagName('head')[0];

            jsAddThis.async = true;
            jsAddThis.type = 'text/javascript';
            jsAddThis.src = 'http://s7.addthis.com/js/300/addthis_widget.js#pubid=ra-522955913726e62c';

            head.appendChild(jsAddThis);
        };

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

        var sliders = [];
        var slider;

        var loadSliders = function () {
            setTimeout(function () {
                $('#detail-content .home-listing').each(function (i, item) {
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
                addthis.toolbox('.addthis_toolbox');
            }, 100);
        };

        var attached = function () {
            addThis();
            loadSliders();
        };

        var activate = function () {
            if ($('#detail-content .home-listing').length > 0)
                return null;
            return recommendationApi.get(vm.recommendations)                
                 .done(function () {
                     vm.sections(makeSections(vm.recommendations()));
                     if ($('#detail-content .home-listing').length > 0) {
                         loadSliders();
                     }
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