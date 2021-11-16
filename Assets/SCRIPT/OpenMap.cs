using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour
{
    public bool OpenIs = false;
    public GameObject PanelMap;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenIs = !OpenIs;
            OpenPanelMap();
        }
       
        
    }

    public void OpenPanelMap()
    {
        PanelMap.SetActive(OpenIs);
    }
}
