using System;
using System.Collections.Generic;
using System.Linq;

namespace PonderingProgrammer.NTangle.Model
{
    public class Tip
    {
        private int _id;
        private string _name;
        private Activity _activity;
        private HashSet<TipRelation> _relations = new HashSet<TipRelation>();

        public Tip(int id, string name, TipType tipType)
        {
            _id = id;
            _name = name ?? throw new ArgumentNullException(nameof(name));
            TipType = tipType;
        }

        public int Id => _id;
        public string Name => _name;
        public string Summary { get; set; }
        public string ReferenceUrl { get; set; }
        public TipType TipType { get; set; }
        public Activity Activity => _activity;
        public IEnumerable<TipRelation> Relations => _relations.ToList();

        public void SetTitle(string newTitle)
        {
            _name = newTitle ?? throw new ArgumentNullException(nameof(newTitle));
        }
        
        public void RelateTo(Tip target, RelationType relationType)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (target == this) throw new ArgumentException("Cannot relate to itself");
            
            var relation =  new TipRelation(this, target, relationType);
            _relations.Add(relation);
        }

        internal void SetActivity(Activity activity)
        {
            _activity = activity;
        }
    }
}