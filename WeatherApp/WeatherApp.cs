using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class WeatherApp : Form
    {
        private City _city;

        private readonly Size _initialFormSize = new Size(300,300);
        private const string FileName = "meteoPicture";

        public WeatherApp()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
        }

        public void ResetForm()
        {
            Size = _initialFormSize;
            pictureBox1.Visible = false;
            groupBox1.Visible = true;
            textBox1.Text = "";
        }

        public bool TrySetCity(string city, Country country)
        {
            try
            {
                _city = new City(city, country);
                return true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show(@"Cannot find the city!");
                return false;
            }
        }

        public void DownloadPicture(string fileName)
        {
            string path = String.Format("http://www.meteo.pl/um/php/mgram_search.php?NALL={0}&EALL={1}&lang=pl",_city.Latitude,_city.Longitude);
            WebRequest req = WebRequest.Create(path);
            WebResponse res = req.GetResponse();
            string temp = res.ResponseUri.ToString();
            res.Dispose();
            string pictureUri = temp.Replace("meteorogram_map_um", "mgram_pict").Replace("/php/","/metco/");
            
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(pictureUri, fileName);
            }
        }

        public void ViewPictureOnPictureBox(string fileName)
        {
            Image image = Image.FromFile(fileName);
            pictureBox1.Image = image;
            pictureBox1.Location = new Point(0,menuStrip1.Bottom);
            pictureBox1.Height = image.Height;
            pictureBox1.Width = image.Width;
            pictureBox1.Visible = true;
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
                DownloadPicture(FileName);
                ViewPictureOnPictureBox(FileName);
                Size = new Size(pictureBox1.Width,pictureBox1.Height + 20);
            }
        }

        private void setCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Visible)
            {
                ResetForm();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        
    }

    public enum Country
    {
        Poland,
        England,
        Germany,
    }
}
