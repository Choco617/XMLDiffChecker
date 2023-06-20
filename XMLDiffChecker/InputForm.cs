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
using static System.Windows.Forms.AxHost;
using System.Diagnostics;

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
            string sDefaultPath = "";
            string sUserPath = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Browse to XML file:";
            ofd.InitialDirectory = sDefaultPath;
            ofd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if(ofd.ShowDialog() == DialogResult.OK) { sUserPath = ofd.FileName; }

            return sUserPath;
        }

        private void BrowseButtonA_Click(object sender, EventArgs e)
        {
            FileAPath.Text = BrowseToFile();
            CompareButton.Select();
        }

        private void BrowseButtonB_Click(object sender, EventArgs e)
        {
            FileBPath.Text = BrowseToFile();
            CompareButton.Select();
        }

        private void CompareButton_Click(object sender, EventArgs e)
        {
            if(FileAPath.Text == "" | FileBPath.Text == "")
            {
                MessageBox.Show("Oops! Must choose two files.");
                return;
            }

            if(FileAPath.Text == FileBPath.Text)
            {
                MessageBox.Show("Oops! Files must be different.");
                return;
            }

            XmlDocument docA = new XmlDocument();
            var foldersA = new List<FolderEntry>();
            docA.Load(FileAPath.Text);
            XmlNode root = docA.DocumentElement;
            ReportXML("", root, foldersA);

            XmlDocument docB = new XmlDocument();
            var foldersB = new List<FolderEntry>();
            docB.Load(FileBPath.Text);
            root = docB.DocumentElement;
            ReportXML("", root, foldersB);

            var UniqueToB = new List<FolderEntry>();

            // build list of entries unique to B
            foreach(FolderEntry feB in foldersB)
            {
                bool bFound = false;
                foreach(FolderEntry feA in foldersA)
                {
                    if(feA.Name == feB.Name)
                    {
                        bFound = true;
                        break;
                    }
                }
                if(bFound == false) { UniqueToB.Add(feB); }
            }

            // record
            if( UniqueToB.Count > 0)
            {
                string sFileAPathNoPath = FileAPath.Text.Substring(FileAPath.Text.LastIndexOf("\\") + 1);
                sFileAPathNoPath = sFileAPathNoPath.Substring(0, sFileAPathNoPath.LastIndexOf("."));
                string sFileBPathNoPath = FileBPath.Text.Substring(FileBPath.Text.LastIndexOf("\\") + 1);
                sFileBPathNoPath = sFileBPathNoPath.Substring(0, sFileBPathNoPath.LastIndexOf("."));
                string sReportFilename = sFileAPathNoPath + " to " + sFileBPathNoPath;
                string sReportDir = FileBPath.Text.Substring(0, FileBPath.Text.LastIndexOf("\\"));
                string sReportFullPath = sReportDir + "\\" + sReportFilename + ".txt";

                using (StreamWriter sw = new StreamWriter(sReportFullPath))
                {
                    foreach(FolderEntry UniqueEntry in UniqueToB)
                    {
                        sw.WriteLine(UniqueEntry.Path + "/" + UniqueEntry.Name);
                    }
                }

                MessageBox.Show($"Changes found - see report file\n{sReportFilename}", "Report");
                Process.Start("notepad.exe", sReportFullPath);
            }
            else
            {
                MessageBox.Show("No changes found!", "Report");
            }

            this.Close();
        }
            public void ReportXML(string sPath, XmlNode node, List<FolderEntry> WhichList)
            {
                string sName = "";
                var attribute = node.Attributes["name"];
                if (attribute != null) { sName = attribute.Value; }

                if (node.Name != "file") 
                { 
                    FolderEntry NewFolder = new FolderEntry { Path = sPath, Name = sName };
                    WhichList.Add( NewFolder );
                }
                
                foreach (XmlNode SomeNode in node.ChildNodes) { ReportXML(sPath + "/" + sName, SomeNode, WhichList); }
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

    public class FolderEntry
    {
        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    
}
