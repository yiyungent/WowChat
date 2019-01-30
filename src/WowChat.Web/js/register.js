$(function () {

	// start 腾讯验证
	// 点击验证
	window.tCaptcha = new TencentCaptcha(
		'2041300407',
		function (res) {
			if (res.ret === 0) {
				// 腾讯云第一次验证通过
				console.log("第一次验证 通过");
				// 发送票据到服务器 -- 获取邮箱验证码
				getEmailVCode(res.ticket, res.randstr);
				// 30s后重新获取验证码
				yzmGetTime($('.yzm-button'));
			}
		}
	);
	// end 腾讯验证

	$('#js-btn-reg').on('click', function () {
		// 检查输入框
		if (!checkInput) {
			return;
		}
		var $yzm = $('.form-group:eq(3)');
		if ($yzm.find('input').val() == '') {
			$yzm.find('.error-message').text('验证码不能为空');
			return false;
		} else {
			$yzm.find('.error-message').text('');
		}
		// 检查通过--ajax到服务端--邮件验证码正确--展示注册成功
		regInfoSend();
	});

	$('input.el-input-inner').on('change', function () {
		checkInput();
	});

	// 点击获取验证码--弹出滑动验证--验证通过:发送验证码
	$('.yzm-button').on('click', function () {
		if (checkInput()) {
			tCaptcha.show();
		}
	});
});

function getEmailVCode(ticket, randStr) {
	var email = $('.form-group:eq(2)').find('input').val().trim();
	$.ajax({
		url: "/register/getEmailVCode",
		type: "POST",
		data: { "email": email, "ticket": ticket, "randStr": randStr },
		dataType: "json",
		success: function (data) {
			if (data.code == -1) {
				console.log(data.message);
				$('.yzm .error-message').text(data.message);
			} else if (data.code == 1) {
				console.log(data.message);
				$('.yzm .error-message').text('验证码已发送，5分钟内有效');
			}
		}
	});
}

function regInfoSend() {
	var nickName = $('.form-group:eq(0) input').val().trim();
	var pwd = $('.form-group:eq(1) input').val();
	var email = $('.form-group:eq(2) input').val().trim();
	var yzm = $('.form-group:eq(3) input').val().trim();
	$.ajax({
		url: "/register/index",
		type: "POST",
		data: { "nickName": nickName, "password": pwd, "email": email, "vCode": yzm },
		dataType: "json",
		success: function (data) {
			if (data.code == -1) {
				// 注册失败
				$('.register-hidden-group:eq(3)').html(data.message).addClass('text-error');
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
	if ($nickName.find('input').val().trim() == '') {
		$nickName.find('.error-message').text('请告诉我你的昵称吧');
		return false;
	} else {
		$nickName.find('.error-message').text('')
	}
	if ($pwd.find('input').val().length < 6) {
		$pwd.find('.error-message').text('密码不能小于6个字符');
		return false;
	} else {
		$pwd.find('.error-message').text('')
	}
	if ($email.find('input').val() == '') {
		$email.find('.error-message').text('亲，请填写邮箱号');
		return false;
	}
	checkEmail($email.find('input').val().trim());
	if ($email.find('.error-message').text() != '') {
		return false;
	}

	return true;
}

function showRegSuccess() {
	var register_title = '<h2 class="register-title"><span>注册成功！</span><h2>';
	$(register_title).insertAfter(".title-line");
	$(".title-line").remove();
	var register_box_inner = '<div style="text-align: center;font-size:16px">还剩{0}s跳转</div>';
	var sec = 3;
	$(".register-box").html(register_box_inner.format(sec));
	setTimeout(function () {
		var returnUrl = getQueryString('returnUrl');
		if (returnUrl != null) {
			window.location.href = returnUrl;
		} else {
			window.location.href = '/';
		}
	}, sec * 1000);
	setInterval(function () {
		sec--;
		$(".register-box").html(register_box_inner.format(sec));
	}, 1000);
}

function checkEmail(email) {
	$.ajax({
		url: "/register/checkEmail",
		type: "POST",
		data: { "email": email },
		dataType: "json",
		success: function (data) {
			if (data.code == -1) {
				// 邮箱不可用
				$('.form-group:eq(2)').find('.error-message').text(data.message);
			} else if (data.code == 1) {
				// 邮箱可用
				$('.form-group:eq(2)').find('.error-message').text('');
			}
		}
	});
}

var yzmSec = 30;
/**
 * 30s后获取验证码
 */
function yzmGetTime($obj) {
	if (yzmSec == 0) {
		$obj.removeAttr("disabled");
		$obj.text("获取验证码");
		$obj.removeClass("is-disabled");
		yzmSec = 30;
		return;
	} else {
		$obj.attr("disabled", "disabled");
		$obj.text(yzmSec + "s后重新获取");
		$obj.addClass("is-disabled");
		yzmSec--;
	}
	setTimeout(function () {
		yzmGetTime($obj)
	}, 1000)
}

function getQueryString(name) {
	var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', 'i');
	var r = window.location.search.substr(1).match(reg);
	if (r != null) {
		return unescape(r[2]);
	}
	return null;
}

String.prototype.trim = function () {
	return this.replace(/(^\s*)|(\s*$)/g, '');
}

String.prototype.format = function () {
	var args = arguments;
	return this.replace(/\{(\d+)\}/g, function (s, i) {
		return args[i];
	});
};
