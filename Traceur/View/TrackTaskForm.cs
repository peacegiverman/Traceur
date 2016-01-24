using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traceur
{
    public partial class TrackTaskForm : Form
    {
        public TrackTaskForm()
        {
            InitializeComponent();
        }

        private void TrackTaskForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TrackTaskForm_Paint(object sender, PaintEventArgs e)
        {
            if (TaskHandler.Instance.activeTask != null)
            {
                activeTaskLabel.Text = TaskHandler.Instance.activeTask.name;
                if (activeTaskLabel.Font.Italic)
                {
                    activeTaskLabel.Font = new Font(activeTaskLabel.Font, activeTaskLabel.Font.Style ^ FontStyle.Italic);
                }
                
                var duration = DateTime.Now - TaskHandler.Instance.activeTask.startTime;
                activityDurationLabel.Text = duration.ToString(@"hh\:mm");

                activeTaskStopButton.Enabled = true;
            }
            else
            {
                activeTaskLabel.Text = "None";
                if (!activeTaskLabel.Font.Italic)
                {
                    activeTaskLabel.Font = new Font(activeTaskLabel.Font, activeTaskLabel.Font.Style | FontStyle.Italic);
                }

                activityDurationLabel.Text = "";

                activeTaskStopButton.Enabled = false;
            }

			Console.WriteLine("Painting");
        }

        private void activeTaskStopButton_Click(object sender, EventArgs e)
        {
            TaskHandler.Instance.EndTask(TaskHandler.Instance.activeTask);

			this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartTask();
        }

        private void StartTask()
        {
			this.Hide();

            TaskHandler.Instance.AddNewTask(textBox1.Text);

            this.textBox1.Clear();
        }

		private void TrackTaskForm_Activated(object sender, EventArgs e)
		{
			// Update autocompletion
			textBox1.AutoCompleteCustomSource.Clear();
			textBox1.AutoCompleteCustomSource.AddRange(TaskHandler.Instance.GetPreviousTaskNames());

			textBox1.Select();
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				StartTask();
				e.Handled = true;
			}

			if (e.KeyCode == Keys.Escape)
			{
				this.Hide();
				e.Handled = true;
			}
		}
    }
}
