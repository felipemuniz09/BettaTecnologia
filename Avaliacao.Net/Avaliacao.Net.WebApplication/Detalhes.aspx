<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalhes.aspx.cs" Inherits="Avaliacao.Net.WebApplication.Detalhes" %>
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
      <div class="btn-group" style="padding-top: 25px"> 
          <button type="submit" class="btn btn-default" runat="server" onserverclick="Salvar_ServerClick">Salvar</button>
          <button type="submit" class="btn btn-default" runat="server" onserverclick="Remover_ServerClick">Remover</button>
      </div>
      <div class="confirmacao" style="display:none" id="msgConfirmacao" runat="server">
          <div class="alert alert-success alert-dismissible" role="alert" >
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            Cliente removido com sucesso.
          </div>
      </div>
      <div class="confirmacao" style="display:none" id="msgConfirmacaoSalvar" runat="server">
          <div class="alert alert-success alert-dismissible" role="alert" >
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            Cliente atualizado com sucesso.
          </div>
      </div>
    </div>
</asp:Content>
