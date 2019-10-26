using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode rewindButton;
    bool isRewind;
    List<Vector3> positionList;
    Rigidbody2D rb;


    public float timeRewind;

    void Start()
    {
        positionList = new List<Vector3>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isRewind)
        {
            if (positionList.Count > 0)
            {
                int LastPosittion = positionList.Count - 1;
                transform.position = Vector2.MoveTowards(positionList[LastPosittion], positionList[LastPosittion], 10 * Time.deltaTime);
                // positionList[LastPosittion];
                positionList.RemoveAt(LastPosittion);
                rb.bodyType = RigidbodyType2D.Kinematic;
            }
        }
        else
        {
            if (positionList.Count >= timeRewind * (1 / Time.deltaTime))
                positionList.RemoveAt(0);

            positionList.Add(transform.position);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        if (Input.GetKeyDown(rewindButton))
        {
            isRewind = true;
            
        }
        if (Input.GetKeyUp(rewindButton))
        {
            isRewind = false;
        }
    }
}