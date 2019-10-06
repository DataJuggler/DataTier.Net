namespace DataTierClient.Controls
{
    partial class UpdateControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateControl));
            this.UpdateLabel = new System.Windows.Forms.Label();
            this.CodeUpdateLabel = new System.Windows.Forms.Label();
            this.SQLUpdateLabel = new System.Windows.Forms.Label();
            this.SQLUpdateInstructions = new System.Windows.Forms.Label();
            this.NoChangesLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UpdateLabel
            // 
            this.UpdateLabel.Location = new System.Drawing.Point(18, 48);
            this.UpdateLabel.Name = "UpdateLabel";
            this.UpdateLabel.Size = new System.Drawing.Size(643, 84);
            this.UpdateLabel.TabIndex = 0;
            this.UpdateLabel.Text = resources.GetString("UpdateLabel.Text");
            // 
            // CodeUpdateLabel
            // 
            this.CodeUpdateLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeUpdateLabel.Location = new System.Drawing.Point(18, 16);
            this.CodeUpdateLabel.Name = "CodeUpdateLabel";
            this.CodeUpdateLabel.Size = new System.Drawing.Size(486, 28);
            this.CodeUpdateLabel.TabIndex = 1;
            this.CodeUpdateLabel.Text = "Code Update Available";
            this.CodeUpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SQLUpdateLabel
            // 
            this.SQLUpdateLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLUpdateLabel.Location = new System.Drawing.Point(18, 120);
            this.SQLUpdateLabel.Name = "SQLUpdateLabel";
            this.SQLUpdateLabel.Size = new System.Drawing.Size(486, 28);
            this.SQLUpdateLabel.TabIndex = 3;
            this.SQLUpdateLabel.Text = "SQL Update Available";
            this.SQLUpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SQLUpdateInstructions
            // 
            this.SQLUpdateInstructions.Location = new System.Drawing.Point(18, 152);
            this.SQLUpdateInstructions.Name = "SQLUpdateInstructions";
            this.SQLUpdateInstructions.Size = new System.Drawing.Size(643, 153);
            this.SQLUpdateInstructions.TabIndex = 2;
            this.SQLUpdateInstructions.Text = resources.GetString("SQLUpdateInstructions.Text");
            // 
            // NoChangesLabel
            // 
            this.NoChangesLabel.Location = new System.Drawing.Point(18, 152);
            this.NoChangesLabel.Name = "NoChangesLabel";
            this.NoChangesLabel.Size = new System.Drawing.Size(643, 47);
            this.NoChangesLabel.TabIndex = 99;
            this.NoChangesLabel.Text = "The database schema has not changed for the this update.";
            this.NoChangesLabel.Visible = false;
            // 
            // OkButton
            // 
            this.OkButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.OkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OkButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.OkButton.Location = new System.Drawing.Point(293, 316);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(96, 40);
            this.OkButton.TabIndex = 98;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            this.OkButton.MouseEnter += new System.EventHandler(this.OkButton_MouseEnter);
            this.OkButton.MouseLeave += new System.EventHandler(this.OkButton_MouseLeave);
            // 
            // UpdateControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.SQLUpdateLabel);
            this.Controls.Add(this.SQLUpdateInstructions);
            this.Controls.Add(this.CodeUpdateLabel);
            this.Controls.Add(this.UpdateLabel);
            this.Controls.Add(this.NoChangesLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "UpdateControl";
            this.Size = new System.Drawing.Size(676, 380);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UpdateLabel;
        private System.Windows.Forms.Label CodeUpdateLabel;
        private System.Windows.Forms.Label SQLUpdateLabel;
        private System.Windows.Forms.Label SQLUpdateInstructions;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label NoChangesLabel;
    }
}
