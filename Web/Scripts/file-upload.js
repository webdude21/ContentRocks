$(function ($, fileUploadData) {
    $('#fileupload').fileupload({
        dataType: "json",
        url: fileUploadData.url,
        limitConcurrentUploads: 1,
        sequentialUploads: true,
        progressInterval: 100,
        maxChunkSize: 52428800,
        add: function (e, data) {
            $('#filelistholder').removeClass('hide');
            data.context = $('<div />').text(data.files[0].name).appendTo('#filelistholder');
            $('</div><div class="progress progress-striped active"><div class="progress-bar" style="width:0%"></div></div>').appendTo(data.context);
            $('#btnUploadAll').click(function () {
                data.submit();
            });
        },
        done: function (e, data) {
            data.context.html($('<a href="' + data.result.Url + '">' + data.result.FileName + '</a><span> ... ' + fileUploadData.completedTextLocale + '</span>'));
            $('</div><div class="progress progress-striped active"><div class="progress-bar" style="width:100%"></div></div>').appendTo(data.context);
        },
        progressall: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#overallbar').css('width', progress + '%');
        },
        progress: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            data.context.find('.progress-bar').css('width', progress + '%');
        }
    });
}($, fileUploadData));