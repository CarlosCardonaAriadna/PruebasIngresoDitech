using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using System.Collections;


namespace web.Logic.Clases
{
    public class clsVendedorBD
    {
        private ISessionFactory mySessionFactory;
        private ISession mySesionn;

        public clsVendedorBD()
        {
            Configuration cfg = new Configuration();
            cfg.AddAssembly("web.Logic");

            mySessionFactory = cfg.BuildSessionFactory();
            mySesionn = mySessionFactory.OpenSession();
                        
        }


        public string ingresarVendedor(clsVendedorIngreso nuevo_vendedor)
        {
            try
            {
                using (mySesionn.BeginTransaction())
                {
                    clsVendedor objVendedor = new clsVendedor
                    {

                        CODIGO = nuevo_vendedor.codigo,
                        NOMBRE = nuevo_vendedor.nombre,
                        APELLIDO = nuevo_vendedor.apellido,
                        NUMERO_IDENTIFICACION = nuevo_vendedor.numero_identificacion,
                        CODIGO_CIUDAD = nuevo_vendedor.codigo_ciudad
                    };

                    mySesionn.Save(objVendedor);
                    mySesionn.Transaction.Commit();
                }
                    

                return "ingreso de vendedor exitoso";
            }catch(Exception ex) { throw ex; }
        }

        public string modificarVendedor(clsVendedorIngreso nuevo_vendedor)
        {
            try
            {
                using (mySesionn.BeginTransaction())
                {
                    clsVendedor objVendedor = (clsVendedor)mySesionn.Load(typeof(clsVendedor), nuevo_vendedor.codigo);

                    objVendedor.CODIGO = nuevo_vendedor.codigo;
                    objVendedor.NOMBRE = nuevo_vendedor.nombre;
                    objVendedor.APELLIDO = nuevo_vendedor.apellido;
                    objVendedor.NUMERO_IDENTIFICACION = nuevo_vendedor.numero_identificacion;
                    objVendedor.CODIGO_CIUDAD = nuevo_vendedor.codigo_ciudad;


                    mySesionn.Update(objVendedor);
                    mySesionn.Transaction.Commit();
                }

                return "Modificación de información de vendedor realizada con éxito";

            }
            catch (Exception ex) { throw ex; }
        }

        public string eliminarVendedor(int codigo_vendedor)
        {
            try
            {
                using (mySesionn.BeginTransaction())
                {
                    clsVendedor objVendedor = (clsVendedor)mySesionn.Load(typeof(clsVendedor), codigo_vendedor);

                    mySesionn.Update(objVendedor);
                    mySesionn.Transaction.Commit();
                }
                    

                return "Se eliminó la información del vendedor";
            }
            catch (Exception ex) { throw ex; }
        }


        public IList consultarVendedor()
        {
            try
            {
                IList iVendedores = mySesionn.CreateCriteria(typeof(clsVendedor)).List();
                return iVendedores;
            }
            catch (Exception ex) { throw ex; }
        }

        public IList consultarVendedorId(int codigo_consulta)
        {
            try
            {
                //IList info_vendedor = mySesionn.CreateSQLQuery("SELECT {*} FROM VENDEDOR {vendedor} WHERE CODIGO = "+ codigo_consulta).AddEntity("clsVendedor", typeof(clsVendedor)).List();
                var info_vendedor = mySesionn.QueryOver<clsVendedor>().Where(val => val.CODIGO == codigo_consulta).List();

                return info_vendedor.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

    }
}
