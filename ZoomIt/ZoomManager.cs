using System;
using UnityEngine;

namespace ZoomIt
{
    public class ZoomManager : MonoBehaviour
    {
        private bool _initialized;

        private void Update()
        {
            try
            {
                if (!_initialized || ModConfig.Instance.ConfigUpdated)
                {
                    UpdateZoom();

                    _initialized = true;
                    ModConfig.Instance.ConfigUpdated = false;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Zoom It!] ZoomManager:Update -> Exception: " + e.Message);
            }
        }

        private void UpdateZoom()
        {
            try
            {
                CameraController cameraController = Camera.main.GetComponent<CameraController>();

                if (cameraController != null)
                {
                    cameraController.m_minDistance = ModConfig.Instance.MinDistance;
                    cameraController.m_maxDistance = ModConfig.Instance.MaxDistance;
                    cameraController.m_unlimitedCamera = ModConfig.Instance.IgnoreBorders;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Zoom It!] ZoomManager:UpdateZoom -> Exception: " + e.Message);
            }
        }
    }
}
