using Zenject;

namespace BeardedPlatypus.Camera.Samples
{
    /// <summary>
    /// <see cref="ControlsVisualisationInstaller"/> provides the
    /// <see cref="ControlsVisualisationInputActions"/> to any objects using it as a
    /// dependency.
    /// </summary>
    public class ControlsVisualisationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ControlsVisualisationInputActions>()
                     .To<ControlsVisualisationInputActions>()
                     .AsSingle();
        }
    }
}