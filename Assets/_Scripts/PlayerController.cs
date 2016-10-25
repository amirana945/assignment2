
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // PRIVATE VARIABLES
    private GameObject _gameControllerObject;
    private GameController _gameController;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private float _move;
    private float _jump;
    private bool _isFacingRight;
    private bool _isGrounded;
    private GameObject _camera;
    private GameObject _spawnPoint;

    // PUBLIC VARIABLES
    public float Velocity = 10f;
    public float JumpForce = 100f;
    
    public Transform SpawnPoint;

  
    public AudioSource JumpSound;
    public AudioSource DeathSound;
    public AudioSource Bonus;
    public AudioSource HurtingSound;


    void Start()
    {
        this._initialize();
    }

    
    void FixedUpdate()
    {

        if (this._isGrounded)
        {
            
            this._move = Input.GetAxis("Horizontal");
            if (this._move > 0f)
            {
                this._move = 1;
                this._isFacingRight = true;
                this._flip();
            }
            else if (this._move < 0f)
            {
                this._move = -1;
                this._isFacingRight = false;
                this._flip();
            }
            else
            {
                this._move = 0f;
            }

            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this._jump = 1f;
                this.JumpSound.Play();
            }

            this._rigidbody.AddForce(new Vector2(
                this._move * this.Velocity,
                this._jump * this.JumpForce),
                ForceMode2D.Force);

        }
        else
        {
            this._move = 0f;
            this._jump = 0f;
        }



        this._camera.transform.position = new Vector3(this._transform.position.x,this._transform.position.y,-10f);

    }

    // PRIVATE METHODS
    
    private void _initialize()
    {
        this._transform = GetComponent<Transform>();
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._move = 0f;
        this._isFacingRight = true;
        this._isGrounded = false;
       this._camera = GameObject.FindWithTag("MainCamera");
       //this._spawnPoint = GameObject.FindWithTag("SpawnPoint");
        this._gameControllerObject = GameObject.Find("GameController");
        this._gameController = this._gameControllerObject.GetComponent<GameController>() as GameController;
    }

    
    private void _flip()
    {
        if (this._isFacingRight)
        {
            this._transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            this._transform.localScale = new Vector2(-1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DeathPlat"))
        {
             
            this._transform.position = this.SpawnPoint.position;
            this.DeathSound.Play();
            this._gameController.LivesValue -= 1;
        }

        if (other.gameObject.CompareTag("Star"))
        {

            Destroy(other.gameObject);
            this.Bonus.Play();
            this._gameController.ScoreValue += 10;

        }
        if (other.gameObject.CompareTag("ghost"))
        {

            this._transform.position = this.SpawnPoint.transform.position;
            this.HurtingSound.Play();
            this._gameController.LivesValue -= 1;
        }

        }


    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            this._isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        this._isGrounded = false;
    }
}
