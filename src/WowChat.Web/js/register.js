$(function () {
	$("#js-btn-reg").on("click", function () {
		// 检查输入框是否都填写
		// 检查通过--ajax到服务端--邮件验证码正确--展示注册成功
		showRegSuccess();
	});
});

function showRegSuccess() {
	var register_title = '<h2 class="register-title"><span>注册成功！</span><h2>';
	$(register_title).insertAfter(".title-line");
	$(".title-line").remove();
	var register_box_inner = '<div style="text-align: center;font-size:16px">还剩5s跳转至登录</div>';
	$(".register-box").empty().append(register_box_inner);
}