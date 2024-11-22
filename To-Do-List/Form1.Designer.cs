namespace To_Do_List
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.tasksListBox = new System.Windows.Forms.ListBox();
            this.addTaskBtn = new System.Windows.Forms.Button();
            this.removeTaskBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 64);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(222, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "To-Do-List";
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(139, 115);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(180, 29);
            this.textBox.TabIndex = 2;
            // 
            // tasksListBox
            // 
            this.tasksListBox.BackColor = System.Drawing.SystemColors.Window;
            this.tasksListBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tasksListBox.FormattingEnabled = true;
            this.tasksListBox.ItemHeight = 37;
            this.tasksListBox.Location = new System.Drawing.Point(104, 161);
            this.tasksListBox.Name = "tasksListBox";
            this.tasksListBox.Size = new System.Drawing.Size(442, 337);
            this.tasksListBox.TabIndex = 3;
            this.tasksListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TasksListBox_DrawItem);
            this.tasksListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TasksListBox_MouseDoubleClick);
            // 
            // addTaskBtn
            // 
            this.addTaskBtn.Location = new System.Drawing.Point(336, 115);
            this.addTaskBtn.Name = "addTaskBtn";
            this.addTaskBtn.Size = new System.Drawing.Size(75, 29);
            this.addTaskBtn.TabIndex = 4;
            this.addTaskBtn.Text = "Add Task";
            this.addTaskBtn.UseVisualStyleBackColor = true;
            this.addTaskBtn.Click += new System.EventHandler(this.AddTaskBtn_Click);
            // 
            // removeTaskBtn
            // 
            this.removeTaskBtn.Location = new System.Drawing.Point(505, 115);
            this.removeTaskBtn.Name = "removeTaskBtn";
            this.removeTaskBtn.Size = new System.Drawing.Size(86, 29);
            this.removeTaskBtn.TabIndex = 5;
            this.removeTaskBtn.Text = "Remove task";
            this.removeTaskBtn.UseVisualStyleBackColor = true;
            this.removeTaskBtn.Click += new System.EventHandler(this.RemoveTaskBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(424, 115);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 29);
            this.editBtn.TabIndex = 6;
            this.editBtn.Text = "Edit Task";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 542);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.removeTaskBtn);
            this.Controls.Add(this.addTaskBtn);
            this.Controls.Add(this.tasksListBox);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "To-Do-List";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ListBox tasksListBox;
        private System.Windows.Forms.Button addTaskBtn;
        private System.Windows.Forms.Button removeTaskBtn;
        private System.Windows.Forms.Button editBtn;
    }
}

