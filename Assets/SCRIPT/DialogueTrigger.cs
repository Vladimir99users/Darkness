using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialog _dialog;

    private void Start()
    {
        TriggerDialog();
    }

    public void TriggerDialog()
    {
        FindObjectOfType<DialogueManadger>().StartDialog(_dialog);
      //  DIalogManadger._instante.StartDialog(_dialog);
    }
}
