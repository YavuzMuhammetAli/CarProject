using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        ISegmentService _segmentService;
        public SegmentController(ISegmentService segmentService)
        {
            _segmentService = segmentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result= _segmentService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int segmentId)
        {
            var result = _segmentService.GetById(segmentId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Segment segment)
        {
            var result = _segmentService.Add(segment);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Segment segment)
        {
            var result = _segmentService.Update(segment);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Segment segment)
        {
            var result = _segmentService.Delete(segment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
