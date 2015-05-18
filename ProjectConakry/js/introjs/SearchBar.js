$(document).ready(function () {
    var button = ".pull-tab";
    var menu = ".pulled-strip";
    var wrap = ".puller";

    function pull() {
        $.getScript("http://code.jquery.com/ui/1.8.24/jquery-ui.js")
         .done(function (script, textStatus) {

            $(wrap).animate({
                left: "-2px"
            }, "slow");
            $(".fa-search").switchClass("fa-search", "fa-close", "slow");
            $(".fa-close").switchClass("fa-cog", "fa-search",

             "slow");
            $(menu).addClass("visible");

         })
          .fail(function (jqxhr, settings, exception) {
              $("div.log").text("Triggered ajaxError handler.");
          });
    }

    function push() {
        $.getScript("http://code.jquery.com/ui/1.8.24/jquery-ui.js")
            .done(function (script, textStatus) {

            $(wrap).animate({
                left: "-360px"
            }, "slow");
            $(".fa-search").switchClass("fa-search", "fa-close",

                "slow");
            $(".fa-close").switchClass("fa-close", "fa-search",

                "slow");
            $(menu).removeClass("visible");

            })
            .fail(function (jqxhr, settings, exception) {
                $("div.log").text("Triggered ajaxError handler.");
            });
    }

    $(button).click(function () {
        if (!$(menu).hasClass("visible")) {
            pull();
        } else {
            push();
        }
    });

    $("input").each(function () {
        $(this).data('holder', $(this).attr('placeholder'));

        $(this).focusin(function () {
            $(this).attr('placeholder', '');
        });

        $(this).focusout(function () {
            $(this).attr('placeholder', $(this).data('holder'));
        });
    });
        
});