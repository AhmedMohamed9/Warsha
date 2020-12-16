namespace Warsha
{
    partial class Form1
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
            this.Goods = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // Goods
            // 
            this.Goods.BackColor = System.Drawing.Color.White;
            this.Goods.Location = new System.Drawing.Point(335, 95);
            this.Goods.Name = "Goods";
            this.Goods.Size = new System.Drawing.Size(187, 154);
            this.Goods.TabIndex = 0;
            this.Goods.Text = "البضائع";
            this.Goods.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Goods.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.Goods.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.Goods.Click += new System.EventHandler(this.Goods_Click);
            // 
            // metroTile1
            // 
            this.metroTile1.BackColor = System.Drawing.Color.Maroon;
            this.metroTile1.Location = new System.Drawing.Point(47, 95);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(187, 154);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTile1.TabIndex = 1;
            this.metroTile1.Text = "المصروفات";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            this.metroTile1.StyleChanged += new System.EventHandler(this.metroTile1_StyleChanged);
            // 
            // metroTile2
            // 
            this.metroTile2.BackColor = System.Drawing.Color.White;
            this.metroTile2.Location = new System.Drawing.Point(335, 291);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(187, 154);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTile2.TabIndex = 2;
            this.metroTile2.Text = "المشتريات";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTile2.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile2.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // metroTile3
            // 
            this.metroTile3.BackColor = System.Drawing.Color.White;
            this.metroTile3.Location = new System.Drawing.Point(47, 291);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(187, 154);
            this.metroTile3.TabIndex = 3;
            this.metroTile3.Text = "البضائع";
            this.metroTile3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTile3.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile3.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 681);
            this.Controls.Add(this.metroTile3);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.Goods);
            this.Name = "Form1";
            this.Text = "Warsha";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile Goods;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile metroTile3;
    }
}

