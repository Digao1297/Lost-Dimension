using UnityEngine;
using System.Collections;

public class Comida : Itens {
	public int vida;
	public int saciedade;
    public string receita;

	public Comida( string nome, int vida, int saciedade, int amount, Type _type):base(nome, amount, _type) {
		this.vida = vida;
		this.saciedade = saciedade;

    }
    public Comida(string nome, int vida, int saciedade,string receita, int amount, Type _type) : base(nome, amount, _type)
    {
        this.receita = receita;
        this.vida = vida;
        this.saciedade = saciedade;

    }

}