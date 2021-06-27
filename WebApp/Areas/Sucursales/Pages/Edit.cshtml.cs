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

namespace WebApp.Areas.Sucursales.Pages
{
    public class EditModel : PageModel
    {
        private readonly MyRepository<Sucursal> _repository;
        private INotyfService _notyfService { get; }
        public EditModel(MyRepository<Sucursal> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }
        [BindProperty]
        public Sucursal Sucursal { get; set; }
 

      
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
                if(id == null)
                {
                    return NotFound();
                }

            Sucursal = await _repository.GetByIdAsync(id);

            if (Sucursal == null)
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
                    "Sucursal",
                    s => s.Nombre,
                    s => s.Direccion,
                    s => s.Telefono,
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
