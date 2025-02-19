using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRest.Context;
using ApiRest.Models;

namespace ApiRest.Repository
{
    public class ProductoDao
    {
        public DbapiContext contexto = new DbapiContext();

        public List<Producto> SelectALL()
        {
            var producto = contexto.Productos.ToList<Producto>();
            return producto;
        }

        public Producto? GetById(int id)
        {
            return contexto.Productos.FirstOrDefault(y => y.Id == id);
        }

        public bool DeleteProducts(int id)
        {
            try
            {
                var delete = GetById(id);
                if (delete == null)
                {
                    return false;
                }

                contexto.Productos.Remove(delete);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Producto? InsertProduct(Producto producto)
        {
            try
            {
                contexto.Productos.Add(producto);
                contexto.SaveChanges();
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateProduct(Producto producto)
        {
            try
            {
                if (producto == null || string.IsNullOrWhiteSpace(producto.Nombre) || producto.Stock < 0 || producto.Precio <= 0)
                {
                    return false;
                }

                var productExis = GetById(producto.Id);

                if (productExis == null)
                {
                    return false;
                }

                productExis.Nombre = producto.Nombre;
                productExis.Precio = producto.Precio;
                productExis.Stock = producto.Stock;

                contexto.Productos.Update(productExis);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
