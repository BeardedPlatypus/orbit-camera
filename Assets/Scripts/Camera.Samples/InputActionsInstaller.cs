using Zenject;

namespace BeardedPlatypus.Camera.Samples
{
    /// <summary>
    /// <see cref="InputActionsInstaller"/> provides the
    /// <see cref="CameraInputActions"/> to any objects using it as a dependency.
    /// </summary>
    public sealed class InputActionsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CameraInputActions>()
                     .To<CameraInputActions>()
                     .AsSingle();
        }
    }
}