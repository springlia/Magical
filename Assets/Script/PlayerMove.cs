using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    CapsuleCollider2D capsulecollider;
    AudioSource audioSource;

    public AudioClip aAttack;
    public AudioClip aDamaged;

    public Magic magic;
    public GameManager gamemanager;
    
    public float moveSpeed;
    bool coolTime = false;
    bool playerDamage = false;
    

    
    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        capsulecollider = GetComponent<CapsuleCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void PlaySound(string action)
    {
        switch (action) {
            case "Attack":
                audioSource.clip = aAttack;
                break;
            case "Damaged":
                audioSource.clip = aDamaged;
                break;
        }
        audioSource.Play();
    }

    void Update()
    {
        //위 아래 이동
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(0f, verticalInput * moveSpeed);

        rigid.velocity = movement;

        //마법 사용
        if (Input.GetButtonDown("Jump") && !coolTime && !playerDamage) {
            anim.SetBool("isMagic", true);
            magic.Magical();
            Invoke("OffMagic", 1);
            coolTime = true;
            PlaySound("Attack");
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //몹에게 공격당함
        if (collision.gameObject.CompareTag("Mob"))
        {
            gamemanager.HealthDown();
            anim.SetBool("isAttack", true);
            spriteRenderer.color = new Color(1,0.5f,0.5f,1);
            playerDamage = true;
            Invoke("OffAttack", 1);
            Destroy(collision.gameObject);
            PlaySound("Damaged");
        }
        else if (collision.gameObject.CompareTag("BigMob"))
        {
            gamemanager.HealthDown();
            anim.SetBool("isAttack", true);
            spriteRenderer.color = new Color(1,0.5f,0.5f,1);
            playerDamage = true;
            Invoke("OffAttack", 1);
            Destroy(collision.gameObject);
            PlaySound("Damaged");
        }
    }

    void OffMagic()
    {
        anim.SetBool("isMagic", false);
        Invoke("CoolTime", 0.5f);
    }

    void OffAttack()
    {
        anim.SetBool("isAttack", false);
        spriteRenderer.color = new Color(1,1,1,1);
        playerDamage = false;
    }

    void CoolTime()
    {
        coolTime = false;
    }

    public void OnDie()
    {
        //색깔
        spriteRenderer.color = new Color(1,0.5f,0.5f,1);
        //애니메이션
        anim.SetBool("isAttack", true);
        //뒤집기
        spriteRenderer.flipY = true;
        //콜라이더 비활성화
        capsulecollider.enabled = false;
        Time.timeScale = 0;
        
    }
}
