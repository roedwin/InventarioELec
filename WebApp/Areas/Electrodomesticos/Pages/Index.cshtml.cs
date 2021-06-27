using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specification;
using ApplicationCore.Specification.Filters;
using AspNetCoreHero.ToastNotification.Abstractions;
using Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Areas.Electrodomesticos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyRepository<Electrodoméstico> _repository;
        private INotyfService _notyfService { get; }

        public IndexModel(MyRepository<Electrodoméstico> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }

        public List<Electrodoméstico> Electrodomésticos { get; set; }
        public UIPaginationModel UIPagination { get; set; }

        public async Task OnGetAsync(string searchString, int? currentPage, int? sizePage)
        {
            var totalItems = await _repository.CountAsync(new ElectrodomésticoSpec(new ElectrodomésticoFilter { Nombre = searchString, LoadChildren = false, IsPagingEnabled = true }));
            UIPagination = new UIPaginationModel(currentPage, searchString, sizePage, totalItems);

            Electrodomésticos = await _repository.ListAsync(new ElectrodomésticoSpec(
                new ElectrodomésticoFilter
                {
                    IsPagingEnabled = true,
                    Nombre = UIPagination.SearchString,
                    SizePage = UIPagination.GetSizePage,
                    Page = UIPagination.GetCurrentPage
                })
             );
        }
    }
}
