CREATE OR ALTER PROCEDURE sp_ListarEntidadesEcommerce
(
	@Pagina AS INT NULL,
	@CantidadPagina AS INT,
	@Busqueda AS StringArray READONLY,
	@TipoEntidad AS VARCHAR(20)
)
AS
BEGIN
	IF @TipoEntidad = 'Producto'
	BEGIN 
		SELECT COUNT(1) OVER() Total,
		p.IdProducto, p.NombreProducto, p.Descripcion, p.Activo, (SELECT COUNT(*) FROM DisenioProducto dp WHERE p.IdProducto = dp.Producto)[CantidadDisenios], p.CodigoImagen[CodigoEntidad],p.PrecioBase,
		p.Colores,
		--Categoria
		c.IdCategoria, c.NombreCategoria[Categoria],
		--Dimension
		d.IdDimension, d.NombreDimension[Dimension],
		--Archivo
		a.NombreArchivo, a.TipoArchivo, a.Content

		FROM Producto p
		INNER JOIN Categoria c ON c.IdCategoria = p.Categoria
		INNER JOIN Dimension d ON d.IdDimension = p.Dimension
		LEFT JOIN Archivo a ON a.CodigoEntidad = p.CodigoImagen
		WHERE p.Eliminado = 0 AND a.Eliminado = 0 AND ((
		SELECT COUNT(1) FROM @Busqueda) = 0 OR EXISTS (SELECT [Value] FROM @Busqueda 
		WHERE p.NombreProducto LIKE CONCAT('%', [Value],'%') OR c.NombreCategoria LIKE CONCAT('%', [Value],'%') OR d.NombreDimension LIKE CONCAT('%', [Value],'%')))
		ORDER BY p.FechaRegistro DESC
		OFFSET (@Pagina - 1) * @CantidadPagina ROWS
		FETCH NEXT @CantidadPagina ROWS ONLY
	END
	ELSE IF @TipoEntidad = 'Categoria'
	BEGIN 
		SELECT COUNT(1) OVER() Total,
		c.IdCategoria, c.NombreCategoria, (SELECT COUNT(*) FROM Producto p WHERE p.Categoria = c.IdCategoria)[ProductosPorCategoria]
		FROM Categoria c
		WHERE ((SELECT COUNT(1) FROM @Busqueda) = 0 OR EXISTS (SELECT [Value] FROM @Busqueda 
		WHERE c.NombreCategoria LIKE CONCAT('%', [Value],'%')))
		ORDER BY c.FechaRegistro DESC
		OFFSET (@Pagina - 1) * @CantidadPagina ROWS
		FETCH NEXT @CantidadPagina ROWS ONLY
	END
	ELSE IF @TipoEntidad = 'Color'
	BEGIN
		SELECT COUNT(1) OVER() Total,
		c.IdColor, c.CodigoColor, c.Descripcion, c.Activo, a.Content, a.TipoArchivo, a.NombreArchivo
		FROM Color c
		INNER JOIN Archivo a ON a.CodigoEntidad = c.CodigoColor AND a.Eliminado = 0
		WHERE c.Eliminado = 0 AND  ((SELECT COUNT(1) FROM @Busqueda) = 0 OR EXISTS (SELECT [Value] FROM @Busqueda 
		WHERE c.Descripcion LIKE CONCAT('%', [Value],'%')))
		ORDER BY c.FechaRegistro DESC
		OFFSET (@Pagina - 1) * @CantidadPagina ROWS
		FETCH NEXT @CantidadPagina ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT COUNT(1) OVER() Total,
		d.IdDimension, d.NombreDimension, (SELECT COUNT(*) FROM Producto p WHERE p.Dimension = d.IdDimension)[ProductosPorDimension]
		FROM Dimension d
		WHERE ((SELECT COUNT(1) FROM @Busqueda) = 0 OR EXISTS (SELECT [Value] FROM @Busqueda 
		WHERE d.NombreDimension LIKE CONCAT('%', [Value],'%')))
		ORDER BY d.FechaRegistro DESC
		OFFSET (@Pagina - 1) * @CantidadPagina ROWS
		FETCH NEXT @CantidadPagina ROWS ONLY
	END
END