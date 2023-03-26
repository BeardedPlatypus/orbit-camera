using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using BeardedPlatypus.OrbitCamera.Presets.Orbit;
using JetBrains.Annotations;
using UnityEngine;
using UniDi;

namespace BeardedPlatypus.OrbitCamera.UniDi.Presets
{
    /// <summary>
    /// <see cref="LimitableOrbitBehaviourInstaller"/> provides the <see cref="IOrbitBehaviour"/>
    /// dependency as a <see cref="LimitableOrbitBehaviour"/>.
    /// </summary>
    public sealed class LimitableOrbitBehaviourInstaller : MonoInstaller
    {
        [SerializeField] [CanBeNull] private LimitableOrbitSettingsScriptableObject settings;
        
        public override void InstallBindings()
        {
            Container.Bind<ILimitableOrbitSettings>()
                     .FromInstance(settings)
                     .AsSingle();
            Container.Bind<IOrbitBehaviour>()
                     .To<LimitableOrbitBehaviour>()
                     .AsSingle();
        }
    }
}