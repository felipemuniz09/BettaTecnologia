<%@ Page Title="Consultar Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarClientes.aspx.cs" Inherits="Avaliacao.Net.WebApplication.ConsultarClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group campo">
        <label class="control-label campo-label">Nome:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" id="nomeCliente" runat="server">
        </div>
    </div>
    <div class="form-group campo">
        <label class="control-label campo-label">Tipo de Cliente:</label>
        <div class="campo-input"> 
          <select class="form-control" id="tpClienteSel"  runat="server">
            <option value="2">Indiferente</option>
            <option value="0">Pessoa Física</option>
            <option value="1">Pessoa Jurídica</option>
          </select>
        </div>
    </div>
    <div class="form-group" style="padding-top: 25px"> 
        <div class="campo-input">
          <button type="submit" class="btn btn-default" runat="server" onserverclick="Consultar_ServerClick">Consultar</button>
        </div>
    </div>

</asp:Content>
