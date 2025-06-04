using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Elements
{
    public class ExitButton : MonoBehaviour
    {
        [SerializeField]
        private Button _exitButton;

        private void Awake()
        {
            _exitButton.onClick.AddListener(Application.Quit);
        }
    }
}