using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using softwareEngineering.Model;
using LIS.MainProject.Utility;
using LIS.MainProject.Utility.Controls.HoldMessage;
using System.Windows.Media.Imaging;

namespace softwareEngineering
{
    public partial class UpdatePage : ChildWindow
    {
  
        #region 定义全局变量
        string stockdateStr = null;
        string moneyamountStr = null;
        #endregion

        #region 定义Model属性
        private MainPageModel _model;
        public MainPageModel Model
        {
            get { return _model; }
            set { _model = value; }
        }
        #endregion

        public UpdatePage(MainPageModel model)
        {
           
            Model = model;
            InitializeComponent();
            this.DataContext = Model;
            model.Vailable = false;

            #region 给页面按钮添加图片          
            RadBtn_Update_Query.Image = new BitmapImage(new Uri(GetUrl.GetAbsoluteUrl("Images/Buttons/Query32.png"), UriKind.Absolute));          
            #endregion

            #region 注册事件
            RadBtn_Update_Query.Click += new System.Windows.RoutedEventHandler(RadBtn_Update_Query_Click);
            #endregion

            #region 注册 model 里的事件
            Model.UpdateDataSuccess += new EventHandler<ConstsEventArgs>(model_UpdateDataSuccess);
            Model.UpdateDataFailure += new EventHandler<ConstsEventArgs>(model_UpdateDataFailure);
            Model.Event_QueryDataSuccess += new EventHandler<ConstsEventArgs>(model_QueryDataSuccess);
            Model.Event_QueryDataFailure += new EventHandler<ConstsEventArgs>(model_QueryDataFailure);
            #endregion
        }

        #region RadBtn_Update_Query_Click 查询按钮按钮
        void RadBtn_Update_Query_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            RTB_ToolBar.IsEnabled = true;
            RBI_BusyBar_Up.IsBusy = true;
            RBI_BusyBar_Up.BusyContent = "正在查询...";

            string stocknumber1 = null;
            string stockdate1 = null;
 
            if (!string.IsNullOrEmpty(this.stocknumber1.Text))
            {
                stocknumber1 = this.stocknumber1.Text;
            }
            if (!string.IsNullOrEmpty(this.stockdate1.DateTimeText))
            {
                stockdate1 = this.stockdate1.DateTimeText;
   
            }
         
           if (string.IsNullOrEmpty(this.stocknumber1.Text) &&!string.IsNullOrEmpty(this.stockdate1.DateTimeText))
           {
               this.RBI_BusyBar_Up.IsBusy = false;
               CommonFunction.ShowMessage("请输入所要修改信息的进货编号！", "提示");
                        return;
           }
             if (string.IsNullOrEmpty(this.stockdate1.DateTimeText) && !string.IsNullOrEmpty(this.stocknumber1.Text))
           {
               this.RBI_BusyBar_Up.IsBusy = false;
               CommonFunction.ShowMessage("请输入所要修改信息的进货日期！", "提示");
                        return;
           }
             if (string.IsNullOrEmpty(this.stocknumber1.Text) && string.IsNullOrEmpty(this.stockdate1.DateTimeText))
           {
               this.RBI_BusyBar_Up.IsBusy = false;
               CommonFunction.ShowMessage("请先填写所要修改数据的进货编号和日期！", "提示");
                        return;
           }
             Model.QueryMulit_Up(stocknumber1, stockdate1);
        }

        void RadBtn_Update_Query_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RadBtn_Update_Query.Focus();
        }
        #endregion 

        #region 查询回调后的响应方法

        void model_QueryDataFailure(object sender, ConstsEventArgs e)
        {
            RBI_BusyBar_Up.IsBusy = false;
            Message.ErrorMessage(Consts.ErrorNoData, e.obj_Args_one.ToString());
        }

        void model_QueryDataSuccess(object sender, ConstsEventArgs e)
        {
            this.stocknumber2.Text = this.stocknumber1.Text;
            this.stockdate2.DateTimeText = this.stockdate1.DateTimeText;
            RBI_BusyBar_Up.IsBusy = false;
        }

        #endregion

        #region 保存按钮
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            string stocknumberStr = null, producingareaStr = null,
                goodnameStr = null, productiondateStr = null, deadlineStr = null,
                categoryStr = null, gradeStr = null,  unitStr = null,
                stockpersonStr = null, unitpriceStr = null, supplypersonStr = null,
                quantityStr = null, remarkStr = null;
           
             gradeStr = Model.GradeID;

             #region 判空
             if (!string.IsNullOrEmpty(stocknumber2.ToString()))
            {
                stocknumberStr = stocknumber2.Text ;
            }
             if (!string.IsNullOrEmpty(producingarea2.ToString ()))
            {
                producingareaStr = producingarea2.Text;
                
            } 
            if (!string.IsNullOrEmpty(goodname2.ToString ()))
            {
                goodnameStr = goodname2.Text;
            }
            if (productiondate2 != null)
            {
                productiondateStr = productiondate2.DateTimeText;
            }
            if (!string.IsNullOrEmpty(deadline2.ToString ()))
            {
                deadlineStr = deadline2.DateTimeText;
            }
            if ( !string.IsNullOrEmpty(category2.ToString ()))
            {
                categoryStr = category2.Text;
            } 
            if ( !string.IsNullOrEmpty(stockdate2.ToString ()))
            {
                stockdateStr = stockdate2.DateTimeText;
            }
            if ( !string.IsNullOrEmpty(unit2.ToString ()))
            {
                unitStr = unit2.Text;
            }
            if ( !string.IsNullOrEmpty(stockperson2.ToString ()))
            {
                stockpersonStr = stockperson2.Text;
            }
            if ( !string.IsNullOrEmpty(unitprice2.ToString ()))
            {
                unitpriceStr = unitprice2.Text;
            }
            if ( !string.IsNullOrEmpty(supplyperson2.ToString ()))
            {
                supplypersonStr = supplyperson2.Text;
            }
            if ( !string.IsNullOrEmpty(quantity2.ToString ()))
            {
                quantityStr = quantity2.Text;
            }
           
            if (!string.IsNullOrEmpty(remark2.ToString()))
            {
                remarkStr = remark2.Text;
            }
          
            if ( string.IsNullOrEmpty ( stocknumberStr))
            {
                Message.ErrorMessage("提示", "请输入进货编号");
                return;

            }
            if (string.IsNullOrEmpty(producingareaStr))
            {
                Message.ErrorMessage("提示", "请输入生产地");
                return;

            }
              if ( string.IsNullOrEmpty ( goodnameStr))
            {
                Message.ErrorMessage("提示", "请输入货物名称");
                return;

            }
             if ( string.IsNullOrEmpty ( productiondateStr))
            {
                Message.ErrorMessage("提示", "请输入生产日期");
                return;

            }
           
             if ( string.IsNullOrEmpty ( categoryStr))
            {
                Message.ErrorMessage("提示", "请输入所属类别");
                return;

            }
             if ( string.IsNullOrEmpty ( gradeStr))
            {
                gradeStr = "一等品";

            }
            if ( string.IsNullOrEmpty ( stockdateStr))
            {
                Message.ErrorMessage("提示", "请输入进货日期");
                return;

            }
             if ( string.IsNullOrEmpty ( unitStr))
            {
                Message.ErrorMessage("提示", "请输入单位");
                return;

            }
            if ( string.IsNullOrEmpty ( stockpersonStr))
            {
                Message.ErrorMessage("提示", "请输入进货人");
                return;

            }
            if ( string.IsNullOrEmpty ( unitpriceStr))
            {
                Message.ErrorMessage("提示", "请输入单价");
                return;

            }
            if ( string.IsNullOrEmpty ( supplypersonStr))
            {
                Message.ErrorMessage("提示", "请输入供货商");
                return;

            }
             if ( string.IsNullOrEmpty ( quantityStr))
            {
                Message.ErrorMessage("提示", "请输入数量");
                return;

            }
           if ( string.IsNullOrEmpty ( remarkStr))
            {
                Message.ErrorMessage("提示", "请输入备注");
                return;
            }
          
          
            #endregion

        
                Model.Update(stocknumberStr, producingareaStr,
                goodnameStr, productiondateStr, deadlineStr,
                categoryStr, gradeStr, stockdateStr, unitStr ,
                stockpersonStr, unitpriceStr, supplypersonStr,
                quantityStr, moneyamountStr  , remarkStr);
        }
        #endregion

        #region 修改回调后的响应方法
        void model_UpdateDataFailure(object sender, ConstsEventArgs e)
        {
            if (!e.IsResult) //数据库错误
            {
                CommonFunction.ShowMessage(e.obj_Args_one.ToString(), Consts.ComfirmTitle);
            }
        }
        void model_UpdateDataSuccess(object sender, ConstsEventArgs e)
        {
            Model.QueryMulit(stockdateStr, stockdateStr, "全部");
            this.DialogResult = true;
        }
        #endregion

        #region 取消按钮
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        #endregion

        #region  ChildWindow_Closed 关闭窗体
        private void ChildWindow_Closed(object sender, EventArgs e)
        {        
            Model.UpdateDataSuccess -= new EventHandler<ConstsEventArgs>(model_UpdateDataSuccess);
            Model.UpdateDataFailure -= new EventHandler<ConstsEventArgs>(model_UpdateDataFailure);
            Model.Event_QueryDataSuccess -= new EventHandler<ConstsEventArgs>(model_QueryDataSuccess);
            Model.Event_QueryDataFailure -= new EventHandler<ConstsEventArgs>(model_QueryDataFailure);
        }
        #endregion

        #region 单价、数量值改变实践
        private void unitprice_TextChanged(object sender, TextChangedEventArgs e)
        {
            double temp;
            if (string.IsNullOrEmpty(quantity2.Text) || string.IsNullOrEmpty(unitprice2.Text))
            { moneyamountStr = null; }
            else
            {
                temp = (Convert.ToDouble(quantity2.Text)) * (Convert.ToDouble(unitprice2.Text));
                moneyamount2.Text = temp.ToString();
                moneyamountStr = moneyamount2.Text;
            }
        }

        private void quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            double temp;
            if (string.IsNullOrEmpty(quantity2.Text) || string.IsNullOrEmpty(unitprice2.Text))
            { moneyamountStr = null; }
            else
            {
                temp = (Convert.ToDouble(quantity2.Text)) * (Convert.ToDouble(unitprice2.Text));
                moneyamount2.Text = temp.ToString();
                moneyamountStr = moneyamount2.Text;
            }
        }
        #endregion
    }
}

