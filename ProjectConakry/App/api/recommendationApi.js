define(['durandal/system', 'services/logger', 'services/global', 'knockout', 'plugins/http', 'services/scripts'],
    function (system, logger, global, ko, http, scripts) {
        var service = global.serviceUrl + 'RecommendationsServiceRESTAPI/';

        var vm = {
            get: get,
            getById: getById,
            update: update,
            deleteById: deleteById
        };

        return vm;

        function get(observableList,userId) {
            var url = service + 'get?userId=' + userId + "&count=25";
            var promise = http.get(url);

            return promise.then(function (data) {
                observableList(data);
            }).fail(function (error) {
                logger.logError("Error while loading recommendations: " + scripts.jsonMessage(error), null, "Get Recommendation List", true);
            });
        }

        function update(recommendation) {
            return http.post(service, recommendation);
        }

        function getById(id) {
            return http.get(service, id);
        }

        function deleteById(id) {
            return http.delete(service, id);
        }
    });