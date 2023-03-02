using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class EFBookStoreRepo : IBookStore
    {
        private WaterProjectContext context { get; set; }
        
        public EFBookStoreRepo (WaterProjectContext temp)
        {
            context = temp;
        }
        public IQueryable<Project> Projects => context.Projects;
    }
}
