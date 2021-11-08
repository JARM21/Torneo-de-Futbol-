using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioJugadores : IRepositorioJugadores
    {
        private readonly AppContext _appContext = new AppContext();
    
        Jugador IRepositorioJugadores.AddJugador(Jugador jugador)
        {
            var jugadorAdicionado = _appContext.Jugadores.Add(jugador);
            _appContext.SaveChanges();
            return jugadorAdicionado.Entity;
        }

        void IRepositorioJugadores.DeleteJugador(int idJugador)
        {
            var jugadorEncontrado=_appContext.Jugadores.FirstOrDefault(e=>e.Id==idJugador);
            if(jugadorEncontrado==null)
                return;
            _appContext.Jugadores.Remove(jugadorEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Jugador> IRepositorioJugadores.GetAllJugador()
        {
            return _appContext.Jugadores;
        }

        public Jugador GetJugador(int IdJugadores)
        {
            var jugador = _appContext.Jugadores
                     .Where(j => j.Id == IdJugadores)
                     .Include(jugador => jugador.Equipo)
                     .FirstOrDefault();
                return jugador;
            
        }
        public Equipo GetEquipos(int IdEquipos)
        {
            var equipo = _appContext.Equipos
                .Where(p => p.Id == IdEquipos)
                .Include(p => p.Municipio)
                .Include(p => p.DirectorTecnico)
                
                .FirstOrDefault();
            return equipo;
            
        }

        Jugador IRepositorioJugadores.UpdateJugador(Jugador jugador)
        {
            var jugadorEncontrado=_appContext.Jugadores.FirstOrDefault(e=>e.Id==jugador.Id);
            if(jugadorEncontrado!=null)
            {
                jugadorEncontrado.Nombre = jugador.Nombre;
                jugadorEncontrado.Numero = jugador.Numero;
                jugadorEncontrado.Posicion = jugador.Posicion;
                
                _appContext.SaveChanges();
            }
            return jugadorEncontrado;
        }

        Equipo IRepositorioJugadores.AsignarEquipo(int IdJugador, int IdEquipo)
        {
            var jugadorEncontrado = _appContext.Jugadores.Find(IdJugador);
            if (jugadorEncontrado != null)
            { var equipoEncontrado = _appContext.Equipos.Find(IdEquipo);
            if (equipoEncontrado != null)
            { jugadorEncontrado.Equipo = equipoEncontrado;
            _appContext.SaveChanges();
            }
            return equipoEncontrado;
            }
            return null;
        }

        public IEnumerable<Jugador> GetJugadoresNombre(string nombre)
        {
            return _appContext.Jugadores
                   .Where(P => P.Nombre.Contains(nombre));
        }
    }
}


