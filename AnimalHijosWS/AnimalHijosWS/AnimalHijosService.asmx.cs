using AnimalHijosWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AnimalHijosWS
{
    /// <summary>
    /// Descripción breve de AnimalHijosService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class AnimalHijosService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod(Description = "Consultar todos los datos")]
        public List<animalesCautiverio> ObteneranimalesCautiverio()
        {
            using (var conexion = new AnimalesEntities())
            {
                var consulta = from c in conexion.animalesCautiverios select c;
                //select * from animalesCautiverio
                return consulta.ToList();
            }
        }

        [WebMethod(Description = "Insertar datos de los Animales")]
        public bool InsertarAnimal(string nombre, string especie, string edad, string rasgosUnicos, string lugarOrigen, string tipoHabitad, string sexo)
        {
            try
            {
                    using (var conexion = new AnimalesEntities())
                {
                    animalesCautiverio nuevo = new animalesCautiverio();
                    nuevo.Id = Guid.NewGuid();
                    nuevo.Nombre = nombre;
                    nuevo.Especie = especie;
                    nuevo.Edad = edad;
                    nuevo.RasgosUnicos = rasgosUnicos;
                    nuevo.LugarOrigen = lugarOrigen;
                    nuevo.TipoHabitat = tipoHabitad;
                    nuevo.Sexo = sexo;
                    conexion.animalesCautiverios.Add(nuevo); // Agregar el nuevo animal al contexto
                    conexion.SaveChanges(); // se guardan los datos dentro de la basa de datos
                    return true; // si los cambios son realizados arrojara el mensaje True
                }
            }
            catch (Exception ex)
            {

                // se imprime un mensaje de error al modificar
                Console.WriteLine("Error al modificar el animal: " + ex.Message);
                return false;
            }
        }

        [WebMethod(Description = "Modificar datos de los Animales")]
        public bool ModificarAnimal(string nombre, string especie, string edad, string rasgosUnicos, string lugarOrigen, string tipoHabitad, string sexo)
        {

            try
            {
                using (var conexion = new AnimalesEntities())
                {
                    var modificar = conexion.animalesCautiverios.FirstOrDefault(a => a.Nombre == nombre);
                                   //SELECT * FROM animalesCautiverios WHERE Nombre = @nombre;

                    // Actualizar los campos del animal con los nuevos valores
                    modificar.Nombre = nombre;
                    modificar.Especie = especie;
                    modificar.Edad = edad;
                    modificar.RasgosUnicos = rasgosUnicos;
                    modificar.LugarOrigen = lugarOrigen;
                    modificar.TipoHabitat = tipoHabitad;
                    modificar.Sexo = sexo;

                    // Guardar los cambios en la base de datos (UPDATE)
                    conexion.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                
                // se imprime un mensaje de error al modificar
                Console.WriteLine("Error al modificar el animal: " + ex.Message);
                return false;
            }
        }

        [WebMethod(Description = "Eliminar registro de los Animales")]
        public bool EliminarAnimal(string nombre)
        {
            try
            {
                using (var conexion = new AnimalesEntities())
                {
                    var eliminar = conexion.animalesCautiverios.FirstOrDefault(a => a.Nombre == nombre);
                    //SELECT * FROM animalesCautiverios WHERE Nombre = @nombre;

                    // Removera los datos del animal (DROP)
                    conexion.animalesCautiverios.Remove(eliminar);

                    // Guardar los cambios en la base de datos
                    conexion.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {

                // se imprime un mensaje de error al modificar
                Console.WriteLine("Error al eliminar datos del animal: " + ex.Message);
                return false;
            }
        }
    }




}
