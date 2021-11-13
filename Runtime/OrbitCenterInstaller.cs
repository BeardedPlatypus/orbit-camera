using BeardedPlatypus.OrbitCamera.Core;
using UnityEngine;
using Zenject;

namespace BeardedPlatypus.OrbitCamera.Zenject
{
    /// <summary>
    /// <see cref="OrbitCenterInstaller"/> provides the <see cref="IOrbitCenter"/> as a
    /// <see cref="OrbitCenter"/>.
    /// </summary>
    public sealed class OrbitCenterInstaller : MonoInstaller
    {
        [SerializeField] private Vector3 orbitCenter;

        public override void InstallBindings()
        {
            Container.Bind<Vector3>()
                     .FromInstance(orbitCenter)
                     .AsSingle()
                     .WhenInjectedInto<OrbitCenter>();
            Container.Bind<IOrbitCenter>()
                     .To<OrbitCenter>()
                     .FromNewComponentOnNewGameObject()
                     .WithGameObjectName("OrbitCenter")
                     .AsSingle();
        }
    }
}