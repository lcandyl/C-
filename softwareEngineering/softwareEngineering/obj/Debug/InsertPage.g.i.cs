﻿#pragma checksum "F:\SoftwareEngineering\softwareEngineering\softwareEngineering\InsertPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "879F7B7F001B7DBDACBA51FB412A7486"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1008
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace softwareEngineering {
    
    
    public partial class InsertPage : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Button OKButton;
        
        internal System.Windows.Controls.TextBox stocknumber;
        
        internal System.Windows.Controls.TextBox producingarea;
        
        internal System.Windows.Controls.TextBox goodname;
        
        internal Telerik.Windows.Controls.RadDateTimePicker productiondate;
        
        internal System.Windows.Controls.TextBox category;
        
        internal Telerik.Windows.Controls.RadDateTimePicker deadline;
        
        internal Telerik.Windows.Controls.RadComboBox grade;
        
        internal Telerik.Windows.Controls.RadDateTimePicker stockdate;
        
        internal System.Windows.Controls.TextBox unit;
        
        internal System.Windows.Controls.TextBox stockperson;
        
        internal System.Windows.Controls.TextBox unitprice;
        
        internal System.Windows.Controls.TextBox supplyperson;
        
        internal System.Windows.Controls.TextBox quantity;
        
        internal System.Windows.Controls.TextBox moneyamount;
        
        internal System.Windows.Controls.TextBox remark;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/softwareEngineering;component/InsertPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
            this.stocknumber = ((System.Windows.Controls.TextBox)(this.FindName("stocknumber")));
            this.producingarea = ((System.Windows.Controls.TextBox)(this.FindName("producingarea")));
            this.goodname = ((System.Windows.Controls.TextBox)(this.FindName("goodname")));
            this.productiondate = ((Telerik.Windows.Controls.RadDateTimePicker)(this.FindName("productiondate")));
            this.category = ((System.Windows.Controls.TextBox)(this.FindName("category")));
            this.deadline = ((Telerik.Windows.Controls.RadDateTimePicker)(this.FindName("deadline")));
            this.grade = ((Telerik.Windows.Controls.RadComboBox)(this.FindName("grade")));
            this.stockdate = ((Telerik.Windows.Controls.RadDateTimePicker)(this.FindName("stockdate")));
            this.unit = ((System.Windows.Controls.TextBox)(this.FindName("unit")));
            this.stockperson = ((System.Windows.Controls.TextBox)(this.FindName("stockperson")));
            this.unitprice = ((System.Windows.Controls.TextBox)(this.FindName("unitprice")));
            this.supplyperson = ((System.Windows.Controls.TextBox)(this.FindName("supplyperson")));
            this.quantity = ((System.Windows.Controls.TextBox)(this.FindName("quantity")));
            this.moneyamount = ((System.Windows.Controls.TextBox)(this.FindName("moneyamount")));
            this.remark = ((System.Windows.Controls.TextBox)(this.FindName("remark")));
        }
    }
}

