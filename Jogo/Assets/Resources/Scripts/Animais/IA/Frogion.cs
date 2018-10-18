using UnityEngine;
using System.Collections;

public class Frogion : MonoBehaviour {
    public int speed;
    public float angulo;
    public GameObject frenteG;
    public GameObject chaoG;
   
    private Animal animal;
    public int tmpSpeed;

    public float tempoPorAtaque = 1;
    private float contador;
    private bool podeAtacar;
    public  bool agressivo;
    public Transform personagem;

 
    

    void Start()
    {
       
        animal = FindObjectOfType<Animal>();
        personagem = GameObject.Find("Jacklin").GetComponent<Transform>();
    }
    void Update() {
        RaycastHit2D chao = Physics2D.Raycast(chaoG.transform.position, -chaoG.transform.up, 0.1f);
        RaycastHit2D[] chaoall = Physics2D.RaycastAll(chaoG.transform.position, -chaoG.transform.up, 0.1f);

        RaycastHit2D frente = Physics2D.BoxCast(frenteG.transform.position, new Vector2(0.2f, 0.2f), 0, -frenteG.transform.up, 1f);
        RaycastHit2D[] frenteall = Physics2D.BoxCastAll(frenteG.transform.position, new Vector2(0.2f, 0.2f), 0, -frenteG.transform.up, 1f);

        RaycastHit2D ataque = Physics2D.BoxCast(frenteG.transform.position, new Vector2(0.3f, 0.2f), 0, frenteG.transform.right, 1f);
        RaycastHit2D[] ataqueAll = Physics2D.BoxCastAll(frenteG.transform.position, new Vector2(0.3f, 0.2f), 0, frenteG.transform.right, 1f);
        
        

        if (agressivo)
        {
            if (Vector2.Distance(transform.position, personagem.position) <= 1f&&podeAtacar==true)
            {
                if (personagem.transform.position.x > transform.position.x)
                {

                    personagem.transform.position = new Vector3(transform.position.x + 2, transform.position.y + 2, 0);
                }
                if (personagem.transform.position.x < transform.position.x)
                {

                    personagem.transform.position = new Vector3(transform.position.x - 2, transform.position.y + 2, 0);
                }

            }
            if (ataque!=false&&ataque.collider.CompareTag("Player") && podeAtacar == true)
            {
                //Ataco

                podeAtacar = false;

                speed = 0;
                if (animal.dano>0)
                {
                    
                    ataque.collider.GetComponent<Vida>().vidaAtual -= animal.dano;
                }
                
            }else if (Vector2.Distance(transform.position,personagem.position)<=5)
            {
                speed = tmpSpeed;
                
                if (personagem.transform.position.x>transform.position.x)
                {
                   
                    angulo = 0;
                    speed = tmpSpeed;
                }
                if (personagem.transform.position.x < transform.position.x)
                {
                   
                    angulo = 180;
                    speed = tmpSpeed;
                }
                if (ataque&&ataque.collider.CompareTag("Player"))
                {
                    speed = 0;
                }
                foreach (var r in frenteall)
                {
                    if (frente && r.collider.tag.StartsWith("min"))
                    {
                        Rigidbody2D rb = GetComponent<Rigidbody2D>();
                        rb.AddForce(transform.up * 20);
                    }
                }
                    
                
                transform.Translate(Vector2.right * (speed+speed) * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, angulo);
                //Aumentar a velocidade
                //Executar um movimento.
            }
            else
            {
               
                agressivo = false;
            }

            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<PolygonCollider2D>().isTrigger = false;
        }
        else if(!agressivo)
        {

     
            if (Vector2.Distance(transform.position, personagem.position) <= 2f)
            {
                GetComponent<Rigidbody2D>().isKinematic = true;
                GetComponent<PolygonCollider2D>().isTrigger = true;
            }
            else
            {
                GetComponent<Rigidbody2D>().isKinematic = false;
                GetComponent<PolygonCollider2D>().isTrigger = false;

            }
            foreach (var c in chaoall)
            {
                if (chao && c.collider.gameObject.tag.StartsWith("min"))
                {
                    foreach (var f in frenteall)
                    {
                        if (frente && f.collider.tag.StartsWith("min"))
                        {
                            if (angulo == 180)
                            {
                                angulo = 0;
                            }
                            else if (angulo == 0)
                            {
                                angulo = 180;
                            }
                            Debug.DrawLine(frente.transform.position, frente.point, Color.red);
                        }
                    }



                }
            }
          
           
            if (chao==false)
            {

                if (angulo == 180)
                {
                    print("C");

                    angulo = 0;
                }
                else if (angulo== 0)
                {
                    print("D");

                    angulo = 180;
                } 
            }
           
          
            
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, angulo);
        }
        if (speed != 0)
        {
            tmpSpeed = speed;
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


    public void Bateu()
    {

        agressivo = true;
    }

    

        

    }
