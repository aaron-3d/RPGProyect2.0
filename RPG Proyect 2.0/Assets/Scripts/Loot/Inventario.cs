using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Inventario : MonoBehaviour
{
    [System.Serializable]
    public struct ObjetoInvId
    {
        public int id;
        public int cantidad;

        public ObjetoInvId(int id, int cantidad)
        {
            this.id = id;
            this.cantidad = cantidad;
        }
    }
    public HealthDamage healthDamage;

    [SerializeField]
    DataBase data;
    [Header("Variables del Drag and drop")]
    public GraphicRaycaster graphRay;
    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults; //Array para almacenar el item que coges con el raycaster
    public static Transform canvas; //se vuelve static para utilizarlo en item
    public GameObject objetoSeleccionado;
    public Transform exParent;
    [Header("Prefs e items")]
    public static GameObject Descripcion;
    public CartelEliminacion CE;
    public int OSC;
    public int OSID;

    public Transform contenido;
    public Item item;
    public List<ItemSuelto> itemsSueltos = new List<ItemSuelto>();
    public List<ObjetoInvId> inventarioo = new List<ObjetoInvId>();

    public Transform ItemSueltoRespawn;
    void Start()
    {
        InventoryUpdate();

        pointerData = new PointerEventData(null);
        raycastResults = new List<RaycastResult>();

        Descripcion = GameObject.Find("Descripcion");

        CE.gameObject.SetActive(false);

        canvas = transform.parent.transform;

    }

    // Update is called once per frame
    void Update()
    {
        //Arrastrar();
    }
    void Arrastrar()
    {
        /*if (Input.GetMouseButtonDown(1))
        {
            pointerData.position = Input.mousePosition;
            graphRay.Raycast(pointerData, raycastResults);
            if (raycastResults.Count > 0)
            {
                if (raycastResults[0].gameObject.GetComponent<Item>()) //si el objeto que pulsamos tiene el componente Item
                {
                    objetoSeleccionado = raycastResults[0].gameObject;

                    OSC = objetoSeleccionado.GetComponent<Item>().cantidad;
                    OSID = objetoSeleccionado.GetComponent<Item>().ID;

                    exParent = objetoSeleccionado.transform.parent.transform; //para guardar la posicion principal del item al pulsarlo
                    //exParent.GetComponent<Image>().fillCenter = false; //borrar el fillCenter de las casillas donde no haya nada
                    objetoSeleccionado.transform.SetParent(canvas); //desenparentar el item del slot
                }
            }
        }

        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.GetComponent<RectTransform>().localPosition = CanvasScreen(Input.mousePosition); //Que se vea el item moviendose junto al raton
        }
        if (objetoSeleccionado != null)
        {
            if (Input.GetMouseButtonUp(1))
            {
                pointerData.position = Input.mousePosition;
                raycastResults.Clear(); //eliminar los resultados del RayCast
                graphRay.Raycast(pointerData, raycastResults); //para saber donde dejamos el item
                objetoSeleccionado.transform.SetParent(exParent);
                if (raycastResults.Count > 0)
                {
                    foreach (var resultado in raycastResults)
                    {
                        if (resultado.gameObject == objetoSeleccionado) continue;
                        if (resultado.gameObject.CompareTag("Slot")) //caso de slot libre
                        {
                            if (resultado.gameObject.GetComponentInChildren<Item>() == null)
                            {
                                objetoSeleccionado.transform.SetParent(resultado.gameObject.transform);
                                //objetoSeleccionado.transform.localPosition = Vector2.zero;
                                //exParent = objetoSeleccionado.transform.parent.transform;
                            }
                            
                            //***************
                            if (resultado.gameObject.CompareTag("Item"))
                            {
                                if (resultado.gameObject.GetComponentInChildren<Item>().ID == objetoSeleccionado.GetComponent<Item>().ID) //acceder al ID y si es igual
                                {
                                    resultado.gameObject.GetComponentInChildren<Item>().cantidad += objetoSeleccionado.GetComponent<Item>().cantidad; //suma las cantidades de un mismo item, (2 pociones + 2 pociones)
                                    Destroy(objetoSeleccionado.gameObject);
                                }
                                else //si el ID es distinto
                                {
                                    objetoSeleccionado.transform.SetParent(resultado.gameObject.transform.parent);
                                    resultado.gameObject.transform.SetParent(exParent);
                                    resultado.gameObject.transform.localPosition = Vector3.zero;
                                }
                            }
                            //**********************
                            /*else //caso de slot ocupado
                            {
                                if (resultado.gameObject.GetComponentInChildren<Item>().ID == objetoSeleccionado.GetComponent<Item>().ID) //acceder al ID y si es igual
                                {
                                    resultado.gameObject.GetComponentInChildren<Item>().cantidad += objetoSeleccionado.GetComponent<Item>().cantidad; //suma las cantidadesd e un mismo item, (2 pociones + 2 pociones)
                                    Destroy(objetoSeleccionado.gameObject);
                                }
                                else //si el ID es distinto
                                {
                                    objetoSeleccionado.transform.SetParent(exParent.transform);
                                    //objetoSeleccionado.transform.localPosition = Vector2.zero;
                                }
                            }*/
        //}
        /*else
        {
            objetoSeleccionado.transform.SetParent(exParent.transform);
            //objetoSeleccionado.transform.localPosition = Vector2.zero;
        }
        if (resultado.gameObject.CompareTag("Eliminar"))
        {
            if(objetoSeleccionado.gameObject.GetComponent<Item>().cantidad >= 2)
            {
                CE.gameObject.SetActive(true);
            }
            else
            {
                CE.gameObject.SetActive(false);
                EliminarItem(objetoSeleccionado.gameObject.GetComponent<Item>().ID, objetoSeleccionado.gameObject.GetComponent<Item>().cantidad);
            }
        }
    }
}
objetoSeleccionado.transform.localPosition = Vector3.zero;
objetoSeleccionado = null;
}
}
if (raycastResults != null)
{
raycastResults.Clear();
}*/
    }
    public Vector2 CanvasScreen(Vector2 screenPos) //Ubicar la camara principal para ver el rango de vision de la camara
    {
        Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(screenPos);
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta; //Coge el tamaño del canvas

        return (new Vector2(viewportPoint.x * canvasSize.x, viewportPoint.y * canvasSize.y) - (canvasSize / 2)); //multiplica la cantidad de pixeles para dividirla y tener un punto intermedio
    }

    public void AgregarItem(int id, int cantidad)
    {
        for (int i = 0; i < inventarioo.Count; i++)
        {
            if (inventarioo[i].id == id && data.baseDatos[id].acumulable) //para agregar los objetos acumulables dentro del mismo stack (Eliminar lo siguiente del && y la bool acumulable si no queremos que se stackeen)
            {
                inventarioo[i] = new ObjetoInvId(inventarioo[i].id, inventarioo[i].cantidad + cantidad);
                InventoryUpdate();
                return;
            }
        }
        if (!data.baseDatos[id].acumulable)
        {
            inventarioo.Add(new ObjetoInvId(id, 1));
        }
        else
        {
            inventarioo.Add(new ObjetoInvId(id, cantidad));
        }
        InventoryUpdate();
    }

    public void EliminarItem(int id, int cantidad)
    {
        for (int i = 0; i < inventarioo.Count; i++)
        {
            if (inventarioo[i].id == id)
            {
                inventarioo[i] = new ObjetoInvId(inventarioo[i].id, inventarioo[i].cantidad - cantidad);

                for (int n = 0; n < itemsSueltos.Count; n++)
                {
                    if (itemsSueltos[n].ID == id)
                    {
                        itemsSueltos[n].gameObject.SetActive(true);
                        itemsSueltos[n].transform.position = ItemSueltoRespawn.position;
                        itemsSueltos[n].transform.SetParent(null);
                        itemsSueltos.Remove(itemsSueltos[n]);
                    }
                }




                if (inventarioo[i].cantidad <= 0)
                {
                    inventarioo.Remove(inventarioo[i]);
                    InventoryUpdate();
                    break;
                }
                InventoryUpdate();
            }
        }
    }

    List<Item> pool = new List<Item>();
    public void InventoryUpdate()
    {
        for (int i = 0; i < pool.Count; i++)                    //hasta obtener el mismo numero en i que en pool.count
        {
            if (i < inventarioo.Count)                         //si hay menos scripts que objetos de inventario
            {
                ObjetoInvId o = inventarioo[i];
                pool[i].ID = o.id;                              //aqui le asigno la id del objeto a mi script llamada Item
                pool[i].GetComponent<Image>().sprite = data.baseDatos[o.id].icono;
                pool[i].GetComponent<RectTransform>().localPosition = Vector3.zero;
                pool[i].cantidad = o.cantidad;
                pool[i].Boton.onClick.RemoveAllListeners();
                pool[i].Boton.onClick.AddListener(() => gameObject.SendMessage(data.baseDatos[o.id].Void, SendMessageOptions.DontRequireReceiver));
                pool[i].gameObject.SetActive(true);
            }
            else
            {
                pool[i].gameObject.SetActive(false);
                pool[i]._descripcion.SetActive(false);
                pool[i].gameObject.transform.parent.GetComponent<Image>().fillCenter = false;
            }
        }
        if (inventarioo.Count > pool.Count)
        {
            for (int i = pool.Count; i < inventarioo.Count; i++)
            {

                Item it = Instantiate(item, contenido.GetChild(i)); // aqui el getchild lo utilizo para crear el item dentro del slot

                pool.Add(it);

                if (contenido.GetChild(0).childCount >= 2)
                {
                    for (int s = 0; s < contenido.childCount; s++)
                    {
                        if (contenido.GetChild(s).childCount == 0)
                        {
                            it.transform.SetParent(contenido.GetChild(s));
                            break;
                        }
                    }
                }
                it.transform.position = Vector3.zero;
                it.transform.localScale = Vector3.one;

                ObjetoInvId o = inventarioo[i];
                pool[i].ID = o.id;                                                              //Aqui le asigno la id del objeto a mi script llamado Item
                pool[i].GetComponent<RectTransform>().localPosition = Vector3.zero;
                pool[i].GetComponent<Image>().sprite = data.baseDatos[o.id].icono;
                pool[i].cantidad = o.cantidad;
                pool[i].Boton.onClick.RemoveAllListeners();
                pool[i].Boton.onClick.AddListener(() => gameObject.SendMessage(data.baseDatos[o.id].Void, SendMessageOptions.DontRequireReceiver));
                pool[i].gameObject.SetActive(true);
            }
        }
    }


    void PocionSalud()
    {
        healthDamage.SumarVida(10);
        EliminarItem(0, 1);
    }
    void Curacion()
    {
        if (healthDamage.vidaP < healthDamage.maxHealth)
        {
            healthDamage.Curar(20);
            EliminarItem(1, 1);
        }
    }

}