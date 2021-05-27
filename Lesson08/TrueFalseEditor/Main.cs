﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrueFalseEditor
{
    public partial class Main : Form
    {
        private TrueFalse database;
        public bool ChangedQuestion;


        public Main()
        {
            InitializeComponent();
            ChangedQuestion = false;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
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
                database = new TrueFalse(saveFileDialog.FileName);
                database.Add("Земля круглая?", true);
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
                database = new TrueFalse(openFileDialog.FileName);
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

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (ChangedQuestion)
            {
                MessageBox.Show($"У вас есть не сохраненные данные! Хотите их сохраните по кнопке Save?",
                    "Вопрос!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                    return;
            }
            tbQuestion.Text = nudNumber.Value > 0 ? database[(int)nudNumber.Value - 1].Text  : "";
            cbTrue.Checked = nudNumber.Value > 0 ? database[(int)nudNumber.Value - 1].TrueFalse : false;
            ChangedQuestion = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(database == null)
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
            database.Add("#" + (database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show($"База данных еще не создана!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nudNumber.Value > 0)
            {
                database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
                database[(int)nudNumber.Value - 1].TrueFalse = cbTrue.Checked;
            }
            ChangedQuestion = false;
        }

        private void tbQuestion_TextChanged(object sender, EventArgs e)
        {
            ChangedQuestion = true;
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"
            Редактор вопросов ""Верю не верю""
            Автор - Хрулев Е. Н.
            Версия - 1.0.0.0",
            "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}