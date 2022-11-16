﻿using Dominio;
using Logica.Exceptions;
using Logica.Implementaciones;
using Logica.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio.EnDataBase;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.PruebasLogica
{
    [TestClass]
    public class LogicaPersonaTest
    {
        ILogicaPersona logicaPersona = new LogicaPersona(new PersonaDBRepo());
        Persona persona = new Persona() { Id = 1, Nombre = "Juan" };
        Usuario admin = new Usuario() { EsAdministrador = true };

        [TestInitialize]
        public void Setup()
        {
            DBCleanUp.CleanUp();
        }

        [TestMethod]
        public void AgregarPersonaTest()
        {
            logicaPersona.AltaPersona(persona, admin);
            Assert.IsTrue(logicaPersona.Personas().Contains(persona));
        }

        [TestMethod]
        [ExpectedException(typeof(PersonaExistenteException))]
        public void AgregarPersonaRepetidaTest()
        {
            logicaPersona.AltaPersona(persona, admin);
            logicaPersona.AltaPersona(persona, admin);
        }

        [TestMethod]
        public void BajaPersonaTest()
        {
            logicaPersona.AltaPersona(persona, admin);
            logicaPersona.BajaPersona(persona, admin);
            Assert.IsFalse(logicaPersona.Personas().Contains(persona));
        }

        [TestMethod]
        [ExpectedException(typeof(PersonaInexistenteException))]
        public void BajaPersonaInexistenteTest()
        {
            logicaPersona.BajaPersona(persona, admin);
        }

        [TestMethod]
        public void ModificarNombreTest()
        {
            logicaPersona.AltaPersona(persona, admin);
            persona.Nombre = "nuevo nombre";
            logicaPersona.ModificarPersona(persona, admin);

            //redefinido el equals, compara los datos en lugar del id
            Assert.IsTrue(logicaPersona.Personas().Contains(persona));
        }

        [TestMethod]
        public void ModificarFotoTest()
        {
            logicaPersona.AltaPersona(persona, admin);
            persona.FotoPerfil = "nueva/foto";
            logicaPersona.ModificarPersona(persona, admin);

            //redefinido el equals, compara los datos en lugar del id
            Assert.IsTrue(logicaPersona.Personas().Contains(persona));
        }

        [TestMethod]
        public void ModificarFechaTest()
        {
            logicaPersona.AltaPersona(persona, admin);
            persona.FechaNacimiento = new DateTime(2010, 4, 22);
            logicaPersona.ModificarPersona(persona, admin);

            //redefinido el equals, compara los datos en lugar del id
            Assert.IsTrue(logicaPersona.Personas().Contains(persona));
        }
    }
}