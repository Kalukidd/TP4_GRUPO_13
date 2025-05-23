﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4_Grupo_13.Ejercicio2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
<style type="text/css">
    .auto-style1 { width: 100%; }
    .auto-style3 { width: 268px; }
    .auto-style5 { width: 30px; }
    .auto-style6 { width: 35px; }
    .auto-style10 { width: 125px; }
    .auto-style11 { width: 153px; }
    .auto-style12 { margin-left: 294px; }
    .auto-style13 { width: 445px; }
    .auto-style15 { margin-left: 0px; }
    .auto-style16 { width: 127px; }
    .auto-style17 { width: 35px; height: 26px; }
    .auto-style18 { width: 125px; height: 26px; }
    .auto-style19 { width: 30px; height: 26px; }
    .auto-style20 { width: 127px; height: 26px; }
    .auto-style21 { width: 268px; height: 26px; }
    .auto-style22 { height: 26px; }
    .validator {
        color: red;
        font-size: small;
        display: block;
    }
    .auto-style23 {
        width: 35px;
        height: 29px;
    }
    .auto-style24 {
        width: 125px;
        height: 29px;
    }
    .auto-style25 {
        width: 30px;
        height: 29px;
    }
    .auto-style26 {
        width: 127px;
        height: 29px;
    }
    .auto-style27 {
        width: 268px;
        height: 29px;
    }
    .auto-style28 {
        height: 29px;
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
                    <td class="auto-style23"></td>
                    <td class="auto-style24">Id Producto:</td>
                    <td class="auto-style25"></td>
                    <td class="auto-style26">
                        <asp:DropDownList ID="ddlIdProducto" runat="server">
                            <asp:ListItem Value="1">Igual a:</asp:ListItem>
                            <asp:ListItem Value="2">Mayor a:</asp:ListItem>
                            <asp:ListItem Value="3">Menor a:</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style27">
                        <asp:TextBox ID="txtProducto" runat="server" Width="245px"></asp:TextBox>
                    </td>
                    <td class="auto-style28">
                        <asp:RegularExpressionValidator ID="revProducto" runat="server" ControlToValidate="txtProducto" CssClass="validator" Display="Dynamic" ErrorMessage="* Solo números enteros positivos, sin espacios ni letras" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="txtProducto" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Debe ingresar al menos un número</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17"></td>
                    <td class="auto-style18">Id Categoria:</td>
                    <td class="auto-style19"></td>
                    <td class="auto-style20">
                        <asp:DropDownList ID="ddlIdCategoria" runat="server">
                            <asp:ListItem Value="1">Igual a:</asp:ListItem>
                            <asp:ListItem Value="2">Mayor a:</asp:ListItem>
                            <asp:ListItem Value="3">Menor a:</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style21">
                        <asp:TextBox ID="txtCategoria" runat="server" Width="243px"></asp:TextBox>
                    </td>
                    <td class="auto-style22">
                        <asp:RegularExpressionValidator ID="revCategoria" runat="server" ControlToValidate="txtCategoria" CssClass="validator" Display="Dynamic" ErrorMessage="* Solo números enteros positivos, sin espacios ni letras" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="txtCategoria" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Debe ingresar al menos un número</asp:RequiredFieldValidator>
                    </td>
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
                        <asp:Button ID="btnFiltrar" runat="server"
                            CssClass="auto-style12"
                            Text="Filtrar"
                            Width="112px"
                            OnClick="btnFiltrar_Click"
                            CausesValidation="true" />
                    </td>
                    <td>
                        <asp:Button ID="btnQuitarFiltro" runat="server"
                            Text="Quitar Filtro"
                            Width="112px"
                            OnClick="btnQuitarFiltro_Click"
                            CausesValidation="false" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            <br /><br /><br />

            <table class="auto-style1">
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td>
                        <asp:GridView ID="gvProductos" runat="server" CssClass="auto-style15">
                        </asp:GridView>
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
