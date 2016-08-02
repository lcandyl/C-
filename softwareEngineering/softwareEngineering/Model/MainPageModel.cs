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
using LIS.MainProject.Service;
using LIS.MainProject.Utility;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LIS.MainProject.DTO.SysConfig;
using softwareEngineering.DTO;
using System.Xml.Linq;
using System.ServiceModel.DomainServices.Client;
using Silverlight;
using System.Collections;

namespace softwareEngineering.Model
{
    public class MainPageModel : ModelBase
    {

        #region GridInfoList 表格标题列表
        private List<GridInfo> _gridInfoList;
        public List<GridInfo> GridInfoList
        {
            get { return _gridInfoList; }
            set
            {
                if (value != _gridInfoList)
                {
                    _gridInfoList = value;
                    this.RaisePropertyChanged("GridInfoList");
                }
            }
        }
        #endregion

        #region grid 数据源
        private ObservableCollection<object> _gridItemsSource;
        public ObservableCollection<object> GridItemsSource
        {
            get
            {
                if (_gridItemsSource == null)
                {
                    _gridItemsSource = new ObservableCollection<object>();
                }
                return _gridItemsSource;
            }
            set
            {
                _gridItemsSource = value;
                this.RaisePropertyChanged("GridItemsSource");
            }
        }
        #endregion

        #region HeaderList表头信息列表
        private ObservableCollection<TB_Table_DTO> _headerList;
        public ObservableCollection<TB_Table_DTO> HeaderList
        {
            get { return _headerList; }
            set
            {
                if (value != _headerList)
                {
                    _headerList = value;
                    this.RaisePropertyChanged("HeaderList");
                }
            }
        }
        #endregion

        #region Available 是否可用
        private bool _available;
        public bool Available
        {
            get
            {
                return _available;
            }
            set
            {
                _available = value;
                this.RaisePropertyChanged("Available");
            }
        }
        private bool _vailable;
        public bool Vailable
        {
            get
            {
                return _vailable;
            }
            set
            {
                _vailable = value;
                this.RaisePropertyChanged("Vailable");
            }
        }
        #endregion

        #region 等级

        #region GradeID 属性
        private string _GradeID;
        public string GradeID
        {
            get
            {
                return _GradeID;
            }
            set
            {
                if (value != GradeID)
                {
                    _GradeID = value;
                    this.RaisePropertyChanged("GradeID");
                }
            }
        }
        #endregion

        #region SelectclItem 显示框SelectclItem
        public SelectclItemDTO SelectclItem
        {
            get
            {
                return SelectGradeIDDTO(GradeID, SelectclItemList, true);
            }
            set
            {          
                if (value != null)
                {
                    GradeID = value.ID;
                    this.RaisePropertyChanged("SelectclItem");
                }
            }
        }
        #endregion

        #region gradeItem 显示框gradeItem
        public SelectclItemDTO gradeItem
        {
            get
            {
                return SelectGradeIDDTO(GradeID, gradeItemList, true);
            }
            set
            {
                if (value != null)
                {
                    GradeID = value.ID;
                    this.RaisePropertyChanged("gradeItem");
                }
            }
        }
        #endregion

        #region SelectclItemList 等级表
        private ObservableCollection<SelectclItemDTO> _SelectclItemList;
        public ObservableCollection<SelectclItemDTO> SelectclItemList
        {
            get
            {
                if (_SelectclItemList == null)
                {
                    _SelectclItemList = new ObservableCollection<SelectclItemDTO>();
                    _SelectclItemList.Add(new SelectclItemDTO("全部"));
                    _SelectclItemList.Add(new SelectclItemDTO("一等品"));
                    _SelectclItemList.Add(new SelectclItemDTO("二等品"));
                    _SelectclItemList.Add(new SelectclItemDTO("三等品"));
                    _SelectclItemList.Add(new SelectclItemDTO("四等品"));

                }
                return _SelectclItemList;
            }
            set
            {
                _SelectclItemList = value;
                this.RaisePropertyChanged("SelectclItemList");
            }
        }
        #endregion

        #region gradeItemList 等级表
        private ObservableCollection<SelectclItemDTO> _gradeItemList;
        public ObservableCollection<SelectclItemDTO> gradeItemList
        {
            get
            {
                if (_gradeItemList == null)
                {
                    _gradeItemList = new ObservableCollection<SelectclItemDTO>();
                    _gradeItemList.Add(new SelectclItemDTO("一等品"));
                    _gradeItemList.Add(new SelectclItemDTO("二等品"));
                    _gradeItemList.Add(new SelectclItemDTO("三等品"));
                    _gradeItemList.Add(new SelectclItemDTO("四等品"));

                }
                return _gradeItemList;
            }
            set
            {
                _gradeItemList = value;
                this.RaisePropertyChanged("gradeItemList");
            }
        }
        #endregion

        #region SelectGradeIDDTO 获取等级表数据
        public static SelectclItemDTO SelectGradeIDDTO(string id, IList<SelectclItemDTO> list, bool allowNull)
        {
            foreach (SelectclItemDTO item in list)
            {
                if (item.ID.Equals(id))
                {
                    return item;
                }
            }
            if (allowNull)
            {
                return null;
            }
            else
            {
                return list[0];
            }
        }
        #endregion

        #endregion

        #region 构造函数
        public MainPageModel()
        {
            GridInfoList = new List<GridInfo>();
        }
        #endregion

        #region init 初始化表头信息
        public void init()
        {
            HeaderList = new ObservableCollection<TB_Table_DTO>();
            HeaderList.Add(new TB_Table_DTO() { Title = "进货编号", Alignment = "Right", DataColumn = "stocknumber", Width = 90, OrderBy = 1 });
            HeaderList.Add(new TB_Table_DTO() { Title = "生产地", Alignment = "Left", DataColumn = "producingarea", Width = 90, OrderBy = 2 });
            HeaderList.Add(new TB_Table_DTO() { Title = "货物名称", Alignment = "Left", DataColumn = "goodname", Width = 90, OrderBy = 3 });
            HeaderList.Add(new TB_Table_DTO() { Title = "生产日期", Alignment = "Right", DataColumn = "productiondate", Width = 90, OrderBy = 4 });
            HeaderList.Add(new TB_Table_DTO() { Title = "所属类别", Alignment = "Left", DataColumn = "category", Width = 90, OrderBy = 5 });
            HeaderList.Add(new TB_Table_DTO() { Title = "过期日期", Alignment = "Right", DataColumn = "deadline", Width = 90, OrderBy = 6 });
            HeaderList.Add(new TB_Table_DTO() { Title = "等级", Alignment = "Left", DataColumn = "grade", Width = 90, OrderBy = 7 });
            HeaderList.Add(new TB_Table_DTO() { Title = "进货日期", Alignment = "Right", DataColumn = "stockdate", Width = 90, OrderBy = 8 });
            HeaderList.Add(new TB_Table_DTO() { Title = "单位", Alignment = "Left", DataColumn = "unit", Width = 90, OrderBy = 9 });
            HeaderList.Add(new TB_Table_DTO() { Title = "进货人", Alignment = "Left", DataColumn = "stockperson", Width = 90, OrderBy = 10 });
            HeaderList.Add(new TB_Table_DTO() { Title = "单价\n(元)", Alignment = "Right", DataColumn = "unitprice", Width = 90, OrderBy = 11 });
            HeaderList.Add(new TB_Table_DTO() { Title = "供货商", Alignment = "Left", DataColumn = "supplyperson", Width = 90, OrderBy = 12 });
            HeaderList.Add(new TB_Table_DTO() { Title = "数量", Alignment = "Right", DataColumn = "quantity", Width = 90, OrderBy = 13 });
            HeaderList.Add(new TB_Table_DTO() { Title = "金额合计\n(元)", Alignment = "Right", DataColumn = "moneyamount", Width = 90, OrderBy = 14 });
            HeaderList.Add(new TB_Table_DTO() { Title = "备注", Alignment = "Left", DataColumn = "remark", Width = 90, OrderBy = 15 });
            CreateGridHeader();
        }
        #endregion

        #region 根据表头信息生成表头
        private void CreateGridHeader()
        {
            GridInfoList.Clear();
            GridInfo gridInfo = new GridInfo();

            if (HeaderList.Count > 0)
            {
                foreach (TB_Table_DTO item in HeaderList)
                {
                    Align align;
                    switch (item.Alignment.ToLower())
                    {
                        case "left": align = Align.Left; break;
                        case "right": align = Align.Right; break;
                        case "center": align = Align.Center; break;
                        default: align = Align.Center; break;
                    }
                    gridInfo = new GridInfo() { Field = item.DataColumn, FieldText = item.Title, Align = align, FieldsWidth = (int)item.Width, Unit = item.Units, OrderBy = item.OrderBy };
                    GridInfoList.Add(gridInfo);
                }

            }
            if (Event_GridHeaderComplete != null)
            {
                Event_GridHeaderComplete(this, null);
            }
        }
        #endregion

        #region 查询数据方法、回调
        #region 查询方法
        public void QueryMulit(string radDTStartTime, string radDTEndTime, string gradeID)
        {

            XElement xelement = new XElement(Consts.ParamRoot);

            if (!string.IsNullOrEmpty (radDTStartTime))
            {
                xelement.SetAttributeValue("radDTStartTime", radDTStartTime);
            }
            if (!string.IsNullOrEmpty (gradeID))
            {
                xelement.SetAttributeValue("gradeID", gradeID);
            }
            if (!string.IsNullOrEmpty (radDTEndTime))
            {
                xelement.SetAttributeValue("radDTEndTime", radDTEndTime);
            }

            this.Context.QueryEntityByXML(xelement.ToString(), "SP_TD_softwareEngineering_S_M", r =>
            {
                QueryMulitCallBack(r);

            }, null);
        }

        #endregion

        #region 查询回调
        private void QueryMulitCallBack(InvokeOperation<string> e)
        {
            if (!e.HasError)
            {
                DataSet ds = new DataSet();
                ReturnInfo returnInfo = new ReturnInfo(e.Value);
                if (returnInfo.IsSuccess)
                {
                    ds.FromXml(returnInfo.Message);
                    GridItemsSource.Clear();

                    if (ds.Tables.Count > 0)
                    {
                        DataTable dataTable = ds.Tables[0];
                        IList temp = dataTable.GetBindableData(new Connector());
                        foreach (object item in temp)
                        {
                            GridItemsSource.Add(item);
                        }
                        if (GridItemsSource.Count > 0)
                        {
                            Available = true;
                        }
                        else
                        {
                            Available = false;
                        }
                    }
                    if (Event_QueryDataSuccess != null)        //成功事件
                    {
                        Event_QueryDataSuccess(e.UserState, new ConstsEventArgs() { });
                    }
                }
                else   //查询存储过程里的定义的失败
                {
                    if (Event_QueryDataFailure != null)    //失败事件
                    {
                        Event_QueryDataFailure(e.UserState, new ConstsEventArgs() { IsResult = true, obj_Args_one = returnInfo.Message });
                    }
                }
            }
            else    //查询失败,数据库原因
            {
                if (Event_QueryDataFailure != null)    //失败事件
                {
                    Event_QueryDataFailure(e.UserState, new ConstsEventArgs() { IsResult = false, obj_Args_one = e.Error.Message });
                }
            }
        }
        #endregion
        #endregion

        #region 修改信息中查询数据方法、回调
        #region 查询方法
        public void QueryMulit_Up(string stocknumber1, string stockdate1)
        {
            XElement xelement = new XElement(Consts.ParamRoot);

            if (stocknumber1 != null)
            {
                xelement.SetAttributeValue("stocknumber1", stocknumber1);
            }
            if (stockdate1 != null)
            {
                xelement.SetAttributeValue("stockdate1", stockdate1);
            }

            this.Context.QueryEntityByXML(xelement.ToString(), "SP_TD_softwareEngineering_Up_S_M", r =>
            {
                QueryMulitCallBack_Up(r);

            }, null);
        }

        #endregion

        #region 查询回调
        private void QueryMulitCallBack_Up(InvokeOperation<string> e)
        {
            if (!e.HasError)
            {
                DataSet ds = new DataSet();
                ReturnInfo returnInfo = new ReturnInfo(e.Value);
                if (returnInfo.IsSuccess)
                {
                    ds.FromXml(returnInfo.Message);
                    GridItemsSource.Clear();

                    if (ds.Tables.Count > 0)
                    {
                        DataTable dataTable = ds.Tables[0];
                        IList temp = dataTable.GetBindableData(new Connector());
                        foreach (object item in temp)
                        {
                            GridItemsSource.Add(item);
                        }
                        if (GridItemsSource.Count > 0)
                        {
                            Vailable = true;
                        }
                        else
                        {
                            Vailable = false;
                        }
                    }
                    if (Event_QueryDataSuccess != null)        //成功事件
                    {
                        Event_QueryDataSuccess(e.UserState, new ConstsEventArgs() {
                        });
                        CommonFunction.ShowMessage("现可编辑该条数据", Consts.ComfirmTitle);
                    }
                }
                else   //查询存储过程里的定义的失败
                {
                    if (Event_QueryDataFailure != null)    //失败事件
                    {
                        Event_QueryDataFailure(e.UserState, new ConstsEventArgs() { IsResult = true, obj_Args_one = returnInfo.Message });
                    }
                }
            }
            else    //查询失败,数据库原因
            {
                if (Event_QueryDataFailure != null)    //失败事件
                {
                    Event_QueryDataFailure(e.UserState, new ConstsEventArgs() { IsResult = false, obj_Args_one = e.Error.Message });
                }
            }
        }
        #endregion
        #endregion

        #region 修改数据方法、回调
        #region 修改方法
        public void Update(string stocknumberStr, string producingareaStr,
               string goodnameStr, string productiondateStr, string deadlineStr,
                string categoryStr, string gradeStr, string stockdateStr, string unitStr,
               string stockpersonStr, string unitpriceStr, string supplypersonStr,
               string quantityStr, string moneyamountStr, string remarkStr)
        {
            string PrimayKey = Guid.NewGuid().ToString();
            XElement xelement = new XElement(Consts.ParamRoot);
            xelement.SetAttributeValue("stocknumberStr", stocknumberStr);
            xelement.SetAttributeValue("producingareaStr", producingareaStr);
            xelement.SetAttributeValue("goodnameStr", goodnameStr);
            xelement.SetAttributeValue("productiondateStr", productiondateStr);
            xelement.SetAttributeValue("deadlineStr", deadlineStr);
            xelement.SetAttributeValue("categoryStr", categoryStr);
            xelement.SetAttributeValue("gradeStr", gradeStr);
            xelement.SetAttributeValue("stockdateStr", stockdateStr);
            xelement.SetAttributeValue("unitStr", unitStr);
            xelement.SetAttributeValue("stockpersonStr", stockpersonStr);
            xelement.SetAttributeValue("unitpriceStr", unitpriceStr);
            xelement.SetAttributeValue("supplypersonStr", supplypersonStr);
            xelement.SetAttributeValue("quantityStr", quantityStr);
            xelement.SetAttributeValue("moneyamountStr", moneyamountStr);
            xelement.SetAttributeValue("remarkStr", remarkStr);
            string strXML = xelement.ToString();
            string UpdateParm = strXML;   //根据自己需要整理参数
            this.Context.UpdateEntity(UpdateParm, "SP_TD_softwareEngineering_U", r =>
            {
                UpdateCallBack(r, PrimayKey);

            }, null);
        }
        #endregion

        #region 修改回调
        private void UpdateCallBack(InvokeOperation<string> e, string PrimayKey)
        {

            if (!e.HasError)
            {
                ReturnInfo returnInfo = new ReturnInfo(e.Value);

                if (returnInfo.IsSuccess)
                {
                    if (UpdateDataSuccess != null)    //成功事件
                    {
                        UpdateDataSuccess(e.UserState, new ConstsEventArgs() { });
                    }
                }
                else
                {
                    if (UpdateDataFailure != null)    //失败事件
                    {
                        UpdateDataFailure(e.UserState, new ConstsEventArgs() { IsResult = false, obj_Args_one = returnInfo.Message });
                    }
                }
            }
        }
        #endregion
        #endregion

        #region 新增数据方法、回调
        #region 新增方法
        public void Insert(string stocknumberStr,string  producingareaStr,
               string  goodnameStr, string productiondateStr,string  deadlineStr,
                string categoryStr, string gradeStr,string  stockdateStr,string  unitStr ,
               string  stockpersonStr, string unitpriceStr, string supplypersonStr,
               string quantityStr, string moneyamountStr, string remarkStr)
        {
            string PrimayKey = Guid.NewGuid().ToString();
            XElement xelement = new XElement(Consts.ParamRoot);
            xelement.SetAttributeValue("stocknumberStr", stocknumberStr);
            xelement.SetAttributeValue("producingareaStr", producingareaStr);
            xelement.SetAttributeValue("goodnameStr", goodnameStr);
            xelement.SetAttributeValue("productiondateStr", productiondateStr);
            xelement.SetAttributeValue("deadlineStr", deadlineStr);
            xelement.SetAttributeValue("categoryStr", categoryStr);
            xelement.SetAttributeValue("gradeStr", gradeStr);
            xelement.SetAttributeValue("stockdateStr", stockdateStr);
            xelement.SetAttributeValue("unitStr", unitStr);
            xelement.SetAttributeValue("stockpersonStr", stockpersonStr);
            xelement.SetAttributeValue("unitpriceStr", unitpriceStr);
            xelement.SetAttributeValue("supplypersonStr", supplypersonStr);
            xelement.SetAttributeValue("quantityStr", quantityStr);
            xelement.SetAttributeValue("moneyamountStr", moneyamountStr);
            xelement.SetAttributeValue("remarkStr", remarkStr);

            string strXML = xelement.ToString();
            string InsertParm = strXML;   //根据自己需要整理参数
            this.Context.InsertEntity(InsertParm, "SP_TD_softwareEngineering__I", r =>
            {
                InsertCallBack(r, PrimayKey);

            }, null);
        }
        #endregion

        #region 新增回调
        private void InsertCallBack(InvokeOperation<string> e, string PrimayKey)
        {

            if (!e.HasError)
            {
                ReturnInfo returnInfo = new ReturnInfo(e.Value);

                if (returnInfo.IsSuccess)
                {
                    if (InsertDataSuccess != null)    //成功事件
                    {
                        InsertDataSuccess(e.UserState, new ConstsEventArgs() { });
                    }
                }
                else
                {
                    if (InsertDataFailure != null)    //失败事件
                    {
                        InsertDataFailure(e.UserState, new ConstsEventArgs() { IsResult = false, obj_Args_one = returnInfo.Message });
                    }
                }
            }
        }
        #endregion
        #endregion

        #region 删除数据方法、回调
        #region 删除方法
        public void Delete(string stocknumberStr , string stockdateStr)
        {
            string PrimayKey = Guid.NewGuid().ToString();
            XElement xelement = new XElement(Consts.ParamRoot);
            xelement.SetAttributeValue("stocknumberStr", stocknumberStr);        
            xelement.SetAttributeValue("stockdateStr", stockdateStr);
          

            string strXML = xelement.ToString();
            string InsertParm = strXML;   //根据自己需要整理参数
            this.Context.InsertEntity(InsertParm, "SP_TD_softwareEngineering__D", r =>
            {
                DeleteCallBack(r, PrimayKey);

            }, null);
        }
        #endregion

        #region 删除回调
        private void DeleteCallBack(InvokeOperation<string> e, string PrimayKey)
        {

            if (!e.HasError)
            {
                ReturnInfo returnInfo = new ReturnInfo(e.Value);

                if (returnInfo.IsSuccess)
                {
                    if (DeleteDataSuccess != null)    //成功事件
                    {
                        DeleteDataSuccess(e.UserState, new ConstsEventArgs() { });
                    }
                }
                else
                {
                    if (DeleteDataFailure != null)    //失败事件
                    {
                        DeleteDataFailure(e.UserState, new ConstsEventArgs() { 
                            IsResult = false, obj_Args_one = returnInfo.Message 
                        });
                    }
                }
            }
        }
        #endregion
        #endregion

        #region 用户查询方法、回调
         #region 用户查询方法
        public void user_QueryMulit(string userStr, string passwordStr)
        {

            XElement xelement = new XElement(Consts.ParamRoot);

            if (!string.IsNullOrEmpty(userStr))
            {
                xelement.SetAttributeValue("userStr", userStr);
            }
            if (!string.IsNullOrEmpty(passwordStr))
            {
                xelement.SetAttributeValue("passwordStr", passwordStr);
            }

            this.Context.QueryEntityByXML(xelement.ToString(), "SP_TD_softwareEngineering_S_M_user", r =>
            {
                Query_MulitCallBack(r);

            }, null);
        }

        #endregion

        #region 用户查询回调
        private void Query_MulitCallBack(InvokeOperation<string> e)
        {
            if (!e.HasError)
            {
                DataSet ds = new DataSet();
                ReturnInfo returnInfo = new ReturnInfo(e.Value);
                if (returnInfo.IsSuccess)
                {
                    ds.FromXml(returnInfo.Message);
                    GridItemsSource.Clear();

                    if (ds.Tables.Count > 0)
                    {
                        DataTable dataTable = ds.Tables[0];
                        IList temp = dataTable.GetBindableData(new Connector());
                        foreach (object item in temp)
                        {
                            GridItemsSource.Add(item);
                        }
                        if (GridItemsSource.Count > 0)
                        {
                            Available = true;
                        }
                        else
                        {
                            Available = false;
                        }
                    }
                    if (Event_QueryDataSuccess != null)        //成功事件
                    {
                        Event_QueryDataSuccess(e.UserState, new ConstsEventArgs() { });
                    }
                }
                else   //查询存储过程里的定义的失败
                {
                    if (Event_QueryDataFailure != null)    //失败事件
                    {
                        Event_QueryDataFailure(e.UserState, new ConstsEventArgs() { IsResult = true, obj_Args_one = returnInfo.Message });
                    }
                }
            }
            else    //查询失败,数据库原因
            {
                if (Event_QueryDataFailure != null)    //失败事件
                {
                    Event_QueryDataFailure(e.UserState, new ConstsEventArgs() { IsResult = false, obj_Args_one = e.Error.Message });
                }
            }
        }
        
        #endregion
        #endregion

        #region 用户注册方法、回调
        #region 用户注册方法
        public void user_list(string usernamestr, string passwordstr)
        {

            XElement xelement = new XElement(Consts.ParamRoot);

            if (!string.IsNullOrEmpty(usernamestr))
            {
                xelement.SetAttributeValue("usernamestr", usernamestr);
            }
            if (!string.IsNullOrEmpty(passwordstr))
            {
                xelement.SetAttributeValue("passwordstr", passwordstr);
            }

            this.Context.InsertEntity (xelement.ToString(), "SP_TD_softwareEngineering_User_I", r =>
            {
                user_listCallBack(r);

            }, null);
        }

        #endregion

        #region 用户注册回调
        private void user_listCallBack(InvokeOperation<string> e)
        {
            if (!e.HasError)
            {
                ReturnInfo returnInfo = new ReturnInfo(e.Value);

                if (returnInfo.IsSuccess)
                {
                    if (User_InsertDataSuccess != null)    //成功事件
                    {
                        User_InsertDataSuccess(e.UserState, new ConstsEventArgs() { });
                    }
                }
                else
                {
                    if (User_InsertDataFailure != null)    //失败事件
                    {
                        User_InsertDataFailure(e.UserState, new ConstsEventArgs() { IsResult = false, obj_Args_one = returnInfo.Message });
                    }
                }
            }
        }
        #endregion
        #endregion
        #region 密码加密
        public void Md5EncryptOldPwd(string password)
        {

            // 对新密码进行MD5加密
            Context.Md5Encrypt(password, r =>
            {
                Md5EncryptOldPwdComplete(this, r);
            }, null);
        }
         public void Md5EncryptOldPwdComplete(object sender, InvokeOperation<string> e)
        {
            if (e.HasError == false)
            {
                ReturnInfo ri = new ReturnInfo(e.Value);
                if (ri.IsSuccess == true)
                {
                    string password = string.Empty;
                    password = ri.Message;
                    if (EventMd5EncryptComplete != null)
                    {
                        EventMd5EncryptComplete(password, null);
                    }
                }
                else
                {
                    CommonFunction.ShowMessage(ri.Message); 
                    return;
                }
            }
            else
            {
                CommonFunction.ShowException("密码加密失败。", e.Error);
                return;
            }
        }
        #endregion

        #region 事件
        public event EventHandler<ConstsEventArgs> Event_QueryDataSuccess;
        public event EventHandler<ConstsEventArgs> Event_QueryDataFailure;
        public event EventHandler<ConstsEventArgs> InsertDataSuccess;
        public event EventHandler<ConstsEventArgs> InsertDataFailure;
        public event EventHandler<ConstsEventArgs> User_InsertDataSuccess;
        public event EventHandler<ConstsEventArgs> User_InsertDataFailure;
        public event EventHandler<ConstsEventArgs> UpdateDataSuccess;
        public event EventHandler<ConstsEventArgs> UpdateDataFailure;
        public event EventHandler<ConstsEventArgs> DeleteDataSuccess;
        public event EventHandler<ConstsEventArgs> DeleteDataFailure;  
        public event EventHandler<InvokeOperationEventArgs<string>> EventMd5EncryptComplete;
        public event EventHandler<InvokeOperationEventArgs<string>> Event_GridHeaderComplete;
        #endregion

    }
}
