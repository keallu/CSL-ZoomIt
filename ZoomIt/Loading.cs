
using ICities;
using System;
using UnityEngine;

namespace ZoomIt
{

    public class Loading : LoadingExtensionBase
    {
        private GameObject _zoomManagerGameObject;

        public override void OnLevelLoaded(LoadMode mode)
        {
            try
            {
                _zoomManagerGameObject = new GameObject("ZoomItZoomManager");
                _zoomManagerGameObject.AddComponent<ZoomManager>();
            }
            catch (Exception e)
            {
                Debug.Log("[Zoom It!] Loading:OnLevelLoaded -> Exception: " + e.Message);
            }
        }

        public override void OnLevelUnloading()
        {
            try
            {
                if (_zoomManagerGameObject != null)
                {
                    UnityEngine.Object.Destroy(_zoomManagerGameObject);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Zoom It!] Loading:OnLevelUnloading -> Exception: " + e.Message);
            }
        }
    }
}