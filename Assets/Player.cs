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
    }
    // ====================================== Private implementation < ==//
    // ------------------------------------------------ Behaviour << --==//
    // ........................................ Initialization <<< ..--==//
    private void Awake() {
        SetupReferencesToComponents();
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
        // '''''''''''''''''''''''''''''''''''''''''''''' Regenerate health
        health = Mathf.Clamp(health + 1.0f * Time.deltaTime,
                             minHealth, maxHealth);
        // ''''''''''''''''''''''''''''''''''''''''''''' Write health value
        healthUI.text = "(" + ((int)health).ToString() + ")";
        // ''''''''''''''''''''''''''''''''''''''''''''''''''''''' End hame
        if (Mathf.Approximately(health, 0.0f)) {
            healthUI.text = "GAME OVER";
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
        }
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

    public float getVelocity()
    {
        return velocity;
    }
    public void setHealth(float currentHealth, float max)
    {
        maxHealth = max;
        health = currentHealth; 

    }


    public float getHealth()
    {
        return health;
    }

}
// ///////////////////////////////////////////////////////////////////// //
