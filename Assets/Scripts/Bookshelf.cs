using Autohand;
using RootMotion.Demos;
using Unity.Collections;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    [SerializeField] MeshCollider _bookshelfMeshCol;
    #region Privete Variables

    private int _correctlyPlacedBooks;

    #endregion
    public void PlaceBook(Collider other,GameObject placePoint)
    {

        if (other.TryGetComponent<Book>(out Book book) && placePoint.TryGetComponent<BookPlacePoint>(out BookPlacePoint bookplacepoint))
        {
            book.transform.parent.transform.position = placePoint.gameObject.transform.position;
            if(book._bookPlace == bookplacepoint.BookPlaceNumber)
            {
                book.transform.parent.transform.parent = placePoint.transform;
                _correctlyPlacedBooks++;
            }
        }
        else
        {
            return;
        }
        CheckBooksPlacements();
    }
    public void RemoveBook(Collider other,BookPlacePoint placePoint)
    {
        if (other.TryGetComponent<Book>(out Book book))
        {
           
            if (book._bookPlace == placePoint.BookPlaceNumber)
            {
                _correctlyPlacedBooks--;
            }
        }
        else
        {
            return;
        }
    }
    void CheckBooksPlacements()
    {
        if (_correctlyPlacedBooks >= 7)
        {
            gameObject.transform.parent.TryGetComponent<Rigidbody>(out Rigidbody parentRb);
            parentRb.isKinematic = false;
            parentRb.constraints = RigidbodyConstraints.None;
            foreach (Book Book in FindObjectsOfType<Book>())
            {
                Destroy(Book.gameObject.GetComponent<Rigidbody>());
                Book.gameObject.layer = 14;
            }
            _bookshelfMeshCol.convex = true;
        }
    }
}
