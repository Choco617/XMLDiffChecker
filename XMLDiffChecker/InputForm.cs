using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace XMLDiffChecker
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        public string BrowseToFile()
        {
            string sDefaultPath = "D:\\MattSpace\\Documents\\Soulseek user file logs";
            string sUserPath = "";

            /*
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.SelectedPath = sDefaultPath;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                sUserPath = folderBrowserDialog1.SelectedPath;
                Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;
            }
            */

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Browse to XML file:";
            ofd.InitialDirectory = sDefaultPath;
            ofd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                sUserPath = ofd.FileName;
            }

            return sUserPath;
        }

        private void BrowseButtonA_Click(object sender, EventArgs e)
        {
            FileAPath.Text = BrowseToFile();
        }

        private void BrowseButtonB_Click(object sender, EventArgs e)
        {
            FileBPath.Text = BrowseToFile();
        }

        private void CompareButton_Click(object sender, EventArgs e)
        {
            //Data XML_A = new Data();
            //XML_A = XmlManager.XmlDataReader(FileAPath.Text);
            /*
            string[] sXML_A;
            sXML_A = XmlManager.XmlDataReader(FileAPath.Text);
            foreach(string sEntry in sXML_A)
            {
                Console.Write(sEntry);
            }
            */

            /*
            var xmlDoc = XDocument.Load(new StreamReader(FileAPath.Text));
            dynamic root = new ExpandoObject();
            dynamic XML_A = XmlWrapper.Convert(root);
            string[] sXML_A = (string[])XML_A;
            foreach(string sEntry in sXML_A)
            {
                Console.WriteLine(sEntry);
            }
            */

            XmlDocument docA = new XmlDocument();
            docA.Load(FileAPath.Text);
            XmlNode root = docA.DocumentElement;
            /*
            foreach(XmlNode node in docA.DocumentElement.ChildNodes)
            {
                Console.WriteLine($"name {node.Name}, text {node.InnerText}");
            }
            */
            ReportXML("", root);
        }
            public void ReportXML(string sPath, XmlNode node)
            {
                foreach(XmlNode SomeNode in node.ChildNodes)
                {
                    var attribute = SomeNode.Attributes["name"];
                    string sName = "";
                    if (attribute != null) { sName = attribute.Value; }
                    if (SomeNode.Name != "file")
                    {
                        Console.WriteLine($"{sPath}/{sName}");
                    }

                    ReportXML(sPath + "/" + sName, SomeNode);
                }
            }
    }


    public class XmlWrapper
    {
        public static dynamic Convert(XElement parent)
        {
            dynamic output = new ExpandoObject();

            output.Name = parent.Name.LocalName;
            output.Value = parent.Value;

            output.HasAttributes = parent.HasAttributes;
            if (parent.HasAttributes)
            {
                output.Attributes = new List<KeyValuePair<string, string>>();
                foreach (XAttribute attr in parent.Attributes())
                {
                    KeyValuePair<string, string> temp = new KeyValuePair<string, string>(attr.Name.LocalName, attr.Value);
                    output.Attributes.Add(temp);
                }
            }

            output.HasElements = parent.HasElements;
            if (parent.HasElements)
            {
                output.Elements = new List<dynamic>();
                foreach (XElement element in parent.Elements())
                {
                    dynamic temp = Convert(element);
                    output.Elements.Add(temp);
                }
            }

            return output;
        }
    }
}
