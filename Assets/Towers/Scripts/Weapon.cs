using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

using Enemies;

namespace Towers
{
    public class Weapon : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Transform _transform;

        [SerializeField] private Transform energyLaser;
        [SerializeField] private List<EnemyModel> enemyModels;
        [SerializeField] private Trunk trunk;

        private Crystal crystal;
        private ColorCrystal color;

        private Vector3 dir;
        private float oldAngle;
        private float newAngle;

        private bool isActive;

        private List<Transform> enemiesPack;

        //private List<EnemyModel> enemyModels;

        private void Start()
        {
            _transform = transform;

            enemiesPack = GameObject.Find("EnemyPack").GetComponent<EnemiesSpawn>().Enemies;

            isActive = true;

            StabileAngle();
            StartCoroutine(Shoot());
        }

        //private void Update()
        //{
        //    if (isActive)
        //    {
        //        foreach (Transform t in EnemiesPack.GetSelectedEnemies())
        //        {
        //            Debug.Log(t.name);
        //        }
        //    }
        //}

        private IEnumerator Shoot()
        {
            List<Transform> selectedEnemies;
            while (true)
            {
                if (isActive)
                {
                    selectedEnemies = EnemiesPack.GetSelectedEnemies();

                    if (selectedEnemies.Count > 0)
                    {
                        trunk.Shoot(selectedEnemies[Random.Range(0, selectedEnemies.Count)]);
                    }
                }
                yield return new WaitForSeconds(crystal.firingSpeed);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            dir = Input.mousePosition - Camera.main.WorldToScreenPoint(_transform.position);
            oldAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - _transform.eulerAngles.z;
            if(crystal != null)
            {
                crystal.Tumbler();
            }
            energyLaser.gameObject.SetActive(false);
            isActive = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            dir = Input.mousePosition - Camera.main.WorldToScreenPoint(_transform.position);
            newAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            _transform.eulerAngles = new Vector3(0, 0, newAngle - oldAngle);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            StabileAngle();
            energyLaser.gameObject.SetActive(true);
            isActive = true;
        }

        private void StabileAngle()
        {
            int numberCrystal = 1;
            float angle = _transform.eulerAngles.z;

            while (angle - 45 > 0)
            {
                angle -= 45;
                numberCrystal++;
            }
            angle = 0;
            for(int i = 0; i < numberCrystal; i++)
            {
                if(i == 0)
                {
                    angle += 22.5f;
                }
                else
                {
                    angle += 45;
                }
            }
            _transform.eulerAngles = Vector3.forward * angle;
            SetCrystal(numberCrystal-1);
        }

        private void SetCrystal(int numberCrystal)
        {
            if (transform.GetChild(numberCrystal).GetComponent<Crystal>())
            {
                crystal = transform.GetChild(numberCrystal).GetComponent<Crystal>();
                EnemiesPack.crystal = crystal;
                crystal.Tumbler();
                color = crystal.color;
            }
        }
    }
}
