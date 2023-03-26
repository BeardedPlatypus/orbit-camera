using BeardedPlatypus.OrbitCamera.Core;
using UniDi;

namespace BeardedPlatypus.OrbitCamera.UniDi
{
    /// <summary>
    /// <see cref="CameraControllerInstaller"/> provides the <see cref="Controller"/>
    /// dependency.
    /// </summary>
    public sealed class CameraControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Controller>().To<Controller>().AsSingle();
        }
    }
}