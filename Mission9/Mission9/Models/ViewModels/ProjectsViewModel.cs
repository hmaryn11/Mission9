using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models.ViewModels
{
    public class ProjectsViewModel
    {
        public IQueryable<Project> Projects { get; set; }
        public PageInfo PageInfo { get; set; }

    }
}
