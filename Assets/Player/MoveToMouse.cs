﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    private Dictionary<bool, string> mode;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        mode.Add(false, "Love");
        mode.Add(true, "War");
        animator = GetComponent<Animator>();   

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPoint.z = 0;
        transform.position = worldPoint;

        bool love = false;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Republic")
                {
                    love = true;
                }
            }
        }
        //change on bool from component from Victor
        animator.SetBool("Love", love);
    }
}
