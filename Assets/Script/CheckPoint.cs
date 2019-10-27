using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode rewindButton;
    bool isRewind;
    List<Vector3> positionList;
    List<Quaternion> posRotate;
    Rigidbody2D rb;
    private bool flag=true;
    public Behaviour fall;


    public float timeRewind;

    void Start()
    {
        positionList = new List<Vector3>();
        posRotate = new List<Quaternion>();
        rb = GetComponent<Rigidbody2D>();
        if (rb.bodyType == RigidbodyType2D.Static)
            flag = false;
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
                if(fall)
                    fall.enabled = false;
                int LastPosittion = positionList.Count - 1;
                transform.position = Vector2.MoveTowards(positionList[LastPosittion], positionList[LastPosittion], 10 * Time.deltaTime);
                transform.rotation = posRotate[LastPosittion];
                positionList.RemoveAt(LastPosittion);
                posRotate.RemoveAt(LastPosittion);
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
            isRewind = true;
            
        }
        if (Input.GetKeyUp(rewindButton))
        {
            isRewind = false;
            if (flag)
                rb.bodyType = RigidbodyType2D.Dynamic;
            else
            {
                rb.bodyType = RigidbodyType2D.Static;
                GlobalSetting.flag = true;
            }
            if (fall)
                fall.enabled = true;
        }
    }
}