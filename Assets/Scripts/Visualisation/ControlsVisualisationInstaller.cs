using UnityEngine;
using Zenject;

namespace BeardedPlatypus.Visualisation
{
    /// <summary>
    /// <see cref="ControlsVisualisationInstaller"/> provides the
    /// <see cref="ControlsVisualisationInputActions"/> to any objects using it as a
    /// dependency.
    /// </summary>
    public class ControlsVisualisationInstaller : MonoInstaller
    {
        [SerializeField] private GameObject buttonPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<ControlsVisualisationInputActions>()
                     .To<ControlsVisualisationInputActions>()
                     .AsSingle();
            Container.BindFactory<string, ButtonController, ButtonController.Factory>()
                     .FromComponentInNewPrefab(buttonPrefab)
                     .AsSingle();
        }
    }
}