using BeardedPlatypus.Camera.Core;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

namespace BeardedPlatypus.Visualisation
{
    /// <summary>
    /// <see cref="MouseVisualisationController"/> implements the behaviour
    /// to visualise which mouse buttons are clicked when running the application.
    /// </summary>
    public sealed class MouseVisualisationController : MonoBehaviour
    {
        [SerializeField] private Color activeColor;
        [SerializeField] private Color inactiveColor;
        
        [SerializeField] private Image mouseLeftButton;
        [SerializeField] private Image mouseMiddleButton;
        [SerializeField] private Image mouseRightButton;

        // Note: Given that the MouseVisualisationController will not be exposed,
        //       nor will the specific input action streams be reused, we do not
        //       explicitly separate the bindings and instead use the input actions
        //       directly.
        private ControlsVisualisationInputActions _inputActions;

        [Inject]
        private void Init(ControlsVisualisationInputActions inputActions)
        {
            _inputActions = inputActions;
        }

        private void Awake() => ConfigureObservables();

        private void Start() => _inputActions.Enable();

        private void ConfigureObservables()
        {
            ConfigureInputAction(_inputActions.ControlsVisualisation.LeftMouse,
                                 mouseLeftButton);
            ConfigureInputAction(_inputActions.ControlsVisualisation.MiddleMouse,
                                 mouseMiddleButton);
            ConfigureInputAction(_inputActions.ControlsVisualisation.RightMouse,
                                 mouseRightButton);
        }
        
        private void ConfigureInputAction(InputAction action, Graphic mouseImage) =>
            action.ActionAsObservable()
                  .Select(InterpretAsBool)
                  .StartWith(false)
                  .DistinctUntilChanged()
                  .Select(ToColor)
                  .Subscribe(color => mouseImage.color = color)
                  .AddTo(this);

        private Color ToColor(bool isActive) => isActive ? activeColor : inactiveColor;

        private static bool InterpretAsBool(InputAction.CallbackContext context) =>
            context.ReadValue<float>() != 0F;
    }
}
