using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace To_Do_List
{
    public partial class Form1 : Form
    {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private List<int> crossedOutItems = new List<int>();
        private bool doubleClickHandled = false;

        public Form1()
        {
            InitializeComponent();
            #region MenuStrip
            this.menuStrip1 = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.saveToolStripMenuItem = new ToolStripMenuItem();
            this.loadToolStripMenuItem = new ToolStripMenuItem();

            this.menuStrip1.Items.AddRange(new ToolStripItem[] 
            {
                this.fileToolStripMenuItem
            });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] 
            {
                this.saveToolStripMenuItem, this.loadToolStripMenuItem
            });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";

            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new EventHandler(this.SaveToolStripMenuItem_Click);
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new Size(98, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new EventHandler(this.LoadToolStripMenuItem_Click);

            this.Controls.Add(menuStrip1);
            #endregion
        }


        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Text Files (*.txt)|*.txt";
                string filePath = "";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                filePath = dialog.FileName;

                tasksListBox.Items.Clear();
                    crossedOutItems.Clear();

                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                           {
                              tasksListBox.Items.Add(line);
                           }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt";
            dialog.Title = "Save your tasks";
            string filePath = "";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (string item in tasksListBox.Items)
                    {
                        sw.WriteLine(item);
                    }
                    MessageBox.Show("File saved successfully", "Conformation message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }    
        }

        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                tasksListBox.Items.Add(textBox.Text);
                textBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please input a task.");
            }
        }

        private void RemoveTask()
        {
            if (tasksListBox.SelectedItem != null)
            {
                tasksListBox.Items.Remove(tasksListBox.SelectedItem);
                crossedOutItems.Clear();
            }
            else
            {
                MessageBox.Show("Select a task that you want to remove.");
            }
        }

        private void AddTaskBtn_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        private void RemoveTaskBtn_Click(object sender, EventArgs e)
        {
            RemoveTask();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveTask();
            }
            else if(e.KeyCode == Keys.Enter)
            {
                AddTask();
            }
        }


        private void EditBtn_Click(object sender, EventArgs e)
        {
            if(tasksListBox.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                tasksListBox.Items[tasksListBox.SelectedIndex] = textBox.Text;
                textBox.Clear();
                MessageBox.Show("Task edited successfully", "Conformation message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("Input is empty");
            }
            else
            {                MessageBox.Show("Select a task that you want to edit.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tasksListBox.DrawMode = DrawMode.OwnerDrawFixed;
            tasksListBox.DrawItem += new DrawItemEventHandler(TasksListBox_DrawItem);
            tasksListBox.MouseDoubleClick += new MouseEventHandler(TasksListBox_MouseDoubleClick);
        }

        private void TasksListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;


            string itemText = tasksListBox.Items[e.Index].ToString();
            Font font = crossedOutItems.Contains(e.Index) ? new Font(e.Font, FontStyle.Strikeout) : e.Font;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {              
                e.Graphics.FillRectangle(Brushes.LightSeaGreen, e.Bounds);        
            }
            else
            {               
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);  
            }

            e.Graphics.DrawString(itemText, font, Brushes.Black, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void TasksListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (doubleClickHandled)
                return;

            doubleClickHandled = true;

            int clickedIndex = tasksListBox.IndexFromPoint(e.Location);
            if (clickedIndex != ListBox.NoMatches)
            {
                if (!crossedOutItems.Contains(clickedIndex))
                {
                    crossedOutItems.Add(clickedIndex);
                }
                else
                {
                    crossedOutItems.Remove(clickedIndex);
                }
                tasksListBox.Invalidate();
            }
            Task.Delay(200).ContinueWith(_ => doubleClickHandled = false);
        }
    }
}
