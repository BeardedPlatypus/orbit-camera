using BeardedPlatypus.Camera.Core;
using Zenject;

namespace BeardedPlatypus.Camera.Samples
{
    /// <summary>
    /// <see cref="CameraInstaller"/> provides the Samples specific dependency to
    /// construct the camera logic.
    /// </summary>
    public class CameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IBindings>()
                     .To<Bindings>()
                     .FromNewComponentOnNewGameObject()
                     .AsSingle();
        }
    }
}