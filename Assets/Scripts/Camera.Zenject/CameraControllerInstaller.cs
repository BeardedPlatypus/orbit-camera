using BeardedPlatypus.Camera.Core;
using Zenject;

namespace BeardedPlatypus.Camera.Zenject
{
    /// <summary>
    /// <see cref="CameraControllerInstaller"/> provides the <see cref="Controller"/>
    /// dependency.
    /// </summary>
    public class CameraControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Controller>().To<Controller>().AsSingle();
        }
    }
}