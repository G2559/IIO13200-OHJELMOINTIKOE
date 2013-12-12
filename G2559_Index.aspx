<%@ Page Language="C#" AutoEventWireup="true" CodeFile="G2559_Index.aspx.cs" Inherits="G2559_Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Index</title>
    <link href="auto.css" rel="stylesheet" type="text/css" />
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
        <h1>iio13200 .NET-ohjelmointi Ohjelmointikoe 12.12.2013</h1>
        <h3>Jenni Kallanto G2559</h3>
            </div>
        <div id="nelio">
                <div id="sisalto">
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/G2559_T2.aspx">Koe tehtävä 2</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/G2559_T3B.aspx">Koe tehtävä 3B</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/G2559_Pisteet.aspx">Pisteet</asp:HyperLink><br />
                    </div>
            </div>

    </div>
    </form>
</body>
</html>
