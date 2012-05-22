using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Utility
{
    public class Parameter
    {
        private string _paraName;
        /// <summary>
        /// 参数名.
        /// </summary>
        public string Name
        {
            get { return _paraName; }
            set { _paraName = value; }
        }


        private string _paraValue;
        /// <summary>
        /// 参数值.
        /// </summary>
        public string Value
        {
            get { return _paraValue; }
            set { _paraValue = value; }
        }

        public Parameter(string name, string value)
        {
            this._paraName = name;
            this._paraValue = value;
        }
    }
}
