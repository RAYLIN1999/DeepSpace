using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance; //Instantiating the DialogueManager.cs

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    private Queue<string> sentences;

    [SerializeField] public bool ConversationStart = false;    //Determining if a conversation is over
    [SerializeField] public bool ConversationOver = false;    //Determining if a conversation is over



    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with "+ dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear();   //����֮ǰ�ĶԻ�
        ConversationStart = true;
        ConversationOver = false;


        foreach (string sentence in dialogue.sentences)  //�����ַ��������е�ÿ������
        {
            sentences.Enqueue(sentence);   //�����Ӽ��뵽������
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)   //�ж��Ƿ��Ѿ��ﵽ���е�ĩβ
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();   //���ö����е���һ������
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");  
        ConversationStart = false;
        ConversationOver = true;
    }

    public void changeBool()
    {
        ConversationOver = false;
    }

}
