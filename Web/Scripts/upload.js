$(document).ready(function () {
    $('#add-input-file').on('click', function () {
        var form = $('#form-upload');

        var count = form.find('input[type="file"]').length;

        var $divContainer = $('<div class="form-group">');
        var $inputContainer = $('<div class="col-md-10">');
        var inputTypeFile = $('<input class="form-control" type="file" name="file' + count + '" id="file_' + count + '" />');

        $inputContainer.append(inputTypeFile);
        $divContainer.append($inputContainer);

        form.append($divContainer);
    });
});