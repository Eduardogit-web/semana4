using Microsoft.AspNetCore.Mvc;
using CentroAdopcion.Models;

using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using CentroAdopcion.Data;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        // Obtener animales disponibles (sin adopciones finalizadas)
        var animalesDisponibles = await _context.Animales
            .Include(a => a.Especie)
            .Include(a => a.Refugio)
            .Where(a => !a.Adopciones.Any(ad => ad.Estado == "Finalizada"))
            .Take(5) // Limitar a 5 para la página principal
            .ToListAsync();

        // Modelo para la vista
        var viewModel = new HomeIndexViewModel
        {
            AnimalesDisponibles = animalesDisponibles,
            TotalAnimales = await _context.Animales.CountAsync(),
            TotalAdopciones = await _context.Adopciones.CountAsync(),
            TotalRefugios = await _context.Refugios.CountAsync()
        };

        return View(viewModel);
    }
}

// Modelo para la vista
public class HomeIndexViewModel
{
    public List<Animal> AnimalesDisponibles { get; set; }
    public int TotalAnimales { get; set; }
    public int TotalAdopciones { get; set; }
    public int TotalRefugios { get; set; }
}
