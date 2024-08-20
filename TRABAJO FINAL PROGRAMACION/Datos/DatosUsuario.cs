using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aaa;
using System.Data;

namespace Aaa
{
    internal partial class Datos : IAccesoADatos<Usuario>, IUsuario
    {
        private static List<Usuario> listaUsuarios = new List<Usuario>();
        private static int lastId;

        #region Metodos JSON
       private static void Read()
        {
            try 
            {
                string path = "C:\\Users\\Graciela\\Desktop\\TRABAJO FINAL PARTE 1\\Datos\\usuarios.json";
                string json = File.ReadAllText(path);
                listaUsuarios = JsonSerializer.Deserialize<List<Usuario>>(json);
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
                string path = "C:\\Users\\Graciela\\Desktop\\TRABAJO FINAL PARTE 1\\Datos\\usuarios.json";
                string json = JsonSerializer.Serialize(listaUsuarios);
                File.WriteAllText(path, json);
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Clear()
        {
            listaUsuarios.Clear();
        }
        #endregion

        #region IAccesoADatos
        public void Add(Usuario data)
        {
            if (listaUsuarios.Any(u => u.ID == data.ID))
            {
                throw new Exception("El usuario ya existe");
            }

            Read();
            string pathID = "C:\\Users\\Graciela\\Desktop\\TRABAJO FINAL PARTE 1\\Datos\\usuarioLasId.txt";
            lastId = int.Parse(File.ReadAllText(pathID));
            data.ID = ++lastId;
            File.WriteAllText(pathID, lastId.ToString()); //Guarda el ultimo ID en el archivo
            listaUsuarios.Add(data);
            Write();
            Clear();
        }
        public void Erase(Usuario data)
        {
            Read();
            foreach(Usuario u in listaUsuarios)
            {
                if(data.ID == u.ID)
                {
                    listaUsuarios.Remove(data);
                    Write();
                    Clear();
                    return;
                }
            }
            Clear();
            throw new Exception("No se encontró el usuario a eliminar");
        }
        public Usuario Find(Usuario data)
        {
            Read(); 
            foreach (Usuario u in listaUsuarios)
            {
                if (data.ID == u.ID)
                {
                    Clear(); 
                    return u; 
                }
            }
            Clear(); 
            throw new Exception("No se encontró el usuario"); 
        }
        public void Modify(Usuario data)
        {
            Read();
            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                if (listaUsuarios[i].ID == data.ID)
                {
                    listaUsuarios[i].Nombre = data.Nombre;
                    Write();
                    Clear();
                    return;
                }
            }
            Clear();
            throw new Exception("No se puede modificar el usuario: No se encuentra en la lista");
        }
        #endregion

        #region IUsuario
         public string Nombre { get; set;}
        public int Dni { get; set;}
        public string Mail { get; set;}
        public Usuario FindDni(int dni)
        {
            Read(); 
            foreach (Usuario u in listaUsuarios)
            {
                if (u.Dni == dni) 
                {
                    Clear(); 
                    return u; 
                }
            }
            Clear(); 
            throw new Exception("No se encontró el usuario con el DNI especificado"); 
        }

        public Usuario FindMail(string mail)
        {
            Read(); 
            foreach (Usuario u in listaUsuarios)
            {
                if (u.Mail == mail) 
                {
                    Clear(); 
                    return u; 
                }
            }
            Clear(); 
            throw new Exception("No se encontró el usuario con el correo especificado"); 
        }

        public bool DniExist(int Dni)
        {
            Read(); 
            foreach (Usuario u in listaUsuarios)
            {
                if (u.Dni == Dni) 
                {
                    Clear();
                    return true; 
                }
            }
            Clear(); 
            return false; 
        }

        public bool MailExist(string Mail)
        {
            Read(); 
            foreach (Usuario u in listaUsuarios)
            {
                if (u.Mail == Mail) 
                {
                    Clear();
                    return true; 
                }
            }
            Clear(); 
            return false; 
        }

        public List<Usuario> List()
        {
            Read();
            List<Usuario> lista = new List<Usuario>(listaUsuarios);
            Clear();
            return listaUsuarios;
        }
        #endregion

    }
}
    
    