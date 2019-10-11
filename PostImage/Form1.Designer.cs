namespace PostImage
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbImage = new System.Windows.Forms.TextBox();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.btChoose = new System.Windows.Forms.Button();
            this.btPost = new System.Windows.Forms.Button();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.tbWeb = new System.Windows.Forms.TextBox();
            this.lbGet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbImage
            // 
            this.tbImage.Location = new System.Drawing.Point(13, 13);
            this.tbImage.Name = "tbImage";
            this.tbImage.Size = new System.Drawing.Size(358, 22);
            this.tbImage.TabIndex = 0;
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(12, 70);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(358, 22);
            this.tbUrl.TabIndex = 1;
            // 
            // btChoose
            // 
            this.btChoose.Location = new System.Drawing.Point(377, 13);
            this.btChoose.Name = "btChoose";
            this.btChoose.Size = new System.Drawing.Size(75, 22);
            this.btChoose.TabIndex = 2;
            this.btChoose.Text = "選擇圖片";
            this.btChoose.UseVisualStyleBackColor = true;
            this.btChoose.Click += new System.EventHandler(this.btChoose_Click);
            // 
            // btPost
            // 
            this.btPost.Location = new System.Drawing.Point(377, 70);
            this.btPost.Name = "btPost";
            this.btPost.Size = new System.Drawing.Size(75, 22);
            this.btPost.TabIndex = 3;
            this.btPost.Text = "Post";
            this.btPost.UseVisualStyleBackColor = true;
            this.btPost.Click += new System.EventHandler(this.btPost_Click);
            // 
            // tbConsole
            // 
            this.tbConsole.Location = new System.Drawing.Point(13, 110);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(439, 178);
            this.tbConsole.TabIndex = 4;
            // 
            // tbWeb
            // 
            this.tbWeb.Location = new System.Drawing.Point(13, 42);
            this.tbWeb.Name = "tbWeb";
            this.tbWeb.Size = new System.Drawing.Size(358, 22);
            this.tbWeb.TabIndex = 5;
            this.tbWeb.Text = "http://localhost:9033/default.aspx";
            // 
            // lbGet
            // 
            this.lbGet.AutoSize = true;
            this.lbGet.Font = new System.Drawing.Font("新細明體", 11F);
            this.lbGet.Location = new System.Drawing.Point(377, 43);
            this.lbGet.Name = "lbGet";
            this.lbGet.Size = new System.Drawing.Size(67, 15);
            this.lbGet.TabIndex = 6;
            this.lbGet.Text = "顯示網頁";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 300);
            this.Controls.Add(this.lbGet);
            this.Controls.Add(this.tbWeb);
            this.Controls.Add(this.tbConsole);
            this.Controls.Add(this.btPost);
            this.Controls.Add(this.btChoose);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.tbImage);
            this.Name = "Form1";
            this.Text = "PostImage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbImage;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btChoose;
        private System.Windows.Forms.Button btPost;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.TextBox tbWeb;
        private System.Windows.Forms.Label lbGet;
    }
}

