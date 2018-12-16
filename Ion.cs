using Chemistry.Interfaces;

namespace Chemistry
{
    public class Ion : ICharged
    {
        public Ion(IAtomic content)
        {
            Content = content;
        }
        
        public IAtomic Content { get; }
        
        public int GetCharge() => -(Content.Electrons - Content.Protons);
    }
}