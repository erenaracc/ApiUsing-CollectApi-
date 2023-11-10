using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;

namespace HavaDurumu_OpenWeather_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //7a92ce2a13a8e0b383dc773223ce2f86 : open weather sitesinden aldýgýmýz bize özel olan id           
            label2.Text = ""; //ortalama
            label3.Text = ""; //min
            label4.Text = ""; //max
        }

        private Hava HavaDurumuBilgileriniCek(string sehir)
        {
            string connection = "https://api.openweathermap.org/data/2.5/weather?q="+sehir+"&mode=xml&appid=7a92ce2a13a8e0b383dc773223ce2f86";

            //MessageBox.Show(connection);

            XDocument veri = XDocument.Load(connection);
            Hava hava = new Hava();
            hava.OrtalamaSicaklik = veri.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            hava.MinSicaklik = veri.Descendants("temperature").ElementAt(0).Attribute("min").Value;
            hava.MaxSicaklik = veri.Descendants("temperature").ElementAt(0).Attribute("max").Value;
            hava.HavaDurumu = veri.Descendants("weather").ElementAt(0).Attribute("value").Value;
            return hava;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hava hava=HavaDurumuBilgileriniCek(textBox1.Text);
            label2.Text = CelciusaCevir(hava.OrtalamaSicaklik).ToString();                ;
            label3.Text = CelciusaCevir(hava.MinSicaklik).ToString();
            label4.Text = CelciusaCevir(hava.MaxSicaklik).ToString();
            if (hava.HavaDurumu.Contains("cloud"))
            {
                //fotograf bulut olsun
                //pictureBox1.ImageLocation = "C:\\Users\\Software Developer\\Desktop\\web\\ApiUsing(CollectApi)\\HavaDurumu(OpenWeather)\\images\\bulut.png";              
                pictureBox1.Image = Properties.Resources.bulut;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //
            }
            else if(hava.HavaDurumu.Contains("rain"))
            {
                pictureBox1.ImageLocation = "C:\\Users\\ARIBILGI\\Downloads\\WebAPIOrnek\\ApiUsing(CollectApi)\\HavaDurumu(OpenWeather)\\images\\Yagmurr.png"; 
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                //fotograf güneþ olsun
                //pictureBox1.ImageLocation = "C:\\Users\\Software Developer\\Desktop\\web\\ApiUsing(CollectApi)\\HavaDurumu(OpenWeather)\\images\\gunes.png";
                pictureBox1.Image = Properties.Resources.gunes;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        //kelvin türünden gelen sýcaklýk bilgisini celcius'a cevirmek.
        public double CelciusaCevir(string sicaklik)
        {
            double sicaklikDegeri;
            CultureInfo ci = CultureInfo.InstalledUICulture;
            string bilgisayarDili = ci.Name;
            switch (bilgisayarDili)
            {
                case "tr-TR":
                    sicaklikDegeri = double.Parse(sicaklik.Replace(".", ","));
                    return (Math.Round((sicaklikDegeri - 273.15), 2));                   
                case "en-US":
                    sicaklikDegeri = double.Parse(sicaklik);
                    return (Math.Round((sicaklikDegeri - 273.15), 2));
                default:
                    return double.MaxValue;                  
            }              
        }


    }
}