using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	bool allowfire = true;
	float fireRate = 0.5f;
	int bulletCount = 10;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1") && (allowfire) && bulletCount > 0)
		{
			StartCoroutine(Shoot());
		}
	}

	IEnumerator Shoot()
	{
		bulletCount -= 1;
		allowfire = false;
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		yield return new WaitForSeconds(fireRate);
		allowfire = true;
	}
}
