CREATE TABLE Amazon 
(
    ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name varchar(255) NOT NULL
);

INSERT INTO [dbo].Amazon (Name) 
VALUES ('India');
INSERT INTO [dbo].Amazon (Name) 
VALUES ('Canada');
INSERT INTO [dbo].Amazon (Name) 
VALUES ('USA');

Select * from Amazon;

CREATE TABLE Orders 
(
    ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
    UserName varchar(255) NOT NULL,
    Cost int,
	ItemQty int,
	CreatedDate DateTime,
	UpdatedDate DateTime,
	AmazonID int NOT NULL FOREIGN KEY REFERENCES Amazon(Id)
);

INSERT INTO [dbo].Orders ([UserName], [Cost], [ItemQty], [CreatedDate], [UpdatedDate], [AmazonID]) 
VALUES ('John' ,100000 ,2, '2022-04-01T12:00:00', '2022-04-01T12:00:00', 1 );
INSERT INTO [dbo].Orders ([UserName], [Cost], [ItemQty], [CreatedDate], [UpdatedDate], [AmazonID]) 
VALUES ('Mary' ,30000 ,4, '2022-03-01T12:00:00', '2022-04-01T12:00:00', 1 );
INSERT INTO [dbo].Orders ([UserName], [Cost], [ItemQty], [CreatedDate], [UpdatedDate], [AmazonID]) 
VALUES ('Scott' ,20000 ,5, '2022-01-01T12:00:00', '2022-04-01T12:00:00', 1 );

Select * from Orders;
