using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiffrerDechiffrer
{
    /* pour la question sur le vecteur d'initialisation de ce que je comprends la clef génère un key stream fixe pour une clef x. 
     * le key stream sert a changer les bytes du  message avec un xor entre les bytes du key  stream et du message et le vecteur
     * d'initialisation sert a modifier périodiquement le key stream pour éviter que quelqu'un puisse faire de l'ingénérie
     * inverse sur le keystream à l'aide de répétition prévisible dans le message. 
     */

    /*
     * pour la question 5  on ne pourrait pas craker le message avec la meme clef, car ils utilisent un algorithme différent pour
     * générer le key stream ce qui fait que le xor entre les bytes donnerait un résultat différent.
     */
    public partial class Form1 : Form
    {
        public enum NomAlgorithme
        {
            Aucun, TripleDES, AES, DSA, RSA
        }

        Object algo { get; set; } = null; // Permet de conserver la clé intacte entre les opérations
        byte[] hash { get; set; } = null; // Utile pour l'algorithme DSA
        public Form1()
        {
            InitializeComponent();
        }



        private void algorithme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)this.algorithme.SelectedItem == NomAlgorithme.Aucun.ToString())
            {
                // On vide le contenu du champ cles
                this.cles.Text = "";
                algo = null;
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.TripleDES.ToString())
            {
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.GenerateKey();
                tdes.GenerateIV(); // On génère aussi un vecteur d'initialisation
                this.cles.Text = BitConverter.ToString(tdes.Key) + "   (" + tdes.KeySize + " bits)";
               
                algo = tdes;
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.AES.ToString())
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.GenerateKey();
                aes.GenerateIV();
                this.cles.Text = BitConverter.ToString(aes.Key) + "   (" + aes.KeySize + " bits)";

                algo= aes;

            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.DSA.ToString())
            {
                DSACryptoServiceProvider dsa = new DSACryptoServiceProvider(1024);
                this.cles.Text = dsa.ToXmlString(true) + "    (" + dsa.KeySize + " bits)";
                dsa.ExportParameters(true);
                algo = dsa;
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.RSA.ToString())
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                this.cles.Text = rsa.ToXmlString(true) + "    (" + rsa.KeySize + " bits)";
                algo = rsa;
              
                // Coder ici : déterminer et afficher la clé pour cet algorithme
            }
        }
        private void lblAlgoSelection_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cles.ReadOnly = true;
        }

        private void chiffrer_Click(object sender, EventArgs e)
        {
            if ((string)this.algorithme.SelectedItem == NomAlgorithme.Aucun.ToString())
            {
                // Puisqu'aucun algorithme n'est choisi, on conserve le texte de l'utilisateur en sortie
                this.texteTransforme.Text = this.texteUtilisateur.Text;
                return;
            }

            byte[] donneesBrutes = UTF8Encoding.UTF8.GetBytes(this.texteUtilisateur.Text);
            byte[] donneesTransformees = null;

            if ((string)this.algorithme.SelectedItem == NomAlgorithme.TripleDES.ToString())
            {
                TripleDESCryptoServiceProvider tdes = (TripleDESCryptoServiceProvider)algo;
                ICryptoTransform encrypteur = tdes.CreateEncryptor(tdes.Key, tdes.IV);
                donneesTransformees = encrypteur.TransformFinalBlock(donneesBrutes, 0, donneesBrutes.Length);
                // Coder ici : chiffrer les données pour cet algorithme
            }

            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.AES.ToString())
            {
                RijndaelManaged aes = (RijndaelManaged)algo;
                ICryptoTransform encrypteur = aes.CreateEncryptor(aes.Key, aes.IV);
                donneesTransformees = encrypteur.TransformFinalBlock(donneesBrutes, 0, donneesBrutes.Length);
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.DSA.ToString())
            {
               DSACryptoServiceProvider dsa = (DSACryptoServiceProvider)algo;
                donneesTransformees = dsa.CreateSignature(donneesBrutes);
               
                return;
                // Coder ici : produire la signature pour cet algorithme
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.RSA.ToString())
            {
                RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)algo;
                donneesTransformees = rsa.Encrypt(donneesBrutes, true);
            }

            this.texteTransforme.Text = Convert.ToBase64String(donneesTransformees, 0, donneesTransformees.Length);
        }

        private void dechiffrer_Click(object sender, EventArgs e)
        {
            if ((string)this.algorithme.SelectedItem == NomAlgorithme.Aucun.ToString())
            {
                // Puisqu'aucun algorithme n'est choisi, on conserve le texte de l'utilisateur en sortie
                this.texteTransforme.Text = this.texteUtilisateur.Text;
                return;
            }

            byte[] donneesBrutes = Convert.FromBase64String(this.texteUtilisateur.Text);
            byte[] donneesTransformees = null;

            if ((string)this.algorithme.SelectedItem == NomAlgorithme.TripleDES.ToString())
            {
                TripleDESCryptoServiceProvider tdes = (TripleDESCryptoServiceProvider)algo;
                ICryptoTransform decrypteur = tdes.CreateDecryptor(tdes.Key, tdes.IV);
                donneesTransformees = decrypteur.TransformFinalBlock(donneesBrutes, 0, donneesBrutes.Length);
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.AES.ToString())
            {
                RijndaelManaged aes = (RijndaelManaged)algo;
                ICryptoTransform decrypteur = aes.CreateDecryptor(aes.Key, aes.IV);
                donneesTransformees = decrypteur.TransformFinalBlock(donneesBrutes, 0, donneesBrutes.Length);
            }
            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.DSA.ToString())
            {
                DSACryptoServiceProvider dsa = (DSACryptoServiceProvider)algo;
                this.texteTransforme.Text = (dsa.VerifySignature(hash, donneesBrutes) ? "Signature valide !" : "Signature invalide !");
                return;
            }

            else if ((string)this.algorithme.SelectedItem == NomAlgorithme.RSA.ToString())
            {
                RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)algo;
                donneesTransformees = rsa.Decrypt(donneesBrutes, true);
                
            }

            this.texteTransforme.Text = UTF8Encoding.UTF8.GetString(donneesTransformees);
        }
    }
}
