using System;
using Selectors;
using UnityEngine;

namespace UI.IndexSelector
{
    
    /// <summary>
    /// UI элемент, создающий на основании массива имен набор кнопок,
    /// при нажатии на каждую из которых, будет сгенерировано событие
    /// выбора с индексом выбранного элемента
    /// </summary>
    public class Selector : MonoBehaviour, ISelectionSource
    {

        [SerializeField]
        private SelectorButton _buttonPrefab;
        
        [SerializeField]
        private Transform _container;


        private string[] _names;


        public event Action<int> OnSelect;
        
        
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
            OnSelect?.Invoke(index);
        }
        
    }
}
