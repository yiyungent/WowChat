$(function () {
	$(document).pjax('[data-pjax] a, a[data-pjax]', '#pjax-container');

	$(document).on('pjax:send', function () {
		$('#loading').show()
	})
	$(document).on('pjax:complete', function () {
		$('#loading').hide("slow");
	})
});

function test() {
	$.pjax({ url: '?data=' + new Date().getTime(), container: '#pjax-container' });
	return false;
}

