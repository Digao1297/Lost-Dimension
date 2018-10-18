using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slot : MonoBehaviour {
   [HideInInspector]public int indexSlot;


    private Text tx;
    private Image ima;
    private Inventario inv;
    public UIControl uiCon;
    private PlayerColetavel pc;
    private PersonagemComandos personagem;

    void Start () {
        
        inv = FindObjectOfType<Inventario>();
        uiCon = FindObjectOfType<UIControl>();
        ima = transform.GetChild(0).GetComponent<Image>();
        tx = transform.GetChild(1).GetComponent<Text>();

        pc = FindObjectOfType<PlayerColetavel>();
        personagem = FindObjectOfType<PersonagemComandos>();


    }



    void Update() {
        
        if (inv.inventairo[indexSlot].nomes!=null)
        {
            ima.enabled = true;
            ima.sprite = inv.inventairo[indexSlot].icones;
        }
        else
        {
            ima.enabled = false;

        }
        if (inv.inventairo[indexSlot].type == Type.RECURSO|| inv.inventairo[indexSlot].type == Type.CONSUMIVEL)
        {
            if (inv.inventairo[indexSlot].amount>=1)
            {
                tx.enabled = true;
                tx.text = inv.inventairo[indexSlot].amount.ToString();

            }
        }else
        {
            tx.enabled = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (uiCon.mouseSlot.activeSelf&& !Inventario.isItem)
            {
                pc.DropItens(Inventario.item);
                DesableMouseSlot();

            }
        }
	}
    public void GetItemSlot()
    {
        if (inv.inventairo[indexSlot].nomes!=null)
        {
            Inventario.ima = uiCon.mouseSlot.GetComponent<Image>();
            Inventario.item = inv.inventairo[indexSlot];
            Inventario.index = indexSlot;
            if (Inventario.ima.sprite==null)
            {
                uiCon.mouseSlot.SetActive(true);
                Inventario.ima.sprite = inv.inventairo[indexSlot].icones;
                inv.inventairo[indexSlot] = new Itens();
            }
        }
    }
    public void DesableMouseSlot()
    {
        
        Inventario.ima.sprite = null;
        Inventario.item = new Itens();
        uiCon.mouseSlot.SetActive(false);
       
    }
    public void SetItemSlot()
    {
        if (inv.inventairo[indexSlot].nomes == null)
        {
            if (uiCon.mouseSlot.activeSelf)
            {
                inv.inventairo[indexSlot] = Inventario.item;
                DesableMouseSlot();
            }
        }
        else if (inv.inventairo[indexSlot].nomes != null)
        {
            if (uiCon.mouseSlot.activeSelf)
            {
                inv.inventairo[Inventario.index] = inv.inventairo[indexSlot];
                inv.inventairo[indexSlot] = Inventario.item;
                DesableMouseSlot();
            }
        }
    }
public void GetDcItemSlo()
    {
        Inventario.isItem = true;
        Itens item;
        if (inv.inventairo[indexSlot].nomes != null && inv.inventairo[indexSlot].type != Type.RECURSO&& inv.inventairo[indexSlot].type != Type.CONSTRUCOES)
        {
            item = inv.inventairo[indexSlot];
            uiCon.showDeItem.SetActive(Inventario.isItem);
            if (uiCon.showDeItem.activeSelf)
            {
                //uiCon.GetDcItem(item.nomes, item.durabilidade, item.dano);
                uiCon.GetDcItem(item);
            }

        }
        else if (inv.inventairo[indexSlot].nomes == null )
        {
            Inventario.isItem = false;
           // uiCon.GetDcItem("", 0, 0);
            uiCon.GetDcItem(null);
            uiCon.showDeItem.SetActive(false);

        }
    }
    public void DesablePanelDc()
    {
        Inventario.isItem = false;
        uiCon.showDeItem.SetActive(Inventario.isItem);

    }
}
