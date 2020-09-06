using System.Collections.Generic;

namespace PonderingProgrammer.NTangle.Core
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public Activity Parent { get; set; }
        public List<Activity> Children { get; set; }
        public List<Tip> Tips { get; set; }
    }
}
