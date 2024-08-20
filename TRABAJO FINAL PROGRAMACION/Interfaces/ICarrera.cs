using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaa
{
    internal interface ICarrera
    {
        string Nombre { get; set; }
        string Sigla { get; set; }
        string Titulo { get; set; }
        int Duracion { get; set; }

        Carrera FindBySigla(string sigla);
        List<Carrera> List();
        bool NameExists(string nombre);
        bool SiglaExists(string sigla);
    }
}