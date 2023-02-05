using GenericTypeTest.Abstract;
using GenericTypeTest.ControllerFactory;
using GenericTypeTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericTypeTest.Controllers
{
   
    [ApiController]
    [GenericRestControllerNameConvention]
    [Route("[controller]")]
    public class WriteController<T,TRequest,TResponse> : ControllerBase where T : class where TRequest : class where TResponse : class
    {
        private readonly IWriteRepository<T> _writeRepository;

        public WriteController(IWriteRepository<T> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(T item)
        {
            if (item == null) return NotFound();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var result = _writeRepository.Add(item);
            return Ok(result);
        }
    }
}
