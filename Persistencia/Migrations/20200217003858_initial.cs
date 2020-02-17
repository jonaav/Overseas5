using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ambiente",
                columns: table => new
                {
                    IdAmbiente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<int>(nullable: false),
                    Aula = table.Column<string>(nullable: true),
                    DescripcionAmbiente = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambiente", x => x.IdAmbiente);
                });

            migrationBuilder.CreateTable(
                name: "Apoderado",
                columns: table => new
                {
                    IdApoderado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombresApoderado = table.Column<string>(nullable: true),
                    ApellidosApoderado = table.Column<string>(nullable: true),
                    CorreoApoderado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apoderado", x => x.IdApoderado);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    IdEspecialidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescripcionEspecialidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.IdEspecialidad);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IdPersona = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DniPersona = table.Column<string>(nullable: true),
                    NombresPersona = table.Column<string>(nullable: true),
                    ApellidosPersona = table.Column<string>(nullable: true),
                    CorreoPersona = table.Column<string>(nullable: true),
                    FechaNacimientoPersona = table.Column<DateTime>(nullable: false),
                    TelefonoPersona = table.Column<string>(nullable: true),
                    DireccionPersona = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.IdPersona);
                });

            migrationBuilder.CreateTable(
                name: "TipoCurso",
                columns: table => new
                {
                    IdTipoCurso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreCurso = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCurso", x => x.IdTipoCurso);
                });

            migrationBuilder.CreateTable(
                name: "TipoEvaluacion",
                columns: table => new
                {
                    IdTipoEvaluacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreEvaluacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvaluacion", x => x.IdTipoEvaluacion);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    StatusUser = table.Column<int>(nullable: false),
                    IdPersona = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Persona_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    IdDocente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<int>(nullable: false),
                    IdPersona = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.IdDocente);
                    table.ForeignKey(
                        name: "FK_Docente_Persona_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReferenciaEstudiante = table.Column<string>(nullable: true),
                    PoseeApoderado = table.Column<int>(nullable: false),
                    IdPersona = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.IdEstudiante);
                    table.ForeignKey(
                        name: "FK_Estudiante_Persona_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoCursoTipoEvaluacion",
                columns: table => new
                {
                    idTipoCursoTipoEvaluacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTipoCurso = table.Column<int>(nullable: false),
                    IdTipoEvaluacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCursoTipoEvaluacion", x => x.idTipoCursoTipoEvaluacion);
                    table.ForeignKey(
                        name: "FK_TipoCursoTipoEvaluacion_TipoCurso_IdTipoCurso",
                        column: x => x.IdTipoCurso,
                        principalTable: "TipoCurso",
                        principalColumn: "IdTipoCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoCursoTipoEvaluacion_TipoEvaluacion_IdTipoEvaluacion",
                        column: x => x.IdTipoEvaluacion,
                        principalTable: "TipoEvaluacion",
                        principalColumn: "IdTipoEvaluacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    IdCurso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    Idioma = table.Column<string>(nullable: true),
                    Nivel = table.Column<string>(nullable: true),
                    Programa = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    Ciclo = table.Column<int>(nullable: false),
                    ModalidadEstudiantes = table.Column<string>(nullable: true),
                    Detalle = table.Column<string>(nullable: true),
                    IdTipoCurso = table.Column<int>(nullable: false),
                    IdDocente = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.IdCurso);
                    table.ForeignKey(
                        name: "FK_Curso_Docente_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "Docente",
                        principalColumn: "IdDocente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curso_TipoCurso_IdTipoCurso",
                        column: x => x.IdTipoCurso,
                        principalTable: "TipoCurso",
                        principalColumn: "IdTipoCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleDocenteEspecialidad",
                columns: table => new
                {
                    IdDetalleDocenteEspecialidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdDocente = table.Column<int>(nullable: false),
                    IdEspecialidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDocenteEspecialidad", x => x.IdDetalleDocenteEspecialidad);
                    table.ForeignKey(
                        name: "FK_DetalleDocenteEspecialidad_Docente_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "Docente",
                        principalColumn: "IdDocente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleDocenteEspecialidad_Especialidad_IdEspecialidad",
                        column: x => x.IdEspecialidad,
                        principalTable: "Especialidad",
                        principalColumn: "IdEspecialidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Traduccion",
                columns: table => new
                {
                    IdTraduccion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteTraduccion = table.Column<string>(nullable: true),
                    TipoTraduccion = table.Column<string>(nullable: true),
                    DetalleTraduccion = table.Column<string>(nullable: true),
                    IdiomaOrigenTraduccion = table.Column<string>(nullable: true),
                    IdiomaDestinoTraduccion = table.Column<string>(nullable: true),
                    FechaTraduccion = table.Column<DateTime>(nullable: false),
                    EstadoTraduccion = table.Column<int>(nullable: false),
                    IdDocente = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traduccion", x => x.IdTraduccion);
                    table.ForeignKey(
                        name: "FK_Traduccion_Docente_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "Docente",
                        principalColumn: "IdDocente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleApoderadoEstudiante",
                columns: table => new
                {
                    IdDetalleApodEst = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEstudiante = table.Column<int>(nullable: false),
                    IdApoderado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleApoderadoEstudiante", x => x.IdDetalleApodEst);
                    table.ForeignKey(
                        name: "FK_DetalleApoderadoEstudiante_Apoderado_IdApoderado",
                        column: x => x.IdApoderado,
                        principalTable: "Apoderado",
                        principalColumn: "IdApoderado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleApoderadoEstudiante_Estudiante_IdEstudiante",
                        column: x => x.IdEstudiante,
                        principalTable: "Estudiante",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistorialEvaluacion",
                columns: table => new
                {
                    IdHistorialEvaluacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FeedbackHistorialEvaluacion = table.Column<string>(nullable: true),
                    IdEstudiante = table.Column<int>(nullable: false),
                    IdCurso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialEvaluacion", x => x.IdHistorialEvaluacion);
                    table.ForeignKey(
                        name: "FK_HistorialEvaluacion_Curso_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialEvaluacion_Estudiante_IdEstudiante",
                        column: x => x.IdEstudiante,
                        principalTable: "Estudiante",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    IdHorario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dia = table.Column<string>(nullable: true),
                    HoraFin = table.Column<TimeSpan>(nullable: false),
                    HoraInicio = table.Column<TimeSpan>(nullable: false),
                    IdCurso = table.Column<int>(nullable: false),
                    IdAmbiente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.IdHorario);
                    table.ForeignKey(
                        name: "FK_Horario_Ambiente_IdAmbiente",
                        column: x => x.IdAmbiente,
                        principalTable: "Ambiente",
                        principalColumn: "IdAmbiente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Horario_Curso_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    IdInscripcion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstadoInscripcion = table.Column<int>(nullable: false),
                    FechaInscripcion = table.Column<DateTime>(nullable: false),
                    IdEstudiante = table.Column<int>(nullable: false),
                    IdCurso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.IdInscripcion);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Curso_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Estudiante_IdEstudiante",
                        column: x => x.IdEstudiante,
                        principalTable: "Estudiante",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluacion",
                columns: table => new
                {
                    IdEvaluacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CalificacionEvaluacion = table.Column<int>(nullable: false),
                    IdHistorialEvaluacion = table.Column<int>(nullable: false),
                    IdTipoEvaluacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluacion", x => x.IdEvaluacion);
                    table.ForeignKey(
                        name: "FK_Evaluacion_HistorialEvaluacion_IdHistorialEvaluacion",
                        column: x => x.IdHistorialEvaluacion,
                        principalTable: "HistorialEvaluacion",
                        principalColumn: "IdHistorialEvaluacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluacion_TipoEvaluacion_IdTipoEvaluacion",
                        column: x => x.IdTipoEvaluacion,
                        principalTable: "TipoEvaluacion",
                        principalColumn: "IdTipoEvaluacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesion",
                columns: table => new
                {
                    IdSesion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AsistenciaDocente = table.Column<int>(nullable: false),
                    FechaSesion = table.Column<DateTime>(nullable: false),
                    NumeroSesion = table.Column<int>(nullable: false),
                    IdHorario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesion", x => x.IdSesion);
                    table.ForeignKey(
                        name: "FK_Sesion_Horario_IdHorario",
                        column: x => x.IdHorario,
                        principalTable: "Horario",
                        principalColumn: "IdHorario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asistencia",
                columns: table => new
                {
                    IdAsistencia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AsistenciaEstudiante = table.Column<int>(nullable: false),
                    IdEstudiante = table.Column<int>(nullable: false),
                    IdSesion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencia", x => x.IdAsistencia);
                    table.ForeignKey(
                        name: "FK_Asistencia_Estudiante_IdEstudiante",
                        column: x => x.IdEstudiante,
                        principalTable: "Estudiante",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencia_Sesion_IdSesion",
                        column: x => x.IdSesion,
                        principalTable: "Sesion",
                        principalColumn: "IdSesion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_IdEstudiante",
                table: "Asistencia",
                column: "IdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_IdSesion",
                table: "Asistencia",
                column: "IdSesion");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdPersona",
                table: "AspNetUsers",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_IdDocente",
                table: "Curso",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_IdTipoCurso",
                table: "Curso",
                column: "IdTipoCurso");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleApoderadoEstudiante_IdApoderado",
                table: "DetalleApoderadoEstudiante",
                column: "IdApoderado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleApoderadoEstudiante_IdEstudiante",
                table: "DetalleApoderadoEstudiante",
                column: "IdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDocenteEspecialidad_IdDocente",
                table: "DetalleDocenteEspecialidad",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDocenteEspecialidad_IdEspecialidad",
                table: "DetalleDocenteEspecialidad",
                column: "IdEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Docente_IdPersona",
                table: "Docente",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_IdPersona",
                table: "Estudiante",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_IdHistorialEvaluacion",
                table: "Evaluacion",
                column: "IdHistorialEvaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_IdTipoEvaluacion",
                table: "Evaluacion",
                column: "IdTipoEvaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEvaluacion_IdCurso",
                table: "HistorialEvaluacion",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEvaluacion_IdEstudiante",
                table: "HistorialEvaluacion",
                column: "IdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_IdAmbiente",
                table: "Horario",
                column: "IdAmbiente");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_IdCurso",
                table: "Horario",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_IdCurso",
                table: "Inscripcion",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_IdEstudiante",
                table: "Inscripcion",
                column: "IdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Sesion_IdHorario",
                table: "Sesion",
                column: "IdHorario");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCursoTipoEvaluacion_IdTipoCurso",
                table: "TipoCursoTipoEvaluacion",
                column: "IdTipoCurso");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCursoTipoEvaluacion_IdTipoEvaluacion",
                table: "TipoCursoTipoEvaluacion",
                column: "IdTipoEvaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_Traduccion_IdDocente",
                table: "Traduccion",
                column: "IdDocente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencia");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DetalleApoderadoEstudiante");

            migrationBuilder.DropTable(
                name: "DetalleDocenteEspecialidad");

            migrationBuilder.DropTable(
                name: "Evaluacion");

            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "TipoCursoTipoEvaluacion");

            migrationBuilder.DropTable(
                name: "Traduccion");

            migrationBuilder.DropTable(
                name: "Sesion");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Apoderado");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "HistorialEvaluacion");

            migrationBuilder.DropTable(
                name: "TipoEvaluacion");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Ambiente");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "TipoCurso");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
