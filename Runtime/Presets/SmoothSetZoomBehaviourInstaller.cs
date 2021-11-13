using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using BeardedPlatypus.OrbitCamera.Presets.SetZoom;
using UnityEngine;
using Zenject;

namespace BeardedPlatypus.OrbitCamera.Zenject.Presets
{
    /// <summary>
    /// <see cref="SmoothSetZoomBehaviourInstaller"/> provides the
    /// <see cref="ISetZoomBehaviour"/> dependency as a
    /// <see cref="SmoothSetZoomBehaviour"/>.
    /// </summary>
    public sealed class SmoothSetZoomBehaviourInstaller : MonoInstaller
    {
        [SerializeField] private float maxTransitionTime = 0.5F;

        public override void InstallBindings()
        {
            Container.Bind<float>()
                     .FromInstance(maxTransitionTime)
                     .WhenInjectedInto<SmoothSetZoomBehaviour>();
            Container.Bind<ISetZoomBehaviour>()
                     .To<SmoothSetZoomBehaviour>()
                     .AsSingle();
        }
    }
}