using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class WeatherApp : Form
    {
        private City _city;
        private Image _image;

        private readonly Size _initialFormSize = new Size(300,300);
        private readonly Size _workingFormSize = new Size(673,674);
        private const string UmModelFileName = "UmModel";
        private const string CoampsModelFileName = "CoampsModel";

        public WeatherApp()
        {
            InitializeComponent();
            ResetForm();
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
            if (_image != null) _image.Dispose();
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

        public void DownloadPicture(string fileName, Model model)
        {
            var pictureUri = GetPictureUri(model);


            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(pictureUri, fileName);
            }
        }

        private string GetPictureUri(Model model)
        {
            string path;
            switch (model)
            {
                case Model.Coamps:
                    path = String.Format("http://www.meteo.pl/php/mgram_search.php?NALL={0}&EALL={1}&lang=pl", _city.Latitude,
                                         _city.Longitude);
                    break;

                default:
                case Model.Um:
                    path = String.Format("http://www.meteo.pl/um/php/mgram_search.php?NALL={0}&EALL={1}&lang=pl", _city.Latitude,
                                         _city.Longitude);
                    break;
            }


            WebRequest req = WebRequest.Create(path);
            WebResponse res = req.GetResponse();
            string temp = res.ResponseUri.ToString();
            res.Dispose();
            string pictureUri;

            switch (model)
            {
                case Model.Coamps:
                    pictureUri = temp.Replace("meteorogram_map_coamps", "mgram_pict").Replace("/php/", "/metco/");
                    break;

                default:
                case Model.Um:
                    pictureUri = temp.Replace("meteorogram_map_um", "mgram_pict").Replace("/php/", "/metco/");
                    break;
            }
            return pictureUri;
        }

        public void ViewPictureOnPictureBox(string fileName, PictureBox pictureBox)
        {
            _image = Image.FromFile(fileName);
            pictureBox.Image = _image;
            pictureBox.Visible = true;
            pictureBox.Location = tabControl1.Location;
            tabControl1.Visible = true;
        }

        public void ViewUmPictureFromUrl(PictureBox pictureBox)
        {
            pictureBox.ImageLocation = GetPictureUri(Model.Um);
            pictureBox.Visible = true;
            pictureBox.Location = tabControl1.Location;
            tabControl1.Visible = true;
        }

        public void ViewCoampsPictureFromUrl(PictureBox pictureBox)
        {
            pictureBox.ImageLocation = GetPictureUri(Model.Coamps);
            pictureBox.Visible = true;
            pictureBox.Location = tabControl1.Location;
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
                //DownloadPicture(CoampsModelFileName,Model.Coamps);
                //DownloadPicture(UmModelFileName,Model.Um);
                //ViewPictureOnPictureBox(CoampsModelFileName, coampsPicture);
                //ViewPictureOnPictureBox(UmModelFileName, umPicture);
                ViewUmPictureFromUrl(umPicture);
                ViewCoampsPictureFromUrl(coampsPicture);
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
