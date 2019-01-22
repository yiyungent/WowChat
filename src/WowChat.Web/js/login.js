// start 腾讯验证
window.onload = function () {
	// 点击验证
	window.tCaptcha = new TencentCaptcha(
		document.getElementById("btnVerifyCode"),
		'2026888591',
		function (res) {
			if (res.ret === 0) {
				// 腾讯云验证通过
				console.log("腾讯第一次验证通过");
				// 第一次验证通过
				var btnVerify = document.getElementById("btnVerifyCode");
				btnVerify.innerText = "验证通过";
				$(".text-warning").text("验证通过");
				btnVerify.className = "verify-success";
				document.getElementById("verify-box").className = "verify-box verify-box-success";
				// 准备 服务端 第二次验证
				document.getElementById("inputTicket").value = res.ticket;
				document.getElementById("inputRandstr").value = res.randstr;
				console.log("第一次验证 结束");
			}
		}
	);
};
// end 腾讯验证