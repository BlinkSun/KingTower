
namespace KingTower
{
    partial class MainForm
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
            this.TowerEnemyUI = new System.Windows.Forms.FlowLayoutPanel();
            this.TowerPlayerUI = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // TowerEnemyUI
            // 
            this.TowerEnemyUI.AutoScroll = true;
            this.TowerEnemyUI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TowerEnemyUI.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.TowerEnemyUI.Location = new System.Drawing.Point(294, 12);
            this.TowerEnemyUI.Name = "TowerEnemyUI";
            this.TowerEnemyUI.Size = new System.Drawing.Size(218, 794);
            this.TowerEnemyUI.TabIndex = 2;
            this.TowerEnemyUI.WrapContents = false;
            // 
            // TowerPlayerUI
            // 
            this.TowerPlayerUI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TowerPlayerUI.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.TowerPlayerUI.Location = new System.Drawing.Point(12, 12);
            this.TowerPlayerUI.Name = "TowerPlayerUI";
            this.TowerPlayerUI.Size = new System.Drawing.Size(218, 794);
            this.TowerPlayerUI.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 818);
            this.Controls.Add(this.TowerPlayerUI);
            this.Controls.Add(this.TowerEnemyUI);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel TowerEnemyUI;
        private System.Windows.Forms.FlowLayoutPanel TowerPlayerUI;
    }
}

