
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/07/2016 14:29:53
-- Generated from EDMX file: C:\Users\e0001302\Google Drive\SA41 AD Project\GitHub\LU_SSIS\LogicUniversity\LogicUniversity\Model\LogicUniversity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LogicUniversity];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AdjVoucher_StoreEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdjVoucher] DROP CONSTRAINT [FK_AdjVoucher_StoreEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_AdjVoucherItem_AdjVoucher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdjVoucherItem] DROP CONSTRAINT [FK_AdjVoucherItem_AdjVoucher];
GO
IF OBJECT_ID(N'[dbo].[FK_AdjVoucherItem_Item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdjVoucherItem] DROP CONSTRAINT [FK_AdjVoucherItem_Item];
GO
IF OBJECT_ID(N'[dbo].[FK_Delegate_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delegate] DROP CONSTRAINT [FK_Delegate_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Department_CollectionPoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Department] DROP CONSTRAINT [FK_Department_CollectionPoint];
GO
IF OBJECT_ID(N'[dbo].[FK_Disbursement_CollectionPoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Disbursement] DROP CONSTRAINT [FK_Disbursement_CollectionPoint];
GO
IF OBJECT_ID(N'[dbo].[FK_Disbursement_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Disbursement] DROP CONSTRAINT [FK_Disbursement_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_Disbursement_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Disbursement] DROP CONSTRAINT [FK_Disbursement_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_DisbursementItem_Disbursement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DisbursementItem] DROP CONSTRAINT [FK_DisbursementItem_Disbursement];
GO
IF OBJECT_ID(N'[dbo].[FK_DisbursementItem_Item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DisbursementItem] DROP CONSTRAINT [FK_DisbursementItem_Item];
GO
IF OBJECT_ID(N'[dbo].[FK_DisbursementRequestItem_DisbursementItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DisbursementRequestItem] DROP CONSTRAINT [FK_DisbursementRequestItem_DisbursementItem];
GO
IF OBJECT_ID(N'[dbo].[FK_DisbursementRequestItem_RequisitionItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DisbursementRequestItem] DROP CONSTRAINT [FK_DisbursementRequestItem_RequisitionItem];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_Item_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Item] DROP CONSTRAINT [FK_Item_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseOrder_StoreEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseOrder] DROP CONSTRAINT [FK_PurchaseOrder_StoreEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseOrder_Supplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseOrder] DROP CONSTRAINT [FK_PurchaseOrder_Supplier];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseOrderItem_Item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseOrderItem] DROP CONSTRAINT [FK_PurchaseOrderItem_Item];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseOrderItem_PurchaseOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseOrderItem] DROP CONSTRAINT [FK_PurchaseOrderItem_PurchaseOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_Requisition_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Requisition] DROP CONSTRAINT [FK_Requisition_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_RequisitionItem_Item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequisitionItem] DROP CONSTRAINT [FK_RequisitionItem_Item];
GO
IF OBJECT_ID(N'[dbo].[FK_RequisitionItem_Requisition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequisitionItem] DROP CONSTRAINT [FK_RequisitionItem_Requisition];
GO
IF OBJECT_ID(N'[dbo].[FK_StockTransaction_AdjVoucherItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockTransaction] DROP CONSTRAINT [FK_StockTransaction_AdjVoucherItem];
GO
IF OBJECT_ID(N'[dbo].[FK_StockTransaction_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockTransaction] DROP CONSTRAINT [FK_StockTransaction_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_StockTransaction_Item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockTransaction] DROP CONSTRAINT [FK_StockTransaction_Item];
GO
IF OBJECT_ID(N'[dbo].[FK_StockTransaction_Supplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockTransaction] DROP CONSTRAINT [FK_StockTransaction_Supplier];
GO
IF OBJECT_ID(N'[dbo].[FK_SupplierItem_Item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SupplierItem] DROP CONSTRAINT [FK_SupplierItem_Item];
GO
IF OBJECT_ID(N'[dbo].[FK_SupplierItem_Supplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SupplierItem] DROP CONSTRAINT [FK_SupplierItem_Supplier];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AdjVoucher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdjVoucher];
GO
IF OBJECT_ID(N'[dbo].[AdjVoucherItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdjVoucherItem];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[CollectionPoint]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollectionPoint];
GO
IF OBJECT_ID(N'[dbo].[Delegate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Delegate];
GO
IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[Disbursement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Disbursement];
GO
IF OBJECT_ID(N'[dbo].[DisbursementItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DisbursementItem];
GO
IF OBJECT_ID(N'[dbo].[DisbursementRequestItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DisbursementRequestItem];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[ForgotPassword]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ForgotPassword];
GO
IF OBJECT_ID(N'[dbo].[Item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Item];
GO
IF OBJECT_ID(N'[dbo].[Notification]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notification];
GO
IF OBJECT_ID(N'[dbo].[PurchaseOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseOrder];
GO
IF OBJECT_ID(N'[dbo].[PurchaseOrderItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseOrderItem];
GO
IF OBJECT_ID(N'[dbo].[Requisition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Requisition];
GO
IF OBJECT_ID(N'[dbo].[RequisitionItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RequisitionItem];
GO
IF OBJECT_ID(N'[dbo].[StockTransaction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StockTransaction];
GO
IF OBJECT_ID(N'[dbo].[StoreEmployee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StoreEmployee];
GO
IF OBJECT_ID(N'[dbo].[Supplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Supplier];
GO
IF OBJECT_ID(N'[dbo].[SupplierItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SupplierItem];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AdjVouchers'
CREATE TABLE [dbo].[AdjVouchers] (
    [AdjVoucherID] int IDENTITY(1,1) NOT NULL,
    [StoreEmployeeID] varchar(50)  NULL
);
GO

-- Creating table 'AdjVoucherItems'
CREATE TABLE [dbo].[AdjVoucherItems] (
    [AdjVoucherItemID] int IDENTITY(1,1) NOT NULL,
    [AdjVoucherID] int  NULL,
    [ItemID] varchar(50)  NULL,
    [Quantity] int  NULL,
    [Reason] varchar(200)  NULL,
    [Status] varchar(50)  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [CategoryName] varchar(50)  NOT NULL
);
GO

-- Creating table 'CollectionPoints'
CREATE TABLE [dbo].[CollectionPoints] (
    [CollectionPointID] int IDENTITY(1,1) NOT NULL,
    [CollectionPointName] varchar(50)  NULL,
    [Time] varchar(50)  NULL,
    [FirstCollectionDate] varchar(50)  NULL,
    [SecondCollectionDate] varchar(50)  NULL
);
GO

-- Creating table 'Delegates'
CREATE TABLE [dbo].[Delegates] (
    [DelegateID] int IDENTITY(1,1) NOT NULL,
    [EmployeeID] varchar(50)  NOT NULL,
    [FromDate] datetime  NOT NULL,
    [ToDate] datetime  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [DepartmentID] varchar(50)  NOT NULL,
    [DepartmentName] varchar(50)  NULL,
    [CollectionPointID] int  NULL
);
GO

-- Creating table 'Disbursements'
CREATE TABLE [dbo].[Disbursements] (
    [DisbursementID] int IDENTITY(1,1) NOT NULL,
    [CollectionDate] datetime  NULL,
    [CollectionPointID] int  NULL,
    [AcknowledgeEmployeeID] varchar(50)  NULL,
    [DepartmentID] varchar(50)  NULL,
    [status] nchar(10)  NULL
);
GO

-- Creating table 'DisbursementItems'
CREATE TABLE [dbo].[DisbursementItems] (
    [DisbursementItemID] int IDENTITY(1,1) NOT NULL,
    [DisbursementID] int  NULL,
    [ItemID] varchar(50)  NULL,
    [Quantity] int  NULL,
    [RequestDate] datetime  NULL,
    [RemainingQty] int  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] varchar(50)  NOT NULL,
    [PIN] varchar(50)  NOT NULL,
    [Email] varchar(50)  NULL,
    [Name] varchar(50)  NULL,
    [DepartmentID] varchar(50)  NOT NULL,
    [Role] varchar(50)  NULL
);
GO

-- Creating table 'ForgotPasswords'
CREATE TABLE [dbo].[ForgotPasswords] (
    [Code] int IDENTITY(1,1) NOT NULL,
    [UserID] varchar(50)  NOT NULL,
    [Status] varchar(50)  NOT NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [ItemID] varchar(50)  NOT NULL,
    [Description] varchar(50)  NOT NULL,
    [Quantity] int  NOT NULL,
    [UOM] varchar(50)  NULL,
    [CategoryID] int  NULL,
    [ReorderLevel] int  NULL,
    [ReorderQty] int  NULL,
    [QRCode] varchar(100)  NULL,
    [BinNo] nvarchar(50)  NULL
);
GO

-- Creating table 'Notifications'
CREATE TABLE [dbo].[Notifications] (
    [NotificationID] int IDENTITY(1,1) NOT NULL,
    [UserID] varchar(50)  NULL,
    [NotificationDate] datetime  NULL,
    [Message] varchar(100)  NULL,
    [FromUser] varchar(50)  NULL
);
GO

-- Creating table 'PurchaseOrders'
CREATE TABLE [dbo].[PurchaseOrders] (
    [PurchaseOrderID] int IDENTITY(1,1) NOT NULL,
    [SupplierID] varchar(50)  NULL,
    [StoreEmployeeID] varchar(50)  NULL,
    [OrderDate] datetime  NULL,
    [RequireDeliveryDate] datetime  NULL
);
GO

-- Creating table 'PurchaseOrderItems'
CREATE TABLE [dbo].[PurchaseOrderItems] (
    [PurchaseOrderItemID] int IDENTITY(1,1) NOT NULL,
    [ItemID] varchar(50)  NULL,
    [PurchaseOrderID] int  NULL,
    [Quantity] int  NULL
);
GO

-- Creating table 'Requisitions'
CREATE TABLE [dbo].[Requisitions] (
    [RequisitionID] int IDENTITY(1,1) NOT NULL,
    [EmployeeID] varchar(50)  NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'RequisitionItems'
CREATE TABLE [dbo].[RequisitionItems] (
    [RequisitionItemID] int IDENTITY(1,1) NOT NULL,
    [RequisitionID] int  NULL,
    [ItemID] varchar(50)  NULL,
    [Quantity] int  NULL,
    [Status] varchar(50)  NULL,
    [Reson] varchar(100)  NULL
);
GO

-- Creating table 'StockTransactions'
CREATE TABLE [dbo].[StockTransactions] (
    [StockTransactionID] int IDENTITY(1,1) NOT NULL,
    [ItemID] varchar(50)  NULL,
    [SupplierID] varchar(50)  NULL,
    [DepartmentID] varchar(50)  NULL,
    [AdjVoucherItemID] int  NULL,
    [Balance] int  NULL,
    [TransactionDate] datetime  NULL
);
GO

-- Creating table 'StoreEmployees'
CREATE TABLE [dbo].[StoreEmployees] (
    [StoreEmployeeID] varchar(50)  NOT NULL,
    [PIN] varchar(50)  NULL,
    [Email] varchar(50)  NULL,
    [Name] varchar(50)  NULL,
    [Role] varchar(50)  NULL
);
GO

-- Creating table 'Suppliers'
CREATE TABLE [dbo].[Suppliers] (
    [SupplierID] varchar(50)  NOT NULL,
    [SupplierName] varchar(50)  NULL,
    [ContactName] varchar(50)  NULL,
    [PhNo] varchar(50)  NULL,
    [FaxNo] varchar(50)  NULL,
    [Address] varchar(200)  NULL,
    [Email] varchar(50)  NULL,
    [GSTRegistration] varchar(50)  NULL
);
GO

-- Creating table 'SupplierItems'
CREATE TABLE [dbo].[SupplierItems] (
    [ItemID] varchar(50)  NOT NULL,
    [SupplierID] varchar(50)  NOT NULL,
    [Price] decimal(10,2)  NULL,
    [Priority] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'DisbursementRequestItem'
CREATE TABLE [dbo].[DisbursementRequestItem] (
    [DisbursementItems_DisbursementItemID] int  NOT NULL,
    [RequisitionItems_RequisitionItemID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AdjVoucherID] in table 'AdjVouchers'
ALTER TABLE [dbo].[AdjVouchers]
ADD CONSTRAINT [PK_AdjVouchers]
    PRIMARY KEY CLUSTERED ([AdjVoucherID] ASC);
GO

-- Creating primary key on [AdjVoucherItemID] in table 'AdjVoucherItems'
ALTER TABLE [dbo].[AdjVoucherItems]
ADD CONSTRAINT [PK_AdjVoucherItems]
    PRIMARY KEY CLUSTERED ([AdjVoucherItemID] ASC);
GO

-- Creating primary key on [CategoryID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- Creating primary key on [CollectionPointID] in table 'CollectionPoints'
ALTER TABLE [dbo].[CollectionPoints]
ADD CONSTRAINT [PK_CollectionPoints]
    PRIMARY KEY CLUSTERED ([CollectionPointID] ASC);
GO

-- Creating primary key on [DelegateID] in table 'Delegates'
ALTER TABLE [dbo].[Delegates]
ADD CONSTRAINT [PK_Delegates]
    PRIMARY KEY CLUSTERED ([DelegateID] ASC);
GO

-- Creating primary key on [DepartmentID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([DepartmentID] ASC);
GO

-- Creating primary key on [DisbursementID] in table 'Disbursements'
ALTER TABLE [dbo].[Disbursements]
ADD CONSTRAINT [PK_Disbursements]
    PRIMARY KEY CLUSTERED ([DisbursementID] ASC);
GO

-- Creating primary key on [DisbursementItemID] in table 'DisbursementItems'
ALTER TABLE [dbo].[DisbursementItems]
ADD CONSTRAINT [PK_DisbursementItems]
    PRIMARY KEY CLUSTERED ([DisbursementItemID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [Code] in table 'ForgotPasswords'
ALTER TABLE [dbo].[ForgotPasswords]
ADD CONSTRAINT [PK_ForgotPasswords]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [ItemID] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([ItemID] ASC);
GO

-- Creating primary key on [NotificationID] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [PK_Notifications]
    PRIMARY KEY CLUSTERED ([NotificationID] ASC);
GO

-- Creating primary key on [PurchaseOrderID] in table 'PurchaseOrders'
ALTER TABLE [dbo].[PurchaseOrders]
ADD CONSTRAINT [PK_PurchaseOrders]
    PRIMARY KEY CLUSTERED ([PurchaseOrderID] ASC);
GO

-- Creating primary key on [PurchaseOrderItemID] in table 'PurchaseOrderItems'
ALTER TABLE [dbo].[PurchaseOrderItems]
ADD CONSTRAINT [PK_PurchaseOrderItems]
    PRIMARY KEY CLUSTERED ([PurchaseOrderItemID] ASC);
GO

-- Creating primary key on [RequisitionID] in table 'Requisitions'
ALTER TABLE [dbo].[Requisitions]
ADD CONSTRAINT [PK_Requisitions]
    PRIMARY KEY CLUSTERED ([RequisitionID] ASC);
GO

-- Creating primary key on [RequisitionItemID] in table 'RequisitionItems'
ALTER TABLE [dbo].[RequisitionItems]
ADD CONSTRAINT [PK_RequisitionItems]
    PRIMARY KEY CLUSTERED ([RequisitionItemID] ASC);
GO

-- Creating primary key on [StockTransactionID] in table 'StockTransactions'
ALTER TABLE [dbo].[StockTransactions]
ADD CONSTRAINT [PK_StockTransactions]
    PRIMARY KEY CLUSTERED ([StockTransactionID] ASC);
GO

-- Creating primary key on [StoreEmployeeID] in table 'StoreEmployees'
ALTER TABLE [dbo].[StoreEmployees]
ADD CONSTRAINT [PK_StoreEmployees]
    PRIMARY KEY CLUSTERED ([StoreEmployeeID] ASC);
GO

-- Creating primary key on [SupplierID] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [PK_Suppliers]
    PRIMARY KEY CLUSTERED ([SupplierID] ASC);
GO

-- Creating primary key on [ItemID], [SupplierID] in table 'SupplierItems'
ALTER TABLE [dbo].[SupplierItems]
ADD CONSTRAINT [PK_SupplierItems]
    PRIMARY KEY CLUSTERED ([ItemID], [SupplierID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [DisbursementItems_DisbursementItemID], [RequisitionItems_RequisitionItemID] in table 'DisbursementRequestItem'
ALTER TABLE [dbo].[DisbursementRequestItem]
ADD CONSTRAINT [PK_DisbursementRequestItem]
    PRIMARY KEY CLUSTERED ([DisbursementItems_DisbursementItemID], [RequisitionItems_RequisitionItemID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StoreEmployeeID] in table 'AdjVouchers'
ALTER TABLE [dbo].[AdjVouchers]
ADD CONSTRAINT [FK_AdjVoucher_StoreEmployee]
    FOREIGN KEY ([StoreEmployeeID])
    REFERENCES [dbo].[StoreEmployees]
        ([StoreEmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdjVoucher_StoreEmployee'
CREATE INDEX [IX_FK_AdjVoucher_StoreEmployee]
ON [dbo].[AdjVouchers]
    ([StoreEmployeeID]);
GO

-- Creating foreign key on [AdjVoucherID] in table 'AdjVoucherItems'
ALTER TABLE [dbo].[AdjVoucherItems]
ADD CONSTRAINT [FK_AdjVoucherItem_AdjVoucher]
    FOREIGN KEY ([AdjVoucherID])
    REFERENCES [dbo].[AdjVouchers]
        ([AdjVoucherID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdjVoucherItem_AdjVoucher'
CREATE INDEX [IX_FK_AdjVoucherItem_AdjVoucher]
ON [dbo].[AdjVoucherItems]
    ([AdjVoucherID]);
GO

-- Creating foreign key on [ItemID] in table 'AdjVoucherItems'
ALTER TABLE [dbo].[AdjVoucherItems]
ADD CONSTRAINT [FK_AdjVoucherItem_Item]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[Items]
        ([ItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdjVoucherItem_Item'
CREATE INDEX [IX_FK_AdjVoucherItem_Item]
ON [dbo].[AdjVoucherItems]
    ([ItemID]);
GO

-- Creating foreign key on [AdjVoucherItemID] in table 'StockTransactions'
ALTER TABLE [dbo].[StockTransactions]
ADD CONSTRAINT [FK_StockTransaction_AdjVoucherItem]
    FOREIGN KEY ([AdjVoucherItemID])
    REFERENCES [dbo].[AdjVoucherItems]
        ([AdjVoucherItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StockTransaction_AdjVoucherItem'
CREATE INDEX [IX_FK_StockTransaction_AdjVoucherItem]
ON [dbo].[StockTransactions]
    ([AdjVoucherItemID]);
GO

-- Creating foreign key on [CategoryID] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_Item_Category]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Item_Category'
CREATE INDEX [IX_FK_Item_Category]
ON [dbo].[Items]
    ([CategoryID]);
GO

-- Creating foreign key on [CollectionPointID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [FK_Department_CollectionPoint]
    FOREIGN KEY ([CollectionPointID])
    REFERENCES [dbo].[CollectionPoints]
        ([CollectionPointID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Department_CollectionPoint'
CREATE INDEX [IX_FK_Department_CollectionPoint]
ON [dbo].[Departments]
    ([CollectionPointID]);
GO

-- Creating foreign key on [CollectionPointID] in table 'Disbursements'
ALTER TABLE [dbo].[Disbursements]
ADD CONSTRAINT [FK_Disbursement_CollectionPoint]
    FOREIGN KEY ([CollectionPointID])
    REFERENCES [dbo].[CollectionPoints]
        ([CollectionPointID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Disbursement_CollectionPoint'
CREATE INDEX [IX_FK_Disbursement_CollectionPoint]
ON [dbo].[Disbursements]
    ([CollectionPointID]);
GO

-- Creating foreign key on [EmployeeID] in table 'Delegates'
ALTER TABLE [dbo].[Delegates]
ADD CONSTRAINT [FK_Delegate_Employee]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Delegate_Employee'
CREATE INDEX [IX_FK_Delegate_Employee]
ON [dbo].[Delegates]
    ([EmployeeID]);
GO

-- Creating foreign key on [DepartmentID] in table 'Disbursements'
ALTER TABLE [dbo].[Disbursements]
ADD CONSTRAINT [FK_Disbursement_Department]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Departments]
        ([DepartmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Disbursement_Department'
CREATE INDEX [IX_FK_Disbursement_Department]
ON [dbo].[Disbursements]
    ([DepartmentID]);
GO

-- Creating foreign key on [DepartmentID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_Department]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Departments]
        ([DepartmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Department'
CREATE INDEX [IX_FK_Employee_Department]
ON [dbo].[Employees]
    ([DepartmentID]);
GO

-- Creating foreign key on [DepartmentID] in table 'StockTransactions'
ALTER TABLE [dbo].[StockTransactions]
ADD CONSTRAINT [FK_StockTransaction_Department]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Departments]
        ([DepartmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StockTransaction_Department'
CREATE INDEX [IX_FK_StockTransaction_Department]
ON [dbo].[StockTransactions]
    ([DepartmentID]);
GO

-- Creating foreign key on [AcknowledgeEmployeeID] in table 'Disbursements'
ALTER TABLE [dbo].[Disbursements]
ADD CONSTRAINT [FK_Disbursement_Employee]
    FOREIGN KEY ([AcknowledgeEmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Disbursement_Employee'
CREATE INDEX [IX_FK_Disbursement_Employee]
ON [dbo].[Disbursements]
    ([AcknowledgeEmployeeID]);
GO

-- Creating foreign key on [DisbursementID] in table 'DisbursementItems'
ALTER TABLE [dbo].[DisbursementItems]
ADD CONSTRAINT [FK_DisbursementItem_Disbursement]
    FOREIGN KEY ([DisbursementID])
    REFERENCES [dbo].[Disbursements]
        ([DisbursementID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DisbursementItem_Disbursement'
CREATE INDEX [IX_FK_DisbursementItem_Disbursement]
ON [dbo].[DisbursementItems]
    ([DisbursementID]);
GO

-- Creating foreign key on [ItemID] in table 'DisbursementItems'
ALTER TABLE [dbo].[DisbursementItems]
ADD CONSTRAINT [FK_DisbursementItem_Item]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[Items]
        ([ItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DisbursementItem_Item'
CREATE INDEX [IX_FK_DisbursementItem_Item]
ON [dbo].[DisbursementItems]
    ([ItemID]);
GO

-- Creating foreign key on [EmployeeID] in table 'Requisitions'
ALTER TABLE [dbo].[Requisitions]
ADD CONSTRAINT [FK_Requisition_Employee]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Requisition_Employee'
CREATE INDEX [IX_FK_Requisition_Employee]
ON [dbo].[Requisitions]
    ([EmployeeID]);
GO

-- Creating foreign key on [ItemID] in table 'PurchaseOrderItems'
ALTER TABLE [dbo].[PurchaseOrderItems]
ADD CONSTRAINT [FK_PurchaseOrderItem_Item]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[Items]
        ([ItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseOrderItem_Item'
CREATE INDEX [IX_FK_PurchaseOrderItem_Item]
ON [dbo].[PurchaseOrderItems]
    ([ItemID]);
GO

-- Creating foreign key on [ItemID] in table 'RequisitionItems'
ALTER TABLE [dbo].[RequisitionItems]
ADD CONSTRAINT [FK_RequisitionItem_Item]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[Items]
        ([ItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RequisitionItem_Item'
CREATE INDEX [IX_FK_RequisitionItem_Item]
ON [dbo].[RequisitionItems]
    ([ItemID]);
GO

-- Creating foreign key on [ItemID] in table 'StockTransactions'
ALTER TABLE [dbo].[StockTransactions]
ADD CONSTRAINT [FK_StockTransaction_Item]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[Items]
        ([ItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StockTransaction_Item'
CREATE INDEX [IX_FK_StockTransaction_Item]
ON [dbo].[StockTransactions]
    ([ItemID]);
GO

-- Creating foreign key on [ItemID] in table 'SupplierItems'
ALTER TABLE [dbo].[SupplierItems]
ADD CONSTRAINT [FK_SupplierItem_Item]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[Items]
        ([ItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [StoreEmployeeID] in table 'PurchaseOrders'
ALTER TABLE [dbo].[PurchaseOrders]
ADD CONSTRAINT [FK_PurchaseOrder_StoreEmployee]
    FOREIGN KEY ([StoreEmployeeID])
    REFERENCES [dbo].[StoreEmployees]
        ([StoreEmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseOrder_StoreEmployee'
CREATE INDEX [IX_FK_PurchaseOrder_StoreEmployee]
ON [dbo].[PurchaseOrders]
    ([StoreEmployeeID]);
GO

-- Creating foreign key on [SupplierID] in table 'PurchaseOrders'
ALTER TABLE [dbo].[PurchaseOrders]
ADD CONSTRAINT [FK_PurchaseOrder_Supplier]
    FOREIGN KEY ([SupplierID])
    REFERENCES [dbo].[Suppliers]
        ([SupplierID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseOrder_Supplier'
CREATE INDEX [IX_FK_PurchaseOrder_Supplier]
ON [dbo].[PurchaseOrders]
    ([SupplierID]);
GO

-- Creating foreign key on [PurchaseOrderID] in table 'PurchaseOrderItems'
ALTER TABLE [dbo].[PurchaseOrderItems]
ADD CONSTRAINT [FK_PurchaseOrderItem_PurchaseOrder]
    FOREIGN KEY ([PurchaseOrderID])
    REFERENCES [dbo].[PurchaseOrders]
        ([PurchaseOrderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseOrderItem_PurchaseOrder'
CREATE INDEX [IX_FK_PurchaseOrderItem_PurchaseOrder]
ON [dbo].[PurchaseOrderItems]
    ([PurchaseOrderID]);
GO

-- Creating foreign key on [RequisitionID] in table 'RequisitionItems'
ALTER TABLE [dbo].[RequisitionItems]
ADD CONSTRAINT [FK_RequisitionItem_Requisition]
    FOREIGN KEY ([RequisitionID])
    REFERENCES [dbo].[Requisitions]
        ([RequisitionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RequisitionItem_Requisition'
CREATE INDEX [IX_FK_RequisitionItem_Requisition]
ON [dbo].[RequisitionItems]
    ([RequisitionID]);
GO

-- Creating foreign key on [SupplierID] in table 'StockTransactions'
ALTER TABLE [dbo].[StockTransactions]
ADD CONSTRAINT [FK_StockTransaction_Supplier]
    FOREIGN KEY ([SupplierID])
    REFERENCES [dbo].[Suppliers]
        ([SupplierID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StockTransaction_Supplier'
CREATE INDEX [IX_FK_StockTransaction_Supplier]
ON [dbo].[StockTransactions]
    ([SupplierID]);
GO

-- Creating foreign key on [SupplierID] in table 'SupplierItems'
ALTER TABLE [dbo].[SupplierItems]
ADD CONSTRAINT [FK_SupplierItem_Supplier]
    FOREIGN KEY ([SupplierID])
    REFERENCES [dbo].[Suppliers]
        ([SupplierID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SupplierItem_Supplier'
CREATE INDEX [IX_FK_SupplierItem_Supplier]
ON [dbo].[SupplierItems]
    ([SupplierID]);
GO

-- Creating foreign key on [DisbursementItems_DisbursementItemID] in table 'DisbursementRequestItem'
ALTER TABLE [dbo].[DisbursementRequestItem]
ADD CONSTRAINT [FK_DisbursementRequestItem_DisbursementItem]
    FOREIGN KEY ([DisbursementItems_DisbursementItemID])
    REFERENCES [dbo].[DisbursementItems]
        ([DisbursementItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RequisitionItems_RequisitionItemID] in table 'DisbursementRequestItem'
ALTER TABLE [dbo].[DisbursementRequestItem]
ADD CONSTRAINT [FK_DisbursementRequestItem_RequisitionItem]
    FOREIGN KEY ([RequisitionItems_RequisitionItemID])
    REFERENCES [dbo].[RequisitionItems]
        ([RequisitionItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DisbursementRequestItem_RequisitionItem'
CREATE INDEX [IX_FK_DisbursementRequestItem_RequisitionItem]
ON [dbo].[DisbursementRequestItem]
    ([RequisitionItems_RequisitionItemID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------