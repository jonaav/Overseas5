
/*DATOS INICIALES*/

SET IDENTITY_INSERT [dbo].[Ambiente] ON 
INSERT [dbo].[Ambiente] ([IdAmbiente], [Estado], [Aula], [DescripcionAmbiente], [Direccion]) VALUES (1, 1, N'Aula A', N'Overseas', N'Av. Larco 383 B - Segundo Piso')
INSERT [dbo].[Ambiente] ([IdAmbiente], [Estado], [Aula], [DescripcionAmbiente], [Direccion]) VALUES (2, 1, N'Aula B', N'Overseas', N'Av. Larco 383 B - Segundo Piso')
INSERT [dbo].[Ambiente] ([IdAmbiente], [Estado], [Aula], [DescripcionAmbiente], [Direccion]) VALUES (3, 1, N'Aula C', N'Overseas', N'Av. Larco 383 B - Segundo Piso')
INSERT [dbo].[Ambiente] ([IdAmbiente], [Estado], [Aula], [DescripcionAmbiente], [Direccion]) VALUES (4, 1, N'Aula D', N'Overseas', N'Av. Larco 383 B - Segundo Piso')
INSERT [dbo].[Ambiente] ([IdAmbiente], [Estado], [Aula], [DescripcionAmbiente], [Direccion]) VALUES (5, 1, N'Aula E', N'Overseas', N'Av. Larco 383 B - Segundo Piso')
INSERT [dbo].[Ambiente] ([IdAmbiente], [Estado], [Aula], [DescripcionAmbiente], [Direccion]) VALUES (6, 1, N'Aula F', N'Overseas', N'Av. Larco 383 B - Segundo Piso')
SET IDENTITY_INSERT [dbo].[Ambiente] OFF

SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Admin', N'ADMIN', N'f0fe5070-1b3e-4f90-95bd-f946e59f6d34')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Docente', N'DOCENTE', N'3fa14f5c-3772-4037-8530-6990c5cf80f6')
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF


INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (2, 2)


SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StatusUser], [IdPersona]) VALUES (1, N'Administrador@Overseas.com', N'ADMINISTRADOR@OVERSEAS.COM', N'Administrador@Overseas.com', N'ADMINISTRADOR@OVERSEAS.COM', 0, N'AQAAAAEAACcQAAAAEOQ9ykbfSYH8ky9WW5gYwA8bRTWats8eGyLkebkdDfQ+6vK2yTS29m9AK/x/VYKQoA==', N'5OEW45BGL3O4TS7SAJBRZKIRI4KY5R5R', N'732247fa-b571-46d5-ac0a-f7157570e86f', NULL, 0, 0, NULL, 1, 0, 1, 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [StatusUser], [IdPersona]) VALUES (2, N'marioct@gmail.com', N'MARIOCT@GMAIL.COM', N'marioct@gmail.com', N'MARIOCT@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPPfPBkbg/PLxkW+4WBk3tn/teuxfy7ge9Nc2KI7Jt8nfrx+TcKYzcqaSH70YIX2Xg==', N'APRLMBJMKQEXVAUZ6M3FIM4J7QTOVPGJ', N'569af6ce-bed9-411c-a319-72da8205c41e', NULL, 0, 0, NULL, 1, 0, 1, 2)
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF


SET IDENTITY_INSERT [dbo].[DetalleDocenteEspecialidad] ON 
INSERT [dbo].[DetalleDocenteEspecialidad] ([IdDetalleDocenteEspecialidad], [IdDocente], [IdEspecialidad]) VALUES (7, 1, 2)
SET IDENTITY_INSERT [dbo].[DetalleDocenteEspecialidad] OFF


SET IDENTITY_INSERT [dbo].[Docente] ON 
INSERT [dbo].[Docente] ([IdDocente], [Estado], [IdPersona]) VALUES (1, 1, 2)
SET IDENTITY_INSERT [dbo].[Docente] OFF


SET IDENTITY_INSERT [dbo].[Especialidad] ON 
INSERT [dbo].[Especialidad] ([IdEspecialidad], [DescripcionEspecialidad]) VALUES (1, N'Ingles')
INSERT [dbo].[Especialidad] ([IdEspecialidad], [DescripcionEspecialidad]) VALUES (2, N'Frances')
INSERT [dbo].[Especialidad] ([IdEspecialidad], [DescripcionEspecialidad]) VALUES (3, N'Portugues')
INSERT [dbo].[Especialidad] ([IdEspecialidad], [DescripcionEspecialidad]) VALUES (4, N'Aleman')
INSERT [dbo].[Especialidad] ([IdEspecialidad], [DescripcionEspecialidad]) VALUES (5, N'Italiano')
SET IDENTITY_INSERT [dbo].[Especialidad] OFF


SET IDENTITY_INSERT [dbo].[Estudiante] ON 
INSERT [dbo].[Estudiante] ([IdEstudiante], [ReferenciaEstudiante], [PoseeApoderado], [IdPersona]) VALUES (1, N'facebook', 1, 3)
SET IDENTITY_INSERT [dbo].[Estudiante] OFF


SET IDENTITY_INSERT [dbo].[Persona] ON 
INSERT [dbo].[Persona] ([IdPersona], [DniPersona], [NombresPersona], [ApellidosPersona], [CorreoPersona], [FechaNacimientoPersona], [TelefonoPersona], [DireccionPersona]) VALUES (1, N'00000000', N'Overseas', N'Administrador', N'Administrador@gmail.com', CAST(N'1980-10-19T00:00:00.0000000' AS DateTime2), N'000000000', N'av Larco')
INSERT [dbo].[Persona] ([IdPersona], [DniPersona], [NombresPersona], [ApellidosPersona], [CorreoPersona], [FechaNacimientoPersona], [TelefonoPersona], [DireccionPersona]) VALUES (2, N'94658235', N'Mario Enrique', N'Cabrera Torres', N'marioct@gmail.com', CAST(N'1989-01-14T00:00:00.0000000' AS DateTime2), N'960883744', N'Jr. Ayacucho #644')
INSERT [dbo].[Persona] ([IdPersona], [DniPersona], [NombresPersona], [ApellidosPersona], [CorreoPersona], [FechaNacimientoPersona], [TelefonoPersona], [DireccionPersona]) VALUES (3, N'47885675', N'Juan Carlos', N'Villa Diaz', N'juancarlos@gmail.com', CAST(N'2020-01-14T00:00:00.0000000' AS DateTime2), N'988434333', N'Jr. Pizarro #444')
SET IDENTITY_INSERT [dbo].[Persona] OFF


SET IDENTITY_INSERT [dbo].[TipoCurso] ON 
INSERT [dbo].[TipoCurso] ([IdTipoCurso], [NombreCurso]) VALUES (1, N'Ingles Niños')
INSERT [dbo].[TipoCurso] ([IdTipoCurso], [NombreCurso]) VALUES (2, N'Ingles Regular')
INSERT [dbo].[TipoCurso] ([IdTipoCurso], [NombreCurso]) VALUES (3, N'P. Exam. Internacional')
INSERT [dbo].[TipoCurso] ([IdTipoCurso], [NombreCurso]) VALUES (4, N'Coorporativo')
INSERT [dbo].[TipoCurso] ([IdTipoCurso], [NombreCurso]) VALUES (5, N'Domicilio')
INSERT [dbo].[TipoCurso] ([IdTipoCurso], [NombreCurso]) VALUES (6, N'Otros Idiomas')
SET IDENTITY_INSERT [dbo].[TipoCurso] OFF


SET IDENTITY_INSERT [dbo].[TipoEvaluacion] ON 
INSERT [dbo].[TipoEvaluacion] ([IdTipoEvaluacion], [NombreEvaluacion]) VALUES (1, N'Listening')
INSERT [dbo].[TipoEvaluacion] ([IdTipoEvaluacion], [NombreEvaluacion]) VALUES (2, N'Writing')
INSERT [dbo].[TipoEvaluacion] ([IdTipoEvaluacion], [NombreEvaluacion]) VALUES (3, N'Reading')
SET IDENTITY_INSERT [dbo].[TipoEvaluacion] OFF