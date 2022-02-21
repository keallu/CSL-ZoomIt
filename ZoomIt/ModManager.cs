using System;
using UnityEngine;

namespace ZoomIt
{
    public class ModManager : MonoBehaviour
    {
        private bool _initialized;
        private CameraController cameraController = null;

        public void Awake()
        {
            cameraController = GameObject.FindObjectOfType<CameraController>();
        }

        public void Update()
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
                Debug.Log("[Zoom It!] ModManager:Update -> Exception: " + e.Message);
            }
        }

        private void UpdateZoom()
        {
            try
            {
                if (cameraController != null)
                {
                    cameraController.m_minDistance = ModConfig.Instance.MinDistance;
                    cameraController.m_maxDistance = ModConfig.Instance.MaxDistance;
                    cameraController.m_unlimitedCamera = ModConfig.Instance.IgnoreBorders;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Zoom It!] ModManager:UpdateZoom -> Exception: " + e.Message);
            }
        }
    }
}
