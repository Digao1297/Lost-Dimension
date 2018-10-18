using UnityEngine;
using System.Collections;

public class Arma : Itens {
    public int dano;
	public int durabilidade;
    public string receita;

	public Arma( string nome, int durabilidade,string receita ,int dano, int amount, Type _type):base(nome, amount, _type) 
        
    {
        this.receita = receita;
		this.durabilidade = durabilidade;
        this.dano = dano;

    }
	
}
