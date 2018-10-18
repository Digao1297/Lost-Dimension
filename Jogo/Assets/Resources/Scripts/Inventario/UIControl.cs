using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {
    public GameObject mouseSlot;
    public GameObject showDeItem;
    
    public Text nameItens;
    public Text atributos;
    public Canvas canvas;

	
	void Start () {
        
	}

	void Update () {
        if (mouseSlot.activeSelf)
        {
           
                MouseSlot();
       }
        if (showDeItem.activeSelf)
        {
            ShowDeItem();
        }
    }
    public void MouseSlot()
    {
        Vector2 tmpPos = (Input.mousePosition-canvas.transform.localPosition);
        mouseSlot.GetComponent<RectTransform>().localPosition = tmpPos;
        showDeItem.SetActive(false);
    }
    private void ShowDeItem()
    {
        Vector2 tmpPos = (Input.mousePosition - canvas.transform.localPosition);
        showDeItem.GetComponent<RectTransform>().localPosition = new Vector2(tmpPos.x+90,tmpPos.y-80);

    }
    /*public void GetDcItem(string nomeItem, int durabilidade, int dano)
    {
        this.nameItens.text = nomeItem;
        this.atributos.text = "Dano: " + dano.ToString() + "\n" + "Durabilidade: " + durabilidade.ToString();
    }*/
    public void GetDcItem(Itens item)
    {
        Arma arma = item as Arma;
        Comida comida = item as Comida;



        if (item is Arma)
        {
            this.nameItens.text = arma.nomes;
            this.atributos.text = "Dano: " + arma.dano.ToString() + "\n" + "Durabilidade: " + arma.durabilidade.ToString();
        }
        if (item is Comida)
        {
            this.nameItens.text = item.nomes;
            this.atributos.text = "Saciedade: " + comida.saciedade.ToString()+"\n"+"Regeneração: "+comida.vida.ToString();
        }

    }
}
