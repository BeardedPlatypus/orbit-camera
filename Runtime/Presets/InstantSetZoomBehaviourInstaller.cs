using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using BeardedPlatypus.OrbitCamera.Presets.SetZoom;
using Zenject;

namespace BeardedPlatypus.OrbitCamera.Zenject.Presets
{
    /// <summary>
    /// <see cref="InstantSetZoomBehaviourInstaller"/> provides the
    /// <see cref="ISetZoomBehaviour"/> dependency as a
    /// <see cref="InstantSetZoomBehaviour"/>.
    /// </summary>
    public class InstantSetZoomBehaviourInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISetZoomBehaviour>()
                     .To<InstantSetZoomBehaviour>()
                     .AsSingle();
        }
    }
}