<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Exercise1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel runat="server" ID="pnlGroupControls">
                <asp:Label Text="This is a label that will change text" runat="server" ID="lblDemo" />
                <asp:TextBox runat="server" ID="txtNewLabelText" />
                <asp:Button Text="Change label text" runat="server" ID="btnChangeLabelText" OnClick="btnChangeLabelText_Click" />

                <asp:Button Text="Change page title" runat="server" ID="btnChangePageTitle" OnClick="btnChangePageTitle_Click" />
                <asp:DropDownList runat="server" ID="ddlDemo" AutoPostBack="true" OnSelectedIndexChanged="ddlDemo_SelectedIndexChanged">
                    <asp:ListItem Text="text1" Value="0" />
                    <asp:ListItem Text="text2" Value="1" />
                </asp:DropDownList>
            </asp:Panel>
            <asp:CheckBox Text="Toogle Controls Visibility" runat="server" Checked="true" AutoPostBack="true" ID="chbToogleControlsVisibility" OnCheckedChanged="chbToogleControlsVisibility_CheckedChanged"/>   
            <asp:HyperLink NavigateUrl="~/PageFlow.aspx" runat="server" ID="lnkToPageFlow" />
            <asp:Button Text="Redirect To PageFlow.aspx programatically" runat="server" ID="btnRedirectToPageFlow" OnClick="btnRedirectToPageFlow_Click" />
            <asp:LinkButton Text="Redirect To PageFlow.aspx programatically" runat="server" ID="lnkRedirectToPageFlow" OnClick="lnkRedirectToPageFlow_Click" />
        </div>
    </form>
</body>
</html>
