using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Samples
{
    /// <summary>
    /// <see cref="SceneLoaderController"/> loads the dependent scenes at
    /// start up.
    /// </summary>
    public class SceneLoaderController : MonoBehaviour
    {
#if !UNITY_EDITOR
        private void Awake()
        {
            SceneManager.LoadSceneAsync("ControlsVisualisation", 
                                        LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync("SampleScene", 
                                        LoadSceneMode.Additive);

        }
#endif
    }
}
