using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mob2 : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsulecollider;
    AudioSource audioSource;

    public GameManager gamemanager;
    public Magic magic;
    public AudioClip a2Mob;

    float mobmoveSpeed = 4;
    int mobHP;

    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        magic = FindObjectOfType<Magic>();

        mobHP = 1;
    }

    void PlaySound(string action)
    {
        switch (action) {
            case "Mob":
                audioSource.clip = a2Mob;
                break;
        }
        audioSource.Play();
    }

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsulecollider = GetComponent<CapsuleCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //몹 피격
        if (collision.gameObject.CompareTag("Magic"))
        {
            Damaged();
            if (SceneManager.GetActiveScene().name == "Game_hard")
                gamemanager.score += 30;
            else if (SceneManager.GetActiveScene().name == "Game_easy")
                gamemanager.score += 10;
            
        }
    }

    public void Damaged()
    {
        if (mobHP == 2)
        {
            PlaySound("Mob");
            mobHP = 1;
        }
        else if (mobHP == 1)
        {
            PlaySound("Mob");
            //투명
            spriteRenderer.color = new Color(1,1,1,0.4f);
            //뒤집기
            spriteRenderer.flipY = true;
            //콜라이더 비활성화
            capsulecollider.enabled = false;
            //죽는 이펙트
            rigid.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            //사망
            Invoke("DeActive",5);
        }
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.tag == "Delete")
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {      
        Vector3 currentPosition = transform.position;
        currentPosition.x += mobmoveSpeed * Time.deltaTime * (-1);
        transform.position = currentPosition;
    }

    void DeActive()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        StopAllCoroutines(); // 해당 몹과 관련된 모든 코루틴 중지
    }
}
