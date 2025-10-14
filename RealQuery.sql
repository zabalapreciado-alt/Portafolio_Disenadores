-- 1. Tabla Usuarios
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario NVARCHAR(50) NOT NULL,
    Contraseña NVARCHAR(50) NOT NULL,
    Rol NVARCHAR(20) NOT NULL -- admin, diseñador, reclutador
);
GO

-- 2. Tabla Diseñadores
CREATE TABLE Diseñadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT NOT NULL,
    Nombre NVARCHAR(100),
    Especialidad NVARCHAR(100),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);
GO

-- 3. Tabla Reclutadores
CREATE TABLE Reclutadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT NOT NULL,
    Empresa NVARCHAR(100),
    Contacto NVARCHAR(100),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);
GO

-- 4. Tabla Proyectos
CREATE TABLE Proyectos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DiseñadorId INT NOT NULL,
    Titulo NVARCHAR(100),
    Descripcion NVARCHAR(MAX),
    Categoria NVARCHAR(50),
    RutaImagen NVARCHAR(255),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (DiseñadorId) REFERENCES Diseñadores(Id)
);
GO

-- 5. Tabla Likes
CREATE TABLE Likes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProyectoId INT NOT NULL,
    UsuarioId INT NULL, -- puede ser anónimo
    Fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ProyectoId) REFERENCES Proyectos(Id),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);
GO

-- 6. Tabla Comentarios
CREATE TABLE Comentarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProyectoId INT NOT NULL,
    UsuarioId INT NULL, -- puede ser anónimo
    Texto NVARCHAR(MAX),
    Fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ProyectoId) REFERENCES Proyectos(Id),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);
GO

-- 7. Tabla OfertasTrabajo
CREATE TABLE OfertasTrabajo (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ReclutadorId INT NOT NULL,
    DiseñadorId INT NOT NULL,
    Titulo NVARCHAR(100),
    Descripcion NVARCHAR(MAX),
    Contacto NVARCHAR(100),
    Estado NVARCHAR(20) DEFAULT 'Pendiente', -- Pendiente, Aceptada, Rechazada
    Fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ReclutadorId) REFERENCES Reclutadores(Id),
    FOREIGN KEY (DiseñadorId) REFERENCES Diseñadores(Id)
);
GO

--8. tabla Perfiles
CREATE TABLE Perfiles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DiseñadorId INT NOT NULL UNIQUE,
    Biografia NVARCHAR(MAX) NULL,
    WhatsApp NVARCHAR(20) NULL,
    Instagram NVARCHAR(100) NULL,
    CorreoContacto NVARCHAR(100) NULL,
    FechaActualizacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (DiseñadorId) REFERENCES Diseñadores(Id)
);
GO


-- Usuario admin
INSERT INTO Usuarios (NombreUsuario, Contraseña, Rol)
VALUES ('mariaclara', '1234', 'admin');

-- Usuario diseñador
INSERT INTO Usuarios (NombreUsuario, Contraseña, Rol)
VALUES ('juan', '1234', 'diseñador');

-- Usuario reclutador
INSERT INTO Usuarios (NombreUsuario, Contraseña, Rol)
VALUES ('empresaX', '1234', 'reclutador');

-- Diseñador vinculado
INSERT INTO Diseñadores (UsuarioId, Nombre, Especialidad)
VALUES (2, 'Juan Pérez', 'Branding y UI/UX');

-- Reclutador vinculado
INSERT INTO Reclutadores (UsuarioId, Empresa, Contacto)
VALUES (3, 'Empresa X', 'empresaX@correo.com');

-- Proyecto de prueba
INSERT INTO Proyectos (DiseñadorId, Titulo, Descripcion, Categoria, RutaImagen)
VALUES (1, 'Logo Minimalista', 'Proyecto de branding con estilo minimalista.', 'Branding', 'C:\\imagenes\\logo.jpg');