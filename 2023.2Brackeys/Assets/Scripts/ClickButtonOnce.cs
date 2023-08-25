using UnityEngine;
using UnityEngine.UI;

public class ClickOnceButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        // Disable the button
        button.interactable = false;

        // Perform button action here

        // Enable all other buttons
        EnableAllButtonsExceptCurrent();
    }

    private void EnableAllButtonsExceptCurrent()
    {
        ClickOnceButton[] allButtons = FindObjectsOfType<ClickOnceButton>();
        foreach (ClickOnceButton otherButton in allButtons)
        {
            if (otherButton != this)
            {
                otherButton.button.interactable = true;
            }
        }
    }
}
