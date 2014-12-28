<%@ Page Title="Cadastrar Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarPedidos.aspx.cs" Inherits="Avaliacao.Net.WebApplication.CadastrarPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="form-group campo">
        <label class="control-label campo-label">Cliente:</label>
        <div class="campo-input"> 
          <select class="form-control" id="sel1">
          </select>
        </div>
    </div>
    <div class="form-group campo">
        <label class="control-label campo-label">Valor:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" id="valorPedido">
        </div>
    </div>
    <div class="form-group campo">
        <label class="control-label campo-label">Descrição:</label>
        <div class="campo-input"> 
          <textarea rows="3" cols="50" class="form-control"></textarea>
        </div>
    </div>
    <div class="form-group" style="padding-top: 80px"> 
        <div class="campo-input">
          <button type="submit" class="btn btn-default">Cadastrar</button>
        </div>
    </div>

</asp:Content>
