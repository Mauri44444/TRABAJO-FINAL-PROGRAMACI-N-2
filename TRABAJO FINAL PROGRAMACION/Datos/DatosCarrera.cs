using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace Aaa
{
    internal partial class DatosCarrera : IAccesoADatos<Carrera>, ICarrera
    {
        private static List<Carrera> listaCarreras = new List<Carrera>();
        private static int lastId;

        #region Metodos de JSON
        private static void Read()
        {
            try
            {
                string path = "C:\\Users\\Graciela\\Desktop\\TRABAJO FINAL PARTE 1\\Datos\\carreras.json";
                string json = File.ReadAllText(path);
                listaCarreras = JsonSerializer.Deserialize<List<Carrera>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Write()
        {
            try
            {
                string path = "C:\\Users\\Graciela\\Desktop\\TRABAJO FINAL PARTE 1\\Datos\\carreras.json";
                string json = JsonSerializer.Serialize(listaCarreras);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Clear()
        {
            listaCarreras.Clear();
        }
        #endregion

        #region IAccesoADatos
        public void Add(Carrera data)
        {
            if (listaCarreras.Any(c => c.ID == data.ID))
            {
                throw new Exception("La carrera ya existe");
            }

            Read();
            string pathID = "C:\\Users\\Graciela\\Desktop\\TRABAJO FINAL PARTE 1\\Datos\\carreraLasId.txt";
            lastId = int.Parse(File.ReadAllText(pathID));
            data.ID = ++lastId;
            File.WriteAllText(pathID, lastId.ToString());
            listaCarreras.Add(data);
            Write();
            Clear();
        }

        public void Erase(Carrera data)
        {
            Read();
            Carrera carreraAEliminar = listaCarreras.FirstOrDefault(c => c.ID == data.ID);
            if (carreraAEliminar != null)
            {
                listaCarreras.Remove(carreraAEliminar);
                Write();
                Clear();
            }
            else
            {
                Clear();
                throw new Exception("No se encontró la carrera a eliminar");
            }
        }

        public Carrera Find(Carrera data)
        {
            Read();
            Carrera carreraEncontrada = listaCarreras.FirstOrDefault(c => c.ID == data.ID);
            Clear();
            if (carreraEncontrada != null)
            {
                return carreraEncontrada;
            }
            throw new Exception("No se encontró la carrera");
        }

        public void Modify(Carrera data)
        {
            Read();
            Carrera carreraAModificar = listaCarreras.FirstOrDefault(c => c.ID == data.ID);
            if (carreraAModificar != null)
            {
                carreraAModificar.Nombre = data.Nombre;
                carreraAModificar.Sigla = data.Sigla;
                carreraAModificar.Titulo = data.Titulo;
                carreraAModificar.Duracion = data.Duracion;
                Write();
                Clear();
            }
            else
            {
                Clear();
                throw new Exception("No se puede modificar la carrera: No se encuentra en la lista");
            }
        }
        #endregion
        
        #region ICarrera
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }

        public Carrera FindBySigla(string sigla)
        {
            Read();
            Carrera carreraEncontrada = listaCarreras.FirstOrDefault(c => c.Sigla == sigla);
            Clear();
            if (carreraEncontrada != null)
            {
                return carreraEncontrada;
            }
            throw new Exception("No se encontró la carrera con la sigla especificada");
        }

        public List<Carrera> List()
        {
            Read();
            List<Carrera> lista = new List<Carrera>(listaCarreras);
            Clear();
            return lista;
        }

        public bool NameExists(string nombre)
        {
            Read();
            bool existe = listaCarreras.Any(c => c.Nombre == nombre);
            Clear();
            return existe;
        }

        public bool SiglaExists(string sigla)
        {
            Read();
            bool existe = listaCarreras.Any(c => c.Sigla == sigla);
            Clear();
            return existe;
        }
        #endregion
    }
}
