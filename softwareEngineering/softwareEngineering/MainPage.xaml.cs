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
using System.Windows.Media.Imaging;
using LIS.MainProject.Utility;
using softwareEngineering.Model;
using LIS.MainProject.Utility.Controls.HoldMessage;
using LIS.MainProject.Common;
using System.Collections;
using Telerik.Windows.Controls;

namespace softwareEngineering
{
    public partial class MainPage : UserControl
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
        string password = null;
        #endregion

        #region 构造函数
        public MainPage()
        {
            Model = new MainPageModel();
            InitializeComponent();
            this.DataContext = Model;

            #region 注册 model 里的事件
            Model.Event_QueryDataSuccess += new EventHandler<ConstsEventArgs>(model_Event_QueryDataSuccess);
            Model.Event_QueryDataFailure += new EventHandler<ConstsEventArgs>(model_Event_QueryDataFailure);
            #endregion
        }
        #endregion

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string user = null;

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                user = textBox1.Text;
            }

            if (string.IsNullOrEmpty(user))
            {
                Message.ErrorMessage("提示", "请输入用户名");
                return;
            }
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                password = textBox2.Text;
            }

            if (string.IsNullOrEmpty(user))
            {
                Message.ErrorMessage("提示", "请输入密码");
                return;
            }
            Model.user_QueryMulit(user, password);

        }
        #region 查询回调后的响应方法
        void model_Event_QueryDataSuccess(object sender, ConstsEventArgs e)
        {
            if (!e.IsResult) //数据库错误
            {
                Model.Md5EncryptOldPwd(password);
                App.Navigation(new FirstPage (Model));
           
            }
        }
        void model_Event_QueryDataFailure(object sender, ConstsEventArgs e)
        {
            CommonFunction.ShowMessage(e.obj_Args_one.ToString(), Consts.ComfirmTitle);
        }
        #endregion

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            userRegister ur = new userRegister(Model);
            ur.Show();
        }
      
    }
}
