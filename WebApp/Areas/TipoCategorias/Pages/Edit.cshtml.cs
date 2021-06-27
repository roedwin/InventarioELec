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

namespace WebApp.Areas.TipoCategorias.Pages
{
    public class EditModel : PageModel
    {
        private readonly MyRepository<TipoCategoria> _repository;
        private INotyfService _notyfService { get; }
        public EditModel(MyRepository<TipoCategoria> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }
        [BindProperty]
        public TipoCategoria TipoCategoria { get; set; }
 

      
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
                if(id == null)
                {
                    return NotFound();
                }

            TipoCategoria = await _repository.GetByIdAsync(id);

            if (TipoCategoria == null)
                {
                    return NotFound();
                }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                var categoriaToUpdate = await _repository.GetByIdAsync(id);
                if(categoriaToUpdate == null)
                {
                    return NotFound();
                }
                if (await TryUpdateModelAsync(categoriaToUpdate,
                    "TipoCategoria",
                    s => s.Nombre,
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
