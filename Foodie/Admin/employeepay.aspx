<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="employeepay.aspx.cs" Inherits="Foodie.Admin.employeepay" %>

<%@ Import Namespace="Foodie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Dashboard page</h1>
    <div class="pcoded-inner-content ">

        <div class="main-body">
            <div class="page-wrapper">

                <div class="page-body">
                    <div class="row">
                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-muffin bg-c-blue card1-icon"></i>
                                    <span class="text-c-blue f-w-600">Employee count</span>
                                    <h4>10</h4>
                                    <div>
                                        <span class="f-left m-t-10 text-muted">
                                            <a href="Category.aspx"><i class="text-c-blue f-16 icofont icofont-eye-alt m-r-10"></i>
                                                View Details
                                            </a>
                                        </span>
                                    </div>
                                </div>
                            </div>




                            <!---salary-->

                            <%-- <h2>Employee Salary Calculator</h2>
                            <table border="1">
                                <tr>
                                    <td>Employee ID:</td>
                                    <td>
                                        <asp:TextBox ID="txtEmpID" runat="server" Width="100px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Employee Name:</td>
                                    <td>
                                        <asp:TextBox ID="txtEmpName" runat="server" Width="200px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Basic Salary:</td>
                                    <td>
                                        <asp:TextBox ID="txtBasicSalary" runat="server" Width="100px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Dearness Allowance (DA):</td>
                                    <td>
                                        <asp:TextBox ID="txtDA" runat="server" Width="100px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>House Rent Allowance (HRA):</td>
                                    <td>
                                        <asp:TextBox ID="txtHRA" runat="server" Width="100px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnCalculate" runat="server" Text="Calculate Salary" OnClick="btnCalculate_Click" /></td>
                                </tr>
                            </table>--%>

                            <div class="container mt-5">
                                <h2 class="text-center">Employee Salary Calculator</h2>
                                <table class="table table-bordered">
                                    <tr>
                                        <td>Employee ID:</td>
                                        <td>
                                            <asp:TextBox ID="txtEmpID" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Employee Name:</td>
                                        <td>
                                            <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Basic Salary:</td>
                                        <td>
                                            <asp:TextBox ID="txtBasicSalary" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Dearness Allowance (DA):</td>
                                        <td>
                                            <asp:TextBox ID="txtDA" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>House Rent Allowance (HRA):</td>
                                        <td>
                                            <asp:TextBox ID="txtHRA" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnCalculate" runat="server" Text="Calculate Salary" OnClick="btnCalculate_Click" CssClass="btn btn-primary" />
                                        </td>
                                    </tr>
                                </table>
                            </div>

                            <br />
                            <%-- <h3>Calculated Salary:</h3>
                            <asp:ListView ID="lvSalaryDetails" runat="server">
                                <ItemTemplate>
                                    <table border="1">
                                        <tr>
                                            <th>Employee ID</th>
                                            <td><%# Eval("EmployeeID") %></td>
                                        </tr>
                                        <tr>
                                            <th>Employee Name</th>
                                            <td><%# Eval("EmployeeName") %></td>
                                        </tr>
                                        <tr>
                                            <th>Basic Salary</th>
                                            <td><%# Eval("BasicSalary") %></td>
                                        </tr>
                                        <tr>
                                            <th>Gross Salary</th>
                                            <td><%# Eval("GrossSalary") %></td>
                                        </tr>
                                        <tr>
                                            <th>Net Salary</th>
                                            <td><%# Eval("NetSalary") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:ListView>
                            <br />
                            <h4>OR</h4>--%>
                            <%--<h3>Calculated Salary:</h3>
                            <asp:GridView ID="gvSalaryDetails" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" />
                                    <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                                    <asp:BoundField DataField="BasicSalary" HeaderText="Basic Salary" />
                                    <asp:BoundField DataField="GrossSalary" HeaderText="Gross Salary" />
                                    <asp:BoundField DataField="NetSalary" HeaderText="Net Salary" />
                                </Columns>
                            </asp:GridView>--%>

                            <div class="container mt-5">
                                <h3>Calculated Salary:</h3>
                                <asp:GridView ID="gvSalaryDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                                    <Columns>
                                        <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" />
                                        <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                                        <asp:BoundField DataField="BasicSalary" HeaderText="Basic Salary" />
                                        <asp:BoundField DataField="GrossSalary" HeaderText="Gross Salary" />
                                        <asp:BoundField DataField="NetSalary" HeaderText="Net Salary" />
                                    </Columns>
                                </asp:GridView>
                            </div>

                            <!--end salary-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
