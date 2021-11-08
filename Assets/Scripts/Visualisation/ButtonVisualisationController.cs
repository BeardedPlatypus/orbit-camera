using System.Collections.Generic;
using BeardedPlatypus.Camera.Core;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace BeardedPlatypus.Visualisation
{
    // TODO: Improve the way keys are handled. Ideally if we are repressing a button it should be 
    // TODO: reused, not creating a new element.
    public class ButtonVisualisationController : MonoBehaviour
    {
        private readonly IDictionary<string, ButtonController> _pressedButtons = 
            new Dictionary<string, ButtonController>();
        
        // Note: Given that the MouseVisualisationController will not be exposed,
        //       nor will the specific input action streams be reused, we do not
        //       explicitly separate the bindings and instead use the input actions
        //       directly.
        private ControlsVisualisationInputActions _inputActions;
        private ButtonController.Factory _buttonControllerFactory;

        [Inject]
        private void Init(ControlsVisualisationInputActions inputActions,
                          ButtonController.Factory buttonControllerFactory)
        {
            _inputActions = inputActions;
            _buttonControllerFactory = buttonControllerFactory;
        }

        private void Awake() => ConfigureObservables();

        private void Start() => _inputActions.Enable();

        private void ConfigureObservables()
        {
            _inputActions.ControlsVisualisation.CtrlButton
                .ActionAsObservable()
                .Select(InterpretAsBool)
                .Select(val => ("Ctrl", val))
                .Subscribe(v => HandleKey(v.Item1, v.val))
                .AddTo(this);
        }
        
        private static bool InterpretAsBool(InputAction.CallbackContext context) =>
            context.ReadValue<float>() != 0F;

        private void HandleKey(string key, bool isPressed)
        {
            if (isPressed) AddKey(key);
            else RemoveKey(key);
        }

        private void AddKey(string key)
        {
            if (_pressedButtons.ContainsKey(key))
                return;

            var newButton = _buttonControllerFactory.Create(key);
            newButton.transform.SetParent(transform);
            
            _pressedButtons.Add(key, newButton);
        }

        private void RemoveKey(string key)
        {
            if (_pressedButtons.TryGetValue(key, out var controller))
            {
                _pressedButtons.Remove(key);
                controller.Remove();
            }
        }
    }
}