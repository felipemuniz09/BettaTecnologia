<%@ Page Title="Consultar Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarClientes.aspx.cs" Inherits="Avaliacao.Net.WebApplication.ConsultarClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group campo">
        <label class="control-label campo-label">Nome:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" id="nomeCliente">
        </div>
    </div>
    <div class="form-group campo">
        <label class="control-label campo-label">Tipo de Cliente:</label>
        <div class="campo-input"> 
          <select class="form-control" id="sel1">
            <option>Indiferente</option>
            <option>Pessoa Física</option>
            <option>Pessoa Jurídica</option>
          </select>
        </div>
    </div>
    <div class="form-group" style="padding-top: 25px"> 
        <div class="campo-input">
          <button type="submit" class="btn btn-default">Consultar</button>
        </div>
      </div>

</asp:Content>
