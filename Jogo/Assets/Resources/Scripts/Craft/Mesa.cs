﻿using UnityEngine;
using System.Collections;

public class Mesa : MonoBehaviour {
  
   
    public BoxCollider2D caixa;
    public Transform posPlayer;
    public CanvasCraft cc;
    void Start()
    {
        

        posPlayer = GameObject.Find("Jacklin").transform;
        cc = FindObjectOfType<CanvasCraft>();
    }
    void Update()
    {
        if (Vector2.Distance(transform.position,posPlayer.position)<1f)
        {
            cc.GetPertoM(true);
            print("Perto");
        }
        else
        {
            
            cc.GetPertoM(false);
        }

    }
}
