<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="StudentDashboard.aspx.cs" Inherits="Student_StudentDashboard" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>CGMS | Student Dashboard</title>
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
                            <li class="breadcrumb-item"><a href="StudentDashboard.aspx">Home</a></li>
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

                    <div class="col-md-12">
                        <div class="card mt-md-3">
                            <div class="card-header border-bottom border-danger">
                                Grievance Details                      
                            </div>
                            <div class="card-body" style="height: 400px; overflow-y: scroll;">


                                <asp:GridView ID="grdgrievancedetails" runat="server" CssClass="w-100" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grdgrievancedetails_RowCommand">
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
                                        
                                        <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="m-1 p-1 text-center text-md-start" ItemStyle-CssClass="m-1 p-1 text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnview" CommandArgument='<%#Eval("GrievanceId") %>' CommandName="view" runat="server" class=" btn btn-outline-secondary btn-xs" >Document</asp:LinkButton>
                                                <asp:LinkButton ID="btnprint" CommandArgument='<%#Eval("GrievanceId") %>' CommandName="print" runat="server" class=" btn btn-outline-secondary btn-xs" >Re-Print</asp:LinkButton>
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


            </div>

        </section>

    </div>


</asp:Content>

