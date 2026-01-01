using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;

        // Simulação de base de dados em memória
        private static readonly List<EmployeeViewModel> Employees =
        [
            new() { Id = 1, Name = "Ana" },
            new() { Id = 2, Name = "Carlos" }
        ];

        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retorna lista de colaboradores
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployeeViewModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Buscando colaboradores");

            return Ok(Employees);
        }

        /// <summary>
        /// Retorna um colaborador pelo Id
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(EmployeeViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Buscando colaborador {Id}", id);

            var employee = Employees.FirstOrDefault(e => e.Id == id);

            if (employee is null)
                return NotFound();

            return Ok(employee);
        }

        /// <summary>
        /// Insere um novo colaborador
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateEmployeeRequest request)
        {
            _logger.LogInformation("Criando colaborador: {Name}", request.Name);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newEmployee = new EmployeeViewModel
            {
                Id = Employees.Max(e => e.Id) + 1,
                Name = request.Name
            };

            Employees.Add(newEmployee);

            return CreatedAtAction(
                nameof(GetById),
                new { id = newEmployee.Id },
                newEmployee
            );
        }

        /// <summary>
        /// Atualiza um colaborador existente
        /// </summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, [FromBody] UpdateEmployeeRequest request)
        {
            _logger.LogInformation("Atualizando colaborador {Id}", id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = Employees.FirstOrDefault(e => e.Id == id);

            if (employee is null)
                return NotFound();

            employee.Name = request.Name;

            return NoContent();
        }

        /// <summary>
        /// Remove um colaborador
        /// </summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Removendo colaborador {Id}", id);

            var employee = Employees.FirstOrDefault(e => e.Id == id);

            if (employee is null)
                return NotFound();

            Employees.Remove(employee);

            return NoContent();
        }
    }
}