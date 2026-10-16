using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace LanchoneteSabida
{
    public partial class Form1 : Form
    {
        int contItem = 0;
        string caminhoArquivoXml = @"pedido.xml";
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Botao Novo Pedido
        {
            tabControl_Detalhes.Enabled = true;

            if (lblNumPed.Text == "?")
            {
                lblNumPed.Text = "1";
            }
            else
            {
                lblNumPed.Text = (int.Parse(lblNumPed.Text) + 1).ToString();
            }


            lblNumPedItens.Text = lblNumPed.Text;
            dtpDataPed.Value = DateTime.Now;
            btnCancelar.Enabled = true;
            btnFazerPedido.Enabled = true;
            txtCliente.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnCamcelar_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            grpOpcoesCond.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }


        private void button5_Click(object sender, EventArgs e) // Botao Add Bebida
        {
            dgvPedidos.Rows.Add(++contItem, cmbBebidas.SelectedItem,
                numQtdBebida.Text,
                cmbPrecoB.SelectedItem,
                lblTotalB.Text.Substring(2)
            );
            lblTotal.Text =
                (double.Parse(lblTotal.Text.Substring(3)) +
                double.Parse(lblTotalB.Text.Substring(2))).ToString("C");
            dgvPedidos.FirstDisplayedScrollingRowIndex = dgvPedidos.Rows.Count - 1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnFazerPedido_Click(object sender, EventArgs e)
        {
            contItem = 0;
            dgvItens.Rows.Clear();
            tabControl_Detalhes.SelectedTab = tpItens;
        }

        private void cmbLanche_SelectedIndexChanged(object sender, EventArgs e)
        {
            numQtdLanche.Enabled = true;
            btnAddLanche.Enabled = true;

            cmbPrecoL.SelectedIndex = cmbLanche.SelectedIndex;
            numQtdLanche.Text = "1";

            if (cmbPrecoL.Text != "")
            {
                decimal preco = decimal.Parse(cmbPrecoL.Text.Substring(2));
                decimal quantidade = numQtdLanche.Value;

                lblTotalL.Text = (preco * quantidade).ToString("C");

                numQtdLanche.Focus();
            }
        }

        private void numQtdLanche_ValueChanged(object sender, EventArgs e)
        {
            if (cmbPrecoL.Text != "")
            {
                decimal preco = decimal.Parse(cmbPrecoL.Text.Substring(2));
                decimal quantidade = numQtdLanche.Value;

                lblTotalL.Text = (preco * quantidade).ToString("C");
                numQtdLanche.Focus();
            }
        }

        private void btnAddLanche_Click(object sender, EventArgs e)
        {
            dgvPedidos.Rows.Add(++contItem,
                cmbLanche.SelectedItem,
                numQtdLanche.Text,
                cmbPrecoL.SelectedItem,
                lblTotalL.Text.Substring(2)
            );
            lblTotal.Text =
                (double.Parse(lblTotal.Text.Substring(3)) +
                double.Parse(lblTotalL.Text.Substring(2))).ToString("C");
            dgvPedidos.FirstDisplayedScrollingRowIndex = dgvPedidos.Rows.Count - 1;

            if (rdbCondSim.Checked)
            {
                grpOpcoesCond.Enabled = true;
                // dgvItens.Rows.Add("", "Condimentos", "", "", "");
                // string condimentos = "";

                foreach (CheckBox cb in grpOpcoesCond.Controls)
                {
                    if (cb.Checked)
                        dgvItens.Rows.Add("->", cb.Text, "", "", "");
                    // condimentos += cb.Text + " | ";
                }

            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numQtdBebida_ValueChanged(object sender, EventArgs e)
        {
            if (cmbPrecoB.Text != "")
            {
                decimal preco = decimal.Parse(cmbPrecoB.Text.Substring(2));
                decimal quantidade = numQtdBebida.Value;

                lblTotalB.Text = (preco * quantidade).ToString("C");
                numQtdLanche.Focus();
            }
        }

        private void cmbBebidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            numQtdBebida.Enabled = true;
            button5.Enabled = true;

            cmbPrecoB.SelectedIndex = cmbBebidas.SelectedIndex;
            numQtdBebida.Text = "1";

            if (cmbPrecoB.Text != "")
            {
                decimal preco = decimal.Parse(cmbPrecoB.Text.Substring(2));
                decimal quantidade = numQtdBebida.Value;

                lblTotalB.Text = (preco * quantidade).ToString("C");

                numQtdBebida.Focus();
            }
        }

        private void btnRemoveLanche_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count == 0) // Verifica se tem linha selecionada
            {
                MessageBox.Show("Selecione um item para remover.");
                return;
            }

            
            DataGridViewRow linhaSelecionada = dgvPedidos.SelectedRows[0]; // Guarda a linha selecionada
            double valor = double.Parse(linhaSelecionada.Cells[4].Value.ToString()); // Le o valor da linha
            // cells: colecao de linha

            // Remover a Linha
            dgvPedidos.Rows.Remove(linhaSelecionada);
            // Subtrai o valor do total
            lblTotal.Text = (double.Parse(lblTotal.Text.Substring(3)) - valor).ToString("C");
            contItem--;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void grpOpcoesCond_Enter(object sender, EventArgs e)
        {

        }

        private void rdbCondNao_CheckedChanged(object sender, EventArgs e)
        {
            grpOpcoesCond.Enabled = false;
        }

        private void btnRemoveBebida_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count == 0) // Verifica se tem linha selecionada
            {
                MessageBox.Show("Selecione um item para remover.");
                return;
            }


            DataGridViewRow linhaSelecionada = dgvPedidos.SelectedRows[0]; // Guarda a linha selecionada
            double valor = double.Parse(linhaSelecionada.Cells[4].Value.ToString()); // Le o valor da linha
            // cells: colecao de linha

            // Remover a Linha
            dgvPedidos.Rows.Remove(linhaSelecionada);
            // Subtrai o valor do total
            lblTotal.Text = (double.Parse(lblTotal.Text.Substring(3)) - valor).ToString("C");
            contItem--;
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            // Arquivo XML

            // Cria um novo arquivo XML
            using (XmlWriter writer = XmlWriter.Create(caminhoArquivoXml, new XmlWriterSettings { Indent = true }))
            {
                // Inicia o documento
                writer.WriteStartDocument();

                // Inicia elemento "Pedido"
                writer.WriteStartElement("Pedido");

                // Adiciona os dados do pedido
                writer.WriteElementString("NumeroPedido", lblNumPed.Text);
                writer.WriteElementString("Cliente", txtCliente.Text);
                writer.WriteElementString("DataPedido", dtpDataPed.Value.ToString("yyyy-MM--dd HH:mm:ss")); // Formato 24h
                writer.WriteElementString("TotalPedido", lblTotal.Text);
                writer.WriteElementString("Observacao", txtObs.Text);

                // Adiciona itens do pedido
                writer.WriteStartElement("Itens");
                foreach (DataGridViewRow row in dgvPedidos.Rows)
                {

                    if (!row.IsNewRow) // Ignora a linha nova que ta sendo editada
                    {
                        writer.WriteStartElement("Item");

                        writer.WriteElementString("NumeroItem", row.Cells["nItem"].Value?.ToString());
                        writer.WriteElementString("Descricao", row.Cells["cDescrição"].Value?.ToString());
                        writer.WriteElementString("PrecoUnitario", row.Cells["cValorUnit"].Value?.ToString());
                        writer.WriteElementString("Quantidade", row.Cells["cQtd"].Value?.ToString());
                        writer.WriteElementString("TotalItem", row.Cells["cTotItem"].Value?.ToString());

                        writer.WriteEndElement(); // Fecha o elemento "Item"
                    }

                }

                writer.WriteEndElement(); // Fecha o elemento "itens"

                writer.WriteEndElement(); // Fecha o elemento "Pedido"
                writer.WriteEndElement(); // Finaliza o documento XML
            }
            MessageBox.Show("Pedido gravado com sucesso em XML!");

        }

        private void btnTXT_Click(object sender, EventArgs e)
        {

        }

        private void btnXDOC_Click(object sender, EventArgs e)
        {
            //string caminhoArquivoXml = @"pedido.xml";

            //Cria o novo pedido  como um XElement
            XElement novoPedido = new XElement("Pedido",
                new XElement ("NumeroPedido", lblNumPed.Text),
                new XElement("Cliente", txtCliente.Text),
                new XElement("DataPedido", dtpDataPed.Value.ToString("yyyy-MM-dd HH;mm;ss")),
                new XElement("TotalPedido", lblTotal.Text),
                new XElement("Observacao", txtObs.Text),
                new XElement("Itens",
                    from DataGridViewRow row in dgvPedidos.Rows
                    where !row.IsNewRow
                    select new XElement("Item",
                        new XElement("NumeroItem", row.Cells["nItem"].Value?.ToString()),
                        new XElement("Descricao", row.Cells["cDescrição"].Value?.ToString()),
                        new XElement("PrecoUnitario", row.Cells["cValorUnit"].Value?.ToString()),
                        new XElement("Quantidade", row.Cells["cQtd"].Value?.ToString()),
                        new XElement("TotalItem", row.Cells["cTotItem"].Value?.ToString())
                    )
                  )
            );

            XDocument doc;

            // Se o arquivo já existe, carrega e adiciona o novo pedido
            if (File.Exists(caminhoArquivoXml))
            {
                doc = XDocument.Load(caminhoArquivoXml);
                doc.Root?.Add(novoPedido);
            }
            else
            {
                // Cria um novo documento com o pedido
                doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Pedidos", novoPedido)
                );
            }
            // Salva o documento
            doc.Save(caminhoArquivoXml);

            MessageBox.Show("Pedido gravado com sucesso em XML!");

        }

        private void tpResumo_Click(object sender, EventArgs e)
        {

        }
    }
    }

