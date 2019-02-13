$(document).ready(function () {
    $('.RegionAddEdit').validate({
       
        errorClass: 'input-validation-error', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',
        errorPlacement: function (error, e) {
            var ul = $(".validationSummary2 ul");
            if (ul.length > 0) {

                $(".validationSummary2").addClass("validation-summary-errors");
                $(".validationSummary2").removeClass("validation-summary-valid");
                ul.html("");

                for (var name in validator.errorList)
                    ul.append("<li>" + validator.errorList[name].message + "</li>")

            }
        },
        highlight: function (e) {

            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'Email': {
                required: true,
                email: true
            },

            'Password': {
                required: true,
                minlength: 6
            },

            'ConfirmPassword': {
                required: true,
                equalTo: '#Password'
            }
        },
        messages: {
            'Email': 'Please enter valid email address',

            'Password': {
                required: 'Please provide a password',
                minlength: 'Your password must be at least 6 characters long'
            },

            'ConfirmPassword': {
                required: 'Please provide a password',
                minlength: 'Your password must be at least 6 characters long',
                equalTo: 'Please enter the same password as above'
            }
        }
    });
});   