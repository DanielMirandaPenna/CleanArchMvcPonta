using CleanArchMvcPonta.Application.DTOs;
using CleanArchMvcPonta.Application.UseCases.Interfaces;
using CleanArchMvcPonta.Domain.Validation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanArchMvcPonta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignmentTaskController : ControllerBase
    {
        private readonly IAssignmentTaskUseCase _assignmentTaskUseCase;
        private readonly IMediator _mediator;
        private readonly ILogger<AssignmentTaskController> _logger;

        public AssignmentTaskController(IAssignmentTaskUseCase assignmentTaskUseCase, IMediator mediator, ILogger<AssignmentTaskController> logger)
        {
            _assignmentTaskUseCase = assignmentTaskUseCase;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentTaskDTO>>> Get()
        {
            try
            {
                var assignmentTasks = await _assignmentTaskUseCase.GetAssignmentTasks();
                if (assignmentTasks == null)
                {
                    return NotFound("Tasks not found");
                }
                return Ok(assignmentTasks);
            }

            catch (DomainExceptionValidation ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Response with unknown ErrorCode Returned", ex.StackTrace);
                return StatusCode(500, "An unexpected error occurred.");
            }
        }


        [HttpGet("{id}", Name = "GetTask")]
        public async Task<ActionResult<AssignmentTaskDTO>> Get(int id)
        {
            try
            {
                var assignmentTasks = await _assignmentTaskUseCase.GetById(id);
                if (assignmentTasks == null)
                {
                    return NotFound("Task not found");
                }
                return Ok(assignmentTasks);
            }
            catch (DomainExceptionValidation ex)
            {
                // Return a bad request response with status code 400 and error message
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Response with unknown ErrorCode Returned", ex.StackTrace);
                return StatusCode(500, "An unexpected error occurred.");
            }

        }

        [HttpGet()]
        [Route("{userId}/GetTaskByUser")]
        public async Task<ActionResult<AssignmentTaskDTO>> GetByUser(string userId)
        {
            try
            {
                var assignmentTasks = await _assignmentTaskUseCase.GetByIdUser(userId);
                if (assignmentTasks == null)
                {
                    return NotFound("Task not found");
                }
                return Ok(assignmentTasks);
            }
            catch (DomainExceptionValidation ex)
            {
                // Return a bad request response with status code 400 and error message
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Response with unknown ErrorCode Returned", ex.StackTrace);
                return StatusCode(500, "An unexpected error occurred.");
            }

        }

        [HttpGet()]
        [Route("{id}/GetTaskByStatus")]
        public async Task<ActionResult<AssignmentTaskDTO>> GetByStatus(int id)
        {
            try
            {
                var assignmentTasks = await _assignmentTaskUseCase.GetByStatus(id);
                if (assignmentTasks == null)
                {
                    return NotFound("Task not found");
                }
                return Ok(assignmentTasks);
            }
            catch (DomainExceptionValidation ex)
            {
                // Return a bad request response with status code 400 and error message
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Response with unknown ErrorCode Returned", ex.StackTrace);
                return StatusCode(500, "An unexpected error occurred.");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AssignmentTaskDTO assignmentTask)
        {
            try
            {
                if (assignmentTask == null)
                    return BadRequest("Data Invalid");
                var claimValue = User.Claims.FirstOrDefault(claim => claim.Type.Contains(ClaimTypes.NameIdentifier));
                assignmentTask.CreatedBy = claimValue.Value;

                assignmentTask = await _assignmentTaskUseCase.Add(assignmentTask);

                return new CreatedAtRouteResult("GetTask",
                    new { id = assignmentTask.Id }, assignmentTask);
            }
            catch (DomainExceptionValidation ex)
            {
                // Return a bad request response with status code 400 and error message
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Response with unknown ErrorCode Returned", ex.StackTrace);
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AssignmentTaskDTO assignmentTask)
        {
            try
            {
                if (id != assignmentTask.Id)
                {
                    return BadRequest("Data invalid");
                }

                if (assignmentTask == null)
                    return BadRequest("Data invalid");

                var claimValue = User.Claims.FirstOrDefault(claim => claim.Type.Contains(ClaimTypes.NameIdentifier));
                assignmentTask.CreatedBy = claimValue.Value;

                await _assignmentTaskUseCase.Update(assignmentTask);

                return Ok(assignmentTask);
            }
            catch (DomainExceptionValidation ex)
            {
                // Return a bad request response with status code 400 and error message
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Response with unknown ErrorCode Returned", ex.StackTrace);
                return StatusCode(500, "An unexpected error occurred.");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AssignmentTaskDTO>> Delete(int id)
        {
            var assignmentTaskDTO = await _assignmentTaskUseCase.GetById(id);

            if (assignmentTaskDTO == null)
            {
                return NotFound("Product not found");
            }

            await _assignmentTaskUseCase.Remove(id);

            return Ok(assignmentTaskDTO);
        }
    }
}
