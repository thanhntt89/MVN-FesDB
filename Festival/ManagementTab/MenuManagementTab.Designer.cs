namespace Festival.ManagementTab
{
    partial class TabManagement
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
            this.btnFunctionID = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnAuthorityGroup = new System.Windows.Forms.Button();
            this.btnExclusiveManagement = new System.Windows.Forms.Button();
            this.btnAuthorityAllocate = new System.Windows.Forms.Button();
            this.btnProjectID = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFunctionID
            // 
            this.btnFunctionID.Location = new System.Drawing.Point(2, 2);
            this.btnFunctionID.Margin = new System.Windows.Forms.Padding(2);
            this.btnFunctionID.Name = "btnFunctionID";
            this.btnFunctionID.Size = new System.Drawing.Size(270, 30);
            this.btnFunctionID.TabIndex = 0;
            this.btnFunctionID.Tag = "410";
            this.btnFunctionID.Text = "機能ID(A)";
            this.btnFunctionID.UseVisualStyleBackColor = true;
            this.btnFunctionID.Click += new System.EventHandler(this.btnFunctionID_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(2, 37);
            this.btnUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(270, 30);
            this.btnUser.TabIndex = 1;
            this.btnUser.Tag = "411";
            this.btnUser.Text = "利用者(B)";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnAuthorityGroup
            // 
            this.btnAuthorityGroup.Location = new System.Drawing.Point(2, 72);
            this.btnAuthorityGroup.Margin = new System.Windows.Forms.Padding(2);
            this.btnAuthorityGroup.Name = "btnAuthorityGroup";
            this.btnAuthorityGroup.Size = new System.Drawing.Size(270, 30);
            this.btnAuthorityGroup.TabIndex = 2;
            this.btnAuthorityGroup.Tag = "412";
            this.btnAuthorityGroup.Text = "権限グループ(C)";
            this.btnAuthorityGroup.UseVisualStyleBackColor = true;
            this.btnAuthorityGroup.Click += new System.EventHandler(this.btnAuthorityGroup_Click);
            // 
            // btnExclusiveManagement
            // 
            this.btnExclusiveManagement.Location = new System.Drawing.Point(304, 72);
            this.btnExclusiveManagement.Margin = new System.Windows.Forms.Padding(2);
            this.btnExclusiveManagement.Name = "btnExclusiveManagement";
            this.btnExclusiveManagement.Size = new System.Drawing.Size(270, 30);
            this.btnExclusiveManagement.TabIndex = 5;
            this.btnExclusiveManagement.Tag = "415";
            this.btnExclusiveManagement.Text = "排他管理(F)";
            this.btnExclusiveManagement.UseVisualStyleBackColor = true;
            this.btnExclusiveManagement.Click += new System.EventHandler(this.btnExclusiveManagement_Click);
            // 
            // btnAuthorityAllocate
            // 
            this.btnAuthorityAllocate.Location = new System.Drawing.Point(304, 2);
            this.btnAuthorityAllocate.Margin = new System.Windows.Forms.Padding(2);
            this.btnAuthorityAllocate.Name = "btnAuthorityAllocate";
            this.btnAuthorityAllocate.Size = new System.Drawing.Size(270, 30);
            this.btnAuthorityAllocate.TabIndex = 3;
            this.btnAuthorityAllocate.Tag = "413";
            this.btnAuthorityAllocate.Text = "権限割り当て(D)";
            this.btnAuthorityAllocate.UseVisualStyleBackColor = true;
            this.btnAuthorityAllocate.Click += new System.EventHandler(this.btnAuthorityAllocate_Click);
            // 
            // btnProjectID
            // 
            this.btnProjectID.Location = new System.Drawing.Point(304, 37);
            this.btnProjectID.Margin = new System.Windows.Forms.Padding(2);
            this.btnProjectID.Name = "btnProjectID";
            this.btnProjectID.Size = new System.Drawing.Size(270, 30);
            this.btnProjectID.TabIndex = 4;
            this.btnProjectID.Tag = "414";
            this.btnProjectID.Text = "プロジェクトID(E)";
            this.btnProjectID.UseVisualStyleBackColor = true;
            this.btnProjectID.Click += new System.EventHandler(this.btnProjectID_Click);
            // 
            // TabManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnProjectID);
            this.Controls.Add(this.btnAuthorityAllocate);
            this.Controls.Add(this.btnExclusiveManagement);
            this.Controls.Add(this.btnAuthorityGroup);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnFunctionID);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TabManagement";
            this.Size = new System.Drawing.Size(602, 219);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFunctionID;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnAuthorityGroup;
        private System.Windows.Forms.Button btnExclusiveManagement;
        private System.Windows.Forms.Button btnAuthorityAllocate;
        private System.Windows.Forms.Button btnProjectID;
    }
}
