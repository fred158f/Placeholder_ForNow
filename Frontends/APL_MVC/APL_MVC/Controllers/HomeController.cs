using ADL.Interfaces.db_Specific;
using ADL.Models.db_Models;
using APL_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PDL.Viewmodels;
using System.Diagnostics;

namespace APL_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<MeasurementSource> _sourceRepo;
        private readonly IRepository<MeasurementType> _typeRepo;

        public HomeController(ILogger<HomeController> logger, IRepository<MeasurementSource> sourceRepo, IRepository<MeasurementType> typeRepo)
        {
            _logger = logger;
            _sourceRepo = sourceRepo;
            _typeRepo = typeRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<MeasurementSourceViewModel> Sources { get; set; }
        public List<MeasurementTypeViewModel> Types { get; set; }

        public async Task<IActionResult> Measurements()
        {
            List<MeasurementSource>? measurementSources = (await _sourceRepo.GetAllAsync()).ToList();
            List<MeasurementType>? measurementTypes = (await _typeRepo.GetAllAsync()).ToList();

            Sources = new List<MeasurementSourceViewModel>();

            if (measurementTypes == null || measurementTypes.Count == 0)
            {
                measurementTypes = new List<MeasurementType>
                {
                    new MeasurementType() { Name = "Voltage", Unit = "V"},
                    new MeasurementType() { Name = "Speed", Unit="km/t"}
                };

                _typeRepo.AddRange(measurementTypes);
                await _typeRepo.SaveChangesAsync();
            }

            if (measurementSources == null || measurementSources.Count == 0)
            {
                measurementSources = new List<MeasurementSource>
                {
                    new MeasurementSource() { Name = "Multimeter", Type = await _typeRepo.SingleOrDefaultAsync(x => x.Name == "Voltage") },
                    new MeasurementSource() { Name = "Speedometer", Type = await _typeRepo.SingleOrDefaultAsync(x => x.Name == "Speed") }
                };

                _sourceRepo.AddRange(measurementSources);
                await _sourceRepo.SaveChangesAsync();
            }

            if (measurementSources != null && measurementSources.Count > 0)
            {
                foreach (MeasurementSource source in measurementSources)
                {
                    Sources.Add(new MeasurementSourceViewModel()
                    {
                        Id = source.Id,
                        Name = source.Name,
                        SourceType = new MeasurementTypeViewModel()
                        {
                            Name = source.Type.Name,
                            Unit = source.Type.Unit,
                            Id = source.Id
                        }
                    });
                }
            }

            return View(Sources);
        }

        public async Task<IActionResult> MeasurementsAdd()
        {
            IEnumerable<MeasurementType>? measurementTypes = await _typeRepo.GetAllAsync();

            if (measurementTypes != null)
            {
                Types = new List<MeasurementTypeViewModel>();
                foreach (MeasurementType measurementType in measurementTypes)
                {
                    Types.Add(new MeasurementTypeViewModel()
                    {
                        Id = measurementType.Id,
                        Name = measurementType.Name,
                        Unit = measurementType.Unit
                    });
                }
                ViewData["Types"] = Types.ToList();
                return View();
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> MeasurementsAdd(MeasurementSourceViewModel sourceViewModel)
        {
            if (ModelState.IsValid)
            {
                MeasurementSource source = new MeasurementSource()
                {
                    Name = sourceViewModel.Name,
                    Type = await _typeRepo.GetAsync(sourceViewModel.Id)

                };
                _sourceRepo.Add(source);
                await _sourceRepo.SaveChangesAsync();
            }

            return View("Measurements");
        }

        private MeasurementTypeViewModel? GetTypeFromID(int id)
        {
            MeasurementType measurementType = _typeRepo.Get(id);
            MeasurementTypeViewModel returnType = null;
            if (measurementType != null) {
                returnType = new MeasurementTypeViewModel()
                {
                    Id = id,
                    Name = measurementType.Name,
                    Unit = measurementType.Unit
                };
            }
            return returnType;
        }
    }
}