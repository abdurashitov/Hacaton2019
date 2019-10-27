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
    private float time = 0f;
    private float time1 = 0f;
    public Behaviour move;
    public Image damageImage;
    public Image[] health;
    public float flashSpeed = 2f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    bool damaged=false;
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
          
            move.enabled = false;
            if (time > 1)
            {
                cointHelth.text = "Health :" + 3;
                move.enabled = true;
                Health = 3;
                transform.position = spawn1.transform.position;
                time = 0f;
                health[0].enabled = true;
                health[1].enabled = true;
                health[2].enabled = true;

            }
        }
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            if (time1 == 0)
            {
                if (Health > 0)
                    health[Health-1].enabled = false;
                Health--;
               
                cointHelth.text = "Health :" + Health.ToString();
               if(transform.rotation.y<0)
                    rb.AddForce(new Vector2(-5f,5), ForceMode2D.Impulse);
               else
                    rb.AddForce(new Vector2(5, 5), ForceMode2D.Impulse);
                damaged = true;
            }
          
            time1 += Time.deltaTime * 1f;
            if (time1 == 1)
            {
                time1 = 0;
            }
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        time1 = 0;
    }
}
