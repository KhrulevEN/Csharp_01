using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App04_DateBirthday
{
    public partial class Main : Form
    {

        private DateBirthdays database;
        public bool ChangedQuestion;

        public Main()
        {
            InitializeComponent();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            if (ChangedQuestion)
            {
                MessageBox.Show($"У вас есть не сохраненные данные! Хотите их сохраните по кнопке Save?",
                    "Вопрос!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                    return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "*.xml|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new DateBirthdays(saveFileDialog.FileName);
                database.Add("Хрулёв Евгений Николаевич", new DateTime(1982, 10, 11));//, 0,0,0));
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            }
            ChangedQuestion = false;
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            if (ChangedQuestion)
            {
                MessageBox.Show($"У вас есть не сохраненные данные! Хотите их сохраните по кнопке Save?",
                    "Вопрос!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                    return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "*.xml|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new DateBirthdays(openFileDialog.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
            }
            ChangedQuestion = false;
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show($"База данных еще не создана!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            database.Save();
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            if (ChangedQuestion)
            {
                MessageBox.Show($"У вас есть не сохраненные данные! Хотите их сохраните по кнопке Save?",
                    "Вопрос!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                    return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "*.xml|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database.SaveAs(saveFileDialog.FileName);
            }
            ChangedQuestion = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show($"База данных еще не создана!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ChangedQuestion)
            {
                MessageBox.Show($"У вас есть не сохраненные данные! Хотите их сохраните по кнопке Save?",
                    "Вопрос!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                    return;
            }
            database.Add("#" + (database.Count + 1).ToString(), new DateTime(1, 1, 1));//,0,0,0));
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show($"База данных еще не создана!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ChangedQuestion)
            {
                MessageBox.Show($"У вас есть не сохраненные данные! Хотите их сохраните по кнопке Save?",
                    "Вопрос!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                    return;
            }
            database.Remove((int)nudNumber.Value - 1);
            if (nudNumber.Maximum>0)
                nudNumber.Maximum--;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show($"База данных еще не создана!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nudNumber.Value > 0)
            {
                database[(int)nudNumber.Value - 1].FIO = textBoxFIO.Text;
                DateTime dateBirth = new DateTime(1, 1, 1);//,0,0,0); 
                bool bRes = DateTime.TryParse(textBoxBirthday.Text, out dateBirth);
                if (bRes)
                    database[(int)nudNumber.Value - 1].Date = dateBirth;
                else
                    MessageBox.Show($"Неверный формат даты!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ChangedQuestion = false;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (ChangedQuestion)
            {
                MessageBox.Show($"У вас есть не сохраненные данные! Хотите их сохраните по кнопке Save?",
                    "Вопрос!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                    return;
            }
            textBoxFIO.Text = nudNumber.Value > 0 ? database[(int)nudNumber.Value - 1].FIO : "";
            textBoxBirthday.Text = nudNumber.Value > 0 ? database[(int)nudNumber.Value - 1].Date.ToShortDateString() : "";
                //ToString() : "";
            ChangedQuestion = false;
        }
    }
}
