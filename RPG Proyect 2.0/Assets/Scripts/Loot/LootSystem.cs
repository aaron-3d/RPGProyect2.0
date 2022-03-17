using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour
{
    [SerializeField]
    private LootTable lootTable;

    public static LootSystem Instance { get; private set; }

    [SerializeField]
    private int probabilidad;

    [SerializeField]
    private int total;

    private LootTable.Probabilidades[] localProb;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        localProb = lootTable.prob;
        System.Array.Sort(localProb, new ComparadorDeRarezas());
        System.Array.Reverse(localProb);

        foreach(var weight in localProb)
        {
            total += weight.rareza;
        }
    }
    public void SpawnLoot(Transform spawnPoint, int factorAdicional/*Por si algun mob hay que incrementarle la probabilidad de que suelte cosas mejores(nunca menor que 1*/, int cantidadDeItemsADropear/*por si queremos que dropee mas de 1 item*/, int dropChance/*probabilidad de que suelte items o no*/, bool? repeated = null)
    {
        probabilidad = Random.Range(0, (total + 1));
        int miProb = probabilidad * factorAdicional;
        if(repeated != null)
        {
            if(repeated == true)
            {
                for (int i = 0; i < localProb.Length; i++)
                {
                    if (miProb <= localProb[i].rareza)
                    {
                        GameObject go = Instantiate(localProb[i].reward, spawnPoint.position, Quaternion.identity);

                        //go.GetComponent<ItemSuelto>().Inv = GameObject.FindObjectOfType<MovimientoJugador>().inventario.GetComponent<Inventario>(); //para que se ponga en el inventario del jugador

                        if (cantidadDeItemsADropear == 1)
                        {
                            return;
                        }
                        cantidadDeItemsADropear--;
                    }
                    else
                    {
                        miProb -= localProb[i].rareza;
                    }
                }
            }
        }
        //Check para ver si objeton loot o no, entre un 0 y 100%
        int dropChanceCalculo = Random.Range(0, 101);

        if(dropChanceCalculo >= dropChance)
        {
            print("No hay loot");
            return;
        }
        //fin del check

        if(miProb >= total)
        {
            miProb = total;
        }

        for (int i = 0; i < localProb.Length; i++)
        {
            if(miProb <= localProb[i].rareza)
            {
                GameObject go = Instantiate(localProb[i].reward, spawnPoint.position, Quaternion.identity);

                //go.GetComponent<ItemSuelto>().Inv = GameObject.FindObjectOfType<Jugador>().inventario.GetComponent<Inventario>(); //para que se ponga en el inventario del jugador

                if (cantidadDeItemsADropear == 1)
                {
                    return;
                }
                cantidadDeItemsADropear--;
            }
            else
            {
                miProb -= localProb[i].rareza;
            }
        }
        if(cantidadDeItemsADropear >=  1)
        {
            SpawnLoot(spawnPoint, factorAdicional, cantidadDeItemsADropear, dropChance, true);
        }
    }
}
public class ComparadorDeRarezas : IComparer
{
    public int Compare(object x, object y)
    {
        int n1 = ((LootTable.Probabilidades)x).rareza;
        int n2 = ((LootTable.Probabilidades)y).rareza;
        if(n1 > n2)
        {
            return 1;
        }
        else if (n1 == n2)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}