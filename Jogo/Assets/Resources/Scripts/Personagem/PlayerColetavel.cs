using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerColetavel : MonoBehaviour {

    public List<Itens> listItens = new List<Itens>();
    private Inventario inv;
    private DataBase db;
  
   

 


    public Transform localDrop;
	void Start () {
        inv = FindObjectOfType<Inventario>();
        db = FindObjectOfType<DataBase>();
        GetItemDb();
        
    }
	public void GetItemDb()
    {

        for (int i = 0; i < db.item.Count; i++)
        {
            listItens.Add(db.item[i]);
            for (int j = 0; j < inv.inventairo.Count; j++)
            {
                if (db.item[i].type == Type.RECURSO || db.item[i].type == Type.CONSUMIVEL)
                {
                    if (db.item[i] == inv.inventairo[j])
                    {
                        listItens.Remove(db.item[i]);
                    }
                }
            }
        }
    }
	
	void Update () {
     
    }

    public void DropItens(Itens item)
    {
        GameObject tmpDrop= Instantiate(item.itemDrop,localDrop.position, Quaternion.identity)as GameObject;
        Coletavel tmpClt = tmpDrop.GetComponent<Coletavel>();
        tmpClt.nomeItem = item.nomes;
        tmpClt.amount = item.amount;
        if (item.type==Type.RECURSO|| item.type == Type.CONSUMIVEL)
        {
            listItens.Add(item);
        }
    }


 void OnTriggerEnter2D(Collider2D other)
        
    {
        if (other.GetComponent<Coletavel>())
        {
            Coletavel coletavel = other.GetComponent<Coletavel>();
            ColletableItem(coletavel);
            Destroy(coletavel.gameObject);
            
        }
    }
    public void ColletableItem(Coletavel coletavel)
    {
        for (int l = 0; l < listItens.Count; l++)
        {
            foreach (var i in inv.inventairo)
            {
                if (listItens[l].nomes == i.nomes)
                {
                    listItens.Remove(listItens[l]);
                    break;
                }

            }
        }
        
          
        foreach (Itens item in inv.inventairo)
        {
            if (coletavel.nomeItem==item.nomes)
            {
                if (item.type==Type.RECURSO|| item.type == Type.CONSUMIVEL)
                {
                    item.amount += coletavel.amount;
                    Destroy(coletavel.gameObject);
                }
            }
        }
        for (int i = 0; i < listItens.Count; i++)
        {
            if (coletavel.nomeItem == listItens[i].nomes)
            {
                inv.AddItens(coletavel.nomeItem, coletavel.amount);
                Destroy(coletavel.gameObject);

                if (listItens[i].type == Type.RECURSO|| listItens[i].type == Type.CONSUMIVEL)
                {
                    listItens.Remove(listItens[i]);
                }
                break;
            }
        }

    }

}
