using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManadger : MonoBehaviour
{
    public int ValueBrother;
    public bool DamageIs ;
    public bool BrotherIs;
    public float[] Damage;
    public float DamageStalactit = -15f;
    public static GameManadger _instanteat;
    public Animator MainCamera;
    public Animator PanelWinPlayer;
    public GameObject PanelWinDark;
    public GameObject PanelLoseDark;





    private void Start()
    {
        PanelWinDark.SetActive(false);
        PanelLoseDark.SetActive(false);
        if (_instanteat) Destroy(_instanteat);
        _instanteat = this;
        DamageIs = false;
        BrotherIs = false;
        ValueBrother = 0;
    }

    public void DamageHero()
    {
        if (!DamageIs)
        {
            DamageIs = true;
            ScrollManadger._instanteat.SetUpdateLive(Damage[ValueBrother]);
            if(ScrollManadger._instanteat.getUpdateLive() <= 0)
            {
                StartCoroutine(DeathPlayerWating());
            }
            StartCoroutine(WaitingDamage());
        }
    }


    public void DamageHeroStalactit()
    {
        Debug.Log("1");
        if (!DamageIs)
        {
            Debug.Log("2");
            DamageIs = true;
            ScrollManadger._instanteat.SetUpdateLive(DamageStalactit);
            AudioManadger._instanteat.PlaySoundTrigger(9);
            if (ScrollManadger._instanteat.getUpdateLive() == 0)
            {
                StartCoroutine(DeathPlayerWating());
            }
            StartCoroutine(WaitingDamage());
            Debug.Log("3");
        }
    }



    IEnumerator DeathPlayerWating()
    {
        PanelWinDark.SetActive(true);
       // MainCamera.Play("DarkWin");
        yield return new WaitForSeconds(1f);
       
    }

 
    IEnumerator WaitingDamage()
    {
        yield return new WaitForSeconds(3f);
        DamageIs = false;
    }

    public void GetUpdateValueBrother()
    {
        if (!BrotherIs)
        {
            

            BrotherIs = true;
            ValueBrother++;

            if (ValueBrother == 1)
            {
                 AudioManadger._instanteat.StartGameSound();
                AnimatorController._instanteat.StartGameAnimator();
            }
            if(ValueBrother == 2 || ValueBrother == 6)
            {
                AudioManadger._instanteat.PlaySoundTrigger(2);
            }
            if (ValueBrother == 3 || ValueBrother == 9)
            {
                AudioManadger._instanteat.PlaySoundTrigger(4);
            }
            if (ValueBrother == 5 || ValueBrother == 8)
            {
                AudioManadger._instanteat.PlaySoundTrigger(5);
            }
            if (ValueBrother == 4 || ValueBrother == 7)
            {
                AudioManadger._instanteat.PlaySoundTrigger(6);
            }


            ScrollManadger._instanteat.SetUpdateLive();
            ScrollManadger._instanteat.UpdateTextBrother(ValueBrother);
            ScrollManadger._instanteat.SetUpdateTimer();
            if (ValueBrother == 10)
            {
                StartCoroutine(LoadLevelthertin());
            }
            StartCoroutine(Waitingbrother());
        }
    }


    IEnumerator LoadLevelthertin()
    {
        PanelLoseDark.SetActive(true);
       // PanelWinPlayer.Play("Dark_lose");
        yield return new WaitForSeconds(3f);
        LoadOnLvl._instentaet.LoadScene(3);
    }

    IEnumerator Waitingbrother()
    {
        yield return new WaitForSeconds(1f);
        BrotherIs = false;
      
    }

    public int valueBrotherGet()
    {
        return ValueBrother;
    }


    public void WinGame()
    {
        if(ValueBrother >= 7)
        {
            StartCoroutine(LoadLevelthertin());

        }
        else
        {
            PanelWinDark.SetActive(true);
           // MainCamera.Play("DarkWin");
        }
    }

}
