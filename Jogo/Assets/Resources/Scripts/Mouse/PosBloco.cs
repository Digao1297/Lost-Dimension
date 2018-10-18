using UnityEngine;
using System.Collections;

public class PosBloco : MonoBehaviour {
    public GameObject personagem;
    
    public int tmpI;
    public GameObject terra;
    public GameObject pedra;
    public GameObject mouse;
    public RaycastHit2D hit2d;
    private PersonagemComandos personaC;
    private PlayerColetavel pc;
    private Inventario inv;

    void Start () {
        inv = FindObjectOfType<Inventario>();
        personaC = FindObjectOfType<PersonagemComandos>();
        pc = FindObjectOfType<PlayerColetavel>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 aux = new Vector3(2, 3);
        Vector2 sub = personagem.transform.position - transform.position;
        Vector2 positivo = ((personagem.transform.position - transform.position) * (-1));
        hit2d = Physics2D.Raycast(transform.position, transform.position, 0.7f);
       

        transform.position = new Vector3(Mathf.Floor(mouse.transform.position.x), Mathf.Floor(mouse.transform.position.y), 0);

        tmpI = personaC.selectSlot;

        if (Input.GetButtonDown("Fire1") && sub.x <= aux.x && sub.y <= aux.y && positivo.x <= aux.x && positivo.y <= aux.y)
        {
            if (!hit2d) {
               
               

                 if (inv.inventairo[tmpI].nomes == "terra" && inv.inventairo[tmpI].amount > 0)
                    {
                    foreach (var list in pc.listItens)
                    {
                        if (list.nomes!="terra")
                        {
                            if (inv.inventairo[tmpI].amount<1)
                            {
                                
                                pc.listItens.Add(new Itens ("terra",1));

                            }

                        }
                    }
                        inv.inventairo[tmpI].amount -= 1;

                        Instantiate(terra, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                
                    }
                     if (inv.inventairo[tmpI].nomes == "pedra" && inv.inventairo[tmpI].amount > 0)
                    {
                    foreach (var list in pc.listItens)
                    {
                        if (list.nomes != "pedra")
                        {
                            if (inv.inventairo[tmpI].amount < 1)
                            {

                                pc.listItens.Add(new Itens("pedra", 1));

                            }

                        }
                    }
                    inv.inventairo[tmpI].amount -= 1;

                    Instantiate(pedra, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

                }
            }

        }
    }
}
