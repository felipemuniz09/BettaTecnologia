<%@ Page Title="Consultar Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarPedidos.aspx.cs" Inherits="Avaliacao.Net.WebApplication.ConsultarPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group campo">
        <label class="control-label campo-label">Cliente:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" id="nomeClienteTxt" runat="server"  maxlength="100">
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
          <asp:Button type="submit" class="btn btn-default" runat="server" OnClientClick="return validarConsultaPedidos();" OnClick="Consultar_ServerClick" Text="Consultar"></asp:Button>
        </div>
    </div>

    <script type="text/javascript">
        function validarConsultaPedidos() {

            // O script de validação precisa ficar aqui para ser possível encontrar os elementos usando getElementById("nomeTxt.ClientID") 
            // Como essa página é uma content page é necessário fazer isso para conseguir encontrar os elementos, pois o ID da content page 
            // é concatenado ao ID de cada elemento com runat=server 
            // Se colocar a função em um arquivo .js não funciona

            // Data Inicial

            var padrao = /^\d{1,2}\/\d{1,2}\/\d{4}$/;

            var dtInicial = document.getElementById("<%=dtInicialPedidoTxt.ClientID%>").value;
            
            if (dtInicial != '' && dtInicial != null) {
                
                if (!(dtInicial.match(padrao))) {
                    window.alert("Preencha a data inicial no formato dd/mm/aaaa");
                    return false;
                }
            }

            // Data Final

            var dtFinal = document.getElementById("<%=dtFinalPedidoTxt.ClientID%>").value;

            if (dtFinal != '' && dtFinal != null) {
                if (!(dtFinal.match(padrao))) {
                    window.alert("Preencha a data final no formato dd/mm/aaaa");
                    return false;
                }
            }

            return true;
        }
    </script>

</asp:Content>
