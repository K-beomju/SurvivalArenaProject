using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Text curTimeText;
    [SerializeField] private Text bestTimeText;

    [SerializeField] private Image rankImage;
    [SerializeField] private Sprite[] rankSprites;

    [SerializeField] private GameTimer gameTimer;

    [SerializeField] private Button startButton;
    [SerializeField] private Button rankRutton;



    private static string encryptionKey = "your_unique_encryption_key";

    private void Awake() 
    {
        startButton.onClick.AddListener(() => SceneManager.LoadScene("GameScene"));
    }

    public void Start()
    {
        int time = (int)gameTimer.t;
        curTimeText.text = string.Format("{0:00}:{1:00}", time / 60, time % 60);

        if (PlayerPrefs.HasKey("playerScore"))
        {
            if (time > LoadTime())
            {
                SaveTime(time);
            }
        }
        else
        {
            SaveTime(time);
        }

        int bestTime = LoadTime();
        bestTimeText.text = string.Format("{0:00}:{1:00}", bestTime / 60, bestTime % 60);

        switch (time)
        {
            case int n when (n <= 180):
                rankImage.sprite = rankSprites[0];
                break;
            case int n when (n <= 600):
                rankImage.sprite = rankSprites[1];
                break;
            case int n when (n <= 900):
                rankImage.sprite = rankSprites[2];
                break;
            case int n when (n <= 1200):
                rankImage.sprite = rankSprites[3];
                break;
            default:
                rankImage.sprite = rankSprites[4];
                break;
        }

    }


    public static void SaveTime(int score)
    {
        // Convert the score to a string
        string scoreString = score.ToString();

        // Encrypt the score string
        byte[] encryptedScore = Encrypt(scoreString);

        // Convert the encrypted score to a base64 string
        string encryptedScoreString = Convert.ToBase64String(encryptedScore);

        // Save the encrypted score to PlayerPrefs
        PlayerPrefs.SetString("playerScore", encryptedScoreString);
    }

    public static int LoadTime()
    {
        // Get the encrypted score from PlayerPrefs
        string encryptedScoreString = PlayerPrefs.GetString("playerScore");

        // Convert the encrypted score string to a byte array
        byte[] encryptedScore = Convert.FromBase64String(encryptedScoreString);

        // Decrypt the score
        string scoreString = Decrypt(encryptedScore);

        // Convert the decrypted score string to an integer
        int score = int.Parse(scoreString);

        return score;
    }

    private static byte[] Encrypt(string plainText)
    {
        byte[] key = new byte[16];
        Array.Copy(Encoding.UTF8.GetBytes(encryptionKey), key, Math.Min(key.Length, encryptionKey.Length));
        byte[] iv = new byte[16];
        Array.Copy(Encoding.UTF8.GetBytes(encryptionKey), iv, Math.Min(iv.Length, encryptionKey.Length));

        // Instantiate a new Aes object to perform string symmetric encryption
        Aes encryptor = Aes.Create();

        encryptor.Mode = CipherMode.CBC;
        encryptor.Padding = PaddingMode.PKCS7;
        encryptor.Key = key;
        encryptor.IV = iv;

        // Instantiate a new MemoryStream object to contain the encrypted bytes
        MemoryStream memoryStream = new MemoryStream();

        // Instantiate a new encryptor from our Aes object
        ICryptoTransform aesEncryptor = encryptor.CreateEncryptor();

        // Instantiate a new CryptoStream object to process the data and write it to the 
        // memory stream
        CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

        // Convert the plainText string into a byte array
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

        // Encrypt the input plaintext string
        cryptoStream.Write(plainBytes, 0, plainBytes.Length);

        // Complete the encryption process
        cryptoStream.FlushFinalBlock();

        // Convert the encrypted data from a MemoryStream to a byte array
        byte[] cipherBytes = memoryStream.ToArray();

        // Close both the MemoryStream and the CryptoStream
        memoryStream.Close();
        cryptoStream.Close();

        // Return the encrypted data as a byte array
        return cipherBytes;
    }

    private static string Decrypt(byte[] cipherBytes)
    {
        byte[] key = new byte[16];
        Array.Copy(Encoding.UTF8.GetBytes(encryptionKey), key, Math.Min(key.Length, encryptionKey.Length));
        byte[] iv = new byte[16];
        Array.Copy(Encoding.UTF8.GetBytes(encryptionKey), iv, Math.Min(iv.Length, encryptionKey.Length));

        // Instantiate a new Aes object to perform string symmetric encryption
        Aes encryptor = Aes.Create();

        encryptor.Mode = CipherMode.CBC;
        encryptor.Padding = PaddingMode.PKCS7;
        encryptor.Key = key;
        encryptor.IV = iv;

        // Instantiate a new MemoryStream object to contain the encrypted bytes
        MemoryStream memoryStream = new MemoryStream(cipherBytes);

        // Instantiate a new encryptor from our Aes object
        ICryptoTransform aesDecryptor = encryptor.CreateDecryptor();

        // Instantiate a new CryptoStream object to process the data and write it to the 
        // memory stream
        CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Read);

        // Will contain decrypted plaintext
        string plainText = string.Empty;

        // Create a decryption stream
        using (StreamReader srDecrypt = new StreamReader(cryptoStream))
        {
            // Read the decrypted bytes from the decrypting stream
            // and place them in a string.
            plainText = srDecrypt.ReadToEnd();
        }

        memoryStream.Close();
        cryptoStream.Close();

        return plainText;
    }

    public void DeletePlayerPrefab(string prefabName)
    {
        if (PlayerPrefs.HasKey(prefabName))
        {
            PlayerPrefs.DeleteKey(prefabName);
            Debug.Log("PlayerPrefab " + prefabName + " deleted successfully.");
        }
        else
        {
            Debug.LogError("Error: PlayerPrefab " + prefabName + " does not exist.");
        }
    }
}
