using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class LerXml: MonoBehaviour{
	public static string nomeX;
	public static float raridade;
	public static int durabilidade;
    public static int vida;
    public static int dano;
    public static float velocidadeAT;
    public static float velocidadeM;
	public static int aux;
	public static int saciedade;
	public static int amount;
	public static string receita;
	public static string tipo;
	public static Type _type;


	public static List<Bloco>Bloco(TextAsset xml){
		XmlReader reader = XmlReader.Create (new StringReader (xml.text));
		List<Bloco> info = new List<Bloco> ();
       
		while (reader.Read ()) {
			bool adicionar = false;
			if (reader.IsStartElement("Bloco")) {
				nomeX = reader.GetAttribute("nome");
                durabilidade = int.Parse(reader.GetAttribute("durabilidade"));
                raridade = float.Parse(reader.GetAttribute ("raridade"));
                _type = Type.RECURSO;

				adicionar = true;
			}
			foreach (var   bloco in info) {

				if (nomeX==bloco.nomes) {
					adicionar = false;
					break;
				}
			}	
			if (adicionar) {
				info.Add (new Bloco(nomeX, durabilidade, raridade, 1, _type));	
			}


				           
		}
		reader.Close ();
        return info;

	}
    public static List<Animal> Animal(TextAsset xml) {
        XmlReader reader = XmlReader.Create(new StringReader(xml.text));
        List<Animal> animal = new List<Animal>();

        while (reader.Read())
        {
            bool adicionar = false;
            if (reader.IsStartElement("Animal"))
            {
                nomeX = reader.GetAttribute("nome");
                raridade = float.Parse(reader.GetAttribute("raridade"));
                vida = int.Parse(reader.GetAttribute("vida"));
                dano = int.Parse(reader.GetAttribute("dano"));
                velocidadeAT = float.Parse(reader.GetAttribute("velocidadeAt"));
                velocidadeM = float.Parse(reader.GetAttribute("velocidadeM"));
                adicionar = true;
            }
            foreach (Animal a in animal)
            {
                if (nomeX == a.nome)
                {
                    adicionar = false;
                    break;
                }
            }
            if (adicionar)
            {
                animal.Add(new Animal(nomeX,raridade, vida, dano, velocidadeAT, velocidadeM));

            }
        }
     
        reader.Close();
        return animal;
    }
	 public static List<Comida>Comida(TextAsset xml){
		XmlReader reader = XmlReader.Create (new StringReader (xml.text));
		List<Comida> comida = new List<Comida> ();

		while (reader.Read ()) {
			bool adicionar = false;
			if (reader.IsStartElement("Comida")) {
				nomeX = reader.GetAttribute("nome");
				vida = int.Parse(reader.GetAttribute("vida"));
				saciedade = int.Parse(reader.GetAttribute("saciedade"));
				amount = int.Parse(reader.GetAttribute ("amount"));
			



				adicionar = true;
			}
		
				
			foreach (Comida comidas in comida) {
				Itens item = comidas;

				if (nomeX==item.nomes) {
					adicionar = false;
					break;
				}
			}	
			if (adicionar) {
				comida.Add (new Comida (nomeX, vida, saciedade, amount, Type.CONSUMIVEL));	
			}



		}
		reader.Close ();
		return comida;

	}

	public static List<Arma>Ferramenta(TextAsset xml){
		XmlReader reader = XmlReader.Create (new StringReader (xml.text));
		List<Arma> arma = new List<Arma> ();

		while (reader.Read ()) {
			bool adicionar = false;
			if (reader.IsStartElement("Ferramenta")) {
				nomeX = reader.GetAttribute("nome");
				durabilidade = int.Parse(reader.GetAttribute("durabilidade"));
				dano = int.Parse(reader.GetAttribute("dano"));
				receita = reader.GetAttribute ("receita");
				tipo = reader.GetAttribute ("type");



				adicionar = true;
			}
			if (reader.IsStartElement("Espada")) {
				nomeX = reader.GetAttribute("nome");
				durabilidade = int.Parse(reader.GetAttribute("durabilidade"));
				dano = int.Parse(reader.GetAttribute("dano"));
				receita = reader.GetAttribute ("receita");
				tipo = reader.GetAttribute ("type");



				adicionar = true;
			}


			foreach (Arma armas in arma) {
				Itens item = armas;
				if (tipo == "ESPADA") {
					_type = Type.ESPADA;
				}
				if (tipo == "CONSTRUCOES") {
						_type = Type.CONSTRUCOES;
				}
				if (tipo == "PA") {
					_type = Type.PA;
				}
				if (tipo == "PICARETA") {
					_type = Type.PICARETA;
				}
				if (tipo == "MACHADO") {
					_type = Type.MACHADO;
				}
				if (nomeX==item.nomes) {
					adicionar = false;
					break;
				}
			}	
			if (adicionar) {
				arma.Add(new Arma (nomeX, durabilidade,receita, dano, 1, _type));	
			}



		}
		reader.Close ();
		return arma;

	}

	public static List<Comida>ComidaAssada(TextAsset xml){
		XmlReader reader = XmlReader.Create (new StringReader (xml.text));
		List<Comida> comidaA = new List<Comida> ();

		while (reader.Read ()) {
			bool adicionar = false;
			if (reader.IsStartElement("Assada")) {
				nomeX = reader.GetAttribute("nome");
				vida = int.Parse(reader.GetAttribute("vida"));
				saciedade = int.Parse(reader.GetAttribute("saciedade"));
				receita = reader.GetAttribute("receita");
				amount = int.Parse(reader.GetAttribute ("amount"));




				adicionar = true;
			}


			foreach (var comidasA in comidaA) {
				Itens item = comidasA;

				if (nomeX==item.nomes) {
					adicionar = false;
					break;
				}
			}	
			if (adicionar) {
				comidaA.Add (new Comida (nomeX, vida, saciedade, receita, amount, Type.CONSUMIVEL));	
			}



		}
		reader.Close ();
		return comidaA;

	}

	public static List<Criacao>Criacao(TextAsset xml){
		XmlReader reader = XmlReader.Create (new StringReader (xml.text));
		List<Criacao> criacao = new List<Criacao> ();

		while (reader.Read ()) {
			bool adicionar = false;
			if (reader.IsStartElement("Criacao")) {
				nomeX = reader.GetAttribute("nome");
				vida = int.Parse(reader.GetAttribute("vida"));
				receita = reader.GetAttribute("receita");

				adicionar = true;
			}


			foreach (var criacoes in criacao) {
				Itens item = criacoes;

				if (nomeX==item.nomes) {
					adicionar = false;
					break;
				}
			}	
			if (adicionar) {
				criacao.Add (new Criacao (nomeX, vida, receita, 1, Type.CONSTRUCOES));	
			}



		}
		reader.Close ();
		return criacao;

	}

	public static List<Lingotes>Lingote(TextAsset xml){
		XmlReader reader = XmlReader.Create (new StringReader (xml.text));
		List<Lingotes> lingote = new List<Lingotes> ();

		while (reader.Read ()) {
			bool adicionar = false;
			if (reader.IsStartElement("Lingote")) {
				nomeX = reader.GetAttribute("nome");
                amount = int.Parse(reader.GetAttribute("amount"));
				receita = reader.GetAttribute("receita");

				adicionar = true;
			}


			foreach (var lingotes in lingote) {
				Itens item = lingotes;

				if (nomeX==item.nomes) {
					adicionar = false;
					break;
				}
			}	
			if (adicionar) {
				lingote.Add (new Lingotes (nomeX,amount, receita, Type.RECURSO));	
			}



		}
		reader.Close ();
		return lingote;

	}

	public static List<Itens>Coleta(TextAsset xml){
		XmlReader reader = XmlReader.Create (new StringReader (xml.text));
		List<Itens> coleta = new List<Itens> ();

		while (reader.Read ()) {
			bool adicionar = false;
			if (reader.IsStartElement("Coletavel")) {
				nomeX = reader.GetAttribute("nome");
				amount = int.Parse(reader.GetAttribute("amount"));

				adicionar = true;
			}


			foreach (var coletas in coleta) {
				Itens item = coletas;

				if (nomeX==item.nomes) {
					adicionar = false;
					break;
				}
			}	
			if (adicionar) {
				coleta.Add (new Itens (nomeX, amount, Type.RECURSO));	
			}



		}
		reader.Close ();
		return coleta;

	}

	public static Vida Jacklin(TextAsset xml){
		XmlReader reader = XmlReader.Create (new StringReader (xml.text));
		Vida jacklin = new Vida();

		while (reader.Read ()) {
			bool adicionar = false;
			if (reader.IsStartElement("Personagem")) {
				nomeX = reader.GetAttribute("nome");
				vida = int.Parse(reader.GetAttribute("vida"));
				saciedade = int.Parse(reader.GetAttribute("saciedade"));
				dano = int.Parse(reader.GetAttribute("dano"));
				velocidadeAT = float.Parse(reader.GetAttribute("velocidadeAt"));
				velocidadeM = float.Parse(reader.GetAttribute("velocidadeM"));

				adicionar = true;
			}

            jacklin = new Vida(vida, nomeX, (float)saciedade, dano, velocidadeAT, velocidadeM);
            reader.Read();


		}


		reader.Close ();
		return jacklin;

	}

    public static Dictionary<string, List<Itens>> Receitas(TextAsset xml)
    {
        XmlReader reader = XmlReader.Create(new StringReader(xml.text));
        Dictionary<string, List<Itens>> receita = new Dictionary<string, List<Itens>>(); ;
        List<Itens> item = null;
        string itemNome=null;
        while (reader.Read())
        {
            bool adicionar = false;
            bool adicionarR = false;
            if (reader.IsStartElement("Receita"))
            {
				item = new List<Itens>();
                nomeX = reader.GetAttribute("nome");
				reader.Read();
                while (reader.IsStartElement("Item"))
                {
					itemNome = reader.GetAttribute("nome");
					amount = int.Parse(reader.GetAttribute("qnt"));
					adicionar = true;
                    foreach (var i in item)
                    {
                        if (i.nomes == itemNome)
                        {
                            adicionar = false;
                            break;
                        }
                    }
                    if (adicionar)
                    {
                        item.Add(new Itens(itemNome, amount));
                    }
					reader.Read();//Lê o fechamento
					reader.Read();//Lê o próximo
                }

                adicionarR = true;
            }
            foreach (var r in receita)
            {
                if (r.Key==nomeX)
                {
                    adicionarR = false;
                    break;
                }
            }
            if (adicionarR)
            {
                receita.Add(nomeX, item);
				//print(nomeX + " " + item.Count);
            }
           
        }
       
        reader.Close();
        return receita;
    }


}
