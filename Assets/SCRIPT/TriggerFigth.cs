using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFigth : MonoBehaviour
{
    public bool FitghIs = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FitghIs && collision.gameObject.tag == "Player")
        {
            FitghIs = false;
            AudioManadger._instanteat.StartGameSound();
            EnemyTrigger._instanteat.NumberHandOfAttack();
            Camera2DFollow._instanteat.StopCamera();
            StartCoroutine(WiatingOffitgh());
        }
    }
    IEnumerator WiatingOffitgh()
    {
        yield return new WaitForSeconds(5f);
        FitghIs = true;
        Camera2DFollow._instanteat.StartCamera();
    }
}
