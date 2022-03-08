$(function () {

    var registerUserButton = $("#UserRegistrationModal button[name='register']").click(onUserRegisterClick);

    function onUserRegisterClick() {

        var url = "/UserAuth/RegisterUser";

        var antiForgeryToken = $("#UserLoginModal input[name='__RequestVerificationToken']").val();

        var email = $("#UserRegistrationModal input[name = 'Email']").val();
        var password = $("#UserRegistrationModal input[name = 'Password']").val();
        var confirmpassword = $("#UserRegistrationModal input[name = 'ConfirmPassword']").val();
        var ime = $("#UserRegistrationModal input[name = 'Ime']").val();
        var prezime = $("#UserRegistrationModal input[name = 'Prezime']").val();
        var adresa1 = $("#UserRegistrationModal input[name = 'Adresa1']").val();
        var adresa2 = $("#UserRegistrationModal input[name = 'Adresa2']").val();
        var phoneNumber = $("#UserRegistrationModal input[name = 'PhoneNumber']").val();
        

        var user = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            ConfirmPassword: confirmpassword,
            Ime: ime,
            Prezime: prezime,
            Adresa1: adresa1,
            Adresa2: adresa2,
            PhoneNumber: phoneNumber,
            AcceptUserAgreement:true
        };

        $.ajax({
            type: "POST",
            url: url,
            data: user,
            success: function (data) {

                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='RegistrationInValid']").val() == "true";

                if (hasErrors == true) {
                    $("#UserRegistrationModal").html(data);

                    userLoginButton = $("#UserRegistrationModal button[name='register']").click(onUserRegisterClick);

                    var form = $("#UserRegistrationForm");

                    $(form).removeData("validator");
                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);

                }
                else {
                    location.href = 'Home/Index';

                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_login", "danger", "Error!", errorText);

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }
});