using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Models.Response;
using Cine.Models;
using Cine.Models.Request;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();


            try
            {
                using (CineContext db = new CineContext())
                {
                    var lst = db.Peliculas.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }


        [HttpPost]
        public IActionResult Add(PeliculaRequest Models)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (CineContext db = new CineContext())
                {
                    Pelicula Opeli = new Pelicula();
                    Opeli.Id = Models.Id;
                    Opeli.Titulo = Models.Titulo;
                    Opeli.Director = Models.Director;
                    Opeli.Genero = Models.Genero;
                    Opeli.Puntuacion = Models.Puntuacion;
                    Opeli.Rating = Models.Rating;
                    Opeli.AñoPublicacion = Models.AñoPublicacion;
                    db.Peliculas.Add(Opeli);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        //METODO PARA EDITAR
        [HttpPut]
        public IActionResult Editar(PeliculaRequest Models)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (CineContext db = new CineContext())
                {

                    //ID para modificar los datos
                    Pelicula Opeli = db.Peliculas.Find(Models.Id);
                    Opeli.Id = Models.Id;
                    Opeli.Titulo = Models.Titulo;
                    Opeli.Director = Models.Director;
                    Opeli.Genero = Models.Genero;
                    Opeli.Puntuacion = Models.Puntuacion;
                    Opeli.Rating = Models.Rating;
                    Opeli.AñoPublicacion = Models.AñoPublicacion;
                    //Indica que se modifico
                    db.Entry(Opeli).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        //METODO PARA ELIMINAR EL ID
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (CineContext db = new CineContext())
                {

                    //para eliminar una pelicula con el ID
                    Pelicula Opeli = db.Peliculas.Find(Id);

                    //
                    //elimina los datos en el Registro
                    db.Remove(Opeli);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                } 
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


    }
}

