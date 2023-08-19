using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webPagination.Data;
using webPagination.Models;

namespace webPagination.Controllers
{
	[ApiController]
	[Route("v1/todos")]
	public class TodoController : ControllerBase
	{
		[HttpGet("load")]
		public async Task<IActionResult> LoadAsync(
			[FromServices] AppDbContext context)
		{
			for (int i = 0; i < 1348; i++)
			{
				var todo = new Todo()
				{
					Id = i + 1,
					Done = false,
					CreatedAt = DateTime.Now,
					Title = $"Tarefa {i}"
				};
				await context.Todos.AddAsync(todo);
				await context.SaveChangesAsync();
			}

			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync(
			[FromServices]AppDbContext context,
			[FromQuery] int skip = 0,
			[FromQuery] int take = 25)
		{
			var todos = await context.Todos
				.AsNoTracking()
				.Skip(skip)
				.Take(take)
				.ToListAsync();		

			return Ok(todos);
		}
	}
}

