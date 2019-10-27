using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checpointPlatworm : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode rewindButton;
    bool isRewind;
    List<Vector3> positionList;
    List<Quaternion> posRotate;
    Rigidbody2D rb;
    public Behaviour bh;
    //private bool flag = true;


    public float timeRewind;

    void Start()
    {
        positionList = new List<Vector3>();
        posRotate = new List<Quaternion>();
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("1");
        //if (rb.bodyType == RigidbodyType2D.Static)
        //    flag = false;
    }
    void Update()
    {
        if (isRewind)
        {
            bh.enabled = false;
            if (positionList.Count > 0)
            {
            
                int LastPosittion = positionList.Count - 1;
                transform.position = Vector2.MoveTowards(positionList[LastPosittion], positionList[LastPosittion], 10 * Time.deltaTime);
                transform.rotation = posRotate[LastPosittion];
                positionList.RemoveAt(LastPosittion);
                posRotate.RemoveAt(LastPosittion);
                Debug.Log("2");
                rb.bodyType = RigidbodyType2D.Static;

            }
        }
        else
        {
            if (positionList.Count >= timeRewind * (1 / Time.deltaTime))
                positionList.RemoveAt(0);

            positionList.Add(transform.position);
            posRotate.Add(transform.rotation);

        }

        if (Input.GetKeyDown(rewindButton))
        {
            bh.enabled = false;
            isRewind = true;
            Debug.Log("3");

        }
        if (Input.GetKeyUp(rewindButton))
        {
            bh.enabled = true;
            isRewind = false;
            GlobalSetting.flag = true;
            Debug.Log("4");
            rb.bodyType = RigidbodyType2D.Static;    
        }
    }
}