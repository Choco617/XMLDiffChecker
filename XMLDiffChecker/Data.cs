using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPropertyViewer
{
    public class Data
    {
        private string _initials;
        public string Initials
        {
            get { return _initials; }
            set { _initials = value; }
        }

        private string _fileformat;
        public string FileFormat
        {
            get { return _fileformat; }
            set { _fileformat = value; }
        }

        private string _defaultlocation;
        public string DefaultLocation
        {
            get { return _defaultlocation; }
            set { _defaultlocation = value; }
        }

        private string _resporg;
        public string RespOrg
        {
            get { return _resporg; }
            set { _resporg = value; }
        }

        private bool _nonstandard;
        public bool NonStandard
        {
            get { return _nonstandard; }
            set { _nonstandard = value; }
        }

        private bool _modernui;
        public bool ModernUI
        {
            get { return _modernui; }
            set { _modernui = value; }
        }

        private bool _dwgmismatch;
        public bool DwgMismatch
        {
            get { return _dwgmismatch; }
            set { _dwgmismatch = value; }
        }

        private bool _autorename;
        public bool AutoRename
        {
            get { return _autorename; }
            set { _autorename = value; }
        }


        /*
         * to add a new preference:
         *     -define it here
         *     -assign it a default value in the DefaultPrefs object at the top of XmlManager.cs
         *     -add control on PrefsForm
         *     -add field in PrefsForm.cs for load/save
         *     "add if missing" is already handled programmatically
         *     value is already available anywhere through public UserPreferences.<prefname>
         */
    }
}
