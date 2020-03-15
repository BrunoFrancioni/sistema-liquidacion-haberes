//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema_Liquidacion_de_Haberes.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empleados()
        {
            this.depositos = new HashSet<depositos>();
        }
    
        public int idEmpleados { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string lugarTrabajo { get; set; }
        public string cuil { get; set; }
        public int legajo { get; set; }
        public System.DateTime antiguedad { get; set; }
        public System.DateTime fechaIngreso { get; set; }
        public Nullable<System.DateTime> fechaEgreso { get; set; }
        public int obrasSociales_idobrasSociales { get; set; }
        public int cuentasBancarias_idcuentasBancarias { get; set; }
        public int categorias_idcategorias { get; set; }
        public byte[] activo { get; set; }
    
        public virtual categorias categorias { get; set; }
        public virtual cuentasBancarias cuentasBancarias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<depositos> depositos { get; set; }
        public virtual obrasSociales obrasSociales { get; set; }
    }
}
