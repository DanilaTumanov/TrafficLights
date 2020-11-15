using System;

namespace Selectors
{
    
    /// <summary>
    /// Источник выбора индекса
    /// </summary>
    public interface ISelectionSource
    {

        event Action<int> OnSelect;

    }
}
