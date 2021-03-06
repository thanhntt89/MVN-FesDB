#region License
// Advanced DataGridView
//
// Copyright (c), 2014 Davide Gironi <davide.gironi@gmail.com>
// Original work Copyright (c), 2013 Zuby <zuby@me.com>
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zuby.ADGV
{

    [System.ComponentModel.DesignerCategory("")]
    internal partial class MenuStrip : ContextMenuStrip
    {

        #region public enum

        /// <summary>
        /// MenuStrip Filter type
        /// </summary>
        public enum FilterType : byte
        {
            None = 0,
            Custom = 1,
            CheckList = 2,
            Loaded = 3
        }


        /// <summary>
        /// MenuStrip Sort type
        /// </summary>
        public enum SortType : byte
        {
            None = 0,
            ASC = 1,
            DESC = 2
        }

        #endregion


        #region class properties

        private FilterType _activeFilterType = FilterType.None;
        private SortType _activeSortType = SortType.None;
        private TreeNodeItemSelector[] _startingNodes = null;
        private TreeNodeItemSelector[] _filterNodes = null;
        private string _sortString = null;
        private string _filterString = null;
        private static Point _resizeStartPoint = new Point(1, 1);
        private Point _resizeEndPoint = new Point(-1, -1);
        private bool _checkTextFilterChangedEnabled = true;
        private TreeNodeItemSelector[] _initialNodes = new TreeNodeItemSelector[] { };
        private TreeNodeItemSelector[] _restoreNodes = new TreeNodeItemSelector[] { };
        private bool _checkTextFilterSetByText = false;
        private bool _checkTextFilterRemoveNodesOnSearch = true;
        #endregion


        #region costructors

        /// <summary>
        /// MenuStrip constructor
        /// </summary>
        /// <param name="dataType"></param>
        public MenuStrip(Type dataType)
            : base()
        {
            //initialize components
            InitializeComponent();

            //set component translations
            cancelSortMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVClearSort.ToString()];
            cancelFilterMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVClearFilter.ToString()];
            customFilterMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVAddCustomFilter.ToString()];
            button_filter.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVButtonFilter.ToString()];
            button_undofilter.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVButtonUndofilter.ToString()];

            //set type
            DataType = dataType;

            //set components values
            if (DataType == typeof(DateTime) || DataType == typeof(TimeSpan))
            {
                customFilterLastFiltersListMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVCustomFilter.ToString()];
                sortASCMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVSortDateTimeASC.ToString()];
                sortDESCMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVSortDateTimeDESC.ToString()];
                sortASCMenuItem.Image = Properties.Resources.MenuStrip_OrderASCnum;
                sortDESCMenuItem.Image = Properties.Resources.MenuStrip_OrderDESCnum;
            }
            else if (DataType == typeof(bool))
            {
                customFilterLastFiltersListMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVCustomFilter.ToString()];
                sortASCMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVSortBoolASC.ToString()];
                sortDESCMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVSortBoolDESC.ToString()];
                sortASCMenuItem.Image = Properties.Resources.MenuStrip_OrderASCbool;
                sortDESCMenuItem.Image = Properties.Resources.MenuStrip_OrderDESCbool;
            }
            else if (DataType == typeof(Int32) || DataType == typeof(Int64) || DataType == typeof(Int16) ||
                DataType == typeof(UInt32) || DataType == typeof(UInt64) || DataType == typeof(UInt16) ||
                DataType == typeof(Byte) || DataType == typeof(SByte) || DataType == typeof(Decimal) ||
                DataType == typeof(Single) || DataType == typeof(Double))
            {
                customFilterLastFiltersListMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVCustomFilter.ToString()];
                sortASCMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVSortNumASC.ToString()];
                sortDESCMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVSortNumDESC.ToString()];
                sortASCMenuItem.Image = Properties.Resources.MenuStrip_OrderASCnum;
                sortDESCMenuItem.Image = Properties.Resources.MenuStrip_OrderDESCnum;
            }
            else
            {
                customFilterLastFiltersListMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVCustomFilter.ToString()];
                sortASCMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVSortTextASC.ToString()];
                sortDESCMenuItem.Text = AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVSortTextDESC.ToString()];
                sortASCMenuItem.Image = Properties.Resources.MenuStrip_OrderASCtxt;
                sortDESCMenuItem.Image = Properties.Resources.MenuStrip_OrderDESCtxt;
            }

            //set check filter textbox
            if (DataType == typeof(DateTime) || DataType == typeof(TimeSpan) || DataType == typeof(bool))
                checkTextFilter.Enabled = false;

            //set default NOT IN logic
            IsFilterNOTINLogicEnabled = false;

            //sent enablers default
            IsSortEnabled = true;
            IsFilterEnabled = true;
            IsFilterChecklistEnabled = true;
            IsFilterDateAndTimeEnabled = true;

            //set default compoents
            customFilterLastFiltersListMenuItem.Enabled = DataType != typeof(bool);
            customFilterLastFiltersListMenuItem.Checked = ActiveFilterType == FilterType.Custom;
            MinimumSize = new Size(PreferredSize.Width, PreferredSize.Height);
            //resize
            ResizeBox(MinimumSize.Width, MinimumSize.Height);
        }

        /// <summary>
        /// Closed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuStrip_Closed(Object sender, EventArgs e)
        {
            ResizeClean();

            _startingNodes = null;

            _checkTextFilterChangedEnabled = false;
            checkTextFilter.Text = "";
            _checkTextFilterChangedEnabled = true;
        }

        /// <summary>
        /// LostFocust event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuStrip_LostFocus(Object sender, EventArgs e)
        {
            if (!ContainsFocus)
                Close();
        }

        /// <summary>
        /// Get all images for checkList
        /// </summary>
        /// <returns></returns>
        private ImageList GetCheckListStateImages()
        {
            ImageList images = new System.Windows.Forms.ImageList();
            Bitmap unCheckImg = new Bitmap(16, 16);
            Bitmap checkImg = new Bitmap(16, 16);
            Bitmap mixedImg = new Bitmap(16, 16);

            using (Bitmap img = new Bitmap(16, 16))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    CheckBoxRenderer.DrawCheckBox(g, new Point(0, 1), System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
                    unCheckImg = (Bitmap)img.Clone();
                    CheckBoxRenderer.DrawCheckBox(g, new Point(0, 1), System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal);
                    checkImg = (Bitmap)img.Clone();
                    CheckBoxRenderer.DrawCheckBox(g, new Point(0, 1), System.Windows.Forms.VisualStyles.CheckBoxState.MixedNormal);
                    mixedImg = (Bitmap)img.Clone();
                }
            }

            images.Images.Add("uncheck", unCheckImg);
            images.Images.Add("check", checkImg);
            images.Images.Add("mixed", mixedImg);

            return images;
        }

        #endregion


        #region public events

        /// <summary>
        /// The current Sorting in changed
        /// </summary>
        public event EventHandler SortChanged;

        /// <summary>
        /// The current Filter is changed
        /// </summary>
        public event EventHandler FilterChanged;

        #endregion


        #region public getter and setters

        /// <summary>
        /// Get the current MenuStripSortType type
        /// </summary>
        public SortType ActiveSortType
        {
            get
            {
                return _activeSortType;
            }
        }

        /// <summary>
        /// Get the current MenuStripFilterType type
        /// </summary>
        public FilterType ActiveFilterType
        {
            get
            {
                return _activeFilterType;
            }
        }

        /// <summary>
        /// Get the DataType for the MenuStrip Filter
        /// </summary>
        public Type DataType { get; private set; }

        /// <summary>
        /// Get or Set the Filter Sort enabled
        /// </summary>
        public bool IsSortEnabled { get; set; }

        /// <summary>
        /// Get or Set the Filter enabled
        /// </summary>
        public bool IsFilterEnabled { get; set; }

        /// <summary>
        /// Get or Set the Filter Checklist enabled
        /// </summary>
        public bool IsFilterChecklistEnabled { get; set; }

        /// <summary>
        /// Get or Set the Filter Custom enabled
        /// </summary>
        public bool IsFilterCustomEnabled { get; set; }

        /// <summary>
        /// Get or Set the Filter DateAndTime enabled
        /// </summary>
        public bool IsFilterDateAndTimeEnabled { get; set; }

        /// <summary>
        /// Get or Set the NOT IN logic for Filter
        /// </summary>
        public bool IsFilterNOTINLogicEnabled { get; set; }

        /// <summary>
        /// Set the text filter search nodes behaviour
        /// </summary>
        public bool DoesTextFilterRemoveNodesOnSearch
        {
            get
            {
                return _checkTextFilterRemoveNodesOnSearch;
            }
            set
            {
                _checkTextFilterRemoveNodesOnSearch = value;
            }
        }

        #endregion


        #region public enablers

        /// <summary>
        /// Enabled or disable Sorting capabilities
        /// </summary>
        /// <param name="enabled"></param>
        public void SetSortEnabled(bool enabled)
        {
            IsSortEnabled = enabled;

            sortASCMenuItem.Enabled = enabled;
            sortDESCMenuItem.Enabled = enabled;
            cancelSortMenuItem.Enabled = enabled;
        }

        /// <summary>
        /// Enable or disable Filter capabilities
        /// </summary>
        /// <param name="enabled"></param>
        public void SetFilterEnabled(bool enabled)
        {
            IsFilterEnabled = enabled;

            cancelFilterMenuItem.Enabled = enabled;
            customFilterLastFiltersListMenuItem.Enabled = (enabled ? DataType != typeof(bool) : false);
            button_filter.Enabled = enabled;
            button_undofilter.Enabled = enabled;
            checkList.Enabled = enabled;
            checkTextFilter.Enabled = enabled;
        }

        /// <summary>
        /// Enable or disable Filter checklist capabilities
        /// </summary>
        /// <param name="enabled"></param>
        public void SetFilterChecklistEnabled(bool enabled)
        {
            if (!IsFilterEnabled)
                enabled = false;

            IsFilterChecklistEnabled = enabled;
            checkList.Enabled = enabled;
            checkTextFilter.ReadOnly = !enabled;

            if (!IsFilterChecklistEnabled)
            {
                checkList.BeginUpdate();
                checkList.Nodes.Clear();
                TreeNodeItemSelector disablednode = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVFilterChecklistDisable.ToString()] + "            ", null, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.SelectAll);
                disablednode.NodeFont = new Font(checkList.Font, FontStyle.Bold);
                checkList.Nodes.Add(disablednode);
            }
        }

        /// <summary>
        /// Enable or disable Filter custom capabilities
        /// </summary>
        /// <param name="enabled"></param>
        public void SetFilterCustomEnabled(bool enabled)
        {
            if (!IsFilterEnabled)
                enabled = false;

            IsFilterCustomEnabled = enabled;
            customFilterMenuItem.Enabled = enabled;
            customFilterLastFiltersListMenuItem.Enabled = enabled;

            if (!IsFilterCustomEnabled)
            {
                UnCheckCustomFilters();
            }
        }

        #endregion


        #region preset loader

        public void SetLoadedMode(bool enabled)
        {
            customFilterMenuItem.Enabled = !enabled;
            cancelFilterMenuItem.Enabled = enabled;
            if (enabled)
            {
                _activeFilterType = FilterType.Loaded;
                _sortString = null;
                _filterString = null;
                _filterNodes = null;
                customFilterLastFiltersListMenuItem.Checked = false;
                for (int i = 2; i < customFilterLastFiltersListMenuItem.DropDownItems.Count - 1; i++)
                {
                    (customFilterLastFiltersListMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked = false;
                }
                checkList.Nodes.Clear();
                TreeNodeItemSelector allnode = TreeNodeItemSelector.CreateNode("(Select All)" + "            ", null, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.SelectAll);
                allnode.NodeFont = new Font(checkList.Font, FontStyle.Bold);
                allnode.CheckState = CheckState.Indeterminate;
                checkList.Nodes.Add(allnode);

                SetSortEnabled(false);
                SetFilterEnabled(false);
            }
            else
            {
                _activeFilterType = FilterType.None;

                SetSortEnabled(true);
                SetFilterEnabled(true);
            }
        }

        #endregion


        #region public show methods

        /// <summary>
        /// Show the menuStrip
        /// </summary>
        /// <param name="control"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="vals"></param>
        public void Show(Control control, int x, int y, DataGridView datagridView, string columName, IEnumerable<DataGridViewCell> vals)
        {
            BuildNodes(datagridView, columName, vals);
            if (_checkTextFilterRemoveNodesOnSearch && checkList.Nodes.Count != _initialNodes.Count())
            {
                _initialNodes = new TreeNodeItemSelector[checkList.Nodes.Count];
                _restoreNodes = new TreeNodeItemSelector[checkList.Nodes.Count];
                int i = 0;
                foreach (TreeNodeItemSelector n in checkList.Nodes)
                {
                    _initialNodes[i] = n.Clone();
                    _restoreNodes[i] = n.Clone();
                    i++;
                }
            }

            if (_activeFilterType == FilterType.Custom)
                SetNodesCheckState(checkList.Nodes, false);
            DuplicateNodes();
            base.Show(control, x, y);

            _checkTextFilterChangedEnabled = false;
            checkTextFilter.Text = "";
            _checkTextFilterChangedEnabled = true;
        }

        /// <summary>
        /// Show the menuStrip
        /// </summary>
        /// <param name="control"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="vals"></param>
        public void Show(Control control, int x, int y, DataGridView grid, int columnIndex)
        {
            BuildNodes(grid, columnIndex);
            // BuildNodes(grid, columnName);
            if (_checkTextFilterRemoveNodesOnSearch && checkList.Nodes.Count != _initialNodes.Count())
            {
                _initialNodes = new TreeNodeItemSelector[checkList.Nodes.Count];
                _restoreNodes = new TreeNodeItemSelector[checkList.Nodes.Count];
                int i = 0;
                foreach (TreeNodeItemSelector n in checkList.Nodes)
                {
                    _initialNodes[i] = n.Clone();
                    _restoreNodes[i] = n.Clone();
                    i++;
                }
            }

            if (_activeFilterType == FilterType.Custom)
                SetNodesCheckState(checkList.Nodes, false);
            DuplicateNodes();
            base.Show(control, x, y);

            _checkTextFilterChangedEnabled = false;
            checkTextFilter.Text = "";
            _checkTextFilterChangedEnabled = true;
        }


        /// <summary>
        /// Show the menuStrip
        /// </summary>
        /// <param name="control"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="vals"></param>
        public void Show(Control control, int x, int y, DataGridView grid, string columnName)
        {
            // BuildNodes(grid, columnIndex);
            BuildNodes(grid, columnName);
            if (_checkTextFilterRemoveNodesOnSearch && checkList.Nodes.Count != _initialNodes.Count())
            {
                _initialNodes = new TreeNodeItemSelector[checkList.Nodes.Count];
                _restoreNodes = new TreeNodeItemSelector[checkList.Nodes.Count];
                int i = 0;
                foreach (TreeNodeItemSelector n in checkList.Nodes)
                {
                    _initialNodes[i] = n.Clone();
                    _restoreNodes[i] = n.Clone();
                    i++;
                }
            }

            if (_activeFilterType == FilterType.Custom)
                SetNodesCheckState(checkList.Nodes, false);
            DuplicateNodes();
            base.Show(control, x, y);

            _checkTextFilterChangedEnabled = false;
            checkTextFilter.Text = "";
            _checkTextFilterChangedEnabled = true;
        }

        /// <summary>
        /// Show the menuStrip
        /// </summary>
        /// <param name="control"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="_restoreFilter"></param>
        public void Show(Control control, int x, int y, bool _restoreFilter)
        {
            _checkTextFilterChangedEnabled = false;
            checkTextFilter.Text = "";
            _checkTextFilterChangedEnabled = true;
            if (_restoreFilter)
                RestoreFilterNodes();
            DuplicateNodes();
            base.Show(control, x, y);

            if (_checkTextFilterRemoveNodesOnSearch && _checkTextFilterSetByText)
            {
                _restoreNodes = new TreeNodeItemSelector[_initialNodes.Count()];
                int i = 0;
                foreach (TreeNodeItemSelector n in _initialNodes)
                {
                    _restoreNodes[i] = n.Clone();
                    i++;
                }
                checkList.BeginUpdate();
                checkList.Nodes.Clear();
                foreach (TreeNodeItemSelector node in _initialNodes)
                {
                    checkList.Nodes.Add(node);
                }
                checkList.EndUpdate();
            }
        }

        /// <summary>
        /// Get values used for Show method
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static IEnumerable<DataGridViewCell> GetValuesForFilter(DataGridView grid, string columnName)
        {
            var vals =
                from DataGridViewRow nulls in grid.Rows
                select nulls.Cells[columnName];

            return vals;
        }

        #endregion


        #region public sort methods

        /// <summary>
        /// Sort ASC
        /// </summary>
        public void SortASC()
        {
            SortASCMenuItem_Click(this, null);
        }

        /// <summary>
        /// Sort DESC
        /// </summary>
        public void SortDESC()
        {
            SortDESCMenuItem_Click(this, null);
        }

        /// <summary>
        /// Get the Sorting String
        /// </summary>
        public string SortString
        {
            get
            {
                return (!String.IsNullOrEmpty(_sortString) ? _sortString : "");
            }
            private set
            {
                cancelSortMenuItem.Enabled = (value != null && value.Length > 0);
                _sortString = value;
            }
        }

        /// <summary>
        /// Clean the Sorting
        /// </summary>
        public void CleanSort()
        {
            string oldsort = SortString;
            sortASCMenuItem.Checked = false;
            sortDESCMenuItem.Checked = false;
            _activeSortType = SortType.None;
            SortString = null;
        }

        #endregion


        #region public filter methods

        /// <summary>
        /// Get the Filter string
        /// </summary>
        public string FilterString
        {
            get
            {
                return (!String.IsNullOrEmpty(_filterString) ? _filterString : "");
            }
            private set
            {
                cancelFilterMenuItem.Enabled = (value != null && value.Length > 0);
                _filterString = value;
            }
        }

        /// <summary>
        /// Clean the Filter
        /// </summary>
        public void CleanFilter()
        {
            if (_checkTextFilterRemoveNodesOnSearch)
            {
                _initialNodes = new TreeNodeItemSelector[] { };
                _restoreNodes = new TreeNodeItemSelector[] { };
                _checkTextFilterSetByText = false;
            }

            for (int i = 2; i < customFilterLastFiltersListMenuItem.DropDownItems.Count - 1; i++)
            {
                (customFilterLastFiltersListMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked = false;
            }
            _activeFilterType = FilterType.None;
            SetNodesCheckState(checkList.Nodes, true);
            string oldsort = FilterString;
            FilterString = null;
            _filterNodes = null;
            customFilterLastFiltersListMenuItem.Checked = false;
            button_filter.Enabled = true;
        }

        /// <summary>
        /// Set the text filter on checklist remove node mode
        /// </summary>
        /// <param name="enabled"></param>
        public void SetChecklistTextFilterRemoveNodesOnSearchMode(bool enabled)
        {
            if (_checkTextFilterRemoveNodesOnSearch != enabled)
            {
                _checkTextFilterRemoveNodesOnSearch = enabled;
                CleanFilter();
            }
        }

        #endregion


        #region checklist filter methods

        /// <summary>
        /// Set the Filter String using checkList selected Nodes
        /// </summary>
        private void SetCheckListFilter()
        {
            UnCheckCustomFilters();

            TreeNodeItemSelector selectAllNode = GetSelectAllNode();
            customFilterLastFiltersListMenuItem.Checked = false;

            if (selectAllNode != null && selectAllNode.Checked)
                CancelFilterMenuItem_Click(null, new EventArgs());
            else
            {
                string oldfilter = FilterString;
                FilterString = "";
                _activeFilterType = FilterType.CheckList;

                if (checkList.Nodes.Count > 1)
                {
                    selectAllNode = GetSelectEmptyNode();
                    if (selectAllNode != null && selectAllNode.Checked)
                        FilterString = "[{0}] IS NULL";

                    if (checkList.Nodes.Count > 2 || selectAllNode == null)
                    {
                        string filter = BuildNodesFilterString(
                            (IsFilterNOTINLogicEnabled && (DataType != typeof(DateTime) && DataType != typeof(TimeSpan) && DataType != typeof(bool)) ?
                                checkList.Nodes.AsParallel().Cast<TreeNodeItemSelector>().Where(
                                    n => n.NodeType != TreeNodeItemSelector.CustomNodeType.SelectAll
                                        && n.NodeType != TreeNodeItemSelector.CustomNodeType.SelectEmpty
                                        && n.CheckState == CheckState.Unchecked
                                ) :
                                checkList.Nodes.AsParallel().Cast<TreeNodeItemSelector>().Where(
                                    n => n.NodeType != TreeNodeItemSelector.CustomNodeType.SelectAll
                                        && n.NodeType != TreeNodeItemSelector.CustomNodeType.SelectEmpty
                                        && n.CheckState != CheckState.Unchecked
                                ))
                        );

                        if (filter.Length > 0)
                        {
                            if (FilterString.Length > 0)
                                FilterString += " OR ";

                            if (DataType == typeof(DateTime) || DataType == typeof(TimeSpan))
                                FilterString += filter;
                            else if (DataType == typeof(bool))
                                FilterString += "[{0}] =" + filter;
                            else if (DataType == typeof(Int32) || DataType == typeof(Int64) || DataType == typeof(Int16) ||
                                        DataType == typeof(UInt32) || DataType == typeof(UInt64) || DataType == typeof(UInt16) ||
                                        DataType == typeof(Decimal) ||
                                        DataType == typeof(Byte) || DataType == typeof(SByte) || DataType == typeof(String))
                            {
                                if (IsFilterNOTINLogicEnabled)
                                    FilterString += "[{0}] NOT IN (" + filter + ")";
                                else
                                    FilterString += "[{0}] IN (" + filter + ")";
                            }
                            else if (DataType == typeof(Double))
                            {
                                if (IsFilterNOTINLogicEnabled)
                                    FilterString += "Convert([{0}],System.String) NOT IN (" + filter + ")";
                                else
                                    FilterString += "Convert([{0}],System.String) IN (" + filter + ")";
                            }
                            else if (DataType == typeof(Bitmap))
                            { }
                            else
                            {
                                if (IsFilterNOTINLogicEnabled)
                                    FilterString += "Convert([{0}],System.String) NOT IN (" + filter + ")";
                                else
                                    FilterString += "Convert([{0}],System.String) IN (" + filter + ")";
                            }
                        }
                    }
                }

                DuplicateFilterNodes();

                if (oldfilter != FilterString && FilterChanged != null)
                    FilterChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Build a Filter string based on selectd Nodes
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private string BuildNodesFilterString(IEnumerable<TreeNodeItemSelector> nodes)
        {
            StringBuilder sb = new StringBuilder("");
            string appx = (DataType == typeof(DateTime) || DataType == typeof(TimeSpan)) ? " OR " : ", ";

            if (nodes != null && nodes.Count() > 0)
            {
                if (DataType == typeof(DateTime))
                {
                    foreach (TreeNodeItemSelector n in nodes)
                    {
                        if (n.Checked && (n.Nodes.AsParallel().Cast<TreeNodeItemSelector>().Where(sn => sn.CheckState != CheckState.Unchecked).Count() == 0))
                        {
                            DateTime dt = (DateTime)n.Value;
                            sb.Append("(Convert([{0}], 'System.String') LIKE '%" + Convert.ToString((IsFilterDateAndTimeEnabled ? dt : dt.Date), CultureInfo.CurrentCulture) + "%')" + appx);
                        }
                        else if (n.CheckState != CheckState.Unchecked && n.Nodes.Count > 0)
                        {
                            string subnode = BuildNodesFilterString(n.Nodes.AsParallel().Cast<TreeNodeItemSelector>().Where(sn => sn.CheckState != CheckState.Unchecked));
                            if (subnode.Length > 0)
                                sb.Append(subnode + appx);
                        }
                    }
                }
                else if (DataType == typeof(TimeSpan))
                {
                    foreach (TreeNodeItemSelector n in nodes)
                    {
                        if (n.Checked && (n.Nodes.AsParallel().Cast<TreeNodeItemSelector>().Where(sn => sn.CheckState != CheckState.Unchecked).Count() == 0))
                        {
                            TimeSpan ts = (TimeSpan)n.Value;
                            sb.Append("(Convert([{0}], 'System.String') LIKE '%P" + ((int)ts.Days > 0 ? (int)ts.Days + "D" : "") + (ts.TotalHours > 0 ? "T" : "") + ((int)ts.Hours > 0 ? (int)ts.Hours + "H" : "") + ((int)ts.Minutes > 0 ? (int)ts.Minutes + "M" : "") + ((int)ts.Seconds > 0 ? (int)ts.Seconds + "S" : "") + "%')" + appx);
                        }
                        else if (n.CheckState != CheckState.Unchecked && n.Nodes.Count > 0)
                        {
                            string subnode = BuildNodesFilterString(n.Nodes.AsParallel().Cast<TreeNodeItemSelector>().Where(sn => sn.CheckState != CheckState.Unchecked));
                            if (subnode.Length > 0)
                                sb.Append(subnode + appx);
                        }
                    }
                }
                else if (DataType == typeof(bool))
                {
                    foreach (TreeNodeItemSelector n in nodes)
                    {
                        sb.Append(n.Value.ToString());
                        break;
                    }
                }
                else if (DataType == typeof(Int32) || DataType == typeof(Int64) || DataType == typeof(Int16) ||
                    DataType == typeof(UInt32) || DataType == typeof(UInt64) || DataType == typeof(UInt16) ||
                    DataType == typeof(Byte) || DataType == typeof(SByte))
                {
                    foreach (TreeNodeItemSelector n in nodes)
                        sb.Append(n.Value.ToString() + appx);
                }
                else if (DataType == typeof(Single) || DataType == typeof(Double) || DataType == typeof(Decimal))
                {
                    foreach (TreeNodeItemSelector n in nodes)
                        sb.Append(n.Value.ToString().Replace(",", ".") + appx);
                }
                else if (DataType == typeof(Bitmap))
                { }
                else
                {
                    foreach (TreeNodeItemSelector n in nodes)
                        sb.Append("'" + FormatFilterString(n.Value.ToString()) + "'" + appx);
                }
            }

            if (sb.Length > appx.Length && DataType != typeof(bool))
                sb.Remove(sb.Length - appx.Length, appx.Length);

            return sb.ToString();
        }

        /// <summary>
        /// Format a text Filter string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string FormatFilterString(string text)
        {
            return text.Replace("'", "''");
        }

        /// <summary>
        /// Add nodes to checkList
        /// </summary>
        /// <param name="vals"></param>
        private void BuildNodes(IEnumerable<DataGridViewCell> vals)
        {
            if (!IsFilterChecklistEnabled)
                return;

            checkList.BeginUpdate();
            checkList.Nodes.Clear();

            if (vals != null)
            {
                checkList.EndUpdate();
                return;
            }

            //add select all node
            TreeNodeItemSelector allnode = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectAll.ToString()] + "            ", null, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.SelectAll);
            allnode.NodeFont = new Font(checkList.Font, FontStyle.Bold);
            checkList.Nodes.Add(allnode);

            if (vals.Count() > 0)
            {
                var nonulls = vals.Where<DataGridViewCell>(c => c.Value != null && c.Value != DBNull.Value);

                //add select empty node
                if (vals.Count() != nonulls.Count())
                {
                    TreeNodeItemSelector nullnode = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectEmpty.ToString()] + "               ", null, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.SelectEmpty);
                    nullnode.NodeFont = new Font(checkList.Font, FontStyle.Bold);
                    checkList.Nodes.Add(nullnode);
                }

                //add datetime nodes
                if (DataType == typeof(DateTime))
                {
                    var years =
                        from year in nonulls
                        group year by ((DateTime)year.Value).Year into cy
                        orderby cy.Key ascending
                        select cy;

                    foreach (var year in years)
                    {
                        TreeNodeItemSelector yearnode = TreeNodeItemSelector.CreateNode(year.Key.ToString(), year.Key, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.DateTimeNode);
                        checkList.Nodes.Add(yearnode);

                        var months =
                            from month in year
                            group month by ((DateTime)month.Value).Month into cm
                            orderby cm.Key ascending
                            select cm;

                        foreach (var month in months)
                        {
                            TreeNodeItemSelector monthnode = yearnode.CreateChildNode(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month.Key), month.Key);

                            var days =
                                from day in month
                                group day by ((DateTime)day.Value).Day into cd
                                orderby cd.Key ascending
                                select cd;

                            foreach (var day in days)
                            {
                                TreeNodeItemSelector daysnode;

                                if (!IsFilterDateAndTimeEnabled)
                                    daysnode = monthnode.CreateChildNode(day.Key.ToString("D2"), day.First().Value);
                                else
                                {
                                    daysnode = monthnode.CreateChildNode(day.Key.ToString("D2"), day.Key);

                                    var hours =
                                        from hour in day
                                        group hour by ((DateTime)hour.Value).Hour into ch
                                        orderby ch.Key ascending
                                        select ch;

                                    foreach (var hour in hours)
                                    {
                                        TreeNodeItemSelector hoursnode = daysnode.CreateChildNode(hour.Key.ToString("D2") + " " + "h", hour.Key);

                                        var mins =
                                            from min in hour
                                            group min by ((DateTime)min.Value).Minute into cmin
                                            orderby cmin.Key ascending
                                            select cmin;

                                        foreach (var min in mins)
                                        {
                                            TreeNodeItemSelector minsnode = hoursnode.CreateChildNode(min.Key.ToString("D2") + " " + "m", min.Key);

                                            var secs =
                                                from sec in min
                                                group sec by ((DateTime)sec.Value).Second into cs
                                                orderby cs.Key ascending
                                                select cs;

                                            foreach (var sec in secs)
                                            {
                                                TreeNodeItemSelector secsnode = minsnode.CreateChildNode(sec.Key.ToString("D2") + " " + "s", sec.First().Value);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //add timespan nodes
                else if (DataType == typeof(TimeSpan))
                {
                    var days =
                        from day in nonulls
                        group day by ((TimeSpan)day.Value).Days into cd
                        orderby cd.Key ascending
                        select cd;

                    foreach (var day in days)
                    {
                        TreeNodeItemSelector daysnode = TreeNodeItemSelector.CreateNode(day.Key.ToString("D2"), day.Key, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.DateTimeNode);
                        checkList.Nodes.Add(daysnode);

                        var hours =
                            from hour in day
                            group hour by ((TimeSpan)hour.Value).Hours into ch
                            orderby ch.Key ascending
                            select ch;

                        foreach (var hour in hours)
                        {
                            TreeNodeItemSelector hoursnode = daysnode.CreateChildNode(hour.Key.ToString("D2") + " " + "h", hour.Key);

                            var mins =
                                from min in hour
                                group min by ((TimeSpan)min.Value).Minutes into cmin
                                orderby cmin.Key ascending
                                select cmin;

                            foreach (var min in mins)
                            {
                                TreeNodeItemSelector minsnode = hoursnode.CreateChildNode(min.Key.ToString("D2") + " " + "m", min.Key);

                                var secs =
                                    from sec in min
                                    group sec by ((TimeSpan)sec.Value).Seconds into cs
                                    orderby cs.Key ascending
                                    select cs;

                                foreach (var sec in secs)
                                {
                                    TreeNodeItemSelector secsnode = minsnode.CreateChildNode(sec.Key.ToString("D2") + " " + "s", sec.First().Value);
                                }
                            }
                        }
                    }
                }

                //add boolean nodes
                else if (DataType == typeof(bool))
                {
                    var values = nonulls.Where<DataGridViewCell>(c => (bool)c.Value == true);

                    if (values.Count() != nonulls.Count())
                    {
                        TreeNodeItemSelector node = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectFalse.ToString()], false, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.Default);
                        checkList.Nodes.Add(node);
                    }

                    if (values.Count() > 0)
                    {
                        TreeNodeItemSelector node = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectTrue.ToString()], true, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.Default);
                        checkList.Nodes.Add(node);
                    }
                }

                //ignore image nodes
                else if (DataType == typeof(Bitmap))
                { }

                //add string nodes
                else
                {
                    foreach (var v in nonulls.GroupBy(c => c.Value).OrderBy(g => g.Key))
                    {
                        TreeNodeItemSelector node = TreeNodeItemSelector.CreateNode(v.First().FormattedValue.ToString(), v.Key, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.Default);
                        checkList.Nodes.Add(node);
                    }
                }
            }


            checkList.EndUpdate();
        }

        /// <summary>
        /// Add nodes to checkList
        /// </summary>
        /// <param name="vals"></param>
        private void BuildNodes(DataGridView grid, string columName, IEnumerable<DataGridViewCell> vals)
        {
            if (!IsFilterChecklistEnabled)
                return;
            BindingSource bs = grid.DataSource as BindingSource;
            if (bs == null) return;
            DataTable gridTable = (DataTable)bs.DataSource;

            // Get datatype column
            DataType = gridTable.Columns[columName].DataType;

            checkList.BeginUpdate();
            checkList.Nodes.Clear();

            if (vals != null)
            {
                //add select all node
                TreeNodeItemSelector allnode = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectAll.ToString()] + "            ", null, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.SelectAll);
                allnode.NodeFont = new Font(checkList.Font, FontStyle.Bold);
                checkList.Nodes.Add(allnode);

                if (vals.Count() > 0)
                {
                    var nonulls = vals.Where<DataGridViewCell>(c => c.Value != null && c.Value != DBNull.Value);

                    //add select empty node
                    if (vals.Count() != nonulls.Count())
                    {
                        TreeNodeItemSelector nullnode = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectEmpty.ToString()] + "               ", null, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.SelectEmpty);
                        nullnode.NodeFont = new Font(checkList.Font, FontStyle.Bold);
                        checkList.Nodes.Add(nullnode);
                    }

                    //add datetime nodes
                    if (DataType == typeof(DateTime))
                    {
                        var years =
                            from year in nonulls
                            group year by ((DateTime)year.Value).Year into cy
                            orderby cy.Key ascending
                            select cy;

                        foreach (var year in years)
                        {
                            TreeNodeItemSelector yearnode = TreeNodeItemSelector.CreateNode(year.Key.ToString(), year.Key, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.DateTimeNode);
                            checkList.Nodes.Add(yearnode);

                            var months =
                                from month in year
                                group month by ((DateTime)month.Value).Month into cm
                                orderby cm.Key ascending
                                select cm;

                            foreach (var month in months)
                            {
                                TreeNodeItemSelector monthnode = yearnode.CreateChildNode(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month.Key), month.Key);

                                var days =
                                    from day in month
                                    group day by ((DateTime)day.Value).Day into cd
                                    orderby cd.Key ascending
                                    select cd;

                                foreach (var day in days)
                                {
                                    TreeNodeItemSelector daysnode;

                                    if (!IsFilterDateAndTimeEnabled)
                                        daysnode = monthnode.CreateChildNode(day.Key.ToString("D2"), day.First().Value);
                                    else
                                    {
                                        #region HH
                                        //daysnode = monthnode.CreateChildNode(day.Key.ToString("D2"), day.Key);

                                        //var hours =
                                        //    from hour in day
                                        //    group hour by ((DateTime)hour.Value).Hour into ch
                                        //    orderby ch.Key ascending
                                        //    select ch;

                                        //foreach (var hour in hours)
                                        //{
                                        //    TreeNodeItemSelector hoursnode = daysnode.CreateChildNode(hour.Key.ToString("D2") + " " + "h", hour.Key);

                                        //    var mins =
                                        //        from min in hour
                                        //        group min by ((DateTime)min.Value).Minute into cmin
                                        //        orderby cmin.Key ascending
                                        //        select cmin;

                                        //    foreach (var min in mins)
                                        //    {
                                        //        TreeNodeItemSelector minsnode = hoursnode.CreateChildNode(min.Key.ToString("D2") + " " + "m", min.Key);

                                        //        var secs =
                                        //            from sec in min
                                        //            group sec by ((DateTime)sec.Value).Second into cs
                                        //            orderby cs.Key ascending
                                        //            select cs;

                                        //        foreach (var sec in secs)
                                        //        {
                                        //            TreeNodeItemSelector secsnode = minsnode.CreateChildNode(sec.Key.ToString("D2") + " " + "s", sec.First().Value);
                                        //        }
                                        //    }
                                        //}
                                        #endregion
                                    }
                                }
                            }
                        }
                    }

                    //add timespan nodes
                    else if (DataType == typeof(TimeSpan))
                    {
                        var days =
                            from day in nonulls
                            group day by ((TimeSpan)day.Value).Days into cd
                            orderby cd.Key ascending
                            select cd;

                        foreach (var day in days)
                        {
                            TreeNodeItemSelector daysnode = TreeNodeItemSelector.CreateNode(day.Key.ToString("D2"), day.Key, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.DateTimeNode);
                            checkList.Nodes.Add(daysnode);

                            var hours =
                                from hour in day
                                group hour by ((TimeSpan)hour.Value).Hours into ch
                                orderby ch.Key ascending
                                select ch;

                            foreach (var hour in hours)
                            {
                                TreeNodeItemSelector hoursnode = daysnode.CreateChildNode(hour.Key.ToString("D2") + " " + "h", hour.Key);

                                var mins =
                                    from min in hour
                                    group min by ((TimeSpan)min.Value).Minutes into cmin
                                    orderby cmin.Key ascending
                                    select cmin;

                                foreach (var min in mins)
                                {
                                    TreeNodeItemSelector minsnode = hoursnode.CreateChildNode(min.Key.ToString("D2") + " " + "m", min.Key);

                                    var secs =
                                        from sec in min
                                        group sec by ((TimeSpan)sec.Value).Seconds into cs
                                        orderby cs.Key ascending
                                        select cs;

                                    foreach (var sec in secs)
                                    {
                                        TreeNodeItemSelector secsnode = minsnode.CreateChildNode(sec.Key.ToString("D2") + " " + "s", sec.First().Value);
                                    }
                                }
                            }
                        }
                    }

                    //add boolean nodes
                    else if (DataType == typeof(bool))
                    {
                        var values = nonulls.Where<DataGridViewCell>(c => (bool)c.Value == true);

                        if (values.Count() != nonulls.Count())
                        {
                            TreeNodeItemSelector node = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectFalse.ToString()], false, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.Default);
                            checkList.Nodes.Add(node);
                        }

                        if (values.Count() > 0)
                        {
                            TreeNodeItemSelector node = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectTrue.ToString()], true, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.Default);
                            checkList.Nodes.Add(node);
                        }
                    }

                    //ignore image nodes
                    else if (DataType == typeof(Bitmap))
                    { }

                    //add string nodes
                    else
                    {
                        foreach (var v in nonulls.GroupBy(c => c.Value).OrderBy(g => g.Key))
                        {
                            TreeNodeItemSelector node = TreeNodeItemSelector.CreateNode(v.First().FormattedValue.ToString(), v.Key, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.Default);
                            checkList.Nodes.Add(node);
                        }
                    }
                }
            }

            checkList.EndUpdate();
        }

        /// <summary>
        /// Add nodes to checkList
        /// </summary>
        /// <param name="vals"></param>
        private void BuildNodes(DataGridView grid, string columName)
        {
            if (!IsFilterChecklistEnabled || string.IsNullOrWhiteSpace(columName))
                return;

            BindingSource bs = grid.DataSource as BindingSource;
            if (bs == null)
                return;

            DataTable gridTable = bs.DataSource as DataTable;

            var columnExist = gridTable.Columns.Cast<DataColumn>().Where(r => r.ColumnName.Equals(columName)).FirstOrDefault();
            if (columnExist == null)
                return;

            // Get datatype column
            DataType = gridTable.Columns[columName].DataType;

            checkList.BeginUpdate();
            checkList.Nodes.Clear();

            if (gridTable != null)
            {
                //add select all node
                TreeNodeItemSelector allnode = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectAll.ToString()] + "            ", null, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.SelectAll);
                allnode.NodeFont = new Font(checkList.Font, FontStyle.Bold);
                checkList.Nodes.Add(allnode);

                if (gridTable.Rows.Count > 0)
                {
                    DataTable nonulls = null;
                    try
                    {
                        nonulls = gridTable.AsEnumerable().Where(r => r.Field<object>(columName) != null && r.Field<object>(columName) != DBNull.Value).CopyToDataTable();
                    }
                    catch (Exception ex)
                    {
                        checkList.EndUpdate();
                        return;
                    }

                    //add select empty node
                    if (gridTable.Rows.Count != nonulls.Rows.Count)
                    {
                        TreeNodeItemSelector nullnode = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectEmpty.ToString()] + "               ", null, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.SelectEmpty);
                        nullnode.NodeFont = new Font(checkList.Font, FontStyle.Bold);
                        checkList.Nodes.Add(nullnode);
                    }

                    //add datetime nodes
                    if (DataType == typeof(DateTime))
                    {
                        DataTable dtYear = nonulls.AsEnumerable().OrderBy(r => r.Field<DateTime>(columName)).GroupBy(r => new { year = r.Field<DateTime>(columName).Year }).Select(g => g.OrderBy(r => r.Field<DateTime>(columName)).First()).CopyToDataTable();

                        foreach (DataRow year in dtYear.Rows)
                        {
                            TreeNodeItemSelector yearnode = TreeNodeItemSelector.CreateNode(year.Field<DateTime>(columName).Year.ToString(), year.Field<DateTime>(columName), CheckState.Checked, TreeNodeItemSelector.CustomNodeType.DateTimeNode);
                            checkList.Nodes.Add(yearnode);

                            DataTable dtMonth = nonulls.AsEnumerable().OrderBy(r => r.Field<DateTime>(columName)).Where(y => y.Field<DateTime>(columName).Year == year.Field<DateTime>(columName).Year).GroupBy(r => new { month = r.Field<DateTime>(columName).Month }).Select(g => g.OrderBy(r => r.Field<DateTime>(columName).Year).First()).CopyToDataTable();

                            foreach (DataRow month in dtMonth.Rows)
                            {
                                TreeNodeItemSelector monthnode = yearnode.CreateChildNode(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month.Field<DateTime>(columName).Month), month.Field<DateTime>(columName));

                                DataTable dtDays = nonulls.AsEnumerable().OrderBy(r => r.Field<DateTime>(columName)).Where(y => ((y.Field<DateTime>(columName)).Year == year.Field<DateTime>(columName).Year) && y.Field<DateTime>(columName).Month == month.Field<DateTime>(columName).Month).GroupBy(r => new { day = r.Field<DateTime>(columName).Day }).Select(g => g.OrderByDescending(r => r.Field<DateTime>(columName).Day).First()).CopyToDataTable();

                                foreach (DataRow day in dtDays.Rows)
                                {
                                    TreeNodeItemSelector daysnode;

                                    if (!IsFilterDateAndTimeEnabled)
                                        daysnode = monthnode.CreateChildNode(((DateTime)day.Field<DateTime>(columName)).Day.ToString("D2"), ((DateTime)day.Field<DateTime>(columName)));
                                    else
                                    {
                                        daysnode = monthnode.CreateChildNode(((DateTime)day.Field<DateTime>(columName)).Day.ToString("D2"), ((DateTime)day.Field<DateTime>(columName)));

                                        #region HH
                                        //DataTable dtHours = nonulls.AsEnumerable().Where(y => (((DateTime)y.Field<DateTime>(columName)).Year == ((DateTime)year.Field<DateTime>(columName)).Year) && (((DateTime)y.Field<DateTime>(columName)).Month == ((DateTime)month.Field<DateTime>(columName)).Month) && (((DateTime)y.Field<DateTime>(columName)).Day == ((DateTime)day.Field<DateTime>(columName)).Day)).GroupBy(r => new { hour = ((DateTime)r.Field<DateTime>(columName)).Hour }).Select(g => g.OrderBy(r => ((DateTime)r[columName]).Hour).First()).CopyToDataTable();

                                        //foreach (DataRow hour in dtHours.Rows)
                                        //{
                                        //    TreeNodeItemSelector hoursnode = daysnode.CreateChildNode(((DateTime)hour.Field<DateTime>(columName)).Hour.ToString("D2") + " " + "h", ((DateTime)hour.Field<DateTime>(columName)));

                                        //    DataTable dtMins = nonulls.AsEnumerable().Where(y => (((DateTime)y.Field<DateTime>(columName)).Year == ((DateTime)year.Field<DateTime>(columName)).Year) && (((DateTime)y.Field<DateTime>(columName)).Month == ((DateTime)month.Field<DateTime>(columName)).Month) && (((DateTime)y.Field<DateTime>(columName)).Day == ((DateTime)day.Field<DateTime>(columName)).Day) && (((DateTime)y.Field<DateTime>(columName)).Hour == ((DateTime)hour.Field<DateTime>(columName)).Hour)).GroupBy(r => new { hour = ((DateTime)r.Field<DateTime>(columName)).Minute }).Select(g => g.OrderBy(r => ((DateTime)r[columName]).Minute).First()).CopyToDataTable();

                                        //    foreach (DataRow min in dtMins.Rows)
                                        //    {
                                        //        TreeNodeItemSelector minsnode = hoursnode.CreateChildNode(((DateTime)min.Field<DateTime>(columName)).Minute.ToString("D2") + " " + "m", ((DateTime)min.Field<DateTime>(columName)));
                                        //        DataTable dtSecs = nonulls.AsEnumerable().Where(y => (((DateTime)y.Field<DateTime>(columName)).Year == ((DateTime)year.Field<DateTime>(columName)).Year) && (((DateTime)y.Field<DateTime>(columName)).Month == ((DateTime)month.Field<DateTime>(columName)).Month) && (((DateTime)y.Field<DateTime>(columName)).Day == ((DateTime)day.Field<DateTime>(columName)).Day) && (((DateTime)y.Field<DateTime>(columName)).Hour == ((DateTime)hour.Field<DateTime>(columName)).Hour) && (((DateTime)y.Field<DateTime>(columName)).Minute == ((DateTime)min.Field<DateTime>(columName)).Minute)).GroupBy(r => new { sec = ((DateTime)r.Field<DateTime>(columName)).Second }).Select(g => g.OrderBy(r => ((DateTime)r[columName]).Second).First()).CopyToDataTable();
                                        //        foreach (DataRow sec in dtSecs.Rows)
                                        //        {
                                        //            TreeNodeItemSelector secsnode = minsnode.CreateChildNode(((DateTime)sec.Field<DateTime>(columName)).Second.ToString("D2") + " " + "s", ((DateTime)sec.Field<DateTime>(columName)));
                                        //        }
                                        //    }
                                        //}

                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                    //add timespan nodes
                    else if (DataType == typeof(TimeSpan))
                    {
                        DataTable dtDays = nonulls.AsEnumerable().GroupBy(r => new { day = r.Field<TimeSpan>(columName).Days }).Select(g => g.OrderBy(r => r.Field<TimeSpan>(columName)).First()).CopyToDataTable();

                        foreach (DataRow day in dtDays.Rows)
                        {
                            TreeNodeItemSelector daysnode = TreeNodeItemSelector.CreateNode(day.Field<TimeSpan>(columName).Days.ToString("D2"), day.Field<TimeSpan>(columName), CheckState.Checked, TreeNodeItemSelector.CustomNodeType.DateTimeNode);
                            checkList.Nodes.Add(daysnode);

                            DataTable dtHours = nonulls.AsEnumerable().Where(r => r.Field<TimeSpan>(columName).Days == day.Field<TimeSpan>(columName).Days).GroupBy(r => new { hour = r.Field<TimeSpan>(columName).Hours }).Select(g => g.OrderBy(r => r.Field<TimeSpan>(columName).Hours).First()).CopyToDataTable();

                            foreach (DataRow hour in dtHours.Rows)
                            {
                                TreeNodeItemSelector hoursnode = daysnode.CreateChildNode(hour.Field<TimeSpan>(columName).Hours.ToString("D2") + " " + "h", hour.Field<TimeSpan>(columName).Hours);

                                DataTable dtMins = nonulls.AsEnumerable().Where(r => r.Field<TimeSpan>(columName).Hours == hour.Field<TimeSpan>(columName).Hours).GroupBy(r => new { day = r.Field<TimeSpan>(columName).Minutes }).Select(g => g.OrderBy(r => r.Field<TimeSpan>(columName)).First()).CopyToDataTable();

                                foreach (DataRow min in dtMins.Rows)
                                {
                                    TreeNodeItemSelector minsnode = hoursnode.CreateChildNode(min.Field<TimeSpan>(columName).Minutes.ToString("D2") + " " + "m", min.Field<TimeSpan>(columName));

                                    DataTable dtSecs = nonulls.AsEnumerable().Where(r => r.Field<TimeSpan>(columName).Minutes == hour.Field<TimeSpan>(columName).Minutes).GroupBy(r => new { second = r.Field<TimeSpan>(columName).Seconds }).Select(g => g.OrderBy(r => r.Field<TimeSpan>(columName)).First()).CopyToDataTable();

                                    foreach (DataRow sec in dtSecs.Rows)
                                    {
                                        TreeNodeItemSelector secsnode = minsnode.CreateChildNode(sec.Field<TimeSpan>(columName).Seconds.ToString("D2") + " " + "s", sec.Field<TimeSpan>(columName));
                                    }
                                }
                            }
                        }
                    }
                    //add boolean nodes
                    else if (DataType == typeof(bool))
                    {                       
                        DataTable values = null;
                        try
                        {
                            values = gridTable.AsEnumerable().Where(r => !(bool)r.Field<bool>(columName)).CopyToDataTable();
                        }
                        catch
                        {
                            checkList.EndUpdate();
                            return;
                        }

                        if (values.Rows.Count != nonulls.Rows.Count)
                        {
                            TreeNodeItemSelector node = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectFalse.ToString()], false, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.Default);
                            checkList.Nodes.Add(node);
                        }

                        if (values.Rows.Count > 0)
                        {
                            TreeNodeItemSelector node = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectTrue.ToString()], true, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.Default);
                            checkList.Nodes.Add(node);
                        }
                    }

                    //ignore image nodes
                    else if (DataType == typeof(Bitmap))
                    { }

                    //add string nodes
                    else //if (DataType == typeof(string))
                    {
                        foreach (var v in nonulls.AsEnumerable().GroupBy(c => c.Field<object>(columName)).OrderBy(g => g.Key))
                        {
                            TreeNodeItemSelector node = TreeNodeItemSelector.CreateNode(v.First().Field<object>(columName).ToString(), v.Key, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.Default);
                            checkList.Nodes.Add(node);
                        }
                    }
                }
            }

            checkList.EndUpdate();
        }


        /// <summary>
        /// Add nodes to checkList
        /// </summary>
        /// <param name="vals"></param>
        private void BuildNodes(DataGridView grid, int columIndex)
        {
            if (!IsFilterChecklistEnabled)
                return;

            BindingSource bs = (BindingSource)grid.DataSource;
            DataTable gridTable = (DataTable)bs.DataSource;

            checkList.BeginUpdate();
            checkList.Nodes.Clear();

            if (gridTable != null)
            {
                //add select all node
                TreeNodeItemSelector allnode = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectAll.ToString()] + "            ", null, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.SelectAll);
                allnode.NodeFont = new Font(checkList.Font, FontStyle.Bold);
                checkList.Nodes.Add(allnode);

                if (gridTable.Rows.Count > 0)
                {
                    DataTable nonulls = null;
                    nonulls = gridTable.AsEnumerable().Where(r => r.Field<object>(columIndex) != null && r.Field<object>(columIndex) != DBNull.Value).CopyToDataTable();

                    if (nonulls == null)
                        return;

                    //add select empty node
                    if (gridTable.Rows.Count != nonulls.Rows.Count)
                    {
                        TreeNodeItemSelector nullnode = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectEmpty.ToString()] + "               ", null, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.SelectEmpty);
                        nullnode.NodeFont = new Font(checkList.Font, FontStyle.Bold);
                        checkList.Nodes.Add(nullnode);
                    }

                    //add datetime nodes
                    if (DataType == typeof(DateTime))
                    {
                        DataTable dtYear = nonulls.AsEnumerable().GroupBy(r => new { year = ((DateTime)r.Field<DateTime>(columIndex)).Year }).Select(g => g.OrderBy(r => r[columIndex]).First()).CopyToDataTable();

                        foreach (DataRow year in dtYear.Rows)
                        {
                            TreeNodeItemSelector yearnode = TreeNodeItemSelector.CreateNode(((DateTime)year.Field<DateTime>(columIndex)).Year.ToString(), year.Field<DateTime>(columIndex), CheckState.Checked, TreeNodeItemSelector.CustomNodeType.DateTimeNode);
                            checkList.Nodes.Add(yearnode);

                            DataTable dtMonth = nonulls.AsEnumerable().Where(y => (((DateTime)y.Field<DateTime>(columIndex)).Year == ((DateTime)year.Field<DateTime>(columIndex)).Year)).GroupBy(r => new { month = ((DateTime)r.Field<DateTime>(columIndex)).Month }).Select(g => g.OrderBy(r => ((DateTime)r[columIndex]).Year).First()).CopyToDataTable();

                            foreach (DataRow month in dtMonth.Rows)
                            {
                                TreeNodeItemSelector monthnode = yearnode.CreateChildNode(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(((DateTime)month.Field<DateTime>(columIndex)).Month), ((DateTime)month.Field<DateTime>(columIndex)));

                                DataTable dtDays = nonulls.AsEnumerable().Where(y => (((DateTime)y.Field<DateTime>(columIndex)).Year == ((DateTime)year.Field<DateTime>(columIndex)).Year) && (((DateTime)y.Field<DateTime>(columIndex)).Month == ((DateTime)month.Field<DateTime>(columIndex)).Month)).GroupBy(r => new { day = ((DateTime)r.Field<DateTime>(columIndex)).Day }).Select(g => g.OrderBy(r => ((DateTime)r[columIndex]).Month).First()).CopyToDataTable();

                                foreach (DataRow day in dtDays.Rows)
                                {
                                    TreeNodeItemSelector daysnode;

                                    if (!IsFilterDateAndTimeEnabled)
                                        daysnode = monthnode.CreateChildNode(((DateTime)day.Field<DateTime>(columIndex)).Day.ToString("D2"), ((DateTime)day.Field<DateTime>(columIndex)));
                                    else
                                    {
                                        daysnode = monthnode.CreateChildNode(((DateTime)day.Field<DateTime>(columIndex)).Day.ToString("D2"), ((DateTime)day.Field<DateTime>(columIndex)));

                                        DataTable dtHours = nonulls.AsEnumerable().Where(y => (((DateTime)y.Field<DateTime>(columIndex)).Year == ((DateTime)year.Field<DateTime>(columIndex)).Year) && (((DateTime)y.Field<DateTime>(columIndex)).Month == ((DateTime)month.Field<DateTime>(columIndex)).Month) && (((DateTime)y.Field<DateTime>(columIndex)).Day == ((DateTime)day.Field<DateTime>(columIndex)).Day)).GroupBy(r => new { hour = ((DateTime)r.Field<DateTime>(columIndex)).Hour }).Select(g => g.OrderBy(r => ((DateTime)r[columIndex]).Hour).First()).CopyToDataTable();

                                        foreach (DataRow hour in dtHours.Rows)
                                        {
                                            TreeNodeItemSelector hoursnode = daysnode.CreateChildNode(((DateTime)hour.Field<DateTime>(columIndex)).Hour.ToString("D2") + " " + "h", ((DateTime)hour.Field<DateTime>(columIndex)));

                                            DataTable dtMins = nonulls.AsEnumerable().Where(y => (((DateTime)y.Field<DateTime>(columIndex)).Year == ((DateTime)year.Field<DateTime>(columIndex)).Year) && (((DateTime)y.Field<DateTime>(columIndex)).Month == ((DateTime)month.Field<DateTime>(columIndex)).Month) && (((DateTime)y.Field<DateTime>(columIndex)).Day == ((DateTime)day.Field<DateTime>(columIndex)).Day) && (((DateTime)y.Field<DateTime>(columIndex)).Hour == ((DateTime)hour.Field<DateTime>(columIndex)).Hour)).GroupBy(r => new { hour = ((DateTime)r.Field<DateTime>(columIndex)).Minute }).Select(g => g.OrderBy(r => ((DateTime)r[columIndex]).Minute).First()).CopyToDataTable();

                                            foreach (DataRow min in dtMins.Rows)
                                            {
                                                TreeNodeItemSelector minsnode = hoursnode.CreateChildNode(((DateTime)min.Field<DateTime>(columIndex)).Minute.ToString("D2") + " " + "m", ((DateTime)min.Field<DateTime>(columIndex)));
                                                DataTable dtSecs = nonulls.AsEnumerable().Where(y => (((DateTime)y.Field<DateTime>(columIndex)).Year == ((DateTime)year.Field<DateTime>(columIndex)).Year) && (((DateTime)y.Field<DateTime>(columIndex)).Month == ((DateTime)month.Field<DateTime>(columIndex)).Month) && (((DateTime)y.Field<DateTime>(columIndex)).Day == ((DateTime)day.Field<DateTime>(columIndex)).Day) && (((DateTime)y.Field<DateTime>(columIndex)).Hour == ((DateTime)hour.Field<DateTime>(columIndex)).Hour) && (((DateTime)y.Field<DateTime>(columIndex)).Minute == ((DateTime)min.Field<DateTime>(columIndex)).Minute)).GroupBy(r => new { sec = ((DateTime)r.Field<DateTime>(columIndex)).Second }).Select(g => g.OrderBy(r => ((DateTime)r[columIndex]).Second).First()).CopyToDataTable();
                                                foreach (DataRow sec in dtSecs.Rows)
                                                {
                                                    TreeNodeItemSelector secsnode = minsnode.CreateChildNode(((DateTime)sec.Field<DateTime>(columIndex)).Second.ToString("D2") + " " + "s", ((DateTime)sec.Field<DateTime>(columIndex)));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //add timespan nodes
                    else if (DataType == typeof(TimeSpan))
                    {
                        DataTable dtDays = nonulls.AsEnumerable().GroupBy(r => new { day = ((TimeSpan)r.Field<TimeSpan>(columIndex)).Days }).Select(g => g.OrderBy(r => ((TimeSpan)r.Field<TimeSpan>(columIndex))).First()).CopyToDataTable();

                        foreach (DataRow day in dtDays.Rows)
                        {
                            TreeNodeItemSelector daysnode = TreeNodeItemSelector.CreateNode(((TimeSpan)day.Field<TimeSpan>(columIndex)).Days.ToString("D2"), ((TimeSpan)day.Field<TimeSpan>(columIndex)), CheckState.Checked, TreeNodeItemSelector.CustomNodeType.DateTimeNode);
                            checkList.Nodes.Add(daysnode);

                            DataTable dtHours = nonulls.AsEnumerable().Where(r => ((TimeSpan)r.Field<TimeSpan>(columIndex)).Days == ((TimeSpan)day.Field<TimeSpan>(columIndex)).Days).GroupBy(r => new { hour = ((TimeSpan)r.Field<TimeSpan>(columIndex)).Hours }).Select(g => g.OrderBy(r => r.Field<TimeSpan>(columIndex).Hours).First()).CopyToDataTable();

                            foreach (DataRow hour in dtHours.Rows)
                            {
                                TreeNodeItemSelector hoursnode = daysnode.CreateChildNode(((TimeSpan)hour.Field<TimeSpan>(columIndex)).Hours.ToString("D2") + " " + "h", ((TimeSpan)hour.Field<TimeSpan>(columIndex)).Hours);

                                DataTable dtMins = nonulls.AsEnumerable().Where(r => ((TimeSpan)r.Field<TimeSpan>(columIndex)).Hours == ((TimeSpan)hour.Field<TimeSpan>(columIndex)).Hours).GroupBy(r => new { day = ((TimeSpan)r.Field<TimeSpan>(columIndex)).Minutes }).Select(g => g.OrderBy(r => ((TimeSpan)r.Field<TimeSpan>(columIndex))).First()).CopyToDataTable();

                                foreach (DataRow min in dtMins.Rows)
                                {
                                    TreeNodeItemSelector minsnode = hoursnode.CreateChildNode(((TimeSpan)min.Field<TimeSpan>(columIndex)).Minutes.ToString("D2") + " " + "m", ((TimeSpan)min.Field<TimeSpan>(columIndex)));

                                    DataTable dtSecs = nonulls.AsEnumerable().Where(r => ((TimeSpan)r.Field<TimeSpan>(columIndex)).Minutes == ((TimeSpan)hour.Field<TimeSpan>(columIndex)).Minutes).GroupBy(r => new { day = ((TimeSpan)r.Field<TimeSpan>(columIndex)).Seconds }).Select(g => g.OrderBy(r => ((TimeSpan)r.Field<TimeSpan>(columIndex))).First()).CopyToDataTable();

                                    foreach (DataRow sec in dtSecs.Rows)
                                    {
                                        TreeNodeItemSelector secsnode = minsnode.CreateChildNode(((TimeSpan)sec.Field<TimeSpan>(columIndex)).Seconds.ToString("D2") + " " + "s", ((TimeSpan)sec.Field<TimeSpan>(columIndex)));
                                    }
                                }
                            }
                        }
                    }

                    //add boolean nodes
                    else if (DataType == typeof(bool))
                    {
                        //var values = nonulls.Where<DataGridViewCell>(c => (bool)c.Value == true);
                        DataTable values = gridTable.AsEnumerable().Where(r => !(bool)r.Field<bool>(columIndex)).CopyToDataTable();
                        if (values == null)
                            return;
                        if (values.Rows.Count != nonulls.Rows.Count)
                        {
                            TreeNodeItemSelector node = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectFalse.ToString()], false, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.Default);
                            checkList.Nodes.Add(node);
                        }

                        if (values.Rows.Count > 0)
                        {
                            TreeNodeItemSelector node = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectTrue.ToString()], true, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.Default);
                            checkList.Nodes.Add(node);
                        }
                    }

                    //ignore image nodes
                    else if (DataType == typeof(Bitmap))
                    { }

                    //add string nodes
                    else if (DataType == typeof(string))
                    {
                        foreach (var v in nonulls.AsEnumerable().GroupBy(c => c.Field<string>(columIndex)).OrderBy(g => g.Key))
                        {
                            TreeNodeItemSelector node = TreeNodeItemSelector.CreateNode(v.First().Field<string>(columIndex).ToString(), v.Key, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.Default);
                            checkList.Nodes.Add(node);
                        }
                    }
                }
            }

            checkList.EndUpdate();
        }

        /// <summary>
        /// Check
        /// </summary>
        /// <param name="node"></param>
        private void NodeCheckChange(TreeNodeItemSelector node)
        {
            if (node.CheckState == CheckState.Checked)
                node.CheckState = CheckState.Unchecked;
            else
                node.CheckState = CheckState.Checked;

            if (node.NodeType == TreeNodeItemSelector.CustomNodeType.SelectAll)
            {
                SetNodesCheckState(checkList.Nodes, node.Checked);
                button_filter.Enabled = node.Checked;
            }
            else
            {
                if (node.Nodes.Count > 0)
                {
                    SetNodesCheckState(node.Nodes, node.Checked);
                }

                //refresh nodes
                CheckState state = UpdateNodesCheckState(checkList.Nodes);

                GetSelectAllNode().CheckState = state;
                button_filter.Enabled = !(state == CheckState.Unchecked);
            }
        }

        /// <summary>
        /// Set Nodes CheckState
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="isChecked"></param>
        private void SetNodesCheckState(TreeNodeCollection nodes, bool isChecked)
        {
            foreach (TreeNodeItemSelector node in nodes)
            {
                node.Checked = isChecked;
                if (node.Nodes != null && node.Nodes.Count > 0)
                    SetNodesCheckState(node.Nodes, isChecked);
            }
        }

        /// <summary>
        /// Update Nodes CheckState recursively
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private CheckState UpdateNodesCheckState(TreeNodeCollection nodes)
        {
            CheckState result = CheckState.Unchecked;
            bool isFirstNode = true;
            bool isAllNodesSomeCheckState = true;

            foreach (TreeNodeItemSelector n in nodes)
            {
                if (n.NodeType == TreeNodeItemSelector.CustomNodeType.SelectAll)
                    continue;

                if (n.Nodes.Count > 0)
                {
                    n.CheckState = UpdateNodesCheckState(n.Nodes);
                }

                if (isFirstNode)
                {
                    result = n.CheckState;
                    isFirstNode = false;
                }
                else
                {
                    if (result != n.CheckState)
                        isAllNodesSomeCheckState = false;
                }
            }

            if (isAllNodesSomeCheckState)
                return result;
            else
                return CheckState.Indeterminate;
        }

        /// <summary>
        /// Get the SelectAll Node
        /// </summary>
        /// <returns></returns>
        private TreeNodeItemSelector GetSelectAllNode()
        {
            TreeNodeItemSelector result = null;
            int i = 0;
            foreach (TreeNodeItemSelector n in checkList.Nodes)
            {
                if (n.NodeType == TreeNodeItemSelector.CustomNodeType.SelectAll)
                {
                    result = n;
                    break;
                }
                else if (i > 2)
                    break;
                else
                    i++;
            }

            return result;
        }

        /// <summary>
        /// Get the SelectEmpty Node
        /// </summary>
        /// <returns></returns>
        private TreeNodeItemSelector GetSelectEmptyNode()
        {
            TreeNodeItemSelector result = null;
            int i = 0;
            foreach (TreeNodeItemSelector n in checkList.Nodes)
            {
                if (n.NodeType == TreeNodeItemSelector.CustomNodeType.SelectEmpty)
                {
                    result = n;
                    break;
                }
                else if (i > 2)
                    break;
                else
                    i++;
            }

            return result;
        }

        /// <summary>
        /// Duplicate Nodes
        /// </summary>
        private void DuplicateNodes()
        {
            _startingNodes = new TreeNodeItemSelector[checkList.Nodes.Count];
            int i = 0;
            foreach (TreeNodeItemSelector n in checkList.Nodes)
            {
                _startingNodes[i] = n.Clone();
                i++;
            }
        }

        /// <summary>
        /// Duplicate Filter on Nodes
        /// </summary>
        private void DuplicateFilterNodes()
        {
            _filterNodes = new TreeNodeItemSelector[checkList.Nodes.Count];
            int i = 0;
            foreach (TreeNodeItemSelector n in checkList.Nodes)
            {
                _filterNodes[i] = n.Clone();
                i++;
            }
        }

        /// <summary>
        /// Restore Nodes
        /// </summary>
        private void RestoreNodes()
        {
            checkList.Nodes.Clear();
            if (_startingNodes != null)
                checkList.Nodes.AddRange(_startingNodes);
        }

        /// <summary>
        /// Restore Filter on Nodes
        /// </summary>
        private void RestoreFilterNodes()
        {
            checkList.Nodes.Clear();
            if (_filterNodes != null)
                checkList.Nodes.AddRange(_filterNodes);
        }

        #endregion


        #region checklist filter events

        /// <summary>
        /// CheckList NodeMouseClick event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeViewHitTestInfo HitTestInfo = checkList.HitTest(e.X, e.Y);
            if (HitTestInfo != null && HitTestInfo.Location == TreeViewHitTestLocations.StateImage)
                //check the node check status
                NodeCheckChange(e.Node as TreeNodeItemSelector);
        }

        /// <summary>
        /// CheckList KeyDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                //check the node check status
                NodeCheckChange(checkList.SelectedNode as TreeNodeItemSelector);
        }

        /// <summary>
        /// CheckList NodeMouseDoubleClick event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNodeItemSelector n = e.Node as TreeNodeItemSelector;
            //set the new node check status
            SetNodesCheckState(checkList.Nodes, false);
            n.CheckState = CheckState.Unchecked;
            NodeCheckChange(n);
            //do Filter by checkList
            Button_ok_Click(this, new EventArgs());
        }

        /// <summary>
        /// CheckList MouseEnter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckList_MouseEnter(object sender, EventArgs e)
        {
            checkList.Focus();
        }

        /// <summary>
        /// CheckList MouseLeave envet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckList_MouseLeave(object sender, EventArgs e)
        {
            Focus();
        }

        /// <summary>
        /// Set the Filter by checkList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ok_Click(object sender, EventArgs e)
        {
            SetCheckListFilter();
            Close();
        }

        /// <summary>
        /// Undo changed by checkList 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_cancel_Click(object sender, EventArgs e)
        {
            bool restoredByFilter = false;
            if (_checkTextFilterRemoveNodesOnSearch && _checkTextFilterSetByText)
            {
                _initialNodes = new TreeNodeItemSelector[_restoreNodes.Count()];
                int i = 0;
                foreach (TreeNodeItemSelector n in _restoreNodes)
                {
                    _initialNodes[i] = n.Clone();
                    i++;
                }

                restoredByFilter = true;
                checkList.BeginUpdate();
                checkList.Nodes.Clear();
                foreach (TreeNodeItemSelector node in _restoreNodes)
                {
                    checkList.Nodes.Add(node);
                }
                checkList.EndUpdate();
            }

            if (!restoredByFilter)
                RestoreNodes();
            Close();
        }

        #endregion


        #region filter methods

        /// <summary>
        /// UnCheck all Custom Filter presets
        /// </summary>
        private void UnCheckCustomFilters()
        {
            for (int i = 2; i < customFilterLastFiltersListMenuItem.DropDownItems.Count; i++)
            {
                (customFilterLastFiltersListMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked = false;
            }
        }

        /// <summary>
        /// Set a Custom Filter
        /// </summary>
        /// <param name="filtersMenuItemIndex"></param>
        private void SetCustomFilter(int filtersMenuItemIndex)
        {
            if (_activeFilterType == FilterType.CheckList)
                SetNodesCheckState(checkList.Nodes, false);

            string filterstring = customFilterLastFiltersListMenuItem.DropDownItems[filtersMenuItemIndex].Tag.ToString();
            string viewfilterstring = customFilterLastFiltersListMenuItem.DropDownItems[filtersMenuItemIndex].Text;

            //do preset jobs
            if (filtersMenuItemIndex != 2)
            {
                for (int i = filtersMenuItemIndex; i > 2; i--)
                {
                    customFilterLastFiltersListMenuItem.DropDownItems[i].Text = customFilterLastFiltersListMenuItem.DropDownItems[i - 1].Text;
                    customFilterLastFiltersListMenuItem.DropDownItems[i].Tag = customFilterLastFiltersListMenuItem.DropDownItems[i - 1].Tag;
                }

                customFilterLastFiltersListMenuItem.DropDownItems[2].Text = viewfilterstring;
                customFilterLastFiltersListMenuItem.DropDownItems[2].Tag = filterstring;
            }

            //uncheck other preset
            for (int i = 3; i < customFilterLastFiltersListMenuItem.DropDownItems.Count; i++)
            {
                (customFilterLastFiltersListMenuItem.DropDownItems[i] as ToolStripMenuItem).Checked = false;
            }

            (customFilterLastFiltersListMenuItem.DropDownItems[2] as ToolStripMenuItem).Checked = true;
            _activeFilterType = FilterType.Custom;

            //get Filter string
            string oldfilter = FilterString;
            FilterString = filterstring;

            //set CheckList nodes
            SetNodesCheckState(checkList.Nodes, false);
            DuplicateFilterNodes();

            customFilterLastFiltersListMenuItem.Checked = true;
            button_filter.Enabled = false;

            //fire Filter changed
            if (oldfilter != FilterString && FilterChanged != null)
                FilterChanged(this, new EventArgs());
        }

        #endregion


        #region filter events

        /// <summary>
        /// Cancel Filter Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelFilterMenuItem_Click(object sender, EventArgs e)
        {
            string oldfilter = FilterString;

            //clean Filter
            CleanFilter();

            //fire Filter changed
            if (oldfilter != FilterString && FilterChanged != null)
                FilterChanged(this, new EventArgs());
        }

        /// <summary>
        /// Cancel Filter MouseEnter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelFilterMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Enabled)
                (sender as ToolStripMenuItem).Select();
        }

        /// <summary>
        /// Custom Filter Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomFilterMenuItem_Click(object sender, EventArgs e)
        {
            //ignore image nodes
            if (DataType == typeof(Bitmap))
                return;

            //open a new Custom filter window
            FormCustomFilter flt = new FormCustomFilter(DataType, IsFilterDateAndTimeEnabled);

            if (flt.ShowDialog() == DialogResult.OK)
            {
                //add the new Filter presets

                string filterString = flt.FilterString;
                string viewFilterString = flt.FilterStringDescription;

                int index = -1;

                for (int i = 2; i < customFilterLastFiltersListMenuItem.DropDownItems.Count; i++)
                {
                    if (customFilterLastFiltersListMenuItem.DropDown.Items[i].Available)
                    {
                        if (customFilterLastFiltersListMenuItem.DropDownItems[i].Text == viewFilterString && customFilterLastFiltersListMenuItem.DropDownItems[i].Tag.ToString() == filterString)
                        {
                            index = i;
                            break;
                        }
                    }
                    else
                        break;
                }

                if (index < 2)
                {
                    for (int i = customFilterLastFiltersListMenuItem.DropDownItems.Count - 2; i > 1; i--)
                    {
                        if (customFilterLastFiltersListMenuItem.DropDownItems[i].Available)
                        {
                            customFilterLastFiltersListMenuItem.DropDownItems[i + 1].Text = customFilterLastFiltersListMenuItem.DropDownItems[i].Text;
                            customFilterLastFiltersListMenuItem.DropDownItems[i + 1].Tag = customFilterLastFiltersListMenuItem.DropDownItems[i].Tag;
                        }
                    }
                    index = 2;

                    customFilterLastFiltersListMenuItem.DropDownItems[2].Text = viewFilterString;
                    customFilterLastFiltersListMenuItem.DropDownItems[2].Tag = filterString;
                }

                //set the Custom Filter
                SetCustomFilter(index);
            }
        }

        /// <summary>
        /// Custom Filter preset MouseEnter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomFilterLastFiltersListMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Enabled)
                (sender as ToolStripMenuItem).Select();
        }

        /// <summary>
        /// Custom Filter preset MouseEnter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomFilterLastFiltersListMenuItem_Paint(Object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(customFilterLastFiltersListMenuItem.Width - 12, 7, 10, 10);
            ControlPaint.DrawMenuGlyph(e.Graphics, rect, MenuGlyph.Arrow, Color.Black, Color.Transparent);
        }

        /// <summary>
        /// Custom Filter preset 1 Visibility changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomFilterLastFilter1MenuItem_VisibleChanged(object sender, EventArgs e)
        {
            toolStripSeparator2MenuItem.Visible = !customFilterLastFilter1MenuItem.Visible;
            (sender as ToolStripMenuItem).VisibleChanged -= CustomFilterLastFilter1MenuItem_VisibleChanged;
        }

        /// <summary>
        /// Custom Filter preset Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomFilterLastFilterMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuitem = sender as ToolStripMenuItem;

            for (int i = 2; i < customFilterLastFiltersListMenuItem.DropDownItems.Count; i++)
            {
                if (customFilterLastFiltersListMenuItem.DropDownItems[i].Text == menuitem.Text && customFilterLastFiltersListMenuItem.DropDownItems[i].Tag.ToString() == menuitem.Tag.ToString())
                {
                    //set current filter preset as active
                    SetCustomFilter(i);
                    break;
                }
            }
        }

        /// <summary>
        /// Custom Filter preset TextChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomFilterLastFilterMenuItem_TextChanged(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Available = true;
            (sender as ToolStripMenuItem).TextChanged -= CustomFilterLastFilterMenuItem_TextChanged;
        }

        /// <summary>
        /// Check list filter changer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckTextFilter_TextChanged(object sender, EventArgs e)
        {
            if (!_checkTextFilterChangedEnabled)
                return;
            if (!String.IsNullOrEmpty(checkTextFilter.Text))
                _checkTextFilterSetByText = true;
            else
                _checkTextFilterSetByText = false;
            if (_checkTextFilterRemoveNodesOnSearch)
            {
                _startingNodes = _initialNodes;

                checkList.BeginUpdate();
                RestoreNodes();
            }
            TreeNodeItemSelector allnode = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectAll.ToString()] + "            ", null, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.SelectAll);
            TreeNodeItemSelector nullnode = TreeNodeItemSelector.CreateNode(AdvancedDataGridView.Translations[AdvancedDataGridView.TranslationKey.ADGVNodeSelectEmpty.ToString()] + "               ", null, CheckState.Checked, TreeNodeItemSelector.CustomNodeType.SelectEmpty);
            TreeNodeItemSelector allnodesel = null;
            for (int i = checkList.Nodes.Count - 1; i >= 0; i--)
            {
                TreeNodeItemSelector node = checkList.Nodes[i] as TreeNodeItemSelector;
                if (node.Text == allnode.Text)
                {
                    allnodesel = node;
                    node.CheckState = CheckState.Indeterminate;
                }
                else if (node.Text == nullnode.Text)
                {
                    node.CheckState = CheckState.Unchecked;
                }
                else
                {
                    if (node.Text.ToLower().Contains(checkTextFilter.Text.ToLower()))
                        node.Checked = false;
                    else
                        node.Checked = true;
                    NodeCheckChange(node as TreeNodeItemSelector);
                }
            }
            if (_checkTextFilterRemoveNodesOnSearch)
            {
                foreach (TreeNodeItemSelector node in _initialNodes)
                {
                    if (node.Text == allnode.Text)
                    {
                        allnodesel = node;
                        node.CheckState = CheckState.Indeterminate;
                    }
                    else if (node.Text == nullnode.Text)
                    {
                        node.CheckState = CheckState.Unchecked;
                    }
                    else
                    {
                        if (node.Text.ToLower().Contains(checkTextFilter.Text.ToLower()))
                            node.CheckState = CheckState.Checked;
                        else
                            node.CheckState = CheckState.Unchecked;
                    }
                }
                checkList.EndUpdate();
                for (int i = checkList.Nodes.Count - 1; i >= 0; i--)
                {
                    TreeNodeItemSelector node = checkList.Nodes[i] as TreeNodeItemSelector;
                    if (!(node.Text == allnode.Text || node.Text == nullnode.Text))
                    {
                        if (!node.Text.ToLower().Contains(checkTextFilter.Text.ToLower()))
                        {
                            node.Remove();
                        }
                    }
                }
            }
        }

        #endregion


        #region sort events

        /// <summary>
        /// Sort ASC Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortASCMenuItem_Click(object sender, EventArgs e)
        {
            //ignore image nodes
            if (DataType == typeof(Bitmap))
                return;

            sortASCMenuItem.Checked = true;
            sortDESCMenuItem.Checked = false;
            _activeSortType = SortType.ASC;

            //get Sort String
            string oldsort = SortString;
            SortString = "[{0}] ASC";

            //fire Sort Changed
            if (oldsort != SortString && SortChanged != null)
                SortChanged(this, new EventArgs());
        }

        /// <summary>
        /// Sort ASC MouseEnter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortASCMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Enabled)
                (sender as ToolStripMenuItem).Select();
        }

        /// <summary>
        /// Sort DESC Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortDESCMenuItem_Click(object sender, EventArgs e)
        {
            //ignore image nodes
            if (DataType == typeof(Bitmap))
                return;

            sortASCMenuItem.Checked = false;
            sortDESCMenuItem.Checked = true;
            _activeSortType = SortType.DESC;

            //get Sort String
            string oldsort = SortString;
            SortString = "[{0}] DESC";

            //fire Sort Changed
            if (oldsort != SortString && SortChanged != null)
                SortChanged(this, new EventArgs());
        }

        /// <summary>
        /// Sort DESC MouseEnter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortDESCMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Enabled)
                (sender as ToolStripMenuItem).Select();
        }

        /// <summary>
        /// Cancel Sort Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelSortMenuItem_Click(object sender, EventArgs e)
        {
            string oldsort = SortString;
            //clean Sort
            CleanSort();
            //fire Sort changed
            if (oldsort != SortString && SortChanged != null)
                SortChanged(this, new EventArgs());
        }

        /// <summary>
        /// Cancel Sort MouseEnter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelSortMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Enabled)
                (sender as ToolStripMenuItem).Select();
        }


        #endregion


        #region resize methods

        /// <summary>
        /// Resize the box
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        private void ResizeBox(int w, int h)
        {
            sortASCMenuItem.Width = w - 1;
            sortDESCMenuItem.Width = w - 1;
            cancelSortMenuItem.Width = w - 1;
            cancelFilterMenuItem.Width = w - 1;
            customFilterMenuItem.Width = w - 1;
            customFilterLastFiltersListMenuItem.Width = w - 1;
            checkFilterListControlHost.Size = new Size(w - 35, h - 160 - 25);
            checkFilterListPanel.Size = new Size(w - 35, h - 160 - 25);
            checkTextFilterControlHost.Width = w - 35;
            checkList.Bounds = new Rectangle(4, 4, w - 35 - 8, h - 160 - 25 - 8);
            checkFilterListButtonsControlHost.Size = new Size(w - 35, 24);
            button_filter.Location = new Point(w - 35 - 164, 0);
            button_undofilter.Location = new Point(w - 35 - 79, 0);
            resizeBoxControlHost.Margin = new Padding(w - 46, 0, 0, 0);
            Size = new Size(w, h);
        }

        /// <summary>
        /// Clean box for Resize
        /// </summary>
        private void ResizeClean()
        {
            if (_resizeEndPoint.X != -1)
            {
                Point startPoint = PointToScreen(MenuStrip._resizeStartPoint);

                Rectangle rc = new Rectangle(startPoint.X, startPoint.Y, _resizeEndPoint.X, _resizeEndPoint.Y)
                {
                    X = Math.Min(startPoint.X, _resizeEndPoint.X),
                    Width = Math.Abs(startPoint.X - _resizeEndPoint.X),

                    Y = Math.Min(startPoint.Y, _resizeEndPoint.Y),
                    Height = Math.Abs(startPoint.Y - _resizeEndPoint.Y)
                };

                ControlPaint.DrawReversibleFrame(rc, Color.Black, FrameStyle.Dashed);

                _resizeEndPoint.X = -1;
            }
        }

        #endregion


        #region resize events

        /// <summary>
        /// Resize MouseDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResizeBoxControlHost_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ResizeClean();
            }
        }

        /// <summary>
        /// Resize MouseMove event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResizeBoxControlHost_MouseMove(object sender, MouseEventArgs e)
        {
            if (Visible)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    int x = e.X;
                    int y = e.Y;

                    ResizeClean();

                    x += Width - resizeBoxControlHost.Width;
                    y += Height - resizeBoxControlHost.Height;

                    x = Math.Max(x, MinimumSize.Width - 1);
                    y = Math.Max(y, MinimumSize.Height - 1);

                    Point StartPoint = PointToScreen(MenuStrip._resizeStartPoint);
                    Point EndPoint = PointToScreen(new Point(x, y));

                    Rectangle rc = new Rectangle
                    {
                        X = Math.Min(StartPoint.X, EndPoint.X),
                        Width = Math.Abs(StartPoint.X - EndPoint.X),

                        Y = Math.Min(StartPoint.Y, EndPoint.Y),
                        Height = Math.Abs(StartPoint.Y - EndPoint.Y)
                    };

                    ControlPaint.DrawReversibleFrame(rc, Color.Black, FrameStyle.Dashed);

                    _resizeEndPoint.X = EndPoint.X;
                    _resizeEndPoint.Y = EndPoint.Y;
                }
            }
        }

        /// <summary>
        /// Resize MouseUp event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResizeBoxControlHost_MouseUp(object sender, MouseEventArgs e)
        {
            if (_resizeEndPoint.X != -1)
            {
                ResizeClean();

                if (Visible)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        int newWidth = e.X + Width - resizeBoxControlHost.Width;
                        int newHeight = e.Y + Height - resizeBoxControlHost.Height;

                        newWidth = Math.Max(newWidth, MinimumSize.Width);
                        newHeight = Math.Max(newHeight, MinimumSize.Height);

                        ResizeBox(newWidth, newHeight);
                    }
                }
            }
        }

        /// <summary>
        /// Resize Paint event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResizeBoxControlHost_Paint(Object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.MenuStrip_ResizeGrip, 0, 0);
        }

        #endregion

    }
}