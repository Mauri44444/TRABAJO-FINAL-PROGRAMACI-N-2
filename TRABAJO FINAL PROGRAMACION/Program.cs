namespace Aaa;

internal class Program
{
    static void Main(string[] args)
    {
        #region CreaciónDeUsuarios
        Console.Clear();
        
        Usuario usuario = new Usuario();
        {
           usuario.Nombre = "Mauricio";
           usuario.Dni = 46;
           usuario.Mail = "Mauri14200@gmail.com";
        };

        Usuario usuario2 = new Usuario
        {
            Nombre = "Sofia",
            Dni = 38,
            Mail = "Sofi14200@gmail.com",
        };
        #endregion

        #region AddUsuarios
        usuario.Add();
        usuario2.Add();
        #endregion

        #region CreaciónDeCarreras
        Carrera carrera1 = new Carrera
        {
            Nombre = "Analisis de Sistemas",
            Sigla = "TSAS",
            Titulo = "Analista en sistemas",
            Duracion = 3
        };

        Carrera carrera2 = new Carrera
        {
            Nombre = "Licenciatura en Administración",
            Sigla = "LA",
            Titulo = "Licenciado en Administración",
            Duracion = 4
        };
        #endregion

        #region AddCarreras
        carrera1.Add();
        carrera2.Add();
        #endregion
    }
}