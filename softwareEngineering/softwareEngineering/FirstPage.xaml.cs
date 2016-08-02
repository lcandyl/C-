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
    public partial class FirstPage : UserControl
    {
        #region 定义Model属性
        private MainPageModel _model;
        public MainPageModel Model
        {
            get { return _model; }
            set { _model = value; }
        }
        #endregion

        #region 构造函数
        public FirstPage(MainPageModel model)
        { 
            InitializeComponent();
            Model = new MainPageModel();
            Model.Event_GridHeaderComplete += new EventHandler<InvokeOperationEventArgs<string>>(GridHeaderComplete);
            Model.init();
            this.DataContext = Model;
            #region 给页面按钮添加图片
            Img_Top.Source = new BitmapImage(new Uri(GetUrl.GetAbsoluteUrl("Images/Btn_Up.png"), UriKind.Absolute));
            RadBtn_Query.Image = new BitmapImage(new Uri(GetUrl.GetAbsoluteUrl("Images/Buttons/Query32.png"), UriKind.Absolute));
            RadBtn_Insert.Image = new BitmapImage(new Uri(GetUrl.GetAbsoluteUrl("Images/Buttons/Add32.png"), UriKind.Absolute));
            RadBtn_Update.Image = new BitmapImage(new Uri(GetUrl.GetAbsoluteUrl("Images/Buttons/Edit32.png"), UriKind.Absolute));
            RadBtn_Delete.Image = new BitmapImage(new Uri(GetUrl.GetAbsoluteUrl("Images/Buttons/Delete32.png"), UriKind.Absolute));
            RadBtn_Excel.Image = new BitmapImage(new Uri(GetUrl.GetAbsoluteUrl("Images/Buttons/Excel32.png"), UriKind.Absolute));
            #endregion


            #region 注册事件
            RadBtn_Query.MouseLeftButtonDown += new MouseButtonEventHandler(RadBtn_Query_MouseLeftButtonDown);
            RadBtn_Query.Click += new System.Windows.RoutedEventHandler(RadBtn_Query_Click);
            RadBtn_Insert.Click += new System.Windows.RoutedEventHandler(RadBtn_Insert_Click);
            RadBtn_Update.Click += new System.Windows.RoutedEventHandler(RadBtn_Update_Click);
            RadBtn_Delete.Click += new System.Windows.RoutedEventHandler(RadBtn_Delete_Click);
            RadBtn_Excel.MouseLeftButtonDown += new MouseButtonEventHandler(RadBtn_Excel_Click);
            #endregion

            #region 注册model里的事件
            Model.Event_QueryDataSuccess += new EventHandler<ConstsEventArgs>(model_QueryDataSuccess);
            Model.Event_QueryDataFailure += new EventHandler<ConstsEventArgs>(model_QueryDataFailure);
            #endregion
        }
        #endregion

        #region GridHeaderComplete完成生成表头
        private void GridHeaderComplete(object sender, InvokeOperationEventArgs<string> e)
        {
            pdgResultGrid.InitDataGrid(Model.GridInfoList);
        }
        #endregion

        #region  RadBtn_Query_Click 查询按钮
        void RadBtn_Query_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RTB_ToolBar.IsEnabled = true;
            RBI_BusyBar.IsBusy = true;
            RBI_BusyBar.BusyContent = "正在查询...";

            string radDTStartTime = null;
            string radDTEndTime = null;
            string gradeID = null;
                if (!string.IsNullOrEmpty(this.radDTStartTime.DateTimeText))
                {
                    radDTStartTime = this.radDTStartTime.DateTimeText;
                }
                if (!string.IsNullOrEmpty(this.radDTEndTime.DateTimeText))
                {
                    radDTEndTime = this.radDTEndTime.DateTimeText;
                }
                if (radDTStartTime != null && radDTEndTime != null)
                {
                    if (Convert.ToDateTime(radDTStartTime) > Convert.ToDateTime(radDTEndTime))
                    {
                        this.RBI_BusyBar.IsBusy = false;
                        CommonFunction.ShowMessage("开始时间不能大于结束时间！", "提示");
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(Model.GradeID))
                { gradeID = (Model.GradeID); }
                else { gradeID = "全部"; }
                Model.QueryMulit(radDTStartTime, radDTEndTime, gradeID);
        }

        void RadBtn_Query_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RadBtn_Query.Focus();
        }
        #endregion

        #region RadBtn_Insert_Click 新增按钮
        void RadBtn_Insert_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            InsertPage ip = new InsertPage(Model);
            ip.Show();
        }
        #endregion 

        #region RadBtn_Update_Click 编辑按钮
        void RadBtn_Update_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdatePage up = new UpdatePage(Model);
            up.Show();
        }
        #endregion 

        #region RadBtn_Delete_Click 删除按钮
        void RadBtn_Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DeletePage dp = new DeletePage(Model);
            dp.Show();
        }
        #endregion

        #region 查询回调后的响应方法

        void model_QueryDataFailure(object sender, ConstsEventArgs e)
        {
            RBI_BusyBar.IsBusy = false;
            Message.ErrorMessage(Consts.ErrorNoData, e.obj_Args_one.ToString());
        }

        void model_QueryDataSuccess(object sender, ConstsEventArgs e)
        {
            RBI_BusyBar.IsBusy = false;
        }

        #endregion

        # region RadBtn_Excel_Click 输出excel
        void RadBtn_Excel_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Model.GridItemsSource.Count == 0)
                {
                    CommonFunction.ShowMessage(HONEConsts.ErrorNoDataExcel, HONEConsts.SystemPrompt);
                    return;
                }
                ExcelHelper excelHelper = new ExcelHelper(Model.GridInfoList);
                excelHelper.EntityList = Model.GridItemsSource as IList;
                excelHelper.Title = System.DateTime.Now.ToString("yyyy年MM月dd日") + "采购管理信息";//表头
                excelHelper.FileName = "采购管理系统";//工作表名
                excelHelper.ExportExcel();
            }
            catch (Exception ex)
            {
                CommonFunction.ShowMessage(ex.Message, HONEConsts.SystemPrompt);
            }
        }
        #endregion  
    }
}
