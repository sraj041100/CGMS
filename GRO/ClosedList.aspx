<%@ Page Title="" Language="C#" MasterPageFile="~/GRO/GROMasterPage.master" AutoEventWireup="true" CodeFile="ClosedList.aspx.cs" Inherits="GRO_ClosedList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>CGMS | Grievance Closed List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">

        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0">Closed List</h1>
                    </div>

                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="GRODashboard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Grievance List</li>
                            <li class="breadcrumb-item active">Closed</li>
                        </ol>
                    </div>

                </div>

            </div>

        </div>

        <section class="content">
            <div class="container-fluid">

                <div class="row">

                    <div class="col-md-12">
                        <div class="card mt-md-3">
                            <div class="card-header border-bottom border-danger">
                                Grievance Details

                        <div class="card-tools">
                            <div class="input-group input-group-sm">
                                <asp:TextBox runat="server" class="form-control form-control-sm" ID="txtgrievanceid" placeholder="Grievance ID"></asp:TextBox>
                                <div class="input-group-append">
                                    <div class="input-group-text">
                                        <asp:LinkButton runat="server" ID="btnsearch" OnClick="btnsearch_Click"><i class="fas fa-search"></i></asp:LinkButton>

                                    </div>
                                </div>
                                <asp:LinkButton runat="server" ID="btnrefresh" CssClass="btn btn-sm btn-outline-danger" OnClick="btnrefresh_Click"><i class="fas fa-sync"></i></asp:LinkButton>
                            </div>
                        </div>
                            </div>
                            <div class="card-body" style="height: 400px; overflow-y: scroll;">


                                <asp:GridView ID="grdgrievancedetails" runat="server" CssClass="w-100" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="true" PagerSettings-Position="Bottom" PageSize="20"  OnPageIndexChanging="grdgrievancedetails_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SNo" HeaderStyle-CssClass="m-1 p-1 text-center" ItemStyle-CssClass="m-1 p-1 text-center">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="grievanceid" HeaderText="Grievance ID" HeaderStyle-CssClass="m-1 p-1 text-md-start text-center" ItemStyle-CssClass="m-1 p-1 text-md-start text-center"></asp:BoundField>

                                        <asp:BoundField DataField="createdon" HeaderText="Date" HeaderStyle-CssClass="m-1 p-1 text-md-start text-center" ItemStyle-CssClass="m-1 p-1 text-md-start text-center" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundField>

                                        <asp:BoundField DataField="grievancetype" HeaderText="Grievance Type" HeaderStyle-CssClass="m-1 p-1 text-md-start text-center" ItemStyle-CssClass="m-1 p-1 text-md-start text-center"></asp:BoundField>

                                        <asp:BoundField DataField="grievancesubtype" HeaderText="Grievance Sub-Type" HeaderStyle-CssClass="m-1 p-1 text-md-start text-center" ItemStyle-CssClass="m-1 p-1 text-md-start text-center"></asp:BoundField>

                                        <asp:BoundField DataField="gstatus" HeaderText="Grievance Status" HeaderStyle-CssClass="m-1 p-1 text-md-start text-center" ItemStyle-CssClass="m-1 p-1 text-md-start text-center"></asp:BoundField>


                                       
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>

                            </div>
                        </div>
                    </div>



                </div>


            </div>

        </section>

    </div>
</asp:Content>

