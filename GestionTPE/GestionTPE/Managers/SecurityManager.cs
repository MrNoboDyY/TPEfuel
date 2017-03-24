using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestionTPE.Managers
{
    public class SecurityManager
    {

        private static volatile SecurityManager instance;
        private static object syncRoot = new Object();

        /* partie 1 de la clef */
        private static string keyPart1 = "abcd1234efgh";

        /* Vecteur d'Initialisation */
        private static string strIv = "ivIVivIVivIVivIV";


        private SecurityManager() { }

        public static SecurityManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SecurityManager();
                    }
                }
                return instance;
            }
        }


        /*generer une clef a partir de numtpe et codesite*/
        public string encrypt(int token, string clearText)
        {
            /*cleartext à chiffrer est placé ds un tab d'octes bytes*/
            byte[] plainText = Encoding.UTF8.GetBytes(clearText);

            /* recup de la partie 2  de la Clef */
            //using (var context = EntityManager.createContext(codesite))
            //{
            //token = context.ONLINESERVERTOKEN.FirstOrDefault(o => o.TERNUM == numtpe).OSTTOKEN;
            //}
            /* placer la clef chiffrement ds un tab byte[] key d'octets 
             avec Encoding */
            byte[] key = new byte[16];
            Encoding.UTF8.GetBytes(keyPart1).CopyTo(key, 0);

            /* convertion du token  */
            byte[] tokenBytes = BitConverter.GetBytes(token);
            for (int i = 0;
                     i < 4;
                     i++)
            {
                key[15 - i] = tokenBytes[i];
            }

            /* placer le vecteur d'initialisation strIv ds un tableau d'octets */
            byte[] iv = Encoding.UTF8.GetBytes(strIv);

            /* initialisation d'une instance de Securité*/
            RijndaelManaged rijndael = new RijndaelManaged();

            /* définition du mode de chiffrement par bloc utilisé*/
            rijndael.Mode = CipherMode.CBC;

            /* definir le type de remplissage/padding à utiliser*/
            rijndael.Padding = PaddingMode.Zeros;

            /*créer le chiffreur AES - Rijndael */
            ICryptoTransform aesEncryptor = rijndael.CreateEncryptor(key, iv);

            /* MemoryStream/flux memoire de sauvegarde */
            MemoryStream ms = new MemoryStream();

            /* écriture des données chiffrées ds le MemoryStream/flux memoire de sauvegarde avec CryptoStream.Write */
            CryptoStream cs = new CryptoStream(ms, aesEncryptor, CryptoStreamMode.Write);
            cs.Write(plainText, 0, plainText.Length);
            cs.FlushFinalBlock();

            /* placer les données chiffrées dans un tab d'octet */
            byte[] CipherBytes = ms.ToArray();

            /* fermer me memoryStream ,fermer le cryptoStream */
            ms.Close();
            cs.Close();

            return Convert.ToBase64String(CipherBytes);

        }

        /* décryptage de la clef */
        public string decrypt(int token, string cipherText)
        {
            /*placer le text à déchiffrer dans un tab byte[] d'octets */
            byte[] ciphereData = Convert.FromBase64String(cipherText);

            /* placer la clef de chiffrement ds un tab byte[] d'octets */
            byte[] key = new byte[16];
            Encoding.UTF8.GetBytes(keyPart1).CopyTo(key, 0);

            /* convertion du token  */
            byte[] tokenBytes = BitConverter.GetBytes(token);
            for (int i = 0; i < 4; i++)
            {
                key[15 - i] = tokenBytes[i];
            }

            /* mettre le vect d'initialisation dans un byte */
            byte[] iv = Encoding.UTF8.GetBytes(strIv);

            /* initialisation d'une instance de Sécurité */
            RijndaelManaged rijndael = new RijndaelManaged();

            /* specifier le mode de chiffrement */
            rijndael.Mode = CipherMode.CBC;

            /* padding de chiffrement */
            rijndael.Padding = PaddingMode.Zeros;

            /* utilisation du Stream / FluxMémoire */
            ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv);
            MemoryStream ms = new MemoryStream(ciphereData);
            /* lecture des données cryptées du flux */
            CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);

            /* placer les données dechiffrées ds un tab byte[] */
            byte[] plainTextData = new byte[ciphereData.Length];

            int decryptedByteCount = cs.Read(plainTextData, 0, plainTextData.Length);

            ms.Close();
            cs.Close();

            return System.Text.Encoding.Default.GetString(plainTextData).Replace("\0",string.Empty);

        }
    }
}

