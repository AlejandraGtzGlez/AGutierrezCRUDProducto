using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult GetAll()
        {
            ML.Categoria categoria = new ML.Categoria();
            ML.Result result = BL.Categoria.GetAll();

            if (result.Correct)
            {
                categoria.Categorias = result.Objects;
                return View(categoria);
            }
            else
            {
                return View(categoria);
            }
        }
        [HttpGet]
        public ActionResult Form(int? IdCategoria)
        {
            ML.Categoria categoria = new ML.Categoria();
            ML.Result resultCategoria = BL.Categoria.GetAll();
            if (resultCategoria.Correct)
            {
                categoria.Categorias = resultCategoria.Objects;
            }

            if (IdCategoria == null)
            {
                return View(categoria);
            }
            else
            {
                ML.Result result = BL.Categoria.GetById(IdCategoria.Value);

                if (result.Correct)
                {

                    categoria = (ML.Categoria)result.Object;
                    categoria.Categorias = resultCategoria.Objects;
                    return View(categoria);
                }
                else
                {
                    ViewBag.Message = "Ocurrio al consultar la información de la categoria seleccionada";
                    return View("Modal");
                }
            }

        }
        [HttpPost]
        public ActionResult Form(ML.Categoria categoria)
        {
            ML.Result result = new ML.Result();

            if (categoria.IdCategoria != null)
            {
                result = BL.Categoria.Update(categoria);
                ViewBag.Message = "Se ha modificado el registro";
            }
            else
            {
                result = BL.Categoria.Add(categoria);
                ViewBag.Message = "Se ha agregado el registro";
            }
            if (result.Correct)
            {
                return PartialView("Modal");
            }
            else
            {
                return PartialView("Modal");
            }
        }
        public ActionResult Delete(int IdCategoria)
        {
            ML.Result result = BL.Categoria.Delete(IdCategoria);
            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha podido eliminar el registro seleccionado" + result.ErrorMessage;
                return PartialView("Modal");
            }

        }
    }
}