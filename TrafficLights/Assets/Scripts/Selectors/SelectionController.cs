using UnityEngine;

namespace Selectors
{
    
    /// <summary>
    /// Контроллер связывающий переключатель и источник выбора.
    /// </summary>
    public class SelectionController : MonoBehaviour
    {

        private ISelector _selector;
        private ISelectionSource _selectionSource;
        
        
        public void SetSelector(ISelector selector)
        {
            _selector = selector;
        }

        public void SetSelectionSource(ISelectionSource selectionSource)
        {
            if (_selectionSource != null)
                _selectionSource.OnSelect -= SelectionHandler;
            
            _selectionSource = selectionSource;
            _selectionSource.OnSelect += SelectionHandler;
        }

        private void SelectionHandler(int index)
        {
            _selector.Select(index);
        }
        
    }
}
