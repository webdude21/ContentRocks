
(function ($) {
    var tokenInputSelector = $('input[data-role=tagsinput]'),
    submitButtonSelector = $('input[type=submit]');

    submitButtonSelector.on('click', function () {
        console.log(tokenInputSelector.val());
    });
}($));