INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'16ad5b3d-e38b-475a-a1b3-71853894dce1', N'admin@stocks.com', N'ADMIN@STOCKS.COM', N'admin@stocks.com', N'ADMIN@STOCKS.COM', 1, N'AQAAAAEAACcQAAAAEESKS80ryRuGuy2UE8ngAR7f1tjq6NuFC7PoXhe1alrXimB7HNzmpCIJ27Er8Uu0dw==', N'TCKDVH5VA4RP7FWORD73LGHSAAGMCOIV', N'a442319a-1d06-475d-af2d-64dac0737c84', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a4e3bed4-f6f1-4752-ad17-c5f64f42a007', N'james@stocks.com', N'JAMES@STOCKS.COM', N'james@stocks.com', N'JAMES@STOCKS.COM', 1, N'AQAAAAEAACcQAAAAEC2LyvJI46VsvM0JCSFgMnguELD/x6gY8vexgitlzGJUkrnLIyl/NJxtmlfUmVl3gg==', N'QIHLZNXGDERBY6ZRS3XMLKEBH6QNBZEZ', N'7661e999-bf89-454d-9e77-21673816582e', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'39e61a55-b431-48dc-bce0-43d0313c1fd2', N'stocks_buyer', N'stocks_buyer', N'e3d32331-9961-4361-96d3-96ba12a3f4e9')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd04fb392-7dec-4934-98bd-6056324bfb6d', N'stock_admin', N'stock_admin', N'21a1fe38-dca4-4355-af4f-102b176052f6')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a4e3bed4-f6f1-4752-ad17-c5f64f42a007', N'39e61a55-b431-48dc-bce0-43d0313c1fd2')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'16ad5b3d-e38b-475a-a1b3-71853894dce1', N'd04fb392-7dec-4934-98bd-6056324bfb6d')
SET IDENTITY_INSERT [dbo].[Company] ON
INSERT INTO [dbo].[Company] ([Id], [CompanyName], [NumberOfTotalStocks], [StocksSold], [StockPrice]) VALUES (1, N'Bio Tech', 20000, 200, CAST(70.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Company] ([Id], [CompanyName], [NumberOfTotalStocks], [StocksSold], [StockPrice]) VALUES (2, N'Automobile Inc.', 40000, 1000, CAST(90.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Company] ([Id], [CompanyName], [NumberOfTotalStocks], [StocksSold], [StockPrice]) VALUES (3, N'Digital World', 60000, 800, CAST(120.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[StocksBuyer] ON
INSERT INTO [dbo].[StocksBuyer] ([Id], [BuyerName], [EmailAddress]) VALUES (1, N'James Wilson', N'james@stocks.com')
SET IDENTITY_INSERT [dbo].[StocksBuyer] OFF
SET IDENTITY_INSERT [dbo].[StocksPayment] ON
INSERT INTO [dbo].[StocksPayment] ([Id], [CompanyId], [StocksBuyerId], [NumberOfStocks]) VALUES (3, 3, 1, 800)
INSERT INTO [dbo].[StocksPayment] ([Id], [CompanyId], [StocksBuyerId], [NumberOfStocks]) VALUES (4, 1, 1, 200)
INSERT INTO [dbo].[StocksPayment] ([Id], [CompanyId], [StocksBuyerId], [NumberOfStocks]) VALUES (5, 2, 1, 1000)
SET IDENTITY_INSERT [dbo].[StocksPayment] OFF
