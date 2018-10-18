using UnityEngine;
using System.Collections;

public class Fauna : MonoBehaviour {

    public int durabilidade;
    public float raridade;
    public GameObject[] drops;
    public GameObject[] drop;

    public void GetDrop()
    {
        for (int i = 0; i < drops.Length; i++)
        {
            Instantiate(drop[0], drops[i].transform.position, Quaternion.identity);
            Instantiate(drop[1], drops[i].transform.position, Quaternion.identity);
        }
     
     


    }
}
