<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>CGMS</title>
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Favicon -->
    <link rel="shortcut icon" type="image/x-icon" href="img/c2.png" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="design/css/bootstrap.min.css" />
    <!-- Fontawesome CSS -->
    <link rel="stylesheet" href="design/css/fontawesome-all.min.css" />
    <!-- Flaticon CSS -->
    <link rel="stylesheet" href="design/font/flaticon.css" />
    <!-- Google Web Fonts -->
    <link href="design/css.css?family=Roboto:300,400,500,700&display=swap" rel="stylesheet" />
    <!-- Custom CSS -->
    <link rel="stylesheet" href="design/style.css" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" integrity="sha512-DTOQO9RWCH3ppGqcWaEA1BIZOC6xxalwEsw9c2QQeAIftl+Vegovlnee1c9QX4TctnWMn13TZye+giMm8e2LwA==" crossorigin="anonymous" referrerpolicy="no-referrer" />

    <script src="aes.js" type="text/javascript"></script>

    <script type="text/javascript">

        function SubmitsEncry() {

            var txtpassword = document.getElementById("<%=txtpassword.ClientID %>").value.trim();;
            var txtCaptcha = "<%=key %>";

            txtCaptcha = txtCaptcha + txtCaptcha + txtCaptcha + txtCaptcha;
            txtCaptcha = txtCaptcha.substring(0, 16);

            var key = CryptoJS.enc.Utf8.parse(txtCaptcha);
            var iv = CryptoJS.enc.Utf8.parse(txtCaptcha);


            var encryptedpassword = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(txtpassword), key,
                {
                    keySize: 128 / 8,
                    iv: iv,
                    mode: CryptoJS.mode.CBC,
                    padding: CryptoJS.pad.Pkcs7
                });

            document.getElementById("<%=txtpassword.ClientID %>").value = encryptedpassword;

        }


    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="preloader" class="preloader">
            <div class='inner'>
                <div class='line1'></div>
                <div class='line2'></div>
                <div class='line3'></div>
            </div>
        </div>
        <section class="fxt-template-animation fxt-template-layout33">
            <div class="fxt-content-wrap">
                <div class="fxt-heading-content">
                    <div class="fxt-inner-wrap fxt-transformX-R-50 fxt-transition-delay-3">
                        <div class="fxt-transformX-R-50 fxt-transition-delay-10">
                            <a href="#" class="fxt-logo">
                                <img src="design/img/c2.png" alt="Logo" /></a>
                        </div>
                        <div class="fxt-transformX-R-50 fxt-transition-delay-10">
                            <div class="fxt-middle-content">
                                <div class="fxt-sub-title">Welcome to</div>
                                <h1 class="fxt-main-title">Grievance Management System</h1>
                                <p class="fxt-description">Your Problems needs a solution.</p>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="fxt-form-content">
                    <div class="fxt-main-form py-3 py-md-0">
                        <div class="fxt-inner-wrap fxt-opacity fxt-transition-delay-13">
                            <h2 class="fxt-page-title">Log In</h2>
                            <p class="fxt-description">Log In to Register your Grievances !</p>
                            <div class="form-group">
                                <asp:Label runat="server" class="fxt-label" Text="User ID"></asp:Label>
                                <asp:TextBox runat="server" ID="txtusername" class="form-control " placeholder="Enter your user id"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblpassword" class="fxt-label" Text="Password"></asp:Label>
                                <asp:TextBox runat="server" ID="txtpassword" TextMode="Password" class="form-control " placeholder="Enter Password"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Image runat="server" ID="img" Height="50px" Width="160px" ImageUrl="~/captcha.aspx" CssClass="mb-1"/>
                                <asp:LinkButton runat="server" ID="btnrefreshcaptcha" Text="Refresh" CssClass="btn btn-sm btn-info mb-1">
                                    <i class="fas fa-retweet"></i>
                                </asp:LinkButton>
                                <asp:TextBox runat="server" ID="txtcaptcha" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <a href="ForgetPassword.aspx" class="fxt-switcher-text">Forgot Password</a>
                            </div>
                            <div class="form-group mb-3 text-center">
                                <asp:LinkButton runat="server" ID="btnlogin" CssClass="btn w-100 btn-outline-danger" OnClick="btnlogin_Click" OnClientClick="SubmitsEncry();">Log in</asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>

    <!-- jquery-->
    <script src="design/js/jquery.min.js"></script>
    <!-- Bootstrap js -->
    <script src="design/js/bootstrap.min.js"></script>
    <!-- Imagesloaded js -->
    <script src="design/js/imagesloaded.pkgd.min.js"></script>
    <!-- Validator js -->
    <script src="design/js/validator.min.js"></script>
    <!-- Custom Js -->
    <script src="design/js/main.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/js/all.min.js" integrity="sha512-GWzVrcGlo0TxTRvz9ttioyYJ+Wwk9Ck0G81D+eO63BaqHaJ3YZX9wuqjwgfcV/MrB2PhaVX9DkYVhbFpStnqpQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
</body>
</html>
