using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public Animator _handEnemy;
    public static EnemyTrigger _instanteat;

    private void Start()
    {
        _handEnemy.Play("IdleEnemy");
        if (_instanteat) Destroy(_instanteat);
        _instanteat = this;
    }

 

    public void NumberHandOfAttack()
    {
        int number = Random.Range(0, 5);
        switch (number)
        {
            case 0:
                _handEnemy.Play("EnemyLeft");
                break;
            case 1:
                _handEnemy.Play("EnemyUp");
                break;
            case 2:
                _handEnemy.Play("EnemyRigth");
                break;
            case 3:
                _handEnemy.Play("EnemyDown");
                break;
            default:  _handEnemy.Play("IdleEnemy");
                break;

        }

        Debug.Log(number);
    }
}
