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
using System.Globalization;

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
            dgvPedidos.Columns[3].DefaultCellStyle.Format = "C2";
            dgvPedidos.Columns[3].DefaultCellStyle.FormatProvider =
                new CultureInfo("pt-BR");

            dgvPedidos.Columns[4].DefaultCellStyle.Format = "C2";
            dgvPedidos.Columns[4].DefaultCellStyle.FormatProvider =
                new CultureInfo("pt-BR");

            lblTotal.Text = 0m.ToString(
                "C2",
                new CultureInfo("pt-BR"));
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

        // Método para Atualizar total do pedido
        private void AtualizarTotalPedido()
        {
            decimal totalPedido = 0;
            CultureInfo cultura = new CultureInfo("pt-BR");

            foreach(DataGridViewRow linha in dgvPedidos.Rows)
            {
                if (linha.IsNewRow)
                    continue;

                object valorCelula = linha.Cells[4].Value;

                if (valorCelula == null)
                    continue;

                if(valorCelula is decimal valorDecimal)
                {
                    totalPedido += valorDecimal;
                }
                else if (decimal.TryParse(
                        valorCelula.ToString(),
                        NumberStyles.Currency,
                        cultura,
                        out decimal valorItem
                        ))
                {
                    totalPedido += valorItem;
                }
            }

            lblTotal.Text = totalPedido.ToString("C2", cultura);
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
            if (cmbLanche.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um lanche.");
                return;
            }

            decimal precoUnitario = decimal.Parse(
                cmbPrecoL.Text,
                NumberStyles.Currency,
                new CultureInfo("pt-BR")
            );

            decimal quantidade = numQtdLanche.Value;
            decimal totalItem = precoUnitario * quantidade;

            dgvPedidos.Rows.Add(
                ++contItem,
                cmbLanche.SelectedItem,
                quantidade,
                precoUnitario,
                totalItem
            );
            AtualizarTotalPedido();


            if (rdbCondSim.Checked)
            {
                grpOpcoesCond.Enabled = true;

                foreach (CheckBox cb in grpOpcoesCond.Controls)
                {
                    if (cb.Checked)
                        dgvItens.Rows.Add("->", cb.Text, "", "", "");
                }

            }

            // DataGridView vai até ultima linha adicionada
            dgvPedidos.FirstDisplayedScrollingRowIndex =
                dgvPedidos.Rows.Count - 1;
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

        private void button5_Click(object sender, EventArgs e) // Botao Add Bebida
        {
            if (cmbBebidas.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma bebida.");
                return;
            }

            decimal precoUnitario = decimal.Parse(
                cmbPrecoB.Text,
                NumberStyles.Currency,
                new CultureInfo("pt-BR"));

            decimal quantidade = numQtdBebida.Value;
            decimal totalItem = precoUnitario * quantidade;

            dgvPedidos.Rows.Add(
                ++contItem,
                cmbBebidas.SelectedItem,
                quantidade,
                precoUnitario,
                totalItem
            );

            AtualizarTotalPedido();

            // DataGridView vai até ultima linha adicionada
            dgvPedidos.FirstDisplayedScrollingRowIndex =
                dgvPedidos.Rows.Count - 1;
        }

        private void btnRemoveLanche_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count == 0) // Verifica se tem linha selecionada
            {
                MessageBox.Show("Selecione um item para remover.");
                return;
            }
            
            DataGridViewRow linhaSelecionada = dgvPedidos.SelectedRows[0]; // Guarda a linha selecionada
            dgvPedidos.Rows.Remove(linhaSelecionada);
            AtualizarTotalPedido();
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
            dgvPedidos.Rows.Remove(linhaSelecionada);
            AtualizarTotalPedido();
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

