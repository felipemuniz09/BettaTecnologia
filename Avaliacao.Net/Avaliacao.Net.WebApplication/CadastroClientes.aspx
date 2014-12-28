<%@ Page Title="Cadastrar Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroClientes.aspx.cs" Inherits="Avaliacao.Net.WebApplication.CadastroClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <div class="form-group campo">
        <label class="control-label campo-label">Nome:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" id="nomeCliente">
        </div>
      </div>
      <div class="form-group campo">
        <label class="control-label campo-label">Email:</label>
        <div class="campo-input"> 
          <input type="email" class="form-control" id="emailCliente">
        </div>
      </div>
      <div class="form-group campo">
        <label class="control-label campo-label">Telefone:</label>
        <div class="campo-input"> 
          <input type="tel" class="form-control" id="telefoneCliente">
        </div>
      </div>
      <div class="form-group campo">
        <label class="control-label campo-label">Tipo de Cliente:</label>
        <div class="campo-input">
            <label class="radio-inline">
              <input type="radio" name="optradio">Pessoa Física
            </label>
            <label class="radio-inline">
              <input type="radio" name="optradio">Pessoa Jurídica
            </label>
        </div>
      </div>
      <div class="form-group" style="padding-top: 25px"> 
        <div class="campo-input">
          <button type="submit" class="btn btn-default">Cadastrar</button>
        </div>
      </div>
</asp:Content>
