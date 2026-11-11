using System;
using Unity.VisualScripting;
using UnityEngine;

public class Teks : MonoBehaviour
{
    Animator anim;

    GameObject target;

    public static bool onDrop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("PlayerDropTeksPosition");
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Debug.Log("Mouse0 key pressed");
        //    anim.Play("TeksRotation");
        //}
        //if(onDrop)
        //{
        //}
        Debug.Log("onDrop: " + onDrop);
        if (target != null && onDrop)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.transform.position,
                1f * Time.deltaTime
            );
        }

        if(transform.position == target.transform.position)
        {
            onDrop = false;
        }


        //if (transform.position == playDropTeksPosition.transform.position)
        //{
        //    onDrop = false;
        //}
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse0 key pressed");
        anim.Play("TeksRotation");
    }
}
