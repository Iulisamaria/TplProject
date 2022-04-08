using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tplProject.Models.Repositories.New;
using tplProject.ViewModels;

namespace tplProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        public readonly INewsRepository _news;
        public NewsController(INewsRepository news)
        {
            _news = news;
        }


        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddNewsViewModel news)
        {
            try
            {
                _news.Add(news);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateNewsViewModel news)
        {
            try
            {
                await _news.Update(news);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var news = await _news.Get(id);
                return Ok(news);
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex);
            }
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var news = await _news.GetAll();
                return Ok(news);
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _news.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex.Message);
            }
        }
    }
}
