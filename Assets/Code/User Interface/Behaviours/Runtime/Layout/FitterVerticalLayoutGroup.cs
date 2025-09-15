namespace UnityEngine.UI
{
    [ExecuteAlways]
    public class FitterVerticalLayoutGroup : VerticalLayoutGroup
    {
        [SerializeField] private float referenceAspect = 1f;

        //public override void SetLayoutVertical()
        //{
        //    // Primero ajusto las alturas de los hijos
        //    for (int i = 0; i < rectChildren.Count; i++)
        //    {
        //        RectTransform child = rectChildren[i];

        //        float width = child.rect.width;
        //        float height = width / referenceAspect;

        //        SetChildAlongAxis(child, 1, child.anchoredPosition.y, height);
        //    }

        //    // Luego dejo que el VerticalLayoutGroup haga su trabajo de ordenar
        //    base.SetLayoutVertical();
        //}
    }
}