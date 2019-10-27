using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristakCheck : MonoBehaviour
{
    public Behaviour cristal;
    public GameObject gm;
    private void Start()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cristal.enabled = false;
            GlobalSetting.cristal1++;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
