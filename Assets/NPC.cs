using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogueData; // Make sure this is assigned in the Inspector
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image PortraitImage;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    // Ensures we can only interact if the dialogue isn't already active
    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    public void Interact()
    {
        Debug.Log("Interact with NPC");
        if (dialogueData == null || (PauseController.Instance.IsGamePaused && !isDialogueActive))
        {
            Debug.LogWarning("Dialogue data is null or game is paused.");
            return;
        }

        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        if (dialogueData == null)
        {
            Debug.LogError("Dialogue Data is missing. Please assign it in the Inspector.");
            return;
        }

        Debug.Log("Starting Dialogue");
        isDialogueActive = true;
        dialogueIndex = 0;

        // Debug log to ensure dialogueData is correctly assigned
        Debug.Log($"NPC Name: {dialogueData.npcName}");
        Debug.Log($"NPC Portrait: {dialogueData.npcPortrait}");

        nameText.text = dialogueData.npcName;
        PortraitImage.sprite = dialogueData.npcPortrait;

        dialoguePanel.SetActive(true);
        PauseController.Instance.SetPause(true);

        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = dialogueData.dialogueLines[dialogueIndex];
            isTyping = false;
        }
        else if (dialogueIndex + 1 < dialogueData.dialogueLines.Length)
        {
            dialogueIndex++;  // Move to next line
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";

        // Make sure we're not accessing null or out-of-bounds lines
        if (dialogueIndex >= dialogueData.dialogueLines.Length)
        {
            Debug.LogError("Invalid dialogue index.");
            yield break;
        }

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        // Auto-progress if applicable
        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            NextLine();
        }
    }

    public void EndDialogue()
    {
        Debug.Log("Ending Dialogue");
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
        PauseController.Instance.SetPause(false);
    }
}
