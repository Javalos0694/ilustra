CREATE OR ALTER PROCEDURE spDelete_ItemsByProduct 
@Items NVARCHAR(MAX) = '',
@IdProduct INT = 0,
@ItemType VARCHAR(30) = 'color'
AS
BEGIN
	IF LEN(@Items) > 0 AND @IdProduct <> 0
	BEGIN
		IF @ItemType = 'color'
		BEGIN
			DELETE ColorXProduct WHERE idProduct = @IdProduct AND idColor IN (SELECT value FROM STRING_SPLIT(@Items,','))
		END

		IF @ItemType = 'dimension'
		BEGIN
			DELETE DimensionXProduct WHERE idProduct = @IdProduct AND idDimension IN (SELECT value FROM STRING_SPLIT(@Items,','))
		END
	END
END