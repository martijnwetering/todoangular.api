using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoAngular.Api.Contract;
using ToDoAngular.Api.Dtos;
using ToDoAngular.Api.Models;

namespace ToDoAngular.Api.Controllers
{
    [Route("api")]
    public class TodoController : Controller
    {
        private readonly ITodoAngularUoW _uow;


        public TodoController(ITodoAngularUoW uow)
        {
            _uow = uow;
        }

        [Route("todo")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_uow.Todos.GetAll());
        }

        [Route("todo/{id}", Name = "GetTodo")]
        [HttpGet]
        public IActionResult GetTodo(int id)
        {
            var todo = _uow.Todos.GetById(id);
            return Ok(todo);
        }

        [HttpPost]
        [Route("todo")]
        public IActionResult CreateTodo([FromBody] TodoForCreationDto todo)
        {
            if (ModelState.IsValid)
            {
                var todoForCreation = Mapper.Map<Todo>(todo);
                _uow.Todos.Add(todoForCreation);
                _uow.Commit();

                var todoToReturn = Mapper.Map<TodoDto>(todoForCreation);

                return CreatedAtRoute("GetTodo", new { id = todoToReturn.ID }, todoToReturn);
            }

            return BadRequest();
        }

        [Route("todo/{id}")]
        [HttpPut]
        public IActionResult UpdateTodo([FromBody] TodoForUpdateDto todo, int id)
        {
            if (ModelState.IsValid)
            {
                var todoForUpDate = Mapper.Map<Todo>(todo);
                _uow.Todos.Update(id, todoForUpDate);
                _uow.Commit();
                return Ok();
            }

            return BadRequest();
        }

        [Route("todo/{id}")]
        [HttpDelete]
        public IActionResult DeleteTodo(int id)
        {
            var entityToDelete = _uow.Todos.GetById(id);
            if (entityToDelete != null)
            {
                _uow.Todos.Delete(entityToDelete);
                _uow.Commit();
                return NoContent();
            }

            return NotFound(); 
        }
    }
}