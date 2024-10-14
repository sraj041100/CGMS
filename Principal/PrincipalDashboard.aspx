<%@ Page Title="" Language="C#" MasterPageFile="~/Principal/Principal.master" AutoEventWireup="true" CodeFile="PrincipalDashboard.aspx.cs" Inherits="Principal_PrincipalDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>CGMS | Principal Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">

        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0">Dashboard</h1>
                    </div>

                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="PrincipalDashboard.aspx">Home</a></li>
                            <li class="breadcrumb-item active">Dashboard</li>
                        </ol>
                    </div>

                </div>

            </div>

        </div>

        <section class="content">
            <div class="container-fluid">

                <div class="row">
                    <div class="col-lg-2 col-6">

                        <div class="small-box bg-info">
                            <div class="inner">
                                <h3>
                                    <asp:Label runat="server" ID="lbltotalgrievance" Text="0"></asp:Label></h3>

                                <p>Total Grievance</p>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-2 col-6">

                        <div class="small-box bg-success">
                            <div class="inner">
                                <h3>
                                    <asp:Label runat="server" ID="lblopengrievance" Text="0"></asp:Label></h3>

                                <p>Open Grievance</p>
                            </div>

                        </div>
                    </div>

                    <div class="col-lg-2 col-6">

                        <div class="small-box bg-warning">
                            <div class="inner">
                                <h3>
                                    <asp:Label runat="server" ID="lblclosedgrievance" Text="0"></asp:Label></h3>

                                <p>Closed Grievance</p>
                            </div>

                        </div>
                    </div>
                </div>



                <div class="col-md-12">
                    <div class="card mt-md-3">
                        <div class="card-header border-bottom border-danger">
                            <div class="row">
                                <div class="col-12 text-danger text-center mb-3" style="font-size: 25px;">
                                    Search Grievances
                                </div>

                                <div class="col-md-3 col-12">
                                    <div class="input-group input-group-sm">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Grievance Type</span>
                                        </div>
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="drpgrievancetype" OnSelectedIndexChanged="drpgrievancetype_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-auto col-12 text-center text-bold my-2 my-md-0">OR</div>

                                <div class="col-md-3 col-12">
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
                        </div>
                        <div class="card-body" style="height: 500px; overflow: auto;">

                            <asp:GridView ID="grdgrievancedetails" runat="server" CssClass="w-100" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="true" PagerSettings-Position="Bottom" PageSize="20" OnRowCommand="grdgrievancedetails_RowCommand" OnPageIndexChanging="grdgrievancedetails_PageIndexChanging" EmptyDataText="No Data Found">
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

                                    <asp:TemplateField HeaderText="Forward To" HeaderStyle-CssClass="m-1 p-1 text-center text-md-start" ItemStyle-CssClass="m-1 p-1 text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnedit" CommandArgument='<%#Eval("id") %>' CommandName="ed" runat="server" class=" btn btn-outline-secondary btn-xs">View/Close</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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

        </section>

    </div>


</asp:Content>

