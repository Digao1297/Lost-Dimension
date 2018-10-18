using UnityEngine;
using System.Collections;
using System;
public enum Type
{
    NULL,CONSUMIVEL,RECURSO,ESPADA,PICARETA,MACHADO,PA,CONSTRUCOES
}
[System.Serializable]
public class Itens : ICloneable{
    public string nomes;
    public int amount;
 
 
    public GameObject itemDrop;
   
    public Sprite icones;
    public Sprite iconsNeutro;
    public Type type;

    public Itens(string nome, Type _type)
    {
        this.nomes = nome;
        this.type = _type;
        
        this.itemDrop = Resources.Load<GameObject>("Prefrabs/Mapa/Dropado/"+nomes);
        this.icones = Resources.Load<Sprite>("Icones/" + nomes);
        this.iconsNeutro = Resources.Load<Sprite>("Icones/IconesNeutro/" + nome);

    }

	public Itens(string nome, int amount)
	{
		this.nomes = nome;
		this.amount = amount;

		this.itemDrop = Resources.Load<GameObject>("Prefrabs/Mapa/Dropado/"+nomes);
		this.icones = Resources.Load<Sprite>("Icones/" + nomes);
		this.iconsNeutro = Resources.Load<Sprite>("Icones/IconesNeutro/" + nome);

	}

	public Itens(string nome, int amount, Type _type)
	{
		this.nomes = nome;

		this.amount = amount;
		this.type = _type;
		this.itemDrop = Resources.Load<GameObject>("Prefrabs/Mapa/Dropado/"+nomes);
		this.icones = Resources.Load<Sprite>("Icones/" + nomes);
		this.iconsNeutro = Resources.Load<Sprite>("Icones/IconesNeutro/" + nome);

	}
    public Itens()
    {

    }
	
	public object Clone()
    {
        return this.MemberwiseClone();
    }
}
