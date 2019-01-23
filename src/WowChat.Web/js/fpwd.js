$(function () {
	confirmAccount();
	// start 腾讯验证
	// 点击验证
	window.tCaptcha = new TencentCaptcha(
		$(".el-button")[0],
		'2041300407',
		function (res) {
			if (res.ret === 0) {
				// 腾讯云验证通过
				console.log("腾讯第一次验证通过");
				// 第一次验证通过
				// 验证第一次通过后，保存票据和账号，跳到下一步
				$(".data-step .userName").val($(".el-input-inner").val().trim());
				resetPassword();
				// 准备 服务端 第二次验证
				$(".data-step .ticket").val(res.ticket);
				$(".data-step .randStr").val(res.randstr);
				console.log("第一次验证 结束");
			}
		}
	);
	// end 腾讯验证
});

function confirmAccount() {
	var htmlStr = '<div class="form-group">\
						<div class="el-input">\
							<input class="el-input-inner" type="text" placeholder="请输入绑定的手机号/邮箱">\
						</div>\
						<div class="form-message text-error"></div>\
				   </div>\
				   <div class="form-group">\
						<button class="el-button" type="button"><span>确认</span></button>\
				   </div>';
	$(".step-container").html(htmlStr);
	$(".el-button").on("click", function () {
		// 是否输入为空
		if ($(".el-input-inner").val().trim() == "") {
			$(".el-input").addClass("input-error");
			$(".form-group .text-error").text("请输入手机号/邮箱");
			return;
		}
		// 弹出滑动验证框
		//tCaptcha.show();
	});
	// 效验是否输入
	$(".el-input-inner").on("change", function () {
		// 是否输入为空
		if ($(".el-input-inner").val().trim() == "") {
			$(".el-input").addClass("input-error");
			$(".form-group .text-error").text("请输入手机号/邮箱");
		} else {
			$(".el-input").removeClass("input-error");
			$(".form-group .text-error").text("");
		}
	});
}

function resetPassword() {
	$(".step-list a:eq(0)").removeClass("active").addClass("step-pass");
	$(".step-list a:eq(1)").addClass("active");
	var htmlStr = '<div class="form-group">\
						<span class="form-group-title">新密码</span>\
	                    <div class="el-input">\
							<input type="password" class="el-input-inner" placeholder="新密码：6～16位字符，区分大小写">\
						</div>\
	                    <div class="form-message text-error"></div>\
				   </div>';
	$(".step-container").html(htmlStr);
}
