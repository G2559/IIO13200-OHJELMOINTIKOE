<%@ Page Language="C#" AutoEventWireup="true" CodeFile="G2559_T3B_muokkaus.aspx.cs" Inherits="G2559_T3B_muokkaus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>T3B</title>
    <link href="pilkut.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="otsikko" align="center">
        <h1>Puolipilkunviilaajat</h1>           
        <h3>Sisäänkirjautuminen</h3>
            </div>
        <div id="nelio">
                <div id="sisalto">
        <table>
        <tr>
            <td>id</td>
            <td><asp:TextBox ID="txtid" runat="server" Width="120px" ReadOnly="true"></asp:TextBox> </td>
            <td style="width:100px"></td><td></td>

            <td>koodaaja</td>
            <td><asp:TextBox ID="txtkoodaaja" runat="server" Width="120px" ></asp:TextBox> </td>
            <td style="width:100px"></td><td></td>
          </tr>
            <tr>
            <td>päivämäärä</td>
            <td><asp:TextBox ID="txtpvm" runat="server" Width="120px" ></asp:TextBox> </td>
            <td class="auto-style1"><asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtpvm" 
            SetFocusOnError="true" ValidationGroup="Save" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator></td>
                      
            

        </tr>
        <tr>
            <td>tunnit</td>
            <td><asp:TextBox ID="txttuntimaara" runat="server" Width="120px" ></asp:TextBox> </td>
            <td style="width:100px"><asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txttuntimaara" 
                SetFocusOnError="true" ValidationGroup="Save" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator></td>
            <td></td>
            
            <td>minuutit</td>
            <td><asp:TextBox ID="txtminuutit" runat="server" Width="120px" ></asp:TextBox> </td>
            <td class="auto-style1"><asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtminuutit" 
                SetFocusOnError="true" ValidationGroup="Save" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator></td>

           
        </tr>
        
        <tr>
            <td colspan="5" style="text-align:center">
                <asp:Button ID="btnSave" runat="server" Width="100px" Text="Save" onclick="btnSave_Click" ValidationGroup="Save" />
                <asp:Button ID="btnClear" runat="server" Width="100px" Text="Clear" CausesValidation="false" onclick="btnClear_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label runat="server" ID="lblMessage" Text="" ></asp:Label>
                <asp:HiddenField ID="hndId" runat="server" Value="" />
            </td>
        </tr>
    </table>
                    <asp:DropDownList ID="DropDownTyypit" runat="server" 
             AutoPostBack="True" OnSelectedIndexChanged="DropDownTyypit_SelectedIndexChanged"  >
            </asp:DropDownList>

                    </div>
            <asp:GridView ID="grdtunnit" runat="server"
        AllowPaging="True" AutoGenerateColumns="False" TabIndex="1"
        DataKeyNames="id" Width="100%" BackColor="White" GridLines="Vertical"
        CellPadding="3" BorderStyle="None" BorderWidth="1px" BorderColor="#999999"
        OnRowDataBound="grdViewTunti_RowDataBound"
        OnPageIndexChanging="grdViewTunti_PageIndexChanging"
        onselectedindexchanging="grdViewTunti_SelectedIndexChanging"
        onrowdeleting="grdViewTunti_RowDeleting">
        <Columns>
            <asp:CommandField ShowSelectButton="True" HeaderText="Select" ItemStyle-HorizontalAlign="Center" />
            <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="koodaaja" HeaderText="koodaaja" />
            <asp:BoundField DataField="paivamaara" HeaderText="paivamaara" />
            <asp:BoundField DataField="tuntimaara" HeaderText="tuntimaara" />
            <asp:BoundField DataField="minuutit" HeaderText="minuutit" />
        </Columns>
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="true" ForeColor="White" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#DCDCDC" />
    </asp:GridView>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
