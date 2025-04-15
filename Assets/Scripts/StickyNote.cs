using UnityEngine;

public class StickyNote : MonoBehaviour
{
    public string noteText = "You said you’d do better today.";
    private bool isLooking = false;

    void OnMouseEnter()
    {
        isLooking = true;
    }

    void OnMouseExit()
    {
        isLooking = false;
    }

    void OnGUI()
    {
        if (isLooking)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 24;
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.MiddleCenter;

            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height - 100, 400, 50), noteText, style);
        }
    }
}
