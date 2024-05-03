using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CameraAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CameraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CamerasController : ControllerBase
    {
        private readonly CameraContext _context;

        public CamerasController(CameraContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Camera> GetCameras()
        {
            return _context.Cameras.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Camera> GetCamera(Guid id)
        {
            var camera = _context.Cameras.Find(id);

            if (camera == null)
            {
                return NotFound();
            }

            return camera;
        }

        [HttpPost]
        public ActionResult<Camera> CreateCamera(String name)
        {
            Camera camera = new Camera();
            camera.CameraName = name;
            camera.CameraId = Guid.NewGuid();
            camera.CameraUrl = $"rtmp://vktrng.ddns.net:1935/stream/{camera.CameraId}";
            _context.Cameras.Add(new Camera());
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCamera), new { id = camera.CameraId }, camera);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCamera(Guid id, Camera camera)
        {
            if (id != camera.CameraId)
            {
                return BadRequest();
            }

            _context.Entry(camera).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCamera(Guid id)
        {
            var camera = _context.Cameras.Find(id);

            if (camera == null)
            {
                return NotFound();
            }

            _context.Cameras.Remove(camera);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
