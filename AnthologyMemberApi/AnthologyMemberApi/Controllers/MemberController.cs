using AnthologyMemberApi.Models;
using AnthologyMemberApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnthologyMemberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        IRepository<MemberDemographic> _member;
        public MemberController(IRepository<MemberDemographic> member)
        {
                _member=member;
        }

        [HttpGet]
        [Route("GetMembers")]
        public async Task<IActionResult> GetMembers()
        {
            try
            {
                var members = await _member.GetAll();
                if (members == null)
                {
                    return NotFound();
                }

                return Ok(members);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("CreateMember")]
        public async Task<IActionResult> CreateMember([FromBody] MemberDemographic model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var memberObj = await _member.Create(model);
                    if (memberObj!=null)
                    {
                        return Ok(memberObj);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("DeleteMember")]
        public async Task<IActionResult> DeleteMember(MemberDemographic memberObj)
        {
            int result = 0;

            if (memberObj == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _member.Delete(memberObj);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [Route("UpdateMember")]
        public async Task<IActionResult> UpdateMember([FromBody] MemberDemographic model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _member.Update(model);

                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
