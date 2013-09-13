using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace WeatherApp
{
    public class MeteoPicture
    {
        private readonly City _city;
        //private readonly string _umModelFileName;
        //private readonly string _coampsModelFileName;
        private readonly string _umModelUri;
        private readonly string _coampsModelUri;

        public MeteoPicture(City city)
        {
            _city = city;

            try
            {
                _umModelUri = GetPictureUri(Model.Um);
                _coampsModelUri = GetPictureUri(Model.Coamps);
            }
            catch (Exception)
            {
                _umModelUri = "";
                _coampsModelUri = "";
                throw;
            }
            
        }

        

        private void DownloadPicture(string fileName, Model model)
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

            try
            {
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
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public string GetUmModelUri()
        {
            return _umModelUri;
        }

        public string GetCoampsModelUri()
        {
            return _coampsModelUri;
        }

        /*public Image GetCoampsImage()
        {
            return Image.FromFile(_coampsModelFileName);
        }
         * 
         * private bool CheckIfFileCreatedToday(string fileName)
        {
            var dateNow = DateTime.Today.ToString("d");
            var creationDate = File.GetCreationTime(fileName).ToString("d");
            if (dateNow == creationDate)
            {
                return true;
            }
            return false;
        }

        public Image GetUmImage()
        {
            return Image.FromFile(_umModelFileName);
        }
         */


    }
}