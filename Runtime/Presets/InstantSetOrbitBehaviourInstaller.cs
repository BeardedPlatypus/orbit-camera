using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using BeardedPlatypus.OrbitCamera.Presets.SetOrbit;
using Zenject;

namespace BeardedPlatypus.OrbitCamera.Zenject.Presets
{
    /// <summary>
    /// <see cref="InstantSetOrbitBehaviourInstaller"/> provides the <see cref="ISetOrbitBehaviour"/>
    /// dependency as a <see cref="InstantSetOrbitBehaviour"/>.
    /// </summary>
    public sealed class InstantSetOrbitBehaviourInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISetOrbitBehaviour>()
                     .To<InstantSetOrbitBehaviour>()
                     .AsSingle();
        }
    }
}