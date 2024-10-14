<%@ Page Title="" Language="C#" MasterPageFile="~/Principal/Principal.master" AutoEventWireup="true" CodeFile="GrievanceProcessing.aspx.cs" Inherits="Principal_GrievanceProcessing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>CGMS | Grievance Processing</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">

        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0">Grievance Processing</h1>
                    </div>

                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="PrincipalDashboard.aspx">Home</a></li>
                            <li class="breadcrumb-item active">Grievance Processing</li>
                        </ol>
                    </div>

                </div>

            </div>

        </div>

        <section class="content">
            <div class="container-fluid">

                <div class="row">

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Grievance ID</div>
                    <div class="col-md-2 mb-2">
                        <asp:Label runat="server" ID="lblgrievanceid" class="form-control form-control-sm w-100"></asp:Label>
                    </div>

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Name</div>
                    <div class="col-md-2 mb-2">
                        <asp:Label runat="server" ID="lblname" class="form-control form-control-sm w-100"></asp:Label>
                    </div>

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Email</div>
                    <div class="col-md-2 mb-2">
                        <asp:Label runat="server" ID="lblemail" class="form-control form-control-sm"></asp:Label>
                    </div>

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Grievance Type</div>
                    <div class="col-md-2 mb-2">
                        <asp:Label runat="server" ID="lblgrievancetype" CssClass="form-control form-control-sm"></asp:Label>
                    </div>

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Grievance Sub-Type</div>
                    <div class="col-md-2 mb-2">
                        <asp:Label runat="server" ID="lblgrievancesubtype" CssClass="form-control form-control-sm"></asp:Label>
                    </div>

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Grievance Details</div>
                    <div class="col-md-2 mb-2">
                        <asp:TextBox runat="server" ID="lblgrievancedetails" TextMode="MultiLine" Rows="2" MaxLength="200" class="form-control form-control-sm"></asp:TextBox>
                    </div>
                    <asp:HiddenField runat="server" ID="txtdocumenturl" />

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Attachement</div>
                    <div class="col-md-2 mb-md-2 m-0">
                        <asp:LinkButton runat="server" ID="btngrievancedocument" Text="View Attachement (if any)" CssClass="btn btn-sm btn-secondary" OnClick="btngrievancedocument_Click"></asp:LinkButton>
                    </div>

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Closing Remarks</div>
                    <div class="col-md-2 mb-2">
                        <asp:TextBox runat="server" ID="txtremarks" class="form-control form-control-sm"></asp:TextBox>
                    </div>

                    <div class="col-md-2 text-md-right mb-md-2 m-0">Closure Attachement (if any)<span class="text-danger font-weight-lighter" style="font-size: 12px;">PDF, JPEG, JPG only</span></div>
                    <div class="col-md-2 mb-2">
                        <asp:FileUpload runat="server" ID="fileupload"></asp:FileUpload>
                    </div>

                    <div class="col-12 text-center pt-5">
                        <asp:LinkButton runat="server" ID="btnclose" Text="Close Grievance" CssClass="btn btn-sm btn-primary" OnClick="btnclose_Click"></asp:LinkButton>
                    </div>
                </div>



            </div>

        </section>

    </div>
</asp:Content>
