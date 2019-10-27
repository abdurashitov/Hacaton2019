using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatworm : MonoBehaviour
{
    public float speedOfPlatform = 0f;
    Rigidbody2D rb;
    private float time = 0f;
    public float time1 = 1f;
    public bool flag2 = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vector3 move = new Vector3(rb.velocity.x, rb.velocity.y-5, 0f);
        if (collision.gameObject.tag == "Player")
        {
            GlobalSetting.flag = false;
            flag2 = false;
        }
    }
    private void Update()
    {
        if (!flag2)
        {
;
            // transform.Translate(0, speedOfPlatform * Time.deltaTime, 0);
            time += Time.deltaTime * 1f;
            Debug.Log("cerf");
            if (time > time1)
            {
                Debug.Log("cerf");
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 3;
                time = 0f;

            }
        }
    }
}