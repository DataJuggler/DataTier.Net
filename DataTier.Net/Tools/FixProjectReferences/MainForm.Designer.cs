namespace FixProjectReferences
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StartButton = new DataJuggler.Win.Controls.Button();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.BackColor = Color.Transparent;
            StartButton.ButtonText = "Start";
            StartButton.FlatStyle = FlatStyle.Flat;
            StartButton.ForeColor = Color.Black;
            StartButton.Location = new Point(295, 164);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(120, 44);
            StartButton.TabIndex = 0;
            StartButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Wood;
            StartButton.Click += StartButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StartButton);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private DataJuggler.Win.Controls.Button StartButton;
    }
}
