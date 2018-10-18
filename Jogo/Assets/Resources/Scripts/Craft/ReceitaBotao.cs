using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ReceitaBotao : MonoBehaviour {
    public string nome;
    public List<Itens> receita;
    public TextAsset xml;
    private Inventario inv;
    private DataBase db;
    public Text nomeTxt,recTxt;
    public GameObject showCraft;
    public Canvas canvas;
    public PlayerColetavel pc;

	void Start () {
        inv = FindObjectOfType<Inventario>();
        db = FindObjectOfType<DataBase>();
        receita = LerXml.Receitas(xml)[nome];
        pc = FindObjectOfType<PlayerColetavel>();
    }
    void Update()
    {
        if (showCraft.activeSelf)
        {
            ShowdeCraft();
        }
    }

    private void ShowdeCraft()
    {
        Vector2 tmpPos = (Input.mousePosition - canvas.transform.localPosition);
        showCraft.GetComponent<RectTransform>().localPosition = new Vector2(tmpPos.x + 90, tmpPos.y - 80);

    }

    public void GetDcCraft()
    {

        foreach (var d in db.item)
        {
            if (d.type == Type.CONSTRUCOES)
            {
                Criacao criacao = d as Criacao;
                if (criacao != null && criacao.receita == nome)
                {
                    nomeTxt.text = d.nomes;
                    break;
                }
            }
            if (d.type == Type.CONSUMIVEL)
            {
                Comida comida = d as Comida;
                if (comida != null && comida.receita == nome)
                {
                    nomeTxt.text = d.nomes;
                    break;
                }
            }
            if (d.type == Type.RECURSO)
            {
                Lingotes lingote = d as Lingotes;
                if (lingote != null && lingote.receita == nome)
                {
                    nomeTxt.text = d.nomes;
                    break;
                }
            }
            if (d.type == Type.ESPADA || d.type == Type.MACHADO || d.type == Type.PA || d.type == Type.PICARETA)
            {
                Arma arma = d as Arma;
                if (arma != null && arma.receita == nome)
                {
                    nomeTxt.text = d.nomes;
                    break;
                }
            }
        }
        string tmpRec="";
        foreach (var r in receita)
        {
            tmpRec += r.amount+ " " + r.nomes+ " + ";
        }
        recTxt.text = tmpRec;
        showCraft.SetActive(true);
    } 

    public void DisableCraft()
    {
        showCraft.SetActive(false);

    }
	public void CriarItem()
    {
        
        switch (receita.Count)
        {
            case 1:
                foreach (var i in inv.inventairo)
                {
                    if (i.nomes==receita[0].nomes&&i.amount>=receita[0].amount)
                    {
                        foreach (var d in db.item)
                        {
                            if (d.type==Type.CONSTRUCOES)
                            {
                                Criacao criacao = d as Criacao;
                                if (criacao!=null&&criacao.receita==nome)
                                {
                                    i.amount -= receita[0].amount;
                                    inv.AddItens(d.nomes, 1);
                                    break;
                                }
                            }
                            if (d.type==Type.CONSUMIVEL)
                            {
                                Comida comida = d as Comida;
                                if (comida!=null&&comida.receita==nome)
                                {
                                    i.amount -= receita[0].amount;
                                    inv.AddItensB(d.nomes, 1);

                                    break;
                                }
                            }
                            if (d.type==Type.RECURSO)
                            {
                                Lingotes lingote = d as Lingotes;
                                if (lingote!=null&&lingote.receita==nome)
                                {
                                    i.amount -= receita[0].amount;
                                    inv.AddItensB(d.nomes, 1);
                                    break;
                                }
                            }
                            if (d.type==Type.ESPADA|| d.type == Type.MACHADO || d.type == Type.PA || d.type == Type.PICARETA)
                            {
                                Arma arma = d as Arma;
                                if (arma!=null&&arma.receita==nome)
                                {
                                    i.amount -= receita[0].amount;
                                    inv.AddItens(d.nomes, 1);
                                    break;
                                }
                            }  
                        }
                    }
                }
                break;
            case 2:
                foreach (var i in inv.inventairo)
                {
                    if (i.nomes == receita[0].nomes && i.amount >= receita[0].amount)
                    {
                        foreach (var r in inv.inventairo)
                        {
                            if (r.nomes == receita[1].nomes && r.amount >= receita[1].amount)
                            {
                                foreach (var d in db.item)
                                {
                                    if (d.type == Type.CONSTRUCOES)
                                    {
                                        Criacao criacao = d as Criacao;
                                        if (criacao != null && criacao.receita == nome)
                                        {
                                            i.amount -= receita[0].amount;
                                            r.amount -= receita[1].amount;
                                            inv.AddItens(d.nomes, 1);
                                           
                                            break;
                                        }
                                    }
                                    if (d.type == Type.CONSUMIVEL)
                                    {
                                        Comida comida = d as Comida;
                                        if (comida != null && comida.receita == nome)
                                        {
                                            i.amount -= receita[0].amount;
                                            r.amount -= receita[1].amount;
                                            inv.AddItensB(d.nomes, 1);
                                            break;
                                        }
                                    }
                                    if (d.type == Type.RECURSO)
                                    {
                                        Lingotes lingote = d as Lingotes;
                                        if (lingote != null && lingote.receita == nome)
                                        {
                                            i.amount -= receita[0].amount;
                                            r.amount -= receita[1].amount;
                                            inv.AddItensB(d.nomes, 1);
                                            break;
                                        }
                                    }
                                    if (d.type == Type.ESPADA || d.type == Type.MACHADO || d.type == Type.PA || d.type == Type.PICARETA)
                                    {
                                        Arma arma = d as Arma;
                                        if (arma != null && arma.receita == nome)
                                        {
                                            i.amount -= receita[0].amount;
                                            r.amount -= receita[1].amount;
                                            inv.AddItens(d.nomes, 1);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            case 3:
                foreach (var i in inv.inventairo)
                {
                    if (i.nomes==receita[0].nomes&&i.amount>=receita[0].amount)
                    {
                        foreach (var r in inv.inventairo)
                        {
                            if (r.nomes == receita[1].nomes && r.amount >= receita[1].amount)
                            {
                                foreach (var t in inv.inventairo)
                                {
                                    if (t.nomes == receita[2].nomes && t.amount >= receita[2].amount)
                                    {
                                        foreach (var d in db.item)
                                        {
                                            if (d.type == Type.CONSTRUCOES)
                                            {
                                                Criacao criacao = d as Criacao;
                                                if (criacao != null && criacao.receita == nome)
                                                {
                                                    i.amount -= receita[0].amount;
                                                    r.amount -= receita[1].amount;
                                                    t.amount -= receita[2].amount;
                                                    inv.AddItens(d.nomes, 1);
                                                    break;
                                                }
                                            }
                                            if (d.type == Type.CONSUMIVEL)
                                            {
                                                Comida comida = d as Comida;
                                                if (comida != null && comida.receita == nome)
                                                {
                                                    i.amount -= receita[0].amount;
                                                    r.amount -= receita[1].amount;
                                                    t.amount -= receita[2].amount;
                                                    inv.AddItensB(d.nomes, 1);
                                                    break;
                                                }
                                            }
                                            if (d.type == Type.RECURSO)
                                            {
                                                Lingotes lingote = d as Lingotes;
                                                if (lingote != null && lingote.receita == nome)
                                                {
                                                    i.amount -= receita[0].amount;
                                                    r.amount -= receita[1].amount;
                                                    t.amount -= receita[2].amount;
                                                    inv.AddItensB(d.nomes, 1);
                                                    break;
                                                }
                                            }
                                            if (d.type == Type.ESPADA || d.type == Type.MACHADO || d.type == Type.PA || d.type == Type.PICARETA)
                                            {
                                                Arma arma = d as Arma;
                                                if (arma != null && arma.receita == nome)
                                                {
                                                    i.amount -= receita[0].amount;
                                                    r.amount -= receita[1].amount;
                                                    t.amount -= receita[2].amount;
                                                    inv.AddItens(d.nomes, 1);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                break;

        }

    }
}
