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

namespace softwareEngineering.DTO
{
    public class SelectclItemDTO
    {
        #region ID 属性
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        public SelectclItemDTO()
        { }

        public SelectclItemDTO(string id)
        { _id = id; }
        
    }
}
