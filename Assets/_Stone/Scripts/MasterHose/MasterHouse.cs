using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

namespace _Stone
{
    public interface IBallonHouse
    {
        void Sprint();
    }
    [RequireComponent(typeof(Rigidbody2D))]
    public class MasterHouse : Creature.CreatureBase,IBallonHouse
    {
        public static MasterHouse instance { get; private set; }
        [SerializeField] private bool AltoPilot = false;

        [SerializeField] private int Score = 0;

        [SerializeField] private ParticleSystem FlyBallonEffect;
        [SerializeField] private Rigidbody2D rb => GetComponent<Rigidbody2D>();

        [SerializeField] private float GravityBoost;

        [SerializeField] private UnityEngine.UI.Slider HeightSlider;

        [SerializeField] private spell SprintSpell;
        private void Awake()
        {
            _Stone.Loader.Load();
        }
        private void Start()
        {
            instance = this;
            HeightSlider.maxValue = 0;
            HeightSlider.minValue = -3.2f;



            SprintSpell.Event = (SpellMethod)_Stone.Loader.BaloonEvents[SprintSpell.MethodName].CreateDelegate(typeof(SpellMethod));
        }

        private void Update()
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
            HeightSlider.value = transform.position.y;

            if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.UpArrow))
            {
                FlyUp();
            }
            if (Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.DownArrow))
            {
                FlyDown();
            }
            if (rb.gravityScale <= 0.01f)
            {
                rb.gravityScale += Time.deltaTime;

            }

   

        }

        private void FlyDown()
        {
            rb.gravityScale += GravityBoost;
        }

        public void AddScore(int Amount)
        {
            Score += Amount;
        }

        public void FlyUp()
        {
            if (FlyBallonEffect)
            {
                FlyBallonEffect.Play();
            }
            rb.gravityScale -= GravityBoost;



        }

        public void Sprint()
        {
            CombatMaster.CallSpell(SprintSpell);

        }
    }

}

