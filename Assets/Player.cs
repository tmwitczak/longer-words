// ////////////////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// /////////////////////////////////////////////////////// Class: Player //
public class Player : MonoBehaviour {
    // ============================================ Public interface < ==//
    // ------------------------------------------------ Behaviour << --==//
    public void Move(Vector3 force) {
        rigidbody.AddForce(velocity * force.normalized);
    }
    public void Attack(Vector3 enemy) {
        Vector3 direction = (enemy - transform.position)
                            .normalized;
        GameObject fireball = Instantiate(fireballPrefab,
                                          transform.position,
                                          Quaternion.identity);
        Physics.IgnoreCollision(GetComponent<Collider>(),
                                fireball.GetComponent<Collider>());
        fireball.GetComponent<Rigidbody>().velocity = 1000.0f * direction 
                                                      * Time.deltaTime;

        FindObjectOfType<AudioManager>().Play(GetComponents<AudioSource>()[0], "shoot");
    }
    // ====================================== Private implementation < ==//
    // ------------------------------------------------ Behaviour << --==//
    // ........................................ Initialization <<< ..--==//
    private void Awake() {
        SetupReferencesToComponents();
        GetComponents<AudioSource>()[2].volume = 0.0f; 
    }
    private void SetupReferencesToComponents() {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Start() {
        healthUI = Instantiate(uiTextPrefab, new Vector3(0, 0, 0),
                               Quaternion.identity).GetComponent<Text>();
        healthUI.transform.parent = GameObject.Find("Canvas").transform;
        healthUI.text = health.ToString();
    }
    // ........................................... Update loop <<< ..--==//
    void Update() {
        GetComponents<AudioSource>()[1].volume = 
                Mathf.Clamp((rigidbody.velocity.magnitude / 5.0f), 0.0f, 0.2f);
        // '''''''''''''''''''''''''''''''''''''''''''''' Regenerate health
        health = Mathf.Clamp(health + 1.0f * Time.deltaTime,
                             minHealth, maxHealth);
        // ''''''''''''''''''''''''''''''''''''''''''''' Write health value
        healthUI.text = "(" + ((int)health).ToString() + ")";
        // ''''''''''''''''''''''''''''''''''''''''''''''''''''''' End hame
        if (Mathf.Approximately(health, 0.0f)) {
            healthUI.text = "GAME OVER";

            GameplayManager gameplayManager = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
            float score = gameplayManager.getCorrectLettres();

            if (SaveSystem.LoadScore().getHighScore() < score)
            {
                SaveSystem.SaveScore(score);
            }

            Destroy(gameObject);
        }
        // '''''''''''''''''''''''''''''''''''''''''''''''''' Render the UI
        Vector3 uiPos = Camera.main.WorldToScreenPoint(transform.position);
        healthUI.transform.position = uiPos + new Vector3(0, 75, 0);
        healthUI.color = new Color(0.45f, 0.75f, 0.82f);
    }
    // ............................................ Collisions <<< ..--==//
    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "Enemy") {
            health -= 20 * Time.deltaTime;

            GetComponents<AudioSource>()[2].volume = 1.0f; 
        }
        else {
            GetComponents<AudioSource>()[2].volume = 0.0f; 
        }
    }
    void OnCollisionExit(Collision collision) {
        GetComponents<AudioSource>()[2].volume = 0.0f; 
    }


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);

        FindObjectOfType<AudioManager>().Play(null, "gui");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;
        velocity = data.velocity;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
    // ----------------------------------------------------- Data << --==//
    // ............................................ Parameters <<< ..--==//
    [SerializeField] public GameObject fireballPrefab;
    [SerializeField] private GameObject uiTextPrefab;
    private CameraShake cameraShake;
    [SerializeField] private float velocity;
    // ............................................ Components <<< ..--==//
    private new Rigidbody rigidbody;
    // ................................................. Other <<< ..--==//
    private Text healthUI;
    private float health = 100.0f;
    private float maxHealth = 100.0f;
    const float minHealth = 0.0f;

    public void setVelocity(float multiplier)
    {
        velocity *= multiplier;
    }

    public void addVelocity(float multiplier)
    {
        velocity += multiplier;
    }

    public float getVelocity()
    {
        return velocity;
    }
    public void setHealth(float currentHealth, float max)
    {
        maxHealth = max;
        health = currentHealth; 

    }

    public float getMaxHealth()
    {
        return maxHealth;
    }


    public float getHealth()
    {
        return health;
    }

}
// ///////////////////////////////////////////////////////////////////// //
