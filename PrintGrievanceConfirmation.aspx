<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintGrievanceConfirmation.aspx.cs" Inherits="PrintGrievanceConfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>CGMS | Print</title>
    <!-- Favicon-->
    <link rel="icon" type="image/x-icon" href="../design/img/c2.png" />
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../DashboardDesign/plugins/fontawesome-free/css/all.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Tempusdominus Bootstrap 4 -->
    <link rel="stylesheet" href="../DashboardDesign/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="../DashboardDesign/plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <!-- JQVMap -->
    <link rel="stylesheet" href="../DashboardDesign/plugins/jqvmap/jqvmap.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../DashboardDesign/dist/css/adminlte.min.css">
    <!-- overlayScrollbars -->
    <link rel="stylesheet" href="../DashboardDesign/plugins/overlayScrollbars/css/OverlayScrollbars.min.css">
    <!-- Daterange picker -->
    <link rel="stylesheet" href="../DashboardDesign/plugins/daterangepicker/daterangepicker.css">
    <!-- summernote -->
    <link rel="stylesheet" href="../DashboardDesign/plugins/summernote/summernote-bs4.min.css">

    <style>
        @media print {
            @page {
                size: portrait;
            }
        }

        @media print {
            html, body {
                height: auto;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row mt-3 mx-3 ">
                <div class="col-md-12 ">
                    <div class="row py-2" style="border: 2px solid black">
                        <div class="col-1 text-center">
                            <img src="design/img/c2.png" height="150" />
                        </div>
                        <div class="col-10 text-center text-black">
                            <div class="w-100" style="font-weight: bold !important; font-size: 25px;">
                                St. Xavier’s College of Management & Technology<br />
                                NAAC Accredited with B++ Grade (1st Cycle)<br />
                                (Affliated to Aryabhatta Knowledge University)<br />
                                Digha-Ashiyana Road, Digha Ghat, Patna - 800011, Bihar<br />


                            </div>
                        </div>

                    </div>
                </div>

                <div class="col-md-12 text-center border-top-0 py-1 text-black" style="border: 2px solid black">
                    <label style="font-weight: bold !important;">Acknowledgement Slip</label>
                </div>

                <div class="col-md-12 text-end border-top-0 py-1 text-black" style="border: 2px solid black">
                    <label style="font-weight: bold !important;">Print Date : <%=DateTime.Now.ToString("dd-MM-yyyy") %></label>
                </div>
                <div class="col-md-12 border-top-0 " style="border: 2px solid black">

                    <div class="row py-1">
                        <div class=" col-6 pt-1 text-black">
                            <span style="font-weight: bold !important;">Registration Date :</span>
                            &nbsp;
                            <asp:Label runat="server" ID="lblregistrationdate"></asp:Label>
                        </div>
                        <div class=" col-6 pt-1 text-black">
                            <span style="font-weight: bold !important;">Grievance Number : &nbsp;</span>
                            <asp:Label runat="server" ID="lblgrievancenumber"></asp:Label>
                        </div>
                        <div class="col-6 pt-1 text-black">
                            <span style="font-weight: bold !important;">Name : &nbsp;</span>
                            <asp:Label runat="server" ID="lblname"></asp:Label>
                        </div>
                        <div class="col-6 pt-1 text-black">
                            <span style="font-weight: bold !important;">Department : &nbsp;</span>
                            <asp:Label runat="server" ID="lbldepartment"></asp:Label>
                        </div>
                        <div class="col-6 pt-1 text-black">
                            <span style="font-weight: bold !important;">Email : &nbsp;</span>
                            <asp:Label runat="server" ID="lblemail"></asp:Label>
                        </div>
                        <div class="col-6 pt-1 text-black">
                            <span style="font-weight: bold !important;">Grievance Type : &nbsp;</span>
                            <asp:Label runat="server" ID="lblgrievancetype"></asp:Label>
                        </div>

                        <div class="col-6 pt-1 text-black">
                            <span style="font-weight: bold !important;">Grievance Sub-type : &nbsp;</span>
                            <asp:Label runat="server" ID="lblgrievancesubtype"></asp:Label>
                        </div>
                        <div class="col-6 pt-1 text-black">
                            <span style="font-weight: bold !important;">Grievance Details : &nbsp;</span>
                            <asp:Label runat="server" ID="lblgrievancedetail"></asp:Label>
                        </div>

                        <div class="col-6 pt-1 text-black" runat="server" visible="false" id="divstatus">
                            <span style="font-weight: bold !important;">Grievance Status : &nbsp;</span>
                            <asp:Label runat="server" ID="lblgrievancestatus"></asp:Label>
                        </div>

                        <div class="col-6 pt-1 text-black" runat="server" visible="false" id="divremarks">
                            <span style="font-weight: bold !important;">Closing Remarks : &nbsp;</span>
                            <asp:Label runat="server" ID="lblclosingremarks"></asp:Label>
                        </div>

                        <div class="col-6 pt-1 text-black" runat="server" visible="false" id="divstatusdate">
                            <span style="font-weight: bold !important;">Closing Date : &nbsp;</span>
                            <asp:Label runat="server" ID="lblstatusdate"></asp:Label>
                        </div>

                    </div>
                </div>

                <div class="col-md-12 text-center mt-3">
                    <asp:LinkButton runat="server" Text="Print" ID="btnprint" CssClass="btn btn-info btn-sm " OnClientClick="hidebuttonandprint()"></asp:LinkButton>
                    <asp:LinkButton runat="server" Text="Home" ID="btnhome" CssClass="btn btn-secondary btn-sm " OnClick="btnhome_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </form>

    <!-- jQuery -->
    <script src="../DashboardDesign/plugins/jquery/jquery.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <script src="../DashboardDesign/plugins/jquery-ui/jquery-ui.min.js"></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->

    <!-- Bootstrap 4 -->
    <script src="../DashboardDesign/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- ChartJS -->
    <script src="../DashboardDesign/plugins/chart.js/Chart.min.js"></script>

    <!-- AdminLTE App -->
    <script src="../DashboardDesign/dist/js/adminlte.js"></script>

    <script type="text/javascript">
        function hidebuttonandprint() {
            document.getElementById('btnprint').style.visibility = 'hidden';
            document.getElementById('btnhome').style.visibility = 'hidden';

            window.print();

        }


    </script>
</body>
</html>
