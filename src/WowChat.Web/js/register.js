$(function () {
	$('#js-btn-reg').on('click', function () {
		// 检查输入框
		if (!checkInput) {
			return;
		}
		// 检查通过--ajax到服务端--邮件验证码正确--展示注册成功
	});

	$('input.el-input-inner').on('change', function () {
		checkInput();
	});
});

function regInfoSend() {
	var nickName = $('.form-group:eq(0) input').val().trim();
	var pwd = $('.form-group:eq(1) input').val();
	var email = $('.form-group:eq(2) input').val().trim();
	var yzm = $('.from-group:eq(3) input').val().trim();
	$.ajax({
		url: "/register/index",
		type: "POST",
		data: { "nickName": nickName, "password": pwd, "email": email, "vCode": yzm },
		dataType: "json",
		success: function (data) {
			if (data.code == -1) {
				// 注册失败
				$('.register-hidden-group:eq(3)').html(data.message);
			} else if (data.code == 1) {
				// 注册成功
				showRegSuccess();
			}
		}
	});
}

function checkInput() {
	var $nickName = $('.form-group:eq(0)');
	var $pwd = $('.form-group:eq(1)');
	var $email = $('.form-group:eq(2)');
	var $yzm = $('.from-group:eq(3)');
	if ($nickName.find('input').val().trim() == '') {
		$nickName.find('.error-message').text('请告诉我你的昵称吧');
		return false;
	}
	if ($pwd.find('input').val().length < 6) {
		$pwd.find('.error-message').text('密码不能小于6个字符');
		return false;
	}
	if ($email.find('input').val() == '') {
		$email.find('.error-message').text('亲，请填写邮箱号');
		return false;
	} else if (existEmail($email.find('input').val().trim())) {
		$email.find('.error-message').text('邮箱已经被注册');
		return false;
	}
	if ($yzm.find('input').val() == '') {
		$yzm.find('.error-message').text('验证码不能为空');
		return false;
	}
}

function showRegSuccess() {
	var register_title = '<h2 class="register-title"><span>注册成功！</span><h2>';
	$(register_title).insertAfter(".title-line");
	$(".title-line").remove();
	var register_box_inner = '<div style="text-align: center;font-size:16px">还剩5s跳转至登录</div>';
	$(".register-box").empty().append(register_box_inner);
}

function existEmail(email) {
	var isExist = true;
	$.ajax({
		url: "/register/existEmail",
		type: "POST",
		data: { "email": email },
		dataType: "json",
		success: function (data) {
			if (data.code == -1) {
				// 邮箱不存在
				isExist = false;
			}
		}
	});
	return isExist;
}