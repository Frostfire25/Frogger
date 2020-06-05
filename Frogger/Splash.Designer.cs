namespace Frogger
{
    partial class Splash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.header = new System.Windows.Forms.PictureBox();
            this.name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.header)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.Transparent;
            this.header.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("header.BackgroundImage")));
            this.header.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.header.Location = new System.Drawing.Point(163, 12);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(260, 143);
            this.header.TabIndex = 0;
            this.header.TabStop = false;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("Minerva", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(143, 189);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(318, 43);
            this.name.TabIndex = 1;
            this.name.Text = "By: Alex Elguezabal";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(585, 282);
            this.Controls.Add(this.name);
            this.Controls.Add(this.header);
            this.Name = "Splash";
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.Shown += new System.EventHandler(this.Splash_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.header)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox header;
        private System.Windows.Forms.Label name;
    }
}