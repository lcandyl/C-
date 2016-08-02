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
using LIS.MainProject.Utility.Controls.HoldMessage;
using LIS.MainProject.Utility;

namespace softwareEngineering
{
    public partial class userRegister : ChildWindow
    {
        #region 定义Model属性
        private MainPageModel _model;
        public MainPageModel Model
        {
            get { return _model; }
            set { _model = value; }
        }
        #endregion

        public userRegister(MainPageModel model)
        {
            Model = model;
            InitializeComponent();
            this.DataContext = Model;
            
            #region 注册 model 里的事件
            Model.User_InsertDataSuccess += new EventHandler<ConstsEventArgs>(model_User_InsertDataSuccess);
            Model.User_InsertDataFailure += new EventHandler<ConstsEventArgs>(model_User_InsertDataFailure);
            #endregion
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            string passwordstr = null;
            string repasswordstr = null;
            string usernamestr = null;
            if (!string.IsNullOrEmpty(password.Text ))
            {
                passwordstr = password.Text;
            }

            if (string.IsNullOrEmpty(passwordstr))
            {
                Message.ErrorMessage("提示", "请输入密码");
                return;

            }
            if (!string.IsNullOrEmpty(repassword.Text))
            {
                repasswordstr = repassword.Text;
            }

            if (string.IsNullOrEmpty(repasswordstr))
            {
                Message.ErrorMessage("提示", "请再次输入密码");
                return;

            }
            if (!string.IsNullOrEmpty(username.Text))
            {
                usernamestr = username.Text;
            }

            if (string.IsNullOrEmpty(usernamestr))
            {
                Message.ErrorMessage("提示", "请输入用户名");
                return;
            }
            if (repassword.Text == password.Text)
            {
                Model.user_list(usernamestr, passwordstr);
            }
            else {
                Message.ErrorMessage("提示", "两次输入的密码不一致！");              
            }
        }

        #region 用户注册回调后的响应方法
        void model_User_InsertDataFailure(object sender, ConstsEventArgs e)
        {
            if (!e.IsResult) //数据库错误
            {
                CommonFunction.ShowMessage(e.obj_Args_one.ToString(), Consts.ComfirmTitle);
            }
        }
        void model_User_InsertDataSuccess(object sender, ConstsEventArgs e)
        {
            this.DialogResult = true;
        }
        #endregion

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

