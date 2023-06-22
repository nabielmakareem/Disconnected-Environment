using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disconnected_Environment
{
    public partial class FormDataProdi : Form
    {
        private string stringConnection = "Data Source=LAPTOP-G2F55ONU\\EHZANDHERRY;" + "database=Act6;User ID=sa;Password=Conex999";
        private SqlConnection koneksi;


        public FormDataProdi()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void refreshform()
        {
            nmp.Text = "";
            ip.Text = "";
            ip.Enabled = true;
            nmp.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void dataGridView()
        {
            koneksi.Open();
            string str = "select id_prodi, nama_prodi From dbo.prodi";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet("prodi");
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void npm_Click(object sender, EventArgs e)
        {
            nmp.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nmProdi = nmp.Text;

            if (nmProdi == "")
            {
                MessageBox.Show("Masukkan Nama Prodi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dboProdi (nama_prodi)" + "values(@id)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("id", nmProdi));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();
            }

        }
        private void FormD()
        {
            FormDataProdi hu = new FormDataProdi();
            hu.Show();
            this.Hide();
        }

        private void FormDataProdi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'act6DataSet.prodi' table. You can move, or remove it, as needed.
            this.prodiTableAdapter.Fill(this.act6DataSet.prodi);

        }

        private void btnOpen_Click_1(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {


            nmp.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string nmProdi = nmp.Text;
            string iProdi = ip.Text;



            if (nmProdi == "")
            {
                MessageBox.Show("Masukkan Nama Prodi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                koneksi.Open();
                string insertQuery = "INSERT INTO dbo.prodi (nama_prodi) VALUES (@nama_prodi);";
                SqlCommand insertCommand = new SqlCommand(insertQuery, koneksi);
                insertCommand.CommandType = CommandType.Text;
                insertCommand.Parameters.Add(new SqlParameter("id_prodi", iProdi));


                string str = "insert into dbo.Prodi (nama_prodi)" + "values(@id)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("nama_prodi", nmProdi));


                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            refreshform();
        }

        private void AddIdProdi_Click(object sender, EventArgs e)
        {
            ip.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
        }
    }
}
