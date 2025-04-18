﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        private readonly IIngresosService _ingresoService;

        public IngresosController(IIngresosService ingresoService)
        {
            _ingresoService = ingresoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingresos>>> GetIngresos() =>
            Ok(await _ingresoService.GetAllAsync());

        [HttpGet("{id_ingreso}")]
        public async Task<ActionResult<Ingresos>> GetIngresos(int id_ingreso)
        {
            var ingresos = await _ingresoService.GetByIdAsync(id_ingreso);
            return ingresos == null ? NotFound() : Ok(ingresos);
        }

        [HttpPost]
        public async Task<IActionResult> PostIngresos(IngresosDTO ingresosDto)
        {
            await _ingresoService.AddAsync(ingresosDto);
            return CreatedAtAction(nameof(GetIngresos), new { folio = ingresosDto.Folio }, ingresosDto);
        }

        [HttpPut("{id_ingreso}")]
        public async Task<IActionResult> PutIngresos(int id_ingreso, IngresosDTO ingresosDto)
        {
            await _ingresoService.UpdateAsync(id_ingreso, ingresosDto);
            return NoContent();
        }

        [HttpDelete("{id_ingreso}")]
        public async Task<IActionResult> DeleteIngresos(int id_ingreso)
        {
            await _ingresoService.DeleteAsync(id_ingreso);
            return NoContent();
        }
    }
}
