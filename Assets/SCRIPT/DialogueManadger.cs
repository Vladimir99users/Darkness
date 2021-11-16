using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManadger : MonoBehaviour
{
    public bool flagIs;
    public bool flagIstwice;
    public GameObject Panel;
    private Queue<string> sentences;
    public Text NameHero;
    public Text textNpc;
    // Start is called before the first frame update
    void Awake()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog _dialogue)
    {
        NameHero.text = _dialogue.name;
        sentences.Clear();
        foreach(string sentence in _dialogue.Sentence)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            if (flagIs)
            {
                EndDialog();
                return;
            }
            else
            {
                EndDialogPanel();
                return;
            }
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
       
    }

    IEnumerator TypeSentence( string centence)
    {
        textNpc.text = " ";
        foreach (char letter in centence.ToCharArray())
        {
            textNpc.text += letter;
            yield return null;
        }
    }

    public void EndDialog()
    {
        if (flagIstwice)
        {
            LoadOnLvl._instentaet.LoadScene(0);
        }
        else
        {
            LoadOnLvl._instentaet.LoadScene(2);
        }


    }

    public void EndDialogPanel()
    {
        Panel.SetActive(false);
    }
}
