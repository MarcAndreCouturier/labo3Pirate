namespace ChiffrerDechiffrer
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.algorithme = new System.Windows.Forms.ComboBox();
            this.lblAlgoSelection = new System.Windows.Forms.Label();
            this.cles = new System.Windows.Forms.TextBox();
            this.texteUtilisateur = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.texteTransforme = new System.Windows.Forms.TextBox();
            this.chiffrer = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dechiffrer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // algorithme
            // 
            this.algorithme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algorithme.FormattingEnabled = true;
            this.algorithme.Items.AddRange(new object[] {
            "Aucun",
            "TripleDES",
            "AES",
            "DSA",
            "RSA"});
            this.algorithme.Location = new System.Drawing.Point(318, 95);
            this.algorithme.Name = "algorithme";
            this.algorithme.Size = new System.Drawing.Size(175, 28);
            this.algorithme.TabIndex = 0;
            this.algorithme.Text = "Aucun";
            this.algorithme.SelectedIndexChanged += new System.EventHandler(this.algorithme_SelectedIndexChanged);
            // 
            // lblAlgoSelection
            // 
            this.lblAlgoSelection.AutoSize = true;
            this.lblAlgoSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlgoSelection.Location = new System.Drawing.Point(128, 98);
            this.lblAlgoSelection.Name = "lblAlgoSelection";
            this.lblAlgoSelection.Size = new System.Drawing.Size(184, 20);
            this.lblAlgoSelection.TabIndex = 1;
            this.lblAlgoSelection.Text = "Algorithme de cryptage : ";
            this.lblAlgoSelection.Click += new System.EventHandler(this.lblAlgoSelection_Click);
            // 
            // cles
            // 
            this.cles.Location = new System.Drawing.Point(318, 139);
            this.cles.Name = "cles";
            this.cles.Size = new System.Drawing.Size(613, 20);
            this.cles.TabIndex = 2;
            // 
            // texteUtilisateur
            // 
            this.texteUtilisateur.Location = new System.Drawing.Point(318, 165);
            this.texteUtilisateur.Multiline = true;
            this.texteUtilisateur.Name = "texteUtilisateur";
            this.texteUtilisateur.Size = new System.Drawing.Size(555, 213);
            this.texteUtilisateur.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AutoSize = false;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 26);
            // 
            // texteTransforme
            // 
            this.texteTransforme.Location = new System.Drawing.Point(318, 385);
            this.texteTransforme.Multiline = true;
            this.texteTransforme.Name = "texteTransforme";
            this.texteTransforme.Size = new System.Drawing.Size(555, 224);
            this.texteTransforme.TabIndex = 5;
            // 
            // chiffrer
            // 
            this.chiffrer.Location = new System.Drawing.Point(879, 165);
            this.chiffrer.Name = "chiffrer";
            this.chiffrer.Size = new System.Drawing.Size(75, 23);
            this.chiffrer.TabIndex = 6;
            this.chiffrer.Text = "chiffrer";
            this.chiffrer.UseVisualStyleBackColor = true;
            this.chiffrer.Click += new System.EventHandler(this.chiffrer_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(788, 616);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dechiffrer
            // 
            this.dechiffrer.Location = new System.Drawing.Point(879, 205);
            this.dechiffrer.Name = "dechiffrer";
            this.dechiffrer.Size = new System.Drawing.Size(75, 23);
            this.dechiffrer.TabIndex = 8;
            this.dechiffrer.Text = "dechiffrer";
            this.dechiffrer.UseVisualStyleBackColor = true;
            this.dechiffrer.Click += new System.EventHandler(this.dechiffrer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 712);
            this.Controls.Add(this.dechiffrer);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chiffrer);
            this.Controls.Add(this.texteTransforme);
            this.Controls.Add(this.texteUtilisateur);
            this.Controls.Add(this.cles);
            this.Controls.Add(this.lblAlgoSelection);
            this.Controls.Add(this.algorithme);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox algorithme;
        private System.Windows.Forms.Label lblAlgoSelection;
        private System.Windows.Forms.TextBox cles;
        private System.Windows.Forms.TextBox texteUtilisateur;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox texteTransforme;
        private System.Windows.Forms.Button chiffrer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button dechiffrer;
    }
}

