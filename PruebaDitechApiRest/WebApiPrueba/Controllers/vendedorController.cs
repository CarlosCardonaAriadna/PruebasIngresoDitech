using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using web.Logic;
using web.Logic.Clases;

namespace WebApiPrueba.Controllers
{
    public class vendedorController : ApiController
    {
        /// <summary>
        /// Api controller para ingresar vendedor a BD por nhibernate
        /// </summary>
        /// <param name="parametros_ingreso"></param>
        /// <returns>Retorna mensaje de exito o error</returns>
        [HttpPost]
        [Route("ingresoVendedor")]
        public string ingreso_vendedor(clsVendedorIngreso parametros_ingreso)
        {
            
            try
            {
                string mensaje_exito = "";
                IList existe_contacto;

                clsVendedorBD almacenar_vendedor = new clsVendedorBD();

                existe_contacto = almacenar_vendedor.consultarVendedorId(parametros_ingreso.codigo);

                if(existe_contacto.Count > 0)
                {
                    mensaje_exito = "Este contacto ya se encuentra registrado en la base de datos";
                }
                else
                {
                    mensaje_exito = almacenar_vendedor.ingresarVendedor(parametros_ingreso);
                }               


                return mensaje_exito;
            }

            catch (Exception ex) { throw ex; }


        }


        /// <summary>
        /// Metodo para modificar info vendedor
        /// </summary>
        /// <param name="parametros_ingreso"></param>
        /// <returns>Retorna mensaje de confirmación</returns>
        [HttpPut]
        [Route("modificarVendedor")]
        public string ModificarVendedor(clsVendedorIngreso parametros_ingreso)
        {

            try
            {
                string mensaje_exito = "";
                IList existe_contacto;

                clsVendedorBD almacenar_vendedor = new clsVendedorBD();

                existe_contacto = almacenar_vendedor.consultarVendedorId(parametros_ingreso.codigo);

                if (existe_contacto.Count > 0)
                {
                    mensaje_exito = almacenar_vendedor.modificarVendedor(parametros_ingreso);
                    
                }
                else
                {
                    mensaje_exito = "El contacto que intenta modificar no esxiste en base de datos. Por favor crearlo";
                }


                return mensaje_exito;
            }
            catch (Exception ex) { throw ex; }


        }

        /// <summary>
        /// Método para consultar todos los vendedores en base de datos
        /// </summary>
        /// <returns>Retorna lista de vendedores en base de datos</returns>
        [HttpGet]
        [Route("consultaTodosVendedores")]
        public IList consultaTodosVendedores()
        {
            try
            {
                clsVendedorBD almacenar_vendedor = new clsVendedorBD();
                IList iVendedores = almacenar_vendedor.consultarVendedor();
                return iVendedores;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Método para consultar un vendedor por id
        /// </summary>
        /// <returns>Retorna información de un vendedor</returns>
        [HttpGet]
        [Route("consultaVendedor")]
        public IList consultarVendedor(int id)
        {
            try
            {
                clsVendedorBD almacenar_vendedor = new clsVendedorBD();
                IList iVendedores = almacenar_vendedor.consultarVendedorId(id);
                return iVendedores;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Método para consultar un vendedor por id
        /// </summary>
        /// <returns>Retorna información de un vendedor</returns>
        [HttpDelete]
        [Route("eliminarVendedor")]
        public string eliminarVendedor(int id)
        {
            try
            {
                string mensaje_respuesta = "";
                IList existe_contacto;
                clsVendedorBD almacenar_vendedor = new clsVendedorBD();

                existe_contacto = almacenar_vendedor.consultarVendedorId(id);

                if (existe_contacto.Count > 0)
                {
                    mensaje_respuesta = almacenar_vendedor.eliminarVendedor(id);
                }
                else
                {
                    mensaje_respuesta = "El contacto que intenta eliminar no existe en base de datos";
                }

                
                return mensaje_respuesta;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}