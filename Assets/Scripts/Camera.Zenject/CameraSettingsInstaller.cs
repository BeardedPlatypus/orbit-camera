using BeardedPlatypus.Camera.Core;
using BeardedPlatypus.Camera.Core.SettingsComponents;
using UnityEngine;
using Zenject;

namespace BeardedPlatypus.Camera.Zenject
{
    /// <summary>
    /// <see cref="CameraSettingsInstaller"/> provides the configured settings
    /// scriptable objects as well as the composed <see cref="Settings"/> as
    /// dependencies for other objects.
    /// </summary>
    public class CameraSettingsInstaller : MonoInstaller
    {
        [SerializeField] private OrbitSettingsScriptableObject orbitSettings;
        [SerializeField] private TranslationSettingsScriptableObject translationSettings;
        [SerializeField] private ZoomSettingsScriptableObject zoomSettings;
        
        public override void InstallBindings()
        {
            Container.Bind<IOrbitSettings>()
                     .FromInstance(orbitSettings)
                     .AsSingle();
            Container.Bind<ITranslationSettings>()
                     .FromInstance(translationSettings)
                     .AsSingle();
            Container.Bind<IZoomSettings>()
                     .FromInstance(zoomSettings)
                     .AsSingle();
            
            Container.Bind<Settings>().To<Settings>().AsSingle();
        }
    }
}