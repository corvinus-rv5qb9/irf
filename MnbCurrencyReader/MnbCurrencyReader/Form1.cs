﻿using MnbCurrencyReader.Entities;
using MnbCurrencyReader.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MnbCurrencyReader
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        public Form1()
        {
            InitializeComponent();
            string xmlstring = Consume();
            LoadXML(xmlstring);
            dataGridView1.DataSource = Rates;
        }
        private void LoadXML(string input)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(input);
            foreach (XmlElement item in xml.DocumentElement)
            {
                RateData r = new RateData();
                r.Date = DateTime.Parse(item.GetAttribute("date"));
                XmlElement child = (XmlElement)item.FirstChild;
                r.Currency = child.GetAttribute("curr");
                r.Value =decimal.Parse(child.InnerText);
                int unit = int.Parse(child.GetAttribute("unit"));
                if (unit != 0)
                    r.Value = r.Value / unit;
                Rates.Add(r);
            }
        }
        string Consume()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };
            var response = mnbService.GetExchangeRates(request);
            string result = response.GetExchangeRatesResult;
            return result;
        }
    }
}
