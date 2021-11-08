﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20211009110011_corregidaconpartidos")]
    partial class corregidaconpartidos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Arbitro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Colegio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Arbitros");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.DirectorTecnico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DirectoresTecnicos");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CantidadPartidosEmpatados")
                        .HasColumnType("int");

                    b.Property<int>("CantidadPartidosGanados")
                        .HasColumnType("int");

                    b.Property<int>("CantidadPartidosJugados")
                        .HasColumnType("int");

                    b.Property<int?>("DirectorTecnicoId")
                        .HasColumnType("int");

                    b.Property<int>("GolesAFavor")
                        .HasColumnType("int");

                    b.Property<int>("GolesEnContra")
                        .HasColumnType("int");

                    b.Property<int?>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Puntos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DirectorTecnicoId");

                    b.HasIndex("MunicipioId");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Estadio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MunicipioId");

                    b.ToTable("Estadios");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.InformacionPartido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Evento")
                        .HasColumnType("int");

                    b.Property<int?>("JugadorInvolucradoId")
                        .HasColumnType("int");

                    b.Property<int>("Minuto")
                        .HasColumnType("int");

                    b.Property<int?>("PartidoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JugadorInvolucradoId");

                    b.HasIndex("PartidoId");

                    b.ToTable("InformacionPartido");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Jugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("EquipoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Posicion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EquipoId");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ArbitroId")
                        .HasColumnType("int");

                    b.Property<int?>("EquipoLocalId")
                        .HasColumnType("int");

                    b.Property<int?>("EquipoVisitanteId")
                        .HasColumnType("int");

                    b.Property<int?>("EstadioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaYHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("MarcadorFinal")
                        .HasColumnType("int");

                    b.Property<int>("MarcadorInicialLocal")
                        .HasColumnType("int");

                    b.Property<int>("MarcadorInicialVisitante")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArbitroId");

                    b.HasIndex("EquipoLocalId");

                    b.HasIndex("EquipoVisitanteId");

                    b.HasIndex("EstadioId");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Equipo", b =>
                {
                    b.HasOne("TorneoFutbol.App.Dominio.DirectorTecnico", "DirectorTecnico")
                        .WithMany()
                        .HasForeignKey("DirectorTecnicoId");

                    b.HasOne("TorneoFutbol.App.Dominio.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId");

                    b.Navigation("DirectorTecnico");

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Estadio", b =>
                {
                    b.HasOne("TorneoFutbol.App.Dominio.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId");

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.InformacionPartido", b =>
                {
                    b.HasOne("TorneoFutbol.App.Dominio.Jugador", "JugadorInvolucrado")
                        .WithMany()
                        .HasForeignKey("JugadorInvolucradoId");

                    b.HasOne("TorneoFutbol.App.Dominio.Partido", "Partido")
                        .WithMany("InformacionPartido")
                        .HasForeignKey("PartidoId");

                    b.Navigation("JugadorInvolucrado");

                    b.Navigation("Partido");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Jugador", b =>
                {
                    b.HasOne("TorneoFutbol.App.Dominio.Equipo", null)
                        .WithMany("Jugador")
                        .HasForeignKey("EquipoId");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Partido", b =>
                {
                    b.HasOne("TorneoFutbol.App.Dominio.Arbitro", "Arbitro")
                        .WithMany()
                        .HasForeignKey("ArbitroId");

                    b.HasOne("TorneoFutbol.App.Dominio.Equipo", "EquipoLocal")
                        .WithMany()
                        .HasForeignKey("EquipoLocalId");

                    b.HasOne("TorneoFutbol.App.Dominio.Equipo", "EquipoVisitante")
                        .WithMany()
                        .HasForeignKey("EquipoVisitanteId");

                    b.HasOne("TorneoFutbol.App.Dominio.Estadio", "Estadio")
                        .WithMany()
                        .HasForeignKey("EstadioId");

                    b.Navigation("Arbitro");

                    b.Navigation("EquipoLocal");

                    b.Navigation("EquipoVisitante");

                    b.Navigation("Estadio");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Equipo", b =>
                {
                    b.Navigation("Jugador");
                });

            modelBuilder.Entity("TorneoFutbol.App.Dominio.Partido", b =>
                {
                    b.Navigation("InformacionPartido");
                });
#pragma warning restore 612, 618
        }
    }
}