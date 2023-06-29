using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetAll();

            if (result.Correct)
            {
                producto.Productos = result.Objects;
                return View(producto);
            }
            else
            {
                return View(producto);
            }
        }
        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            ML.Result resultProducto = BL.Producto.GetAll();
            if (resultProducto.Correct)
            {
                producto.Productos = resultProducto.Objects;
            }

            if (IdProducto == null)
            {
                return View(producto);
            }
            else
            {
                ML.Result result = BL.Producto.GetById(IdProducto.Value);

                if (result.Correct)
                {

                    producto = (ML.Producto)result.Object;
                    producto.Productos = resultProducto.Objects;
                    return View(producto);
                }
                else
                {
                    ViewBag.Message = "Ocurrio al consultar la información del producto";
                    return View("Modal");
                }
            }

        }
        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            if (producto.IdProducto != null)
            {
                result = BL.Producto.Update(producto);
                ViewBag.Message = "Se ha modificado el registro";
            }
            else
            {
                result = BL.Producto.Add(producto);
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
        public ActionResult Delete(int IdProducto)
        {
            ML.Result result = BL.Producto.Delete(IdProducto);
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