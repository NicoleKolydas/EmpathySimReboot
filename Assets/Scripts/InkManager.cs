using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InkManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject choiceButtonPrefab;
    public Transform choiceContainer;
    public TextAsset inkJSON;

    private Story story;

    void Start()
    {
        story = new Story(inkJSON.text);
        RefreshView();
    }

    void RefreshView()
    {
        dialogueText.text = "";
        foreach (Transform child in choiceContainer)
            Destroy(child.gameObject);

        while (story.canContinue)
        {
            dialogueText.text += story.Continue();
        }

        foreach (Choice choice in story.currentChoices)
        {
            GameObject buttonObj = Instantiate(choiceButtonPrefab, choiceContainer);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
            buttonObj.GetComponent<Button>().onClick.AddListener(() =>
            {
                story.ChooseChoiceIndex(choice.index);
                RefreshView();
            });
        }
    }
}
