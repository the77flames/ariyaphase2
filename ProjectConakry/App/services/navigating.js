define(['plugins/router', 'knockout'], function (router, ko) {

    var busy = ko.observable(false);
    
    function showBusy() {
        if (router.isNavigating() || busy()) {
            return true;
        }
        return false;
    }

    var vm = {
        busy: busy,
        showBusy: showBusy
    };

    return vm;

});