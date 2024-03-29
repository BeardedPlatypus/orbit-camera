﻿using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using BeardedPlatypus.OrbitCamera.Presets.Zoom;
using JetBrains.Annotations;
using UnityEngine;
using UniDi;

namespace BeardedPlatypus.OrbitCamera.UniDi.Presets
{
    /// <summary>
    /// <see cref="LimitableZoomBehaviourInstaller"/> provides the <see cref="IZoomBehaviour"/>
    /// dependency as a <see cref="LimitableZoomBehaviour"/>.
    /// </summary>
    public sealed class LimitableZoomBehaviourInstaller : MonoInstaller
    {
        [SerializeField] [CanBeNull] private LimitableZoomSettingsScriptableObject settings;

        public override void InstallBindings()
        {
            Container.Bind<ILimitableZoomSettings>()
                     .FromInstance(settings)
                     .AsSingle();
            Container.Bind<IZoomBehaviour>()
                     .To<LimitableZoomBehaviour>()
                     .AsSingle();
        }
    }
}