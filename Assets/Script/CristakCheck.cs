using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristakCheck : MonoBehaviour
{
    public GameObject gm;
    private void Start()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GlobalSetting.cristal1++;
            gm.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
