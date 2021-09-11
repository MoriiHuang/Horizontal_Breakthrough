using UnityEngine;
using System.Collections;
public class Bandit : MonoBehaviour {

    [SerializeField] protected float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;

    public static Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    public static bool                m_combatIdle = false;
    private bool                m_isDead = false;
    private float timeBtwAttack=0.5f;
    public float startTimeBtwAttack=3f;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    private int damage;
    public static int damageplus;
    public static int damageptmp;
    private int extrajump;
    public static int extrajumpplus=2;
    private float batTime=0;
    protected double t1;
    protected double t2;
    private Animator m_skill;
    private Animator m_skilll2;
    public GameObject child;
    public GameObject child2;
    private Vector3 child2pos;
    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        //damage=damageplus;
        //child=transform.Find("Skill").GetComponent<GameObject>();
        //m_skill=transform.Find("Skill").GetComponent<Animator>();
        m_skill=child.GetComponent<Animator>();
        m_skilll2=child2.GetComponent<Animator>();
        child2pos=child2.transform.position-transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        damage=damageplus;
        m_speed=4.0f;
        timeBtwAttack-=Time.deltaTime;
        batTime-=Time.deltaTime;
        if(batTime<0){
            m_combatIdle=false;
        }
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State()) {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if(m_grounded && !m_groundSensor.State()) {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0){
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            t2 = Time.realtimeSinceStartup;
            if (t2 - t1 < 0.2f &&m_grounded)
            {
                if(Input.GetKey(KeyCode.D))
                {
                    m_speed=8;
                }
                //Debug.Log("双击");
            }
            t1 = t2;
        }
        else if (inputX < 0){
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            t2 = Time.realtimeSinceStartup;
            if (t2 - t1 < 0.2f && m_grounded)
            {
                if(Input.GetKey(KeyCode.A))
                {
                    m_speed=8;
                }

            }
            t1 = t2;}

        // Move
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        // -- Handle Animations --
        //Death
        if (Input.GetKeyDown("i") &&MagicBar.MagicCur>0) {
           child2.SetActive(true);
           m_skilll2.SetTrigger("Skill2");
            Collider2D[] enimiesToDamage = Physics2D.OverlapCircleAll(child2.transform.position,attackRange*0.5f,whatIsEnemies);
            for(int i =0;i<enimiesToDamage.Length;i++){
                    enimiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage*2);
                    if(enimiesToDamage[i].GetComponent<Enemy>().CompareTag("boss")){
                    enimiesToDamage[i].GetComponent<Boss>().m_animator.SetTrigger("hit");
                    enimiesToDamage[i].GetComponent<Boss>().TakeDamage(damage);}
                    Camera.main.GetComponent<CameraShake>().isshakeCamera=true;
                }
            MagicBar.MagicCur-=5;
            //child.SetActive(false);
            timeBtwAttack=startTimeBtwAttack;
        }
        //Hurt
        else if (Input.GetKeyDown("l") && MagicBar.MagicCur>0){
            child.SetActive(true);
            m_skill.SetTrigger("Skill");
            Collider2D[] enimiesToDamage = Physics2D.OverlapCircleAll(child.transform.position,attackRange*2,whatIsEnemies);
            for(int i =0;i<enimiesToDamage.Length;i++){
                    enimiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage*2);
                    if(enimiesToDamage[i].GetComponent<Enemy>().CompareTag("boss")){
                    enimiesToDamage[i].GetComponent<Boss>().m_animator.SetTrigger("hit");
                    enimiesToDamage[i].GetComponent<Boss>().TakeDamage(damage);}
                    Camera.main.GetComponent<CameraShake>().isshakeCamera=true;
                }
            MagicBar.MagicCur-=5;
            //child.SetActive(false);
            timeBtwAttack=startTimeBtwAttack;
        }
        //Attack
        else if(Input.GetKeyDown("j")) {
                Debug.Log(damageplus);
                m_animator.SetTrigger("Attack");
                //Debug.Log(damage);
                if(timeBtwAttack<=0){
                Collider2D[] enimiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatIsEnemies);
                for(int i =0;i<enimiesToDamage.Length;i++){
                    enimiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    if(enimiesToDamage[i].GetComponent<Enemy>().CompareTag("boss")){
                    enimiesToDamage[i].GetComponent<Boss>().m_animator.SetTrigger("hit");
                    enimiesToDamage[i].GetComponent<Boss>().TakeDamage(damage);}
                    Camera.main.GetComponent<CameraShake>().isshakeCamera=true;
                }
                timeBtwAttack=startTimeBtwAttack;
                }
                }
        //Change between idle and combat idle
        else if (Input.GetKeyDown("f"))
            m_combatIdle = !m_combatIdle;

        //Jump
        else if (Input.GetKeyDown("space") && m_grounded) {
            extrajump=extrajumpplus;
            m_animator.SetTrigger("Jump");
            m_grounded=false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = Vector2.up*m_jumpForce;
            m_groundSensor.Disable(0.2f);
            extrajump--;
        }
        else if(Input.GetKeyDown("space") && extrajump>0 && !m_grounded){
            m_animator.SetTrigger("Recover");
            //m_animator.SetTrigger("Jump");
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = Vector2.up*m_jumpForce;
            extrajump--;
        }
        /*else if(m_grounded==true){
            extrajump=2;
            if(Input.GetKeyDown("space") && extrajump>0){
                m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
                extrajump-=1;
            }
            else if(Input.GetKeyDown("space") && extrajump==0 && m_grounded==true){
                m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            }
        }*/
        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);

        //Combat Idle
        else if (Input.GetKeyDown("q")){

            m_animator.SetTrigger("Cambat");
            m_combatIdle=true;
            batTime=2.0f;
            MagicBar.MagicCur-=1;
            }

        //Idle
        else{
            m_animator.SetInteger("AnimState", 0);
            }
        if(transform.position.y<-10){
            HealthBar.healthCur=-1;
        }
        if(HealthBar.healthCur<=0){
            extrajumpplus=2;
            damageplus=damageptmp;
            Destroy(gameObject);
            InventoryManager.Zero();
            GameManager.Instance.LoadScence("dead");
            HealthBar.healthCur=HealthBar.healthMax;
        }
        if(child2){
            child2.transform.Translate(-1f*Time.deltaTime,0,0);
            if(timeBtwAttack<-1){
                child2.SetActive(false);
                child2.transform.position=child2pos+transform.position;
            }
        }  
    }
    void OnDrawGizmosSelected() {
            Gizmos.color =Color.yellow;
            Gizmos.DrawWireSphere(attackPos.position,attackRange);
        }
}
