using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDProductoEntities context = new DL.AGutierrezCRUDProductoEntities())
                {
                    var query = context.ProductoGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = item.IdProducto;
                            producto.Nombre = item.Nombre;
                            producto.Descripcion = item.Descripcion;
                            producto.Stock = item.Stock.Value;

                            result.Objects.Add(producto);
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

        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDProductoEntities context = new DL.AGutierrezCRUDProductoEntities())
                {
                    var query = context.ProductoGetById(IdProducto).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.Nombre;
                        producto.Descripcion = query.Descripcion;
                        producto.Stock = query.Stock.Value;

                        result.Object = producto;
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

        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDProductoEntities context = new DL.AGutierrezCRUDProductoEntities())
                {
                    var query = context.ProductoAdd(producto.Nombre, producto.Descripcion, producto.Stock);
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
        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDProductoEntities context = new DL.AGutierrezCRUDProductoEntities())
                {
                    var query = context.ProductoUpdate(producto.IdProducto,producto.Nombre, producto.Descripcion, producto.Stock);
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
        public static ML.Result Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezCRUDProductoEntities context = new DL.AGutierrezCRUDProductoEntities())
                {
                    var query = context.ProductoDelete(IdProducto);
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
