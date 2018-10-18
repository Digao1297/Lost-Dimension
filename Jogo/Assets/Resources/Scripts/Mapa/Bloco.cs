using UnityEngine;
using System.Collections;

public class Bloco : Itens {

    public int durabilidade;
    public float raridade;
   
   
 public Bloco (string nome, int durabilidade, float raridade, int amount, Type _type) :base (nome, amount, _type)
    {
        this.durabilidade = durabilidade;
        this.raridade = raridade;
    }
}
