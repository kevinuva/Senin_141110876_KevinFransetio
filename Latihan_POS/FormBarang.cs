﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pertemuan11_a
{
    public partial class FormBarang : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter customerDA;
        //DataSet ds;
        DataTable dt;

        public FormBarang()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string myConnectionString = "Server=localhost;Database=testing;Uid=root;Pwd=;";
            conn = new MySqlConnection(myConnectionString);
            conn.Open();
            //ds = new DataSet();
            dt = new DataTable();
            initializeDA();
            customerDA.SelectCommand.ExecuteScalar();
            //customerDA.Fill(ds, "barang");
            customerDA.Fill(dt);
            dgvDaftar.ReadOnly = true;
            dgvDaftar.AllowUserToAddRows = false;
            dgvDaftar.AllowUserToDeleteRows = false;
            dgvDaftar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            BindingSource bs = new BindingSource();
            //bs.DataSource = ds.Tables["barang"];
            bs.DataSource = dt;
            dgvDaftar.DataSource = bs;
            //dgvDaftar.DataSource = ds.Tables["barang"];
        }

        private void initializeDA() {
            customerDA = new MySqlDataAdapter();

            //select
            string customerSelectSql = String.Concat("Select * from barang");
            customerDA.SelectCommand = new MySqlCommand(customerSelectSql, conn);

            //insert
            string customerInsertSql = String.Concat("Insert into barang (nama, jumlah_awal, harga_hpp, harga_jual) values (@nama, @address, @zip_code, @phone_number, @email)");
            MySqlCommand customerInsertCommand = new MySqlCommand(customerInsertSql, conn);
            customerInsertCommand.Parameters.AddWithValue("@nama", txName.Text);
            customerInsertCommand.Parameters.AddWithValue("@address", txAddress.Text);
            customerInsertCommand.Parameters.AddWithValue("@zip_code", txZipCode.Text);
            customerInsertCommand.Parameters.AddWithValue("@phone_number", txPhoneNumber.Text);
            
            customerDA.InsertCommand = customerInsertCommand;

            //update
            string customerUpdateSql = String.Concat("Update barang set nama = @nama, address = @address, zip_code = @zip_code, phone_number = @phone_number, email = @email where id = @id");
            MySqlCommand customerUpdateCommand = new MySqlCommand(customerUpdateSql, conn);
            customerUpdateCommand.Parameters.AddWithValue("@kode", txId.Text);
            customerUpdateCommand.Parameters.AddWithValue("@nama", txName.Text);
            customerUpdateCommand.Parameters.AddWithValue("@address", txAddress.Text);
            customerUpdateCommand.Parameters.AddWithValue("@zip_code", txZipCode.Text);
            customerUpdateCommand.Parameters.AddWithValue("@phone_number", txPhoneNumber.Text);
            
            customerDA.UpdateCommand = customerUpdateCommand;

            //delete
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mysql = String.Concat("Insert Into barang(nama, jumlah_awal, harga_hpp, harga_jual) values('", txName.Text, "', '", txAddress.Text, "', '", txZipCode.Text, "','" , txPhoneNumber.Text, "')");
            customerDA.InsertCommand = new MySqlCommand(mysql, conn);
            string save = string.Concat(customerDA.InsertCommand.ExecuteNonQuery(), " Record berhasil di Simpan");
            MessageBox.Show(save, "Info Simpan");



            customerDA.SelectCommand.ExecuteScalar();
            dt.Clear();
            customerDA.Fill(dt);

            
        }

        private void deklarasiDA(TextBox txnama) {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mysql, pesan;
            DialogResult hsl;
            hsl = MessageBox.Show("Anda Yakin ?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (hsl == DialogResult.Yes)
            {
                mysql = String.Concat("Delete From barang Where kode = '", txId.Text, "'");
                MySqlCommand cmd = new MySqlCommand(mysql, conn);
                pesan = String.Concat(cmd.ExecuteNonQuery(), " Record berhasil di Hapus");
                MessageBox.Show(pesan, "Info Hapus");
            }

            customerDA.SelectCommand.ExecuteScalar();
            dt.Clear();
            customerDA.Fill(dt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mysql, pesan;
            DialogResult hsl;
            hsl = MessageBox.Show("Anda Yakin ?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (hsl == DialogResult.Yes)
            {
                mysql = String.Concat("DELETE FROM barang");
                MySqlCommand cmd = new MySqlCommand(mysql, conn);
                pesan = String.Concat(cmd.ExecuteNonQuery(), " Record berhasil di Reset");
                MessageBox.Show(pesan, "Info Hapus");
            }

            customerDA.SelectCommand.ExecuteScalar();
            dt.Clear();
            customerDA.Fill(dt);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormCustomer formcustomer = new FormCustomer();
            formcustomer.BringToFront();
            Close();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSupplier formsupplier = new FormSupplier();
            formsupplier.Show();
            Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dgvDaftar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void jualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJual formjual = new FormJual();
            formjual.Show();
            Close();
        }

        private void beliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBeli formbeli = new FormBeli();
            formbeli.Show();
            Close();
        }

        private void txZipCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
