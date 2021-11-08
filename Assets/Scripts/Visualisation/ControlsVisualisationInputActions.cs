// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Visualisation/ControlsVisualisationInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace BeardedPlatypus.Visualisation
{
    public class @ControlsVisualisationInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ControlsVisualisationInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlsVisualisationInputActions"",
    ""maps"": [
        {
            ""name"": ""ControlsVisualisation"",
            ""id"": ""d19aaf30-b3d9-4e09-a7f8-02951200bfe6"",
            ""actions"": [
                {
                    ""name"": ""LeftMouse"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8348a641-01a3-45a1-893e-029943ccce2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMouse"",
                    ""type"": ""PassThrough"",
                    ""id"": ""89c07f4b-39d5-4433-85c3-ea3fb98a3185"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleMouse"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f98ef1a9-f515-4d46-89bf-a8a7cecdca27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CtrlButton"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f13acd2b-c034-4f22-991e-06721a79e1dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""21f1a61d-a190-43e2-8c0a-5d4bc5291097"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76bfb792-544f-408d-98e0-37b2bba8f151"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2f9021c-e2d6-4b86-a750-8436c3bd1f88"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MiddleMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ecc7d29-5621-4d0f-a94e-6a1d0e49a5f3"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CtrlButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // ControlsVisualisation
            m_ControlsVisualisation = asset.FindActionMap("ControlsVisualisation", throwIfNotFound: true);
            m_ControlsVisualisation_LeftMouse = m_ControlsVisualisation.FindAction("LeftMouse", throwIfNotFound: true);
            m_ControlsVisualisation_RightMouse = m_ControlsVisualisation.FindAction("RightMouse", throwIfNotFound: true);
            m_ControlsVisualisation_MiddleMouse = m_ControlsVisualisation.FindAction("MiddleMouse", throwIfNotFound: true);
            m_ControlsVisualisation_CtrlButton = m_ControlsVisualisation.FindAction("CtrlButton", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // ControlsVisualisation
        private readonly InputActionMap m_ControlsVisualisation;
        private IControlsVisualisationActions m_ControlsVisualisationActionsCallbackInterface;
        private readonly InputAction m_ControlsVisualisation_LeftMouse;
        private readonly InputAction m_ControlsVisualisation_RightMouse;
        private readonly InputAction m_ControlsVisualisation_MiddleMouse;
        private readonly InputAction m_ControlsVisualisation_CtrlButton;
        public struct ControlsVisualisationActions
        {
            private @ControlsVisualisationInputActions m_Wrapper;
            public ControlsVisualisationActions(@ControlsVisualisationInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @LeftMouse => m_Wrapper.m_ControlsVisualisation_LeftMouse;
            public InputAction @RightMouse => m_Wrapper.m_ControlsVisualisation_RightMouse;
            public InputAction @MiddleMouse => m_Wrapper.m_ControlsVisualisation_MiddleMouse;
            public InputAction @CtrlButton => m_Wrapper.m_ControlsVisualisation_CtrlButton;
            public InputActionMap Get() { return m_Wrapper.m_ControlsVisualisation; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ControlsVisualisationActions set) { return set.Get(); }
            public void SetCallbacks(IControlsVisualisationActions instance)
            {
                if (m_Wrapper.m_ControlsVisualisationActionsCallbackInterface != null)
                {
                    @LeftMouse.started -= m_Wrapper.m_ControlsVisualisationActionsCallbackInterface.OnLeftMouse;
                    @LeftMouse.performed -= m_Wrapper.m_ControlsVisualisationActionsCallbackInterface.OnLeftMouse;
                    @LeftMouse.canceled -= m_Wrapper.m_ControlsVisualisationActionsCallbackInterface.OnLeftMouse;
                    @RightMouse.started -= m_Wrapper.m_ControlsVisualisationActionsCallbackInterface.OnRightMouse;
                    @RightMouse.performed -= m_Wrapper.m_ControlsVisualisationActionsCallbackInterface.OnRightMouse;
                    @RightMouse.canceled -= m_Wrapper.m_ControlsVisualisationActionsCallbackInterface.OnRightMouse;
                    @MiddleMouse.started -= m_Wrapper.m_ControlsVisualisationActionsCallbackInterface.OnMiddleMouse;
                    @MiddleMouse.performed -= m_Wrapper.m_ControlsVisualisationActionsCallbackInterface.OnMiddleMouse;
                    @MiddleMouse.canceled -= m_Wrapper.m_ControlsVisualisationActionsCallbackInterface.OnMiddleMouse;
                    @CtrlButton.started -= m_Wrapper.m_ControlsVisualisationActionsCallbackInterface.OnCtrlButton;
                    @CtrlButton.performed -= m_Wrapper.m_ControlsVisualisationActionsCallbackInterface.OnCtrlButton;
                    @CtrlButton.canceled -= m_Wrapper.m_ControlsVisualisationActionsCallbackInterface.OnCtrlButton;
                }
                m_Wrapper.m_ControlsVisualisationActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @LeftMouse.started += instance.OnLeftMouse;
                    @LeftMouse.performed += instance.OnLeftMouse;
                    @LeftMouse.canceled += instance.OnLeftMouse;
                    @RightMouse.started += instance.OnRightMouse;
                    @RightMouse.performed += instance.OnRightMouse;
                    @RightMouse.canceled += instance.OnRightMouse;
                    @MiddleMouse.started += instance.OnMiddleMouse;
                    @MiddleMouse.performed += instance.OnMiddleMouse;
                    @MiddleMouse.canceled += instance.OnMiddleMouse;
                    @CtrlButton.started += instance.OnCtrlButton;
                    @CtrlButton.performed += instance.OnCtrlButton;
                    @CtrlButton.canceled += instance.OnCtrlButton;
                }
            }
        }
        public ControlsVisualisationActions @ControlsVisualisation => new ControlsVisualisationActions(this);
        public interface IControlsVisualisationActions
        {
            void OnLeftMouse(InputAction.CallbackContext context);
            void OnRightMouse(InputAction.CallbackContext context);
            void OnMiddleMouse(InputAction.CallbackContext context);
            void OnCtrlButton(InputAction.CallbackContext context);
        }
    }
}
