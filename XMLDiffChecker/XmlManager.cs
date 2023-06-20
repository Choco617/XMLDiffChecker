using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection;

public class Data
{
    private string _path;
    public string Path
    {
        get { return _path; }
        set { _path = value; }
    }

    private string _entry;
    public string Entry
    {
        get { return _entry; }
        set { _entry = value; }
    }
}

namespace XMLDiffChecker
{
    class XmlManager
    {
        /*
        public static void XmlDataWriter(object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();
            SWPropertyViewer.UserPreferences = (Data)obj;
        }
        */

        public static string[] XmlDataReader(string filename)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Data));
            FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            //Data obj = (Data)xs.Deserialize(reader);
            string[] obj = (string[])xs.Deserialize(reader);
            reader.Close();

            return obj;
        }
    }
}
