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
    public class DeleteModel : PageModel
    {
        private readonly MyRepository<Sucursal> _repository;

        private INotyfService _notyfService { get; }
        public DeleteModel(MyRepository<Sucursal> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }

        [BindProperty]
        public Sucursal Sucursal { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int? Id, bool? saveChangesError = false)
        {
            if(Id== null)
            {
                return NotFound();
            }

            Sucursal = await _repository.GetByIdAsync(Id);
                

            if(Sucursal == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("DELETE {Id} Failed. Try again", Id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }

            var sucursal = await _repository.GetByIdAsync(Id);

            if(sucursal == null)
            {
                return NotFound();
            }



            try
            {
                await _repository.DeleteAsync(sucursal);
                await _repository.SaveChangesAsync();
                _notyfService.Success("Eliminado con exito");
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {

                
                return RedirectToPage("Index");
            }
        }

    }
}
