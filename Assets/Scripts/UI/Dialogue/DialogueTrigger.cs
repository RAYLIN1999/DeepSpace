using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public static DialogueTrigger Instance; //Instantiating the DialogueTrigger.cs
    public Dialogue dialogue;
    public bool couldInteract=false;

    void Awake()
    {
        Instance = this;
    }

    public void TriggerDialogue()      //start the conversation
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    public void OnTriggerEnter(Collider other)     //Show button when triggered
    {
        couldInteract = true;
        UIManager.Instance.ShowStartTalkButton();
    }

    public void OnTriggerExit(Collider other) //Hide button when not triggered
    {
        couldInteract = false;
        UIManager.Instance.HideStartTalkButton();
    }
}
