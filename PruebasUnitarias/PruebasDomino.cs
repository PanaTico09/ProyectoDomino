using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoDomino;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasDomino
    {
        /// <summary>
        /// Prueba que el metodo de generar fichas genere correctamente 28 fichas
        /// </summary>
        [TestMethod]
        public void PruebaGenerarFichas()
        {
            var fichas = new Domino().GenerarFichas();
            Assert.IsNotNull(fichas);
            Assert.IsTrue(fichas.Count == 28);
        }

        /// <summary>
        /// Prueba que el metodo de entregar fichas entregue la cantidad correcta de fichas y no 
        /// presente errores si la cantidad de fichas es mayor al numero de fichas disponibles
        /// </summary>
        [TestMethod]
        public void PruebaEntregarFichas()
        {
            Domino domino = new Domino();
            var jugador = new Jugador { };
            var fichas = new List<Ficha>{
                new Ficha { primerNumero = 0,segundoNumero = 1},
                new Ficha { primerNumero = 1,segundoNumero = 2},
                new Ficha { primerNumero = 2,segundoNumero =3}
            };
            domino.EntregarFichas(jugador, fichas, 2);
            Assert.IsTrue(jugador.FichasDisponibles.Count == 2);
            domino.EntregarFichas(jugador, fichas, 2);
            Assert.IsTrue(jugador.FichasDisponibles.Count == 3);
        }

        /// <summary>
        /// Prueba que el metodo de elegir al primer jugador funcione correctamente
        /// Elige al jugador ya sea con el la ficha doble de mayor puntaje, o en 
        /// caso de no existir fichas doble, la ficha de mayor puntaje
        /// </summary>
        [TestMethod]
        public void PruebaElegirPrimerJugador()
        {

            List<Jugador> jugadores = new List<Jugador>();
            jugadores.Add(new Jugador()
            {
                Nombre = "Jugador 1",
                FichasDisponibles = new List<Ficha>{
                    new Ficha { primerNumero = 0,segundoNumero = 1},
                    new Ficha { primerNumero = 1,segundoNumero = 2},
                    new Ficha { primerNumero = 2,segundoNumero = 5}
                }
            });
            jugadores.Add(new Jugador()
            {
                Nombre = "Jugador 2",
                FichasDisponibles = new List<Ficha>{
                    new Ficha { primerNumero = 3,segundoNumero = 1},
                    new Ficha { primerNumero = 3,segundoNumero = 0},
                    new Ficha { primerNumero = 4,segundoNumero = 3}
                }
            });
            jugadores.Add(new Jugador()
            {
                Nombre = "Jugador 3",
                FichasDisponibles = new List<Ficha>{
                    new Ficha { primerNumero = 1,segundoNumero = 4},
                    new Ficha { primerNumero = 2,segundoNumero = 3},
                    new Ficha { primerNumero = 1,segundoNumero = 6}
                }
            });
            Domino domino = new Domino { Jugadores = jugadores };

            Jugador jugadorInicial = domino.ElegirJugadorInicial();
            Assert.IsNotNull(jugadorInicial);
            Assert.IsTrue(jugadorInicial.Nombre == "Jugador 3");

            jugadores.Clear();

            jugadores.Add(new Jugador()
            {
                Nombre = "Jugador 1",
                FichasDisponibles = new List<Ficha>{
                    new Ficha { primerNumero = 0,segundoNumero = 1},
                    new Ficha { primerNumero = 2,segundoNumero = 2, esDoble = true},
                    new Ficha { primerNumero = 2,segundoNumero = 5}
                }
            });
            jugadores.Add(new Jugador()
            {
                Nombre = "Jugador 2",
                FichasDisponibles = new List<Ficha>{
                    new Ficha { primerNumero = 3,segundoNumero = 1},
                    new Ficha { primerNumero = 3,segundoNumero = 0},
                    new Ficha { primerNumero = 4,segundoNumero = 4, esDoble = true}
                }
            });
            jugadores.Add(new Jugador()
            {
                Nombre = "Jugador 3",
                FichasDisponibles = new List<Ficha>{
                    new Ficha { primerNumero = 1,segundoNumero = 4},
                    new Ficha { primerNumero = 2,segundoNumero = 3},
                    new Ficha { primerNumero = 6,segundoNumero = 6, esDoble = true}
                }
            });
            jugadores.Add(new Jugador()
            {
                Nombre = "Jugador 4",
                FichasDisponibles = new List<Ficha>{
                    new Ficha { primerNumero = 0,segundoNumero = 4},
                    new Ficha { primerNumero = 3,segundoNumero = 5},
                    new Ficha { primerNumero = 5,segundoNumero = 6}
                }
            });

            domino = new Domino { Jugadores = jugadores };

            jugadorInicial = domino.ElegirJugadorInicial();
            Assert.IsNotNull(jugadorInicial);
            Assert.IsTrue(jugadorInicial.Nombre == "Jugador 3");
        }

        /// <summary>
        /// Prueba que el metodo de obtener el orden de los jugadores devuelva una
        /// cola con un orden correcto
        /// </summary>
        [TestMethod]
        public void PruebaObtenerOrdenJugadores()
        {
            List<Jugador> jugadores = new List<Jugador>();
            jugadores.Add(new Jugador()
            {
                Nombre = "Jugador 1",
                FichasDisponibles = new List<Ficha>{
                    new Ficha { primerNumero = 0,segundoNumero = 1},
                    new Ficha { primerNumero = 1,segundoNumero = 2},
                    new Ficha { primerNumero = 2,segundoNumero = 5}
                }
            });
            jugadores.Add(new Jugador()
            {
                Nombre = "Jugador 2",
                FichasDisponibles = new List<Ficha>{
                    new Ficha { primerNumero = 3,segundoNumero = 1},
                    new Ficha { primerNumero = 3,segundoNumero = 0},
                    new Ficha { primerNumero = 4,segundoNumero = 3}
                }
            });
            jugadores.Add(new Jugador()
            {
                Nombre = "Jugador 3",
                FichasDisponibles = new List<Ficha>{
                    new Ficha { primerNumero = 1,segundoNumero = 4},
                    new Ficha { primerNumero = 2,segundoNumero = 3},
                    new Ficha { primerNumero = 1,segundoNumero = 6}
                }
            });
            Domino domino = new Domino();
            domino.Jugadores = jugadores;

            var colaJugadores = domino.ObtenerOrdenJugadores();
            Assert.IsNotNull(colaJugadores);
            Assert.IsTrue(colaJugadores.Peek().Nombre == "Jugador 3");
        }
    }
}
