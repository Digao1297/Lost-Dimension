using UnityEngine;
using System.Collections;

public class Construcao : MonoBehaviour {
    public GameObject start;
    public GameObject end;
    public GameObject mouse;
    public GameObject personagem;
    public GameObject mesa, fornalha,fogueira;
    public int tmpI;
    public GameObject[] cons;
    private PersonagemComandos personaC;
    private Inventario inv;

    void Start () {
        inv = FindObjectOfType<Inventario>();
        personaC = FindObjectOfType<PersonagemComandos>();
        mesa.SetActive(false);
        fornalha.SetActive(false);
    }
	
	
	void Update () {
        tmpI = personaC.selectSlot;

        Vector2 aux = new Vector3(2, 3);
        Vector2 sub = personagem.transform.position - transform.position;
        Vector2 positivo = ((personagem.transform.position - transform.position) * (-1));

        

        transform.position = new Vector3(Mathf.Floor(mouse.transform.position.x), Mathf.Floor(mouse.transform.position.y), 0);

        RaycastHit2D startR = Physics2D.Linecast(start.transform.position, new Vector2(start.transform.position.x, start.transform.position.y + 0.001f));
        RaycastHit2D endR = Physics2D.Linecast(start.transform.position, new Vector2(start.transform.position.x, start.transform.position.y + 0.001f));
        RaycastHit2D startE = Physics2D.Linecast(start.transform.position, new Vector2(start.transform.position.x, start.transform.position.y + 0.001f));
        RaycastHit2D endE = Physics2D.Linecast(start.transform.position, new Vector2(start.transform.position.x, start.transform.position.y + 0.001f));

       
        if (startR == true && endR == true&& startR.collider.tag.StartsWith("min") && endR.collider.tag.StartsWith("min"))
        {
            if (inv.inventairo[tmpI]!=null&&inv.inventairo[tmpI].type == Type.CONSTRUCOES && inv.inventairo[tmpI].nomes == "mesa")
            {

                mesa.SetActive(true);
                fornalha.SetActive(false);

            }
            else
            {
                mesa.SetActive(false);
               
            }
            if (inv.inventairo[tmpI] != null && inv.inventairo[tmpI].type == Type.CONSTRUCOES && inv.inventairo[tmpI].nomes == "fornalha")
            {

                mesa.SetActive(false);
                fornalha.SetActive(true);

            }

            else
            {
               
                fornalha.SetActive(false);
            }
            if (inv.inventairo[tmpI] != null && inv.inventairo[tmpI].type == Type.CONSTRUCOES && inv.inventairo[tmpI].nomes == "Fogueira")
            {

                mesa.SetActive(false);
                fornalha.SetActive(false);
                fogueira.SetActive(true);
            }

            else
            {

                fogueira.SetActive(false);
            }
        }
        else
        {

            mesa.SetActive(false);
            fornalha.SetActive(false);
            fogueira.SetActive(false);
        }

        if (Input.GetButtonDown("Fire1") && sub.x <= aux.x && sub.y <= aux.y && positivo.x <= aux.x && positivo.y <= aux.y)
        {
            if (startR==true&&endR==true &&  startR.collider.tag.StartsWith("min")&& endR.collider.tag.StartsWith("min"))
            {
                if (inv.inventairo[tmpI] != null && inv.inventairo[tmpI].type==Type.CONSTRUCOES&& inv.inventairo[tmpI].nomes=="mesa")
                {
                    inv.inventairo[tmpI].amount -= 1;
                    Instantiate(cons[0], mesa.transform.position, Quaternion.identity);
                    mesa.SetActive(true);
                   
                }
                if (inv.inventairo[tmpI] != null && inv.inventairo[tmpI].type == Type.CONSTRUCOES && inv.inventairo[tmpI].nomes == "fornalha")
                {
                    inv.inventairo[tmpI].amount -= 1;
                    Instantiate(cons[1], fornalha.transform.position, Quaternion.identity);
                    fornalha.SetActive(true);

                }
                if (inv.inventairo[tmpI] != null && inv.inventairo[tmpI].type == Type.CONSTRUCOES && inv.inventairo[tmpI].nomes == "Fogueira")
                {
                    inv.inventairo[tmpI].amount -= 1;
                    Instantiate(cons[2], fogueira.transform.position, Quaternion.identity);
                   fogueira.SetActive(true);

                }
            }

        }


    }
}
