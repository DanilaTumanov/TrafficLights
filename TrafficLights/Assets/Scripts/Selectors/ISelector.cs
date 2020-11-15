using UnityEngine;

namespace Selectors
{
    
    /// <summary>
    /// Переключатель
    /// Способен производить выбор на основе индекса
    /// </summary>
    public interface ISelector
    {

        void Select(int index);
        void Reset();

    }
}
