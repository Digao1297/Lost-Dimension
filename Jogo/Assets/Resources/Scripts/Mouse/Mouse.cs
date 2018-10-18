using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Mouse : MonoBehaviour {
    public GameObject personagem;
    public PersonagemComandos personaC;
    public Inventario inv;
    public int tmpI;
    public Grama grama;
    public BoxCollider2D caixa;
    public GameObject[] drops;
    public float tempoPorAtaque = 1;
    public GameObject posBloco;

    private float contador;
    private bool podeAtacar;
    private int dano=1;
   


    void Start () {
        grama = FindObjectOfType<Grama>();
        inv = FindObjectOfType<Inventario>();
        personaC = FindObjectOfType<PersonagemComandos>();
        

        podeAtacar = false;
      
    }
	
	
	void Update () {
        tmpI = personaC.selectSlot;

        Vector2 aux = new Vector3(2, 3);
      
      
        Vector2 sub= personagem.transform.position - transform.position;
        Vector2 positivo = ((personagem.transform.position - transform.position) * (-1));
        RaycastHit2D hit2d = Physics2D.Raycast(transform.position, transform.position, 1f);
        RaycastHit2D[] hit2dAll = Physics2D.RaycastAll(transform.position, transform.position, 1f);

       


        if (hit2d==true&&hit2d.collider.tag.StartsWith("min"))
        {
            Cursor.visible =false;
            posBloco.SetActive(true);
            Vector3 c = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(Mathf.Floor(c.x), Mathf.Floor(c.y), 0);
        }
        else if ((inv.inventairo[tmpI].nomes=="terra")||(inv.inventairo[tmpI].nomes == "pedra")) 
        {
            Cursor.visible = false;
            posBloco.SetActive(true);
            Vector3 c = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(Mathf.Floor(c.x), Mathf.Floor(c.y), 0);

       }
        else
        {
            Cursor.visible = true;
            posBloco.SetActive(false);
            Vector3 c = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = c;
        }

   

       
      


       
       
        if (hit2d)

        {
            
            //Debug.DrawLine(transform.position, hit2d.point, Color.red);
           
            if (Input.GetButton("Fire1") && sub.x <= aux.x && sub.y <= aux.y && positivo.x <= aux.x && positivo.y <= aux.y&&podeAtacar==true)

            {
                podeAtacar = false;
               
                //Debug.DrawLine(transform.position, hit2d.point);
                if (hit2d.collider.gameObject != null && hit2d.collider.gameObject.tag != "min-Rocha" && !hit2d.collider.GetComponent<Coletavel>())
                {
                    
                    if (inv.inventairo[tmpI].type==Type.PA)
                    {
                     
                        if (hit2d.collider.gameObject.tag=="min-Terra"|| hit2d.collider.gameObject.tag == "min-Grama" && hit2d.collider.GetComponent<Grama>().GetFauna() == false)
                        {
                            Arma arma = inv.inventairo[tmpI] as Arma;
                          
                           hit2d.collider.GetComponent<Minerios>().durabilidade-= arma.dano;
                           

                            if (hit2d.collider.GetComponent<Minerios>().durabilidade<=0)
                            {
                                
                                
                                Destroy(hit2d.collider.gameObject);
								arma.durabilidade -= 1;
                                Instantiate(drops[0], hit2d.collider.gameObject.transform.position, Quaternion.identity);
                            }
                       
                        }
                        
                    }
                    if (inv.inventairo[tmpI].type == Type.PICARETA)
                    {
                        if (hit2d.collider.gameObject.tag == "min-Pedra" || hit2d.collider.gameObject.tag == "min-Carvao" || hit2d.collider.gameObject.tag == "min-Ferro"
                            || hit2d.collider.gameObject.tag == "min-Cobre" || hit2d.collider.gameObject.tag == "min-QuadPala")
                        {

                            // hit2d.collider.GetComponent<Bloco>().durabilidade -= inv.inventairo[tmpI].dano;
                            Arma arma = inv.inventairo[tmpI] as Arma;
                            hit2d.collider.GetComponent<Minerios>().durabilidade -= arma.dano;

                            if (hit2d.collider.GetComponent<Minerios>().durabilidade<=0)
                            {
                                string tag = hit2d.collider.gameObject.tag;
                                Destroy(hit2d.collider.gameObject);
								arma.durabilidade -= 1;

                                if (tag== "min-Pedra")
                                {
                                    Instantiate(drops[1], hit2d.collider.gameObject.transform.position, Quaternion.identity);
                                }
                                if (tag == "min-Carvao")
                                {
                                    Instantiate(drops[2], hit2d.collider.gameObject.transform.position, Quaternion.identity);
                                }
                                if (tag == "min-Cobre")
                                {
                                    Instantiate(drops[3], hit2d.collider.gameObject.transform.position, Quaternion.identity);
                                }
                                if (tag == "min-Ferro")
                                {
                                    Instantiate(drops[4], hit2d.collider.gameObject.transform.position, Quaternion.identity);
                                }
                                if (tag == "min-QuadPala")
                                {
                                    Instantiate(drops[5], hit2d.collider.gameObject.transform.position, Quaternion.identity);
                                }
                            }

                        }

                    }
                    if (inv.inventairo[tmpI].type == Type.ESPADA)
                    {
                        foreach (var r in hit2dAll)
                        {
                            if (r.collider.GetComponent<Animal>()!=null)
                            {
                                Arma arma = inv.inventairo[tmpI] as Arma;
                                r.collider.GetComponent<Animal>().vida -= arma.dano;
								if (r.collider.GetComponent<Frogion>()!=null)
								{
									r.collider.GetComponent<Frogion> ().Bateu ();
								}
                                if (r.collider.GetComponent<Animal>().vida <= 0)
                                {
                                    Destroy(r.collider.gameObject);

									arma.durabilidade -= 1;
                                    if (hit2d.collider.gameObject.tag =="ani-Beaster")
                                    {
                                        hit2d.collider.GetComponent<Animal>().GetDrop();
                                    }
                                }
                            }
                     
                        }
                        
                    }
                    if (inv.inventairo[tmpI].type==Type.MACHADO)
                    {
                        if (hit2d.collider.GetComponent<Fauna>()!=null)
                        {
                            
                            Arma arma = inv.inventairo[tmpI] as Arma;
                            hit2d.collider.GetComponent<Fauna>().durabilidade -= arma.dano;

                            if (hit2d.collider.GetComponent<Fauna>().durabilidade<=0)
                            {
                               
                                Destroy(hit2d.collider.gameObject);
								arma.durabilidade -= 1;

                                if (hit2d.collider.gameObject.tag == "fau-ArvoreDragao")
                                {
                                    hit2d.collider.GetComponent<Fauna>().GetDrop();
                                }
                                if (hit2d.collider.gameObject.tag == "fau-Arbusto")
                                {
                                    hit2d.collider.GetComponent<Fauna>().GetDrop();
                                }
                                if (hit2d.collider.gameObject.tag == "fau-Salgueiro")
                                {
                                    hit2d.collider.GetComponent<Fauna>().GetDrop();
                                }
                            }
                        }
                    }
                    if (inv.inventairo[tmpI].type==Type.NULL)
                    {
                        if (hit2d.collider.GetComponent<Fauna>() )
                        {
                            hit2d.collider.GetComponent<Fauna>().durabilidade -= dano;
                            if (hit2d.collider.GetComponent<Fauna>().durabilidade <= 0)
                            {
                                Destroy(hit2d.collider.gameObject);

                                if (hit2d.collider.gameObject.tag == "fau-ArvoreDragao")
                                {
                                    hit2d.collider.GetComponent<Fauna>().GetDrop();
                                }
                                if (hit2d.collider.gameObject.tag == "fau-Arbusto")
                                {
                                    hit2d.collider.GetComponent<Fauna>().GetDrop();
                                }
                                if (hit2d.collider.gameObject.tag == "fau-Salgueiro")
                                {
                                    hit2d.collider.GetComponent<Fauna>().GetDrop();
                                }
                            }
                        }
                        foreach (var r in hit2dAll)
                        {
                            if (r.collider.GetComponent<Animal>() != null)
                            {
                               
                                r.collider.GetComponent<Animal>().vida -= dano;
                                if (hit2d&&r.collider.GetComponent<Frogion>()!=null)
                                {
                                    r.collider.GetComponent<Frogion>().Bateu();
                                }
                                if (r.collider.GetComponent<Animal>().vida <= 0)
                                {
									Arma arma = inv.inventairo[tmpI] as Arma;
                                    Destroy(r.collider.gameObject);

									arma.durabilidade -= 1;
                                    if (hit2d.collider.gameObject.tag == "ani-Beaster")
                                    {
                                        hit2d.collider.GetComponent<Animal>().GetDrop();
                                    }
                                }
                            }

                        }

                    }

                }
            }

        }
        if (podeAtacar == false)
        {
            
            contador += Time.deltaTime;
        }
        if (contador >= tempoPorAtaque)
        {
            
            contador = 0;
            podeAtacar = true;
        }
     
        
       


    }


            }
