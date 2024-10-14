<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="ForgetPassword" %>

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
                                <img src="logindesign/img/c2.png" alt="Logo"/></a>
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
                    <div class="fxt-main-form">
                        <div class="fxt-inner-wrap fxt-opacity fxt-transition-delay-13">
                            <h2 class="fxt-page-title">Log In</h2>
                            <p class="fxt-description">Log In to Register your Grievances !</p>                            
                                <div class="form-group">                                    
                                    <asp:Label runat="server"  class="fxt-label" Text="User ID"></asp:Label>
                                    <asp:TextBox runat="server" id="txtuserid" class="form-control" placeholder="Enter your user id"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblpassword" class="fxt-label" Text="Password"></asp:Label>
                                    <asp:TextBox runat="server" id="txtpassword" TextMode="Password" class="form-control" placeholder="Enter Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <a href="#" class="fxt-switcher-text">Forgot Password</a>
                                </div>
                                <div class="form-group mb-3">
                                    <button type="submit" class="fxt-btn-fill">Log in</button>
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
</body>
</html>
