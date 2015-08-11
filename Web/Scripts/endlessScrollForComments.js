(function ($, postPageVariables) {
	var currentReviewPage = 1,
			   $commentsContainer = $('#comment-box'),
			   $showCommentsButton = $('#show-comments-button'),
			   allCommentsWareDownloaded = false,
			   ReadCommentsClicked = false,
			   $data,
			   appendMoreComments = function () {
			   	ReadCommentsClicked = true;
			   	$.ajax(
				{
					url: postPageVariables.loadCommentsUrl + "?page=" + currentReviewPage,
					type: "GET",
					success: function (data) {
						if (data.length > postPageVariables.pageSize) {
							$data = $(data);
							$commentsContainer.append($data);
							currentReviewPage += 1;
						} else if (currentReviewPage > 1) {
							$commentsContainer.append(postPageVariables.noMoreCommentsLabel);
							$showCommentsButton.remove();
							allCommentsWareDownloaded = true;
						} else {
							$commentsContainer.append(postPageVariables.noCommentsLabel);
							$showCommentsButton.remove();
							allCommentsWareDownloaded = true;
						}
					}
				});
			   }

	$(window).scroll(function () {
		if ($(window).scrollTop() === $(document).height() - $(window).height()) {
			if (!allCommentsWareDownloaded) {
				if (ReadCommentsClicked) {
					appendMoreComments();
				}
			}
		}
	});

	$showCommentsButton.on("click", appendMoreComments);
}($, postPageVariables))