using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dead : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject spawn1;
    private SpriteRenderer sr;
    public int Health=3;
    public Text cointHelth;
    private Color cr;
    public float time = 0f;
    public Behaviour move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cointHelth.text = "Health :" + Health.ToString();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Health <= 0)
        {
            cointHelth.text = "Ты умер";
            time += Time.deltaTime*0.5f;
            Debug.Log(time);
            move.enabled = false;
            if (time > 1)
            {
                cointHelth.text = "Health :" + 3;
                move.enabled = true;
                Health = 3;
                transform.position = spawn1.transform.position;
                time = 0f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            Health--;
            cointHelth.text = "Health :"+Health.ToString();
        }
    }
}
