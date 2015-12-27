$(document).ready(function(){
	$('input[type=range]').mouseup(function(){
		var range_id = $(this).attr('id');
		var range_value = $(this).val();
		$('#range-value-' + range_id).html(range_value);
	});
	$('.overlay, .close-modal').click(function(){
		$('.overlay').hide();
		$('.modal').hide();
	});

	$('#register').click(function(){
		validate_registration();
	});

	$('#subscribe').click(function(){
		validate_subscription();
	});
});
var openTerms = function(){
	$('.overlay').show();
	$('.modal').show();
};
var validate_registration = function(){

    var isValidEntries = true;
    if ($('#first-name').val() == '' && $('#last-name').val() == '') {
        isValidEntries = false;
		$('#name_error').show().text("Please enter your name");
	} else {
		$('#name_error').hide();
	}

	if ($('#dob').val() == '' && $('#birth-place').val() == '') {
	    isValidEntries = false;
		$('#birth_error').show().text("Please enter your date and place of birth");
	} else {
		$('#birth_error').hide();
	}

	if ($('#stage-name').val() == '') {
	    isValidEntries = false;
		$('#stagename_error').show().text("Please enter stage name");
	} else {
		$('#stagename_error').hide();
	}

	if ($('#nationality').val() == '') {
	    isValidEntries = false;
		$('#nationality_error').show().text("Please enter your nationality");
	} else {
		$('#nationality_error').hide();
	}

	if ($('#experience').val() == '') {
	    isValidEntries = false;
		$('#experience_error').show().text("Please describe your experience in brief");
	} else {
		$('#experience_error').hide();
	}

	if ($('#video').val() == '') {
	    isValidEntries = false;
		$('#video_error').show().text("Please upload your video entry");
	} else if ($('#video')[0].files[0].size > 10240000) {
	    isValidEntries = false;
		$('#video_error').show().text('Your file is ' + Math.round($('#video')[0].files[0].size / 1000000) + 'mb. Your video entry should not be more than 10mb');
	} else {
		$('#video_error').hide();
	}

	var scores_ids = ['range-value-commitment', 'range-value-communication', 'range-value-dress', 'range-value-knowledge', 'range-value-relationship', 'range-value-memory', 'range-value-etiquette', 'range-value-discipline', 'range-value-motivation', 'range-value-presense'];

	for (var x in scores_ids){
	    if ($('#' + scores_ids[x]).text() == '') {
	        isValidEntries = false;
			$('#score_error').show().text("Please score yourself in all the fields");
		} else {
			$('#score_error').hide();
		}

		// console.log(scores_ids[x]);
	}

	if ($('#inspire-1').val() == '' && $('#inspire-2').val() == '') {
	    isValidEntries = false;
		$('#inspire_error').show().text("Please enter the names of two African comedians who inspire you");
	} else {
		$('#inspire_error').hide();
	}

	if ($('#reg_email').val() == '') {
	    isValidEntries = false;
	    $('#regemail_error').show().text("Please enter your email");
	} else if (!isEmail($('#reg_email').val())) {
	    isValidEntries = false;
	    $('#regemail_error').show().text("Please enter a valid email");
	} else {
	    $('#regemail_error').hide();
	}

	if($('#agree-to-terms').is(':checked')){
		$('#terms_error').hide();
	} else {
	    isValidEntries = false;
		$('#terms_error').show().text("Please accept the terms and conditions");
	}
	if(isValidEntries)
	{
	    $('#wantedRegistrationForm').submit();
	}
};

var validate_subscription = function(){

	if($('#email').val() == ''){
		$('#email_error').show().text("Please enter your email");
	} else if(!isEmail($('#email').val())) {
		$('#email_error').show().text("Please enter a valid email");
	} else {
		$('#email_error').hide();
	}

	if($('input[name="payment_option"]:checked').val() == 'paypal'){
		$('#paymentoption_error').hide();
	} else {
		$('#paymentoption_error').show().text("Please select a payment method");
	}

	if($('#address1').val() == ''){
		$('#billingaddress_error').show().text("Please enter your billing address");
	} else {
		$('#billingaddress_error').hide();
	}
}

function isEmail(email) {
  var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
  return regex.test(email);
}