using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
   // public Animator Am_MainCamera;
    public Animator Am_Hand_death;

    public static AnimatorController _instanteat;

    public void Start()
    {
        if (_instanteat) Destroy(_instanteat);
        _instanteat = this;

    }

    public void StartGameAnimator()
    {
        Am_Hand_death.Play("Hand_Death_Start");
    }

    public void Animation_on_Gameobject(int number)
    {
        Am_Hand_death.Play(number);
    }
}
