using System;
using System.Drawing;
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
            catch (ArgumentException)
            {
                MessageBox.Show(@"Cannot find the city!");
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
            umPicture.Refresh();
            coampsPicture.Refresh();
        }

        private void WeatherApp_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.City == "")
            {
                ResetForm();
            }
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
