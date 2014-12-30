<%@ Page Title="Cadastrar Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarPedidos.aspx.cs" Inherits="Avaliacao.Net.WebApplication.CadastrarPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="form-group campo">
        <label class="control-label campo-label">Cliente:</label>
        <div class="campo-input"> 
          <select class="form-control" id="clienteSel" runat="server">
          </select>
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
          <textarea rows="3" cols="50" class="form-control" id="descricaoTxt" runat="server" maxlength="300"></textarea>
        </div>
    </div>
    <div class="form-group" style="padding-top: 80px"> 
        <div class="campo-input">
          <asp:Button class="btn btn-default"  runat="server" OnClientClick="return ValidarCadastroPedido()" onClick="Cadastrar_ServerClick" Text="Cadastrar"></asp:Button>
        </div>
    </div>
    <div class="confirmacao" style="visibility:hidden" id="msgConfirmacao" runat="server">
          <div class="alert alert-success alert-dismissible" role="alert" >
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            Pedido cadastrado com sucesso.
          </div>
    </div>

    <script type="text/javascript">
        function ValidarCadastroPedido()
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
