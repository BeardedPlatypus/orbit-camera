using BeardedPlatypus.Camera.Core.Behaviours;
using BeardedPlatypus.Camera.Presets.SetOrbit;
using UnityEngine;
using Zenject;

namespace BeardedPlatypus.Camera.Zenject.Presets
{
    public class SmoothSetOrbitBehaviourInstaller : MonoInstaller
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