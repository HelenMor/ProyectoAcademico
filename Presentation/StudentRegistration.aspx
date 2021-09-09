<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="Presentation.StudentRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>

    <link href="Libraries/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Libraries/Fontawesome/css/all.min.css" rel="stylesheet" />

    <form id="form1" runat="server">

        <div class="col-md-8 col-lg-8 col-md-offset-2 col-lg-offset-2">

            <div class="row">
                <br />
            </div>

            <div class="panel panel-default">
                <div class="panel-heading" ></div>
                <div class="panel-body">
                    <div class="row col-md-offset-1 col-lg-offset-1">
                        <div class="col-md-6 col-lg-6">
                            <asp:Label ID="lblStudentName" Text="Student Name" runat="server"></asp:Label>
                            <asp:TextBox ID="txtStudenteName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-3 col-lg-3">
                            <asp:Label ID="lblLastName1" Text="Last Name 1" runat="server"></asp:Label>
                            <asp:TextBox ID="txtLastName1" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-3 col-lg-3">
                            <asp:Label ID="LblLastName2" Text="Last Name 2" runat="server"></asp:Label>
                            <asp:TextBox ID="TxtLastName2" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                    </div>

                    <div class="row col-md-offset-1 col-lg-offset-1">

                        <div class="col-md-2 col-lg-2">
                            <asp:Label ID="LblAge" Text="Age" runat="server"></asp:Label>
                            <asp:TextBox ID="TxtAge" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-4 col-lg-4">
                            <asp:Label ID="LblIdentificationId" Text="Identification Id" runat="server"></asp:Label>
                            <asp:TextBox ID="TxtIdentificationId" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-2 col-lg-2">
                            <br />
                            <asp:Button ID="SaveStudent" Text="Save" runat="server" CssClass="form-control" BackColor="YellowGreen" ForeColor="Window" OnClick="SaveStudent_Click"  />
                        </div>

                        <div class="col-md-2 col-lg-2">
                            <br />
                            <asp:Button ID="CancelStudent" Text="Cancel" runat="server" CssClass="form-control" BackColor="Red" ForeColor="Window" />
                        </div>

                    </div>

                    <div class="row">
                        <br />
                    </div>

                    <div class="row col-md-offset-1 col-lg-offset-1">
                        <div class="col-md-10 col-lg-10">
                            <asp:GridView ID="gvStudents" AutoGenerateColumns="false" CssClass="table table-bordered" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Selection">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="BtSeleccionar" OnCommand="BtSeleccionar_Command" CssClass="btn btn-primary" CommandArgument='<% #Bind("Id") %>' runat="server"><i class="far fa-check-circle"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Student Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltName" Text="text" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Last Name 1">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltLastaName1" Text="text" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Last Name 2">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltLastaName2" Text="text" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Age">
                                        <ItemTemplate>
                                            <asp:Literal ID="LtAge" Text="text" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Identification Id">
                                        <ItemTemplate>
                                            <asp:Literal ID="IDentificationId" Text="text" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>

                </div>

                <div class="panel-footer"></div>

            </div>

        </div>
    </form>
    <script src="Libraries/JQuery.js"></script>
    <script src="Libraries/Bootstrap/js/bootstrap.min.js"></script>
    <script src="Libraries/Fontawesome/js/all.min.js"></script>

</body>

</html>
