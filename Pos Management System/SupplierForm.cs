﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos_Management_System
{
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            dataGrid();
        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            int id = int.Parse(dataGridView1.Rows[row].Cells[colId].Value.ToString());
            _Id = id;
            string code = dataGridView1.Rows[row].Cells[colCode].Value.ToString();
            string name = dataGridView1.Rows[row].Cells[colName].Value.ToString();

            var supp = Singleton.SingletonPriority1.Instance().Supplier.SingleOrDefault(w => w.Id == id);
            if (supp.Enable)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            textBoxCode.Text = code;
            textBoxName.Text = name;
            textBoxAddress.Text = supp.Address;
            textBoxTel.Text = supp.Tel;
            textBoxDesc.Text = supp.Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        int colId = 0;
        int colCode = 1;
        int colName = 2;
        
        int _Id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            // add new 
            _Id = 0;
            textBoxCode.Text = "";
            textBoxName.Text = "";
            textBoxAddress.Text = "";
            textBoxTel.Text = "";
            textBoxDesc.Text = "";
            radioButton1.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SSLsEntities db = new SSLsEntities())
            {
                if (_Id == 0)
                {
                    // add new 
                    Supplier obj = new Supplier();
                    obj.Code = textBoxCode.Text;
                    obj.Name = textBoxName.Text;
                    obj.Address = textBoxAddress.Text;
                    obj.Tel = textBoxTel.Text;
                    obj.Description = textBoxDesc.Text;
                    obj.CreateDate = DateTime.Now;
                    obj.CreateBy = Singleton.SingletonAuthen.Instance().Id;
                    obj.Enable = true;
                    obj.UpdateBy = Singleton.SingletonAuthen.Instance().Id;
                    obj.UpdateDate = DateTime.Now;
                    db.Supplier.Add(obj);
                }
                else
                {
                    // edit
                    var obj = db.Supplier.SingleOrDefault(w => w.Id == _Id);
                    obj.UpdateDate = DateTime.Now;
                    obj.UpdateBy = Singleton.SingletonAuthen.Instance().Id;
                    obj.Code = textBoxCode.Text;
                    obj.Name = textBoxName.Text;
                    obj.Address = textBoxAddress.Text;
                    obj.Tel = textBoxTel.Text;
                    obj.Description = textBoxDesc.Text;
                    if (radioButton1.Checked)
                    {
                        obj.Enable = true;
                    }
                    else
                    {
                        obj.Enable = false;
                    }
                    db.Entry(obj).State = EntityState.Modified;
                }
                db.SaveChanges();
                Singleton.SingletonPriority1.SetInstance();
                //Singleton.SingletonPriority1.Instance();

                dataGrid();
                //this.Dispose();
                //_Id = 0;
            }
        }

        public void dataGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            var data = Singleton.SingletonPriority1.Instance().Supplier;
            foreach (var item in data)
            {
                dataGridView1.Rows.Add(item.Id, item.Code, item.Name, item.Address, item.Tel, Library.GetFullNameUserById(item.CreateBy),
                    Library.ConvertBoolToStr(item.Enable), item.Description);
            }
        }

    }
}
