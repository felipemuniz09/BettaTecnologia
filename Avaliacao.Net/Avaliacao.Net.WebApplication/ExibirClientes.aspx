<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExibirClientes.aspx.cs" Inherits="Avaliacao.Net.WebApplication.ExibirClientes" EnableEventValidation="false" %>
<%@ PreviousPageType VirtualPath="~/ConsultarClientes.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div style="padding-top: 20px; padding-bottom:20px">
        <table class="table table-hover" runat="server" id="clientesTb">
            <thead>
                <tr><th>ID</th><th>Nome</th><th>Email</th><th>Telefone</th><th>Tipo de Cliente</th><th></th></tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

</asp:Content>
