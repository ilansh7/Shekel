/****** Object:  View [dbo].[V_CustomersAndGroups]    Script Date: 1/17/2023 12:30:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE           VIEW [dbo].[V_CustomersAndGroups]
AS
	select	g.groupCode,
			g.groupName, 
			c.customerId, 
			c.name
	from [dbo].[Customers] c
	left join [dbo].[FactoriesToCustomer] fc on c.customerId = fc.customerId
	left join [dbo].[Groups] g on fc.groupCode = g.groupCode 

GO



GO
/****** Object:  StoredProcedure [dbo].[sp_GetCustomersAndGroups]    Script Date: 1/17/2023 12:30:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[sp_GetCustomersAndGroups] 
	@groupId nvarchar(5)

AS
BEGIN

	SELECT	groupCode,
			groupName,
			customerId,
			name
	FROM	[dbo].[V_CustomersAndGroups]
	where	groupCode = @groupId or @groupId = '0'
	ORDER BY 2, 4
END
GO




/****** Object:  StoredProcedure [dbo].[sp_GetListValues]    Script Date: 1/17/2023 12:30:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[sp_GetListValues] 
	@listName nvarchar(5),
	@gId int

AS
BEGIN
	IF @listName = 'G'
		BEGIN
			SELECT	groupCode as ID,
					groupName as Name
			FROM	[dbo].[Groups]
			ORDER BY 2
		END

	IF @listName = 'F'
		BEGIN
			SELECT	factoryCode as ID,
					factoryName as Name
			FROM	[dbo].[Factories]
			WHERE	groupCode = @gId
			ORDER BY 2
		END
END
GO




/****** Object:  StoredProcedure [dbo].[sp_InsertCustomer]    Script Date: 1/17/2023 12:30:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[sp_InsertCustomer] 
	@customerId nvarchar(9),
	@customerName nvarchar(50),
	@customerAddress nvarchar(150),
	@customerPhone nvarchar(50),
	@factoryCode int,
	@groupCode int

AS
BEGIN
	
	DECLARE @@custId nvarchar(9)
	DECLARE @@ret int = 0
	
	IF NOT EXISTS(SELECT customerId FROM [dbo].[Customers] c WHERE c.customerId = @customerId)
		BEGIN
			INSERT INTO [dbo].[Customers] (
					customerId,
					name,
					address,
					phone
				) 
			VALUES ( 
					@customerId,
		            @customerName,
			        @customerAddress,
				    @customerPhone                  
				) 

			SELECT @@ret = CAST(@customerId As int)
		END

	IF NOT EXISTS(SELECT customerId FROM [dbo].[FactoriesToCustomer] fc WHERE fc.customerId = @customerId and fc.factoryCode = 0 and fc.groupCode = 0)
		BEGIN
			INSERT INTO [dbo].[FactoriesToCustomer] (
					customerId,
					factoryCode,
					groupCode
				) 
			VALUES ( 
					@customerId,
		            @factoryCode,
			        @groupCode                  
				) 

			SELECT @@ret = CAST(@customerId As int)
		END

	select @@ret

END
GO
