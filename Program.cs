using System;
using System.Media;

namespace Alarm_clock
{

    public partial class AlarmClock : Form
        {
            private Timer timer;
            private DateTime alarmTime;
            private bool alarmSet = false;

            public AlarmClock()
            {
                InitializeComponent();

                // Setup timer to tick every second
                timer = new Timer();
                timer.Interval = 1000;
                timer.Tick += Timer_Tick;
                timer.Start();
            }

            private void AlarmClock_Load(object sender, EventArgs e)
            {
                lblCurrentTime.Text = DateTime.Now.ToLongTimeString();
            }

            private void Timer_Tick(object sender, EventArgs e)
            {
                lblCurrentTime.Text = DateTime.Now.ToLongTimeString();

                if (alarmSet && DateTime.Now.ToLongTimeString() == alarmTime.ToLongTimeString())
                {
                    timer.Stop();
                    alarmSet = false;
                    SystemSounds.Beep.Play();
                    MessageBox.Show("⏰ Alarm ringing!", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            private void btnSetAlarm_Click(object sender, EventArgs e)
            {
                if (DateTime.TryParse(txtAlarmTime.Text, out alarmTime))
                {
                    alarmSet = true;
                    MessageBox.Show("✅ Alarm set for " + alarmTime.ToLongTimeString(), "Alarm Set", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("❌ Please enter time in HH:mm:ss format", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }

}
