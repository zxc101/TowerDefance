using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour, IUpdate, ITakeDamage
    {
        [SerializeField] protected Transform eyes;
        [SerializeField] protected Transform attackDistance;
        [SerializeField] protected EnemyModel model;

        protected Transform _transform;
        protected Animator animator;

        private Transform target;

        private UpdateManager updateManager;
        private EnemiesPack enemiesPackManager;

        public EnemiesNames Name { get { return model.name; } }
        public EnemyModel Model { get { return model; } }

        protected Transform Target
        {
            get { return target; }
            set
            {
                if (value)
                {
                    animator.SetBool("IsAttack", true);
                }
                else
                {
                    animator.SetBool("IsAttack", false);
                    if (!animator.GetBool("TakeDamage"))
                    {
                        _transform.Translate(Vector2.left * model.speed * Time.deltaTime);
                    }
                }
                target = value;
            }
        }

        private int HP { get; set; }

        public void AddToPack()
        {
            EnemiesPack.AddEnemy(transform);
        }

        protected void Init()
        {
            _transform = transform;

            HP = model.HP;

            updateManager = GameObject.Find("UpdateManager").GetComponent<UpdateManager>();
            updateManager.Add(this);

            if (!GetComponent<Animator>())
            {
                animator = gameObject.AddComponent<Animator>();
                GetComponent<Animator>().runtimeAnimatorController = model.animController;
            }
            else
            {
                animator = gameObject.GetComponent<Animator>();
            }
        }
        
        public void TakeDamage(int damage)
        {
            HP -= damage;
            Debug.Log($"{name}: {HP}");
            if (HP > 0)
            {
                animator.SetTrigger("TakeDamage");
            }
            else
            {
                animator.SetBool("Dead", true);
                animator.SetTrigger("TakeDamage");
            }
        }

        public void Destroy()
        {
            updateManager.Remove(this);
            EnemiesPack.Remove(transform);
            Destroy(gameObject);
        }

        public abstract void OnUpdate();
    }
}