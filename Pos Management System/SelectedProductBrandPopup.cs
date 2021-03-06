﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos_Management_System
{
    public partial class SelectedProductBrandPopup : Form
    {
        private ManageProductForm manageProductForm;
        private string _FromForm;
        public SelectedProductBrandPopup()
        {
            InitializeComponent();
        }

        public SelectedProductBrandPopup(ManageProductForm manageProductForm)
        {
            InitializeComponent();
            _FromForm = "ManageProductForm";
            this.manageProductForm = manageProductForm;
        }

        private void SelectedProductBrandPopup_Load(object sender, EventArgs e)
        {
            foreach (var item in Singleton.SingletonProductBrand.Instance().ProductBrands.Where(w => w.Enable == true).ToList())
            {
                dataGridView1.Rows.Add(item.Id, item.Code, item.Name, item.Description);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendDataChoose();
        }
        private void SendDataChoose()
        {
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            var data = Singleton.SingletonProductBrand.Instance().ProductBrands.SingleOrDefault(w => w.Id == id);
            switch (_FromForm)
            {
                case "ManageProductForm":
                    this.manageProductForm.BinddingProBrandChoose(data);
                    break;

            }
            this.Dispose();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SendDataChoose();
        }

        private void textBoxSearchKey_KeyUp(object sender, KeyEventArgs e)
        {
            string key = textBoxSearchKey.Text.Trim();
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    if (radioButtonCode.Checked == true)
                    {
                        foreach (var item in Singleton.SingletonProductBrand.Instance().ProductBrands.Where(w => w.Enable == true && w.Code.Contains(key)).ToList())
                        {
                            dataGridView1.Rows.Add(item.Id, item.Code, item.Name, item.Description);
                        }
                    }
                    else
                    {
                        foreach (var item in Singleton.SingletonProductBrand.Instance().ProductBrands.Where(w => w.Enable == true && w.Name.Contains(key)).ToList())
                        {
                            dataGridView1.Rows.Add(item.Id, item.Code, item.Name, item.Description);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
