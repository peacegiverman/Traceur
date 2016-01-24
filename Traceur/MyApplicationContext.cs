using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace Traceur
{
    class MyApplicationContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        TaskListForm configWindow = new TaskListForm();
        TrackTaskForm trackTaskWindow = new TrackTaskForm();

        private KeyboardHookListener keyboardHookListener;

		[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		internal static extern IntPtr SetForegroundWindow(IntPtr hwnd);

        public MyApplicationContext()
        {
            MenuItem viewCalendarItem = new MenuItem("View Google Calendar", new EventHandler(ViewGoogleCalendar));
            MenuItem configMenuItem = new MenuItem("List tasks", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Traceur.Properties.Resources.traceur1;
            notifyIcon.Click += new EventHandler(OnClick);
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { viewCalendarItem, configMenuItem, exitMenuItem });
            notifyIcon.Visible = true;

            // Global Shortcut Hook
            keyboardHookListener = new KeyboardHookListener(new GlobalHooker());
            keyboardHookListener.Enabled = true;
            keyboardHookListener.KeyDown += OnGlobalKeyDown;
            keyboardHookListener.KeyUp += OnGlobalKeyUp;

            this.trackTaskWindow.SetDesktopLocation(
                Screen.PrimaryScreen.WorkingArea.Right - this.trackTaskWindow.Size.Width - 8,
                Screen.PrimaryScreen.WorkingArea.Bottom - this.trackTaskWindow.Size.Height - 4
                );
        }

        //TODO: use an array of keys, so this can be changed easily;
        private bool controlIsDown = false;
        private bool tildeIsDown = false;
        //FIXME: Register down only on first press, not while holding.
        private void OnGlobalKeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Key Down: " + e.KeyValue);
            switch(e.KeyCode)
            {
                case Keys.LControlKey:
				case Keys.RControlKey:
                    Console.WriteLine("CTRL");
                    controlIsDown = true;
                    if (tildeIsDown)
                    {
						e.Handled = true;
                        trackTaskWindow.Show();
                        //trackTaskWindow.Activate();
						SetForegroundWindow(trackTaskWindow.Handle);
						
                    }
                    break;
                
                case Keys.Oemtilde:
                    Console.WriteLine("Tilde");
                    tildeIsDown = true;
                    if (controlIsDown)
                    {
						e.Handled = true;
                        trackTaskWindow.Show();
                        //trackTaskWindow.Activate();
						SetForegroundWindow(trackTaskWindow.Handle);
                    }
                    break;

                default: break;
            }
        }


        private void OnGlobalKeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Control:
                    controlIsDown = false;
                    break;

                case Keys.Oemtilde:
                    tildeIsDown = false;
                    break;

                default: break;
            }
        }

        private void ViewGoogleCalendar(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com/calendar/");
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (trackTaskWindow.Visible)
            {
                trackTaskWindow.Hide();
            }
            else
            {
                trackTaskWindow.Show();
                trackTaskWindow.Activate();
            }
        }

        void ShowConfig(object sender, EventArgs e)
        {
            // If we are already showing the window, merely focus it.
            if (configWindow.Visible)
            {
                configWindow.Activate();
            }
            else
            {
                configWindow.Show();
            }
        }

        void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
