// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Camera.Samples/CameraInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

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
                    ""name"": ""Drag"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ef8c02c8-650d-4113-ae8e-df304ddbf3b1"",
                    ""expectedControlType"": ""Vector2"",
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_OrbitActive = m_Camera.FindAction("OrbitActive", throwIfNotFound: true);
        m_Camera_Drag = m_Camera.FindAction("Drag", throwIfNotFound: true);
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
    private readonly InputAction m_Camera_Drag;
    public struct CameraActions
    {
        private @CameraInputActions m_Wrapper;
        public CameraActions(@CameraInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @OrbitActive => m_Wrapper.m_Camera_OrbitActive;
        public InputAction @Drag => m_Wrapper.m_Camera_Drag;
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
                @Drag.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnDrag;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OrbitActive.started += instance.OnOrbitActive;
                @OrbitActive.performed += instance.OnOrbitActive;
                @OrbitActive.canceled += instance.OnOrbitActive;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    public interface ICameraActions
    {
        void OnOrbitActive(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
    }
}
