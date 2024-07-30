using EnigmaShopApi.Repositories;
using LearnEntityFramework.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnigmaShopApi.Controllers
{
    [ApiController]
    [Route("/api/customers")]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> repository;
        private readonly IPersistance persistance;

        public CustomerController(IRepository<Customer> repository, IPersistance persistance)
        {
            this.repository = repository;
            this.persistance = persistance;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCustomer([FromBody] Customer payload)
        {
            var customer = await repository.SaveAsync(payload);
            await persistance.SaveChangesAsync();

            return Created("/api/customers", customer);
            
        }

        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] Customer payload)
        {
            var customer = repository.Update(payload);
            persistance.SaveChangesAsync();

            return Ok(customer);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            try
            {
                var customer = await repository.FindByIdAsync(Guid.Parse(id));
                if (customer is null) return NotFound("Customer Not Found");
                repository.Delete(customer);
                await persistance.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }

        }
    }
}
