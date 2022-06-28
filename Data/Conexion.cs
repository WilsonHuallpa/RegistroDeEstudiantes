using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Conexion : DataConnection
    {
        public Conexion() : base("PDHN1") { }

        //Es la la forma que LinqToDB se va relacionar con la tabla que tenga el mismo nombre de la clase que pasamos.
        // nos devuelve un coleccion de objetos con los datos de la tablas.
        //Vamos a poder manipularlo el objeto devulto para eliminar, actulizar, insertar, modificar.

        public ITable<Estudiant> _Estudiante { get { return this.GetTable<Estudiant>(); } }



    }
}
