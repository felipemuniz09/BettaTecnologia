<%@ Page Title="Cadastrar Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroClientes.aspx.cs" Inherits="Avaliacao.Net.WebApplication.CadastroClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
      <div class="form-group campo">
        <label class="control-label campo-label">Nome:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" name="nomeTxt" id="nomeTxt" runat="server">
        </div>
      </div>
      <div class="form-group campo">
        <label class="control-label campo-label">Email:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" id="emailTxt" runat="server">
        </div>
      </div>
      <div class="form-group campo">
        <label class="control-label campo-label">Telefone:</label>
        <div class="campo-input"> 
          <input type="text" class="form-control" id="telefoneTxt" runat="server" >
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
          <asp:Button class="btn btn-default" runat="server" ClientIDMode="Static" OnClientClick="return validarCadastroClientes();" OnClick="Cadastrar_ServerClick" Text="Cadastrar"></asp:Button>
        </div>
      </div>
      <div class="confirmacao" style="visibility:hidden" id="msgConfirmacao" runat="server">
          <div class="alert alert-success alert-dismissible" role="alert" >
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            Cliente cadastrado com sucesso.
          </div>
      </div>
    </div>

    <script type="text/javascript">
        function validarCadastroClientes() {
            
            // O script de validação precisa ficar aqui para ser possível encontrar os elementos usando getElementById("nomeTxt.ClientID") 
            // Como essa página é uma content page é necessário fazer isso para conseguir encontrar os elementos, pois o ID da content page 
            // é concatenado ao ID de cada elemento com runat=server 
            // Se colocar a função em um arquivo .js não funciona


            // Nome

            var nome = document.getElementById("<%=nomeTxt.ClientID%>").value;
            if (nome == '' || nome == null) {
                window.alert("Preencha o campo Nome");
                return false;
            }

            // Email

            var email = document.getElementById("<%=emailTxt.ClientID%>").value;

            if (email == '' || email == null) {
                window.alert("Preencha o campo Email");
                return false;
            }
            
            var atpos = email.indexOf("@");
            
            var dotpos = email.lastIndexOf(".");
           
            if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= email.length) {
                window.alert("Email inválido");
                return false;
            }
           
            // Telefone válido

            var telefone = document.getElementById("<%=telefoneTxt.ClientID%>").value;

            

            if (telefone == '' || telefone == null) {
                window.alert("Preencha o campo Telefone");
                return false;
            }

            var phoneno = /^\(?([0-9]{2})\)?[ ]?([0-9]{4})[-]?([0-9]{4})$/;

            if (!(telefone.match(phoneno))) {
                window.alert("Preencha o telefone no formato 99 9999-9999");
                return false;
            }
            
            return true;
        }
    </script>
</asp:Content>
