//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyUtubeApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int Id { get; set; }
        public Nullable<int> Likes { get; set; }
        public Nullable<int> Dislikes { get; set; }
        public Nullable<int> Views { get; set; }
        public Nullable<int> VideoId { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual User User { get; set; }
        public virtual Video Video { get; set; }
    }
}
