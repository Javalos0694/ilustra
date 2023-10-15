CREATE OR ALTER PROCEDURE sp_ListarUsuarios
(
	@CantidadPagina  AS INT,
	@Pagina AS INT NULL,
	@Tipo AS VARCHAR(15),
	@Busqueda AS StringArray READONLY
)
AS
BEGIN
	IF @Tipo = ''
	BEGIN
		SELECT COUNT(1) OVER() Total,
		u.IdUsuario, u.Username, u.Activo, u.FechaRegistro,
		-- Persona
		p.Nombre, p.Apellido, p.TipoDocumento, p.NumeroDocumento, p.CorreoElectronico, p.FechaNacimiento, p.IdPersona, p.Telefono,
		--Perfil
		pf.Descripcion [NombrePerfil], pf.IdPerfil[Perfil]
		FROM Usuario u
		INNER JOIN Persona p ON p.IdPersona = u.Persona
		INNER JOIN Perfil pf ON pf.IdPerfil = u.Perfil
		WHERE u.Eliminado = 0 AND ((
		SELECT COUNT(1) FROM @Busqueda) = 0 OR EXISTS (SELECT [Value] FROM @Busqueda 
		WHERE u.Username LIKE CONCAT('%', [Value],'%') OR p.Nombre LIKE CONCAT('%', [Value],'%') OR p.Apellido LIKE CONCAT('%', [Value],'%')))
		ORDER BY u.IdUsuario
		OFFSET (@Pagina - 1) * @CantidadPagina ROWS
		FETCH NEXT @CantidadPagina ROWS ONLY
	END
	ELSE IF @TIPO = 'Cliente'
	BEGIN
		SELECT COUNT(1) OVER() Total,
		u.IdUsuario, u.Username, u.Activo, u.FechaRegistro,
		-- Persona
		p.Nombre, p.Apellido, p.TipoDocumento, p.NumeroDocumento, p.CorreoElectronico, p.FechaNacimiento, p.IdPersona, p.Telefono,
		--Perfil
		pf.Descripcion [NombrePerfil], pf.IdPerfil[Perfil]
		FROM Usuario u
		INNER JOIN Persona p ON p.IdPersona = u.Persona
		INNER JOIN Perfil pf ON pf.IdPerfil = u.Perfil
		WHERE u.Eliminado = 0 AND pf.IdPerfil = 3 AND ((
		SELECT COUNT(1) FROM @Busqueda) = 0 OR EXISTS (SELECT [Value] FROM @Busqueda 
		WHERE u.Username LIKE CONCAT('%', [Value],'%') OR p.Nombre LIKE CONCAT('%', [Value],'%') OR p.Apellido LIKE CONCAT('%', [Value],'%')))
		ORDER BY u.IdUsuario
		OFFSET (@Pagina - 1) * @CantidadPagina ROWS
		FETCH NEXT @CantidadPagina ROWS ONLY
	END
	ELSE
	BEGIN 
		SELECT COUNT(1) OVER() Total,
		u.IdUsuario, u.Username, u.Activo, u.FechaRegistro,
		-- Persona
		p.Nombre, p.Apellido, p.TipoDocumento, p.NumeroDocumento, p.CorreoElectronico, p.FechaNacimiento, p.IdPersona, p.Telefono,
		--Perfil
		pf.Descripcion [NombrePerfil], pf.IdPerfil[Perfil],
		--Aliado
		a.NombreComercial, ISNULL((SELECT COUNT(*) FROM Disenio d WHERE a.IdAliado = d.Aliado),0)[CantidadDisenios]
		FROM Usuario u
		INNER JOIN Persona p ON p.IdPersona = u.Persona
		INNER JOIN Perfil pf ON pf.IdPerfil = u.Perfil
		LEFT JOIN Aliado a ON a.Persona = p.IdPersona
		WHERE u.Eliminado = 0 AND pf.IdPerfil = 2 AND ((
		SELECT COUNT(1) FROM @Busqueda) = 0 OR EXISTS (SELECT [Value] FROM @Busqueda 
		WHERE u.Username LIKE CONCAT('%', [Value],'%') OR p.Nombre LIKE CONCAT('%', [Value],'%') OR p.Apellido LIKE CONCAT('%', [Value],'%')))
		ORDER BY u.IdUsuario
		OFFSET (@Pagina - 1) * @CantidadPagina ROWS
		FETCH NEXT @CantidadPagina ROWS ONLY
	END
END



