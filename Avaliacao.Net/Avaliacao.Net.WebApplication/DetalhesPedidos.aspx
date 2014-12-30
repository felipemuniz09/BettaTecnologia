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
          <asp:Button type="submit" class="btn btn-default" runat="server" OnClientClick="return ValidarEdicaoPedido();" onClick="Salvar_ServerClick" Text="Salvar"></asp:Button>
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
    <script type="text/javascript">
        function ValidarEdicaoPedido()
        {
            // O script de validação precisa ficar aqui para ser possível encontrar os elementos usando getElementById("nomeTxt.ClientID") 
            // Como essa página é uma content page é necessário fazer isso para conseguir encontrar os elementos, pois o ID da content page 
            // é concatenado ao ID de cada elemento com runat=server 
            // Se colocar a função em um arquivo .js não funciona

            // Valor

            var valor = document.getElementById("<%=valorTxt.ClientID%>").value;

            if (valor == '' || valor == null) {
                window.alert("Preencha o campo Valor");
                return false;
            }

            var padrao = /^\d+(?:\,\d{0,2})$/;

            if (!(valor.match(padrao))) {
                window.alert("Preencha o valor no formato 99999,99");
                return false;
            }

            // Descrição

            var descricao = document.getElementById("<%=descricaoTxt.ClientID%>").value;

            if (descricao == '' || descricao == null) {
                window.alert("Preencha o campo Descricao");
                return false;
            }

            return true;
        }
    </script>
</asp:Content>
