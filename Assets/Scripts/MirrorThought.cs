using UnityEngine;

public class MirrorThought : MonoBehaviour
{
    public string mirrorText = "You don't even recognize yourself anymore.";
    private bool showThought = false;

    void OnMouseEnter()
    {
        showThought = true;
    }

    void OnMouseExit()
    {
        showThought = false;
    }

    void OnGUI()
    {
        if (showThought)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 24;
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.MiddleCenter;

            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height - 140, 400, 50), mirrorText, style);
        }
    }
}
