CREATE TABLE [dbo].[BasketPaymentInfo]
(
	[BasketID] INT NOT NULL, 
    [PaymentInfoID] INT NOT NULL, 
    CONSTRAINT [FK_BasketPaymentInfo_Basket] FOREIGN KEY (BasketID) REFERENCES Basket(Id), 
    CONSTRAINT [FK_BasketPaymentInfo_PaymentInfo] FOREIGN KEY (PaymentInfoID) REFERENCES PaymentInfo(Id), 
    CONSTRAINT [PK_BasketPaymentInfo] PRIMARY KEY ([BasketID], [PaymentInfoID]) 
)
