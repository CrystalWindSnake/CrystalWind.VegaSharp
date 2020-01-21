using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalWind.VegaSharp.WindowsFormsSamples
{


    public partial class Form1 : Form
    {
        private Func<SamplesResult>[] methods = new Func<SamplesResult>[]
        {
                Samples.NewMethod1,
                Samples.NewMethod2,
                Samples.NewMethod3,
                Samples.NewMethod4,
                Samples.NewMethod5,
                Samples.NewMethod6,
                Samples.NewMethod7,
                Samples.NewMethod8,
        };

        public Form1()
        {
            InitializeComponent();
            listBox1.Items.AddRange(Enumerable.Range(1, 8).Select(v => v as object).ToArray());
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            listBox1.SelectedIndex = 0;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var res = methods[listBox1.SelectedIndex]();
            richTextBox1.Text = res.Desc;
            webView1.LoadHtml(res.Html);
        }




    }
}
