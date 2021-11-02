
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactuable : MonoBehaviour
{
    public float radius = 3f;
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public abstract void Interact();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Moverrata>().OpenInteractableIcon();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Moverrata>().CloseInteractableIcon();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
