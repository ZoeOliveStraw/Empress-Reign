using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UI_WidgetSceneButton : MonoBehaviour
    {
        [SerializeField] private Image scenePreviewImage;
        [SerializeField] private TextMeshProUGUI sceneLabel;
        [SerializeField] private string sceneNameActual;

        public void Initialize(SO_SceneRegistry scene)
        {
            if(scene.previewImage != null) scenePreviewImage.sprite = scene.previewImage;
            sceneLabel.text = scene.sceneTitle;
            sceneNameActual = scene.sceneName;
        }
    }
}
