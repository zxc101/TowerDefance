using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class EnemiesPack
    {
        private static List<Transform> enemies = new List<Transform>();

        private static List<EnemyModel> enemyModels;

        public static Crystal crystal;

        /// <summary>
        /// Добавляет врага в List
        /// </summary>
        /// <param name="_enemy">враг</param>
        public static void AddEnemy(Transform enemy)
        {
            enemies.Add(enemy);
            //Debug.Log(enemies.Count);
        }

        private static void InitEnemyModels()
        {
            enemyModels = new List<EnemyModel>();
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].gameObject.activeSelf) continue;
                EnemyModel model = enemies[i].GetComponent<Enemy>().Model;
                if (!enemyModels.Contains(model))
                {
                    enemyModels.Add(model);
                }
            }
        }

        /// <summary>
        /// Удаляет врага из List
        /// </summary>
        /// <param name="_enemy">враг</param>
        public static void Remove(Transform _enemy)
        {
            enemies.Remove(_enemy);
            //Debug.Log(enemies.Count);
        }

        /// <summary>
        /// Выдаёт противника по идентификатору
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Transform GetEnemy(int i)
        {
            return enemies[i];
        }

        public static List<Transform> GetSelectedEnemies()
        {
            List<Transform> selectedEnemies = new List<Transform>();
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].gameObject.activeSelf) continue;
                EnemiesNames name = enemies[i].GetComponent<Enemy>().Name;
                if (name == SelectedNameEnemies())
                {
                    selectedEnemies.Add(enemies[i]);
                }
            }
            return selectedEnemies;
        }

        public static EnemiesNames SelectedNameEnemies()
        {
            // Берётся сила пули которая соответствует кристалу за базовой значение силы
            // Подставляется ко всем моделям противников с учётом процента
            // Из получившегося находится наибольшее значение и выводится тип

            float damage = 0;
            EnemiesNames enemiesNames = EnemiesNames.Empty;
            InitEnemyModels();

            for (int i = 0; i < enemyModels.Count; i++)
            {
                for (int j = 0; j < enemyModels[i].procentsDamage.Count; j++)
                {
                    if (crystal.color == enemyModels[i].procentsDamage[j].color)
                    {
                        float newDamage = crystal.power * enemyModels[i].procentsDamage[j].procent;
                        if (newDamage > damage)
                        {
                            damage = newDamage;
                            enemiesNames = enemyModels[i].name;
                        }
                    }
                }
            }

            return enemiesNames;
        }
    }
}