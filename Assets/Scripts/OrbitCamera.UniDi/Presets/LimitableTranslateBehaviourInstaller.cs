using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using BeardedPlatypus.OrbitCamera.Presets.Translate;
using JetBrains.Annotations;
using UnityEngine;
using UniDi;

namespace BeardedPlatypus.OrbitCamera.UniDi.Presets
{
    /// <summary>
    /// <see cref="LimitableTranslateBehaviourInstaller"/> provides the <see cref="ITranslateBehaviour"/>
    /// dependency as a <see cref="LimitableTranslateBehaviour"/>.
    /// </summary>
    public sealed class LimitableTranslateBehaviourInstaller : MonoInstaller
    {
        [SerializeField] [CanBeNull] private LimitableTranslateSettingsScriptableObject settings;
        
        public override void InstallBindings()
        {
            Container.Bind<ILimitableTranslateSettings>()
                     .FromInstance(settings)
                     .AsSingle();
            Container.Bind<ITranslateBehaviour>()
                     .To<LimitableTranslateBehaviour>()
                     .AsSingle();
        }
    }
}