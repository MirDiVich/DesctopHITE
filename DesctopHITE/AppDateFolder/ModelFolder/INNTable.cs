//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesctopHITE.AppDateFolder.ModelFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class INNTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INNTable()
        {
            this.WorkerTabe = new HashSet<WorkerTabe>();
        }
    
        public string PersonalNumber_INN { get; set; }
        public string TaxAuthority_INN { get; set; }
        public string NumberTaxAuthority_INN { get; set; }
        public System.DateTime Date_INN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkerTabe> WorkerTabe { get; set; }
    }
}