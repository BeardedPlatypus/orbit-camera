using BeardedPlatypus.Camera.Core;
using BeardedPlatypus.Camera.Core.Behaviours;
using BeardedPlatypus.Camera.Presets.Orbit;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace BeardedPlatypus.Camera.Zenject.Presets
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