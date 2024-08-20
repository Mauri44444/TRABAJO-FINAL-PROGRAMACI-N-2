using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaa
{
    internal interface IUsuario
    {
        string Nombre { get; set; }
        int Dni { get; set; }
        string Mail { get; set; }

        bool DniExist(int Dni);
        bool MailExist(string Mail);
        Usuario FindMail(string Mail);
        Usuario FindDni (int Dni);
        
        List<Usuario> List();

        
    }
}