<%@ Page Title="Consultar Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarPedidos.aspx.cs" Inherits="Avaliacao.Net.WebApplication.ConsultarPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group campo">
        <label class="control-label campo-label">Cliente:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" id="nomeClienteTxt" runat="server">
        </div>
    </div>
    <div class="form-group campo">
        <label class="control-label campo-label">Data Inicial:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" id="dtInicialPedidoTxt" runat="server">
        </div>
    </div>
    <div class="form-group campo">
        <label class="control-label campo-label">Data Final:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" id="dtFinalPedidoTxt" runat="server">
        </div>
    </div>
    <div class="form-group" style="padding-top: 25px"> 
        <div class="campo-input">
          <button type="submit" class="btn btn-default" runat="server" onserverclick="Consultar_ServerClick">Consultar</button>
        </div>
    </div>

</asp:Content>
