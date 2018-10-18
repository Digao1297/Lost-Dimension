using UnityEngine;
using System.Collections;

public class Lingotes : Itens {

	public string receita;

	public Lingotes (string nome, int amount,string receita, Type _type) :base (nome,amount, _type){
		this.receita = receita;
	}
}
