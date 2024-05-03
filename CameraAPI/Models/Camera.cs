using System;

namespace CameraAPI.Models
{
    public class Camera
    {
        public Guid CameraId { get; set; }
        public string CameraName { get; set; }
        public string CameraUrl { get; set; }
    }
}
