<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Cadastro_Pets.Views.HTML.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="../CSS/home.css" rel="stylesheet" />
<title></title>
</head>
<body>
    <h1 class="tabTitulo">Cadastro de Pets</h1>
    <form id="form1" runat="server">
        <section>
            <!--- INPUTS CADASTRO DOS CACHORROS -->
            <div class="cadastro">
            <section class="forms_cadastro">
                <asp:Label   class="lbl_cadastro" ID="lbl_id_cachorro" runat="server" Text="Id" Width="100px"></asp:Label>
                <asp:TextBox class="input_cadastro" ID="txtIDCachorro" runat="server" ReadOnly="True" Width="66px"></asp:TextBox>

                <asp:Label class="lbl_cadastro" ID="lbl_nome_cachorro" runat="server" Text="Nome" Width="99px"></asp:Label>
                <asp:TextBox class="input_cadastro" ID="txtNome" Width="385px" runat="server"></asp:TextBox><br /><br />

                <asp:Label class="lbl_cadastro" ID="lbl_idade_cachorro" runat="server" Text="Idade" Width="99px" style="margin-left: 0px"></asp:Label>
                <asp:TextBox class="input_cadastro" ID="textIdade" Width="64px" runat="server"></asp:TextBox>

                <asp:Label class="lbl_cadastro" ID="lbl_peso_cachorro" runat="server" Text="Peso" Width="99px"></asp:Label>
                <asp:TextBox class="input_cadastro" ID="textPeso" Width="79px" runat="server"></asp:TextBox>

                <asp:Label class="lbl_cadastro" ID="lbl_raca_cachorro" runat="server" Text="Raça" Width="99px"></asp:Label>
                <asp:TextBox class="input_cadastro" ID="textRaca" Width="191px" runat="server"></asp:TextBox><br /><br />

                <asp:Label class="lbl_cadastro" ID="lbl_cpf_responsavel" runat="server" Text="CPF Responsável" Width="150px"></asp:Label>
                <asp:TextBox class="input_cadastro" ID="textCpfResponsavel" Width="495px" runat="server"></asp:TextBox><br /><br />

                <asp:Label class="lbl_cadastro" ID="lbl_nome_responsavel" runat="server" Text="Nome Responsável" Width="154px"></asp:Label>
                <asp:TextBox class="input_cadastro" ID="textNomeResponsavel" Width="486px" runat="server"></asp:TextBox><br /><br />
            </section>
            </div>
            <!--- AÇÕES CADASTRO DOS CACHORROS -->
            <div class="acoes_cadastro">
                <asp:Button ID="btnLimpar" runat="server" Text="LIMPAR"
                    OnClick="btnLimpar_Click" />
                &nbsp; &nbsp; 

                <asp:Button ID="btnInserir" runat="server" Text="INSERIR"
                    OnClick="btnInserir_Click" Width="91px" />
                &nbsp; &nbsp;                
                
                <asp:Button ID="btnAlterar" runat="server" Text="ATUALIZAR" OnClick="btnAlterar_Click" />
                &nbsp; &nbsp; 
               <%-- 
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir"
                    Enabled="False" OnClick="btnExcluir_Click" /> --%>               
            </div>
           
             <hr class="linhaSep"/>
       
            <div class="msgErro"> 
                  <asp:Label ID="lblMsgErro" runat="server"
                    ForeColor="Red"></asp:Label>
            </div>
            <!--- TABELA CADASTRO DOS CACHORROS -->
            <h2 class="tabTitulo">Pets Cadastrados</h2>
            <asp:GridView class="tabGeral" ID="gvCachorro" runat="server" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="gv_cachorro" OnSelectedIndexChanged="gvCachorro_SelectedIndexChanged" CellPadding="12">
                <Columns>
                    <asp:TemplateField  HeaderText="ID" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="colID" Text='<%# Eval("idcachorro") %>' runat="server" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gvHeader" />
                            <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nome" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="colNome" Text='<%# Eval("nome") %>' runat="server" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gvHeader" />
                            <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Idade" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="colIdade" Text='<%# Eval("idade") %>' runat="server" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gvHeader" />
                            <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Peso" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="colPeso" Text='<%# Eval("peso") %>' runat="server" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gvHeader" />
                            <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Raça" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="colRaca" Text='<%# Eval("raca") %>' runat="server" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gvHeader" />
                            <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CPF do Responsável" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="colCpfResponsavel" Text='<%# Eval("cpfresponsavel") %>' runat="server" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gvHeader" />
                            <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nome do Responsável" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="colNomeResponsavel" Text='<%# Eval("nomeresponsavel") %>' runat="server" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gvHeader" />
                            <ItemStyle CssClass="gvItemCentro" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Editar" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="../../Assets/Images/editar.png" runat="server" 
                                    OnClick="ImgEditar_Click" CommandArgument='<%# Eval("idcachorro")  %>' 
                                    ToolTip="Editar" Width="20px" Height="20px" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gvHeader" />
                            <ItemStyle CssClass="gvItemCentro" />
                     </asp:TemplateField>

                    <asp:TemplateField HeaderText="Editar" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="../../Assets/Images/lixo.png" runat="server" 
                                    OnClick="ImgExcluir_Click" CommandArgument='<%# Eval("idcachorro")  %>' 
                                    ToolTip="Editar" Width="20px" Height="20px" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gvHeader" />
                            <ItemStyle CssClass="gvItemCentro" />
                     </asp:TemplateField>
                </Columns>
                <HeaderStyle ForeColor="White" />
            </asp:GridView>
        </section>
    </form>
</body>
</html>
