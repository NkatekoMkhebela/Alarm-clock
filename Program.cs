using System;
using System.Windows.Forms;
using System.Media;

namespace Alarm_clock
{
    public partial class AlarmClock : Form
    {
        private Timer timer;
        private DateTime alarmTime;
        private bool alarmSet = false;

        // Snooze duration (5 minutes)
        private TimeSpan snoozeDuration = TimeSpan.FromMinutes(5);

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

                // Play a simple beep
                SystemSounds.Beep.Play();

                // Optionally show a message box
                MessageBox.Show("Time's up! Alarm triggered.", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Enable the snooze button
                btnSnooze.Enabled = true;
            }
        }

        private void btnSetAlarm_Click(object sender, EventArgs e)
        {
            // Assuming you have a DateTimePicker named timePickerAlarm
            alarmTime = timePickerAlarm.Value;
            alarmSet = true;
            MessageBox.Show($"Alarm set for {alarmTime.ToLongTimeString()}");
        }

        private void btnSnooze_Click(object sender, EventArgs e)
        {
            // Add snooze duration to the current alarm time
            alarmTime = alarmTime.Add(snoozeDuration);
            alarmSet = true;

            // Optionally show the updated alarm time after snoozing
            MessageBox.Show($"Snooze activated! New alarm time: {alarmTime.ToLongTimeString()}");

            // Disable the snooze button until next alarm
            btnSnooze.Enabled = false;
        }
    }
}

            

                

            
    
            
            
        
            

        
            
        
            

            
        
            

                
                
                    
                    
                    
                    
                
            
        
    


