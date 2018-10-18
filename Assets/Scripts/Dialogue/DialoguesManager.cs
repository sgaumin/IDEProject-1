using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesManager : MonoBehaviour {

    public static DialoguesManager instance = null;

    [Header("UI")]
    public GameObject dialogueUI;
    public Text nameText;
    public Text dialogueText;

    [Header("Sounds")]
    public AudioSource voiceSound;
    public AudioSource bipSound;

    private Queue<string> sentences;
    private Queue<AudioClip> voices;

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
        voices = new Queue<AudioClip>();
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
        voices.Clear();

        nameText.text = dialogue.name;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (AudioClip voice in dialogue.voices)
        {
            voices.Enqueue(voice);
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

        //if (voices.Count == 0)
        //{
        //    EndDialogue();
        //    return;
        //}

        AudioClip voice = voices.Dequeue();
        string sentence = sentences.Dequeue();

        voiceSound.clip = voice;
        voiceSound.Play();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            bipSound.Play();
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void EndDialogue() {
        GameManager.instance.gameState = GameManager.gameStates.Playing;
        dialogueUI.SetActive(false);

        // Active le mode cinema
        cine.QuitCineMode();
        bipSound.Stop();
    }
}
