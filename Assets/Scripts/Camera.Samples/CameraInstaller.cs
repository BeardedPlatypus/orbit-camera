using BeardedPlatypus.Camera.SettingsComponents;
using UnityEngine;
using Zenject;

namespace BeardedPlatypus.Camera.Samples
{
    /// <summary>
    /// <see cref="CameraInputActions"/> provides the dependency to construct the
    /// camera logic.
    /// </summary>
    public class CameraInstaller : MonoInstaller
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

            Container.Bind<IBindings>().To<Bindings>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<Settings>().To<Settings>().AsSingle();
            Container.Bind<Controller>().To<Controller>().AsSingle();
        }
    }
}