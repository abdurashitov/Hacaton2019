using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dead : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public int Health=3;
    public Text cointHelth;
    private Color cr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cointHelth.text = Health.ToString();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Health == 0)
        //{
        //    cr = sr.color;
        //    for (int i = 255;  i>= 0; i++)
        //    {  
        //        cr.a--;
        //        sr.color = cr;
        //    }
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            Health--;
            cointHelth.text = Health.ToString();
        }
    }
}
