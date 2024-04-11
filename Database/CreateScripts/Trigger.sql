﻿CREATE OR ALTER TRIGGER CUSTOMER_TG
ON [customer]
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @NextID INT 
    SELECT @Next = NEXT VALUE FOR custonmer_seq;


    PRINT 'Customer already added.'
END;
GO
