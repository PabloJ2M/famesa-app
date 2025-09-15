using UnityEngine;

public class ExternalLink : MonoBehaviour
{
    public void OpenURL(string url) => Application.OpenURL(url);
    public void OpenWsp(string number) => Application.OpenURL($"https://wa.me/{number}");
}