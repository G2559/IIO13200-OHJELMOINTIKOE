<%@ Page Language="C#" AutoEventWireup="true" CodeFile="G2559_T3B.aspx.cs" Inherits="G2559_T3B" %>

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
        <tr><td>Käyttäjä: <asp:TextBox ID="txtHashkayttaja" runat="server" Width="120px" ></asp:TextBox> </td>
        <td> <asp:RequiredFieldValidator ID="rfvHashUser" ErrorMessage="Anna käyttäjä" ControlToValidate="txtHashkayttaja" runat="server" /></td>

        <td>Salasana: <asp:TextBox ID="txtHashsala" TextMode="Password" runat="server" Width="120px" ></asp:TextBox></td>
         <td> <asp:RequiredFieldValidator ID="rfvHashSala" ErrorMessage="Anna salasana" ControlToValidate="txtHashsala" runat="server" /></td>
        </tr>
        <tr>
        <td><asp:Button ID="btnHashkirjaudu" runat="server" Width="100px" Text="Kirjaudu" CausesValidation="false" OnClick="btnHashkirjaudu_Click" /></td>
    </tr>
    <tr>
        <td><asp:Label ID="lblHashkirjautuminen" runat="server"></asp:Label></td>
    </tr>

    </table>
                    </div>
    </div>
    </form>
</body>
</html>
