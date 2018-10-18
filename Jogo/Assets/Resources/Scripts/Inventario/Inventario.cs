using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class Inventario : MonoBehaviour {
    public List<Itens> inventairo = new List<Itens>();
    public List<Slot> slots = new List<Slot>();
    public static Itens item;
    public static Image ima;
    public static int index;
    public static bool isItem;
	public static Arma arma;
    
    private int contChild;
    private DataBase db;
    private PersonagemComandos perC;
    private PlayerColetavel pc;
    

    void Start () {
        //contChild = transform.childCount;
        contChild = slots.Count;
        db = FindObjectOfType(typeof(DataBase)) as DataBase;
        pc = FindObjectOfType<PlayerColetavel>();
        perC = FindObjectOfType<PersonagemComandos>();
        


        for (int i = 0; i < contChild; i++)
        {
            slots[i].indexSlot=i;
            inventairo.Add(new Itens());

        }
        AddItensSlot();
    }
	

	void Update () {
		Arma arma = inventairo[perC.selectSlot] as Arma;

		if (inventairo[perC.selectSlot].type == Type.PICARETA  && arma.durabilidade<=0)
        {
            inventairo[perC.selectSlot] = new Itens();
        }
		if (inventairo[perC.selectSlot].type == Type.PA && arma.durabilidade <= 0)
        {
           
            inventairo[perC.selectSlot] = new Itens();
        }
		if (inventairo[perC.selectSlot].type == Type.ESPADA && arma.durabilidade <= 0)
        {
            inventairo[perC.selectSlot] = new Itens();
        }
		if (inventairo[perC.selectSlot].type == Type.MACHADO && arma.durabilidade <= 0)
        {
            inventairo[perC.selectSlot] = new Itens();
        }
		for (int i = 0; i < inventairo.Count; i++) {
			if (inventairo[i].amount<=0)
			{
				Itens item = inventairo[i];
				inventairo[i] = new Itens();
				if (item.type!= Type.NULL)
				{
					pc.listItens.Add(item);
				}

			}
		}
        for (int list = 0; list < pc.listItens.Count; list++)
        {
            for (int list2 = 0; list2 < inventairo.Count; list2++)
            {
                if (inventairo[list2].nomes == pc.listItens[list].nomes)
                {
                    pc.listItens.Remove(pc.listItens[list]);
                }
            }
            
        }
     


    }
  

    public void AddItens(string nome,int amount)
    {
       
        for (int i = 0; i < inventairo.Count; i++)
        {
            if (inventairo[i].nomes == null)
            {
                for (int j = 0; j < db.item.Count; j++)
                {
                    if (db.item[j].nomes == nome)
                    {
                       
                    
                        inventairo[i] = db.item[j].Clone() as Itens;
                      
                    }
                    if (inventairo[i].type==Type.RECURSO|| inventairo[i].type == Type.CONSUMIVEL)
                    {
                        inventairo[i].amount = amount;
                       
                    }
                    else if (inventairo[i].type == Type.PICARETA
                        || inventairo[i].type == Type.PA 
                        || inventairo[i].type == Type.ESPADA
                        || inventairo[i].type == Type.MACHADO)
                    {
                        inventairo[i].amount = 1;
                    }
                }
                break;
            }
        }
       
    
    }
    public void AddItensB(string nome, int amount)
    {

        for (int i = 0; i < inventairo.Count; i++)
        {
            if (nome==inventairo[i].nomes)
            {
                if (inventairo[i].type == Type.RECURSO || inventairo[i].type == Type.CONSUMIVEL)
                {
                    inventairo[i].amount += amount;

                    break;

                }


            } else if (inventairo[i].nomes == null)
            {
                for (int j = 0; j < db.item.Count; j++)
                {
                    if (db.item[j].nomes == nome)
                    {


                        inventairo[i] = db.item[j].Clone() as Itens;

                    }
                    if (inventairo[i].type == Type.RECURSO || inventairo[i].type == Type.CONSUMIVEL)
                    {
                        inventairo[i].amount = amount;

                    }
                    else if (inventairo[i].type == Type.PICARETA
                        || inventairo[i].type == Type.PA
                        || inventairo[i].type == Type.ESPADA
                        || inventairo[i].type == Type.MACHADO)
                    {
                        inventairo[i].amount = 1;
                    }
                }
                break;
            }
            
        }


    }
    private void AddItensSlot()
    {
       


    }

}
