using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class DataBase : MonoBehaviour {
    public List<Itens> item = new List<Itens>();
  
	public TextAsset xml;
   
	
	
	void Start () {

       
       
    
	

		foreach (var it in LerXml.Coleta(xml))
		{
			Itens i = it as Itens;
			item.Add(i);
		}
     
        foreach (var it in LerXml.Comida(xml))
        {
            Itens i = it as Itens;
            item.Add(i);
        }
		foreach (var it in LerXml.ComidaAssada(xml))
		{
			Itens i = it as Itens;
			item.Add(i);
		}
		foreach (var it in LerXml.Ferramenta(xml))
		{
			Itens i = it as Itens;
			item.Add(i);
		}

		foreach (var it in LerXml.Criacao(xml))
		{
			Itens i = it as Itens;
			item.Add(i);
		}
		foreach (var it in LerXml.Lingote(xml))
		{
			Itens i = it as Itens;
			item.Add(i);
		}

    }
	
	
}
