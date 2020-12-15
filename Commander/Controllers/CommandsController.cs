using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandController: ControllerBase
    {

        private readonly ICommanderRepo _repository;

        public CommandController(ICommanderRepo repository)
        {
            _repository = repository;   
        }

        //GET api/commands 
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();
            return Ok(commandItems);
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            return Ok(commandItem);
        }
    }
}