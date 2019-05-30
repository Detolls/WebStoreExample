using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Components
{
    public class SectionsViewComponent : ViewComponent
    {
        private readonly IProductData productData;

        public SectionsViewComponent(IProductData productData)
        {
            this.productData = productData;
        }

        /// <summary>
        /// Invoke component
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sections = GetSections();
            return View(sections);
        }

        /// <summary>
        /// Get sections
        /// </summary>
        /// <returns></returns>
        private List<SectionViewModel> GetSections()
        {
            var categories = productData.GetSections();
            var parentCategories = categories.Where(p => p.ParentID.Equals(null)).ToArray();
            var parentSections = new List<SectionViewModel>();

            foreach (var parentCategory in parentCategories)
            {
                parentSections.Add(new SectionViewModel()
                {
                    ID = parentCategory.ID,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentSection = null
                });
            }

            foreach (var sectionViewModel in parentSections)
            {
                var childCategories = categories
                    .Where(c => c.ParentID.Equals(sectionViewModel.ID));

                foreach (var childCategory in childCategories)
                {
                    sectionViewModel.ChildSections.Add(new SectionViewModel()
                    {
                        ID = childCategory.ID,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentSection = sectionViewModel
                    });
                }

                sectionViewModel.ChildSections = sectionViewModel
                    .ChildSections
                    .OrderBy(c => c.Order)
                    .ToList();
            }

            parentSections = parentSections.OrderBy(c => c.Order).ToList();
            return parentSections;
        }

    }
}
