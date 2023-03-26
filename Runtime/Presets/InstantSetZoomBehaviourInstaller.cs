using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using BeardedPlatypus.OrbitCamera.Presets.SetZoom;
using UniDi;

namespace BeardedPlatypus.OrbitCamera.UniDi.Presets
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