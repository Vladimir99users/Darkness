using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManadger : MonoBehaviour
{
    public Text NumberBrother;
    public static ScrollManadger _instanteat;
    public float LiveHero;
    public float TimerLvl;
    public Slider LiveScroll;
    public Slider TimerScroll;

    private void Start()
    {
        if (_instanteat) Destroy(_instanteat);
        _instanteat = this;

        TimerLvl = TimerScroll.value;
        LiveHero = LiveScroll.value;
        StartCoroutine(timerSecond());   
    }


    
    public  IEnumerator timerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            TimerScroll.value -= 1f;
            if (TimerScroll.value == 0)
            {
                GameManadger._instanteat.WinGame();
            }

        }
    }


    public void SetUpdateTimer()
    {
        TimerScroll.value = TimerLvl;
    }

    public void SetUpdateLive(float eventDam_and_hil)
    {
        LiveScroll.value += eventDam_and_hil;
    }

    public void SetUpdateLive()
    {
        LiveScroll.value = LiveScroll.maxValue;
    }

    public float getUpdateTimer()
    {
        return TimerScroll.value;
    }

    public float getUpdateLive()
    {
        return LiveScroll.value;
    }

    public void UpdateTextBrother(int col)
    {
        NumberBrother.text = col.ToString("N0") + " / " + " 10 ";
    }
    // public void 
}
