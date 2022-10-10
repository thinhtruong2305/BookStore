IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(10) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Menus] (
    [MenuId] int NOT NULL IDENTITY,
    [ParentId] int NULL,
    [MenuName] nvarchar(70) NOT NULL DEFAULT N'Unknow',
    [Keyword] nvarchar(60) NOT NULL,
    [Decription] ntext NOT NULL,
    [Slug] varchar(MAX) NOT NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Menus] PRIMARY KEY ([MenuId])
);
GO

CREATE TABLE [Order] (
    [OrderId] int NOT NULL IDENTITY,
    [ShipName] nvarchar(60) NOT NULL DEFAULT N'Unknow',
    [ShipAdress] nvarchar(MAX) NOT NULL,
    [ShipPhone] varchar(12) NOT NULL,
    [TotalPrice] float NOT NULL,
    [OrderAt] datetime2 NOT NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY ([OrderId])
);
GO

CREATE TABLE [Series] (
    [SeriesId] int NOT NULL IDENTITY,
    [SeriesName] nvarchar(30) NOT NULL DEFAULT N'Unknow',
    [PlannedVolume] int NULL,
    [Keyword] nvarchar(60) NOT NULL,
    [Decription] ntext NOT NULL,
    [Slug] varchar(MAX) NOT NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Series] PRIMARY KEY ([SeriesId])
);
GO

CREATE TABLE [Tác giả] (
    [AuthorId] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(10) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [CountryOfResidence] nvarchar(20) NOT NULL,
    [Keyword] nvarchar(60) NOT NULL,
    [Decription] ntext NOT NULL,
    [Slug] varchar(MAX) NOT NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Tác giả] PRIMARY KEY ([AuthorId])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Info] (
    [InfoId] int NOT NULL IDENTITY,
    [SeriesId] int NOT NULL,
    [DiscountPercent] int NULL,
    [Language] nvarchar(20) NULL,
    [VolumeNumber] int NOT NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Info] PRIMARY KEY ([InfoId]),
    CONSTRAINT [FK_Info_Series_SeriesId] FOREIGN KEY ([SeriesId]) REFERENCES [Series] ([SeriesId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Book] (
    [BookId] int NOT NULL IDENTITY,
    [InfoId] int NOT NULL,
    [Title] nvarchar(70) NOT NULL DEFAULT N'Unknow',
    [Keyword] nvarchar(60) NOT NULL,
    [Decription] ntext NOT NULL,
    [Slug] varchar(MAX) NOT NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY ([BookId]),
    CONSTRAINT [FK_Book_Info_InfoId] FOREIGN KEY ([InfoId]) REFERENCES [Info] ([InfoId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Tag] (
    [TagId] int NOT NULL IDENTITY,
    [MenuId] int NOT NULL,
    [InfoId] int NOT NULL,
    [TagName] nvarchar(30) NOT NULL DEFAULT N'Unknow',
    [Keyword] nvarchar(60) NOT NULL,
    [Decription] ntext NOT NULL,
    [Slug] varchar(MAX) NOT NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY ([TagId]),
    CONSTRAINT [FK_Tag_Info_InfoId] FOREIGN KEY ([InfoId]) REFERENCES [Info] ([InfoId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Tag_Menus_MenuId] FOREIGN KEY ([MenuId]) REFERENCES [Menus] ([MenuId]) ON DELETE CASCADE
);
GO

CREATE TABLE [AuthorBooks] (
    [AuthorId] int NOT NULL,
    [BookId] int NOT NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_AuthorBooks] PRIMARY KEY ([AuthorId], [BookId]),
    CONSTRAINT [FK_AuthorBooks_Book_BookId] FOREIGN KEY ([BookId]) REFERENCES [Book] ([BookId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AuthorBooks_Tác giả_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Tác giả] ([AuthorId]) ON DELETE CASCADE
);
GO

CREATE TABLE [BookImages] (
    [BookImageId] int NOT NULL IDENTITY,
    [BookId] int NOT NULL,
    [FileUpload] nvarchar(max) NOT NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_BookImages] PRIMARY KEY ([BookImageId]),
    CONSTRAINT [FK_BookImages_Book_BookId] FOREIGN KEY ([BookId]) REFERENCES [Book] ([BookId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Edition] (
    [EditionId] int NOT NULL IDENTITY,
    [BookId] int NOT NULL,
    [PublisherId] int NOT NULL,
    [ISBN] char(10) NOT NULL DEFAULT 'Unknow',
    [PublicationDate] datetime2 NOT NULL,
    [Format] nvarchar(20) NOT NULL,
    [PrintRunSize] nvarchar(30) NOT NULL,
    [Price] money NOT NULL,
    [Pages] int NOT NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Edition] PRIMARY KEY ([EditionId]),
    CONSTRAINT [FK_Edition_Book_BookId] FOREIGN KEY ([BookId]) REFERENCES [Book] ([BookId]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrderDetail] (
    [OrderDetailId] int NOT NULL IDENTITY,
    [OrderId] int NOT NULL,
    [BookId] int NOT NULL,
    [Quantity] int NOT NULL,
    [DiscountPrice] decimal(18,2) NOT NULL,
    [Payment] decimal(18,2) NOT NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_OrderDetail] PRIMARY KEY ([OrderDetailId]),
    CONSTRAINT [FK_OrderDetail_Book_BookId] FOREIGN KEY ([BookId]) REFERENCES [Book] ([BookId]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderDetail_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([OrderId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Rating] (
    [RatingId] int NOT NULL IDENTITY,
    [UserName] nvarchar(60) NOT NULL,
    [BookId] int NOT NULL,
    [Rate] int NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Rating] PRIMARY KEY ([RatingId]),
    CONSTRAINT [FK_Rating_Book_BookId] FOREIGN KEY ([BookId]) REFERENCES [Book] ([BookId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Publisher] (
    [PublisherId] int NOT NULL IDENTITY,
    [PulishingHouse] nvarchar(50) NOT NULL DEFAULT N'Unknow',
    [Country] nvarchar(20) NOT NULL DEFAULT N'Unknow',
    [Keyword] nvarchar(60) NOT NULL,
    [Decription] ntext NOT NULL,
    [Slug] varchar(MAX) NOT NULL,
    [CreateBy] nvarchar(max) NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NULL,
    [UpdateAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Publisher] PRIMARY KEY ([PublisherId]),
    CONSTRAINT [FK_Publisher_Edition_PublisherId] FOREIGN KEY ([PublisherId]) REFERENCES [Edition] ([EditionId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

CREATE INDEX [IX_AuthorBooks_BookId] ON [AuthorBooks] ([BookId]);
GO

CREATE UNIQUE INDEX [IX_Book_InfoId] ON [Book] ([InfoId]);
GO

CREATE UNIQUE INDEX [IX_BookImages_BookId] ON [BookImages] ([BookId]);
GO

CREATE UNIQUE INDEX [IX_Edition_BookId] ON [Edition] ([BookId]);
GO

CREATE INDEX [IX_Info_SeriesId] ON [Info] ([SeriesId]);
GO

CREATE UNIQUE INDEX [IX_OrderDetail_BookId] ON [OrderDetail] ([BookId]);
GO

CREATE INDEX [IX_OrderDetail_OrderId] ON [OrderDetail] ([OrderId]);
GO

CREATE INDEX [IX_Rating_BookId] ON [Rating] ([BookId]);
GO

CREATE INDEX [IX_Tag_InfoId] ON [Tag] ([InfoId]);
GO

CREATE INDEX [IX_Tag_MenuId] ON [Tag] ([MenuId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221010072016_updateDatabase', N'6.0.9');
GO

COMMIT;
GO

