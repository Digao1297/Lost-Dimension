using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour {
    public string nome;
    public float raridade;
    public int vida;
    public int dano;
    public float velocidadeAT;
    public float VelocidadeM;

    public GameObject[] drops;
    public GameObject drop;

    public Animal(string nome,float raridade, int vida,int dano,float velocidadeAT, float velocidadeM)
    {
        this.nome = nome;
        this.raridade = raridade;
        this.vida = vida;
        this.dano = dano;
        this.velocidadeAT = velocidadeAT;
        this.VelocidadeM = velocidadeM;

    }

    public void GetDrop()
    {
        Instantiate(drop, drops[0].transform.position, Quaternion.identity);
        Instantiate(drop, drops[1].transform.position, Quaternion.identity);
        Instantiate(drop, drops[2].transform.position, Quaternion.identity);


    }

  
}
