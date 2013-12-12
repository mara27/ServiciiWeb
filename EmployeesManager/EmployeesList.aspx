<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesList.aspx.cs" Inherits="EmployeesManager.EmployeesList" MasterPageFile="Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <title>Employees List</title>     
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <asp:GridView runat="server" ID="gvEmployees" AutoGenerateColumns="False" DataKeyNames="Id" OnRowEditing="OnEditClick" OnRowDeleting="OnDeleteClick" >
        <Columns>
            <asp:TemplateField HeaderText="Nume">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("FullName") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Salariu">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Salary") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Manager">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Manager.FullName") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" ShowEditButton="True" EditText="Editeaza" ShowDeleteButton="True" DeleteText="Sterge"/>
        </Columns>
    </asp:GridView>
    
    <asp:LinkButton runat="server" Text="Adauga un angajat nou" PostBackUrl="~/EditEmployee.aspx"></asp:LinkButton>

</asp:Content>

