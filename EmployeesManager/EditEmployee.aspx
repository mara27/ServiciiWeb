<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="EmployeesManager.EditEmployee" MasterPageFile="Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Edit employee</title>     
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <h2>Detalii angajat</h2>
    <asp:HiddenField runat="server" ID="hdnId"/>
    <table>
        <tr>
            <td>Prenume</td>
            <td>
                <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName" ErrorMessage="<%$Resources:Texts, reqName %>"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Nume</td>
            <td>
                <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
            </td>
            <td>
               <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName" ErrorMessage="<%$Resources:Texts, reqFirstName %>"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Salariu</td>
            <td>
                <asp:TextBox runat="server" ID="txtSalary"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtSalary" ValidationExpression="\d+(\.\d+)?" ErrorMessage="<%$Resources:Texts, validSalary %>"></asp:RegularExpressionValidator>
                <asp:RangeValidator runat="server" ID="valSalaryRange" ControlToValidate="txtSalary" MinimumValue="0" MaximumValue="10000" ErrorMessage="<%$Resources:Texts, validSalaryRange %>" ></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>Manager</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlManagers" DataTextField="FullName" DataValueField="Id" AppendDataBoundItems="true">
                    <asp:ListItem Text="Fara Manager" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
    </table>
    <asp:Button runat="server" ID="btnSave" Text="Salveaza" OnClick="btnSave_OnClick" />
    <asp:Button runat="server" PostBackUrl="~/EmployeesList.aspx" Text="Renunta" CausesValidation="False"/>
</asp:Content>
