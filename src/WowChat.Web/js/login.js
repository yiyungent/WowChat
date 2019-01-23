﻿// start 腾讯验证
window.onload = function () {
	// 点击验证
	window.tCaptcha = new TencentCaptcha(
		document.getElementById("btnVerifyCode"),
		'2041300407',
		function (res) {
			if (res.ret === 0) {
				// 腾讯云验证通过
				console.log("腾讯第一次验证通过");
				// 第一次验证通过
				$("#btnVerifyCode").text("验证通过");
				$("#btnVerifyCode")[0].className = "verify-success";
				$("#verify-box")[0].className = "verify-box verify-box-success";
				// 准备 服务端 第二次验证
				$("#inputTicket").val(res.ticket);
				$("#inputRandstr").val(res.randstr);
				console.log("第一次验证 结束");
			}
		}
	);
};
// end 腾讯验证

$(function () {
	// 点击登录
	$(".btn-login").on("click", function () {
		// 获取用户名(手机号/邮箱), 密码, 票据
		var userName = $(".userName input").val().trim();
		var password = $(".password input").val();
		var ticket = $("#inputTicket").val();
		var randStr = $("#inputRandstr").val();
		// 检查登录信息填写
		if (!checkLoginInfo()) {
			// 未通过
			return;
		}
		// 是否滑动验证
		if (ticket == "" || randStr == "") {
			// 未滑动验证则弹出验证框
			tCaptcha.show();
			return;
		}
		// 发送用户名，密码，票据到服务端
		$.ajax({
			url: "/login",
			type: "POST",
			data: { "userName": userName, "password": password, "ticket": ticket, "randStr": randStr },
			dataType: "json",
			success: function (data) {
				if (data.code == "-2") {
					// 验证码错误
					$(".remember .tips").text(data.message);
				} else if (data.code == "-1") {
					$(".remember .tips").text(data.message);
					$(".userName input").addClass("error");
					$(".userName .status").addClass("error");
					$(".password input").addClass("error");
					$(".password .status").addClass("error");
					// 清空密码框
					$(".password input").val("");
				} else if (data.code == "1") {
					window.location.href = "/";
				}
			}
		});
		// 根据返回结果判断:跳转到首页/提示信息

		// 点击登录后，下次需要重新验证
		$("#btnVerifyCode").text("点击验证");
		$("#btnVerifyCode")[0].className = "verify-detect";
		$("#verify-box")[0].className = "verify-box verify-box-detect";
	});
	$(".form-login input").on("change", function () {
		checkLoginInfo();
	});
});

/**
 * 效验登录信息填写有效性
 * */
function checkLoginInfo() {
	var isPass = true;
	// 获取用户名(手机号/邮箱), 密码, 票据
	var userName = $(".userName input").val().trim();
	var password = $(".password input").val();
	var ticket = $("#inputTicket").val();
	var randStr = $("#inputRandstr").val();
	// 效验用户名，密码是否填写
	if (userName == "") {
		isPass = false;
		$(".userName input").addClass("error");
		$(".userName .status").addClass("error");
		$(".userName .tips").text("请输入注册时用的邮箱或者手机号呀");
	} else {
		$(".userName input").removeClass("error");
		$(".userName .status").removeClass("error");
		$(".userName .tips").text("");
	}
	if (password == "") {
		isPass = false;
		$(".password input").addClass("error");
		$(".password .status").addClass("error");
		$(".password .tips").text("喵，你没输入密码么？");
	} else {
		$(".password input").removeClass("error");
		$(".password .status").removeClass("error");
		$(".password .tips").text("");
	}
	$(".remember .tips").text("");
	return isPass;
}


// 问吧。。。。。。。。。。。。。虽然我萌新
//// 算法？我很慌！！！！都说是萌新啦QAQ
//14: 41: 13 : 收到彈幕: 冰魄冫玄影 說: 一堆数组   随机放进一个数组里面
//14: 41: 56 : 收到彈幕: 冰魄冫玄影 說: 比如  5个3  6个7  8个8
//// QAQ，我都没看出规律，什么鬼？我放弃，求dalao解
//// 尴尬，不会，不好随机放，额鹅鹅鹅，
//// 那不是不符合题意，我还以为放进去时就要随机，其实也随意了
//14: 42: 14 : 收到彈幕: 冰魄冫玄影 說: 最好用递归实现


// _(￣0￣)_[哦~] 
// (・∀・(・∀・(・∀・*)))可以这么说吧