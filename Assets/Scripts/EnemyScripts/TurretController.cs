using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject bulletPrefab; // 子弹预制体
    public Transform firePoint;     // 发射点
    public float fireInterval = 2f; // 发射间隔
    public float bulletLifetime = 5f; // 子弹存活时间
    public float bulletSpeed = 10f;  // 子弹速度

    private void Start()
    {
        // 开始自动循环发射
        InvokeRepeating(nameof(FireBullet), fireInterval, fireInterval);
    }

    private void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // 实例化子弹
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // 给子弹施加速度
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = firePoint.forward * bulletSpeed; // 子弹沿着发射点的方向飞出
            }

            // 自动销毁子弹
            Destroy(bullet, bulletLifetime);
        }
    }
}
