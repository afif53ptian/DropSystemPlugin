namespace ExamplePacketPlugin
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("AC Mem", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("AC Non-Mem", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Gold Mem", 2, 2);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Gold Non-Mem", 2, 2);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Item Description");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.keepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOnWikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchOnWikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbEnable = new System.Windows.Forms.CheckBox();
            this.tbDrop = new System.Windows.Forms.TextBox();
            this.tvDropMain = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lbStringLogs = new System.Windows.Forms.Label();
            this.tvDropPool = new System.Windows.Forms.TreeView();
            this.lbDropPool = new System.Windows.Forms.Label();
            this.contextMenuStripPool = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.keepToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbDropItems = new System.Windows.Forms.Label();
            this.cbHideUI = new System.Windows.Forms.CheckBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.linklbReportBug = new System.Windows.Forms.LinkLabel();
            this.cbAutoAtt = new System.Windows.Forms.CheckBox();
            this.tbSkill = new System.Windows.Forms.TextBox();
            this.cbHidePlayer = new System.Windows.Forms.CheckBox();
            this.cbDisableAnim = new System.Windows.Forms.CheckBox();
            this.cbLagKiller = new System.Windows.Forms.CheckBox();
            this.contextMenuStripMainEquip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.equipSWFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnResetSWF = new System.Windows.Forms.Button();
            this.gbOption = new System.Windows.Forms.GroupBox();
            this.cbInfiniteRange = new System.Windows.Forms.CheckBox();
            this.cbProvokeMons = new System.Windows.Forms.CheckBox();
            this.cbWalkSpeed = new System.Windows.Forms.CheckBox();
            this.numWalkSpeed = new System.Windows.Forms.NumericUpDown();
            this.cbSkipCutscene = new System.Windows.Forms.CheckBox();
            this.lbTest = new System.Windows.Forms.Label();
            this.linklbHotkeys = new System.Windows.Forms.LinkLabel();
            this.contextMenuStripMain.SuspendLayout();
            this.contextMenuStripPool.SuspendLayout();
            this.contextMenuStripMainEquip.SuspendLayout();
            this.gbOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepToolStripMenuItem,
            this.rejectToolStripMenuItem,
            this.openOnWikiToolStripMenuItem,
            this.searchOnWikiToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStrip1";
            this.contextMenuStripMain.Size = new System.Drawing.Size(161, 92);
            this.contextMenuStripMain.Text = "Keep this item(s)?";
            // 
            // keepToolStripMenuItem
            // 
            this.keepToolStripMenuItem.Name = "keepToolStripMenuItem";
            this.keepToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.keepToolStripMenuItem.Text = "Keep";
            this.keepToolStripMenuItem.Click += new System.EventHandler(this.keepToolStripMenuItem_Click);
            // 
            // rejectToolStripMenuItem
            // 
            this.rejectToolStripMenuItem.Name = "rejectToolStripMenuItem";
            this.rejectToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.rejectToolStripMenuItem.Text = "Reject";
            this.rejectToolStripMenuItem.Click += new System.EventHandler(this.rejectToolStripMenuItem_Click);
            // 
            // openOnWikiToolStripMenuItem
            // 
            this.openOnWikiToolStripMenuItem.Name = "openOnWikiToolStripMenuItem";
            this.openOnWikiToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openOnWikiToolStripMenuItem.Text = "(Open on Wiki)";
            this.openOnWikiToolStripMenuItem.Click += new System.EventHandler(this.openOnWikiToolStripMenuItem_Click);
            // 
            // searchOnWikiToolStripMenuItem
            // 
            this.searchOnWikiToolStripMenuItem.Name = "searchOnWikiToolStripMenuItem";
            this.searchOnWikiToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.searchOnWikiToolStripMenuItem.Text = "(Search on Wiki)";
            this.searchOnWikiToolStripMenuItem.Click += new System.EventHandler(this.searchOnWikiToolStripMenuItem_Click);
            // 
            // cbEnable
            // 
            this.cbEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbEnable.AutoSize = true;
            this.cbEnable.Location = new System.Drawing.Point(19, 352);
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.Size = new System.Drawing.Size(59, 17);
            this.cbEnable.TabIndex = 0;
            this.cbEnable.Text = "Enable";
            this.cbEnable.UseVisualStyleBackColor = true;
            this.cbEnable.CheckedChanged += new System.EventHandler(this.cbEnable_CheckedChanged);
            // 
            // tbDrop
            // 
            this.tbDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDrop.Location = new System.Drawing.Point(258, 270);
            this.tbDrop.Multiline = true;
            this.tbDrop.Name = "tbDrop";
            this.tbDrop.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDrop.Size = new System.Drawing.Size(223, 76);
            this.tbDrop.TabIndex = 3;
            this.tbDrop.Text = "Enable plugin before log in (the plugin can\'t be activated once you\'re logged in)" +
    "";
            this.tbDrop.TextChanged += new System.EventHandler(this.tbDrop_TextChanged);
            // 
            // tvDropMain
            // 
            this.tvDropMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvDropMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvDropMain.ImageIndex = 0;
            this.tvDropMain.ImageList = this.imageList1;
            this.tvDropMain.Location = new System.Drawing.Point(12, 37);
            this.tvDropMain.Name = "tvDropMain";
            treeNode1.ContextMenuStrip = this.contextMenuStripMain;
            treeNode1.ForeColor = System.Drawing.Color.Magenta;
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "Node0";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "AC Mem";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "Node1";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "AC Non-Mem";
            treeNode3.ForeColor = System.Drawing.Color.Magenta;
            treeNode3.ImageIndex = 2;
            treeNode3.Name = "Node2";
            treeNode3.SelectedImageIndex = 2;
            treeNode3.Text = "Gold Mem";
            treeNode4.ImageIndex = 2;
            treeNode4.Name = "Node2";
            treeNode4.SelectedImageIndex = 2;
            treeNode4.Text = "Gold Non-Mem";
            treeNode5.ImageKey = "GEAR.png";
            treeNode5.Name = "Node3";
            treeNode5.SelectedImageIndex = 0;
            treeNode5.Text = "Item Description";
            this.tvDropMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.tvDropMain.SelectedImageIndex = 0;
            this.tvDropMain.Size = new System.Drawing.Size(235, 208);
            this.tvDropMain.TabIndex = 4;
            this.tvDropMain.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "GEAR.png");
            this.imageList1.Images.SetKeyName(1, "AC.png");
            this.imageList1.Images.SetKeyName(2, "GOLD.png");
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(194, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(53, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lbStringLogs
            // 
            this.lbStringLogs.AutoSize = true;
            this.lbStringLogs.Location = new System.Drawing.Point(256, 251);
            this.lbStringLogs.Name = "lbStringLogs";
            this.lbStringLogs.Size = new System.Drawing.Size(68, 13);
            this.lbStringLogs.TabIndex = 6;
            this.lbStringLogs.Text = "Debug Logs:";
            // 
            // tvDropPool
            // 
            this.tvDropPool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDropPool.ImageIndex = 0;
            this.tvDropPool.ImageList = this.imageList1;
            this.tvDropPool.Location = new System.Drawing.Point(258, 37);
            this.tvDropPool.Name = "tvDropPool";
            this.tvDropPool.SelectedImageIndex = 0;
            this.tvDropPool.Size = new System.Drawing.Size(224, 208);
            this.tvDropPool.TabIndex = 7;
            this.tvDropPool.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_NodeMouseClick);
            // 
            // lbDropPool
            // 
            this.lbDropPool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDropPool.AutoSize = true;
            this.lbDropPool.Location = new System.Drawing.Point(256, 21);
            this.lbDropPool.Name = "lbDropPool";
            this.lbDropPool.Size = new System.Drawing.Size(156, 13);
            this.lbDropPool.TabIndex = 8;
            this.lbDropPool.Text = "Drop Pool: (all rejected go here)";
            // 
            // contextMenuStripPool
            // 
            this.contextMenuStripPool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepToolStripMenuItem1,
            this.restoreToolStripMenuItem});
            this.contextMenuStripPool.Name = "contextMenuStrip2";
            this.contextMenuStripPool.Size = new System.Drawing.Size(114, 48);
            // 
            // keepToolStripMenuItem1
            // 
            this.keepToolStripMenuItem1.Name = "keepToolStripMenuItem1";
            this.keepToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.keepToolStripMenuItem1.Text = "Keep";
            this.keepToolStripMenuItem1.Click += new System.EventHandler(this.keepToolStripMenuItem1_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // lbDropItems
            // 
            this.lbDropItems.AutoSize = true;
            this.lbDropItems.Location = new System.Drawing.Point(9, 18);
            this.lbDropItems.Name = "lbDropItems";
            this.lbDropItems.Size = new System.Drawing.Size(59, 13);
            this.lbDropItems.TabIndex = 9;
            this.lbDropItems.Text = "Main Drop:";
            // 
            // cbHideUI
            // 
            this.cbHideUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbHideUI.AutoSize = true;
            this.cbHideUI.Location = new System.Drawing.Point(79, 352);
            this.cbHideUI.Name = "cbHideUI";
            this.cbHideUI.Size = new System.Drawing.Size(100, 17);
            this.cbHideUI.TabIndex = 10;
            this.cbHideUI.Text = "Hide Logs/Pool";
            this.cbHideUI.UseVisualStyleBackColor = true;
            this.cbHideUI.CheckedChanged += new System.EventHandler(this.cbHideUI_CheckedChanged);
            // 
            // lbInfo
            // 
            this.lbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(177, 353);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(49, 13);
            this.lbInfo.TabIndex = 11;
            this.lbInfo.Text = "(Inv Info)";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linklbReportBug
            // 
            this.linklbReportBug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklbReportBug.AutoSize = true;
            this.linklbReportBug.Location = new System.Drawing.Point(417, 251);
            this.linklbReportBug.Name = "linklbReportBug";
            this.linklbReportBug.Size = new System.Drawing.Size(64, 13);
            this.linklbReportBug.TabIndex = 12;
            this.linklbReportBug.TabStop = true;
            this.linklbReportBug.Text = "ReportBug?";
            this.linklbReportBug.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLbReportBug_LinkClicked);
            // 
            // cbAutoAtt
            // 
            this.cbAutoAtt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAutoAtt.AutoSize = true;
            this.cbAutoAtt.Location = new System.Drawing.Point(6, 21);
            this.cbAutoAtt.Name = "cbAutoAtt";
            this.cbAutoAtt.Size = new System.Drawing.Size(82, 17);
            this.cbAutoAtt.TabIndex = 13;
            this.cbAutoAtt.Text = "AutoAttack:";
            this.cbAutoAtt.UseVisualStyleBackColor = true;
            this.cbAutoAtt.CheckedChanged += new System.EventHandler(this.cbAutoAtt_CheckedChanged);
            // 
            // tbSkill
            // 
            this.tbSkill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSkill.Location = new System.Drawing.Point(88, 19);
            this.tbSkill.Name = "tbSkill";
            this.tbSkill.Size = new System.Drawing.Size(45, 20);
            this.tbSkill.TabIndex = 14;
            this.tbSkill.Text = "1;2;3;4";
            // 
            // cbHidePlayer
            // 
            this.cbHidePlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbHidePlayer.AutoSize = true;
            this.cbHidePlayer.Location = new System.Drawing.Point(151, 21);
            this.cbHidePlayer.Name = "cbHidePlayer";
            this.cbHidePlayer.Size = new System.Drawing.Size(77, 17);
            this.cbHidePlayer.TabIndex = 15;
            this.cbHidePlayer.Text = "HidePlayer";
            this.cbHidePlayer.UseVisualStyleBackColor = true;
            this.cbHidePlayer.CheckedChanged += new System.EventHandler(this.cbHidePlayer_CheckedChanged);
            // 
            // cbDisableAnim
            // 
            this.cbDisableAnim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDisableAnim.AutoSize = true;
            this.cbDisableAnim.Location = new System.Drawing.Point(6, 44);
            this.cbDisableAnim.Name = "cbDisableAnim";
            this.cbDisableAnim.Size = new System.Drawing.Size(107, 17);
            this.cbDisableAnim.TabIndex = 16;
            this.cbDisableAnim.Text = "DisableAnimation";
            this.cbDisableAnim.UseVisualStyleBackColor = true;
            this.cbDisableAnim.CheckedChanged += new System.EventHandler(this.cbDisableAnim_CheckedChanged);
            // 
            // cbLagKiller
            // 
            this.cbLagKiller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbLagKiller.AutoSize = true;
            this.cbLagKiller.Location = new System.Drawing.Point(151, 44);
            this.cbLagKiller.Name = "cbLagKiller";
            this.cbLagKiller.Size = new System.Drawing.Size(66, 17);
            this.cbLagKiller.TabIndex = 17;
            this.cbLagKiller.Text = "LagKiller";
            this.cbLagKiller.UseVisualStyleBackColor = true;
            this.cbLagKiller.CheckedChanged += new System.EventHandler(this.cbLagKiller_CheckedChanged);
            // 
            // contextMenuStripMainEquip
            // 
            this.contextMenuStripMainEquip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.equipSWFToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStripMainEquip.Name = "contextMenuStrip1";
            this.contextMenuStripMainEquip.Size = new System.Drawing.Size(161, 114);
            this.contextMenuStripMainEquip.Text = "Keep this item(s)?";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem1.Text = "Keep";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.keepToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem2.Text = "Reject";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.rejectToolStripMenuItem_Click);
            // 
            // equipSWFToolStripMenuItem
            // 
            this.equipSWFToolStripMenuItem.Name = "equipSWFToolStripMenuItem";
            this.equipSWFToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.equipSWFToolStripMenuItem.Text = "(Equip SWF)";
            this.equipSWFToolStripMenuItem.Click += new System.EventHandler(this.equipSWFToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem3.Text = "(Open on Wiki)";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.openOnWikiToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem4.Text = "(Search on Wiki)";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.searchOnWikiToolStripMenuItem_Click);
            // 
            // btnResetSWF
            // 
            this.btnResetSWF.Location = new System.Drawing.Point(119, 8);
            this.btnResetSWF.Name = "btnResetSWF";
            this.btnResetSWF.Size = new System.Drawing.Size(69, 23);
            this.btnResetSWF.TabIndex = 18;
            this.btnResetSWF.Text = "ResetSWF";
            this.btnResetSWF.UseVisualStyleBackColor = true;
            this.btnResetSWF.Click += new System.EventHandler(this.btnResetSWF_Click);
            // 
            // gbOption
            // 
            this.gbOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbOption.Controls.Add(this.cbInfiniteRange);
            this.gbOption.Controls.Add(this.cbProvokeMons);
            this.gbOption.Controls.Add(this.cbAutoAtt);
            this.gbOption.Controls.Add(this.tbSkill);
            this.gbOption.Controls.Add(this.cbHidePlayer);
            this.gbOption.Controls.Add(this.cbDisableAnim);
            this.gbOption.Controls.Add(this.cbLagKiller);
            this.gbOption.Location = new System.Drawing.Point(13, 251);
            this.gbOption.Name = "gbOption";
            this.gbOption.Size = new System.Drawing.Size(234, 95);
            this.gbOption.TabIndex = 19;
            this.gbOption.TabStop = false;
            this.gbOption.Text = "Options:";
            // 
            // cbInfiniteRange
            // 
            this.cbInfiniteRange.AutoSize = true;
            this.cbInfiniteRange.Location = new System.Drawing.Point(6, 67);
            this.cbInfiniteRange.Name = "cbInfiniteRange";
            this.cbInfiniteRange.Size = new System.Drawing.Size(120, 17);
            this.cbInfiniteRange.TabIndex = 19;
            this.cbInfiniteRange.Text = "InfiniteAttackRange";
            this.cbInfiniteRange.UseVisualStyleBackColor = true;
            this.cbInfiniteRange.CheckedChanged += new System.EventHandler(this.cbInfiniteRange_CheckedChanged);
            // 
            // cbProvokeMons
            // 
            this.cbProvokeMons.AutoSize = true;
            this.cbProvokeMons.Location = new System.Drawing.Point(151, 67);
            this.cbProvokeMons.Name = "cbProvokeMons";
            this.cbProvokeMons.Size = new System.Drawing.Size(66, 17);
            this.cbProvokeMons.TabIndex = 18;
            this.cbProvokeMons.Text = "Provoke";
            this.cbProvokeMons.UseVisualStyleBackColor = true;
            this.cbProvokeMons.CheckedChanged += new System.EventHandler(this.cbProvokeMons_CheckedChanged);
            // 
            // cbWalkSpeed
            // 
            this.cbWalkSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbWalkSpeed.AutoSize = true;
            this.cbWalkSpeed.Location = new System.Drawing.Point(258, 352);
            this.cbWalkSpeed.Name = "cbWalkSpeed";
            this.cbWalkSpeed.Size = new System.Drawing.Size(85, 17);
            this.cbWalkSpeed.TabIndex = 20;
            this.cbWalkSpeed.Text = "WalkSpeed:";
            this.cbWalkSpeed.UseVisualStyleBackColor = true;
            this.cbWalkSpeed.CheckedChanged += new System.EventHandler(this.cbWalkSpeed_CheckedChangedAsync);
            // 
            // numWalkSpeed
            // 
            this.numWalkSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numWalkSpeed.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numWalkSpeed.Location = new System.Drawing.Point(340, 351);
            this.numWalkSpeed.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numWalkSpeed.Name = "numWalkSpeed";
            this.numWalkSpeed.Size = new System.Drawing.Size(39, 20);
            this.numWalkSpeed.TabIndex = 21;
            this.numWalkSpeed.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numWalkSpeed.ValueChanged += new System.EventHandler(this.numWalkSpeed_ValueChanged);
            // 
            // cbSkipCutscene
            // 
            this.cbSkipCutscene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSkipCutscene.AutoSize = true;
            this.cbSkipCutscene.Location = new System.Drawing.Point(385, 352);
            this.cbSkipCutscene.Name = "cbSkipCutscene";
            this.cbSkipCutscene.Size = new System.Drawing.Size(92, 17);
            this.cbSkipCutscene.TabIndex = 22;
            this.cbSkipCutscene.Text = "SkipCutscene";
            this.cbSkipCutscene.UseVisualStyleBackColor = true;
            this.cbSkipCutscene.CheckedChanged += new System.EventHandler(this.cbSkipCutscene_CheckedChanged);
            // 
            // lbTest
            // 
            this.lbTest.AutoSize = true;
            this.lbTest.Location = new System.Drawing.Point(323, 251);
            this.lbTest.Name = "lbTest";
            this.lbTest.Size = new System.Drawing.Size(74, 13);
            this.lbTest.TabIndex = 23;
            this.lbTest.Text = "{currentNode}";
            // 
            // linklbHotkeys
            // 
            this.linklbHotkeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linklbHotkeys.AutoSize = true;
            this.linklbHotkeys.Location = new System.Drawing.Point(429, 21);
            this.linklbHotkeys.Name = "linklbHotkeys";
            this.linklbHotkeys.Size = new System.Drawing.Size(52, 13);
            this.linklbHotkeys.TabIndex = 24;
            this.linklbHotkeys.TabStop = true;
            this.linklbHotkeys.Text = "Hotkeys?";
            this.linklbHotkeys.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbHotkeys_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 376);
            this.Controls.Add(this.linklbHotkeys);
            this.Controls.Add(this.lbTest);
            this.Controls.Add(this.cbSkipCutscene);
            this.Controls.Add(this.numWalkSpeed);
            this.Controls.Add(this.cbWalkSpeed);
            this.Controls.Add(this.gbOption);
            this.Controls.Add(this.btnResetSWF);
            this.Controls.Add(this.linklbReportBug);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.cbHideUI);
            this.Controls.Add(this.lbDropItems);
            this.Controls.Add(this.lbDropPool);
            this.Controls.Add(this.tvDropPool);
            this.Controls.Add(this.lbStringLogs);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tvDropMain);
            this.Controls.Add(this.tbDrop);
            this.Controls.Add(this.cbEnable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(510, 39);
            this.Name = "Main";
            this.Text = "Drop System 3.0";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.contextMenuStripMain.ResumeLayout(false);
            this.contextMenuStripPool.ResumeLayout(false);
            this.contextMenuStripMainEquip.ResumeLayout(false);
            this.gbOption.ResumeLayout(false);
            this.gbOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox cbEnable;
        private System.Windows.Forms.TextBox tbDrop;
        private System.Windows.Forms.TreeView tvDropMain;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem keepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejectToolStripMenuItem;
        private System.Windows.Forms.Label lbStringLogs;
        private System.Windows.Forms.TreeView tvDropPool;
        private System.Windows.Forms.Label lbDropPool;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPool;
        private System.Windows.Forms.ToolStripMenuItem keepToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.Label lbDropItems;
        private System.Windows.Forms.CheckBox cbHideUI;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.LinkLabel linklbReportBug;
        private System.Windows.Forms.ToolStripMenuItem searchOnWikiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openOnWikiToolStripMenuItem;
        public System.Windows.Forms.CheckBox cbAutoAtt;
        public System.Windows.Forms.TextBox tbSkill;
        private System.Windows.Forms.CheckBox cbHidePlayer;
        private System.Windows.Forms.CheckBox cbDisableAnim;
        private System.Windows.Forms.CheckBox cbLagKiller;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMainEquip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem equipSWFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.Button btnResetSWF;
        private System.Windows.Forms.GroupBox gbOption;
        private System.Windows.Forms.CheckBox cbInfiniteRange;
        private System.Windows.Forms.CheckBox cbProvokeMons;
        private System.Windows.Forms.CheckBox cbWalkSpeed;
        private System.Windows.Forms.NumericUpDown numWalkSpeed;
        private System.Windows.Forms.CheckBox cbSkipCutscene;
        private System.Windows.Forms.Label lbTest;
        private System.Windows.Forms.LinkLabel linklbHotkeys;
    }
}