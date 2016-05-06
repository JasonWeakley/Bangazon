CREATE TABLE [dbo].[Customer] (
  [IdCustomer]    INT          NOT NULL,
  [FirstName]     VARCHAR (55) NULL,
  [LastName]      VARCHAR (55) NULL,
  [StreetAddress] VARCHAR (55) NULL,
  [City]          VARCHAR (55) NULL,
  [StateProvince] VARCHAR (55) NULL,
  [PostalCode]    INT          NULL,
  [PhoneNumber]   VARCHAR (12) NULL,
  PRIMARY KEY CLUSTERED ([IdCustomer] ASC)
);