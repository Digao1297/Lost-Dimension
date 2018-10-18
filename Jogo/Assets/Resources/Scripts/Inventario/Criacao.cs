using UnityEngine;
using System.Collections;

public class Criacao : Itens {
	public int vida;
    public string receita;


	public Criacao( string nome, int vida, string receita, int amount, Type _type):base(nome, amount, _type) {
		this.vida = vida;
        this.receita = receita;
	}
}
