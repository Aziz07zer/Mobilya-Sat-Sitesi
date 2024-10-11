using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace deneme_kur_cekme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);
            //dolar alış fiyatı.........
            string dolaralıs = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerText;
            lbldolaralıs.Text = dolaralıs;
            //dolar5 satış fiyatı.......
            string dolarsatıs = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lbldolarsatıs.Text = dolarsatıs;

            //euro alış fiyatı.........
            string euroalıs = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerText;
            lbleuroalıs.Text = euroalıs;
            //euro satış fiyatı.......
            string eurosatıs = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lbleurosatıs.Text = eurosatıs;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem.ToString();

            double textBoxValue;
            if (double.TryParse(textBox1.Text, out textBoxValue))
            {
                
                if (textBoxValue == 0)
                {
                    MessageBox.Show("Bölme işlemi için 0'dan farklı bir değer girin.");
                    return;
                }

                double result = 0;

                // ComboBox'taki veriyi kontrol et
                if (selectedValue == "Dolar Alış")
                {
                    double label1Value = double.Parse(lbldolaralıs.Text);
                    result = textBoxValue/ (label1Value);
                 
                    label2.Text = "Sonuç: " + result.ToString()+" $";
                }
                else if (selectedValue == "Dolar Satış")
                {
                    double label3Value = double.Parse(lbldolarsatıs.Text);
                    result = textBoxValue*(label3Value);
                    label2.Text = "Sonuç: " + result.ToString()+" TL";
                }
                else if (selectedValue == "EURO Alış")
                {
                    double label5Value = double.Parse(lbleuroalıs.Text);
                    result = textBoxValue/(label5Value);
                    label2.Text = "Sonuç: " + result.ToString()+ " €";
                }
                else if (selectedValue == "EURO Satış")
                {
                    double label4Value = double.Parse(lbleurosatıs.Text);
                    result =textBoxValue*(label4Value);
                    label2.Text = "Sonuç: " + result.ToString()+ " TL";
                }
                else
                {
                    MessageBox.Show("Geçersiz seçim.");
                    return;
                }

           
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin.");
            }
        }

        private void lbldolarsatıs_Click(object sender, EventArgs e)
        {

        }
    }
}
