<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TP4_Grupo_13.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 400px">
            <asp:Label ID="lbl_inicio_tp" runat="server" Font-Bold="True" Font-Italic="False" Text="Inicio Trabajo Practico 4"></asp:Label>
        </div>
        <br />
        <asp:Button ID="btn_ejercicio1" runat="server" OnClick="btn_ejercicio1_Click" style="margin-left: 168px" Text="Ejercicio 1" Width="120px" />
        <asp:Button ID="btn_ejercicio2" runat="server" OnClick="btn_ejercicio2_Click" style="margin-left: 211px" Text="Ejercicio 2" Width="120px" />
        <asp:Button ID="btn_ejercicio3" runat="server" OnClick="btn_ejercicio3_Click" style="margin-left: 210px" Text="Ejercicio 3" Width="120px" />
    </form>
</body>
</html>
