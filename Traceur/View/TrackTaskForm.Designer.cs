namespace Traceur
{
    partial class TrackTaskForm
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.activeTaskLabel = new System.Windows.Forms.Label();
			this.activeTaskStopButton = new System.Windows.Forms.Button();
			this.activityDurationLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.AllowDrop = true;
			this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(12, 78);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(215, 24);
			this.textBox1.TabIndex = 0;
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Enter task:";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(233, 78);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 24);
			this.button1.TabIndex = 2;
			this.button1.Text = "Start task";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Active task:";
			// 
			// activeTaskLabel
			// 
			this.activeTaskLabel.AutoSize = true;
			this.activeTaskLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.activeTaskLabel.Location = new System.Drawing.Point(17, 25);
			this.activeTaskLabel.Margin = new System.Windows.Forms.Padding(8, 3, 3, 0);
			this.activeTaskLabel.Name = "activeTaskLabel";
			this.activeTaskLabel.Size = new System.Drawing.Size(61, 18);
			this.activeTaskLabel.TabIndex = 4;
			this.activeTaskLabel.Text = "Activity";
			this.activeTaskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// activeTaskStopButton
			// 
			this.activeTaskStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.activeTaskStopButton.Location = new System.Drawing.Point(233, 23);
			this.activeTaskStopButton.Name = "activeTaskStopButton";
			this.activeTaskStopButton.Size = new System.Drawing.Size(75, 24);
			this.activeTaskStopButton.TabIndex = 5;
			this.activeTaskStopButton.Text = "Stop Task";
			this.activeTaskStopButton.UseVisualStyleBackColor = true;
			this.activeTaskStopButton.Click += new System.EventHandler(this.activeTaskStopButton_Click);
			// 
			// activityDurationLabel
			// 
			this.activityDurationLabel.AutoSize = true;
			this.activityDurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.activityDurationLabel.Location = new System.Drawing.Point(183, 25);
			this.activityDurationLabel.Margin = new System.Windows.Forms.Padding(8, 3, 3, 0);
			this.activityDurationLabel.Name = "activityDurationLabel";
			this.activityDurationLabel.Size = new System.Drawing.Size(44, 18);
			this.activityDurationLabel.TabIndex = 6;
			this.activityDurationLabel.Text = "10:00";
			this.activityDurationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TrackTaskForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(320, 114);
			this.Controls.Add(this.activityDurationLabel);
			this.Controls.Add(this.activeTaskStopButton);
			this.Controls.Add(this.activeTaskLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TrackTaskForm";
			this.Opacity = 0.9D;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "TrackTaskForm";
			this.TopMost = true;
			this.Activated += new System.EventHandler(this.TrackTaskForm_Activated);
			this.Deactivate += new System.EventHandler(this.TrackTaskForm_Deactivate);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.TrackTaskForm_Paint);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label activeTaskLabel;
        private System.Windows.Forms.Button activeTaskStopButton;
        private System.Windows.Forms.Label activityDurationLabel;
    }
}