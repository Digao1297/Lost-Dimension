using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour {
    public Image barraVida;
    public Image barraFome;
    public float vidaCheia;
    public float vidaAtual;
	public string nome;
	public float sacAtual;
    public float sacCheia;
	public int dano;
	public float vAtaque;
	public float vMovimento;
    public TextAsset xml;

    public float cronometroFome;

    private PersonagemComandos personaC;
    private Inventario inv;
    public int tmpI;

    public Vida (float vidaCheia, string nome,float sacCheia, int dano, float vAtaque, float vMovimento)
	{
		this.vidaCheia = vidaCheia;
		this.nome = nome;
		this.sacCheia = sacCheia;
		this.dano = dano;
		this.vAtaque = vAtaque;
		this.vMovimento = vMovimento;
	}
	
    public Vida()
    {

    }
    void Start()
    {
        inv = FindObjectOfType<Inventario>();
        personaC = FindObjectOfType<PersonagemComandos>();
        Vida tmp = LerXml.Jacklin(xml);
        vidaCheia = tmp.vidaCheia;
        nome = tmp.nome;
        sacCheia = tmp.sacCheia;
        dano = tmp.dano;
        vAtaque = tmp.vAtaque;
        vMovimento = tmp.vMovimento;
        

        vidaAtual = vidaCheia;
        sacAtual = sacCheia;
    }

    void Update()
    {
        Comer();
        SistemaFome();
        BarraFome();
        SistemaDeVida();
        BarraVida();
		if(vidaAtual<=0) {
            Cursor.visible=true;
			SceneManager.LoadScene ("game_over");
			//Application.LoadLevel("game_over");
		}
    }
	public void Comer()
	{
		tmpI = personaC.selectSlot;
		if (Input.GetButtonDown("Fire1")&&inv.inventairo[tmpI].type==Type.CONSUMIVEL&&sacAtual<sacCheia&& inv.inventairo[tmpI].amount>0)
		{
			Comida comida = inv.inventairo[tmpI] as Comida;
			inv.inventairo[tmpI].amount -= 1;
			vidaAtual += comida.vida;
			sacAtual += comida.saciedade;
		}
	}


    
public void SistemaDeVida()
    {
        if (vidaAtual>=vidaCheia)
        {
            vidaAtual = vidaCheia;

        }
        else if (vidaAtual<=0)
        {
            vidaAtual = 0;
        }


    }
    public void BarraVida()
    {
        barraVida.fillAmount = ((1 / vidaCheia) * vidaAtual);

    }

    public void SistemaFome()
    {
       
        sacAtual -= (5 * Time.deltaTime);
        if (sacAtual>=sacCheia)
        {
            sacAtual = sacCheia;
        }
       
        if (sacAtual<=0)
        {
            
            sacAtual = 0;
            cronometroFome += Time.deltaTime;
        }
        if (cronometroFome>=3)
        {
            vidaAtual -= (vidaCheia * 0.2f);
            cronometroFome = 0;
        }
       

    }
    public void BarraFome()
    {
        barraFome.fillAmount = ((1 / sacCheia) * sacAtual);


    }
}
