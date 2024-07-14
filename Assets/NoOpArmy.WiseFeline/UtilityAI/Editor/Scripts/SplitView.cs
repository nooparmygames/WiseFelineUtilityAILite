using UnityEngine.UIElements;

namespace NoOpArmy.WiseFeline
{
    public class SplitView : TwoPaneSplitView
    {
        public new class UxmlFactory : UxmlFactory<SplitView, UxmlTraits> { }

        public SplitView()
        {

        }
    }
}