using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaa
{
    class Usuario : IABMC<Usuario>, IUsuario
    {
        private static Datos datos = new Datos();

        #region IID
        public int ID { get; set; }
        #endregion

        #region IUsuario 
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Mail { get; set; }

        public bool DniExist(int Dni)
        {
            return datos.DniExist(this.Dni);
        }

        public bool MailExist(string Mail)
        {
            return datos.MailExist(this.Mail);
        }

        public Usuario FindMail(string Mail)
        {
            return datos.FindMail(this.Mail);
        }

        public Usuario FindDni(int Dni)
        {
            return datos.FindDni(this.Dni);
        }

        List<Usuario> IUsuario.List()
        {
            return datos.List();
        }

        
        #endregion

        #region IABMC
        public void Add()
        {
            datos.Add(this);
        }

        public void Erase()
        {
            datos.Erase(this);
        }

        public Usuario Find()
        {
            return datos.Find(this);
        }

        public void Modify()
        {
            datos.Modify(this);
        }

        
        #endregion
    }
}
