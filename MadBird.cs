using UnityEngine;
using UnityEngine.SceneManagement;

public class MadBird : MonoBehaviour
{

    private Vector3 _initialPosition;
    Quaternion startRotation;
    private bool _isBirdLaunched;
    //private float _sittingTime;

    Rigidbody2D rb;
    private Enemy[] _enemies;
    Health health;
 

    public AudioSource LaunchedSound;
    public AudioSource LaunchingSound;
    private float _levelTimer;

    [SerializeField] private float _LaunchPower = 500f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _initialPosition = transform.position;  // Bu kod ile karakterin pozisyonunu sabitledik istediðimiz zaman _initialPosition ile sýfýrlayabilmek için
        startRotation = transform.rotation;
        _enemies = FindObjectsOfType<Enemy>();
        health = GetComponent<Health>();
    }
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition); // karakterin hedef oklarýnýn yönleri
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        if (_isBirdLaunched)
        {
            _levelTimer += Time.deltaTime;
            
            restartLevel();
          
        }


        if (transform.position.y > 10 ||
            transform.position.y < -10 ||
            transform.position.x > 20 ||
            transform.position.x < -30 || _levelTimer > 4)
        {
            restartLevel();
        }



        //if (transform.position.y > 10 ||
        //    transform.position.y < -10 ||
        //    transform.position.x > 20 ||
        //    transform.position.x < -30)
        //    //_sittingTime > 7)  // Eger kus kamera acýsýndan cok fazla cýkarsa sahneyi resetle ya da yere düsmesinin üzerinden 3 saniye gecerse
        //{
        //    string currentSceneName = SceneManager.GetActiveScene().name;
        //    SceneManager.LoadScene(currentSceneName);
        //}
    }
    private void restartLevel()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null && _levelTimer > 6)
            {
                _isBirdLaunched = false;
                transform.position = _initialPosition;
                transform.rotation = startRotation;
                _levelTimer = 0;
                rb.velocity = Vector3.zero;
                rb.gravityScale = 0;              
                health.looseHealth();

            }
        }
    }


    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
        GetComponent<PolygonCollider2D>().enabled = false;
        LaunchingSound.Play();
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToÝnitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToÝnitialPosition * _LaunchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<PolygonCollider2D>().enabled = true;
        LaunchedSound.Play();
        _isBirdLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
