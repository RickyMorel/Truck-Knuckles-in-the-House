using Autohand;
using Unity.Collections;
using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    [SerializeField] private string[] _bookNames;
    [SerializeField] private GameObject[] _placePoints;
    public int _CorrectlyPlacedBooks;
    public void PlaceBook(Collider other,GameObject placePoint)
    {

        if (other.TryGetComponent<Book>(out Book book))
        {
            int placePointIndex = System.Array.IndexOf(_placePoints, placePoint);
            book.transform.parent.transform.position = placePoint.transform.position;
            if(book._bookname == _bookNames[placePointIndex])
            {
                book.transform.parent.transform.parent = placePoint.transform;
                _CorrectlyPlacedBooks++;
                Debug.Log("massivemuscles");
            }
        }
        else
        {
            return;
        }
        if (_CorrectlyPlacedBooks >= 7)
        {
            gameObject.transform.parent.TryGetComponent<Rigidbody>(out Rigidbody parentRb);
            parentRb.isKinematic = false;
            parentRb.constraints = RigidbodyConstraints.None;
            gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
            Debug.Log("All Books Placed Right");
        }
    }
    public void RemoveBook(Collider other,GameObject placePoint)
    {
        if (other.TryGetComponent<Book>(out Book book))
        {
            int placePointIndex = System.Array.IndexOf(_placePoints, placePoint);
           
            if (book._bookname == _bookNames[placePointIndex])
            {
                _CorrectlyPlacedBooks--;
                Debug.Log("tinymuscles");
            }
        }
        else
        {
            return;
        }
    }
}
