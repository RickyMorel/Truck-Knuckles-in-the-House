using Unity.Collections;
using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    [SerializeField] private string[] _bookNames ;

    public void PlaceBook(Collider other)
    {
        if (other.gameObject.tag == "bookplacepoint")
        {
            other.transform.parent.transform.position = other.transform.position;
        }
        Debug.Log("chin");
    }
}
