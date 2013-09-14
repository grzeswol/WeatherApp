using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class WeatherApp : Form
    {
        private City _city;
        private MeteoPicture _meteoPicture;
        
        private readonly Size _initialFormSize = new Size(300,300);
        private readonly Size _workingFormSize = new Size(689,674);

        private const char Degree = (char) 176;
        

        public WeatherApp()
        {
            InitializeComponent();
        }

        private void SetLabels()
        {
            _city.SetFieldsFromXml();
            label2.Text = string.Format("{0}, {1}{2}\n{3}", _city.GetCityName().ToUpper(), _city.CurrentTemperature, Degree,
                                        _city.WeatherDescription);
            
            label2.Location = tabControl1.Location;
            label2.Visible = true;

            label3.Text = label2.Text;
            label3.Location = label2.Location;
        }

        
        public void ResetForm()
        {
            Size = _initialFormSize;
            tabControl1.Visible = false;
            coampsPicture.Visible = false;
            groupBox1.Visible = true;
            groupBox1.Parent = this;
            textBox1.Text = "";
            coampsPicture.Image = null;
            umPicture.Image = null;
            label2.Visible = false;
        }



        public bool TrySetCity(string city, Country country)
        {
            try
            {
                _city = new City(city, country);
                _meteoPicture = new MeteoPicture(_city);
                return true;
            }
            catch (ArgumentException ex)
            {
                string message = string.Format("Error: {0}", ex.Message);
                MessageBox.Show(message, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (WebException)
            {
                string message = @"Problem with connection!";
                MessageBox.Show(message, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        public void ViewPictureOnPictureBox(Model model, PictureBox pictureBox)
        {
            switch (model)
            {
                case Model.Coamps:
                    pictureBox.Load(_meteoPicture.GetCoampsModelUri());
                    break;

                    default:
                    case Model.Um:
                    pictureBox.Load(_meteoPicture.GetUmModelUri());
                    break;
            }
            pictureBox.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y + 50);
            pictureBox.Visible = true;
            tabControl1.Visible = true;
        }

        private void SetNotifyText()
        {
            string text = string.Format("{0}, {1}{2}", _city.GetCityName().ToUpper(), _city.CurrentTemperature,
                                                       Degree);
            notifyIcon1.BalloonTipText = text;
            notifyIcon1.BalloonTipTitle = @"WeatherApp";
            notifyIcon1.Text = text;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string cityName = textBox1.Text;
            if (String.IsNullOrEmpty(cityName) || String.IsNullOrWhiteSpace(cityName))
            {
                MessageBox.Show(@"You have to specify name of the city!");
                return;
            }

            if (TrySetCity(cityName, Country.Poland))
            {
                timer1.Enabled = true;
                timer1.Start();
                groupBox1.Visible = false;
                ViewPictureOnPictureBox(Model.Um, umPicture);
                ViewPictureOnPictureBox(Model.Coamps, coampsPicture);
                SetLabels();
                this.ClientSize = _workingFormSize;
            }
        }

        private void setCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            umPicture.Load(_meteoPicture.GetUmModelUri());
            coampsPicture.Load(_meteoPicture.GetCoampsModelUri());
        }

        private void WeatherApp_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.City == "")
            {
                ResetForm();
            }
            timer1.Enabled = true;
            timer1.Start();
            TrySetCity(Properties.Settings.Default.City, Country.Poland);
            groupBox1.Visible = false;
            ViewPictureOnPictureBox(Model.Um, umPicture);
            ViewPictureOnPictureBox(Model.Coamps, coampsPicture);
            SetLabels();
            this.ClientSize = _workingFormSize;
        }

        private void WeatherApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.City = _city.GetCityName();
            Properties.Settings.Default.Save();
        }

        private void WeatherApp_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                SetNotifyText();
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(300);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetLabels();
            SetNotifyText();
        }

        private void weatherAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }

    public enum Country
    {
        Poland,
        England,
        Germany,
    }

    public enum Model
    {
        Um,
        Coamps,
    }
}
