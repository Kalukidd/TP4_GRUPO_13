<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4_Grupo_13.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 268px;
        }
        .auto-style5 {
            width: 30px;
        }
        .auto-style6 {
            width: 35px;
        }
        .auto-style10 {
            width: 125px;
        }
        .auto-style11 {
            width: 153px;
        }
        .auto-style12 {
            margin-left: 294px;
        }
        .auto-style13 {
            width: 445px;
        }
        .auto-style15 {
            margin-left: 0px;
        }
        .auto-style16 {
            width: 127px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style10">Id Producto:</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style16">
                        <asp:DropDownList ID="ddlIdProducto" runat="server">
                            <asp:ListItem Value="0">Igual a:</asp:ListItem>
                            <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                            <asp:ListItem Value="2">Menor a:</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtProducto" runat="server" Width="245px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style10">Id Categoria:</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style16">
                        <asp:DropDownList ID="ddlIdCategoria" runat="server">
                            <asp:ListItem Value="0">Igual a:</asp:ListItem>
                            <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                            <asp:ListItem Value="2">Menor a:</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtCategoria" runat="server" Width="243px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
           
            <table class="auto-style1">
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style13">
                        <asp:Button ID="btnFiltrar" runat="server" CssClass="auto-style12" Text="Filtrar" Width="112px" OnClick="btnFiltrar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnQuitarFiltro" runat="server" Text="Quitar Filtro" Width="112px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
           
            <br />
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td>
                        <asp:GridView ID="gvProductos" runat="server" CssClass="auto-style15">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
