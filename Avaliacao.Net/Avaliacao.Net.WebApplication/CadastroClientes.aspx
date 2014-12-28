<%@ Page Title="Cadastrar Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroClientes.aspx.cs" Inherits="Avaliacao.Net.WebApplication.CadastroClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
      <div class="form-group campo">
        <label class="control-label campo-label">Nome:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" id="nomeTxt" runat="server">
        </div>
      </div>
      <div class="form-group campo">
        <label class="control-label campo-label">Email:</label>
        <div class="campo-input"> 
          <input type="email" class="form-control" id="emailTxt" runat="server">
        </div>
      </div>
      <div class="form-group campo">
        <label class="control-label campo-label">Telefone:</label>
        <div class="campo-input"> 
          <input type="tel" class="form-control" id="telefoneTxt" runat="server">
        </div>
      </div>
      <div class="form-group campo">
        <label class="control-label campo-label">Tipo de Cliente:</label>
        <div class="campo-input">
            <label class="radio-inline">
              <input type="radio" id="clientePFRadioBtn" name="tpPessoaRdBtn" runat="server" checked="true">Pessoa Física
            </label>
            <label class="radio-inline">
              <input type="radio" id="clientePJRadioBtn" name="tpPessoaRdBtn" runat="server">Pessoa Jurídica
            </label>
        </div>
      </div>
      <div class="form-group" style="padding-top: 25px"> 
        <div class="campo-input">
          <button type="submit" class="btn btn-default" runat="server" onserverclick="Cadastrar_ServerClick">Cadastrar</button>
        </div>
      </div>
      <div class="confirmacao" style="visibility:hidden" id="msgConfirmacao" runat="server">
          <div class="alert alert-success alert-dismissible" role="alert" >
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            Cliente cadastrado com sucesso.
          </div>
      </div>
    </div>
</asp:Content>
