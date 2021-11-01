using Zenject;

namespace BeardedPlatypus.Camera.Samples
{
    /// <summary>
    /// <see cref="CameraInputActions"/> provides the dependency to construct the
    /// camera logic.
    /// </summary>
    public class CameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IBindings>().To<Bindings>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<Controller>().To<Controller>().AsSingle();
        }
    }
}