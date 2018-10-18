using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PersonagemComandos : MonoBehaviour {
	public Animator animador;
	public Rigidbody2D rb2d;
	private RaycastHit2D ray;
	
	public float velocidade;
    public GameObject pulo;
    public float forcaPulo;
	
    public GameObject inventario;
	public GameObject fcraft;
	public GameObject showCraft;
    public GameObject mouse;
    public GameObject menu;

    public Image[] selecionado;
    
    private UIControl uicon;
    private Inventario inv;
    public int selectSlot;
    
   





    void Start () {
        uicon = FindObjectOfType<UIControl>();
        inv = FindObjectOfType<Inventario>();

        inventario.SetActive(false);
        fcraft.SetActive(false);
        mouse.SetActive(true);
        menu.SetActive(false);
        Time.timeScale = 1f;
    }


    void Update() {
        animador.SetBool("Nochao", nochao());
        animador.SetBool("andar", false);
       
        //print (nochao());
        
        if (nochao()) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                pular();
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
          
           if (menu.activeSelf==false)
            {
                menu.SetActive(true);
               Time.timeScale = 0f;
            }else if (menu.activeSelf == true)
            {
                menu.SetActive(false);
                Time.timeScale = 1f;
            }

        }
       

        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            if (inv.inventairo[15]!=null)
            {
                selectSlot = 15;
                foreach (var s in selecionado)
                {
                    if (s.enabled==true)
                    {
                        s.enabled = false;
                        break;
                    }
                }
                selecionado[0].enabled = true; 
               
            }
         
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (inv.inventairo[16] != null)
            {
                selectSlot = 16;
                foreach (var s in selecionado)
                {
                    if (s.enabled == true)
                    {
                        s.enabled = false;
                        break;
                    }
                }
                selecionado[1].enabled = true;
            }
          

        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            if (inv.inventairo[17] != null)
            {
                selectSlot = 17;
                foreach (var s in selecionado)
                {
                    if (s.enabled == true)
                    {
                        s.enabled = false;
                        break;
                    }
                }
                selecionado[2].enabled = true;
            }
          

        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            if (inv.inventairo[18] != null)
            {
                selectSlot = 18;
                foreach (var s in selecionado)
                {
                    if (s.enabled == true)
                    {
                        s.enabled = false;
                        break;
                    }
                }
                selecionado[3].enabled = true;
            }
           

        }

        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            if (inv.inventairo[19]!=null)
            {
                selectSlot = 19;
                foreach (var s in selecionado)
                {
                    if (s.enabled == true)
                    {
                        s.enabled = false;
                        break;
                    }
                }
                selecionado[4].enabled = true;
            }
          

        }








		if (Input.GetKeyDown(KeyCode.C))
		{
			if (inventario.activeSelf == true) {
				if (fcraft.activeSelf == false) {

					fcraft.SetActive (true);

				} else if (fcraft.activeSelf == true) {

					fcraft.SetActive (false);
					showCraft.SetActive (false);
				}
			}
		}

		if (Input.GetKeyDown(KeyCode.E))
		{

			if (inventario.activeSelf==false)
			{

				inventario.SetActive(true);
				mouse.SetActive(false);
				Cursor.visible = true;
			}else
				if (inventario.activeSelf == true)
				{

					inventario.SetActive(false);
					mouse.SetActive(true);
					uicon.showDeItem.SetActive(false);
					Cursor.visible = false;
					if (fcraft == true) {
						fcraft.SetActive (false);
						showCraft.SetActive (false);
					}
				}

        }
		if (Input.GetKey(KeyCode.D)) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0,0);
			animador.SetBool ("andar",true);
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0,180);
			animador.SetBool ("andar",true);
        }

       

      
        
	}
 

	public bool nochao(){
        

       

        ray = Physics2D.Raycast(pulo.transform.position,
            -transform.up,0.5f);

        RaycastHit2D[] ray2 = Physics2D.RaycastAll(pulo.transform.position,
            -transform.up, 0.5f);

        string tmptag;
        if (ray)
        {
            Debug.DrawLine(pulo.transform.position,ray.point);
            foreach (var r in ray2)
            {
                
                    tmptag = r.transform.gameObject.tag;
                
              
                if (tmptag.StartsWith("min"))
                {
                    return true;
                } 
            }
           
        }
        

        
		return false;


	}

	public void pular (){

		animador.SetBool ("Nochao",false);

        rb2d.AddForce (transform.up*forcaPulo);
	}

   


}
