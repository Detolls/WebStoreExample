using System.Collections.Generic;
using WebStore.Domain.Entities.Base;

namespace WebStore.Models
{
    public class SectionViewModel : INamedEntity, IOrderedEntity
    {
        public SectionViewModel()
        {
            ChildSections = new List<SectionViewModel>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        /// <summary>
        /// Child sections
        /// </summary>
        public List<SectionViewModel> ChildSections { get; set; }

        /// <summary>
        /// Parent section
        /// </summary>
        public SectionViewModel ParentSection { get; set; }
    }
}
