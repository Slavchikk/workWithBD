//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace workWithBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tickets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tickets()
        {
            this.halls_tickets = new HashSet<halls_tickets>();
        }
    
        public int id_ticket { get; set; }
        public string session { get; set; }
        public int id_session_time { get; set; }
        public int id_session_day { get; set; }
        public int id_halls { get; set; }
        public int id_type_tickets { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<halls_tickets> halls_tickets { get; set; }
        public virtual sessions_days sessions_days { get; set; }
        public virtual sessions_time sessions_time { get; set; }
        public virtual type_tickets type_tickets { get; set; }
    }
}
