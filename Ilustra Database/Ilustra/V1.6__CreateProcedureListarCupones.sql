CREATE OR ALTER PROCEDURE sp_LisarCupones
(
	@CantidadPagina  AS INT,
	@Pagina AS INT NULL,
	@Busqueda AS StringArray READONLY
)
AS
BEGIN
	SELECT COUNT(1) OVER() Total,
	c.IdCupon, c.CodigoCupon, c.Activo, c.EnUso, c.Valor, c.FechaRegistro,
	u.Username[Usuario], u.IdUsuario
	FROM Cupon c
	INNER JOIN Usuario u ON c.Usuario = u.IdUsuario
	WHERE c.Eliminado = 0 AND ((SELECT COUNT(1) FROM @Busqueda) = 0 OR EXISTS (SELECT [Value] FROM @Busqueda 
	WHERE u.Username LIKE CONCAT('%', [Value],'%') OR c.CodigoCupon LIKE CONCAT('%', [Value],'%')))
	ORDER BY c.FechaRegistro DESC
	OFFSET (@Pagina - 1) * @CantidadPagina ROWS
	FETCH NEXT @CantidadPagina ROWS ONLY
END
