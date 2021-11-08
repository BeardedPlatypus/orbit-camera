using BeardedPlatypus.Camera.Core.Behaviours;
using BeardedPlatypus.Camera.Presets.SetZoom;
using Zenject;

namespace BeardedPlatypus.Camera.Zenject.Presets
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