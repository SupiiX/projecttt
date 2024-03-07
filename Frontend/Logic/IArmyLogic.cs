using Frontend.Models;
using System.Collections.Generic;

namespace Frontend.Logic
{
    public interface IArmyLogic
    {
        int AllCost { get; }
        // double AVGpower { get; }
        // double AVGspeed { get; }

        void AddToArmy(Trooper trooper);
        void RemoveFromArmy(Trooper trooper);
        void EditTrooper(Trooper trooper);
        void SetupCollections(IList<Trooper> barracks, IList<Trooper> army);
    }
}