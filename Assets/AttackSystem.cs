using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class AttackSystem : MonoBehaviour
{
    public int damage = 5;
    private float attackRange = 10f;
    public LayerMask enemyLayer;
    public Camera cam;
    private Ray ray;
    RaycastHit hit;

    private float lastAttack = 0;
    private float attackCoolTime = 1f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    Attack();
                }
            }
        }
    }

    void Attack()
    {
        if (Time.time - lastAttack >= attackCoolTime)
        {
            if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
            {
                Hp enemyHp = hit.collider.GetComponent<Hp>();
                Debug.Log("Attack Enemy");
                enemyHp.Damage(damage);
            }
            lastAttack = Time.time;
        }
    }
}
