using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaa
{
    class Carrera : IABMC<Carrera>, ICarrera
    {
        private static DatosCarrera datosCarrera = new DatosCarrera();

        #region IID
        public int ID { get; set; }
        #endregion

        #region ICarrera
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }

        public Carrera FindBySigla(string sigla)
        {
            return datosCarrera.FindBySigla(this.Sigla);
        }

        public bool NameExists(string nombre)
        {
            return datosCarrera.NameExists(this.Nombre);
        }

        public bool SiglaExists(string sigla)
        {
            return datosCarrera.SiglaExists(this.Sigla);
        }
        public List<Carrera> List()
        {
            return datosCarrera.List();
        }
        
        #endregion

        #region IABMC
        public void Add()
        {
            datosCarrera.Add(this);
        }

        public void Erase()
        {
            datosCarrera.Erase(this);
        }

        public Carrera Find()
        {
            return datosCarrera.Find(this);
        }

        public void Modify()
        {
            datosCarrera.Modify(this);
        }
        #endregion
    }
}
