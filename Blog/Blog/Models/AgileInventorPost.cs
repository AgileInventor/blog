//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AgileInventorPost
    {
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public System.DateTime PostDate { get; set; }
        public bool PostStatus { get; set; }
        public int CategoryID { get; set; }
        public string URLImagen { get; set; }
        public string URLGitHub { get; set; }
    
        public virtual AgileInventorCategory AgileInventorCategory { get; set; }
    }
}