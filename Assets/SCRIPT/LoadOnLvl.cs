using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnLvl : MonoBehaviour
{
    public static LoadOnLvl _instentaet;

    private void Start()
    {
        if (_instentaet) Destroy(_instentaet);
        _instentaet = this;
    }

    public void LoadScene(int number)
    {
        SceneManager.LoadScene(number);
    }
}
