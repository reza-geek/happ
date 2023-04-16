// login() {
//     this.error = "";
//     if (!this.username || !this.password) {
//       this.error = "لطفا نام کاربری و رمز عبور را وارد نمایید.";
//       return;
//     }
//     if (!this.captcha) {
//       this.error = "لطفا عبارت امنیتی را وارد نمایید.";
//       return;
//     }
//     const bgColor = localStorage.getItem("bgColor");
//     const fastSearch = localStorage.getItem("fastSearch");
//     localStorage.clear();
//     if (bgColor) {
//       localStorage.setItem("bgColor", bgColor);
//     }
//     if (fastSearch != undefined && fastSearch != null) {
//       localStorage.setItem("fastSearch", fastSearch);
//     }

//     this.loginService.login(this.username, this.password, this.captcha, this.guid).subscribe(
//       (data) => {

//         localStorage.setItem("sh-token", data.token.toString());
//         this.router.navigate([data.url]);
//       },
//       (error) => {
//         if (error.statusText == "Please enter captcha") {
//           this.error = "عبارت امنیتی اشتباه است";
//           this.loadCaptcha();
//         }
//         else if (error.status === 401) {
//           this.error = "نام کاربری و رمز عبور اشتباه است";
//           this.loadCaptcha();
//         } else {
//           this.error = "ارتباط با سرور برقرار نشد";
//         }
//       }
//     );
//   }