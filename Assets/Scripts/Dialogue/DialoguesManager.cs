using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesManager : MonoBehaviour {

    public static DialoguesManager instance = null;

    public GameObject dialogueUI;
    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;
    private CineMode cine;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != null)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        if (dialogueUI != null)
        {
            dialogueUI.SetActive(false);
        }

        cine = GetComponent<CineMode>();
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (GameManager.instance.gameState == GameManager.gameStates.Dialogue)
        {
            if (Input.anyKeyDown)
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        GameManager.instance.gameState = GameManager.gameStates.Dialogue;

        // Active le mode cinema
        cine.LaunchCineMode();

        sentences.Clear();

        nameText.text = dialogue.name;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

        dialogueUI.SetActive(true);
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue() {
        GameManager.instance.gameState = GameManager.gameStates.Playing;
        dialogueUI.SetActive(false);

        // Active le mode cinema
        cine.QuitCineMode();
    }
}
