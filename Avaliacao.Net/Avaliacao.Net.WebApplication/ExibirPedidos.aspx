<%@ Page Title="Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExibirPedidos.aspx.cs" Inherits="Avaliacao.Net.WebApplication.ExibirPedidos" %>
<%@ PreviousPageType VirtualPath="~/ConsultarPedidos.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding-top: 20px; padding-bottom:20px">
        <table class="table table-hover" runat="server" id="pedidosTb">
            <thead>
                <tr><th>ID</th><th>Cliente</th><th>Data</th><th>Descrição</th><th>Valor</th><th></th></tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

</asp:Content>
