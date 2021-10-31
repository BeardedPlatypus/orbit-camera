using UnityEngine;

namespace BeardedPlatypus.Camera.SettingsComponents
{
    /// <summary>
    /// <see cref="TranslationSettingsScriptableObject"/> provides the
    /// <see cref="ITranslationSettings"/> as a <see cref="ScriptableObject"/> to be
    /// used within the camera setup.
    /// </summary>
    [CreateAssetMenu(fileName="TranslationSettings", menuName="BeardedPlatypus/Camera/TranslationSettings")]
    public sealed class TranslationSettingsScriptableObject : ScriptableObject, ITranslationSettings
    {
    }
}