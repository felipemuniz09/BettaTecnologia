<%@ Page Title="Detalhes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalhesPedidos.aspx.cs" Inherits="Avaliacao.Net.WebApplication.DetalhesPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group campo">
        <label class="control-label campo-label">Cliente:</label>
        <div class="campo-input"> 
            <input type="text" class="form-control" id="clientTxt" runat="server" readonly>
        </div>
    </div>
    <div class="form-group campo">
        <label class="control-label campo-label">Data:</label>
        <div class="campo-input"> 
            <input type="text" class="form-control" id="dataTxt" runat="server" readonly>
        </div>
    </div>
    <div class="form-group campo">
        <label class="control-label campo-label">Valor:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" id="valorTxt" runat="server">
        </div>
    </div>
    <div class="form-group campo">
        <label class="control-label campo-label">Descrição:</label>
        <div class="campo-input"> 
          <textarea rows="3" cols="50" class="form-control" id="descricaoTxt" runat="server"></textarea>
        </div>
    </div>
    <div class="btn-group col-md-offset-2" style="padding-top: 25px"> 
          <button type="submit" class="btn btn-default" runat="server" onserverclick="Salvar_ServerClick">Salvar</button>
          <button class="btn btn-default"  runat="server" onserverclick="Remover_ServerClick">Remover</button>
    </div>
    <div class="confirmacao" style="display:none" id="msgConfirmacao" runat="server">
          <div class="alert alert-success alert-dismissible" role="alert" >
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            Pedido removido com sucesso.
          </div>
      </div>
      <div class="confirmacao" style="display:none" id="msgConfirmacaoSalvar" runat="server">
          <div class="alert alert-success alert-dismissible" role="alert" >
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            Pedido atualizado com sucesso.
          </div>
      </div>
</asp:Content>
