using UnityEngine;

namespace CameraSystem
{
    public static class CameraExtensions
    {
        public static void OrthographicFitter(this Camera camera, float n)
        {
            var ratio = (float) Screen.width / Screen.height;
            camera.orthographicSize = ratio >= 1 ? (n) / 2f : (n) / 2f * (1 / ratio);
        }
    }
        
        
}