using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace dota2Leaderboards
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://www.dota2.com/webapi/ILeaderboard/GetDivisionLeaderboard/v0001?division=china";
            HttpWebRequest hwrqP = (HttpWebRequest)WebRequest.Create(url);
            //hwrqP.Method = "POST";

            HttpWebResponse response = (HttpWebResponse)hwrqP.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();

            JObject jo = (JObject)JsonConvert.DeserializeObject(content);
            JArray ja = (JArray)jo["leaderboard"];

            string text = "";

            foreach(JObject o in ja)
            {
                text += o["rank"] + "、" + o["team_tag"] + "." + o["name"] + "\n";
            }

            MessageBox.Show(text);

        }
    }
}
