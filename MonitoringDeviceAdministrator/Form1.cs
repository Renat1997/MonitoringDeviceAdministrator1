using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;


namespace MonitoringDeviceAdministrator
{
    public partial class Form1 : Form
    {
        InfoContext db;
        public Form1()
        {
            
            InitializeComponent();


            db = new InfoContext();
            db.Infos.Load();


            dataGridView1.DataSource = db.Infos.Local.ToBindingList();
            
        }
        //добавить
        private void Button1_Click(object sender, EventArgs e)
        {
            AddInfoMachine addInfoMachine = new AddInfoMachine();
            DialogResult result = addInfoMachine.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Info machine = new Info();
            machine.Name = addInfoMachine.textBox1.Text;
            machine.Port = (int)addInfoMachine.numericUpDown1.Value;

            db.Infos.Add(machine);
            db.SaveChanges();
           
        }

        //удалить
        private void Button2_Click(object sender, EventArgs e)
        {
        
            if (dataGridView1.SelectedCells.Count > 0)
            {

                int index = dataGridView1.SelectedCells[0].OwningRow.Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;


                Info machine = db.Infos.Find(id);
                db.Infos.Remove(machine);
                db.SaveChanges();
            }
             
        }
        
        

        
      
        //изменить
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {

                int index = dataGridView1.SelectedCells[0].OwningRow.Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Info mashine = db.Infos.Find(id);

                AddInfoMachine addInfoMachine = new AddInfoMachine();

                addInfoMachine.numericUpDown1.Value = mashine.Port;

                addInfoMachine.textBox1.Text = mashine.Name;




                

              
                     

                mashine.Port = (int)addInfoMachine.numericUpDown1.Value;
                mashine.Name = addInfoMachine.textBox1.Text;

                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
           
           
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
