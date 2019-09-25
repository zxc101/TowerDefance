using Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullets
{
    public class Bullet : MonoBehaviour, IUpdate
    {
        [SerializeField] private BulletModel model;
        [SerializeField] private LayerMask mask;
        [SerializeField] private Transform fire;

        private Transform _transform;
        private UpdateManager updateManager;
        //private Animator animator;

        private float angle;
        private Vector3 direction;

        private EnemiesNames target;

        private Vector2 CenterBullet {
            get
            {
                return _transform.position + _transform.lossyScale / 2;
            }
        }

        public void SetTarget(EnemiesNames _target)
        {
            target = _target;
        }

        public void SetDirection(Vector3 _direction)
        {
            direction = _direction;
        }

        private void Start()
        {
            _transform = transform;
            updateManager = GameObject.Find("UpdateManager").GetComponent<UpdateManager>();

            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.eulerAngles = new Vector3(0, 0, angle);

            updateManager.Add(this);
            //GetComponent<SpriteRenderer>().sprite = model.sprate;
        }

        public void OnUpdate()
        {
            Move();
            RaycastHit2D hit = Physics2D.Linecast(_transform.position, CenterBullet, mask);
            if (hit)
            {
                if (hit.transform.GetComponent<Enemy>() != null)
                {
                    if (hit.transform.GetComponent<Enemy>().Name.Equals(target))
                    {
                        Attack(hit.transform);
                    }
                }
                else
                {
                    Attack(hit.transform);
                }
            }
        }

        private void Attack(Transform _target)
        {
            if(_target.GetComponent<ITakeDamage>() != null)
            {
                _target.GetComponent<ITakeDamage>().TakeDamage(model.power);
            }
            else
            {
                Instantiate(fire, transform.position, Quaternion.identity);
            }
            updateManager.Remove(this);
            Destroy(gameObject);
        }

        private void Move()
        {
            transform.localPosition += direction * model.speed * Time.deltaTime;
        }
    }
}
