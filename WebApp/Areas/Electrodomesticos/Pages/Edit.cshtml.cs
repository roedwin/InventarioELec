using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infraestructure.Data;

namespace WebApp.Areas.Electrodomesticos.Pages
{
    public class EditModel : PageModel
    {
        private readonly MyRepository<Electrodoméstico> _repository;
        private INotyfService _notyfService { get; }
        public EditModel(MyRepository<Electrodoméstico> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }
        [BindProperty]
        public Electrodoméstico Electrodoméstico { get; set; }
 

      
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
                if(id == null)
                {
                    return NotFound();
                }

            Electrodoméstico = await _repository.GetByIdAsync(id);

            if (Electrodoméstico == null)
                {
                    return NotFound();
                }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                var electrodomesticoToUpdate = await _repository.GetByIdAsync(id);
                if(electrodomesticoToUpdate == null)
                {
                    return NotFound();
                }
                if (await TryUpdateModelAsync(electrodomesticoToUpdate,
                    "Electrodoméstico",
                    s => s.Nombre,
                    s => s.IdCategoria,
                    s => s.Cantidad,
                    s => s.IdSucursal,
                    s => s.Estado))
                {
                    await _repository.SaveChangesAsync();
                    _notyfService.Success("Se ha guardado con exito");
                    return base.RedirectToPage("./Index");
                }
            }
            catch(Exception ex)
            {
                _notyfService.Error("Error no se puede");
            }
            return Page();
        }
        
    }
}
