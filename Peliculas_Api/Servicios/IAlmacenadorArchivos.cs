namespace Peliculas_Api.Servicios
{
    public interface IAlmacenadorArchivos
    {
        //Subir imagen hacia azure storage 

        Task<string> GuardarArchivo(byte[] contenido, string extension, string contenedor,
            string contentType);
        Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor,
         string ruta, string contentType);
        Task BorrarArchivo(string ruta, string contenedor);
    }
}
