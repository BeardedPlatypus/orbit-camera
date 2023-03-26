using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using BeardedPlatypus.OrbitCamera.Presets.SetOrbit;
using UnityEngine;
using UniDi;

namespace BeardedPlatypus.OrbitCamera.UniDi.Presets
{
    /// <summary>
    /// <see cref="SmoothSetOrbitBehaviourInstaller"/> provides the <see cref="ISetOrbitBehaviour"/>
    /// dependency as a <see cref="SmoothSetOrbitBehaviour"/>.
    /// </summary>
    public sealed class SmoothSetOrbitBehaviourInstaller : MonoInstaller
    {
        [SerializeField] private float maxTransitionTime = 0.5F;

        public override void InstallBindings()
        {
            Container.Bind<float>()
                     .FromInstance(maxTransitionTime)
                     .WhenInjectedInto<SmoothSetOrbitBehaviour>();
            Container.Bind<ISetOrbitBehaviour>()
                     .To<SmoothSetOrbitBehaviour>()
                     .AsSingle();
        }
    }
}