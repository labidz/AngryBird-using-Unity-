using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 _initialPosition;
    private bool _birdLaunced;
    private float _idleTime;

    [SerializeField] private float _launchPower = 2;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if (Input.GetMouseButton(0))
        {
            GetComponent<SpriteRenderer>().color = Color.white;

            Vector2 directiontoinitialposition = _initialPosition - transform.position;

            GetComponent<Rigidbody2D>().AddForce(directiontoinitialposition * _launchPower);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<LineRenderer>().enabled = false;
            _birdLaunced = true;
            Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newpos.x, newpos.y);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        
    }
   
}
