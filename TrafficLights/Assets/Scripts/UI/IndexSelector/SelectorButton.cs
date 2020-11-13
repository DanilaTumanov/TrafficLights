using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.IndexSelector
{
    [RequireComponent(typeof(Button))]
    public class SelectorButton : MonoBehaviour
    {

        [SerializeField]
        private TMP_Text _label;

        private Button _button;
        private int _index;

        public event Action<int> OnClick;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void Init(int index, string text)
        {
            _label.text = text;
            _index = index;
            _button.onClick.AddListener(ClickHandler);
        }

        private void ClickHandler()
        {
            OnClick?.Invoke(_index);
        }
    }
}
