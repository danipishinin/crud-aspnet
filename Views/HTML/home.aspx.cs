using Cadastro_Pets.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cadastro_Pets.Views.HTML
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //chama apenas na primeira carga da pagina
            if (!Page.IsPostBack)
            {
                obterCachorro();
            }
        }
        //------------------------------------
        // BOTÕES DO CADASTRO 
        //------------------------------------
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Dog o_cachorro = new Dog();

                if (txtNome.Text.ToString().Trim() == "" || textPeso.Text.ToString().Trim() == "" || textRaca.Text.ToString().Trim() == "" || textCpfResponsavel.Text.ToString().Trim() == "" || textNomeResponsavel.Text.ToString().Trim() == "")
                {
                    lblMsgErro.Text = "Por favor, preencha os campos obrigatórios";
                    txtNome.Focus();
                    textPeso.Focus();
                    textRaca.Focus();
                    textCpfResponsavel.Focus();
                    textNomeResponsavel.Focus();
                    return;
                }

                decimal peso = 0;
                peso = decimal.Parse(textPeso.Text.ToString());

                int idade = 0;
                idade = int.Parse(textIdade.Text.ToString());

                int cpfResponsavel = 0;
                cpfResponsavel = int.Parse(textCpfResponsavel.Text.ToString());

                o_cachorro.Nome = txtNome.Text;
                o_cachorro.Idade = idade;
                o_cachorro.Peso = peso;
                o_cachorro.Raca = textRaca.Text;
                o_cachorro.Cpfresponsavel = cpfResponsavel;
                o_cachorro.NomeResponsavel = textNomeResponsavel.Text;

                o_cachorro.inserir();
                lblMsgErro.Text = "Inserção efetuada com sucesso!";
                lblMsgErro.ForeColor = System.Drawing.Color.Blue;
                obterCachorro();
                limparCampos();
            }
            catch (Exception err)
            {
                lblMsgErro.Text = "Erro: " + err.Message;
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int idCachorro;
                idCachorro = int.Parse(txtIDCachorro.Text.ToString());

                Dog o_cachorro = new Dog();
                o_cachorro.Idcachorro = idCachorro;

                o_cachorro.excluir();

                obterCachorro();
                limparCampos();
            }
            catch (Exception err)
            {
                lblMsgErro.Text = "Erro: " + err.Message;
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNome.Text.ToString().Trim() == "" || textPeso.Text.ToString().Trim() == "" || textRaca.Text.ToString().Trim() == "" || textCpfResponsavel.Text.ToString().Trim() == "" || textNomeResponsavel.Text.ToString().Trim() == "")
                {
                    lblMsgErro.Text = "Por favor, preencha os campos obrigatórios";
                    txtNome.Focus();
                    textPeso.Focus();
                    textRaca.Focus();
                    textCpfResponsavel.Focus();
                    textNomeResponsavel.Focus();
                    return;
                }

                decimal peso = 0;
                peso = decimal.Parse(textPeso.Text.ToString());

                int idade = 0;
                idade = int.Parse(textIdade.Text.ToString());

                int idCachorro;
                idCachorro = int.Parse(txtIDCachorro.Text.ToString());

                int cpfResponsavel = 0;
                cpfResponsavel = int.Parse(textCpfResponsavel.Text.ToString());

                Dog o_cachorro = new Dog();
                o_cachorro.Idcachorro = idCachorro;
                o_cachorro.Nome = txtNome.Text;
                o_cachorro.Idade = idade;
                o_cachorro.Peso = peso;
                o_cachorro.Raca = textRaca.Text;
                o_cachorro.Cpfresponsavel = cpfResponsavel;
                o_cachorro.NomeResponsavel = textNomeResponsavel.Text;
                o_cachorro.atualizar();

                obterCachorro();

            }
            catch (Exception err)
            {
                lblMsgErro.Text = "Erro: " + err.Message;
            }
        }

        //------------------------------------------
        // BOTÕES E CAMPOS GRID VIEW
        //------------------------------------------
        protected void gvCachorro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gv_cachorro(object sender, GridViewRowEventArgs e)
        {
            try
            {

            }
            catch (Exception err)
            {
                lblMsgErro.Text = "Erro: " + err.Message;
            }
        }



        private void obterCachorro()
        {
            try
            {
                Dog o_cachorro = new Dog();
                DataTable dtCachorro;

                dtCachorro = o_cachorro.selecionar();
                gvCachorro.DataSource = dtCachorro;
                gvCachorro.DataBind();
            }
            catch (Exception err)
            {
                lblMsgErro.Text = "Erro: " + err.Message;
            }
        }
        protected void limparCampos()
        {
            txtIDCachorro.Text = "";
            txtNome.Text = "";
            textIdade.Text = "";
            textPeso.Text = "";
            textRaca.Text = "";
            textCpfResponsavel.Text = "";
            textNomeResponsavel.Text = "";
            lblMsgErro.Text = "";


        }

        protected void ImgEditar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int idcachorro = Convert.ToInt32((sender as ImageButton).CommandArgument);
                
                Dog o_cachorro = new Dog();
                o_cachorro.Idcachorro = idcachorro;

                DataTable dtCachorro;
                dtCachorro = o_cachorro.obterPorIdCachorro();

                txtIDCachorro.Text = dtCachorro.Rows[0]["idcachorro"].ToString();
                txtNome.Text = dtCachorro.Rows[0]["nome"].ToString();
                textIdade.Text = dtCachorro.Rows[0]["idade"].ToString();
                textPeso.Text = dtCachorro.Rows[0]["peso"].ToString();
                textRaca.Text = dtCachorro.Rows[0]["raca"].ToString();
                textCpfResponsavel.Text = dtCachorro.Rows[0]["cpfresponsavel"].ToString();
                textNomeResponsavel.Text = dtCachorro.Rows[0]["nomeResponsavel"].ToString();

                lblMsgErro.Text = "";
            }
            catch (Exception err)
            {
                lblMsgErro.Text = "Erro: " + err.Message;
            }
        }

        protected void ImgExcluir_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int idCachorro;
                idCachorro = int.Parse(txtIDCachorro.Text.ToString());

                Dog o_cachorro = new Dog();
                o_cachorro.Idcachorro = idCachorro;

                o_cachorro.excluir();

                obterCachorro();
                limparCampos();
            }
            catch (Exception err)
            {
                lblMsgErro.Text = "Erro: " + err.Message;
            }
        }
    }
}