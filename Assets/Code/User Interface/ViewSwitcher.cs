using UnityEngine;

public class ViewSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] _views;

    private void Awake()
    {
        if (Application.isEditor) return;
        OpenView(0);
    }

    public void OpenView(int index)
    {
        for (int i = 0; i < _views.Length; i++)
            _views[i].SetActive(i == index);
    }
}