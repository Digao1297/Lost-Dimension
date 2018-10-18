using UnityEngine;
using System.Collections;

public class Fogueira : MonoBehaviour {

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
        if (Vector2.Distance(transform.position, posPlayer.position) < 1f)
        {
            cc.GetPertoFo(true);

        }
        else
        {

            cc.GetPertoFo(false);
        }





    }
}
