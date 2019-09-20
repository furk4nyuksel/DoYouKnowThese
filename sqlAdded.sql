 
Use DoYouNowThese


Create Table AppUser(AppUserId int identity primary key,Name nvarchar(100),Surname nvarchar(100),Username nvarchar(50),Email nvarchar(200),Password nvarchar(max),ResetKeyCode nvarchar(50),CreateDate datetime  not null,IsActive  bit  not null ,IsDeleted bit not null)


Create Table Category(CategoryId int identity primary key,Name nvarchar(100),CategoryImagePath nvarchar(max),CreateDate datetime  not null  ,IsActive bit  not null  ,IsDeleted bit  not null)

Create Table InformationContent(InformationContentId int identity primary key,Title nvarchar(150),Explanation nvarchar(max),PostImagePath nvarchar(max),CategoryId int references Category(CategoryId),AuthorId int references AppUser(AppUserId),LikeCount int not null ,CreateDate datetime    not null,IsActive  bit  not null ,IsDeleted bit  not null )

Create Table InformationReadLog(InformationReadLogId int identity primary key,AppUserId int references AppUser(AppUserId),InformationContentId int references InformationContent(InformationContentId),CreateDate datetime  not null,IsActive bit  not null,IsDeleted bit  not null)
