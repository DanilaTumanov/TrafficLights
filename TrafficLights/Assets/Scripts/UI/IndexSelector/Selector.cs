using System;
using UnityEngine;

namespace UI.IndexSelector
{
    public class Selector : MonoBehaviour
    {

        [SerializeField]
        private SelectorButton _buttonPrefab;
        
        [SerializeField]
        private Transform _container;


        private string[] _names;


        public event Action<int, string> OnSelect;
        
        
        public void Reset(string[] names)
        {
            _names = names;

            foreach (Transform oldButton in _container)
            {
                Destroy(oldButton.gameObject);
            }

            for (int i = 0; i < _names.Length; i++)
            {
                var button = Instantiate(_buttonPrefab, _container);
                button.Init(i, _names[i]);
                button.OnClick += SelectHandler;
            }
        }

        private void SelectHandler(int index)
        {
            OnSelect?.Invoke(index, _names[index]);
        }
        
    }
}
