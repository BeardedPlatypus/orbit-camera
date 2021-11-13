using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Samples
{
    [CreateAssetMenu(fileName="ResetData", 
                     menuName="BeardedPlatypus/Samples/ResetData")]
    public class ResetDataScriptableObject : ScriptableObject
    {
        [SerializeField] private int throttleTime = 500;
        [SerializeField] private Vector2 resetOrbit = new Vector2(45F, 0F);
        [SerializeField] private Vector3 resetPosition = Vector3.zero;
        [SerializeField] private float resetZoom = Mathf.Sqrt(18);

        public int ThrottleTime => throttleTime;
        public Vector2 ResetOrbit => resetOrbit;
        public Vector3 ResetPosition => resetPosition;
        public float ResetZoom => resetZoom;
    }
}