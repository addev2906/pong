using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    public Rigidbody2D ballRB;
    private Vector2 ballDir;
    [SerializeField] float ballSpeed;
    public Text Player1Score;
    public Text Player2Score;
    public int score1 = 0;
    public int score2 = 0;
    private bool isPlaying = false;
    public LayerMask mask;
    public RaycastHit2D hit;
    public RaycastHit2D hit2;
    public Vector2 hitPoint;
    public ComputerAI ai;
    public ParticleSystem particles;
    [System.Obsolete]
    public AudioScript au;
    public EventMangerScript events;
    void Start(){transform.position = new Vector3(-0, -0.07f, 0);}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPlaying && events.gameEnded == false)
        {
            isPlaying = true;
            Launch();
        }
        if (SceneManager.GetActiveScene().name=="SinglePlayer")
        {
            hit = Physics2D.Raycast(transform.position, ballRB.velocity, mask);

            if (hit && hit.collider.name == "AI_Trigger" && ballRB.velocity.normalized.x > 0)
            {
                ai.seek();
                hitPoint = hit.point;
            }
            if (hit && hit.collider.tag == "FloorCeil" && ballRB.velocity.normalized.x > 0)
            {

                hit2 = Physics2D.Raycast(hit.point, Vector2.Reflect(ballRB.velocity, new Vector2(0, hit.point.y)), mask);
                Debug.DrawRay(hit.point, new Vector2(ballRB.velocity.x, -ballRB.velocity.y), Color.red);
                if (hit2)
                {
                    ai.seek();
                    hitPoint = hit2.point;
                }
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        isPlaying = false;
        if (collision.name == "WallRight"&&collision.tag=="PointWall")
        {
            score1 += 1;
            Player1Score.text = score1.ToString();
            transform.position = new Vector3(-0, -0.07f, 0);
            ballRB.velocity = Vector2.zero;
            au.score();
            events.EndGame();
        }

        if (collision.name == "WallLeft" && collision.tag == "PointWall")
        {
            score2 += 1;
            Player2Score.text = score2.ToString();
            transform.position = new Vector3(-0, -0.07f, 0);
            ballRB.velocity = Vector2.zero;
            au.score();
            events.EndGame();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballRB.velocity += ballRB.velocity.normalized * 0.7f;
        particles.Play();
        float dotProdcut = Vector2.Dot(ballRB.velocity.normalized,new Vector2(1,0));
        if (dotProdcut == 1){ballRB.velocity += new Vector2(0,-1);}
        if (dotProdcut == -1){ballRB.velocity += new Vector2(0, 1);}
        if (collision.collider.tag == "Player"){au.paddle();}
        if (collision.collider.tag == "FloorCeil"){ au.wall();}


    }

    
    private void Launch()
    {
        
        
        //ballDir = new Vector2(-11, Random.RandomRange(-5, 5)).normalized;
        int x = flipCoin();
        int y = flipCoin();
        Debug.Log(x);
        if (x == 0)
        {
            //left
            if (y == 0) { ballDir = new Vector2(-11, Random.Range(1, 5)).normalized; }
            if (y == 1) { ballDir = (new Vector2(-11, Random.Range(1, 5)).normalized)*(-1); }

        }
        if (x == 1)
        {
            //right
            if (y == 0) { ballDir = new Vector2(11, Random.Range(1, 5)).normalized; }
            if (y == 1) { ballDir = (new Vector2(11, Random.Range(1, 5)).normalized) * (-1); }

        }

        ballRB.velocity = (ballDir * ballSpeed) * Time.deltaTime;

    }

    private int flipCoin()
    {
        int digit = Random.Range(0, 2);
        return digit;
    }
}
