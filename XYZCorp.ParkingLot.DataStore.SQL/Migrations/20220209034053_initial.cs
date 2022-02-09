using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZCorp.ParkingLot.DataStore.SQL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"SET IDENTITY_INSERT [dbo].[EntryPoints] ON 
                                    GO
                                    INSERT [dbo].[EntryPoints] ([ID], [Name], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (1, N'ENTRANCE A', CAST(N'2022-02-07T22:11:00.6133333' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[EntryPoints] ([ID], [Name], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (2, N'ENTRANCE B', CAST(N'2022-02-07T22:11:00.6133333' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[EntryPoints] ([ID], [Name], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (3, N'ENTRANCE C', CAST(N'2022-02-07T22:11:00.6133333' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    SET IDENTITY_INSERT [dbo].[EntryPoints] OFF
                                    GO
                                    SET IDENTITY_INSERT [dbo].[SlotTypes] ON 
                                    GO
                                    INSERT [dbo].[SlotTypes] ([ID], [Name], [Description], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (1, N'Small', N'Small', CAST(N'2022-02-07T22:11:00.6466667' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[SlotTypes] ([ID], [Name], [Description], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (2, N'Medium', N'Medium', CAST(N'2022-02-07T22:11:00.6466667' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[SlotTypes] ([ID], [Name], [Description], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (3, N'Large', N'Large', CAST(N'2022-02-07T22:11:00.6466667' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    SET IDENTITY_INSERT [dbo].[SlotTypes] OFF
                                    GO
                                    SET IDENTITY_INSERT [dbo].[Slots] ON 
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (1, N'SLOT 1-A', N'SLOT 1-A', 1, 1, CAST(N'2022-02-07T22:11:00.6666667' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (2, N'SLOT 1-B', N'SLOT 1-B', 1, 1, CAST(N'2022-02-07T22:11:00.6666667' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (3, N'SLOT 1-C', N'SLOT 1-C', 2, 1, CAST(N'2022-02-07T22:11:00.6666667' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (4, N'SLOT 1-D', N'SLOT 1-D', 2, 1, CAST(N'2022-02-07T22:11:00.6666667' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (5, N'SLOT 1-E', N'SLOT 1-E', 3, 1, CAST(N'2022-02-07T22:11:00.6666667' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (6, N'SLOT 1-F', N'SLOT 1-F', 3, 1, CAST(N'2022-02-07T22:11:00.6666667' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (7, N'SLOT 2-A', N'SLOT 2-A', 1, 2, CAST(N'2022-02-07T22:11:00.6666667' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (8, N'SLOT 2-B', N'SLOT 2-B', 1, 2, CAST(N'2022-02-07T22:11:00.6666667' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (9, N'SLOT 2-C', N'SLOT 2-C', 2, 2, CAST(N'2022-02-07T22:11:00.6666667' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (10, N'SLOT 2-D', N'SLOT 2-D', 2, 2, CAST(N'2022-02-07T22:11:00.6666667' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (11, N'SLOT 2-E', N'SLOT 2-E', 3, 2, CAST(N'2022-02-07T22:11:00.6666667' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (12, N'SLOT 2-F', N'SLOT 2-F', 3, 2, CAST(N'2022-02-07T22:11:00.6666667' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (13, N'SLOT 3-A', N'SLOT 3-A', 1, 3, CAST(N'2022-02-07T22:11:00.6700000' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (14, N'SLOT 3-B', N'SLOT 3-B', 1, 3, CAST(N'2022-02-07T22:11:00.6700000' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (15, N'SLOT 3-C', N'SLOT 3-C', 2, 3, CAST(N'2022-02-07T22:11:00.6700000' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (16, N'SLOT 3-D', N'SLOT 3-D', 2, 3, CAST(N'2022-02-07T22:11:00.6700000' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (17, N'SLOT 3-E', N'SLOT 3-E', 3, 3, CAST(N'2022-02-07T22:11:00.6700000' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    INSERT [dbo].[Slots] ([ID], [Name], [Description], [SlotTypeID], [EntryPointID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy],[Status]) VALUES (18, N'SLOT 3-F', N'SLOT 3-F', 3, 3, CAST(N'2022-02-07T22:11:00.6700000' AS DateTime2), 1, NULL, NULL,0)
                                    GO
                                    SET IDENTITY_INSERT [dbo].[Slots] OFF
                                    GO
                                    SET IDENTITY_INSERT [dbo].[SlotRates] ON 
                                    GO
                                    INSERT [dbo].[SlotRates] ([ID], [SlotTypeID], [RatePerHour], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (1, 1, CAST(20.0000 AS Decimal(18, 4)), CAST(N'2022-02-07T22:11:00.6900000' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[SlotRates] ([ID], [SlotTypeID], [RatePerHour], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (2, 2, CAST(60.0000 AS Decimal(18, 4)), CAST(N'2022-02-07T22:11:00.6933333' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[SlotRates] ([ID], [SlotTypeID], [RatePerHour], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (3, 3, CAST(100.0000 AS Decimal(18, 4)), CAST(N'2022-02-07T22:11:00.6933333' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    SET IDENTITY_INSERT [dbo].[SlotRates] OFF
                                    GO
                                    SET IDENTITY_INSERT [dbo].[VehicleTypes] ON 
                                    GO
                                    INSERT [dbo].[VehicleTypes] ([ID], [Name], [Description], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (1, N'Small', N'Small', CAST(N'2022-02-07T22:11:00.6366667' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[VehicleTypes] ([ID], [Name], [Description], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (2, N'Medium', N'Medium', CAST(N'2022-02-07T22:11:00.6366667' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[VehicleTypes] ([ID], [Name], [Description], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (3, N'Large', N'Large', CAST(N'2022-02-07T22:11:00.6366667' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    SET IDENTITY_INSERT [dbo].[VehicleTypes] OFF
                                    GO
                                    SET IDENTITY_INSERT [dbo].[VehicleSlotAssignments] ON 
                                    GO
                                    INSERT [dbo].[VehicleSlotAssignments] ([ID], [SlotTypeID], [VehicleTypeID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (1, 1, 1, CAST(N'2022-02-07T00:00:00.0000000' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[VehicleSlotAssignments] ([ID], [SlotTypeID], [VehicleTypeID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (2, 2, 1, CAST(N'2022-02-07T00:00:00.0000000' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[VehicleSlotAssignments] ([ID], [SlotTypeID], [VehicleTypeID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (3, 3, 1, CAST(N'2022-02-07T00:00:00.0000000' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[VehicleSlotAssignments] ([ID], [SlotTypeID], [VehicleTypeID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (4, 3, 2, CAST(N'2022-02-07T00:00:00.0000000' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[VehicleSlotAssignments] ([ID], [SlotTypeID], [VehicleTypeID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (5, 2, 2, CAST(N'2022-02-07T00:00:00.0000000' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    INSERT [dbo].[VehicleSlotAssignments] ([ID], [SlotTypeID], [VehicleTypeID], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (6, 3, 3, CAST(N'2022-02-07T00:00:00.0000000' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    SET IDENTITY_INSERT [dbo].[VehicleSlotAssignments] OFF
                                    GO
                                    SET IDENTITY_INSERT [dbo].[BaseRates] ON 
                                    GO
                                    INSERT [dbo].[BaseRates] ([ID], [FlatRate], [ExcessRate], [ResetHours], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (1, CAST(40.0000 AS Decimal(18, 4)), CAST(5000.0000 AS Decimal(18, 4)), 1, CAST(N'2022-02-07T22:11:00.6900000' AS DateTime2), 1, NULL, NULL)
                                    GO
                                    SET IDENTITY_INSERT [dbo].[BaseRates] OFF
                                    GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
