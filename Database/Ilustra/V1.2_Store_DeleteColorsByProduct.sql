CREATE OR ALTER PROCEDURE spDelete_ColorsByProduct 
@Colors NVARCHAR(MAX) = '',
@IdProduct INT = 0
AS
BEGIN
	IF LEN(@Colors) > 0 AND @IdProduct <> 0
	BEGIN
		DELETE ColorXProduct WHERE idProduct = @IdProduct AND idColor IN (SELECT value FROM STRING_SPLIT(@Colors,','))
	END
END

