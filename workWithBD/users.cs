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
    
    public partial class users
    {
        public int id_user { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string lastname { get; set; }
        public string login { get; set; }
        public int password { get; set; }
        public System.DateTime birthday { get; set; }
        public int id_gender { get; set; }
        public int id_role { get; set; }
    
        public virtual Genders Genders { get; set; }
        public virtual Role_user Role_user { get; set; }
    }
}