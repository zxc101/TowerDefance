using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class EnemiesSpawn : MonoBehaviour
    {
        [Tooltip("Пак противников")]
        [SerializeField] private EnemiesPackModel enemiesPack;

        private List<Transform> enemies = new List<Transform>();

        public List<Transform> Enemies { get { return enemies; } }

        /// <summary>
        /// Инициализация
        /// </summary>
        private void Init()
        {
            for (int i = 0; i < enemiesPack.waves.Length; i++)
                for (int j = 0; j < enemiesPack.waves[i].groups.Length; j++)
                    for (int c = 0; c < enemiesPack.waves[i].groups[j].count; c++)
                        Spawn(enemiesPack.waves[i].groups[j].enemyModel.prefab);
        }

        /// <summary>
        /// Добавляет противников в лист
        /// </summary>
        /// <param name="GO_Enemy">противник</param>
        private void Spawn(Transform _enemy)
        {
            Transform enemy = Instantiate(_enemy.gameObject, transform).transform;
            enemy.GetComponent<Enemy>().AddToPack();
            enemy.gameObject.SetActive(false);
            //EnemiesPackManager.Add(enemy);
        }

        private void Awake()
        {
            Init();
            StartCoroutine(Activate());
        }

        /// <summary>
        /// Активатор волн
        /// </summary>
        /// <param name="waves">Волны</param>
        /// <returns></returns>
        private IEnumerator Activate()
        {
            for (int i = 0; i < enemiesPack.waves.Length; i++)
            {
                yield return new WaitForSeconds(enemiesPack.waves[i].respawnWave);
                // Активируем волну
                yield return StartCoroutine(WavesActivate(enemiesPack.waves[i].groups, i));
            }
        }

        /// <summary>
        /// Активатор волны
        /// </summary>
        /// <param name="groups">группы в волне</param>
        /// <param name="numberWave">номер волны</param>
        /// <returns></returns>
        private IEnumerator WavesActivate(Group[] groups, int numberWave)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                // Активируем группу
                yield return StartCoroutine(GroupsActivate(groups[i], numberWave, i));

                if (i != groups.Length - 1)
                {
                    yield return new WaitForSeconds(groups[i].respawnGroup);
                }
            }
        }

        /// <summary>
        /// Активатор группы
        /// </summary>
        /// <param name="group">группа</param>
        /// <param name="numberWave">номер волны</param>
        /// <param name="numberGroup">номер группы</param>
        /// <returns></returns>
        private IEnumerator GroupsActivate(Group group, int numberWave, int numberGroup)
        {
            for (int countCharacters, i = 0; i < group.count; i++)
            {
                countCharacters = CountCharacters(numberWave) + CountCharacters(enemiesPack.waves[numberWave], numberGroup) + i;
                // Активируем врага
                EnemiesPack.GetEnemy(countCharacters).gameObject.SetActive(true);

                if (i != group.count - 1)
                {
                    yield return new WaitForSeconds(group.respawnCharacter);
                }
            }
        }

        /// <summary>
        /// Количество врагов вплоть до определённой волны
        /// </summary>
        /// <param name="numverWave"></param>
        /// <returns></returns>
        private int CountCharacters(int numverWave)
        {
            int count = 0;
            for (int i = 0; i < numverWave; i++)
            {
                count += CountCharacters(enemiesPack.waves[i]);
            }
            return count;
        }

        /// <summary>
        /// Количество врагов в определённой волне
        /// </summary>
        /// <param name="wave">волна</param>
        /// <returns></returns>
        private int CountCharacters(Wave wave)
        {
            int count = 0;
            for (int i = 0; i < wave.groups.Length; i++)
            {
                count += wave.groups[i].count;
            }
            return count;
        }

        /// <summary>
        /// Количество врагов в определённой волне до определённой группы
        /// </summary>
        /// <param name="wave">волна</param>
        /// <returns></returns>
        private int CountCharacters(Wave wave, int numberGroup)
        {
            int count = 0;
            for (int i = 0; i < numberGroup; i++)
            {
                count += wave.groups[i].count;
            }
            return count;
        }
    }
}