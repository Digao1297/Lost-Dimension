using UnityEngine;
using System.Collections;

public class Grama : MonoBehaviour {
    public RaycastHit2D[] ray;

    public bool GetFauna()
    {
        ray = Physics2D.RaycastAll(transform.position, transform.up, transform.position.y+10);
        foreach (var r in ray)
        {
            if (r.collider.tag.StartsWith("fau"))
            {
                return true;
                
            }
           
    
        }
        return false;

    }
}
