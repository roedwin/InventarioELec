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
using Microsoft.AspNetCore.Http;
using System.IO;
using WebApp.Services;

namespace WebApp.Areas.Sucursales.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MyRepository<Sucursal> _repository;
        private INotyfService _notyfService { get; }
        private readonly IFileUploadService _fileUploadService;

        public CreateModel(MyRepository<Sucursal> repository, INotyfService notyfService, IFileUploadService fileUploadService)
        {
            _repository = repository;
            _notyfService = notyfService;
            _fileUploadService = fileUploadService;
        }

        [BindProperty]
        public Sucursal Sucursal { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(IFormFile fileUpload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Alumno.Fotografia = await _fileUploadService.SaveFileOnAWSS3(fileUpload, Alumno.NombreFotografia(), "mycleanarchitecturebucket");
                    //Alumno.Fotografia = await _fileUploadService.SaveFileOnDisk(fileUpload, Alumno.NombreFotografia(), "alumnos");
                    await _repository.AddAsync(Sucursal);
                    _notyfService.Success("Sucursal agregada exitosamente");
                }
                else
                {
                    _notyfService.Warning("Su formulario no cumple las reglas de negocio");
                    return Page();
                }
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {

                _notyfService.Error("Ocurrio un error en el servidor, intente nuevamente");
                return RedirectToPage("Index");
            }
        }
    }
}
