using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using softwareEngineering.Model;
using LIS.MainProject.Utility;
using LIS.MainProject.Utility.Controls.HoldMessage;
using LIS.MainProject.Common;
using Telerik.Windows.Controls;

namespace softwareEngineering
{
    public partial class DeletePage : ChildWindow
    {
        #region 定义Model属性
        private MainPageModel _model;
        public MainPageModel Model
        {
            get { return _model; }
            set { _model = value; }
        }
        #endregion

        #region 全局变量
        string stocknumberStr = null;
        string stockdateStr = null;
        #endregion

        public DeletePage(MainPageModel model)
        {
           
            Model = model;
            InitializeComponent();
            this.DataContext = Model;
            Model.DeleteDataSuccess += new EventHandler<ConstsEventArgs>(model_DeleteDataSuccess);
            Model.DeleteDataFailure += new EventHandler<ConstsEventArgs>(model_DeleteDataFailure);
        }

        #region 确定按钮
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(stocknumberD.ToString()))
            {
                Message.ErrorMessage("提示", "请输入进货编号");
                return;

            }
            if (string.IsNullOrEmpty(stockdateD.DateTimeText))
            {
                Message.ErrorMessage("提示", "请输入进货日期");
                return;
            }
           
            HONEDialogHelper.Confirm(new DialogParameters
          {
              Content = HONEConsts.ErrorDelYesInfo,
              Header = HONEConsts.SystemPrompt,
              OkButtonContent = "确定",
              CancelButtonContent = "取消",
              Closed = (s, arg) => DelOKButton_Click(arg.DialogResult, null)
          });
            Model.Available = false;
        }
        private void DelOKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
          
            bool DialogResult = false;
            if (sender != null)
            {
                DialogResult = (bool)sender;
            }

            if (DialogResult == true)
            {
                #region 配置删除条件
               
                if (!string.IsNullOrEmpty(stocknumberD.ToString()))
                {
                    stocknumberStr = stocknumberD.Text;
                }
                if (!string.IsNullOrEmpty(stockdateD.DateTimeText))
                {
                    stockdateStr = stockdateD.DateTimeText;

                }
                #endregion
                Model.Delete(stocknumberStr, stockdateStr);
            }
                     
        }
        #endregion
        #region 删除回调后的响应方法
        void model_DeleteDataFailure(object sender, ConstsEventArgs e)
        {
            if (!e.IsResult) //数据库错误
            {
                CommonFunction.ShowMessage(e.obj_Args_one.ToString(), Consts.ComfirmTitle);
            }
        }
        void model_DeleteDataSuccess(object sender, ConstsEventArgs e)
        {
            Model.QueryMulit("", "", "全部");
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
            Model.DeleteDataSuccess -= new EventHandler<ConstsEventArgs>(model_DeleteDataSuccess);
            Model.DeleteDataFailure -= new EventHandler<ConstsEventArgs>(model_DeleteDataFailure);
        }
        #endregion
    }
}

