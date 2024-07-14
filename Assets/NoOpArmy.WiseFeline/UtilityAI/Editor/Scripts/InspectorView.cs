using UnityEngine.UIElements;
using UnityEditor;

namespace NoOpArmy.WiseFeline
{
    public class InspectorView : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<InspectorView, VisualElement.UxmlTraits> { }
        Editor editor;

        public InspectorView()
        {

        }

        public void UpdateSelection(UnityEngine.Object uObject)
        {
            Clear();

            UnityEngine.Object.DestroyImmediate(editor);
            editor = Editor.CreateEditor(uObject);
            IMGUIContainer container = new IMGUIContainer(() =>
            {
                if (editor.target)
                    editor.OnInspectorGUI();
            });

            Add(container);
        }
    }
}