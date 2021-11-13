// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/OrbitCamera.Samples/CameraInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace BeardedPlatypus.OrbitCamera.Samples
{
    public class @CameraInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @CameraInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""CameraInputActions"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""fc6c3c74-e078-4e35-9082-fe9e0abc0ef9"",
            ""actions"": [
                {
                    ""name"": ""OrbitActive"",
                    ""type"": ""PassThrough"",
                    ""id"": ""edebc6ba-b975-4121-94c6-8301271829f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TranslateActive"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ed9fb926-f540-4644-925b-5d77fcd61d9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TranslateAlt"",
                    ""type"": ""PassThrough"",
                    ""id"": ""487972e7-1353-4ef3-9cb6-237cab0973ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ef8c02c8-650d-4113-ae8e-df304ddbf3b1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fccb47b7-7786-4232-a49d-452a2721b684"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0436fd18-031b-47ed-b0de-76d4838b361e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OrbitActive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f8e60cd-1f47-48b7-aa33-55296c17f8bb"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""601e1bbc-9727-4447-a624-131763c36704"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1694a49-2b83-419f-a972-c06e042845b5"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TranslateAlt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d65d7c9a-d06a-4cd1-ade8-629c7ef4ef6a"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TranslateActive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Camera
            m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
            m_Camera_OrbitActive = m_Camera.FindAction("OrbitActive", throwIfNotFound: true);
            m_Camera_TranslateActive = m_Camera.FindAction("TranslateActive", throwIfNotFound: true);
            m_Camera_TranslateAlt = m_Camera.FindAction("TranslateAlt", throwIfNotFound: true);
            m_Camera_Drag = m_Camera.FindAction("Drag", throwIfNotFound: true);
            m_Camera_Zoom = m_Camera.FindAction("Zoom", throwIfNotFound: true);
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

        // Camera
        private readonly InputActionMap m_Camera;
        private ICameraActions m_CameraActionsCallbackInterface;
        private readonly InputAction m_Camera_OrbitActive;
        private readonly InputAction m_Camera_TranslateActive;
        private readonly InputAction m_Camera_TranslateAlt;
        private readonly InputAction m_Camera_Drag;
        private readonly InputAction m_Camera_Zoom;
        public struct CameraActions
        {
            private @CameraInputActions m_Wrapper;
            public CameraActions(@CameraInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @OrbitActive => m_Wrapper.m_Camera_OrbitActive;
            public InputAction @TranslateActive => m_Wrapper.m_Camera_TranslateActive;
            public InputAction @TranslateAlt => m_Wrapper.m_Camera_TranslateAlt;
            public InputAction @Drag => m_Wrapper.m_Camera_Drag;
            public InputAction @Zoom => m_Wrapper.m_Camera_Zoom;
            public InputActionMap Get() { return m_Wrapper.m_Camera; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
            public void SetCallbacks(ICameraActions instance)
            {
                if (m_Wrapper.m_CameraActionsCallbackInterface != null)
                {
                    @OrbitActive.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnOrbitActive;
                    @OrbitActive.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnOrbitActive;
                    @OrbitActive.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnOrbitActive;
                    @TranslateActive.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnTranslateActive;
                    @TranslateActive.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnTranslateActive;
                    @TranslateActive.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnTranslateActive;
                    @TranslateAlt.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnTranslateAlt;
                    @TranslateAlt.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnTranslateAlt;
                    @TranslateAlt.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnTranslateAlt;
                    @Drag.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnDrag;
                    @Drag.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnDrag;
                    @Drag.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnDrag;
                    @Zoom.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                    @Zoom.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                    @Zoom.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                }
                m_Wrapper.m_CameraActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @OrbitActive.started += instance.OnOrbitActive;
                    @OrbitActive.performed += instance.OnOrbitActive;
                    @OrbitActive.canceled += instance.OnOrbitActive;
                    @TranslateActive.started += instance.OnTranslateActive;
                    @TranslateActive.performed += instance.OnTranslateActive;
                    @TranslateActive.canceled += instance.OnTranslateActive;
                    @TranslateAlt.started += instance.OnTranslateAlt;
                    @TranslateAlt.performed += instance.OnTranslateAlt;
                    @TranslateAlt.canceled += instance.OnTranslateAlt;
                    @Drag.started += instance.OnDrag;
                    @Drag.performed += instance.OnDrag;
                    @Drag.canceled += instance.OnDrag;
                    @Zoom.started += instance.OnZoom;
                    @Zoom.performed += instance.OnZoom;
                    @Zoom.canceled += instance.OnZoom;
                }
            }
        }
        public CameraActions @Camera => new CameraActions(this);
        public interface ICameraActions
        {
            void OnOrbitActive(InputAction.CallbackContext context);
            void OnTranslateActive(InputAction.CallbackContext context);
            void OnTranslateAlt(InputAction.CallbackContext context);
            void OnDrag(InputAction.CallbackContext context);
            void OnZoom(InputAction.CallbackContext context);
        }
    }
}
