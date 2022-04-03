﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using tplProject.Models.Repositories;
using tplProject.ViewModels;

namespace tplProject.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PassController : ControllerBase
    {
        public IPass _pass;
        public PassController(IPass pass)
        {
            _pass = pass;
        }
        [HttpPost("{Cnp}")]
        public async Task<IActionResult> AddPass(AddPassViewModel pass,decimal Cnp)
        {
            try
            {
              await _pass.AddPass(pass,Cnp);
                return Ok("CNP este:"+Cnp+pass);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);    
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(BasePassViewModel pass)
        {
            try
            {
                await _pass.Update(pass);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
               var pass= await _pass.Get(id);
                return Ok(pass);
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
                await _pass.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex.Message);
            }
        }
    }

}
