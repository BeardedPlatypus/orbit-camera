using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using BeardedPlatypus.OrbitCamera.Presets.SetPosition;
using UniDi;

namespace BeardedPlatypus.OrbitCamera.UniDi.Presets
{
    /// <summary>
    /// <see cref="InstantSetPositionBehaviourInstaller"/> provides the
    /// <see cref="ISetPositionBehaviour"/> dependency as a
    /// <see cref="InstantSetPositionBehaviour"/>.
    /// </summary>
    public class InstantSetPositionBehaviourInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISetPositionBehaviour>()
                     .To<InstantSetPositionBehaviour>()
                     .AsSingle();
        }
    }
}