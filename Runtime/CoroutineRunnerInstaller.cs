using BeardedPlatypus.OrbitCamera.Core;
using UniDi;

namespace BeardedPlatypus.OrbitCamera.UniDi
{
    /// <summary>
    /// <see cref="CoroutineRunnerInstaller"/> provides the <see cref="ICoroutineRunner"/>
    /// dependency.
    /// </summary>
    public sealed class CoroutineRunnerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>()
                     .To<CoroutineRunner>()
                     .FromNewComponentOnNewGameObject()
                     .WithGameObjectName("CoroutineRunner")
                     .AsSingle();
        }
    }
}