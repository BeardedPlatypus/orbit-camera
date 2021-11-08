using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BeardedPlatypus.Visualisation
{
    /// <summary>
    /// <see cref="ButtonController"/> handles the transparency of the button when it
    /// is spawned.
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] private float fadeTime = 1F;

        [SerializeField] private TMP_Text buttonText;
        [SerializeField] private Graphic background;
        
        private float _alpha = 0F;
        private string _key;

        [Inject]
        private void Init(string key)
        {
            _key = key;
        }

        private void Awake()
        {
            Configure(_key);
            
            SetAlpha(buttonText, _alpha);
            SetAlpha(background, _alpha);
        }

        private void Start()
        {
            StartCoroutine(FadeTo(1.0F, fadeTime));
        }

        private void Configure(string key)
        {
            switch (key)
            {
                // TODO: Clean this up a bit
                case "Ctrl":
                case "Alt":
                    SetWidth(125);
                    break;
                case "Shift":
                case "Enter":
                    SetWidth(200);
                    break;
                case "Tab":
                    SetWidth(150);
                    break;
                case "Space":
                    SetWidth(300);
                    break;
            }

            buttonText.text = key;
        }

        public void Remove()
        {
            StartCoroutine(FadeTo(0.0F, fadeTime));
            Destroy(gameObject, fadeTime + 0.1F);
        }

        private IEnumerator FadeTo(float alphaVal, float totalTime)
        {
            float initialAlpha = _alpha;
            var timeFactor = 1.0F / totalTime;
            
            for (var t = 0.0F; t < 1.0F; t += Time.deltaTime * timeFactor)
            {
                _alpha = Mathf.Lerp(initialAlpha, alphaVal, t);
                SetAlpha(buttonText, _alpha);
                SetAlpha(background, _alpha);
                yield return null;
            }
        }

        private static void SetAlpha(Graphic graphic, float value)
        {
            var color = graphic.color;
            color.a = value;
            graphic.color = color;
        }

        private void SetWidth(float width)
        {
            background.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            buttonText.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);

            var containerRectTransform = GetComponent<RectTransform>();
            containerRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }
        
        public sealed class Factory : PlaceholderFactory<string, ButtonController> { }
    }
}