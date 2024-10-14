<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="GrievanceRegistration.aspx.cs" Inherits="Student_GrievanceRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>CGMS | Grievance Registration</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">

        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0">Grievance Registration</h1>
                    </div>

                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="StudentDashboard.aspx">Home</a></li>
                            <li class="breadcrumb-item active">Grievance Registration</li>
                        </ol>
                    </div>

                </div>

            </div>

        </div>

        <section class="content">
            <div class="container-fluid">




                <div class="row">
                    <div class="col-md-2 text-md-right mb-md-2 m-0">Name</div>
                    <div class="col-md-2 mb-2">
                        <asp:TextBox runat="server" ID="txtname" class="form-control form-control-sm w-100" ReadOnly="true"></asp:TextBox>
                    </div>



                    <div class="col-md-2 text-md-right mb-md-2 m-0">Email</div>
                    <div class="col-md-2 mb-2">
                        <asp:TextBox runat="server" ID="txtemail" class="form-control form-control-sm" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Grievance Type</div>
                    <div class="col-md-2 mb-2">
                        <asp:DropDownList runat="server" ID="drpgrievancetype" CssClass="form-control form-control-sm" AutoPostBack="true" OnSelectedIndexChanged="drpgrievancetype_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Grievance Sub-Type</div>
                    <div class="col-md-2 mb-2">
                        <asp:DropDownList runat="server" ID="drpgrievancesubtype" CssClass="form-control form-control-sm">
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Grievance Details</div>
                    <div class="col-md-2 mb-2">
                        <asp:TextBox runat="server" ID="txtgrievancedetails" TextMode="MultiLine" Rows="2" MaxLength="200" class="form-control form-control-sm"></asp:TextBox>
                    </div>

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Attachement (if any)<span class="text-danger font-weight-lighter" style="font-size: 12px;">PDF, JPEG, JPG only</span></div>
                    <div class="col-md-2 mb-2">
                        <asp:FileUpload runat="server" ID="fileupload" class=""></asp:FileUpload>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 text-center my-4">
                        <asp:LinkButton runat="server" ID="btnsubmit" Text="Submit" class="btn btn-outline-primary btn-sm" OnClick="btnsubmit_Click"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btncancel" Text="Cancel" class="btn btn-outline-danger btn-sm" OnClick="btncancel_Click"></asp:LinkButton>
                    </div>
                </div>

            </div>

        </section>

    </div>


</asp:Content>

