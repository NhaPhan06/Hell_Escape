using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float boostDuration = 5f; // Thời gian tăng tốc tạm thời
    public float boostMultiplier = 2f; // Tốc độ tăng gấp đôi
    [SerializeField] private AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng va chạm có tag là "Player" (nhân vật của bạn)
        if (other.CompareTag("Warrior"))
        {
            // Thực hiện tăng tốc tạm thời cho nhân vật
            Movement playerController = other.GetComponent<Movement>();
            if (playerController != null)
            {
                audioSource.Play();
                playerController.ApplySpeedBoost(boostDuration, boostMultiplier);
            }

            // Xóa item sau khi nhân vật chạm vào
            Destroy(gameObject);
        }
    }
}
