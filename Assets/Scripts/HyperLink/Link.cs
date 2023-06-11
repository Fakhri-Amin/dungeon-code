using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Link : MonoBehaviour
{

    public void OpenLink()
    {
#if !UNITY_EDITOR
		openWindow("https://farou.itch.io");
		return;
#endif

        Application.OpenURL("https://farou.itch.io");
    }

    [DllImport("__Internal")]
    private static extern void openWindow(string url);

}