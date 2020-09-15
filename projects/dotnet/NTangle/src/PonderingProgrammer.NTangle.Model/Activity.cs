using System;
using System.Collections.Generic;
using System.Linq;

namespace PonderingProgrammer.NTangle.Model
{
    public class Activity
    {
        private int _id;
        private string _name;
        private Activity _parent;
        private HashSet<Activity> _children = new HashSet<Activity>();
        private HashSet<Tip> _tips = new HashSet<Tip>();

        public Activity(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id => _id;
        public string Name => _name;
        public string Description { get; set; }

        public Activity Parent => _parent;
        public IEnumerable<Activity> Children => _children.ToList();
        public IEnumerable<Tip> Tips => _tips.ToList();

        public void SetName(string newName)
        {
            _name = newName ?? throw new ArgumentNullException(nameof(newName));
        }

        public void AddChild(Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));
            if (activity.IsDescendant(this)) throw new ArgumentException("Cannot add ancestor as a child");

            _children.Add(activity);
            activity.SetParent(this);
        }

        public void RemoveChild(Activity activity)
        {
            var removed = _children.Remove(activity);
            if (removed) activity.SetParent(null);
        }

        public void AddTip(Tip tip)
        {
            if (tip == null) throw new ArgumentNullException(nameof(tip));
            _tips.Add(tip);
            tip.SetActivity(this);
        }

        public void RemoveTip(Tip tip)
        {
            var removed = _tips.Remove(tip);
            if (removed) tip.SetActivity(null);
        }
        
        private void SetParent(Activity newParent)
        {
            _parent = newParent;
        }

        private bool IsDescendant(Activity activity)
        {
            return ActivityTreeBreadthFirstSearch(a => a == activity) != null;
        }

        private Activity ActivityTreeBreadthFirstSearch(Func<Activity, bool> predicate)
        {
            var queue = new Queue<Activity>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (predicate.Invoke(current))
                {
                    return current;
                }
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
    }
}
