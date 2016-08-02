using System;
using System.Windows;
using System.Windows.Controls;
using softwareEngineering.Model;
using LIS.MainProject.Utility.Controls.HoldMessage;
using LIS.MainProject.Utility;

namespace softwareEngineering
{
    public partial class InsertPage : ChildWindow
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

        public InsertPage(MainPageModel model)
        {
           
            Model = model;
            InitializeComponent();
            this.DataContext = Model;

            #region 获取当前的时间
            DateTime datetime = System.DateTime.Now;
            this.stockdate.DateTimeText  = datetime.ToString("yyyy/MM/dd");
            #endregion

            #region 注册 model 里的事件
            Model.InsertDataSuccess += new EventHandler<ConstsEventArgs>(model_InsertDataSuccess);
            Model.InsertDataFailure += new EventHandler<ConstsEventArgs>(model_InsertDataFailure); 
            #endregion
        }
       
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
             if (!string.IsNullOrEmpty(stocknumber.ToString()))
            {
                stocknumberStr = stocknumber.Text ;
            }
             if (!string.IsNullOrEmpty(producingarea.ToString ()))
            {
                producingareaStr = producingarea.Text;
                
            } 
            if (!string.IsNullOrEmpty(goodname.ToString ()))
            {
                goodnameStr = goodname.Text;
            }
            if (productiondate != null)
            {
                productiondateStr = productiondate.DateTimeText;
            }
            if (!string.IsNullOrEmpty(deadline.ToString ()))
            {
                deadlineStr = deadline.DateTimeText;
            }
            if ( !string.IsNullOrEmpty(category.ToString ()))
            {
                categoryStr = category.Text;
            } 
            if ( !string.IsNullOrEmpty(stockdate.ToString ()))
            {
                stockdateStr = stockdate.DateTimeText;
            }
            if ( !string.IsNullOrEmpty(unit.ToString ()))
            {
                unitStr = unit.Text;
            }
            if ( !string.IsNullOrEmpty(stockperson.ToString ()))
            {
                stockpersonStr = stockperson.Text;
            }
            if ( !string.IsNullOrEmpty(unitprice.ToString ()))
            {
                unitpriceStr = unitprice.Text;
            }
            if ( !string.IsNullOrEmpty(supplyperson.ToString ()))
            {
                supplypersonStr = supplyperson.Text;
            }
            if ( !string.IsNullOrEmpty(quantity.ToString ()))
            {
                quantityStr = quantity.Text;
            }
           
            if (!string.IsNullOrEmpty(remark.ToString()))
            {
                remarkStr = remark.Text;
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

        
                Model.Insert(stocknumberStr, producingareaStr,
                goodnameStr, productiondateStr, deadlineStr,
                categoryStr, gradeStr, stockdateStr, unitStr ,
                stockpersonStr, unitpriceStr, supplypersonStr,
                quantityStr, moneyamountStr  , remarkStr);
        }
        #endregion

        #region 新增回调后的响应方法
        void model_InsertDataFailure(object sender, ConstsEventArgs e)
        {
            if (!e.IsResult) //数据库错误
            {
                CommonFunction.ShowMessage(e.obj_Args_one.ToString(), Consts.ComfirmTitle);
            }
        }
        void model_InsertDataSuccess(object sender, ConstsEventArgs e)
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
            Model.InsertDataSuccess -= new EventHandler<ConstsEventArgs>(model_InsertDataSuccess);
            Model.InsertDataFailure -= new EventHandler<ConstsEventArgs>(model_InsertDataFailure);          
        }
        #endregion

        #region 单价、数量值改变事件
        private void unitprice_TextChanged(object sender, TextChangedEventArgs e)
        {
            double temp;
            if (string.IsNullOrEmpty(quantity.Text) || string.IsNullOrEmpty(unitprice.Text))
            { moneyamountStr = null; }
            else
            {
                temp = (Convert.ToDouble(quantity.Text)) * (Convert.ToDouble(unitprice.Text));
                moneyamount.Text = temp.ToString();
                moneyamountStr = moneyamount.Text;
            }
        }

        private void quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            double temp;
            if (string.IsNullOrEmpty(quantity.Text) || string.IsNullOrEmpty(unitprice.Text))
            { moneyamountStr = null; }
            else
            {
                temp = (Convert.ToDouble(quantity.Text)) * (Convert.ToDouble(unitprice.Text));
                moneyamount.Text = temp.ToString();
                moneyamountStr = moneyamount.Text;
            }
        }
        #endregion

    }
}

