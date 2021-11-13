using BeardedPlatypus.OrbitCamera.Core;
using UniRx;
using UnityEngine;
using Zenject;

namespace BeardedPlatypus.OrbitCamera.Samples
{
    /// <summary>
    /// <see cref="ControllerBehaviour"/> implements a simple controller
    /// behaviour in a single camera setup, where the script is placed
    /// on the virtual camera, such that the <see cref="Transform"/>
    /// can be retrieved at start.
    /// </summary>
    public sealed class ControllerBehaviour : MonoBehaviour
    {
        private Controller _controller;
        
        [Inject]
        private void Init(Controller controller)
        {
            _controller = controller;
        }

        private void Start()
        {
            // We assume that the transform to control is equal to
            // the object this script is attached to.
            _controller.VirtualCameraTransform = transform;
            
            // We bind the lifetime management of the controller to
            // the lifetime of this object.
            _controller.AddTo(this);
        }
    }
}