using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categoria
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDProductoEntities context = new DL.AGutierrezCRUDProductoEntities())
                {
                    var query = context.CategoriaGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Categoria categoria = new ML.Categoria();
                            categoria.IdCategoria = item.IdCategoria;
                            categoria.Nombre = item.Nombre;
                            categoria.Descripcion = item.Descripcion;
                            categoria.Estado = item.Estado;
                            categoria.EncargadoCategoria = item.EncargadoCategoria;
                            categoria.Proveedor = item.Proveedor;
                            categoria.CiudadProveedor = item.CiudadProveedor;

                            result.Objects.Add(categoria);
                            result.Correct = true;
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
        public static ML.Result GetById(int IdCategoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDProductoEntities context = new DL.AGutierrezCRUDProductoEntities())
                {
                    var query = context.CategoriaGetById(IdCategoria).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Categoria categoria = new ML.Categoria();
                        categoria.IdCategoria = query.IdCategoria;
                        categoria.Nombre = query.Nombre;
                        categoria.Descripcion = query.Descripcion;
                        categoria.Estado = query.Estado;
                        categoria.EncargadoCategoria = query.EncargadoCategoria;
                        categoria.Proveedor = query.Proveedor;
                        categoria.CiudadProveedor = query.CiudadProveedor;

                        result.Object = categoria;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Categoria categoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDProductoEntities context = new DL.AGutierrezCRUDProductoEntities())
                {
                    var query = context.CategoriaAdd(categoria.Nombre, categoria.Descripcion, categoria.Estado, categoria.EncargadoCategoria, categoria.Proveedor, categoria.CiudadProveedor);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Categoria categoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDProductoEntities context = new DL.AGutierrezCRUDProductoEntities())
                {
                    var query = context.CategoriaUpdate(categoria.IdCategoria, categoria.Nombre, categoria.Descripcion, categoria.Estado, categoria.EncargadoCategoria, categoria.Proveedor, categoria.CiudadProveedor);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
        public static ML.Result Delete(int IdCategoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDProductoEntities context = new DL.AGutierrezCRUDProductoEntities())
                {
                    var query = context.CategoriaDelete(IdCategoria);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
    }
}
