USE [SoftwareEngineering]
GO
/****** Object:  Table [dbo].[userlist]    Script Date: 08/21/2013 15:10:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[userlist](
	[user] [varchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[userlist] ([user], [password]) VALUES (N'1', N'1')
INSERT [dbo].[userlist] ([user], [password]) VALUES (N'2', N'1')
INSERT [dbo].[userlist] ([user], [password]) VALUES (N'1', N'33')
INSERT [dbo].[userlist] ([user], [password]) VALUES (N'5', N'5')
/****** Object:  Table [dbo].[stocklist]    Script Date: 08/21/2013 15:10:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stocklist](
	[stocknumber] [nvarchar](50) NOT NULL,
	[producingarea] [nvarchar](50) NOT NULL,
	[goodname] [nvarchar](50) NOT NULL,
	[productiondate] [date] NOT NULL,
	[deadline] [date] NULL,
	[category] [nvarchar](50) NULL,
	[grade] [nchar](10) NULL,
	[stockdate] [date] NULL,
	[unit] [nchar](10) NULL,
	[stockperson] [nchar](10) NOT NULL,
	[unitprice] [numeric](18, 2) NOT NULL,
	[supplyperson] [nvarchar](50) NOT NULL,
	[quantity] [int] NOT NULL,
	[moneyamount] [numeric](18, 2) NOT NULL,
	[remark] [nvarchar](50) NULL
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'进货编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'stocknumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产地' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'producingarea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'goodname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'productiondate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'过期日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'deadline'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'grade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'进货日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'stockdate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'unit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'进货人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'stockperson'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'unitprice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供货商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'supplyperson'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'quantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'金额合计' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'moneyamount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'stocklist', @level2type=N'COLUMN',@level2name=N'remark'
GO
INSERT [dbo].[stocklist] ([stocknumber], [producingarea], [goodname], [productiondate], [deadline], [category], [grade], [stockdate], [unit], [stockperson], [unitprice], [supplyperson], [quantity], [moneyamount], [remark]) VALUES (N'11111', N'1', N'1', CAST(0x81370B00 AS Date), CAST(0x74370B00 AS Date), N'1', N'三等品       ', CAST(0x7C370B00 AS Date), N'1         ', N'1         ', CAST(1.00 AS Numeric(18, 2)), N'1', 1, CAST(1.00 AS Numeric(18, 2)), N'1')
INSERT [dbo].[stocklist] ([stocknumber], [producingarea], [goodname], [productiondate], [deadline], [category], [grade], [stockdate], [unit], [stockperson], [unitprice], [supplyperson], [quantity], [moneyamount], [remark]) VALUES (N'1112', N'1', N'1', CAST(0x81370B00 AS Date), CAST(0x74370B00 AS Date), N'1', N'三等品       ', CAST(0x7C370B00 AS Date), N'1         ', N'1         ', CAST(1.00 AS Numeric(18, 2)), N'1', 1, CAST(1.00 AS Numeric(18, 2)), N'1')
INSERT [dbo].[stocklist] ([stocknumber], [producingarea], [goodname], [productiondate], [deadline], [category], [grade], [stockdate], [unit], [stockperson], [unitprice], [supplyperson], [quantity], [moneyamount], [remark]) VALUES (N'112', N'美国', N'提子', CAST(0xB5360B00 AS Date), CAST(0xF2360B00 AS Date), NULL, N'一等品       ', CAST(0x63350B00 AS Date), NULL, N'李想        ', CAST(3.00 AS Numeric(18, 2)), N'张三', 5, CAST(15.00 AS Numeric(18, 2)), N'2')
INSERT [dbo].[stocklist] ([stocknumber], [producingarea], [goodname], [productiondate], [deadline], [category], [grade], [stockdate], [unit], [stockperson], [unitprice], [supplyperson], [quantity], [moneyamount], [remark]) VALUES (N'2', N'3', N'4', CAST(0x74370B00 AS Date), CAST(0x7A370B00 AS Date), N'', N'三等品       ', CAST(0x7B370B00 AS Date), N'3         ', N'4         ', CAST(3.00 AS Numeric(18, 2)), N'3', 2, CAST(5.00 AS Numeric(18, 2)), N'4')
INSERT [dbo].[stocklist] ([stocknumber], [producingarea], [goodname], [productiondate], [deadline], [category], [grade], [stockdate], [unit], [stockperson], [unitprice], [supplyperson], [quantity], [moneyamount], [remark]) VALUES (N'3', N'1', N'1', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date), N'1', N'一等品       ', CAST(0x5B950A00 AS Date), N'1         ', N'1         ', CAST(1.00 AS Numeric(18, 2)), N'1', 1, CAST(1.00 AS Numeric(18, 2)), N'1')
INSERT [dbo].[stocklist] ([stocknumber], [producingarea], [goodname], [productiondate], [deadline], [category], [grade], [stockdate], [unit], [stockperson], [unitprice], [supplyperson], [quantity], [moneyamount], [remark]) VALUES (N'', N'1', N'1', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date), N'1', N'一等品       ', CAST(0x5B950A00 AS Date), N'1         ', N'1         ', CAST(1.00 AS Numeric(18, 2)), N'1', 1, CAST(1.00 AS Numeric(18, 2)), N'1')
INSERT [dbo].[stocklist] ([stocknumber], [producingarea], [goodname], [productiondate], [deadline], [category], [grade], [stockdate], [unit], [stockperson], [unitprice], [supplyperson], [quantity], [moneyamount], [remark]) VALUES (N'6', N'6', N'6', CAST(0x7A370B00 AS Date), CAST(0x7A370B00 AS Date), N'6', N'一等品       ', CAST(0x7A370B00 AS Date), N'6         ', N'6         ', CAST(6.00 AS Numeric(18, 2)), N'66', 6, CAST(36.00 AS Numeric(18, 2)), N'6')
INSERT [dbo].[stocklist] ([stocknumber], [producingarea], [goodname], [productiondate], [deadline], [category], [grade], [stockdate], [unit], [stockperson], [unitprice], [supplyperson], [quantity], [moneyamount], [remark]) VALUES (N'77', N'7', N'7', CAST(0x7A370B00 AS Date), CAST(0x7D370B00 AS Date), N'7', N'一等品       ', CAST(0x7A370B00 AS Date), N'7         ', N'7         ', CAST(7.00 AS Numeric(18, 2)), N'7', 7, CAST(49.00 AS Numeric(18, 2)), N'7')
INSERT [dbo].[stocklist] ([stocknumber], [producingarea], [goodname], [productiondate], [deadline], [category], [grade], [stockdate], [unit], [stockperson], [unitprice], [supplyperson], [quantity], [moneyamount], [remark]) VALUES (N'123432', N'4', N'33', CAST(0x78370B00 AS Date), CAST(0x83370B00 AS Date), N'3', N'一等品       ', CAST(0x7A370B00 AS Date), N'4         ', N'4         ', CAST(4.00 AS Numeric(18, 2)), N'4', 4, CAST(16.00 AS Numeric(18, 2)), N'4')
INSERT [dbo].[stocklist] ([stocknumber], [producingarea], [goodname], [productiondate], [deadline], [category], [grade], [stockdate], [unit], [stockperson], [unitprice], [supplyperson], [quantity], [moneyamount], [remark]) VALUES (N'0', N'0', N'0', CAST(0x84370B00 AS Date), CAST(0x74370B00 AS Date), N'0', N'一等品       ', CAST(0x7A370B00 AS Date), N'0         ', N'0         ', CAST(0.00 AS Numeric(18, 2)), N'0', 0, CAST(0.00 AS Numeric(18, 2)), N'0')
/****** Object:  StoredProcedure [dbo].[SP_TD_softwareEngineering_User_I]    Script Date: 08/21/2013 15:10:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		zq
-- Create date: 2012-08-20
-- Description:	采购管理系统-新增
--<Param deptNo="11111111-1111-1111-1111-111111111111" ID="7a3a70e7-9172-444a-be2f-9c38a842eed5" RotationId="2" yearStr="2012" WaterSum="879" userId="11111111-1111-1111-1111-111111111111" />
-- =============================================
CREATE PROCEDURE [dbo].[SP_TD_softwareEngineering_User_I]
	 @strXmlPara    ntext,
     @OutMsg        varchar(8000) output,
     @OutCode       bit output
AS
BEGIN
	SET NOCOUNT ON;
	Begin try
		Declare @xml xml
		Declare @usernamestr varchar(50)
		Declare @passwordstr varchar(50)
					
		Set @xml = Convert(xml, @strXmlPara)
		Set @usernamestr = (@xml.value('(/Param/@usernamestr)[1]', 'varchar(50)'))
		Set @passwordstr = (@xml.value('(/Param/@passwordstr)[1]', 'varchar(50)'))		
		
		If exists
		(
			Select 1 
				from dbo.userlist
				where  [user] = @usernamestr
		)
		
		Begin
			Declare @errorMess nvarchar(100)
			Set @errorMess =  CAST(@usernamestr as varchar(10)) + '用户名已存在'
			RAISERROR(@errorMess, 16, 1)
			Return
		End
	
		Insert into dbo.userlist values 
		(
		@usernamestr,
		@passwordstr
		)
		
        Set @OutCode=1       
        Set @OutMsg = '保存成功。'
   End try
   Begin catch
      Set @OutCode = 0
      Set @OutMsg = '保存失败。原因：' + ERROR_MESSAGE() 
   End catch             
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TD_softwareEngineering_Up_S_M]    Script Date: 08/21/2013 15:10:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		zq
-- Create date: 2013-08-14
-- Description:	采购查询(多条)
--<Param radDTEndTime="2014/8/27" />
-- =============================================
create PROCEDURE [dbo].[SP_TD_softwareEngineering_Up_S_M]
	 @strXmlPara    ntext,
     @OutMsg        varchar(8000) output,
     @OutCode       bit output
AS
BEGIN
	SET NOCOUNT ON;
	
	Begin try
		Declare @xml xml
		Declare @stocknumber1 varchar(50)
		Declare @stockdate1 varchar(50)
						
		Set @xml = Convert(xml, @strXmlPara)
		Set @stocknumber1 = (@xml.value('(/Param/@stocknumber1)[1]', 'varchar(50)'))
		Set @stockdate1 = (@xml.value('(/Param/@stockdate1)[1]', 'varchar(50)'))
			
		if not exists( select stocknumber, producingarea, goodname,   convert(varchar(10),productiondate,120)productiondate,
	    category, convert(varchar(10),deadline,120)deadline,  grade,  convert(varchar(10),stockdate,120)stockdate, unit, stockperson, unitprice, 
	    supplyperson, quantity, moneyamount, remark from dbo.stocklist where stocknumber = @stocknumber1 and  stockdate = @stockdate1 )
	    begin
	    Declare @errorMess nvarchar(100)
			Set @errorMess = '该条记录不存在,若想保存请单击新增按钮'
			RAISERROR(@errorMess, 16, 1)
			Return 
	    end
	    else 
	    select stocknumber, producingarea, goodname,   convert(varchar(10),productiondate,120)productiondate,
	    category, convert(varchar(10),deadline,120)deadline,  grade,  convert(varchar(10),stockdate,120)stockdate, unit, stockperson, unitprice, 
	    supplyperson, quantity, moneyamount, remark from dbo.stocklist where stocknumber = @stocknumber1 and  stockdate = @stockdate1 
	    
      
        Set @OutCode=1       
        Set @OutMsg = '查询成功。'
   End try
   Begin catch
      Set @OutCode = 0
      Set @OutMsg = '查询失败。原因：' + ERROR_MESSAGE() 
   End catch             
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TD_softwareEngineering_U]    Script Date: 08/21/2013 15:10:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		zq
-- Create date: 2013-08-18
-- Description:	采购管理系统修改
--<Param deptNo="11111111-1111-1111-1111-111111111111" ID="7a3a70e7-9172-444a-be2f-9c38a842eed5" RotationId="2" yearStr="2012" WaterSum="879" userId="11111111-1111-1111-1111-111111111111" />
-- =============================================
create PROCEDURE [dbo].[SP_TD_softwareEngineering_U]
	 @strXmlPara    ntext,
     @OutMsg        varchar(8000) output,
     @OutCode       bit output
AS
BEGIN
	SET NOCOUNT ON;
	Begin try
		Declare @xml xml
		Declare @stocknumberStr varchar(50)
		Declare @producingareaStr varchar(50)
		Declare @goodnameStr varchar(50)
		Declare @productiondateStr varchar(50)
		Declare @deadlineStr varchar(50)
		Declare @categoryStr varchar(50)
		Declare @gradeStr varchar(50)
		Declare @unitStr varchar(50)
		Declare @stockpersonStr varchar(50)
		Declare @unitpriceStr varchar(50)
		Declare @quantityStr varchar(50)
		Declare @moneyamountStr varchar(50)
		Declare @remarkStr varchar(50)
		Declare @stockdateStr varchar(50)
		Declare @supplypersonStr varchar(50)
		
		
			
		Set @xml = Convert(xml, @strXmlPara)
		Set @stocknumberStr = (@xml.value('(/Param/@stocknumberStr)[1]', 'varchar(50)'))
		Set @producingareaStr = (@xml.value('(/Param/@producingareaStr)[1]', 'varchar(50)'))
		Set @goodnameStr = (@xml.value('(/Param/@goodnameStr)[1]', 'varchar(50)'))
		Set @productiondateStr = (@xml.value('(/Param/@productiondateStr)[1]', 'varchar(50)'))
		Set @deadlineStr = (@xml.value('(/Param/@deadlineStr)[1]', 'varchar(50)'))
		Set @categoryStr = (@xml.value('(/Param/@categoryStr)[1]', 'varchar(50)'))
		Set @gradeStr = (@xml.value('(/Param/@gradeStr)[1]', 'varchar(50)'))
		Set @unitStr = (@xml.value('(/Param/@unitStr)[1]', 'varchar(50)'))
		Set @stockpersonStr = (@xml.value('(/Param/@stockpersonStr)[1]', 'varchar(50)'))
		Set @unitpriceStr = (@xml.value('(/Param/@unitpriceStr)[1]', 'varchar(50)'))
		Set @quantityStr = (@xml.value('(/Param/@quantityStr)[1]', 'varchar(50)'))
		Set @moneyamountStr = (@xml.value('(/Param/@moneyamountStr)[1]', 'varchar(50)'))
		Set @remarkStr = (@xml.value('(/Param/@remarkStr)[1]', 'varchar(50)'))
		Set @stockdateStr = (@xml.value('(/Param/@stockdateStr)[1]', 'varchar(50)'))
		Set @supplypersonStr = (@xml.value('(/Param/@supplypersonStr)[1]', 'varchar(50)'))
		
		delete from dbo.stocklist 
	where stocknumber = @stocknumberStr and stockdate = @stockdateStr 
	
		Insert into dbo.stocklist values 
		(
		 @stocknumberStr ,
		 @producingareaStr,
		 @goodnameStr,
		 @productiondateStr ,
		 @deadlineStr ,
		 @categoryStr ,
		 @gradeStr ,
		 @stockdateStr,
		 @unitStr ,
		 @stockpersonStr,
		 @unitpriceStr,
		 @supplypersonStr,
		 @quantityStr,
		 @moneyamountStr ,
		 @remarkStr 
		)
		
        Set @OutCode=1       
        Set @OutMsg = '保存成功。'
   End try
   Begin catch
      Set @OutCode = 0
      Set @OutMsg = '保存失败。原因：' + ERROR_MESSAGE() 
   End catch             
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TD_softwareEngineering_S_M_user]    Script Date: 08/21/2013 15:10:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		zq
-- Create date: 2013-08-20
-- Description:	采购用户查询(多条)
--<Param radDTEndTime="2014/8/27" />
-- =============================================
CREATE PROCEDURE [dbo].[SP_TD_softwareEngineering_S_M_user]
	 @strXmlPara    ntext,
     @OutMsg        varchar(8000) output,
     @OutCode       bit output
AS
BEGIN
	SET NOCOUNT ON;
	
	Begin try
		Declare @xml xml
		Declare @userStr varchar(50)
		Declare @passwordStr varchar(50)	
						
		Set @xml = Convert(xml, @strXmlPara)
		Set @userStr = (@xml.value('(/Param/@userStr)[1]', 'varchar(50)'))
		Set @passwordStr = (@xml.value('(/Param/@passwordStr)[1]', 'varchar(50)'))		
	--select [user], password from dbo.userlist
		if not exists (select [user], password from dbo.userlist 
		where [user]=@userStr and password =@passwordStr   )
		Begin
			Declare @errorMess nvarchar(100)
			Set @errorMess =  '用户名或密码不正确请重新输入'
			RAISERROR(@errorMess, 16, 1)
			Return
		End
		else
		begin 
		select [user], password from dbo.userlist 
		where [user]=@userStr and password =@passwordStr 
		end
		
        Set @OutCode=1       
        Set @OutMsg = '查询成功。'
   End try
   Begin catch
      Set @OutCode = 0
      Set @OutMsg = '查询失败。原因：' + ERROR_MESSAGE() 
   End catch             
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TD_softwareEngineering_S_M]    Script Date: 08/21/2013 15:10:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		zq
-- Create date: 2013-08-14
-- Description:	采购查询(多条)
--<Param radDTEndTime="2014/8/27" />
-- =============================================
CREATE PROCEDURE [dbo].[SP_TD_softwareEngineering_S_M]
	 @strXmlPara    ntext,
     @OutMsg        varchar(8000) output,
     @OutCode       bit output
AS
BEGIN
	SET NOCOUNT ON;
	
	Begin try
		Declare @xml xml
		Declare @radDTStartTime varchar(50)
		Declare @radDTEndTime varchar(50)
		Declare @gradeID varchar(10)	
						
		Set @xml = Convert(xml, @strXmlPara)
		Set @radDTStartTime = (@xml.value('(/Param/@radDTStartTime)[1]', 'varchar(50)'))
		Set @radDTEndTime = (@xml.value('(/Param/@radDTEndTime)[1]', 'varchar(50)'))
		Set @gradeID = (@xml.value('(/Param/@gradeID)[1]', 'varchar(10)'))			
		
		if (@gradeID = '全部' )
		begin
		if (@radDTStartTime is null and @radDTEndTime is null)
	    begin  select stocknumber, producingarea, goodname,   convert(varchar(10),productiondate,120)productiondate,
	    category, convert(varchar(10),deadline,120)deadline,  grade,  convert(varchar(10),stockdate,120)stockdate, unit, stockperson, unitprice, 
	    supplyperson, quantity, moneyamount, remark from dbo.stocklist
        end 
        else 
        if (@radDTStartTime is null and @radDTEndTime is not  null) 
        begin 
        select stocknumber, producingarea, goodname, convert(varchar(10),productiondate,120)productiondate,
	    category, convert(varchar(10),deadline,120)deadline,  grade, convert(varchar(10),stockdate,120)stockdate, unit, stockperson, unitprice, 
	    supplyperson, quantity, moneyamount, remark from dbo.stocklist where stockdate <= @radDTEndTime
        end     
        else 
        if (@radDTStartTime is not  null and @radDTEndTime is not  null)
        begin 
         select stocknumber, producingarea, goodname, convert(varchar(10),productiondate,120)productiondate,
	    category, convert(varchar(10),deadline,120)deadline,  grade,  convert(varchar(10),stockdate,120)stockdate, unit, stockperson, unitprice, 
	    supplyperson, quantity, moneyamount, remark from dbo.stocklist where stockdate >= @radDTStartTime and stockdate <=@radDTEndTime
        end
        else
         if (@radDTStartTime is not  null and @radDTEndTime is  null) 
         begin 
          select stocknumber, producingarea, goodname, convert(varchar(10),productiondate,120)productiondate,
	    category, convert(varchar(10),deadline,120)deadline,  grade,  convert(varchar(10),stockdate,120)stockdate, unit, stockperson, unitprice, 
	    supplyperson, quantity, moneyamount, remark from dbo.stocklist where stockdate >= @radDTStartTime
         end
         end
         else 
         
         if (@gradeID != '全部')
         begin
         if (@radDTStartTime is null and @radDTEndTime is null)
	    begin  select stocknumber, producingarea, goodname,   convert(varchar(10),productiondate,120)productiondate,
	    category, convert(varchar(10),deadline,120)deadline,  grade,  convert(varchar(10),stockdate,120)stockdate, unit, stockperson, unitprice, 
	    supplyperson, quantity, moneyamount, remark from dbo.stocklist where grade = @gradeID
        end 
        else 
        if (@radDTStartTime is null and @radDTEndTime is not  null) 
        begin 
        select stocknumber, producingarea, goodname, convert(varchar(10),productiondate,120)productiondate,
	    category, convert(varchar(10),deadline,120)deadline,  grade, convert(varchar(10),stockdate,120)stockdate, unit, stockperson, unitprice, 
	    supplyperson, quantity, moneyamount, remark from dbo.stocklist where stockdate <= @radDTEndTime and grade = @gradeID
        end     
        else 
        if (@radDTStartTime is not  null and @radDTEndTime is not  null)
        begin 
         select stocknumber, producingarea, goodname, convert(varchar(10),productiondate,120)productiondate,
	    category, convert(varchar(10),deadline,120)deadline,  grade,  convert(varchar(10),stockdate,120)stockdate, unit, stockperson, unitprice, 
	    supplyperson, quantity, moneyamount, remark from dbo.stocklist where stockdate >= @radDTStartTime and stockdate <=@radDTEndTime and grade = @gradeID
        end
        else
         if (@radDTStartTime is not  null and @radDTEndTime is  null) 
         begin 
          select stocknumber, producingarea, goodname, convert(varchar(10),productiondate,120)productiondate,
	    category, convert(varchar(10),deadline,120)deadline,  grade,  convert(varchar(10),stockdate,120)stockdate, unit, stockperson, unitprice, 
	    supplyperson, quantity, moneyamount, remark from dbo.stocklist where stockdate >= @radDTStartTime and grade = @gradeID
         end
        end
        Set @OutCode=1       
        Set @OutMsg = '查询成功。'
   End try
   Begin catch
      Set @OutCode = 0
      Set @OutMsg = '查询失败。原因：' + ERROR_MESSAGE() 
   End catch             
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TD_softwareEngineering__I]    Script Date: 08/21/2013 15:10:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		zq
-- Create date: 2012-08-15
-- Description:	采购管理系统-新增
--<Param deptNo="11111111-1111-1111-1111-111111111111" ID="7a3a70e7-9172-444a-be2f-9c38a842eed5" RotationId="2" yearStr="2012" WaterSum="879" userId="11111111-1111-1111-1111-111111111111" />
-- =============================================
CREATE PROCEDURE [dbo].[SP_TD_softwareEngineering__I]
	 @strXmlPara    ntext,
     @OutMsg        varchar(8000) output,
     @OutCode       bit output
AS
BEGIN
	SET NOCOUNT ON;
	Begin try
		Declare @xml xml
		Declare @stocknumberStr varchar(50)
		Declare @producingareaStr varchar(50)
		Declare @goodnameStr varchar(50)
		Declare @productiondateStr varchar(50)
		Declare @deadlineStr varchar(50)
		Declare @categoryStr varchar(50)
		Declare @gradeStr varchar(50)
		Declare @unitStr varchar(50)
		Declare @stockpersonStr varchar(50)
		Declare @unitpriceStr varchar(50)
		Declare @quantityStr varchar(50)
		Declare @moneyamountStr varchar(50)
		Declare @remarkStr varchar(50)
		Declare @stockdateStr varchar(50)
		Declare @supplypersonStr varchar(50)
		
		
			
		Set @xml = Convert(xml, @strXmlPara)
		Set @stocknumberStr = (@xml.value('(/Param/@stocknumberStr)[1]', 'varchar(50)'))
		Set @producingareaStr = (@xml.value('(/Param/@producingareaStr)[1]', 'varchar(50)'))
		Set @goodnameStr = (@xml.value('(/Param/@goodnameStr)[1]', 'varchar(50)'))
		Set @productiondateStr = (@xml.value('(/Param/@productiondateStr)[1]', 'varchar(50)'))
		Set @deadlineStr = (@xml.value('(/Param/@deadlineStr)[1]', 'varchar(50)'))
		Set @categoryStr = (@xml.value('(/Param/@categoryStr)[1]', 'varchar(50)'))
		Set @gradeStr = (@xml.value('(/Param/@gradeStr)[1]', 'varchar(50)'))
		Set @unitStr = (@xml.value('(/Param/@unitStr)[1]', 'varchar(50)'))
		Set @stockpersonStr = (@xml.value('(/Param/@stockpersonStr)[1]', 'varchar(50)'))
		Set @unitpriceStr = (@xml.value('(/Param/@unitpriceStr)[1]', 'varchar(50)'))
		Set @quantityStr = (@xml.value('(/Param/@quantityStr)[1]', 'varchar(50)'))
		Set @moneyamountStr = (@xml.value('(/Param/@moneyamountStr)[1]', 'varchar(50)'))
		Set @remarkStr = (@xml.value('(/Param/@remarkStr)[1]', 'varchar(50)'))
		Set @stockdateStr = (@xml.value('(/Param/@stockdateStr)[1]', 'varchar(50)'))
		Set @supplypersonStr = (@xml.value('(/Param/@supplypersonStr)[1]', 'varchar(50)'))
		
		
		If exists
		(
			Select 1 
				from dbo.stocklist
				where  stocknumber = @stocknumberStr
					and  stockdate= @stockdateStr
		)
		
		Begin
			Declare @errorMess nvarchar(100)
			Set @errorMess =  CAST(@stockdateStr as varchar(10)) + '日期该货物记录已存在'
			RAISERROR(@errorMess, 16, 1)
			Return
		End
	
		Insert into dbo.stocklist values 
		(
		 @stocknumberStr ,
		 @producingareaStr,
		 @goodnameStr,
		 @productiondateStr ,
		 @deadlineStr ,
		@categoryStr ,
		 @gradeStr ,
		 @stockdateStr,
		 @unitStr ,
		 @stockpersonStr,
		 @unitpriceStr,
		 @supplypersonStr,
		 @quantityStr,
		@moneyamountStr ,
		@remarkStr 
		
	
		)
		
        Set @OutCode=1       
        Set @OutMsg = '保存成功。'
   End try
   Begin catch
      Set @OutCode = 0
      Set @OutMsg = '保存失败。原因：' + ERROR_MESSAGE() 
   End catch             
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TD_softwareEngineering__D]    Script Date: 08/21/2013 15:10:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		zq
-- Create date: 2013-08-18
-- Description:	采购管理系统—删除
--<Param deptNo="11111111-1111-1111-1111-111111111111" yearStr="2012" RotationId="1" />
-- =============================================
CREATE PROCEDURE [dbo].[SP_TD_softwareEngineering__D]
	 @strXmlPara    ntext,
     @OutMsg        varchar(8000) output,
     @OutCode       bit output
AS
BEGIN
	SET NOCOUNT ON;
	
	Begin try
		Declare @xml xml
		Declare @stocknumberStr varchar(50)
		Declare @stockdateStr varchar(50)	
			
		Set @xml = Convert(xml, @strXmlPara)	
		Set @stocknumberStr = (@xml.value('(/Param/@stocknumberStr)[1]', 'varchar(50)'))		
		Set @stockdateStr = (@xml.value('(/Param/@stockdateStr )[1]', 'varchar(50)'))
	if not exists( select stocknumber, producingarea, goodname,   convert(varchar(10),productiondate,120)productiondate,
	    category, convert(varchar(10),deadline,120)deadline,  grade,  convert(varchar(10),stockdate,120)stockdate, unit, stockperson, unitprice, 
	    supplyperson, quantity, moneyamount, remark from dbo.stocklist where stocknumber = @stocknumberStr and  stockdate = @stockdateStr )
	    begin
	     Declare @errorMess nvarchar(100)
			Set @errorMess = '该条记录不存在!'
			RAISERROR(@errorMess, 16, 1)
			Return 
	    end
	if  exists( select stocknumber, producingarea, goodname,   convert(varchar(10),productiondate,120)productiondate,
	    category, convert(varchar(10),deadline,120)deadline,  grade,  convert(varchar(10),stockdate,120)stockdate, unit, stockperson, unitprice, 
	    supplyperson, quantity, moneyamount, remark from dbo.stocklist where stocknumber = @stocknumberStr and  stockdate = @stockdateStr )
	    begin
	delete from dbo.stocklist
	where stocknumber = @stocknumberStr and stockdate = @stockdateStr 
	 end
		
		
        Set @OutCode=1       
        Set @OutMsg = '删除成功。'
   End try
   Begin catch
      Set @OutCode = 0
      Set @OutMsg = '删除失败。原因：' + ERROR_MESSAGE() 
   End catch             
END
GO
