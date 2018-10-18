using UnityEngine;
using System.Collections;

public class Coletavel : MonoBehaviour {
    public string nomeItem;
    public int amount;

	public Coletavel(string nome, int amount) {
        this.nomeItem = nome;
        this.amount = amount;
    }

    public Coletavel()
    {
        
    }
}
