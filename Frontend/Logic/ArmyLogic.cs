using Frontend.Models;
using Frontend.Services;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic
{
    public class ArmyLogic : IArmyLogic
    {
        IList<Trooper> barracks;
        IList<Trooper> army;

        IMessenger messenger;
        ITrooperEditorService editorService;
        public ArmyLogic(IMessenger messenger, ITrooperEditorService editorService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
        }

        public int AllCost { get { return army.Count == 0 ? 0 : army.Sum(t => (t.Power*t.Vitality*t.Cost)); } }
       // public double AVGpower { get { return Math.Round(army.Count == 0 ? 0 : army.Average(t => t.Power),2); } }
       // public double AVGspeed { get { return Math.Round(army.Count == 0 ? 0 : army.Average(t => t.Vitality),2); } }
        public void SetupCollections(IList<Trooper> barracks, IList<Trooper> army)
        {
            this.barracks = barracks;
            this.army = army;
        }

        public void AddToArmy(Trooper trooper)
        {
            army.Add(trooper.GetCopy());
            messenger.Send("Trooper added", "TrooperInfo");
        }

        public void RemoveFromArmy(Trooper trooper)
        {
            army.Remove(trooper);
            messenger.Send("Trooper removed", "TrooperInfo");
        }

        public void EditTrooper(Trooper trooper)
        {
            editorService.Edit(trooper);
        
        }
    }
}
