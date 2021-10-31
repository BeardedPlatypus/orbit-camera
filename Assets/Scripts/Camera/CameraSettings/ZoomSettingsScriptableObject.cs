using UnityEngine;

namespace BeardedPlatypus.Camera.CameraSettings
{
    /// <summary>
    /// <see cref="ZoomSettingsScriptableObject"/> provides the
    /// <see cref="IZoomSettings"/> as a <see cref="ScriptableObject"/> to be used
    /// within the camera setup.
    /// </summary>
    [CreateAssetMenu(fileName="ZoomSettings", menuName="BeardedPlatypus/Camera/ZoomSettings")]
    public sealed class ZoomSettingsScriptableObject : ScriptableObject, IZoomSettings
    {
    }
}